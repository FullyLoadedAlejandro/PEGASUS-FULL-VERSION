using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

// Token: 0x02000007 RID: 7
[global::System.ComponentModel.DefaultEvent("Scroll")]
internal class LoyalScrollBar : global::System.Windows.Forms.Control
{
	// Token: 0x14000001 RID: 1
	// (add) Token: 0x06000024 RID: 36 RVA: 0x00009538 File Offset: 0x00007738
	// (remove) Token: 0x06000025 RID: 37 RVA: 0x00009570 File Offset: 0x00007770


	// Token: 0x17000009 RID: 9
	// (get) Token: 0x06000026 RID: 38 RVA: 0x000022C4 File Offset: 0x000004C4
	// (set) Token: 0x06000027 RID: 39 RVA: 0x000022CC File Offset: 0x000004CC
	public int Minimum
	{
		get
		{
			return this._minimum;
		}
		set
		{
			if (value < 0)
			{
				throw new global::System.Exception("Property value is not valid.");
			}
			this._minimum = value;
			if (value > this._value)
			{
				this._value = value;
			}
			if (value > this._maximum)
			{
				this._maximum = value;
			}
			this.InvalidateLayout();
		}
	}

	// Token: 0x1700000A RID: 10
	// (get) Token: 0x06000028 RID: 40 RVA: 0x0000230A File Offset: 0x0000050A
	// (set) Token: 0x06000029 RID: 41 RVA: 0x00002312 File Offset: 0x00000512
	public int Maximum
	{
		get
		{
			return this._maximum;
		}
		set
		{
			if (value < 1)
			{
				value = 1;
			}
			this._maximum = value;
			if (value < this._value)
			{
				this._value = value;
			}
			if (value < this._minimum)
			{
				this._minimum = value;
			}
			this.InvalidateLayout();
		}
	}

	// Token: 0x1700000B RID: 11
	// (get) Token: 0x0600002A RID: 42 RVA: 0x00002348 File Offset: 0x00000548
	// (set) Token: 0x0600002B RID: 43 RVA: 0x000095A8 File Offset: 0x000077A8
	public int Value
	{
		get
		{
			if (!this._showThumb)
			{
				return this._minimum;
			}
			return this._value;
		}
		set
		{
			if (value == this._value)
			{
				return;
			}
			if (value > this._maximum || value < this._minimum)
			{
				throw new global::System.Exception("Property value is not valid.");
			}
			this._value = value;
			this.InvalidatePosition();

		}
	}

	// Token: 0x1700000C RID: 12
	// (get) Token: 0x0600002C RID: 44 RVA: 0x0000235F File Offset: 0x0000055F
	public double Percent
	{
		get
		{
			if (!this._showThumb)
			{
				return 0.0;
			}
			return this.GetProgress();
		}
	}

	// Token: 0x1700000D RID: 13
	// (get) Token: 0x0600002D RID: 45 RVA: 0x00002379 File Offset: 0x00000579
	// (set) Token: 0x0600002E RID: 46 RVA: 0x00002381 File Offset: 0x00000581
	public int SmallChange
	{
		get
		{
			return this._smallChange;
		}
		set
		{
			if (value < 1)
			{
				throw new global::System.Exception("Property value is not valid.");
			}
			this._smallChange = value;
		}
	}

	// Token: 0x1700000E RID: 14
	// (get) Token: 0x0600002F RID: 47 RVA: 0x00002399 File Offset: 0x00000599
	// (set) Token: 0x06000030 RID: 48 RVA: 0x000023A1 File Offset: 0x000005A1
	public int LargeChange
	{
		get
		{
			return this._largeChange;
		}
		set
		{
			if (value < 1)
			{
				throw new global::System.Exception("Property value is not valid.");
			}
			this._largeChange = value;
		}
	}

	// Token: 0x1700000F RID: 15
	// (get) Token: 0x06000031 RID: 49 RVA: 0x000023B9 File Offset: 0x000005B9
	// (set) Token: 0x06000032 RID: 50 RVA: 0x000023C1 File Offset: 0x000005C1
	[global::System.ComponentModel.Category("Colors")]
	public override global::System.Drawing.Color BackColor
	{
		get
		{
			return this._backColor;
		}
		set
		{
			this._backColor = value;
			base.Invalidate();
		}
	}

	// Token: 0x17000010 RID: 16
	// (get) Token: 0x06000033 RID: 51 RVA: 0x000023D0 File Offset: 0x000005D0
	// (set) Token: 0x06000034 RID: 52 RVA: 0x000023D8 File Offset: 0x000005D8
	[global::System.ComponentModel.Category("Colors")]
	public global::System.Drawing.Color ArrowColor
	{
		get
		{
			return this._arrowColor;
		}
		set
		{
			this._arrowColor = value;
			base.Invalidate();
		}
	}

	// Token: 0x17000011 RID: 17
	// (get) Token: 0x06000035 RID: 53 RVA: 0x000023E7 File Offset: 0x000005E7
	// (set) Token: 0x06000036 RID: 54 RVA: 0x000023EF File Offset: 0x000005EF
	[global::System.ComponentModel.Category("Colors")]
	public global::System.Drawing.Color ScrollColor
	{
		get
		{
			return this._scrollColor;
		}
		set
		{
			this._scrollColor = value;
			base.Invalidate();
		}
	}

	// Token: 0x17000012 RID: 18
	// (get) Token: 0x06000037 RID: 55 RVA: 0x000023FE File Offset: 0x000005FE
	// (set) Token: 0x06000038 RID: 56 RVA: 0x00002406 File Offset: 0x00000606
	[global::System.ComponentModel.Category("Colors")]
	public global::System.Drawing.Color BorderColor
	{
		get
		{
			return this._borderColor;
		}
		set
		{
			this._borderColor = value;
			base.Invalidate();
		}
	}

	// Token: 0x06000039 RID: 57 RVA: 0x00009600 File Offset: 0x00007800
	private void InvalidateLayout()
	{
		this.TSA = new global::System.Drawing.Rectangle(0, 0, base.Width, this.buttonSize);
		this.BSA = new global::System.Drawing.Rectangle(0, base.Height - this.buttonSize, base.Width, this.buttonSize);
		this.Shaft = new global::System.Drawing.Rectangle(0, this.TSA.Bottom + 1, base.Width, base.Height - this.buttonSize * 2 - 1);
		this._showThumb = (this._maximum - this._minimum > this.Shaft.Height);
		if (this._showThumb)
		{
			this.Thumb = new global::System.Drawing.Rectangle(1, 0, base.Width - 3, this.thumbSize);
		}

		this.InvalidatePosition();
	}

	// Token: 0x0600003A RID: 58 RVA: 0x00002415 File Offset: 0x00000615
	private void InvalidatePosition()
	{
		this.Thumb.Y = global::System.Convert.ToInt32(this.GetProgress() * (double)(this.Shaft.Height - this.thumbSize)) + this.TSA.Height;
		base.Invalidate();
	}

	// Token: 0x0600003B RID: 59 RVA: 0x00002453 File Offset: 0x00000653
	private double GetProgress()
	{
		return (double)(this._value - this._minimum) / (double)(this._maximum - this._minimum);
	}

	// Token: 0x0600003C RID: 60 RVA: 0x000096D8 File Offset: 0x000078D8
	private global::System.Drawing.Drawing2D.GraphicsPath DrawArrow(int x, int y, bool flip)
	{
		global::System.Drawing.Drawing2D.GraphicsPath graphicsPath = new global::System.Drawing.Drawing2D.GraphicsPath();
		int num = 9;
		int num2 = 5;
		if (flip)
		{
			graphicsPath.AddLine(x + 1, y, x + num + 1, y);
			graphicsPath.AddLine(x + num, y, x + num2, y + num2 - 1);
		}
		else
		{
			graphicsPath.AddLine(x, y + num2, x + num, y + num2);
			graphicsPath.AddLine(x + num, y + num2, x + num2, y);
		}
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	// Token: 0x0600003D RID: 61 RVA: 0x00002472 File Offset: 0x00000672
	protected override void OnSizeChanged(global::System.EventArgs e)
	{
		this.InvalidateLayout();
	}

	// Token: 0x0600003E RID: 62 RVA: 0x00009740 File Offset: 0x00007940
	protected override void OnMouseDown(global::System.Windows.Forms.MouseEventArgs e)
	{
		if (e.Button == global::System.Windows.Forms.MouseButtons.Left && this._showThumb)
		{
			if (this.TSA.Contains(e.Location))
			{
				this.I1 = this._value - this._smallChange;
			}
			else if (this.BSA.Contains(e.Location))
			{
				this.I1 = this._value + this._smallChange;
			}
			else
			{
				if (this.Thumb.Contains(e.Location))
				{
					this._thumbDown = true;
					base.OnMouseDown(e);
					return;
				}
				if (e.Y < this.Thumb.Y)
				{
					this.I1 = this._value - this._largeChange;
				}
				else
				{
					this.I1 = this._value + this._largeChange;
				}
			}
			this._value = global::System.Math.Min(global::System.Math.Max(this.I1, this._minimum), this._maximum);
			this.InvalidatePosition();
		}
		base.OnMouseDown(e);
	}

	// Token: 0x0600003F RID: 63 RVA: 0x00009848 File Offset: 0x00007A48
	protected override void OnMouseMove(global::System.Windows.Forms.MouseEventArgs e)
	{
		if (this._thumbDown && this._showThumb)
		{
			int num = e.Y - this.TSA.Height - this.thumbSize / 2;
			int num2 = this.Shaft.Height - this.thumbSize;
			this.I1 = global::System.Convert.ToInt32((double)num / (double)num2 * (double)(this._maximum - this._minimum)) + this._minimum;
			this._value = global::System.Math.Min(global::System.Math.Max(this.I1, this._minimum), this._maximum);
			this.InvalidatePosition();
		}
		base.OnMouseMove(e);
	}

	// Token: 0x06000040 RID: 64 RVA: 0x0000247A File Offset: 0x0000067A
	protected override void OnMouseUp(global::System.Windows.Forms.MouseEventArgs e)
	{
		this._thumbDown = false;
		base.OnMouseUp(e);
	}

	// Token: 0x06000041 RID: 65 RVA: 0x000098EC File Offset: 0x00007AEC
	public LoyalScrollBar()
	{
		base.SetStyle(global::System.Windows.Forms.ControlStyles.Selectable, false);
		base.SetStyle(global::System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, true);
		base.Width = 19;
	}

	// Token: 0x06000042 RID: 66 RVA: 0x0000998C File Offset: 0x00007B8C
	protected override void OnPaint(global::System.Windows.Forms.PaintEventArgs e)
	{
		base.OnPaint(e);
		global::System.Drawing.Graphics graphics = e.Graphics;
		graphics.Clear(this._backColor);
		global::System.Drawing.Drawing2D.GraphicsPath path = this.DrawArrow(4, 6, false);
		global::System.Drawing.Drawing2D.GraphicsPath path2 = this.DrawArrow(4, base.Height - 10, true);
		graphics.FillPath(new global::System.Drawing.SolidBrush(this._arrowColor), path);
		graphics.FillPath(new global::System.Drawing.SolidBrush(this._arrowColor), path2);
		if (this._showThumb)
		{
			graphics.FillRectangle(new global::System.Drawing.SolidBrush(this._scrollColor), this.Thumb);
			graphics.DrawRectangle(new global::System.Drawing.Pen(this._borderColor), this.Thumb);
			int num = this.Thumb.Y + this.Thumb.Height / 2 - 3;
			for (int i = 0; i < 3; i++)
			{
				int num2 = num + i * 3;
				graphics.DrawLine(new global::System.Drawing.Pen(this._borderColor), this.Thumb.X + 5, num2, this.Thumb.Right - 5, num2);
			}
		}
		graphics.DrawRectangle(new global::System.Drawing.Pen(this._borderColor), 0, 0, base.Width - 1, base.Height - 1);
		graphics.FillRectangle(new global::System.Drawing.SolidBrush(base.Parent.BackColor), base.Width - 1, base.Height - 1, 1, 1);
		graphics.FillRectangle(new global::System.Drawing.SolidBrush(base.Parent.BackColor), base.Width - 1, 0, 1, 1);
	}

	// Token: 0x0400000A RID: 10
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::LoyalScrollBar.ScrollEventHandler Scroll;

	// Token: 0x0400000B RID: 11
	private int buttonSize = 16;

	// Token: 0x0400000C RID: 12
	private int thumbSize = 24;

	// Token: 0x0400000D RID: 13
	private global::System.Drawing.Rectangle TSA;

	// Token: 0x0400000E RID: 14
	private global::System.Drawing.Rectangle BSA;

	// Token: 0x0400000F RID: 15
	private global::System.Drawing.Rectangle Shaft;

	// Token: 0x04000010 RID: 16
	private global::System.Drawing.Rectangle Thumb;

	// Token: 0x04000011 RID: 17
	private bool _showThumb;

	// Token: 0x04000012 RID: 18
	private bool _thumbDown;

	// Token: 0x04000013 RID: 19
	private int I1;

	// Token: 0x04000014 RID: 20
	private int _minimum;

	// Token: 0x04000015 RID: 21
	private int _maximum = 100;

	// Token: 0x04000016 RID: 22
	private int _value;

	// Token: 0x04000017 RID: 23
	private int _smallChange = 1;

	// Token: 0x04000018 RID: 24
	private int _largeChange = 10;

	// Token: 0x04000019 RID: 25
	private global::System.Drawing.Color _backColor = global::System.Drawing.Color.FromArgb(31, 31, 31);

	// Token: 0x0400001A RID: 26
	private global::System.Drawing.Color _arrowColor = global::System.Drawing.Color.FromArgb(51, 51, 51);

	// Token: 0x0400001B RID: 27
	private global::System.Drawing.Color _scrollColor = global::System.Drawing.Color.FromArgb(41, 41, 41);

	// Token: 0x0400001C RID: 28
	private global::System.Drawing.Color _borderColor = global::System.Drawing.Color.FromArgb(18, 18, 18);

	// Token: 0x02000008 RID: 8
	// (Invoke) Token: 0x06000044 RID: 68
	public delegate void ScrollEventHandler(object sender);
}
