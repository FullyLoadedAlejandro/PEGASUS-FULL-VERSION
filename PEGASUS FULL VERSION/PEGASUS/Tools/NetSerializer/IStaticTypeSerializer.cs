using System;
using System.Reflection;

namespace PEGASUS.Tools.NetSerializer
	{
public interface IStaticTypeSerializer : ITypeSerializer
{
	void GetStaticMethods(Type type, out MethodInfo writer, out MethodInfo reader);
}
}