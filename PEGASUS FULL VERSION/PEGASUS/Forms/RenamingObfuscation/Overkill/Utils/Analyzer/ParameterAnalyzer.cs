using dnlib.DotNet;

namespace PEGASUS.Forms.RenamingObfuscation.Overkill.Utils.Analyzer
	{
public class ParameterAnalyzer : DefAnalyzer
{
	public override bool Execute(object context)
	{
		if (((Parameter)context).Name == string.Empty)
		{
			return false;
		}
		return true;
	}
}
}