using System;

namespace PEGASUS.Utilities
{ 

public static class PlatformHelper
{
	public static int Architecture => IntPtr.Size * 8;

	public static bool RunningOnMono { get; private set; }

	public static bool Win32NT { get; private set; }

	public static bool XpOrHigher { get; private set; }

	public static bool VistaOrHigher { get; private set; }

	public static bool SevenOrHigher { get; private set; }

	public static bool EightOrHigher { get; private set; }

	public static bool EightPointOneOrHigher { get; private set; }

	public static bool TenOrHigher { get; private set; }

	static PlatformHelper()
	{
		Win32NT = Environment.OSVersion.Platform == PlatformID.Win32NT;
		XpOrHigher = Win32NT && Environment.OSVersion.Version.Major >= 5;
		VistaOrHigher = Win32NT && Environment.OSVersion.Version.Major >= 6;
		SevenOrHigher = Win32NT && Environment.OSVersion.Version >= new Version(6, 1);
		EightOrHigher = Win32NT && Environment.OSVersion.Version >= new Version(6, 2, 9200);
		EightPointOneOrHigher = Win32NT && Environment.OSVersion.Version >= new Version(6, 3);
		TenOrHigher = Win32NT && Environment.OSVersion.Version >= new Version(10, 0);
		RunningOnMono = Type.GetType("Mono.Runtime") != null;
	}
}
}