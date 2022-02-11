using System;
using PEGASUS.Tools.MouseKeyHook.WinApi;

namespace PEGASUS.Tools.MouseKeyHook.Implementation 
{ 

internal abstract class BaseListener : IDisposable
{
    protected HookResult Handle { get; set; }

    protected BaseListener(Subscribe subscribe)
    {
        Handle = subscribe(Callback);
    }

    public void Dispose()
    {
        Handle.Dispose();
    }

    protected abstract bool Callback(CallbackData data);
}
}