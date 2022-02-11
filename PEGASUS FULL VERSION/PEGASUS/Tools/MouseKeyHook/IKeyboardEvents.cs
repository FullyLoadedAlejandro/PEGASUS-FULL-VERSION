using System.Windows.Forms;

namespace PEGASUS.Tools.MouseKeyHook
	{
public interface IKeyboardEvents
{
	event KeyEventHandler KeyDown;

	event KeyPressEventHandler KeyPress;

	event KeyEventHandler KeyUp;
}
}