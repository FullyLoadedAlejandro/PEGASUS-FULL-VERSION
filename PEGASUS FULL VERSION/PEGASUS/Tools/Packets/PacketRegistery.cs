using System;
using PEGASUS.Tools.Packets.ClientPackets;
using PEGASUS.Tools.Packets.ServerPackets;

namespace PEGASUS.Tools.Packets
{ 

public class PacketRegistery
{
	public static Type[] GetPacketTypes()
	{
		return new Type[10]
		{
			typeof(GetAuthentication),
			typeof(GetDesktop),
			typeof(DoMouseEvent),
			typeof(DoKeyboardEvent),
			typeof(GetSystemInfo),
			typeof(GetMonitors),
			typeof(SetAuthenticationSuccess),
			typeof(GetConnections),
			typeof(GetAuthenticationResponse),
			typeof(GetConnectionsResponse)
		};
	}
}
}