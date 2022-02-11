using System.Reflection;

namespace PEGASUS.Tools.NetSerializer
{ 
public sealed class TypeData
{
	public readonly ushort TypeID;

	public readonly IDynamicTypeSerializer TypeSerializer;

	public MethodInfo WriterMethodInfo;

	public MethodInfo ReaderMethodInfo;

	public bool IsGenerated => TypeSerializer != null;

	public bool NeedsInstanceParameter { get; private set; }

	public TypeData(ushort typeID, IDynamicTypeSerializer serializer)
	{
		TypeID = typeID;
		TypeSerializer = serializer;
		NeedsInstanceParameter = true;
	}

	public TypeData(ushort typeID, MethodInfo writer, MethodInfo reader)
	{
		TypeID = typeID;
		WriterMethodInfo = writer;
		ReaderMethodInfo = reader;
		NeedsInstanceParameter = writer.GetParameters().Length == 3;
	}
}
}