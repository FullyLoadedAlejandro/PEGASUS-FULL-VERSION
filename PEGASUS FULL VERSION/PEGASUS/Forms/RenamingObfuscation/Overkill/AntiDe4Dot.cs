using dnlib.DotNet;

namespace PEGASUS.Forms.RenamingObfuscation.Overkill
	{
internal class AntiDe4Dot
{
	public static void Execute()
	{
		foreach (ModuleDef module in Ovelkill.Module.Assembly.Modules)
		{
			string text = "PEGASUS.NET";
			for (int i = 0; i < 1; i++)
			{
				TypeDefUser typeDefUser = new TypeDefUser(string.Empty, text);
				InterfaceImplUser item = new InterfaceImplUser(typeDefUser);
				module.Types.Add(typeDefUser);
				typeDefUser.Interfaces.Add(item);
			}
		}
	}
}
}