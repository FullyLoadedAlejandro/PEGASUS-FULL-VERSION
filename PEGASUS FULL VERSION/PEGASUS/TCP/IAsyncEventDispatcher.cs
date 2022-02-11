using System;
using System.Collections.Generic;
using PEGASUS.Tools;
using Sockets;

namespace PEGASUS.TCP
	{
public class IAsyncEventDispatcher
{
	public object _obj = new object();

	public TcpClientSession _tcs;

	public Dictionary<DataType, Action<TcpClientSession, byte[]>> _ProcessorsMessageHandler;

	public IAsyncEventDispatcher(TcpClientSession tcs)
	{
		_tcs = tcs;
		_ProcessorsMessageHandler = new Dictionary<DataType, Action<TcpClientSession, byte[]>>();
	}

	~IAsyncEventDispatcher()
	{
	}

	public void DispatchMessageHandler(TcpHeartPacket tp, byte[] payload)
	{
		try
		{
			Action<TcpClientSession, byte[]> value = null;
			if (_ProcessorsMessageHandler.TryGetValue((DataType)tp._DataType, out value))
			{
				value?.Invoke(_tcs, payload);
			}
		}
		catch
		{
		}
	}

	public bool Register(DataType dt, Action<TcpClientSession, byte[]> ob)
	{
		lock (_obj)
		{
			_ProcessorsMessageHandler?.Add(dt, ob);
			return true;
		}
	}

	public bool Unregister(DataType dt)
	{
		lock (_obj)
		{
			return _ProcessorsMessageHandler.Remove(dt);
		}
	}

	public void destroy()
	{
		_ProcessorsMessageHandler?.Clear();
		_ProcessorsMessageHandler = null;
		_obj = null;
		_tcs = null;
	}
}
}