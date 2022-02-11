using System.Drawing;
using System.Threading;
using PEGASUS.Connection;
using PEGASUS.MessagePack;

namespace PEGASUS.Handle_Packet
	{
public class HandlePing
{
	public void Ping(Clients client, MsgPack unpack_msgpack)
	{
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").SetAsString("Po_ng");
			ThreadPool.QueueUserWorkItem(client.Send, msgPack.Encode2Bytes());
			lock (Settings.LockListviewClients)
			{
				if (client.LV != null)
				{
					client.LV.SubItems[Program.form1.lv_act.Index].Text = unpack_msgpack.ForcePathObject("Message").AsString;
				}
			}
		}
		catch
		{
		}
	}

	public void Po_ng(Clients client, MsgPack unpack_msgpack)
	{
		try
		{
			lock (Settings.LockListviewClients)
			{
				if (client.LV != null)
				{
					client.LV.SubItems[Program.form1.lv_ping.Index].Text = unpack_msgpack.ForcePathObject("Message").AsInteger + " MS";
					if (unpack_msgpack.ForcePathObject("Message").AsInteger > 600)
					{
						client.LV.SubItems[Program.form1.lv_ping.Index].ForeColor = Color.Red;
					}
					else if (unpack_msgpack.ForcePathObject("Message").AsInteger > 300)
					{
						client.LV.SubItems[Program.form1.lv_ping.Index].ForeColor = Color.Orange;
					}
					else
					{
						client.LV.SubItems[Program.form1.lv_ping.Index].ForeColor = Color.FromArgb(3, 130, 200);
					}
				}
			}
		}
		catch
		{
		}
	}
}
}