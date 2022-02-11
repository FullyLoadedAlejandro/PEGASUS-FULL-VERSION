using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using PEGASUS.Tools.Algorithm;

namespace PEGASUS.Tools.Helper
	{
public static class CryptographyHelper
{
	[MethodImpl(MethodImplOptions.NoOptimization)]
	public static bool AreEqual(byte[] a1, byte[] a2)
	{
		bool result = true;
		for (int i = 0; i < a1.Length; i++)
		{
			if (a1[i] != a2[i])
			{
				result = false;
			}
		}
		return result;
	}

	public static void DeriveKeys(string password, out string key, out string authKey)
	{
		using Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, AES.Salt, 50000);
		key = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(16));
		authKey = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(64));
	}
}
}