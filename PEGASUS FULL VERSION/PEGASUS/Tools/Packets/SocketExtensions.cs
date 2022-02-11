using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace PEGASUS.Tools.Packets
{ 

public static class SocketExtensions
{
	internal struct TcpKeepAlive
	{
		internal uint onoff;

		internal uint keepalivetime;

		internal uint keepaliveinterval;
	}

	public static void SetKeepAliveEx(this Socket socket, uint keepAliveInterval, uint keepAliveTime)
	{
		TcpKeepAlive tcpKeepAlive = default(TcpKeepAlive);
		tcpKeepAlive.onoff = 1u;
		tcpKeepAlive.keepaliveinterval = keepAliveInterval;
		tcpKeepAlive.keepalivetime = keepAliveTime;
		TcpKeepAlive structure = tcpKeepAlive;
		int num = Marshal.SizeOf(structure);
		IntPtr intPtr = Marshal.AllocHGlobal(num);
		Marshal.StructureToPtr(structure, intPtr, fDeleteOld: true);
		byte[] array = new byte[num];
		Marshal.Copy(intPtr, array, 0, num);
		Marshal.FreeHGlobal(intPtr);
		socket.IOControl(IOControlCode.KeepAliveValues, array, null);
	}
}
}