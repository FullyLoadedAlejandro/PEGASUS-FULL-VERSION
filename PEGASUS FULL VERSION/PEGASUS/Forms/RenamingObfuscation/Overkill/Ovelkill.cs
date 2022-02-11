using System;
using System.IO;
using dnlib.DotNet;
using dnlib.DotNet.Writer;
using PEGASUS.Forms.RenamingObfuscation.Overkill.Protections;

namespace PEGASUS.Forms.RenamingObfuscation.Overkill
	{
internal class Ovelkill
{
	public ModuleDef ManifestModule;

	public static ModuleDefMD Module { get; set; }

	public static string FileExtension { get; set; }

	public static bool DontRename { get; set; }

	public static bool ForceWinForms { get; set; }

	public static string FilePath { get; set; }

	public static void fatality(string path)
	{
		Console.WriteLine("Drag n drop your file : ");
		Module = ModuleDefMD.Load(path);
		FileExtension = Path.GetExtension(path);
		Console.WriteLine("Encrypting strings...");
		StringEncryption.Execute();
		Console.WriteLine("Renaming...");
		Renamer.Execute();
		Console.WriteLine("Encoding ints...");
		IntEncoding.Execute();
		Console.WriteLine("Injecting ControlFlow...");
		ControlFlow.Execute();
		Console.WriteLine("Injecting local to fields...");
		L2F.Execute();
		Console.WriteLine("Adding Proxys...");
		ProxyInts.Execute();
		Console.WriteLine("Injecting AntiDe4Dot...");
		AntiDe4Dot.Execute();
		Console.WriteLine("Saving file...");
		string filename = path + "-Obfuscated.exe";
		ModuleWriterOptions options = new ModuleWriterOptions(Module)
		{
			Logger = DummyLogger.NoThrowInstance
		};
		Module.Write(filename, options);
	}
}
}