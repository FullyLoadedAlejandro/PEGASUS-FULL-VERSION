using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PEGASUS.Pegasus
	{
internal class Encryption
{
	public static string APIService(string value)
	{
		string @string = Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTKEY));
		byte[] key = SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(@string));
		byte[] bytes = Encoding.ASCII.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTSALT)));
		return EncryptString(value, key, bytes);
	}

	public static string EncryptService(string value)
	{
		string @string = Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTKEY));
		byte[] key = SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(@string));
		byte[] bytes = Encoding.ASCII.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTSALT)));
		string text = EncryptString(value, key, bytes);
		int length = int.Parse(ABC.AID.Substring(0, 2));
		return text + Security.Obfuscate(length);
	}

	public static string DecryptService(string value)
	{
		string @string = Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTKEY));
		byte[] key = SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(@string));
		byte[] bytes = Encoding.ASCII.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTSALT)));
		return DecryptString(value, key, bytes);
	}

	public static string EncryptString(string plainText, byte[] key, byte[] iv)
	{
		Aes aes = Aes.Create();
		aes.Mode = CipherMode.CBC;
		aes.Key = key;
		aes.IV = iv;
		MemoryStream memoryStream = new MemoryStream();
		ICryptoTransform transform = aes.CreateEncryptor();
		CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
		byte[] bytes = Encoding.ASCII.GetBytes(plainText);
		cryptoStream.Write(bytes, 0, bytes.Length);
		cryptoStream.FlushFinalBlock();
		byte[] array = memoryStream.ToArray();
		memoryStream.Close();
		cryptoStream.Close();
		return Convert.ToBase64String(array, 0, array.Length);
	}

	public static string DecryptString(string cipherText, byte[] key, byte[] iv)
	{
		Aes aes = Aes.Create();
		aes.Mode = CipherMode.CBC;
		aes.Key = key;
		aes.IV = iv;
		MemoryStream memoryStream = new MemoryStream();
		ICryptoTransform transform = aes.CreateDecryptor();
		CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
		string empty = string.Empty;
		try
		{
			byte[] array = Convert.FromBase64String(cipherText);
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.FlushFinalBlock();
			byte[] array2 = memoryStream.ToArray();
			return Encoding.ASCII.GetString(array2, 0, array2.Length);
		}
		finally
		{
			memoryStream.Close();
			cryptoStream.Close();
		}
	}

	public static string Decode(string text)
	{
		text = text.Replace('_', '/').Replace('-', '+');
		switch (text.Length % 4)
		{
			case 2:
				text += "==";
				break;
			case 3:
				text += "=";
				break;
		}
		return Encoding.UTF8.GetString(Convert.FromBase64String(text));
	}
}
public static class encryption
{
	public static string byte_arr_to_str(byte[] ba)
	{
		StringBuilder stringBuilder = new StringBuilder(ba.Length * 2);
		foreach (byte b in ba)
		{
			stringBuilder.AppendFormat("{0:x2}", b);
		}
		return stringBuilder.ToString();
	}

	public static byte[] str_to_byte_arr(string hex)
	{
		try
		{
			int length = hex.Length;
			byte[] array = new byte[length / 2];
			for (int i = 0; i < length; i += 2)
			{
				array[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
			}
			return array;
		}
		catch
		{
			MsgBox.Show("The session has ended, open program again.");
			Environment.Exit(0);
			return null;
		}
	}

	public static string encrypt_string(string plain_text, byte[] key, byte[] iv)
	{
		Aes aes = Aes.Create();
		aes.Mode = CipherMode.CBC;
		aes.Key = key;
		aes.IV = iv;
		using MemoryStream memoryStream = new MemoryStream();
		using ICryptoTransform transform = aes.CreateEncryptor();
		using CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
		byte[] bytes = Encoding.Default.GetBytes(plain_text);
		cryptoStream.Write(bytes, 0, bytes.Length);
		cryptoStream.FlushFinalBlock();
		return byte_arr_to_str(memoryStream.ToArray());
	}

	public static string decrypt_string(string cipher_text, byte[] key, byte[] iv)
	{
		Aes aes = Aes.Create();
		aes.Mode = CipherMode.CBC;
		aes.Key = key;
		aes.IV = iv;
		using MemoryStream memoryStream = new MemoryStream();
		using ICryptoTransform transform = aes.CreateDecryptor();
		using CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
		byte[] array = str_to_byte_arr(cipher_text);
		cryptoStream.Write(array, 0, array.Length);
		cryptoStream.FlushFinalBlock();
		byte[] array2 = memoryStream.ToArray();
		return Encoding.Default.GetString(array2, 0, array2.Length);
	}

	public static string iv_key()
	{
		return Guid.NewGuid().ToString().Substring(0, Guid.NewGuid().ToString().IndexOf("-", StringComparison.Ordinal));
	}

	public static string sha256(string r)
	{
		return byte_arr_to_str(new SHA256Managed().ComputeHash(Encoding.Default.GetBytes(r)));
	}

	public static string encrypt(string message, string enc_key, string iv)
	{
		byte[] bytes = Encoding.Default.GetBytes(sha256(enc_key).Substring(0, 32));
		byte[] bytes2 = Encoding.Default.GetBytes(sha256(iv).Substring(0, 16));
		return encrypt_string(message, bytes, bytes2);
	}

	public static string decrypt(string message, string enc_key, string iv)
	{
		byte[] bytes = Encoding.Default.GetBytes(sha256(enc_key).Substring(0, 32));
		byte[] bytes2 = Encoding.Default.GetBytes(sha256(iv).Substring(0, 16));
		return decrypt_string(message, bytes, bytes2);
	}
}
}