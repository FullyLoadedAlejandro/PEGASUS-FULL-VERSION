using System.IO;
using System.Windows.Forms;
using PEGASUS.Tools.Helper;
using PEGASUS.Tools.Networking;
using PEGASUS.Tools.Packets.ClientPackets;

namespace PEGASUS.Tools.Commands
	{
public static class CommandHandler
{
	public static void HandleGetAuthenticationResponse(Client client, GetAuthenticationResponse packet)
	{
		if (client.EndPoint.Address.ToString() == "255.255.255.255" || packet.Id.Length != 64)
		{
			return;
		}
		try
		{
			client.Value.Version = packet.Version;
			client.Value.OperatingSystem = packet.OperatingSystem;
			client.Value.AccountType = packet.AccountType;
			client.Value.Country = packet.Country;
			client.Value.CountryCode = packet.CountryCode;
			client.Value.Region = packet.Region;
			client.Value.City = packet.City;
			client.Value.Id = packet.Id;
			client.Value.Username = packet.Username;
			client.Value.PCName = packet.PCName;
			client.Value.Tag = packet.Tag;
			client.Value.ImageIndex = packet.ImageIndex;
			client.Value.DownloadDirectory = ((!FileHelper.CheckPathForIllegalChars(client.Value.UserAtPc)) ? Path.Combine(Application.StartupPath, $"Clients\\{client.Value.UserAtPc}_{client.Value.Id.Substring(0, 7)}\\") : Path.Combine(Application.StartupPath, $"Clients\\{client.EndPoint.Address}_{client.Value.Id.Substring(0, 7)}\\"));
		}
		catch
		{
		}
	}
}
}