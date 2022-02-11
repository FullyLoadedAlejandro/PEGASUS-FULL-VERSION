using System;
using PEGASUS.Tools.Networking;

namespace PEGASUS.Tools.Packets.ServerPackets
	{
[Serializable]
public class GetMonitors : IPacket
{
	public void Execute(Client client)
	{
		client.Send(this);
	}
}
}