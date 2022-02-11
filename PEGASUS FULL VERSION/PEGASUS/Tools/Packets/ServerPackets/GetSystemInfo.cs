using System;
using PEGASUS.Tools.Networking;

namespace PEGASUS.Tools.Packets.ServerPackets
{
[Serializable]
public class GetSystemInfo : IPacket
{
	public void Execute(Client client)
	{
		client.Send(this);
	}
}
}