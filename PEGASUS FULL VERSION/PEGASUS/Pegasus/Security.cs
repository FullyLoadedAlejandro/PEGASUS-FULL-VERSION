using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;

namespace PEGASUS.Pegasus
	{
internal class Security
{
	private const string _key = "045C03C7FB0E76A822AB197B6663C288D9632E55B39B80296CBCD978707A7E5B3EAE1DB5D487CE9F0E448C3557079CE142F5A41B7F1F6436077D8F3FF7C311888C";

	public static string Signature(string value)
	{
		using MD5 mD = MD5.Create();
		byte[] bytes = Encoding.UTF8.GetBytes(value);
		return BitConverter.ToString(mD.ComputeHash(bytes)).Replace("-", "");
	}

	private static string Session(int length)
	{
		Random random = new Random();
		return new string((from s in Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz", length)
						   select s[random.Next(s.Length)]).ToArray());
	}

	public static string Obfuscate(int length)
	{
		Random random = new Random();
		return new string((from s in Enumerable.Repeat("gd8JQ57nxXzLLMPrLylVhxoGnWGCFjO4knKTfRE6mVvdjug2NF/4aptAsZcdIGbAPmcx0O+ftU/KvMIjcfUnH3j+IMdhAW5OpoX3MrjQdf5AAP97tTB5g1wdDSAqKpq9gw06t3VaqMWZHKtPSuAXy0kkZRsc+DicpcY8E9+vWMHXa3jMdbPx4YES0p66GzhqLd/heA2zMvX8iWv4wK7S3QKIW/a9dD4ALZJpmcr9OOE=", length)
						   select s[random.Next(s.Length)]).ToArray());
	}

	public static void Start()
	{
		string pathRoot = Path.GetPathRoot(Environment.SystemDirectory);
		if (Constants.Started)
		{
			MessageBox.Show("A session has already been started, please end the previous one!", ABC.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
			Process.GetCurrentProcess().Kill();
			return;
		}
		using (StreamReader streamReader = new StreamReader(pathRoot + "Windows\\System32\\drivers\\etc\\hosts"))
		{
			if (streamReader.ReadToEnd().Contains("api.auth.gg"))
			{
				Constants.Breached = true;
				MessageBox.Show("DNS redirecting has been detected!", ABC.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Process.GetCurrentProcess().Kill();
			}
		}
		new InfoManager().StartListener();
		Constants.Token = Guid.NewGuid().ToString();
		ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)Delegate.Combine(ServicePointManager.ServerCertificateValidationCallback, new RemoteCertificateValidationCallback(PinPublicKey));
		Constants.APIENCRYPTKEY = Convert.ToBase64String(Encoding.Default.GetBytes(Session(32)));
		Constants.APIENCRYPTSALT = Convert.ToBase64String(Encoding.Default.GetBytes(Session(16)));
		Constants.IV = Convert.ToBase64String(Encoding.Default.GetBytes(Constants.RandomString(16)));
		Constants.Key = Convert.ToBase64String(Encoding.Default.GetBytes(Constants.RandomString(32)));
		Constants.Started = true;
	}

	public static void End()
	{
		if (!Constants.Started)
		{
			MessageBox.Show("No session has been started, closing for security reasons!", ABC.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
			Process.GetCurrentProcess().Kill();
			return;
		}
		Constants.Token = null;
		ServicePointManager.ServerCertificateValidationCallback = (object _003Cp0_003E, X509Certificate _003Cp1_003E, X509Chain _003Cp2_003E, SslPolicyErrors _003Cp3_003E) => true;
		Constants.APIENCRYPTKEY = null;
		Constants.APIENCRYPTSALT = null;
		Constants.IV = null;
		Constants.Key = null;
		Constants.Started = false;
	}

	private static bool PinPublicKey(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
	{
		if (certificate != null)
		{
			return certificate.GetPublicKeyString() == "045C03C7FB0E76A822AB197B6663C288D9632E55B39B80296CBCD978707A7E5B3EAE1DB5D487CE9F0E448C3557079CE142F5A41B7F1F6436077D8F3FF7C311888C";
		}
		return false;
	}

	public static string Integrity(string filename)
	{
		using MD5 mD = MD5.Create();
		using FileStream inputStream = File.OpenRead(filename);
		return BitConverter.ToString(mD.ComputeHash(inputStream)).Replace("-", "").ToLowerInvariant();
	}

	public static bool MaliciousCheck(string date)
	{
		DateTime dateTime = DateTime.Parse(date);
		DateTime now = DateTime.Now;
		TimeSpan timeSpan = dateTime - now;
		if (Convert.ToInt32(timeSpan.Seconds.ToString().Replace("-", "")) >= 15 || Convert.ToInt32(timeSpan.Minutes.ToString().Replace("-", "")) >= 1)
		{
			Constants.Breached = true;
			return true;
		}
		return false;
	}
}
}