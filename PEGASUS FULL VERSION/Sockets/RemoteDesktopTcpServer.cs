using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sockets
{ 

public class RemoteDesktopTcpServer
{
	public TcpListener _listener;

	public TcpClient _tcpClient;

	private NetworkStream _netstream;

	public List<byte> _HeadAndPayloadPacket = new List<byte>();

	private int _HeadPacketSize = 4;

	public Action<byte[]> _ClientMessage;

	public IPEndPoint _ListenedEndPoint { get; private set; }

	public RemoteDesktopTcpServer(int _listport)
	{
		_ListenedEndPoint = new IPEndPoint(IPAddress.Any, _listport);
	}

	public void Listen()
	{
		try
		{
			_listener = new TcpListener(_ListenedEndPoint);
			_listener.Start();
			Task.Factory.StartNew((Func<Task>)async delegate
			{
				await Accept();
			}, TaskCreationOptions.None);
		}
		catch
		{
			MessageBox.Show("Listen error");
		}
	}

	private async Task Accept()
	{
		RemoteDesktopTcpServer desktopTcpServer = this;
		try
		{
			desktopTcpServer._tcpClient = await desktopTcpServer._listener.AcceptTcpClientAsync();
			await Task.Factory.StartNew((Func<Task>)desktopTcpServer.AsyncClientRecv, TaskCreationOptions.None);
		}
		catch
		{
		}
	}

	public async Task AsyncClientRecv()
	{
		try
		{
			_netstream = _tcpClient.GetStream();
			while (_tcpClient.Connected)
			{
				byte[] _readbyte = new byte[15000];
				int num = await _netstream.ReadAsync(_readbyte, 0, 15000);
				if (num == 0)
				{
					throw new Exception();
				}
				byte[] array = new byte[num];
				Buffer.BlockCopy(_readbyte, 0, array, 0, num);
				_HeadAndPayloadPacket.AddRange(array);
				SplitPacket();
			}
		}
		catch
		{
			Close();
		}
	}

	private void SplitPacket()
	{
		try
		{
			if (_HeadAndPayloadPacket == null || _tcpClient == null || _HeadAndPayloadPacket.Count < _HeadPacketSize)
			{
				return;
			}
			int num = BitConverter.ToInt32(_HeadAndPayloadPacket.GetRange(0, _HeadPacketSize).ToArray(), 0);
			if (_HeadAndPayloadPacket.Count - _HeadPacketSize >= num)
			{
				if (_HeadAndPayloadPacket.Count - _HeadPacketSize > num)
				{
					_ClientMessage(_HeadAndPayloadPacket.GetRange(_HeadPacketSize, num).ToArray());
					_HeadAndPayloadPacket.RemoveRange(0, num + _HeadPacketSize);
					SplitPacket();
				}
				if (_HeadAndPayloadPacket.Count - _HeadPacketSize == num)
				{
					_ClientMessage(_HeadAndPayloadPacket.GetRange(_HeadPacketSize, num).ToArray());
					_HeadAndPayloadPacket.Clear();
				}
			}
		}
		catch
		{
			_HeadAndPayloadPacket.Clear();
		}
	}

	public void Close()
	{
		try
		{
			_listener?.Stop();
			_tcpClient?.Client.Shutdown(SocketShutdown.Both);
			_netstream?.Dispose();
			_tcpClient?.Close();
			_tcpClient?.Dispose();
			_HeadAndPayloadPacket?.Clear();
		}
		catch
		{
		}
		finally
		{
			_netstream = null;
			_tcpClient = null;
			_HeadAndPayloadPacket = null;
			_listener = null;
		}
	}
}
}