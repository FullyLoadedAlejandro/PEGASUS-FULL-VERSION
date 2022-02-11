using dnlib.DotNet;

namespace PEGASUS.Forms.RenamingObfuscation.Interfaces
	{
public interface IRenaming
{
	ModuleDefMD Rename(ModuleDefMD module);
}
}