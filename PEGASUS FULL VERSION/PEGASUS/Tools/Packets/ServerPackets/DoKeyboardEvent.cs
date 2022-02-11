using System;
using PEGASUS.Tools.Networking;

namespace PEGASUS.Tools.Packets.ServerPackets
{
[Serializable]
public class DoKeyboardEvent : IPacket
{
	public byte Key { get; set; }

	public bool KeyDown { get; set; }

	public DoKeyboardEvent()
	{
	}

	public DoKeyboardEvent(byte key, bool keyDown)
	{
		Key = key;
		KeyDown = keyDown;
	}

	public void Execute(Client client)
	{
		client.Send(this);
	}
}
}