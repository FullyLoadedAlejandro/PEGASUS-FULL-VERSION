using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using PEGASUS.Forms.RenamingObfuscation.Overkill.Utils;

namespace PEGASUS.Forms.RenamingObfuscation.Overkill.Protections
	{
public class StringEncryption : Randomizer
{
	private static readonly RandomNumberGenerator csp = RandomNumberGenerator.Create();

	private static int Amount { get; set; }

	public static void Execute()
	{
		MethodDef methodDef = (MethodDef)InjectHelper.Inject(ModuleDefMD.Load(typeof(StringDecoder).Module).ResolveTypeDef(MDToken.ToRID(typeof(StringDecoder).MetadataToken)), Ovelkill.Module.GlobalType, Ovelkill.Module).Single((IDnlibDef method) => method.Name == "Decrypt");
		methodDef.Rename(Randomizer.GenerateRandomString(MemberRenamer.StringLength()));
		foreach (MethodDef method in Ovelkill.Module.GlobalType.Methods)
		{
			if (method.Name.Equals(".ctor"))
			{
				Ovelkill.Module.GlobalType.Remove(method);
				break;
			}
		}
		foreach (TypeDef type in Ovelkill.Module.Types)
		{
			if (type.IsGlobalModuleType)
			{
				continue;
			}
			foreach (MethodDef method2 in type.Methods)
			{
				new CryptoRandom();
				if (!method2.HasBody)
				{
					continue;
				}
				for (int i = 0; i < method2.Body.Instructions.Count; i++)
				{
					if (method2.Body.Instructions[i].OpCode == OpCodes.Ldstr)
					{
						int num = method2.Name.Length + Next();
						string operand = Encrypt(new Tuple<string, int>(method2.Body.Instructions[i].Operand.ToString(), num));
						method2.Body.Instructions[i].OpCode = OpCodes.Ldstr;
						method2.Body.Instructions[i].Operand = operand;
						method2.Body.Instructions.Insert(i + 1, OpCodes.Ldc_I4.ToInstruction(num));
						method2.Body.Instructions.Insert(i + 2, OpCodes.Call.ToInstruction(methodDef));
						Amount++;
						i += 2;
					}
				}
			}
		}
		Console.WriteLine($"  Encrypted {Amount} strings.");
	}

	public static int Next()
	{
		return BitConverter.ToInt32(RandomBytes(4), 0);
	}

	private static byte[] RandomBytes(int bytes)
	{
		byte[] array = new byte[bytes];
		csp.GetBytes(array);
		return array;
	}

	public static string Encrypt(Tuple<string, int> values)
	{
		StringBuilder stringBuilder = new StringBuilder(values.Item1);
		StringBuilder stringBuilder2 = new StringBuilder(values.Item1.Length);
		int item = values.Item2;
		for (int i = 0; i < values.Item1.Length; i++)
		{
			char c = stringBuilder[i];
			c = (char)(c ^ item);
			stringBuilder2.Append(c);
		}
		return stringBuilder2.ToString();
	}
}
}