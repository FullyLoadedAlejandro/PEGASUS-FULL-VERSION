using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using PEGASUS.Forms.RenamingObfuscation.Interfaces;

namespace PEGASUS.Forms.RenamingObfuscation.Classes
	{
public class ClassesRenaming : IRenaming
{
	private static Dictionary<string, string> _names = new Dictionary<string, string>();

	public ModuleDefMD Rename(ModuleDefMD module)
	{
		foreach (TypeDef type in module.GetTypes())
		{
			if (!type.IsGlobalModuleType && !(type.Name == "GeneratedInternalTypeHelper") && !(type.Name == "Resources"))
			{
				if (_names.TryGetValue(type.Name, out var value))
				{
					type.Name = value;
					continue;
				}
				string text = Utils.GenerateRandomString();
				_names.Add(type.Name, text);
				type.Name = text;
			}
		}
		return ApplyChangesToResources(module);
	}

	private static ModuleDefMD ApplyChangesToResources(ModuleDefMD module)
	{
		foreach (Resource resource in module.Resources)
		{
			foreach (KeyValuePair<string, string> name in _names)
			{
				if (resource.Name.Contains(name.Key))
				{
					resource.Name = resource.Name.Replace(name.Key, name.Value);
				}
			}
		}
		foreach (TypeDef type in module.GetTypes())
		{
			foreach (PropertyDef property in type.Properties)
			{
				if (property.Name != "ResourceManager")
				{
					continue;
				}
				IList<Instruction> instructions = property.GetMethod.Body.Instructions;
				for (int i = 0; i < instructions.Count; i++)
				{
					if (instructions[i].OpCode != OpCodes.Ldstr)
					{
						continue;
					}
					foreach (KeyValuePair<string, string> name2 in _names)
					{
						if (instructions[i].Operand.ToString().Contains(name2.Key))
						{
							instructions[i].Operand = instructions[i].Operand.ToString().Replace(name2.Key, name2.Value);
						}
					}
				}
			}
		}
		return module;
	}
}
}