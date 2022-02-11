using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using PEGASUS.Forms.RenamingObfuscation.Classes;
using PEGASUS.Forms.RenamingObfuscation.Interfaces;

namespace PEGASUS.Forms.RenamingObfuscation
	{
public static class EncryptString
{
	private static MethodDef InjectMethod(ModuleDef module, string methodName)
	{
		MethodDef result = (MethodDef)InjectHelper.Inject(ModuleDefMD.Load(typeof(DecryptionHelper).Module).ResolveTypeDef(MDToken.ToRID(typeof(DecryptionHelper).MetadataToken)), module.GlobalType, module).Single((IDnlibDef method) => method.Name == methodName);
		foreach (MethodDef method in module.GlobalType.Methods)
		{
			if (method.Name == ".ctor")
			{
				module.GlobalType.Remove(method);
				return result;
			}
		}
		return result;
	}

	public static void DoEncrypt(ModuleDef inPath)
	{
		EncryptStrings(inPath);
	}

	private static ModuleDef EncryptStrings(ModuleDef inModule)
	{
		ICrypto crypto = new Base64();
		MethodDef methodDef = InjectMethod(inModule, "Decrypt_Base64");
		foreach (TypeDef type in inModule.Types)
		{
			if (type.IsGlobalModuleType || type.Name == "Resources" || type.Name == "Settings")
			{
				continue;
			}
			foreach (MethodDef method in type.Methods)
			{
				if (!method.HasBody || method == methodDef)
				{
					continue;
				}
				method.Body.KeepOldMaxStack = true;
				for (int i = 0; i < method.Body.Instructions.Count; i++)
				{
					if (method.Body.Instructions[i].OpCode == OpCodes.Ldstr)
					{
						string dataPlain = method.Body.Instructions[i].Operand.ToString();
						method.Body.Instructions[i].Operand = crypto.Encrypt(dataPlain);
						method.Body.Instructions.Insert(i + 1, new Instruction(OpCodes.Call, methodDef));
					}
				}
				method.Body.SimplifyBranches();
				method.Body.OptimizeBranches();
			}
		}
		return inModule;
	}
}
}