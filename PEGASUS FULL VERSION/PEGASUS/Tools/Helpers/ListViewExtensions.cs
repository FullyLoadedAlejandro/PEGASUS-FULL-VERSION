using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PEGASUS.Tools.Helpers
	{
public static class ListViewExtensions
{
	private struct LV_ITEM
	{
		public uint uiMask;

		public int iItem;

		public int iSubItem;

		public uint uiState;

		public uint uiStateMask;

		public string pszText;

		public int cchTextMax;

		public int iImage;

		public IntPtr lParam;
	}

	public const int LVM_FIRST = 4096;

	public const int LVM_SETITEM = 4102;

	public const int LVIF_IMAGE = 2;

	public const int LVW_FIRST = 4096;

	public const int LVM_SETEXTENDEDLISTVIEWSTYLE = 4150;

	public const int LVM_GETEXTENDEDLISTVIEWSTYLE = 4151;

	public const int LVS_EX_SUBITEMIMAGES = 2;

	[DllImport("user32.dll")]
	private static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

	[DllImport("user32.dll")]
	private static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, ref LV_ITEM item_info);

	public static void MakeColumnHeaders(this ListView lvw, params object[] header_info)
	{
		lvw.Columns.Clear();
		for (int i = header_info.GetLowerBound(0); i <= header_info.GetUpperBound(0); i += 3)
		{
			lvw.Columns.Add((string)header_info[i], (int)header_info[i + 1], (HorizontalAlignment)header_info[i + 2]);
		}
	}

	public static void AddRow(this ListView lvw, string item_title, params string[] subitem_titles)
	{
		ListViewItem listViewItem = lvw.Items.Add(item_title, 1);
		for (int i = subitem_titles.GetLowerBound(0); i <= subitem_titles.GetUpperBound(0); i++)
		{
			listViewItem.SubItems.Add(subitem_titles[i]);
		}
	}

	public static void ShowSubItemIcons(this ListView lvw, bool show)
	{
		int num = SendMessage(lvw.Handle, 4151u, 0, 0);
		num = ((!show) ? (num & -3) : (num | 2));
		SendMessage(lvw.Handle, 4150u, 0, num);
	}

	public static void AddIconToSubitem(this ListView lvw, int row, int col, int icon_num)
	{
		LV_ITEM item_info = default(LV_ITEM);
		item_info.iItem = row;
		item_info.iSubItem = col;
		item_info.uiMask = 2u;
		item_info.iImage = icon_num;
		SendMessage(lvw.Handle, 4102u, 0, ref item_info);
	}
}
}