using PEGASUS.Tools.MouseKeyHook.WinApi;

namespace PEGASUS.Tools.MouseKeyHook.Implementation
{
internal class AppMouseListener : MouseListener
{
	public AppMouseListener()
		: base(HookHelper.HookAppMouse)
	{
	}

	protected override MouseEventExtArgs GetEventArgs(CallbackData data)
	{
		return MouseEventExtArgs.FromRawDataApp(data);
	}
}
}