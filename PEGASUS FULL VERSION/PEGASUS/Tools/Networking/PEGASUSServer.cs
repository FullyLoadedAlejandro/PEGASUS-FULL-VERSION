using System;
using System.Linq;
using PEGASUS.Tools.Commands;
using PEGASUS.Tools.NetSerializer;
using PEGASUS.Tools.Packets;
using PEGASUS.Tools.Packets.ClientPackets;
using PEGASUS.Tools.Packets.ServerPackets;

namespace PEGASUS.Tools.Networking
	{
public class PEGASUSServer : Server
{
	public delegate void ClientConnectedEventHandler(Client client);

	public delegate void ClientDisconnectedEventHandler(Client client);

	public Client[] ConnectedClients => base.Clients.Where((Client c) => c?.Authenticated ?? false).ToArray();

	public event ClientConnectedEventHandler ClientConnected;

	public event ClientDisconnectedEventHandler ClientDisconnected;

	private void OnClientConnected(Client client)
	{
		if (!base.ProcessingDisconnect && base.Listening)
		{
			this.ClientConnected?.Invoke(client);
		}
	}

	private void OnClientDisconnected(Client client)
	{
		if (!base.ProcessingDisconnect && base.Listening)
		{
			this.ClientDisconnected?.Invoke(client);
		}
	}

	public PEGASUSServer()
	{
		base.Serializer = new Serializer(PacketRegistery.GetPacketTypes());
		base.ClientState += OnClientState;
		base.ClientRead += OnClientRead;
	}

	private void OnClientState(Server server, Client client, bool connected)
	{
		if (connected)
		{
			new GetAuthentication().Execute(client);
		}
		else if (client.Authenticated)
		{
			OnClientDisconnected(client);
		}
	}

	private void OnClientRead(Server server, Client client, IPacket packet)
	{
		Type type = packet.GetType();
		if (!client.Authenticated)
		{
			if (type == typeof(GetAuthenticationResponse))
			{
				client.Authenticated = true;
				new SetAuthenticationSuccess().Execute(client);
				CommandHandler.HandleGetAuthenticationResponse(client, (GetAuthenticationResponse)packet);
				OnClientConnected(client);
			}
			else
			{
				client.Disconnect();
			}
		}
		else
		{
			PacketHandler.HandlePacket(client, packet);
		}
	}
}
}