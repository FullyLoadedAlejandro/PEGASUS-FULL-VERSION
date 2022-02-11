using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace PEGASUS.Forms.RenamingObfuscation.Overkill
	{
public class CFHelper
{
	public class Blocks
	{
		public List<Block> blocks = new List<Block>();

		private static Random generator = new Random();

		public Block getBlock(int id)
		{
			return blocks.Single((Block block) => block.ID == id);
		}

		public void Scramble(out Blocks incGroups)
		{
			Blocks blocks = new Blocks();
			foreach (Block block in this.blocks)
			{
				blocks.blocks.Insert(generator.Next(0, blocks.blocks.Count), block);
			}
			incGroups = blocks;
		}
	}

	public class Block
	{
		public int ID;

		public int nextBlock;

		public List<Instruction> instructions = new List<Instruction>();
	}

	private static Random generator = new Random();

	public bool HasUnsafeInstructions(MethodDef methodDef)
	{
		if (methodDef.HasBody && methodDef.Body.HasVariables)
		{
			return methodDef.Body.Variables.Any((Local x) => x.Type.IsPointer);
		}
		return false;
	}

	public Blocks GetBlocks(MethodDef method)
	{
		Blocks blocks = new Blocks();
		Block block = new Block();
		int num = 0;
		block.ID = 0;
		int num2 = 1;
		block.nextBlock = block.ID + 1;
		block.instructions.Add(Instruction.Create(OpCodes.Nop));
		blocks.blocks.Add(block);
		block = new Block();
		foreach (Instruction instruction in method.Body.Instructions)
		{
			int pops = 0;
			instruction.CalculateStackUsage(out var pushes, out pops);
			block.instructions.Add(instruction);
			num += pushes - pops;
			if (pushes == 0 && instruction.OpCode != OpCodes.Nop && (num == 0 || instruction.OpCode == OpCodes.Ret))
			{
				block.ID = num2;
				num2++;
				block.nextBlock = block.ID + 1;
				blocks.blocks.Add(block);
				block = new Block();
			}
		}
		return blocks;
	}

	public List<Instruction> Calc(int value)
	{
		List<Instruction> list = new List<Instruction>();
		int num = generator.Next(0, int.MaxValue);
		bool flag = Convert.ToBoolean(generator.Next(int.MaxValue));
		int num2 = generator.Next(int.MaxValue);
		list.Add(Instruction.Create(OpCodes.Ldc_I4, value - num + (flag ? (-num2) : num2)));
		list.Add(Instruction.Create(OpCodes.Ldc_I4, num));
		list.Add(Instruction.Create(OpCodes.Add));
		list.Add(Instruction.Create(OpCodes.Ldc_I4, num2));
		list.Add(Instruction.Create(flag ? OpCodes.Add : OpCodes.Sub));
		return list;
	}
}
}