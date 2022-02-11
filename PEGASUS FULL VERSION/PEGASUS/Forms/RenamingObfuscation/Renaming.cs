using dnlib.DotNet;
using PEGASUS.Forms.RenamingObfuscation.Classes;
using PEGASUS.Forms.RenamingObfuscation.Interfaces;

namespace PEGASUS.Forms.RenamingObfuscation
	{
public class Renaming
{
	public static ModuleDefMD DoRenaming(ModuleDefMD inPath)
	{
		return RenamingObfuscation(inPath);
	}

	private static ModuleDefMD RenamingObfuscation(ModuleDefMD inModule)
	{
		ModuleDefMD module = inModule;
		module = ((IRenaming)new NamespacesRenaming()).Rename(module);
		module = ((IRenaming)new ClassesRenaming()).Rename(module);
		module = ((IRenaming)new MethodsRenaming()).Rename(module);
		module = ((IRenaming)new PropertiesRenaming()).Rename(module);
		return ((IRenaming)new FieldsRenaming()).Rename(module);
	}
}
}