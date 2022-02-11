using dnlib.DotNet;

namespace PEGASUS.Forms.RenamingObfuscation.Overkill.Utils.Analyzer
	{
public class MethodDefAnalyzer : DefAnalyzer
{
	public override bool Execute(object context)
	{
		MethodDef methodDef = (MethodDef)context;
		if (methodDef.IsRuntimeSpecialName)
		{
			return false;
		}
		if (methodDef.DeclaringType.IsForwarder)
		{
			return false;
		}
		if (methodDef.IsConstructor || methodDef.IsStaticConstructor)
		{
			return false;
		}
		return true;
	}
}
}