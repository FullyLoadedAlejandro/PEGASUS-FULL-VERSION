using dnlib.DotNet;

namespace PEGASUS.Forms.RenamingObfuscation.Overkill.Utils.Analyzer
	{
public class PropertyDefAnalyzer : DefAnalyzer
{
	public override bool Execute(object context)
	{
		PropertyDef propertyDef = (PropertyDef)context;
		if (propertyDef.IsRuntimeSpecialName)
		{
			return false;
		}
		if (propertyDef.IsEmpty)
		{
			return false;
		}
		return !propertyDef.IsSpecialName;
	}
}
}