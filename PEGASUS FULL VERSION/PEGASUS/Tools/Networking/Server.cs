using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using PEGASUS.Tools.NetSerializer;
using PEGASUS.Tools.Packets;
using PEGASUS.Utilities;

namespace PEGASUS.Tools.Networking
	{
public class Server
{
	public delegate void ServerStateEventHandler(Server s, bool listening, ushort port);

	public delegate void ClientStateEventHandler(Server s, Client c, bool connected);

	public delegate void ClientReadEventHandler(Server s, Client c, IPacket packet);

	public delegate void ClientWriteEventHandler(Server s, Client c, IPacket packet, long length, byte[] rawData);

	private Socket _handle;

	private SocketAsyncEventArgs _item;

	private List<Client> _clients;

	private readonly object _clientsLock = new object();

	public ushort Port { get; private set; }

	public long BytesReceived { get; set; }

	public long BytesSent { get; set; }

	public int BUFFER_SIZE => 16384;

	public uint KEEP_ALIVE_TIME => 25000u;

	public uint KEEP_ALIVE_INTERVAL => 25000u;

	public int HEADER_SIZE => 4;

	public int MAX_PACKET_SIZE => 5242880;

	public PooledBufferManager BufferManager { get; private set; }

	public bool Listening { get; private set; }

	protected Client[] Clients
	{
		get
		{
			lock (_clientsLock)
			{
				return _clients.ToArray();
			}
		}
	}

	public Serializer Serializer { get; protected set; }

	protected bool ProcessingDisconnect { get; set; }

	public event ServerStateEventHandler ServerState;

	public event ClientStateEventHandler ClientState;

	public event ClientReadEventHandler ClientRead;

	public event ClientWriteEventHandler ClientWrite;

	private void OnServerState(bool listening)
	{
		if (Listening != listening)
		{
			Listening = listening;
			this.ServerState?.Invoke(this, listening, Port);
		}
	}

	private void OnClientState(Client c, bool connected)
	{
		ClientStateEventHandler clientState = this.ClientState;
		if (!connected)
		{
			RemoveClient(c);
		}
		clientState?.Invoke(this, c, connected);
	}

	private void OnClientRead(Client c, IPacket packet)
	{
		this.ClientRead?.Invoke(this, c, packet);
	}

	private void OnClientWrite(Client c, IPacket packet, long length, byte[] rawData)
	{
		this.ClientWrite?.Invoke(this, c, packet, length, rawData);
	}

	protected Server()
	{
		_clients = new List<Client>();
		BufferManager = new PooledBufferManager(BUFFER_SIZE, 1)
		{
			ClearOnReturn = false
		};
	}

	public void Listen(ushort port, bool ipv6)
	{
		Port = port;
		try
		{
			if (!Listening)
			{
				if (_handle != null)
				{
					_handle.Close();
					_handle = null;
				}
				if (Socket.OSSupportsIPv6 && ipv6)
				{
					_handle = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
					SocketOptionName optionName = SocketOptionName.IPv6Only;
					_handle.SetSocketOption(SocketOptionLevel.IPv6, optionName, 0);
					_handle.Bind(new IPEndPoint(IPAddress.IPv6Any, port));
				}
				else
				{
					_handle = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
					_handle.Bind(new IPEndPoint(IPAddress.Any, port));
				}
				_handle.Listen(1000);
				ProcessingDisconnect = false;
				OnServerState(listening: true);
				if (_item != null)
				{
					_item.Dispose();
					_item = null;
				}
				_item = new SocketAsyncEventArgs();
				_item.Completed += AcceptClient;
				if (!_handle.AcceptAsync(_item))
				{
					AcceptClient(null, _item);
				}
			}
		}
		catch (SocketException ex)
		{
			if (ex.ErrorCode == 10048)
			{
				MessageBox.Show("The port is already in use.", "Listen Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				MessageBox.Show($"An unexpected socket error occurred: {ex.Message}", "Unexpected Listen Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			Disconnect();
		}
		catch (Exception)
		{
			Disconnect();
		}
	}

	private void AcceptClient(object s, SocketAsyncEventArgs e)
	{
		try
		{
			do
			{
				switch (e.SocketError)
				{
					case SocketError.Success:
						{
							if (BufferManager.BuffersAvailable == 0)
							{
								BufferManager.IncreaseBufferCount(1);
							}
							Client client = new Client(this, e.AcceptSocket);
							AddClient(client);
							OnClientState(client, connected: true);
							break;
						}
					default:
						throw new Exception("SocketError");
					case SocketError.ConnectionReset:
						break;
				}
				e.AcceptSocket = null;
			}
			while (!_handle.AcceptAsync(e));
		}
		catch (ObjectDisposedException)
		{
		}
		catch (Exception)
		{
			Disconnect();
		}
	}

	private void AddClient(Client client)
	{
		lock (_clientsLock)
		{
			client.ClientState += OnClientState;
			client.ClientRead += OnClientRead;
			client.ClientWrite += OnClientWrite;
			_clients.Add(client);
		}
	}

	private void RemoveClient(Client client)
	{
		if (ProcessingDisconnect)
		{
			return;
		}
		lock (_clientsLock)
		{
			client.ClientState -= OnClientState;
			client.ClientRead -= OnClientRead;
			client.ClientWrite -= OnClientWrite;
			_clients.Remove(client);
		}
	}

	public void Disconnect()
	{
		if (ProcessingDisconnect)
		{
			return;
		}
		ProcessingDisconnect = true;
		if (_handle != null)
		{
			_handle.Close();
			_handle = null;
		}
		if (_item != null)
		{
			_item.Dispose();
			_item = null;
		}
		lock (_clientsLock)
		{
			while (_clients.Count != 0)
			{
				try
				{
					_clients[0].Disconnect();
					_clients[0].ClientState -= OnClientState;
					_clients[0].ClientRead -= OnClientRead;
					_clients[0].ClientWrite -= OnClientWrite;
					_clients.RemoveAt(0);
				}
				catch
				{
				}
			}
		}
		ProcessingDisconnect = false;
		OnServerState(listening: false);
	}
}
}