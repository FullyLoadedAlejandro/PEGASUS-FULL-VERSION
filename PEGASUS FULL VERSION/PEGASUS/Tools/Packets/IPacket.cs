using PEGASUS.Tools.Networking;

namespace PEGASUS.Tools.Packets
{ 

public interface IPacket
{
	void Execute(Client client);
}
}