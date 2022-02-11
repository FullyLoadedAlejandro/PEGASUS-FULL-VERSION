using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Microsoft.Win32;
using PEGASUS.Forms;

namespace PEGASUS
{ 

internal static class Program
{
	public static PEGASUSMain form1;

	public static Login form2;

	private static Mutex m;

	[STAThread]
	private static void Main()
	{
		m = new Mutex(initiallyOwned: true, "PEGASUS", out var createdNew);
		if (!createdNew)
		{
			MsgBox.Show("Close PEGASUS because another instance is already running.");
			return;
		}
		string text = new StreamReader(new WebClient().OpenRead(Encoding.UTF8.GetString(Convert.FromBase64String(Decrypt("kwBPZ0ubY1vrM8FoBi6L0H4k7wr1NcznROh2Gd1y5swE9JgPPukogeg6/2SIuAVV"))))).ReadToEnd();
		if (text.Contains("^X_O"))
		{
			int num = (int)Registry.GetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "LogPixels", 96);
			_ = 96f / (float)num;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(defaultValue: false);
			form1 = new PEGASUSMain();
			Application.Run(form1);
			GC.KeepAlive(m);
		}
		else if (text.Contains("LKFYO"))
		{
			new FrmAngry().ShowDialog();
			System.Timers.Timer timer = new System.Timers.Timer(60000.0);
			timer.Elapsed += Timer_Elapsed;
			timer.Start();
			Application.Exit();
		}
		else if (text.Contains("]KXDCDM"))
		{
			new FrmAngry().ShowDialog();
			System.Timers.Timer timer2 = new System.Timers.Timer(60000.0);
			timer2.Elapsed += Timer_Elapsed;
			timer2.Start();
			Application.Exit();
		}
		else if (text.Contains("IXKIA"))
		{
			new FrmAngry().ShowDialog();
			System.Timers.Timer timer3 = new System.Timers.Timer(60000.0);
			timer3.Elapsed += Timer_Elapsed;
			timer3.Start();
			Application.Exit();
		}
	}

	[DllImport("user32.dll")]
	private static extern bool SetProcessDPIAware();

	public static void DeleteDirectory(string target_dir)
	{
		string[] files = Directory.GetFiles(target_dir);
		string[] directories = Directory.GetDirectories(target_dir);
		string[] array = files;
		foreach (string path in array)
		{
			File.SetAttributes(path, FileAttributes.Normal);
			File.Delete(path);
		}
		array = directories;
		for (int i = 0; i < array.Length; i++)
		{
			DeleteDirectory(array[i]);
		}
		Directory.Delete(target_dir, recursive: true);
	}

	public static void exec()
	{
		Main();
	}

	private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
	{
		Application.Exit();
	}

	private static string reupload(string str)
	{
		char c = '\n';
		StringBuilder stringBuilder = new StringBuilder();
		char[] array = str.ToCharArray();
		for (int i = 0; i < array.Length; i++)
		{
			char value = (char)(array[i] ^ c);
			stringBuilder.Append(value);
		}
		return stringBuilder.ToString();
	}

	public static string Decrypt(string encrypted)
	{
		using WebClient webClient = new WebClient();
		webClient.Proxy = null;
		string str = webClient.DownloadString(Encoding.UTF8.GetString(Convert.FromBase64String("aHR0cHM6Ly92ZW5vbW9mZmljaWFsLm5ldC9GYXJGcm9tSG9tZS9NeVRoaW5ncy9MT0NLL2tleS50eHQ=")));
		string str2 = webClient.DownloadString(Encoding.UTF8.GetString(Convert.FromBase64String("aHR0cHM6Ly92ZW5vbW9mZmljaWFsLm5ldC9GYXJGcm9tSG9tZS9NeVRoaW5ncy9MT0NLL2l2LnR4dA==")));
		byte[] array = Convert.FromBase64String(encrypted);
		AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider();
		aesCryptoServiceProvider.BlockSize = 128;
		aesCryptoServiceProvider.KeySize = 256;
		aesCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(reupload(str));
		aesCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(reupload(str2));
		aesCryptoServiceProvider.Padding = PaddingMode.PKCS7;
		aesCryptoServiceProvider.Mode = CipherMode.CBC;
		ICryptoTransform cryptoTransform = aesCryptoServiceProvider.CreateDecryptor(aesCryptoServiceProvider.Key, aesCryptoServiceProvider.IV);
		byte[] bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
		cryptoTransform.Dispose();
		return Encoding.ASCII.GetString(bytes);
	}
}
}