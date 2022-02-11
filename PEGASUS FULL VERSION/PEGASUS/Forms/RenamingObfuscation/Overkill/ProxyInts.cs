using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using PEGASUS.Forms.RenamingObfuscation.Overkill.Protections;

namespace PEGASUS.Forms.RenamingObfuscation.Overkill
	{
internal class ProxyInts
{
	public static Random rand = new Random();

	private static int Amount { get; set; }

	public static void Execute()
	{
		ModuleDefMD module = Ovelkill.Module;
		foreach (TypeDef type in module.GetTypes())
		{
			if (type.IsGlobalModuleType)
			{
				continue;
			}
			foreach (MethodDef method in type.Methods)
			{
				if (!method.HasBody)
				{
					continue;
				}
				IList<Instruction> instructions = method.Body.Instructions;
				for (int i = 0; i < instructions.Count; i++)
				{
					if (method.Body.Instructions[i].IsLdcI4())
					{
						MethodImplAttributes implFlags = MethodImplAttributes.IL;
						MethodAttributes flags = MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.HideBySig;
						MethodDefUser methodDefUser = new MethodDefUser(L2F.RandomString(30), MethodSig.CreateStatic(module.CorLibTypes.Int32), implFlags, flags);
						module.GlobalType.Methods.Add(methodDefUser);
						methodDefUser.Body = new CilBody();
						methodDefUser.Body.Variables.Add(new Local(module.CorLibTypes.Int32));
						methodDefUser.Body.Instructions.Add(Instruction.Create(OpCodes.Ldc_I4, instructions[i].GetLdcI4Value()));
						methodDefUser.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
						instructions[i].OpCode = OpCodes.Call;
						instructions[i].Operand = methodDefUser;
						Amount++;
					}
					else if (method.Body.Instructions[i].OpCode == OpCodes.Ldc_R4)
					{
						MethodImplAttributes implFlags2 = MethodImplAttributes.IL;
						MethodAttributes flags2 = MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.HideBySig;
						MethodDefUser methodDefUser2 = new MethodDefUser(L2F.RandomString(30), MethodSig.CreateStatic(module.CorLibTypes.Double), implFlags2, flags2);
						module.GlobalType.Methods.Add(methodDefUser2);
						methodDefUser2.Body = new CilBody();
						methodDefUser2.Body.Variables.Add(new Local(module.CorLibTypes.Double));
						methodDefUser2.Body.Instructions.Add(Instruction.Create(OpCodes.Ldc_R4, (float)method.Body.Instructions[i].Operand));
						methodDefUser2.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
						instructions[i].OpCode = OpCodes.Call;
						instructions[i].Operand = methodDefUser2;
						Amount++;
					}
				}
			}
		}
		Console.WriteLine("   " + Amount + " ints proxied!");
	}
}
}