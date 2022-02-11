using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace PEGASUS.Forms.RenamingObfuscation.Overkill.Protections
	{
public static class IntEncoding
{
	public static void Execute()
	{
		foreach (TypeDef type in Ovelkill.Module.GetTypes())
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
				for (int i = 0; i < method.Body.Instructions.Count; i++)
				{
					if (method.Body.Instructions[i].IsLdcI4())
					{
						int num = new Random(Guid.NewGuid().GetHashCode()).Next();
						int num2 = new Random(Guid.NewGuid().GetHashCode()).Next();
						int value = num ^ num2;
						Instruction instruction = OpCodes.Nop.ToInstruction();
						Local local = new Local(method.Module.ImportAsTypeSig(typeof(int)));
						method.Body.Variables.Add(local);
						method.Body.Instructions.Insert(i + 1, OpCodes.Stloc.ToInstruction(local));
						method.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Ldc_I4, method.Body.Instructions[i].GetLdcI4Value() - 4));
						method.Body.Instructions.Insert(i + 3, Instruction.Create(OpCodes.Ldc_I4, value));
						method.Body.Instructions.Insert(i + 4, Instruction.Create(OpCodes.Ldc_I4, num2));
						method.Body.Instructions.Insert(i + 5, Instruction.Create(OpCodes.Xor));
						method.Body.Instructions.Insert(i + 6, Instruction.Create(OpCodes.Ldc_I4, num));
						method.Body.Instructions.Insert(i + 7, Instruction.Create(OpCodes.Bne_Un, instruction));
						method.Body.Instructions.Insert(i + 8, Instruction.Create(OpCodes.Ldc_I4, 2));
						method.Body.Instructions.Insert(i + 9, OpCodes.Stloc.ToInstruction(local));
						method.Body.Instructions.Insert(i + 10, Instruction.Create(OpCodes.Sizeof, method.Module.Import(typeof(float))));
						method.Body.Instructions.Insert(i + 11, Instruction.Create(OpCodes.Add));
						method.Body.Instructions.Insert(i + 12, instruction);
						i += 12;
					}
				}
				method.Body.SimplifyBranches();
			}
		}
	}
}
}