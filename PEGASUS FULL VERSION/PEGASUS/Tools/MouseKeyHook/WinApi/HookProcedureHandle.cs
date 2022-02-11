using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;

namespace PEGASUS.Tools.MouseKeyHook.WinApi
	{
internal class HookProcedureHandle : SafeHandleZeroOrMinusOneIsInvalid
{
	private static bool _closing;

	static HookProcedureHandle()
	{
		Application.ApplicationExit += delegate
		{
			_closing = true;
		};
	}

	public HookProcedureHandle()
		: base(ownsHandle: true)
	{
	}

	protected override bool ReleaseHandle()
	{
		if (_closing)
		{
			return true;
		}
		return HookNativeMethods.UnhookWindowsHookEx(handle) != 0;
	}
}
}