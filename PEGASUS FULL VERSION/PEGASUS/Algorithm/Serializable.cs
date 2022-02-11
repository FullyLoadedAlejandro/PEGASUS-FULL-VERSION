using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PEGASUS.Algorithm
	{
public class Serializable
{
	public static byte[] Serialize(object obj)
	{
		using MemoryStream memoryStream = new MemoryStream();
		new BinaryFormatter().Serialize(memoryStream, obj);
		return memoryStream.ToArray();
	}

	public static object Deserialize(byte[] data)
	{
		using MemoryStream memoryStream = new MemoryStream(data);
		BinaryFormatter obj = new BinaryFormatter
		{
			Binder = new UBinder()
		};
		memoryStream.Position = 0L;
		return obj.Deserialize(memoryStream);
	}
}
}
