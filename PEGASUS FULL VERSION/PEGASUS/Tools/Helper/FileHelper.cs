using System;
using System.IO;
using System.Linq;
using System.Text;
using PEGASUS.Tools.Algorithm;

namespace PEGASUS.Tools.Helper
	{
public static class FileHelper
{
	private const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

	private static readonly Random _rnd = new Random(Environment.TickCount);

	private static readonly string[] _sizes = new string[4] { "B", "KB", "MB", "GB" };

	private static readonly char[] _illegalChars = Path.GetInvalidPathChars().Union(Path.GetInvalidFileNameChars()).ToArray();

	public static bool CheckPathForIllegalChars(string path)
	{
		return path.Any((char c) => _illegalChars.Contains(c));
	}

	public static string GetRandomFilename(int length, string extension = "")
	{
		StringBuilder stringBuilder = new StringBuilder(length);
		for (int i = 0; i < length; i++)
		{
			stringBuilder.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"[_rnd.Next("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".Length)]);
		}
		return stringBuilder.ToString() + extension;
	}

	public static int GetNewTransferId(int o = 0)
	{
		return _rnd.Next(0, int.MaxValue) + o;
	}

	public static string GetDataSize(long size)
	{
		double num = size;
		int num2 = 0;
		while (num >= 1024.0 && num2 + 1 < _sizes.Length)
		{
			num2++;
			num /= 1024.0;
		}
		return $"{num:0.##} {_sizes[num2]}";
	}

	public static int GetFileIcon(string extension)
	{
		if (string.IsNullOrEmpty(extension))
		{
			return 2;
		}
		switch (extension.ToLower())
		{
			default:
				return 2;
			case ".exe":
				return 3;
			case ".txt":
			case ".log":
			case ".conf":
			case ".cfg":
			case ".asc":
				return 4;
			case ".rar":
			case ".zip":
			case ".zipx":
			case ".tar":
			case ".tgz":
			case ".gz":
			case ".s7z":
			case ".7z":
			case ".bz2":
			case ".cab":
			case ".zz":
			case ".apk":
				return 5;
			case ".doc":
			case ".docx":
			case ".odt":
				return 6;
			case ".pdf":
				return 7;
			case ".jpg":
			case ".jpeg":
			case ".png":
			case ".bmp":
			case ".gif":
			case ".ico":
				return 8;
			case ".mp4":
			case ".mov":
			case ".avi":
			case ".wmv":
			case ".mkv":
			case ".m4v":
			case ".flv":
				return 9;
			case ".mp3":
			case ".wav":
			case ".pls":
			case ".m3u":
			case ".m4a":
				return 10;
		}
	}

	public static void WriteLogFile(string filename, string appendText)
	{
		appendText = ReadLogFile(filename) + appendText;
		using FileStream fileStream = File.Open(filename, FileMode.Create, FileAccess.Write);
		byte[] array = AES.Encrypt(Encoding.UTF8.GetBytes(appendText));
		fileStream.Seek(0L, SeekOrigin.Begin);
		fileStream.Write(array, 0, array.Length);
	}

	public static string ReadLogFile(string filename)
	{
		if (!File.Exists(filename))
		{
			return string.Empty;
		}
		return Encoding.UTF8.GetString(AES.Decrypt(File.ReadAllBytes(filename)));
	}
}
}