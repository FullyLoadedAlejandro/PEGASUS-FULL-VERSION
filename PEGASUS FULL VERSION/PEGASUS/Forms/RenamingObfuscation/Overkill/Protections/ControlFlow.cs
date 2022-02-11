using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace PEGASUS.Forms.RenamingObfuscation.Overkill.Protections
	{
public static class ControlFlow
{
	public static void Execute()
	{
		CFHelper cFHelper = new CFHelper();
		foreach (TypeDef type in Ovelkill.Module.Types)
		{
			if (type.IsGlobalModuleType)
			{
				continue;
			}
			foreach (MethodDef method in type.Methods)
			{
				if (!method.HasBody || method.Body.Instructions.Count <= 0 || method.IsConstructor || cFHelper.HasUnsafeInstructions(method))
				{
					continue;
				}
				if (Simplify(method))
				{
					CFHelper.Blocks blocks = cFHelper.GetBlocks(method);
					if (blocks.blocks.Count != 1)
					{
						toDoBody(cFHelper, method, blocks, type);
					}
				}
				Optimize(method);
			}
		}
	}

	public static bool Optimize(MethodDef methodDef)
	{
		if (methodDef.Body == null)
		{
			return false;
		}
		methodDef.Body.OptimizeMacros();
		methodDef.Body.OptimizeBranches();
		return true;
	}

	public static bool Simplify(MethodDef methodDef)
	{
		if (methodDef.Parameters == null)
		{
			return false;
		}
		methodDef.Body.SimplifyMacros(methodDef.Parameters);
		return true;
	}

	private static void toDoBody(CFHelper cFHelper, MethodDef method, CFHelper.Blocks blocks, TypeDef typeDef)
	{
		blocks.Scramble(out blocks);
		method.Body.Instructions.Clear();
		Local local = new Local(Ovelkill.Module.CorLibTypes.Int32);
		method.Body.Variables.Add(local);
		Instruction instruction = Instruction.Create(OpCodes.Nop);
		Instruction instruction2 = Instruction.Create(OpCodes.Br, instruction);
		foreach (Instruction item in cFHelper.Calc(0))
		{
			method.Body.Instructions.Add(item);
		}
		method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
		method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, instruction2));
		method.Body.Instructions.Add(instruction);
		foreach (CFHelper.Block block in blocks.blocks)
		{
			if (block == blocks.getBlock(blocks.blocks.Count - 1))
			{
				continue;
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
			foreach (Instruction item2 in cFHelper.Calc(block.ID))
			{
				method.Body.Instructions.Add(item2);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
			Instruction instruction3 = Instruction.Create(OpCodes.Nop);
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction3));
			foreach (Instruction instruction4 in block.instructions)
			{
				method.Body.Instructions.Add(instruction4);
			}
			foreach (Instruction item3 in cFHelper.Calc(block.nextBlock))
			{
				method.Body.Instructions.Add(item3);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
			method.Body.Instructions.Add(instruction3);
		}
		method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
		foreach (Instruction item4 in cFHelper.Calc(blocks.blocks.Count - 1))
		{
			method.Body.Instructions.Add(item4);
		}
		method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
		method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction2));
		method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, blocks.getBlock(blocks.blocks.Count - 1).instructions[0]));
		method.Body.Instructions.Add(instruction2);
		foreach (Instruction instruction5 in blocks.getBlock(blocks.blocks.Count - 1).instructions)
		{
			method.Body.Instructions.Add(instruction5);
		}
	}
}
}