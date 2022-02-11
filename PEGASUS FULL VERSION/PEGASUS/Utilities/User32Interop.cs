using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace PEGASUS.Utilities
{ 

public static class User32Interop
{
	private const byte HighBit = 128;

	public static char ToAscii(Keys key, Keys modifiers)
	{
		StringBuilder stringBuilder = new StringBuilder(2);
		if (ToAscii((uint)key, 0u, GetKeyState(modifiers), stringBuilder, 0u) == 1)
		{
			return stringBuilder[0];
		}
		throw new Exception("Invalid key");
	}

	private static byte[] GetKeyState(Keys modifiers)
	{
		byte[] array = new byte[256];
		foreach (Keys value in Enum.GetValues(typeof(Keys)))
		{
			if ((modifiers & value) == value)
			{
				array[(int)value] = 128;
			}
		}
		return array;
	}

	[DllImport("user32.dll")]
	private static extern int ToAscii(uint uVirtKey, uint uScanCode, byte[] lpKeyState, [Out] StringBuilder lpChar, uint uFlags);
}
}