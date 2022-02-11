using System;
using System.Reflection;

namespace PEGASUS.Loader
	{
public static class Extensions
{
	public static string GetReplacementName(this object obj, string propertyName)
	{
		dynamic val = obj.GetProperty(propertyName);
		if (val == null)
		{
			val = obj.GetField(propertyName);
		}
		if (val == null)
		{
			throw new Exception("Couldn't find property or field: " + propertyName);
		}
		object[] array = val.GetCustomAttributes(typeof(ReplacementAttribute), true);
		if (array != null && array.Length != 0)
		{
			return ((ReplacementAttribute)array[0]).Name;
		}
		return "UNDEFINED";
	}

	public static PropertyInfo GetProperty(this object obj, string property_name)
	{
		return obj.GetType().GetProperty(property_name);
	}

	public static FieldInfo GetField(this object obj, string field_name)
	{
		return obj.GetType().GetField(field_name);
	}
}
}