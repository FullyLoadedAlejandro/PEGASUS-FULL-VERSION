using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using PEGASUS.Forms.RenamingObfuscation.Interfaces;

namespace PEGASUS.Forms.RenamingObfuscation.Classes
	{
public class FieldsRenaming : IRenaming
{
	private static Dictionary<string, string> _names = new Dictionary<string, string>();

	public ModuleDefMD Rename(ModuleDefMD module)
	{
		foreach (TypeDef type in module.GetTypes())
		{
			if (type.IsGlobalModuleType)
			{
				continue;
			}
			foreach (FieldDef field in type.Fields)
			{
				if (_names.TryGetValue(field.Name, out var value))
				{
					field.Name = value;
				}
				else if (!field.IsSpecialName && !field.HasCustomAttributes)
				{
					string text = Utils.GenerateRandomString();
					_names.Add(field.Name, text);
					field.Name = text;
				}
			}
		}
		return ApplyChangesToResources(module);
	}

	private static ModuleDefMD ApplyChangesToResources(ModuleDefMD module)
	{
		foreach (TypeDef type in module.GetTypes())
		{
			if (type.IsGlobalModuleType)
			{
				continue;
			}
			foreach (MethodDef method in type.Methods)
			{
				if (method.Name != "InitializeComponent")
				{
					continue;
				}
				IList<Instruction> instructions = method.Body.Instructions;
				for (int i = 0; i < instructions.Count - 3; i++)
				{
					if (instructions[i].OpCode != OpCodes.Ldstr)
					{
						continue;
					}
					foreach (KeyValuePair<string, string> name in _names)
					{
						if (name.Key == instructions[i].Operand.ToString())
						{
							instructions[i].Operand = name.Value;
						}
					}
				}
			}
		}
		return module;
	}
}
}