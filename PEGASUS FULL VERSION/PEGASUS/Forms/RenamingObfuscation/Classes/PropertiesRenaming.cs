using dnlib.DotNet;
using PEGASUS.Forms.RenamingObfuscation.Interfaces;

namespace PEGASUS.Forms.RenamingObfuscation.Classes
	{
public class PropertiesRenaming : IRenaming
{
	public ModuleDefMD Rename(ModuleDefMD module)
	{
		foreach (TypeDef type in module.GetTypes())
		{
			if (type.IsGlobalModuleType)
			{
				continue;
			}
			foreach (PropertyDef property in type.Properties)
			{
				property.Name = Utils.GenerateRandomString();
			}
		}
		return module;
	}
}
}