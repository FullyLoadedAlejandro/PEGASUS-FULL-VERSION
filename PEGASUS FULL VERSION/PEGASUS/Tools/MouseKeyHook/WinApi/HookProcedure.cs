using System;

namespace PEGASUS.Tools.MouseKeyHook.WinApi
    {
public delegate IntPtr HookProcedure(int nCode, IntPtr wParam, IntPtr lParam);
}