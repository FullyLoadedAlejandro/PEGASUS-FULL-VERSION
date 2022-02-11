using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

// Token: 0x02000011 RID: 17
public partial class MsgBox : Form
{
	// Token: 0x06000090 RID: 144
	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern bool MessageBeep(uint type);

	// Token: 0x06000091 RID: 145 RVA: 0x0000BF14 File Offset: 0x0000A114
	private MsgBox()
	{
		base.FormBorderStyle = FormBorderStyle.None;
		this.BackColor = Color.FromArgb(22, 22, 22);
		base.StartPosition = FormStartPosition.CenterScreen;
		base.Padding = new Padding(3);
		base.Width = 400;
		this._lblTitle = new Label();
		this._lblTitle.ForeColor = Color.White;
		this._lblTitle.Font = new Font("Electrolize", 18f);
		this._lblTitle.Dock = DockStyle.Top;
		this._lblTitle.Height = 50;
		this._lblMessage = new Label();
		this._lblMessage.ForeColor = Color.White;
		this._lblMessage.Font = new Font("Electrolize", 10f);
		this._lblMessage.Dock = DockStyle.Fill;
		this._flpButtons.FlowDirection = FlowDirection.RightToLeft;
		this._flpButtons.Dock = DockStyle.Fill;
		this._plHeader.Dock = DockStyle.Fill;
		this._plHeader.Padding = new Padding(20);
		this._plHeader.Controls.Add(this._lblMessage);
		this._plHeader.Controls.Add(this._lblTitle);
		this._plFooter.Dock = DockStyle.Bottom;
		this._plFooter.Padding = new Padding(20);
		this._plFooter.BackColor = Color.FromArgb(22, 22, 22);
		this._plFooter.Height = 80;
		this._plFooter.Controls.Add(this._flpButtons);
		this._picIcon.Width = 32;
		this._picIcon.Height = 32;
		this._picIcon.Location = new Point(30, 50);
		this._plIcon.Dock = DockStyle.Left;
		this._plIcon.Padding = new Padding(20);
		this._plIcon.Width = 70;
		this._plIcon.Controls.Add(this._picIcon);
		foreach (Control control in new List<Control>
		{
			this,
			this._lblTitle,
			this._lblMessage,
			this._flpButtons,
			this._plHeader,
			this._plFooter,
			this._plIcon,
			this._picIcon
		})
		{
			control.MouseDown += MsgBox.MsgBox_MouseDown;
			control.MouseMove += MsgBox.MsgBox_MouseMove;
		}
		base.Controls.Add(this._plHeader);
		base.Controls.Add(this._plIcon);
		base.Controls.Add(this._plFooter);
	}

	// Token: 0x06000092 RID: 146 RVA: 0x00002762 File Offset: 0x00000962
	private static void MsgBox_MouseDown(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			MsgBox.lastMousePos = new Point(e.X, e.Y);
		}
	}

	// Token: 0x06000093 RID: 147 RVA: 0x0000C244 File Offset: 0x0000A444
	private static void MsgBox_MouseMove(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			MsgBox._msgBox.Left += e.X - MsgBox.lastMousePos.X;
			MsgBox._msgBox.Top += e.Y - MsgBox.lastMousePos.Y;
		}
	}

	// Token: 0x06000094 RID: 148 RVA: 0x00002787 File Offset: 0x00000987
	public static DialogResult Show(string message)
	{
		MsgBox._msgBox = new MsgBox();
		MsgBox._msgBox._lblMessage.Text = message;
		MsgBox.InitButtons(MsgBox.Buttons.OK);
		MsgBox._msgBox.ShowDialog();
		MsgBox.MessageBeep(0U);
		return MsgBox._buttonResult;
	}

	// Token: 0x06000095 RID: 149 RVA: 0x0000C2A4 File Offset: 0x0000A4A4
	public static DialogResult Show(string message, string title)
	{
		MsgBox._msgBox = new MsgBox();
		MsgBox._msgBox._lblMessage.Text = message;
		MsgBox._msgBox._lblTitle.Text = title;
		MsgBox._msgBox.Size = MsgBox.MessageSize(message);
		MsgBox.InitButtons(MsgBox.Buttons.OK);
		MsgBox._msgBox.ShowDialog();
		MsgBox.MessageBeep(0U);
		return MsgBox._buttonResult;
	}

	// Token: 0x06000096 RID: 150 RVA: 0x0000C308 File Offset: 0x0000A508
	public static DialogResult Show(string message, string title, MsgBox.Buttons buttons)
	{
		MsgBox._msgBox = new MsgBox();
		MsgBox._msgBox._lblMessage.Text = message;
		MsgBox._msgBox._lblTitle.Text = title;
		MsgBox._msgBox._plIcon.Hide();
		MsgBox.InitButtons(buttons);
		MsgBox._msgBox.Size = MsgBox.MessageSize(message);
		MsgBox._msgBox.ShowDialog();
		MsgBox.MessageBeep(0U);
		return MsgBox._buttonResult;
	}

	// Token: 0x06000097 RID: 151 RVA: 0x0000C37C File Offset: 0x0000A57C
	public static DialogResult Show(string message, string title, MsgBox.Buttons buttons, MsgBox.Icon icon)
	{
		MsgBox._msgBox = new MsgBox();
		MsgBox._msgBox._lblMessage.Text = message;
		MsgBox._msgBox._lblTitle.Text = title;
		MsgBox.InitButtons(buttons);
		MsgBox.InitIcon(icon);
		MsgBox._msgBox.Size = MsgBox.MessageSize(message);
		MsgBox._msgBox.ShowDialog();
		MsgBox.MessageBeep(0U);
		return MsgBox._buttonResult;
	}

	// Token: 0x06000098 RID: 152 RVA: 0x0000C3E8 File Offset: 0x0000A5E8
	public static DialogResult Show(string message, string title, MsgBox.Buttons buttons, MsgBox.Icon icon, MsgBox.AnimateStyle style)
	{
		MsgBox._msgBox = new MsgBox();
		MsgBox._msgBox._lblMessage.Text = message;
		MsgBox._msgBox._lblTitle.Text = title;
		MsgBox._msgBox.Height = 0;
		MsgBox.InitButtons(buttons);
		MsgBox.InitIcon(icon);
		MsgBox._timer = new Timer();
		Size size = MsgBox.MessageSize(message);
		switch (style)
		{
		case MsgBox.AnimateStyle.SlideDown:
			MsgBox._msgBox.Size = new Size(size.Width, 0);
			MsgBox._timer.Interval = 1;
			MsgBox._timer.Tag = new AnimateMsgBox(size, style);
			break;
		case MsgBox.AnimateStyle.FadeIn:
			MsgBox._msgBox.Size = size;
			MsgBox._msgBox.Opacity = 0.0;
			MsgBox._timer.Interval = 20;
			MsgBox._timer.Tag = new AnimateMsgBox(size, style);
			break;
		case MsgBox.AnimateStyle.ZoomIn:
			MsgBox._msgBox.Size = new Size(size.Width + 100, size.Height + 100);
			MsgBox._timer.Tag = new AnimateMsgBox(size, style);
			MsgBox._timer.Interval = 1;
			break;
		}
		MsgBox._timer.Tick += MsgBox.timer_Tick;
		MsgBox._timer.Start();
		MsgBox._msgBox.ShowDialog();
		MsgBox.MessageBeep(0U);
		return MsgBox._buttonResult;
	}

	// Token: 0x06000099 RID: 153 RVA: 0x0000C54C File Offset: 0x0000A74C
	private static void timer_Tick(object sender, EventArgs e)
	{
		AnimateMsgBox animateMsgBox = (AnimateMsgBox)((Timer)sender).Tag;
		switch (animateMsgBox.Style)
		{
		case MsgBox.AnimateStyle.SlideDown:
			if (MsgBox._msgBox.Height < animateMsgBox.FormSize.Height)
			{
				MsgBox._msgBox.Height += 17;
				MsgBox._msgBox.Invalidate();
				return;
			}
			MsgBox._timer.Stop();
			MsgBox._timer.Dispose();
			return;
		case MsgBox.AnimateStyle.FadeIn:
			if (MsgBox._msgBox.Opacity < 1.0)
			{
				MsgBox._msgBox.Opacity += 0.1;
				MsgBox._msgBox.Invalidate();
				return;
			}
			MsgBox._timer.Stop();
			MsgBox._timer.Dispose();
			return;
		case MsgBox.AnimateStyle.ZoomIn:
			if (MsgBox._msgBox.Width > animateMsgBox.FormSize.Width)
			{
				MsgBox._msgBox.Width -= 17;
				MsgBox._msgBox.Invalidate();
			}
			if (MsgBox._msgBox.Height > animateMsgBox.FormSize.Height)
			{
				MsgBox._msgBox.Height -= 17;
				MsgBox._msgBox.Invalidate();
			}
			return;
		default:
			return;
		}
	}

	// Token: 0x0600009A RID: 154 RVA: 0x0000C688 File Offset: 0x0000A888
	private static void InitButtons(MsgBox.Buttons buttons)
	{
		switch (buttons)
		{
		case MsgBox.Buttons.AbortRetryIgnore:
			MsgBox._msgBox.InitAbortRetryIgnoreButtons();
			break;
		case MsgBox.Buttons.OK:
			MsgBox._msgBox.InitOKButton();
			break;
		case MsgBox.Buttons.OKCancel:
			MsgBox._msgBox.InitOKCancelButtons();
			break;
		case MsgBox.Buttons.RetryCancel:
			MsgBox._msgBox.InitRetryCancelButtons();
			break;
		case MsgBox.Buttons.YesNo:
			MsgBox._msgBox.InitYesNoButtons();
			break;
		case MsgBox.Buttons.YesNoCancel:
			MsgBox._msgBox.InitYesNoCancelButtons();
			break;
		}
		foreach (Button button in MsgBox._msgBox._buttonCollection)
		{
			button.ForeColor = Color.White;
			button.Font = new Font("Electrolize", 8f);
			button.Padding = new Padding(3);
			button.FlatStyle = FlatStyle.Flat;
			button.Height = 30;
			button.FlatAppearance.BorderColor = Color.FromArgb(191, 37, 33);
			MsgBox._msgBox._flpButtons.Controls.Add(button);
		}
	}

	// Token: 0x0600009B RID: 155 RVA: 0x0000C7AC File Offset: 0x0000A9AC
	private static void InitIcon(MsgBox.Icon icon)
	{
		switch (icon)
		{
		case MsgBox.Icon.Application:
			MsgBox._msgBox._picIcon.Image = SystemIcons.Application.ToBitmap();
			return;
		case MsgBox.Icon.Exclamation:
			MsgBox._msgBox._picIcon.Image = SystemIcons.Exclamation.ToBitmap();
			return;
		case MsgBox.Icon.Error:
			MsgBox._msgBox._picIcon.Image = SystemIcons.Error.ToBitmap();
			return;
		case MsgBox.Icon.Warning:
			MsgBox._msgBox._picIcon.Image = SystemIcons.Warning.ToBitmap();
			return;
		case MsgBox.Icon.Info:
			MsgBox._msgBox._picIcon.Image = SystemIcons.Information.ToBitmap();
			return;
		case MsgBox.Icon.Question:
			MsgBox._msgBox._picIcon.Image = SystemIcons.Question.ToBitmap();
			return;
		case MsgBox.Icon.Shield:
			MsgBox._msgBox._picIcon.Image = SystemIcons.Shield.ToBitmap();
			return;
		default:
			return;
		}
	}

	// Token: 0x0600009C RID: 156 RVA: 0x0000C894 File Offset: 0x0000AA94
	private void InitAbortRetryIgnoreButtons()
	{
		Button button = new Button();
		button.Text = "Abort";
		button.Click += MsgBox.ButtonClick;
		Button button2 = new Button();
		button2.Text = "Retry";
		button2.Click += MsgBox.ButtonClick;
		Button button3 = new Button();
		button3.Text = "Ignore";
		button3.Click += MsgBox.ButtonClick;
		this._buttonCollection.Add(button);
		this._buttonCollection.Add(button2);
		this._buttonCollection.Add(button3);
	}

	// Token: 0x0600009D RID: 157 RVA: 0x0000C930 File Offset: 0x0000AB30
	private void InitOKButton()
	{
		Button button = new Button();
		button.Text = "OK";
		button.Click += MsgBox.ButtonClick;
		this._buttonCollection.Add(button);
	}

	// Token: 0x0600009E RID: 158 RVA: 0x0000C96C File Offset: 0x0000AB6C
	private void InitOKCancelButtons()
	{
		Button button = new Button();
		button.Text = "OK";
		button.Click += MsgBox.ButtonClick;
		Button button2 = new Button();
		button2.Text = "Cancel";
		button2.Click += MsgBox.ButtonClick;
		this._buttonCollection.Add(button);
		this._buttonCollection.Add(button2);
	}

	// Token: 0x0600009F RID: 159 RVA: 0x0000C96C File Offset: 0x0000AB6C
	private void InitRetryCancelButtons()
	{
		Button button = new Button();
		button.Text = "OK";
		button.Click += MsgBox.ButtonClick;
		Button button2 = new Button();
		button2.Text = "Cancel";
		button2.Click += MsgBox.ButtonClick;
		this._buttonCollection.Add(button);
		this._buttonCollection.Add(button2);
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x0000C9D8 File Offset: 0x0000ABD8
	private void InitYesNoButtons()
	{
		Button button = new Button();
		button.Text = "Yes";
		button.Click += MsgBox.ButtonClick;
		Button button2 = new Button();
		button2.Text = "No";
		button2.Click += MsgBox.ButtonClick;
		this._buttonCollection.Add(button);
		this._buttonCollection.Add(button2);
	}

	// Token: 0x060000A1 RID: 161 RVA: 0x0000CA44 File Offset: 0x0000AC44
	private void InitYesNoCancelButtons()
	{
		Button button = new Button();
		button.Text = "Abort";
		button.Click += MsgBox.ButtonClick;
		Button button2 = new Button();
		button2.Text = "Retry";
		button2.Click += MsgBox.ButtonClick;
		Button button3 = new Button();
		button3.Text = "Cancel";
		button3.Click += MsgBox.ButtonClick;
		this._buttonCollection.Add(button);
		this._buttonCollection.Add(button2);
		this._buttonCollection.Add(button3);
	}

	// Token: 0x060000A2 RID: 162 RVA: 0x0000CAE0 File Offset: 0x0000ACE0
	private static void ButtonClick(object sender, EventArgs e)
	{
		string text = ((Button)sender).Text;
		uint num = PrivateImplementationDetails.ComputeStringHash(text);
		if (num <= 1642511898U)
		{
			if (num != 900713019U)
			{
				if (num != 1256668313U)
				{
					if (num == 1642511898U)
					{
						if (text == "No")
						{
							MsgBox._buttonResult = DialogResult.No;
						}
					}
				}
				else if (text == "Abort")
				{
					MsgBox._buttonResult = DialogResult.Abort;
				}
			}
			else if (text == "Cancel")
			{
				MsgBox._buttonResult = DialogResult.Cancel;
			}
		}
		else if (num <= 2246359087U)
		{
			if (num != 2151067481U)
			{
				if (num == 2246359087U)
				{
					if (text == "OK")
					{
						MsgBox._buttonResult = DialogResult.OK;
					}
				}
			}
			else if (text == "Retry")
			{
				MsgBox._buttonResult = DialogResult.Retry;
			}
		}
		else if (num != 3013883440U)
		{
			if (num == 3293848931U)
			{
				if (text == "Ignore")
				{
					MsgBox._buttonResult = DialogResult.Ignore;
				}
			}
		}
		else if (text == "Yes")
		{
			MsgBox._buttonResult = DialogResult.Yes;
		}
		MsgBox._msgBox.Dispose();
	}

	// Token: 0x060000A3 RID: 163 RVA: 0x0000CC0C File Offset: 0x0000AE0C
	private static Size MessageSize(string message)
	{
		Graphics graphics = MsgBox._msgBox.CreateGraphics();
		int width = 350;
		int height = 230;
		SizeF sizeF = graphics.MeasureString(message, new Font("Electrolize", 10f));
		if (message.Length < 150 && (int)sizeF.Width > 350)
		{
			width = (int)sizeF.Width;
		}
		return new Size(width, height);
	}

	// Token: 0x17000021 RID: 33
	// (get) Token: 0x060000A4 RID: 164 RVA: 0x000026EA File Offset: 0x000008EA
	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams createParams = base.CreateParams;
			createParams.ClassStyle |= 131072;
			return createParams;
		}
	}

	// Token: 0x060000A5 RID: 165 RVA: 0x0000B5A0 File Offset: 0x000097A0
	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		Graphics graphics = e.Graphics;
		Rectangle rect = new Rectangle(new Point(0, 0), new Size(base.Width - 1, base.Height - 1));
		Pen pen = new Pen(Color.FromArgb(191, 37, 33));
		graphics.DrawRectangle(pen, rect);
	}

	// Token: 0x0400005D RID: 93
	private const int CS_DROPSHADOW = 131072;

	// Token: 0x0400005E RID: 94
	private static MsgBox _msgBox;

	// Token: 0x0400005F RID: 95
	private Panel _plHeader = new Panel();

	// Token: 0x04000060 RID: 96
	private Panel _plFooter = new Panel();

	// Token: 0x04000061 RID: 97
	private Panel _plIcon = new Panel();

	// Token: 0x04000062 RID: 98
	private PictureBox _picIcon = new PictureBox();

	// Token: 0x04000063 RID: 99
	private FlowLayoutPanel _flpButtons = new FlowLayoutPanel();

	// Token: 0x04000064 RID: 100
	private Label _lblTitle;

	// Token: 0x04000065 RID: 101
	private Label _lblMessage;

	// Token: 0x04000066 RID: 102
	private List<Button> _buttonCollection = new List<Button>();

	// Token: 0x04000067 RID: 103
	private static DialogResult _buttonResult;

	// Token: 0x04000068 RID: 104
	private static Timer _timer;

	// Token: 0x04000069 RID: 105
	private static Point lastMousePos;

	// Token: 0x02000012 RID: 18
	public enum Buttons
	{
		// Token: 0x0400006B RID: 107
		AbortRetryIgnore = 1,
		// Token: 0x0400006C RID: 108
		OK,
		// Token: 0x0400006D RID: 109
		OKCancel,
		// Token: 0x0400006E RID: 110
		RetryCancel,
		// Token: 0x0400006F RID: 111
		YesNo,
		// Token: 0x04000070 RID: 112
		YesNoCancel
	}

	// Token: 0x02000013 RID: 19
	public new enum Icon
	{
		// Token: 0x04000072 RID: 114
		Application = 1,
		// Token: 0x04000073 RID: 115
		Exclamation,
		// Token: 0x04000074 RID: 116
		Error,
		// Token: 0x04000075 RID: 117
		Warning,
		// Token: 0x04000076 RID: 118
		Info,
		// Token: 0x04000077 RID: 119
		Question,
		// Token: 0x04000078 RID: 120
		Shield,
		// Token: 0x04000079 RID: 121
		Search,
		// Token: 0x0400007A RID: 122
		Information
	}

	// Token: 0x02000014 RID: 20
	public enum AnimateStyle
	{
		// Token: 0x0400007C RID: 124
		SlideDown = 1,
		// Token: 0x0400007D RID: 125
		FadeIn,
		// Token: 0x0400007E RID: 126
		ZoomIn
	}
}
