using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using PEGASUS.Tools.MouseKeyHook.WinApi;

namespace PEGASUS.Tools.MouseKeyHook
	{
public class KeyEventArgsExt : KeyEventArgs
{
	public int Timestamp { get; private set; }

	public bool IsKeyDown { get; private set; }

	public bool IsKeyUp { get; private set; }

	public KeyEventArgsExt(Keys keyData)
		: base(keyData)
	{
	}

	internal KeyEventArgsExt(Keys keyData, int timestamp, bool isKeyDown, bool isKeyUp)
		: this(keyData)
	{
		Timestamp = timestamp;
		IsKeyDown = isKeyDown;
		IsKeyUp = isKeyUp;
	}

	internal static KeyEventArgsExt FromRawDataApp(CallbackData data)
	{
		IntPtr wParam = data.WParam;
		IntPtr lParam = data.LParam;
		int tickCount = Environment.TickCount;
		int num = (int)lParam.ToInt64();
		bool flag = (num & 0x40000000) != 0;
		bool flag2 = (num & int.MinValue) != 0;
		Keys num2 = AppendModifierStates((Keys)(int)wParam);
		bool isKeyDown = !flag && !flag2;
		bool isKeyUp = flag && flag2;
		return new KeyEventArgsExt(num2, tickCount, isKeyDown, isKeyUp);
	}

	internal static KeyEventArgsExt FromRawDataGlobal(CallbackData data)
	{
		IntPtr wParam = data.WParam;
		KeyboardHookStruct keyboardHookStruct = (KeyboardHookStruct)Marshal.PtrToStructure(data.LParam, typeof(KeyboardHookStruct));
		Keys keys = AppendModifierStates((Keys)keyboardHookStruct.VirtualKeyCode);
		int num = (int)wParam;
		bool isKeyDown = num == 256 || num == 260;
		bool isKeyUp = num == 257 || num == 261;
		return new KeyEventArgsExt(keys, keyboardHookStruct.Time, isKeyDown, isKeyUp);
	}

	private static bool CheckModifier(int vKey)
	{
		return (KeyboardNativeMethods.GetKeyState(vKey) & 0x8000) > 0;
	}

	private static Keys AppendModifierStates(Keys keyData)
	{
		bool flag = CheckModifier(17);
		bool flag2 = CheckModifier(16);
		bool flag3 = CheckModifier(18);
		return keyData | (flag ? Keys.Control : Keys.None) | (flag2 ? Keys.Shift : Keys.None) | (flag3 ? Keys.Alt : Keys.None);
	}
}
}