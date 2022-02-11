using System;
using System.Collections.Generic;
using System.Reflection;

namespace PEGASUS.Tools.NetSerializer.TypeSerializers
	{
public class EnumSerializer : IStaticTypeSerializer, ITypeSerializer
{
	public bool Handles(Type type)
	{
		return type.IsEnum;
	}

	public IEnumerable<Type> GetSubtypes(Type type)
	{
		yield return System.Enum.GetUnderlyingType(type);
	}

	public void GetStaticMethods(Type type, out MethodInfo writer, out MethodInfo reader)
	{
		Type underlyingType = System.Enum.GetUnderlyingType(type);
		writer = Primitives.GetWritePrimitive(underlyingType);
		reader = Primitives.GetReaderPrimitive(underlyingType);
	}
}
}