using System;
using PEGASUS.Algorithm;
using PEGASUS.Messages;
using Sockets;

namespace PEGASUS.Module
	{
public class ClientInfomation
{
	public Action<TcpClientSession, GetCilentInfo> _FormExecute;

	~ClientInfomation()
	{
	}

	public void ClientInfoExecute(TcpClientSession tcs, byte[] bt)
	{
		GetCilentInfo arg = Serializable.Deserialize(GZip.Decompress(bt)) as GetCilentInfo;
		_FormExecute(tcs, arg);
	}

	public void destroy()
	{
		_FormExecute = null;
	}
}
}