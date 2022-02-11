using System;
using System.Collections.Generic;

namespace PEGASUS.Tools.NetSerializer
	{
public interface ITypeSerializer
{
	bool Handles(Type type);

	IEnumerable<Type> GetSubtypes(Type type);
}
}