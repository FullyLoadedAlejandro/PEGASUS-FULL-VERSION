using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PEGASUS.Pegasus
{
	// Token: 0x02000100 RID: 256
	public static class encryption
	{
		// Token: 0x06000773 RID: 1907 RVA: 0x0002B090 File Offset: 0x00029290
		public static string byte_arr_to_str(byte[] ba)
		{
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder(ba.Length * 2);
			foreach (byte b in ba)
			{
				stringBuilder.AppendFormat("{0:x2}", b);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x0002B0D4 File Offset: 0x000292D4
		public static byte[] str_to_byte_arr(string hex)
		{
			byte[] result;
			try
			{
				int length = hex.Length;
				byte[] array = new byte[length / 2];
				for (int i = 0; i < length; i += 2)
				{
					array[i / 2] = global::System.Convert.ToByte(hex.Substring(i, 2), 16);
				}
				result = array;
			}
			catch
			{
				global::PEGASUS.MsgBox.Show("The session has ended, open program again.");
				global::System.Environment.Exit(0);
				result = null;
			}
			return result;
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x0002B13C File Offset: 0x0002933C
		public static string encrypt_string(string plain_text, byte[] key, byte[] iv)
		{
			global::System.Security.Cryptography.Aes aes = global::System.Security.Cryptography.Aes.Create();
			aes.Mode = global::System.Security.Cryptography.CipherMode.CBC;
			aes.Key = key;
			aes.IV = iv;
			string result;
			using (global::System.IO.MemoryStream memoryStream = new global::System.IO.MemoryStream())
			{
				using (global::System.Security.Cryptography.ICryptoTransform cryptoTransform = aes.CreateEncryptor())
				{
					using (global::System.Security.Cryptography.CryptoStream cryptoStream = new global::System.Security.Cryptography.CryptoStream(memoryStream, cryptoTransform, global::System.Security.Cryptography.CryptoStreamMode.Write))
					{
						byte[] bytes = global::System.Text.Encoding.Default.GetBytes(plain_text);
						cryptoStream.Write(bytes, 0, bytes.Length);
						cryptoStream.FlushFinalBlock();
						result = global::PEGASUS.Pegasus.encryption.byte_arr_to_str(memoryStream.ToArray());
					}
				}
			}
			return result;
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x0002B1F4 File Offset: 0x000293F4
		public static string decrypt_string(string cipher_text, byte[] key, byte[] iv)
		{
			global::System.Security.Cryptography.Aes aes = global::System.Security.Cryptography.Aes.Create();
			aes.Mode = global::System.Security.Cryptography.CipherMode.CBC;
			aes.Key = key;
			aes.IV = iv;
			string @string;
			using (global::System.IO.MemoryStream memoryStream = new global::System.IO.MemoryStream())
			{
				using (global::System.Security.Cryptography.ICryptoTransform cryptoTransform = aes.CreateDecryptor())
				{
					using (global::System.Security.Cryptography.CryptoStream cryptoStream = new global::System.Security.Cryptography.CryptoStream(memoryStream, cryptoTransform, global::System.Security.Cryptography.CryptoStreamMode.Write))
					{
						byte[] array = global::PEGASUS.Pegasus.encryption.str_to_byte_arr(cipher_text);
						cryptoStream.Write(array, 0, array.Length);
						cryptoStream.FlushFinalBlock();
						byte[] array2 = memoryStream.ToArray();
						@string = global::System.Text.Encoding.Default.GetString(array2, 0, array2.Length);
					}
				}
			}
			return @string;
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x0002B2B4 File Offset: 0x000294B4
		public static string iv_key()
		{
			return global::System.Guid.NewGuid().ToString().Substring(0, global::System.Guid.NewGuid().ToString().IndexOf("-", global::System.StringComparison.Ordinal));
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x00006080 File Offset: 0x00004280
		public static string sha256(string r)
		{
			return global::PEGASUS.Pegasus.encryption.byte_arr_to_str(new global::System.Security.Cryptography.SHA256Managed().ComputeHash(global::System.Text.Encoding.Default.GetBytes(r)));
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x0002B2F8 File Offset: 0x000294F8
		public static string encrypt(string message, string enc_key, string iv)
		{
			byte[] bytes = global::System.Text.Encoding.Default.GetBytes(global::PEGASUS.Pegasus.encryption.sha256(enc_key).Substring(0, 32));
			byte[] bytes2 = global::System.Text.Encoding.Default.GetBytes(global::PEGASUS.Pegasus.encryption.sha256(iv).Substring(0, 16));
			return global::PEGASUS.Pegasus.encryption.encrypt_string(message, bytes, bytes2);
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x0002B340 File Offset: 0x00029540
		public static string decrypt(string message, string enc_key, string iv)
		{
			byte[] bytes = global::System.Text.Encoding.Default.GetBytes(global::PEGASUS.Pegasus.encryption.sha256(enc_key).Substring(0, 32));
			byte[] bytes2 = global::System.Text.Encoding.Default.GetBytes(global::PEGASUS.Pegasus.encryption.sha256(iv).Substring(0, 16));
			return global::PEGASUS.Pegasus.encryption.decrypt_string(message, bytes, bytes2);
		}
	}
}
