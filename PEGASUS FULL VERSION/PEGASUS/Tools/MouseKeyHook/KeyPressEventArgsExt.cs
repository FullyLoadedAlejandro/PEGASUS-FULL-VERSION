using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using PEGASUS.Tools.MouseKeyHook.WinApi;

namespace PEGASUS.Tools.MouseKeyHook
	{
public class KeyPressEventArgsExt : KeyPressEventArgs
{
	public bool IsNonChar { get; private set; }

	public int Timestamp { get; private set; }

	internal KeyPressEventArgsExt(char keyChar, int timestamp)
		: base(keyChar)
	{
		IsNonChar = keyChar == '\0';
		Timestamp = timestamp;
	}

	public KeyPressEventArgsExt(char keyChar)
		: this(keyChar, Environment.TickCount)
	{
	}

	internal static IEnumerable<KeyPressEventArgsExt> FromRawDataApp(CallbackData data)
	{
		IntPtr wParam = data.WParam;
		uint num = (uint)data.LParam.ToInt64();
		bool flag = (num & 0x40000000) != 0;
		bool flag2 = (num & 0x80000000u) != 0;
		if (!flag && !flag2)
		{
			yield break;
		}
		int virtualKeyCode = (int)wParam;
		int scanCode = checked((int)(num & 0xFF0000u));
		KeyboardNativeMethods.TryGetCharFromKeyboardState(virtualKeyCode, scanCode, 0, out var chars);
		if (chars != null)
		{
			char[] array = chars;
			foreach (char c in array)
			{
				yield return new KeyPressEventArgsExt(c);
			}
		}
	}

	internal static IEnumerable<KeyPressEventArgsExt> FromRawDataGlobal(CallbackData data)
	{
		IntPtr wParam = data.WParam;
		IntPtr lParam = data.LParam;
		if ((int)wParam != 256)
		{
			yield break;
		}
		KeyboardHookStruct keyboardHookStruct = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));
		int virtualKeyCode = keyboardHookStruct.VirtualKeyCode;
		int scanCode = keyboardHookStruct.ScanCode;
		int flags = keyboardHookStruct.Flags;
		if (virtualKeyCode == 231)
		{
			char c = (char)scanCode;
			yield return new KeyPressEventArgsExt(c, keyboardHookStruct.Time);
			yield break;
		}
		KeyboardNativeMethods.TryGetCharFromKeyboardState(virtualKeyCode, scanCode, flags, out var chars);
		if (chars != null)
		{
			char[] array = chars;
			foreach (char c2 in array)
			{
				yield return new KeyPressEventArgsExt(c2, keyboardHookStruct.Time);
			}
		}
	}
}
}