using System;
using System.Drawing;
using System.Windows.Forms;

namespace PEGASUS.Handle_Packet
	{
public class HandleLogs
{
	public void Addmsg(string Msg, Color color)
	{
		try
		{
			ListViewItem LV = new ListViewItem();
			LV.Text = DateTime.Now.ToLongTimeString();
			LV.SubItems.Add(Msg);
			LV.ForeColor = color;
			if (Program.form1.InvokeRequired)
			{
				Program.form1.Invoke((MethodInvoker)delegate
				{
					lock (Settings.LockListviewLogs)
					{
						Program.form1.listView2.Items.Insert(0, LV);
					}
				});
				return;
			}
			lock (Settings.LockListviewLogs)
			{
				Program.form1.listView2.Items.Insert(0, LV);
			}
		}
		catch
		{
		}
	}
}
}