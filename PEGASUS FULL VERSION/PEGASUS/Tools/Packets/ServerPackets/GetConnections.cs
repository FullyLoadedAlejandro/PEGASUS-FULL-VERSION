using System;
using PEGASUS.Tools.Networking;

namespace PEGASUS.Tools.Packets.ServerPackets
{
[Serializable]
public class GetConnections : IPacket
{
	public void Execute(Client client)
	{
		client.Send(this);
	}
}
}