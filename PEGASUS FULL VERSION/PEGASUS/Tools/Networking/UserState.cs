using System;
using System.Windows.Forms;
using PEGASUS.Forms;
using PEGASUS.Utilities;

namespace PEGASUS.Tools.Networking
	{
public class UserState : IDisposable
{
	private bool _processingDirectory;

	private readonly object _processingDirectoryLock;

	public string Version { get; set; }

	public string OperatingSystem { get; set; }

	public string AccountType { get; set; }

	public int ImageIndex { get; set; }

	public string Country { get; set; }

	public string CountryCode { get; set; }

	public string Region { get; set; }

	public string City { get; set; }

	public string Id { get; set; }

	public string Username { get; set; }

	public string PCName { get; set; }

	public string UserAtPc => $"{Username}@{PCName}";

	public string CountryWithCode => $"{Country} [{CountryCode}]";

	public string Tag { get; set; }

	public string DownloadDirectory { get; set; }

	public Remote_Desktop FrmRdp { get; set; }

	public bool ReceivedLastDirectory { get; set; }

	public UnsafeStreamCodec StreamCodec { get; set; }

	public bool ProcessingDirectory
	{
		get
		{
			lock (_processingDirectoryLock)
			{
				return _processingDirectory;
			}
		}
		set
		{
			lock (_processingDirectoryLock)
			{
				_processingDirectory = value;
			}
		}
	}

	public UserState()
	{
		ReceivedLastDirectory = true;
		_processingDirectory = false;
		_processingDirectoryLock = new object();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposing)
		{
			return;
		}
		try
		{
			if (FrmRdp != null)
			{
				FrmRdp.Invoke((MethodInvoker)delegate
				{
					FrmRdp.Close();
				});
			}
		}
		catch (InvalidOperationException)
		{
		}
		if (StreamCodec != null)
		{
			StreamCodec.Dispose();
		}
	}
}
}