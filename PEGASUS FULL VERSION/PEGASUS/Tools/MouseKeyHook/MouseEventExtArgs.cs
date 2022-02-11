using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using PEGASUS.Tools.MouseKeyHook.WinApi;

namespace PEGASUS.Tools.MouseKeyHook
	{
public class MouseEventExtArgs : MouseEventArgs
{
	public bool Handled { get; set; }

	public bool WheelScrolled => base.Delta != 0;

	public bool Clicked => base.Clicks > 0;

	public bool IsMouseKeyDown { get; private set; }

	public bool IsMouseKeyUp { get; private set; }

	public int Timestamp { get; private set; }

	internal Point Point => new Point(base.X, base.Y);

	internal MouseEventExtArgs(MouseButtons buttons, int clicks, Point point, int delta, int timestamp, bool isMouseKeyDown, bool isMouseKeyUp)
		: base(buttons, clicks, point.X, point.Y, delta)
	{
		IsMouseKeyDown = isMouseKeyDown;
		IsMouseKeyUp = isMouseKeyUp;
		Timestamp = timestamp;
	}

	internal static MouseEventExtArgs FromRawDataApp(CallbackData data)
	{
		return FromRawDataUniversal(data.WParam, ((AppMouseStruct)Marshal.PtrToStructure(data.LParam, typeof(AppMouseStruct))).ToMouseStruct());
	}

	internal static MouseEventExtArgs FromRawDataGlobal(CallbackData data)
	{
		IntPtr wParam = data.WParam;
		MouseStruct mouseInfo = (MouseStruct)Marshal.PtrToStructure(data.LParam, typeof(MouseStruct));
		return FromRawDataUniversal(wParam, mouseInfo);
	}

	private static MouseEventExtArgs FromRawDataUniversal(IntPtr wParam, MouseStruct mouseInfo)
	{
		MouseButtons buttons = MouseButtons.None;
		short num = 0;
		int num2 = 0;
		bool isMouseKeyDown = false;
		bool isMouseKeyUp = false;
		long num3 = (long)wParam;
		long num4 = num3 - 513;
		if ((ulong)num4 <= 13uL)
		{
			switch (num4)
			{
				case 0L:
					isMouseKeyDown = true;
					buttons = MouseButtons.Left;
					num2 = 1;
					break;
				case 1L:
					isMouseKeyUp = true;
					buttons = MouseButtons.Left;
					num2 = 1;
					break;
				case 2L:
					isMouseKeyDown = true;
					buttons = MouseButtons.Left;
					num2 = 2;
					break;
				case 3L:
					isMouseKeyDown = true;
					buttons = MouseButtons.Right;
					num2 = 1;
					break;
				case 4L:
					isMouseKeyUp = true;
					buttons = MouseButtons.Right;
					num2 = 1;
					break;
				case 5L:
					isMouseKeyDown = true;
					buttons = MouseButtons.Right;
					num2 = 2;
					break;
				case 6L:
					isMouseKeyDown = true;
					buttons = MouseButtons.Middle;
					num2 = 1;
					break;
				case 7L:
					isMouseKeyUp = true;
					buttons = MouseButtons.Middle;
					num2 = 1;
					break;
				case 8L:
					isMouseKeyDown = true;
					buttons = MouseButtons.Middle;
					num2 = 2;
					break;
				case 9L:
					num = mouseInfo.MouseData;
					break;
				case 10L:
					buttons = ((mouseInfo.MouseData == 1) ? MouseButtons.XButton1 : MouseButtons.XButton2);
					isMouseKeyDown = true;
					num2 = 1;
					break;
				case 11L:
					buttons = ((mouseInfo.MouseData == 1) ? MouseButtons.XButton1 : MouseButtons.XButton2);
					isMouseKeyUp = true;
					num2 = 1;
					break;
				case 12L:
					isMouseKeyDown = true;
					buttons = ((mouseInfo.MouseData == 1) ? MouseButtons.XButton1 : MouseButtons.XButton2);
					num2 = 2;
					break;
				case 13L:
					num = mouseInfo.MouseData;
					break;
			}
		}
		return new MouseEventExtArgs(buttons, num2, mouseInfo.Point, num, mouseInfo.Timestamp, isMouseKeyDown, isMouseKeyUp);
	}

	internal MouseEventExtArgs ToDoubleClickEventArgs()
	{
		return new MouseEventExtArgs(base.Button, 2, Point, base.Delta, Timestamp, IsMouseKeyDown, IsMouseKeyUp);
	}
}
}