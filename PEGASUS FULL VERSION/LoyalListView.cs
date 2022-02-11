using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x02000009 RID: 9
internal class LoyalListView : global::System.Windows.Forms.Control
{
	// Token: 0x17000013 RID: 19
	// (get) Token: 0x06000047 RID: 71 RVA: 0x0000248A File Offset: 0x0000068A
	// (set) Token: 0x06000048 RID: 72 RVA: 0x00002497 File Offset: 0x00000697
	[global::System.ComponentModel.Category("Content")]
	[global::System.ComponentModel.DesignerSerializationVisibility(global::System.ComponentModel.DesignerSerializationVisibility.Content)]
	public global::LoyalListViewItem[] Items
	{
		get
		{
			return this._items.ToArray();
		}
		set
		{
			this._items = new global::System.Collections.Generic.List<global::LoyalListViewItem>(value);
			this.InvalidateScroll();
		}
	}

	// Token: 0x17000014 RID: 20
	// (get) Token: 0x06000049 RID: 73 RVA: 0x000024AB File Offset: 0x000006AB
	[global::System.ComponentModel.Category("Content")]
	public global::LoyalListViewItem[] SelectedItems
	{
		get
		{
			return this._selectedItems.ToArray();
		}
	}

	// Token: 0x17000015 RID: 21
	// (get) Token: 0x0600004A RID: 74 RVA: 0x000024B8 File Offset: 0x000006B8
	// (set) Token: 0x0600004B RID: 75 RVA: 0x000024C5 File Offset: 0x000006C5
	[global::System.ComponentModel.Category("Content")]
	[global::System.ComponentModel.DesignerSerializationVisibility(global::System.ComponentModel.DesignerSerializationVisibility.Content)]
	public global::LoyalListViewColumnHeader[] Columns
	{
		get
		{
			return this._columns.ToArray();
		}
		set
		{
			this._columns = new global::System.Collections.Generic.List<global::LoyalListViewColumnHeader>(value);
			this.InvalidateColumns();
		}
	}

	// Token: 0x17000016 RID: 22
	// (get) Token: 0x0600004C RID: 76 RVA: 0x000024D9 File Offset: 0x000006D9
	// (set) Token: 0x0600004D RID: 77 RVA: 0x000024E1 File Offset: 0x000006E1
	public bool Multiselect
	{
		get
		{
			return this._multiSelect;
		}
		set
		{
			this._multiSelect = value;
			if (this._selectedItems.Count > 1)
			{
				this._selectedItems.RemoveRange(1, this._selectedItems.Count);
			}
			base.Invalidate();
		}
	}

	// Token: 0x17000017 RID: 23
	// (get) Token: 0x0600004E RID: 78 RVA: 0x00002515 File Offset: 0x00000715
	// (set) Token: 0x0600004F RID: 79 RVA: 0x00009AFC File Offset: 0x00007CFC
	public override global::System.Drawing.Font Font
	{
		get
		{
			return base.Font;
		}
		set
		{
			this._itemHeight = global::System.Convert.ToInt32(global::System.Drawing.Graphics.FromHwnd(base.Handle).MeasureString("@", this.Font).Height) + 6;
			if (this._VS != null)
			{
				this._VS.SmallChange = this._itemHeight;
				this._VS.LargeChange = this._itemHeight;
			}
			base.Font = value;
			this.InvalidateLayout();
		}
	}

	// Token: 0x17000018 RID: 24
	// (get) Token: 0x06000050 RID: 80 RVA: 0x0000251D File Offset: 0x0000071D
	// (set) Token: 0x06000051 RID: 81 RVA: 0x00002525 File Offset: 0x00000725
	[global::System.ComponentModel.Category("Colors")]
	public global::System.Drawing.Color HeaderColor
	{
		get
		{
			return this._headerColor;
		}
		set
		{
			this._headerColor = value;
			this._VS.ScrollColor = this._headerColor;
			this._VS.ArrowColor = this._headerColor;
			base.Invalidate();
		}
	}

	// Token: 0x17000019 RID: 25
	// (get) Token: 0x06000052 RID: 82 RVA: 0x00002556 File Offset: 0x00000756
	// (set) Token: 0x06000053 RID: 83 RVA: 0x0000255E File Offset: 0x0000075E
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

	// Token: 0x1700001A RID: 26
	// (get) Token: 0x06000054 RID: 84 RVA: 0x0000256D File Offset: 0x0000076D
	// (set) Token: 0x06000055 RID: 85 RVA: 0x00002575 File Offset: 0x00000775
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
			this._VS.BorderColor = this._borderColor;
			base.Invalidate();
		}
	}

	// Token: 0x1700001B RID: 27
	// (get) Token: 0x06000056 RID: 86 RVA: 0x00002595 File Offset: 0x00000795
	// (set) Token: 0x06000057 RID: 87 RVA: 0x0000259D File Offset: 0x0000079D
	[global::System.ComponentModel.Category("Colors")]
	public global::System.Drawing.Color ItemColor
	{
		get
		{
			return this._itemColor;
		}
		set
		{
			this._itemColor = value;
			base.Invalidate();
		}
	}

	// Token: 0x1700001C RID: 28
	// (get) Token: 0x06000058 RID: 88 RVA: 0x000025AC File Offset: 0x000007AC
	// (set) Token: 0x06000059 RID: 89 RVA: 0x000025B4 File Offset: 0x000007B4
	[global::System.ComponentModel.Category("Colors")]
	public global::System.Drawing.Color SelectedItemColor
	{
		get
		{
			return this._selectedItemColor;
		}
		set
		{
			this._selectedItemColor = value;
			base.Invalidate();
		}
	}

	// Token: 0x1700001D RID: 29
	// (get) Token: 0x0600005A RID: 90 RVA: 0x000025C3 File Offset: 0x000007C3
	// (set) Token: 0x0600005B RID: 91 RVA: 0x000025CB File Offset: 0x000007CB
	[global::System.ComponentModel.Category("Colors")]
	public global::System.Drawing.Color ScrollBarBackColor
	{
		get
		{
			return this._scrollBarBackColor;
		}
		set
		{
			this._scrollBarBackColor = value;
			this._VS.BackColor = this._scrollBarBackColor;
			base.Invalidate();
		}
	}

	// Token: 0x1700001E RID: 30
	// (get) Token: 0x0600005C RID: 92 RVA: 0x000025EB File Offset: 0x000007EB
	// (set) Token: 0x0600005D RID: 93 RVA: 0x000025F3 File Offset: 0x000007F3
	[global::System.ComponentModel.Category("Colors")]
	public override global::System.Drawing.Color ForeColor
	{
		get
		{
			return this._foreColor;
		}
		set
		{
			this._foreColor = value;
			base.Invalidate();
		}
	}

	// Token: 0x0600005E RID: 94 RVA: 0x00002602 File Offset: 0x00000802
	private void InvalidateScroll()
	{
		this._VS.Maximum = this._items.Count * 24;
		base.Invalidate();
	}

	// Token: 0x0600005F RID: 95 RVA: 0x00009B70 File Offset: 0x00007D70
	private void InvalidateColumns()
	{
		int num = 3;
		this._columnOffsets = new int[this._columns.Count];
		for (int i = 0; i < this._columns.Count; i++)
		{
			this._columnOffsets[i] = num;
			num += this.Columns[i].Width;
		}
		base.Invalidate();
	}

	// Token: 0x06000060 RID: 96 RVA: 0x00009BCC File Offset: 0x00007DCC
	private void InvalidateLayout()
	{
		this._VS.Location = new global::System.Drawing.Point(base.Width - this._VS.Width, 0);
		this._VS.Size = new global::System.Drawing.Size(19, base.Height);
		this.InvalidateScroll();
	}

	// Token: 0x06000061 RID: 97 RVA: 0x00002623 File Offset: 0x00000823
	private void HandleScroll(object sender)
	{
		base.Invalidate();
	}

	// Token: 0x06000062 RID: 98 RVA: 0x00009C1C File Offset: 0x00007E1C
	public LoyalListView()
	{
		base.SetStyle(global::System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, true);
		this._VS = new global::LoyalScrollBar();
		this._VS.LargeChange = this._itemHeight;
		this._VS.SmallChange = this._itemHeight;
		//this._VS.Scroll += this.HandleScroll;
		this._VS.MouseDown += this._VS_MouseDown;
		this._VS.MouseMove += this._VS_MouseMove;
		this._VS.MouseUp += this._VS_MouseUp;
		this._VS.ScrollColor = this._headerColor;
		this._VS.BorderColor = this._borderColor;
		this._VS.ArrowColor = this._headerColor;
		this._VS.BackColor = this._scrollBarBackColor;
		base.Size = new global::System.Drawing.Size(150, 75);
		this.Font = new global::System.Drawing.Font("Segoe UI", 8.25f);
		base.Controls.Add(this._VS);
		this.InvalidateLayout();
	}

	// Token: 0x06000063 RID: 99 RVA: 0x0000262B File Offset: 0x0000082B
	private void _VS_MouseUp(object sender, global::System.Windows.Forms.MouseEventArgs e)
	{
		this._down = false;
	}

	// Token: 0x06000064 RID: 100 RVA: 0x00002634 File Offset: 0x00000834
	private void _VS_MouseMove(object sender, global::System.Windows.Forms.MouseEventArgs e)
	{
		if (this._down)
		{
			base.Invalidate();
		}
	}

	// Token: 0x06000065 RID: 101 RVA: 0x00002644 File Offset: 0x00000844
	private void _VS_MouseDown(object sender, global::System.Windows.Forms.MouseEventArgs e)
	{
		this._down = true;
		base.Focus();
	}

	// Token: 0x06000066 RID: 102 RVA: 0x00009DEC File Offset: 0x00007FEC
	protected override void OnMouseWheel(global::System.Windows.Forms.MouseEventArgs e)
	{
		int num = -(e.Delta * global::System.Windows.Forms.SystemInformation.MouseWheelScrollLines / 120 * 12);
		int value = global::System.Math.Max(global::System.Math.Min(this._VS.Value + num, this._VS.Maximum), this._VS.Minimum);
		this._VS.Value = value;
		base.OnMouseWheel(e);
	}

	// Token: 0x06000067 RID: 103 RVA: 0x00009E50 File Offset: 0x00008050
	protected override void OnMouseDown(global::System.Windows.Forms.MouseEventArgs e)
	{
		base.Focus();
		if (e.Button == global::System.Windows.Forms.MouseButtons.Left)
		{
			int num = global::System.Convert.ToInt32(this._VS.Percent * (double)(this._VS.Maximum - (base.Height - 48)));
			int num2 = (e.Y + num - 24) / 24;
			if (num2 > this._items.Count - 1)
			{
				num2 = -1;
			}
			if (num2 > -1)
			{
				if (global::System.Windows.Forms.Control.ModifierKeys == global::System.Windows.Forms.Keys.Control && this._multiSelect)
				{
					if (this._selectedItems.Contains(this._items[num2]))
					{
						this._selectedItems.Remove(this._items[num2]);
					}
					else
					{
						this._selectedItems.Add(this._items[num2]);
					}
				}
				else
				{
					this._selectedItems.Clear();
					this._selectedItems.Add(this._items[num2]);
				}
			}
			base.Invalidate();
		}
		base.OnMouseDown(e);
	}

	// Token: 0x06000068 RID: 104 RVA: 0x00002654 File Offset: 0x00000854
	protected override void OnSizeChanged(global::System.EventArgs e)
	{
		this.InvalidateLayout();
		base.OnSizeChanged(e);
	}

	// Token: 0x06000069 RID: 105 RVA: 0x00009F54 File Offset: 0x00008154
	public void AddItem(string text, string[] subitems)
	{
		global::System.Collections.Generic.List<global::LoyalListViewSubItem> list = new global::System.Collections.Generic.List<global::LoyalListViewSubItem>();
		for (int i = 0; i < subitems.Length; i++)
		{
			global::LoyalListViewSubItem item = new global::LoyalListViewSubItem(subitems[i]);
			list.Add(item);
		}
		global::LoyalListViewItem item2 = new global::LoyalListViewItem(text, list);
		this._items.Add(item2);
		this.InvalidateScroll();
	}

	// Token: 0x0600006A RID: 106 RVA: 0x00002663 File Offset: 0x00000863
	public void RemoveItemAt(int index)
	{
		this._items.RemoveAt(index);
		this.InvalidateScroll();
	}

	// Token: 0x0600006B RID: 107 RVA: 0x00002677 File Offset: 0x00000877
	public void RemoveItem(global::LoyalListViewItem lvi)
	{
		this._items.Remove(lvi);
		this.InvalidateScroll();
	}

	// Token: 0x0600006C RID: 108 RVA: 0x00009FA4 File Offset: 0x000081A4
	public void RemoveItems(global::LoyalListViewItem[] lvis)
	{
		foreach (global::LoyalListViewItem item in lvis)
		{
			this._items.Remove(item);
		}
		this.InvalidateScroll();
	}

	// Token: 0x0600006D RID: 109 RVA: 0x00009FD8 File Offset: 0x000081D8
	protected override void OnPaint(global::System.Windows.Forms.PaintEventArgs e)
	{
		base.OnPaint(e);
		global::System.Drawing.Graphics graphics = e.Graphics;
		graphics.Clear(this._backColor);
		int num = global::System.Convert.ToInt32(this._VS.Percent * (double)(this._VS.Maximum - (base.Height - this._itemHeight * 2)));
		int num2;
		if (num == 0)
		{
			num2 = 0;
		}
		else
		{
			num2 = num / this._itemHeight;
		}
		int num3 = global::System.Math.Min(num2 + base.Height / this._itemHeight, this._items.Count);
		for (int i = num2; i < num3; i++)
		{
			global::LoyalListViewItem loyalListViewItem = this._items[i];
			global::System.Drawing.Rectangle rectangle = new global::System.Drawing.Rectangle(0, 24 + i * 24 - num, base.Width, 24);
			int num4 = global::System.Convert.ToInt32(graphics.MeasureString(loyalListViewItem.Text, this.Font).Height);
			int num5 = rectangle.Y + global::System.Convert.ToInt32(12 - num4 / 2);
			if (this._selectedItems.Contains(loyalListViewItem))
			{
				graphics.FillRectangle(new global::System.Drawing.SolidBrush(this._selectedItemColor), rectangle);
			}
			else
			{
				graphics.FillRectangle(new global::System.Drawing.SolidBrush(this._itemColor), rectangle);
			}
			graphics.DrawRectangle(new global::System.Drawing.Pen(this._borderColor), rectangle);
			if (this._columns.Count > 0)
			{
				rectangle.Width = this._columns[0].Width;
				graphics.SetClip(rectangle);
			}
			graphics.DrawString(loyalListViewItem.Text, this.Font, new global::System.Drawing.SolidBrush(this._foreColor), 4f, (float)(num5 + 1));
			if (loyalListViewItem.SubItems.Count > 0)
			{
				for (int j = 0; j < global::System.Math.Min(loyalListViewItem.SubItems.Count, this._columns.Count); j++)
				{
					int num6 = this._columnOffsets[j + 1];
					rectangle.X = num6;
					rectangle.Width = this._columns[j].Width;
					graphics.SetClip(rectangle);
					graphics.DrawString(loyalListViewItem.SubItems[j].Text, this.Font, new global::System.Drawing.SolidBrush(this._foreColor), (float)(num6 + 1), (float)(num5 + 1));
				}
			}
			graphics.ResetClip();
		}
		global::System.Drawing.Rectangle rect = new global::System.Drawing.Rectangle(0, 0, base.Width, 24);
		graphics.FillRectangle(new global::System.Drawing.SolidBrush(this._headerColor), rect);
		int y = global::System.Math.Min(this._VS.Maximum + this._itemHeight - num + 2, base.Height);
		for (int k = 0; k < this._columns.Count; k++)
		{
			global::LoyalListViewColumnHeader loyalListViewColumnHeader = this._columns[k];
			int num7 = global::System.Convert.ToInt32(graphics.MeasureString(loyalListViewColumnHeader.Text, this.Font).Height);
			int num8 = global::System.Convert.ToInt32(12 - num7 / 2);
			int num9 = this._columnOffsets[k];
			graphics.DrawString(loyalListViewColumnHeader.Text, new global::System.Drawing.Font(this.Font.FontFamily, this.Font.Size, global::System.Drawing.FontStyle.Bold), new global::System.Drawing.SolidBrush(this._foreColor), (float)(num9 + 1), (float)(num8 + 1));
			graphics.DrawLine(new global::System.Drawing.Pen(this._borderColor), num9 - 3, 0, num9 - 3, y);
		}
		graphics.DrawRectangle(new global::System.Drawing.Pen(this._borderColor), 0, 0, base.Width - 1, base.Height - 1);
		graphics.DrawLine(new global::System.Drawing.Pen(global::System.Drawing.Color.FromArgb(30, global::System.Drawing.Color.White)), 0, 1, base.Width, 1);
		graphics.DrawLine(new global::System.Drawing.Pen(global::System.Drawing.Color.FromArgb(70, global::System.Drawing.Color.Black)), 0, 23, base.Width, 23);
		graphics.DrawLine(new global::System.Drawing.Pen(this._borderColor), 0, 24, base.Width, 24);
		graphics.FillRectangle(new global::System.Drawing.SolidBrush(this._backColor), base.Width - 19, 0, base.Width, base.Height);
		graphics.FillRectangle(new global::System.Drawing.SolidBrush(base.Parent.BackColor), 0, 0, 1, 1);
		graphics.FillRectangle(new global::System.Drawing.SolidBrush(base.Parent.BackColor), 0, base.Height - 1, 1, 1);
	}

	// Token: 0x0400001D RID: 29
	private int[] _columnOffsets;

	// Token: 0x0400001E RID: 30
	private global::LoyalScrollBar _VS;

	// Token: 0x0400001F RID: 31
	private bool _down;

	// Token: 0x04000020 RID: 32
	private int _itemHeight = 24;

	// Token: 0x04000021 RID: 33
	private global::System.Collections.Generic.List<global::LoyalListViewItem> _items = new global::System.Collections.Generic.List<global::LoyalListViewItem>();

	// Token: 0x04000022 RID: 34
	private global::System.Collections.Generic.List<global::LoyalListViewItem> _selectedItems = new global::System.Collections.Generic.List<global::LoyalListViewItem>();

	// Token: 0x04000023 RID: 35
	private global::System.Collections.Generic.List<global::LoyalListViewColumnHeader> _columns = new global::System.Collections.Generic.List<global::LoyalListViewColumnHeader>();

	// Token: 0x04000024 RID: 36
	private bool _multiSelect = true;

	// Token: 0x04000025 RID: 37
	private global::System.Drawing.Color _headerColor = global::System.Drawing.Color.FromArgb(102, 51, 153);

	// Token: 0x04000026 RID: 38
	private global::System.Drawing.Color _backColor = global::System.Drawing.Color.FromArgb(40, 40, 40);

	// Token: 0x04000027 RID: 39
	private global::System.Drawing.Color _borderColor = global::System.Drawing.Color.FromArgb(18, 18, 18);

	// Token: 0x04000028 RID: 40
	private global::System.Drawing.Color _itemColor = global::System.Drawing.Color.FromArgb(50, 50, 50);

	// Token: 0x04000029 RID: 41
	private global::System.Drawing.Color _selectedItemColor = global::System.Drawing.Color.FromArgb(65, 65, 65);

	// Token: 0x0400002A RID: 42
	private global::System.Drawing.Color _scrollBarBackColor = global::System.Drawing.Color.FromArgb(31, 31, 31);

	// Token: 0x0400002B RID: 43
	private global::System.Drawing.Color _foreColor = global::System.Drawing.Color.White;
}
