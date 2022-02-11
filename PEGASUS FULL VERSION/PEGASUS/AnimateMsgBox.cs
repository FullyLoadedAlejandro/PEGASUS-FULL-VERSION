using System.Drawing;

namespace PEGASUS
{ 

internal class AnimateMsgBox
{
	public Size FormSize;

	public MsgBox.AnimateStyle Style;

	public AnimateMsgBox(Size formSize, MsgBox.AnimateStyle style)
	{
		FormSize = formSize;
		Style = style;
	}
}
}