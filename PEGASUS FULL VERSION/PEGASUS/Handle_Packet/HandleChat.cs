using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using PEGASUS.Connection;
using PEGASUS.Forms;
using PEGASUS.MessagePack;

namespace PEGASUS.Handle_Packet
	{
public class HandleChat
{
	public void Read(MsgPack unpack_msgpack, Clients client)
	{
		try
		{
			FormChat formChat = (FormChat)Application.OpenForms["chat:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
			if (formChat != null)
			{
				Console.Beep();
				formChat.richTextBox1.SelectionColor = Color.Blue;
				formChat.richTextBox1.AppendText(unpack_msgpack.ForcePathObject("WriteInput").AsString);
				formChat.richTextBox1.SelectionColor = Color.FromArgb(3, 130, 200);
				formChat.richTextBox1.AppendText(unpack_msgpack.ForcePathObject("WriteInput2").AsString);
				formChat.richTextBox1.SelectionStart = formChat.richTextBox1.TextLength;
				formChat.richTextBox1.ScrollToCaret();
			}
			else
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "chatExit";
				ThreadPool.QueueUserWorkItem(client.Send, msgPack.Encode2Bytes());
				client.Disconnected();
			}
		}
		catch
		{
		}
	}

	public void GetClient(MsgPack unpack_msgpack, Clients client)
	{
		FormChat formChat = (FormChat)Application.OpenForms["chat:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
		if (formChat != null && formChat.Client == null)
		{
			formChat.Client = client;
			formChat.textBox1.Enabled = true;
			formChat.timer1.Enabled = true;
		}
	}
}
}