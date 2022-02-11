using System;
using System.Drawing;

// Token: 0x02000015 RID: 21
internal class AnimateMsgBox
{
	// Token: 0x060000A6 RID: 166 RVA: 0x000027C0 File Offset: 0x000009C0
	public AnimateMsgBox(global::System.Drawing.Size formSize, global::MsgBox.AnimateStyle style)
	{
		this.FormSize = formSize;
		this.Style = style;
	}

	// Token: 0x0400007F RID: 127
	public global::System.Drawing.Size FormSize;

	// Token: 0x04000080 RID: 128
	public global::MsgBox.AnimateStyle Style;
}
