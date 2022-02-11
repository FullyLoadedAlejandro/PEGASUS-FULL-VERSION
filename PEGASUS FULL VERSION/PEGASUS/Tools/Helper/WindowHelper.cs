using PEGASUS.Tools.Networking;

namespace PEGASUS.Tools.Helper
	{
public static class WindowHelper
{
	public static string GetWindowTitle(string title, Client c)
	{
		return $"{title} - {c.Value.Username}@{c.Value.PCName} [{c.EndPoint.Address.ToString()}:{c.EndPoint.Port.ToString()}]";
	}

	public static string GetWindowTitle(string title, int count)
	{
		return $"{title} [Selected: {count}]";
	}
}
}