using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace PEGASUS.Forms.RenamingObfuscation.Overkill
	{
public class AddInteger
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
				IList<Instruction> instructions = method.Body.Instructions;
				for (int i = 0; i < instructions.Count; i++)
				{
					if (method.Body.Instructions[i].IsLdcI4())
					{
						int num = new Random().Next(int.MaxValue);
						method.Body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Sizeof, method.Module.Import(typeof(bool))));
						method.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Add));
						method.Body.Instructions.Insert(i + 3, Instruction.Create(OpCodes.Ldc_R8, Math.PI / 2.0));
						method.Body.Instructions.Insert(i + 4, Instruction.Create(OpCodes.Call, method.Module.Import(typeof(Math).GetMethod("Sin", new Type[1] { typeof(double) }))));
						method.Body.Instructions.Insert(i + 5, Instruction.Create(OpCodes.Conv_I4));
						method.Body.Instructions.Insert(i + 6, Instruction.Create(OpCodes.Sub));
						method.Body.Instructions.Insert(i + 7, Instruction.Create(OpCodes.Sizeof, method.Module.Import(typeof(bool))));
						method.Body.Instructions.Insert(i + 8, Instruction.Create(OpCodes.Add));
						method.Body.Instructions.Insert(i + 9, Instruction.Create(OpCodes.Ldc_R8, num ^ num));
						method.Body.Instructions.Insert(i + 10, Instruction.Create(OpCodes.Call, method.Module.Import(typeof(Math).GetMethod("Cos", new Type[1] { typeof(double) }))));
						method.Body.Instructions.Insert(i + 11, Instruction.Create(OpCodes.Conv_I4));
						method.Body.Instructions.Insert(i + 12, Instruction.Create(OpCodes.Sub));
					}
				}
			}
		}
	}
}
}