using System.Drawing;
using System.Windows.Forms;
using PEGASUS.Tools.MouseKeyHook.WinApi;

namespace PEGASUS.Tools.MouseKeyHook.Implementation
	{
internal class GlobalMouseListener : MouseListener
{
	private readonly int m_SystemDoubleClickTime;

	private MouseButtons m_PreviousClicked;

	private Point m_PreviousClickedPosition;

	private int m_PreviousClickedTime;

	public GlobalMouseListener()
		: base(HookHelper.HookGlobalMouse)
	{
		m_SystemDoubleClickTime = MouseNativeMethods.GetDoubleClickTime();
	}

	protected override void ProcessDown(ref MouseEventExtArgs e)
	{
		if (IsDoubleClick(e))
		{
			e = e.ToDoubleClickEventArgs();
		}
		base.ProcessDown(ref e);
	}

	protected override void ProcessUp(ref MouseEventExtArgs e)
	{
		base.ProcessUp(ref e);
		if (e.Clicks == 2)
		{
			StopDoubleClickWaiting();
		}
		if (e.Clicks == 1)
		{
			StartDoubleClickWaiting(e);
		}
	}

	private void StartDoubleClickWaiting(MouseEventExtArgs e)
	{
		m_PreviousClicked = e.Button;
		m_PreviousClickedTime = e.Timestamp;
		m_PreviousClickedPosition = e.Point;
	}

	private void StopDoubleClickWaiting()
	{
		m_PreviousClicked = MouseButtons.None;
		m_PreviousClickedTime = 0;
		m_PreviousClickedPosition = new Point(0, 0);
	}

	private bool IsDoubleClick(MouseEventExtArgs e)
	{
		if (e.Button == m_PreviousClicked && e.Point == m_PreviousClickedPosition)
		{
			return e.Timestamp - m_PreviousClickedTime <= m_SystemDoubleClickTime;
		}
		return false;
	}

	protected override MouseEventExtArgs GetEventArgs(CallbackData data)
	{
		return MouseEventExtArgs.FromRawDataGlobal(data);
	}
}
}