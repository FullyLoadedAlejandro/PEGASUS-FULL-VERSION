using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

// Token: 0x02000010 RID: 16
internal partial class InputDialog : Form
{
	// Token: 0x06000086 RID: 134 RVA: 0x0000B5F8 File Offset: 0x000097F8
	private InputDialog()
	{
		Panel panel = new Panel();
		panel.Dock = DockStyle.Fill;
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
		flowLayoutPanel.Dock = DockStyle.Fill;
		this.lblMessage = new Label();
		this.lblMessage.Font = new Font("Electrolize", 10f);
		this.lblMessage.ForeColor = Color.White;
		this.lblMessage.AutoSize = true;
		Panel panel2 = new Panel();
		panel2.BorderStyle = BorderStyle.None;
		panel2.Width = 360;
		panel2.Height = 28;
		panel2.Padding = new Padding(5);
		panel2.BackColor = Color.FromArgb(24, 24, 24);
		panel2.Margin = new Padding(0, 15, 0, 0);
		panel2.Paint += this.txtPl_Paint;
		this.txtInput = new TextBox();
		this.txtInput.Dock = DockStyle.Fill;
		this.txtInput.BorderStyle = BorderStyle.None;
		this.txtInput.Font = new Font("Electrolize", 9f);
		this.txtInput.KeyDown += this.txtInput_KeyDown;
		this.txtInput.BackColor = Color.FromArgb(30, 30, 30);
		this.txtInput.Multiline = true;
		this.txtInput.ForeColor = Color.White;
		panel2.Controls.Add(this.txtInput);
		FlowLayoutPanel flowLayoutPanel2 = new FlowLayoutPanel();
		flowLayoutPanel2.Dock = DockStyle.Bottom;
		flowLayoutPanel2.FlowDirection = FlowDirection.RightToLeft;
		flowLayoutPanel2.Height = 35;
		Button button = new Button();
		button.Text = "Cancel";
		button.ForeColor = Color.White;
		button.Font = new Font("Electrolize", 8f);
		button.Padding = new Padding(3);
		button.FlatStyle = FlatStyle.Flat;
		button.Height = 30;
		button.Click += this.btnCancel_Click;
		Button button2 = new Button();
		button2.Text = "OK";
		button2.ForeColor = Color.White;
		button2.Font = new Font("Electrolize", 8f);
		button2.Padding = new Padding(3);
		button2.FlatStyle = FlatStyle.Flat;
		button2.Height = 30;
		button2.Click += this.btnOK_Click;
		flowLayoutPanel2.Controls.Add(button);
		flowLayoutPanel2.Controls.Add(button2);
		flowLayoutPanel.Controls.Add(this.lblMessage);
		flowLayoutPanel.SetFlowBreak(this.lblMessage, true);
		flowLayoutPanel.Controls.Add(panel2);
		flowLayoutPanel.SetFlowBreak(panel2, true);
		flowLayoutPanel.Controls.Add(flowLayoutPanel2);
		panel.Controls.Add(flowLayoutPanel);
		base.Controls.Add(panel);
		base.Controls.Add(flowLayoutPanel2);
		base.FormBorderStyle = FormBorderStyle.None;
		this.BackColor = Color.FromArgb(24, 24, 24);
		base.StartPosition = FormStartPosition.CenterScreen;
		base.Padding = new Padding(20);
		base.Width = 400;
		base.Height = 200;
	}

	// Token: 0x06000087 RID: 135 RVA: 0x0000B904 File Offset: 0x00009B04
	private void txtInput_KeyDown(object sender, KeyEventArgs e)
	{
		TextBox textBox = (TextBox)sender;
		if (e.KeyCode == Keys.Return)
		{
			this._txtInput = textBox.Text;
			base.Dispose();
			return;
		}
		if (textBox.Text.Length > 60)
		{
			textBox.Parent.Height = 80;
			if (!this._txtPaintInvalidated)
			{
				textBox.Parent.Invalidate();
				this._txtPaintInvalidated = true;
			}
		}
		if (textBox.Text.Length < 60)
		{
			textBox.Parent.Height = 28;
			if (this._txtPaintInvalidated)
			{
				textBox.Parent.Invalidate();
				this._txtPaintInvalidated = false;
			}
		}
	}

	// Token: 0x06000088 RID: 136 RVA: 0x0000B9A4 File Offset: 0x00009BA4
	private void txtPl_Paint(object sender, PaintEventArgs e)
	{
		Panel panel = (Panel)sender;
		base.OnPaint(e);
		Graphics graphics = e.Graphics;
		Rectangle rect = new Rectangle(new Point(0, 0), new Size(panel.Width - 1, panel.Height - 1));
		Pen pen = new Pen(Color.FromArgb(198, 25, 31));
		pen.Width = 3f;
		graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, 30, 30)), rect);
		graphics.DrawRectangle(pen, rect);
	}

	// Token: 0x06000089 RID: 137 RVA: 0x0000271A File Offset: 0x0000091A
	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.Dispose();
	}

	// Token: 0x0600008A RID: 138 RVA: 0x00002722 File Offset: 0x00000922
	private void btnOK_Click(object sender, EventArgs e)
	{
		this._txtInput = this.txtInput.Text;
		base.Dispose();
	}

	// Token: 0x17000020 RID: 32
	// (get) Token: 0x0600008B RID: 139 RVA: 0x000026EA File Offset: 0x000008EA
	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams createParams = base.CreateParams;
			createParams.ClassStyle |= 131072;
			return createParams;
		}
	}

	// Token: 0x0600008C RID: 140 RVA: 0x0000273B File Offset: 0x0000093B
	public static string Show(string message)
	{
		InputDialog inputDialog = new InputDialog();
		inputDialog.lblMessage.Text = message;
		inputDialog.ShowDialog();
		return inputDialog._txtInput;
	}

	// Token: 0x0600008D RID: 141 RVA: 0x0000BA28 File Offset: 0x00009C28
	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		Graphics graphics = e.Graphics;
		Rectangle rect = new Rectangle(new Point(0, 0), new Size(base.Width - 1, base.Height - 1));
		Pen pen = new Pen(Color.FromArgb(198, 25, 31));
		graphics.DrawRectangle(pen, rect);
	}

	// Token: 0x0600008F RID: 143 RVA: 0x0000275A File Offset: 0x0000095A
	private void guna2PictureBox1_Click(object sender, EventArgs e)
	{
		base.Close();
	}

	// Token: 0x04000050 RID: 80
	private const int CS_DROPSHADOW = 131072;

	// Token: 0x04000051 RID: 81
	protected Label lblMessage;

	// Token: 0x04000052 RID: 82
	protected TextBox txtInput;

	// Token: 0x04000053 RID: 83
	protected string _txtInput;

	// Token: 0x0400005C RID: 92
	protected bool _txtPaintInvalidated;
}
