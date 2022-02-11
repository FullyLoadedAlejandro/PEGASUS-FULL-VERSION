using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using PEGASUS.Algorithm;
using PEGASUS.Tools.Compression;
using PEGASUS.Tools.Packets;

namespace PEGASUS.Tools.Networking
	{
public class Client : IEquatable<Client>
{
	public delegate void ClientStateEventHandler(Client s, bool connected);

	public delegate void ClientReadEventHandler(Client s, IPacket packet);

	public delegate void ClientWriteEventHandler(Client s, IPacket packet, long length, byte[] rawData);

	public enum ReceiveType
	{
		Header,
		Payload
	}

	private Socket _handle;

	private readonly Queue<byte[]> _sendBuffers = new Queue<byte[]>();

	private bool _sendingPackets;

	private readonly object _sendingPacketsLock = new object();

	private readonly Queue<byte[]> _readBuffers = new Queue<byte[]>();

	private bool _readingPackets;

	private readonly object _readingPacketsLock = new object();

	private int _readOffset;

	private int _writeOffset;

	private int _tempHeaderOffset;

	private int _readableDataLen;

	private int _payloadLen;

	private ReceiveType _receiveState;

	private readonly Server _parentServer;

	private byte[] _readBuffer;

	private byte[] _payloadBuffer;

	private byte[] _tempHeader;

	private bool _appendHeader;

	private const bool encryptionEnabled = true;

	private const bool compressionEnabled = true;

	public DateTime ConnectedTime { get; private set; }

	public bool Connected { get; private set; }

	public bool Authenticated { get; set; }

	public UserState Value { get; set; }

	public IPEndPoint EndPoint { get; private set; }

	public event ClientStateEventHandler ClientState;

	public event ClientReadEventHandler ClientRead;

	public event ClientWriteEventHandler ClientWrite;

	private void OnClientState(bool connected)
	{
		if (Connected != connected)
		{
			Connected = connected;
			this.ClientState?.Invoke(this, connected);
		}
	}

	private void OnClientRead(IPacket packet)
	{
		this.ClientRead?.Invoke(this, packet);
	}

	private void OnClientWrite(IPacket packet, long length, byte[] rawData)
	{
		this.ClientWrite?.Invoke(this, packet, length, rawData);
	}

	public bool Equals(Client c)
	{
		try
		{
			return EndPoint.Port.Equals(c.EndPoint.Port);
		}
		catch (Exception)
		{
			return false;
		}
	}

	public override bool Equals(object obj)
	{
		return Equals(obj as Client);
	}

	public override int GetHashCode()
	{
		return EndPoint.Port.GetHashCode();
	}

	public Client(Server parentServer, Socket socket)
	{
		try
		{
			_parentServer = parentServer;
			Initialize();
			_handle = socket;
			_handle.SetKeepAliveEx(_parentServer.KEEP_ALIVE_INTERVAL, _parentServer.KEEP_ALIVE_TIME);
			EndPoint = (IPEndPoint)_handle.RemoteEndPoint;
			ConnectedTime = DateTime.UtcNow;
			_readBuffer = _parentServer.BufferManager.GetBuffer();
			_tempHeader = new byte[_parentServer.HEADER_SIZE];
			_handle.BeginReceive(_readBuffer, 0, _readBuffer.Length, SocketFlags.None, AsyncReceive, null);
			OnClientState(connected: true);
		}
		catch (Exception)
		{
			Disconnect();
		}
	}

	private void Initialize()
	{
		Authenticated = false;
		Value = new UserState();
	}

	private void AsyncReceive(IAsyncResult result)
	{
		int num;
		try
		{
			num = _handle.EndReceive(result);
			if (num <= 0)
			{
				throw new Exception("no bytes transferred");
			}
		}
		catch (NullReferenceException)
		{
			return;
		}
		catch (ObjectDisposedException)
		{
			return;
		}
		catch (Exception)
		{
			Disconnect();
			return;
		}
		_parentServer.BytesReceived += num;
		byte[] array = new byte[num];
		try
		{
			Array.Copy(_readBuffer, array, array.Length);
		}
		catch (Exception)
		{
			Disconnect();
			return;
		}
		lock (_readBuffers)
		{
			_readBuffers.Enqueue(array);
		}
		lock (_readingPacketsLock)
		{
			if (!_readingPackets)
			{
				_readingPackets = true;
				ThreadPool.QueueUserWorkItem(AsyncReceive);
			}
		}
		try
		{
			_handle.BeginReceive(_readBuffer, 0, _readBuffer.Length, SocketFlags.None, AsyncReceive, null);
		}
		catch (ObjectDisposedException)
		{
		}
		catch (Exception)
		{
			Disconnect();
		}
	}

	private void AsyncReceive(object state)
	{
		while (true)
		{
			byte[] array;
			lock (_readBuffers)
			{
				if (_readBuffers.Count == 0)
				{
					lock (_readingPacketsLock)
					{
						_readingPackets = false;
						break;
					}
				}
				array = _readBuffers.Dequeue();
			}
			_readableDataLen += array.Length;
			bool flag = true;
			while (flag)
			{
				int num2;
				switch (_receiveState)
				{
					case ReceiveType.Header:
						if (_readableDataLen + _tempHeaderOffset >= _parentServer.HEADER_SIZE)
						{
							num2 = (_appendHeader ? (_parentServer.HEADER_SIZE - _tempHeaderOffset) : _parentServer.HEADER_SIZE);
							try
							{
								if (_appendHeader)
								{
									try
									{
										Array.Copy(array, _readOffset, _tempHeader, _tempHeaderOffset, num2);
									}
									catch (Exception)
									{
										flag = false;
										Disconnect();
										goto end_IL_00d8;
									}
									_payloadLen = BitConverter.ToInt32(_tempHeader, 0);
									_tempHeaderOffset = 0;
									_appendHeader = false;
								}
								else
								{
									_payloadLen = BitConverter.ToInt32(array, _readOffset);
								}
								if (_payloadLen <= 0 || _payloadLen > _parentServer.MAX_PACKET_SIZE)
								{
									throw new Exception("invalid header");
								}
								goto IL_0175;
							end_IL_00d8:;
							}
							catch (Exception)
							{
								flag = false;
								Disconnect();
							}
						}
						else
						{
							try
							{
								Array.Copy(array, _readOffset, _tempHeader, _tempHeaderOffset, _readableDataLen);
							}
							catch (Exception)
							{
								flag = false;
								Disconnect();
								break;
							}
							_tempHeaderOffset += _readableDataLen;
							_appendHeader = true;
							flag = false;
						}
						break;
					case ReceiveType.Payload:
						{
							if (_payloadBuffer == null || _payloadBuffer.Length != _payloadLen)
							{
								_payloadBuffer = new byte[_payloadLen];
							}
							int num = ((_writeOffset + _readableDataLen >= _payloadLen) ? (_payloadLen - _writeOffset) : _readableDataLen);
							try
							{
								Array.Copy(array, _readOffset, _payloadBuffer, _writeOffset, num);
							}
							catch (Exception)
							{
								flag = false;
								Disconnect();
								break;
							}
							_writeOffset += num;
							_readOffset += num;
							_readableDataLen -= num;
							if (_writeOffset == _payloadLen)
							{
								bool flag2 = _payloadBuffer.Length == 0;
								if (!flag2)
								{
									_payloadBuffer = AES.Decrypt(_payloadBuffer);
									flag2 = _payloadBuffer.Length == 0;
								}
								if (!flag2)
								{
									try
									{
										_payloadBuffer = SafeQuickLZ.Decompress(_payloadBuffer);
									}
									catch (Exception)
									{
										flag = false;
										Disconnect();
										break;
									}
									flag2 = _payloadBuffer.Length == 0;
								}
								if (flag2)
								{
									flag = false;
									Disconnect();
									break;
								}
								using (MemoryStream stream = new MemoryStream(_payloadBuffer))
								{
									try
									{
										IPacket packet = (IPacket)_parentServer.Serializer.Deserialize(stream);
										OnClientRead(packet);
									}
									catch (Exception)
									{
										flag = false;
										Disconnect();
										break;
									}
								}
								_receiveState = ReceiveType.Header;
								_payloadBuffer = null;
								_payloadLen = 0;
								_writeOffset = 0;
							}
							if (_readableDataLen == 0)
							{
								flag = false;
							}
							break;
						}
					IL_0175:
						_readableDataLen -= num2;
						_readOffset += num2;
						_receiveState = ReceiveType.Payload;
						break;
				}
			}
			if (_receiveState == ReceiveType.Header)
			{
				_writeOffset = 0;
			}
			_readOffset = 0;
			_readableDataLen = 0;
		}
	}

	public void Send<T>(T packet) where T : IPacket
	{
		if (!Connected || packet == null)
		{
			return;
		}
		lock (_sendBuffers)
		{
			using MemoryStream memoryStream = new MemoryStream();
			try
			{
				_parentServer.Serializer.Serialize(memoryStream, packet);
			}
			catch (Exception)
			{
				Disconnect();
				return;
			}
			byte[] array = memoryStream.ToArray();
			_sendBuffers.Enqueue(array);
			OnClientWrite(packet, array.LongLength, array);
			lock (_sendingPacketsLock)
			{
				if (_sendingPackets)
				{
					return;
				}
				_sendingPackets = true;
			}
			ThreadPool.QueueUserWorkItem(Send);
		}
	}

	public void SendBlocking<T>(T packet) where T : IPacket
	{
		Send(packet);
		while (_sendingPackets)
		{
			Thread.Sleep(10);
		}
	}

	private void Send(object state)
	{
		while (Connected)
		{
			byte[] payload;
			lock (_sendBuffers)
			{
				if (_sendBuffers.Count == 0)
				{
					SendCleanup();
					return;
				}
				payload = _sendBuffers.Dequeue();
			}
			try
			{
				byte[] array = BuildPacket(payload);
				_parentServer.BytesSent += array.Length;
				_handle.Send(array);
			}
			catch (Exception)
			{
				Disconnect();
				SendCleanup(clear: true);
				return;
			}
		}
		SendCleanup(clear: true);
	}

	private byte[] BuildPacket(byte[] payload)
	{
		payload = SafeQuickLZ.Compress(payload);
		payload = AES.Encrypt(payload);
		byte[] array = new byte[payload.Length + _parentServer.HEADER_SIZE];
		Array.Copy(BitConverter.GetBytes(payload.Length), array, _parentServer.HEADER_SIZE);
		Array.Copy(payload, 0, array, _parentServer.HEADER_SIZE, payload.Length);
		return array;
	}

	private void SendCleanup(bool clear = false)
	{
		lock (_sendingPacketsLock)
		{
			_sendingPackets = false;
		}
		if (!clear)
		{
			return;
		}
		lock (_sendBuffers)
		{
			_sendBuffers.Clear();
		}
	}

	public void Disconnect()
	{
		if (_handle != null)
		{
			_handle.Close();
			_handle = null;
			_readOffset = 0;
			_writeOffset = 0;
			_tempHeaderOffset = 0;
			_readableDataLen = 0;
			_payloadLen = 0;
			_payloadBuffer = null;
			_receiveState = ReceiveType.Header;
			if (Value != null)
			{
				Value.Dispose();
				Value = null;
			}
			_parentServer.BufferManager.ReturnBuffer(_readBuffer);
		}
		OnClientState(connected: false);
	}
}
}