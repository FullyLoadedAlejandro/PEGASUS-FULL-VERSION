using System;
using System.Drawing;
using System.Windows.Forms;
using PEGASUS.Tools.MouseKeyHook.WinApi;

namespace PEGASUS.Tools.MouseKeyHook.Implementation
	{
internal abstract class MouseListener : BaseListener, IMouseEvents
{
	private readonly ButtonSet m_DoubleDown;

	private readonly ButtonSet m_SingleDown;

	private Point m_PreviousPosition;

	public event MouseEventHandler MouseMove;

	public event EventHandler<MouseEventExtArgs> MouseMoveExt;

	public event MouseEventHandler MouseClick;

	public event MouseEventHandler MouseDown;

	public event EventHandler<MouseEventExtArgs> MouseDownExt;

	public event MouseEventHandler MouseUp;

	public event EventHandler<MouseEventExtArgs> MouseUpExt;

	public event MouseEventHandler MouseWheel;

	public event MouseEventHandler MouseDoubleClick;

	protected MouseListener(Subscribe subscribe)
		: base(subscribe)
	{
		m_PreviousPosition = new Point(-1, -1);
		m_DoubleDown = new ButtonSet();
		m_SingleDown = new ButtonSet();
	}

	protected override bool Callback(CallbackData data)
	{
		MouseEventExtArgs e = GetEventArgs(data);
		if (e.IsMouseKeyDown)
		{
			ProcessDown(ref e);
		}
		if (e.IsMouseKeyUp)
		{
			ProcessUp(ref e);
		}
		if (e.WheelScrolled)
		{
			ProcessWheel(ref e);
		}
		if (HasMoved(e.Point))
		{
			ProcessMove(ref e);
		}
		return !e.Handled;
	}

	protected abstract MouseEventExtArgs GetEventArgs(CallbackData data);

	protected virtual void ProcessWheel(ref MouseEventExtArgs e)
	{
		OnWheel(e);
	}

	protected virtual void ProcessDown(ref MouseEventExtArgs e)
	{
		OnDown(e);
		OnDownExt(e);
		if (!e.Handled)
		{
			if (e.Clicks == 2)
			{
				m_DoubleDown.Add(e.Button);
			}
			if (e.Clicks == 1)
			{
				m_SingleDown.Add(e.Button);
			}
		}
	}

	protected virtual void ProcessUp(ref MouseEventExtArgs e)
	{
		if (m_SingleDown.Contains(e.Button))
		{
			OnUp(e);
			OnUpExt(e);
			if (e.Handled)
			{
				return;
			}
			OnClick(e);
			m_SingleDown.Remove(e.Button);
		}
		if (m_DoubleDown.Contains(e.Button))
		{
			e = e.ToDoubleClickEventArgs();
			OnUp(e);
			OnDoubleClick(e);
			m_DoubleDown.Remove(e.Button);
		}
	}

	private void ProcessMove(ref MouseEventExtArgs e)
	{
		m_PreviousPosition = e.Point;
		OnMove(e);
		OnMoveExt(e);
	}

	private bool HasMoved(Point actualPoint)
	{
		return m_PreviousPosition != actualPoint;
	}

	protected virtual void OnMove(MouseEventArgs e)
	{
		this.MouseMove?.Invoke(this, e);
	}

	protected virtual void OnMoveExt(MouseEventExtArgs e)
	{
		this.MouseMoveExt?.Invoke(this, e);
	}

	protected virtual void OnClick(MouseEventArgs e)
	{
		this.MouseClick?.Invoke(this, e);
	}

	protected virtual void OnDown(MouseEventArgs e)
	{
		this.MouseDown?.Invoke(this, e);
	}

	protected virtual void OnDownExt(MouseEventExtArgs e)
	{
		this.MouseDownExt?.Invoke(this, e);
	}

	protected virtual void OnUp(MouseEventArgs e)
	{
		this.MouseUp?.Invoke(this, e);
	}

	protected virtual void OnUpExt(MouseEventExtArgs e)
	{
		this.MouseUpExt?.Invoke(this, e);
	}

	protected virtual void OnWheel(MouseEventArgs e)
	{
		this.MouseWheel?.Invoke(this, e);
	}

	protected virtual void OnDoubleClick(MouseEventArgs e)
	{
		this.MouseDoubleClick?.Invoke(this, e);
	}
}
}