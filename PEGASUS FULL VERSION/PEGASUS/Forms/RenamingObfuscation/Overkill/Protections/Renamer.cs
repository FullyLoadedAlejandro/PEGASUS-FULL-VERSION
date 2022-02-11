using System;
using dnlib.DotNet;
using PEGASUS.Forms.RenamingObfuscation.Overkill.Utils;
using PEGASUS.Forms.RenamingObfuscation.Overkill.Utils.Analyzer;

namespace PEGASUS.Forms.RenamingObfuscation.Overkill.Protections
	{
public class Renamer : Randomizer
{
	private static int MethodAmount { get; set; }

	private static int ParameterAmount { get; set; }

	private static int PropertyAmount { get; set; }

	private static int FieldAmount { get; set; }

	private static int EventAmount { get; set; }

	public static void Execute()
	{
		if (Ovelkill.DontRename)
		{
			return;
		}
		Ovelkill.Module.Mvid = Guid.NewGuid();
		Ovelkill.Module.Name = Randomizer.GenerateRandomString(MemberRenamer.StringLength());
		Ovelkill.Module.EntryPoint.Name = Randomizer.GenerateRandomString(MemberRenamer.StringLength());
		foreach (TypeDef type in Ovelkill.Module.Types)
		{
			foreach (MethodDef method in type.Methods)
			{
				if (CanRename(method) && !Ovelkill.ForceWinForms && !Ovelkill.FileExtension.Contains("dll"))
				{
					method.Name = Randomizer.GenerateRandomString(MemberRenamer.StringLength());
					MethodAmount++;
				}
				foreach (Parameter parameter in method.Parameters)
				{
					if (CanRename(parameter))
					{
						parameter.Name = Randomizer.GenerateRandomString(MemberRenamer.StringLength());
						ParameterAmount++;
					}
				}
			}
			foreach (PropertyDef property in type.Properties)
			{
				if (CanRename(property))
				{
					property.Name = Randomizer.GenerateRandomString(MemberRenamer.StringLength());
					PropertyAmount++;
				}
			}
			foreach (FieldDef field in type.Fields)
			{
				if (CanRename(field))
				{
					field.Name = Randomizer.GenerateRandomString(MemberRenamer.StringLength());
					FieldAmount++;
				}
			}
			foreach (EventDef @event in type.Events)
			{
				if (CanRename(@event))
				{
					@event.Name = Randomizer.GenerateRandomString(MemberRenamer.StringLength());
					EventAmount++;
				}
			}
		}
		Console.WriteLine($"  Renamed {MethodAmount} methods.\n  Renamed {ParameterAmount} parameters." + $"\n  Renamed {PropertyAmount} properties.\n  Renamed {FieldAmount} fields.\n  Renamed {EventAmount} events.");
	}

	public static bool CanRename(object obj)
	{
		DefAnalyzer defAnalyzer;
		if (obj is MethodDef)
		{
			defAnalyzer = new MethodDefAnalyzer();
		}
		else if (obj is PropertyDef)
		{
			defAnalyzer = new PropertyDefAnalyzer();
		}
		else if (obj is EventDef)
		{
			defAnalyzer = new EventDefAnalyzer();
		}
		else if (obj is FieldDef)
		{
			defAnalyzer = new FieldDefAnalyzer();
		}
		else
		{
			if (!(obj is Parameter))
			{
				return false;
			}
			defAnalyzer = new ParameterAnalyzer();
		}
		return defAnalyzer.Execute(obj);
	}
}
}