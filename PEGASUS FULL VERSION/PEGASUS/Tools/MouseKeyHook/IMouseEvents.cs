using System;
using System.Windows.Forms;

namespace PEGASUS.Tools.MouseKeyHook
	{
public interface IMouseEvents
{
	event MouseEventHandler MouseMove;

	event EventHandler<MouseEventExtArgs> MouseMoveExt;

	event MouseEventHandler MouseClick;

	event MouseEventHandler MouseDown;

	event EventHandler<MouseEventExtArgs> MouseDownExt;

	event MouseEventHandler MouseUp;

	event EventHandler<MouseEventExtArgs> MouseUpExt;

	event MouseEventHandler MouseWheel;

	event MouseEventHandler MouseDoubleClick;
}
}