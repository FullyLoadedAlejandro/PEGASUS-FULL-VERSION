using System;
using System.Runtime.InteropServices;

namespace PEGASUS.Utilities
{ 

public static class NativeMethods
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct LVITEM
	{
		public int mask;

		public int iItem;

		public int iSubItem;

		public int state;

		public int stateMask;

		[MarshalAs(UnmanagedType.LPTStr)]
		public string pszText;

		public int cchTextMax;

		public int iImage;

		public IntPtr lParam;

		public int iIndent;

		public int iGroupId;

		public int cColumns;

		public IntPtr puColumns;
	}

	[DllImport("user32.dll")]
	public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

	[DllImport("user32.dll")]
	public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, int vk);

	[DllImport("user32.dll")]
	public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

	[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
	public static extern IntPtr SendMessageLVItem(IntPtr hWnd, int msg, int wParam, ref LVITEM lvi);

	[DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
	public static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

	[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
	public unsafe static extern int memcmp(byte* ptr1, byte* ptr2, uint count);

	[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
	public static extern int memcmp(IntPtr ptr1, IntPtr ptr2, uint count);

	[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
	public static extern int memcpy(IntPtr dst, IntPtr src, uint count);

	[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
	public unsafe static extern int memcpy(void* dst, void* src, uint count);

	[DllImport("kernel32.dll")]
	public static extern IntPtr LoadLibrary(string dllToLoad);

	[DllImport("kernel32.dll")]
	public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

	[DllImport("kernel32.dll")]
	public static extern bool FreeLibrary(IntPtr hModule);
}
}