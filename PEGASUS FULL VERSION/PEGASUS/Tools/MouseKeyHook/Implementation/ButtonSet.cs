using System.Windows.Forms;

namespace PEGASUS.Tools.MouseKeyHook.Implementation
	{
internal class ButtonSet
{
	private MouseButtons m_Set;

	public ButtonSet()
	{
		m_Set = MouseButtons.None;
	}

	public void Add(MouseButtons element)
	{
		m_Set |= element;
	}

	public void Remove(MouseButtons element)
	{
		m_Set &= ~element;
	}

	public bool Contains(MouseButtons element)
	{
		return (m_Set & element) != 0;
	}
}
}