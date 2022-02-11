using PEGASUS.Tools.MouseKeyHook.Implementation;

namespace PEGASUS.Tools.MouseKeyHook
	{
public static class Hook
{
	public static IKeyboardMouseEvents AppEvents()
	{
		return new AppEventFacade();
	}

	public static IKeyboardMouseEvents GlobalEvents()
	{
		return new GlobalEventFacade();
	}
}
}