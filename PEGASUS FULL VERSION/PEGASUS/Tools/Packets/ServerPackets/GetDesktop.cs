using System;
using PEGASUS.Tools.Networking;

namespace PEGASUS.Tools.Packets.ServerPackets
{
[Serializable]
public class GetDesktop : IPacket
{
	public int Quality { get; set; }

	public int Monitor { get; set; }

	public GetDesktop()
	{
	}

	public GetDesktop(int quality, int monitor)
	{
		Quality = quality;
		Monitor = monitor;
	}

	public void Execute(Client client)
	{
		client.Send(this);
	}
}
}