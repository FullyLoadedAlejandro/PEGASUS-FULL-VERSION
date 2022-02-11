using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PEGASUS
{ 

public class MsgBox : Form
{
	public enum Buttons
	{
		AbortRetryIgnore = 1,
		OK,
		OKCancel,
		RetryCancel,
		YesNo,
		YesNoCancel
	}

	public new enum Icon
	{
		Application = 1,
		Exclamation,
		Error,
		Warning,
		Info,
		Question,
		Shield,
		Search,
		Information
	}

	public enum AnimateStyle
	{
		SlideDown = 1,
		FadeIn,
		ZoomIn
	}

	private const int CS_DROPSHADOW = 131072;

	private static MsgBox _msgBox;

	private Panel _plHeader = new Panel();

	private Panel _plFooter = new Panel();

	private Panel _plIcon = new Panel();

	private PictureBox _picIcon = new PictureBox();

	private FlowLayoutPanel _flpButtons = new FlowLayoutPanel();

	private Label _lblTitle;

	private Label _lblMessage;

	private List<Button> _buttonCollection = new List<Button>();

	private static DialogResult _buttonResult;

	private static Timer _timer;

	private static Point lastMousePos;

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams obj = base.CreateParams;
			obj.ClassStyle |= 131072;
			return obj;
		}
	}

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern bool MessageBeep(uint type);

	private MsgBox()
	{
		base.FormBorderStyle = FormBorderStyle.None;
		BackColor = Color.FromArgb(22, 22, 22);
		base.StartPosition = FormStartPosition.CenterScreen;
		base.Padding = new Padding(3);
		base.Width = 400;
		_lblTitle = new Label();
		_lblTitle.ForeColor = Color.White;
		_lblTitle.Font = new Font("Electrolize", 18f);
		_lblTitle.Dock = DockStyle.Top;
		_lblTitle.Height = 50;
		_lblMessage = new Label();
		_lblMessage.ForeColor = Color.White;
		_lblMessage.Font = new Font("Electrolize", 10f);
		_lblMessage.Dock = DockStyle.Fill;
		_flpButtons.FlowDirection = FlowDirection.RightToLeft;
		_flpButtons.Dock = DockStyle.Fill;
		_plHeader.Dock = DockStyle.Fill;
		_plHeader.Padding = new Padding(20);
		_plHeader.Controls.Add(_lblMessage);
		_plHeader.Controls.Add(_lblTitle);
		_plFooter.Dock = DockStyle.Bottom;
		_plFooter.Padding = new Padding(20);
		_plFooter.BackColor = Color.FromArgb(22, 22, 22);
		_plFooter.Height = 80;
		_plFooter.Controls.Add(_flpButtons);
		_picIcon.Width = 32;
		_picIcon.Height = 32;
		_picIcon.Location = new Point(30, 50);
		_plIcon.Dock = DockStyle.Left;
		_plIcon.Padding = new Padding(20);
		_plIcon.Width = 70;
		_plIcon.Controls.Add(_picIcon);
		foreach (Control item in new List<Control> { this, _lblTitle, _lblMessage, _flpButtons, _plHeader, _plFooter, _plIcon, _picIcon })
		{
			item.MouseDown += MsgBox_MouseDown;
			item.MouseMove += MsgBox_MouseMove;
		}
		base.Controls.Add(_plHeader);
		base.Controls.Add(_plIcon);
		base.Controls.Add(_plFooter);
	}

	private static void MsgBox_MouseDown(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			lastMousePos = new Point(e.X, e.Y);
		}
	}

	private static void MsgBox_MouseMove(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			_msgBox.Left += e.X - lastMousePos.X;
			_msgBox.Top += e.Y - lastMousePos.Y;
		}
	}

	public static DialogResult Show(string message)
	{
		_msgBox = new MsgBox();
		_msgBox._lblMessage.Text = message;
		InitButtons(Buttons.OK);
		_msgBox.ShowDialog();
		MessageBeep(0u);
		return _buttonResult;
	}

	public static DialogResult Show(string message, string title)
	{
		_msgBox = new MsgBox();
		_msgBox._lblMessage.Text = message;
		_msgBox._lblTitle.Text = title;
		_msgBox.Size = MessageSize(message);
		InitButtons(Buttons.OK);
		_msgBox.ShowDialog();
		MessageBeep(0u);
		return _buttonResult;
	}

	public static DialogResult Show(string message, string title, Buttons buttons)
	{
		_msgBox = new MsgBox();
		_msgBox._lblMessage.Text = message;
		_msgBox._lblTitle.Text = title;
		_msgBox._plIcon.Hide();
		InitButtons(buttons);
		_msgBox.Size = MessageSize(message);
		_msgBox.ShowDialog();
		MessageBeep(0u);
		return _buttonResult;
	}

	public static DialogResult Show(string message, string title, Buttons buttons, Icon icon)
	{
		_msgBox = new MsgBox();
		_msgBox._lblMessage.Text = message;
		_msgBox._lblTitle.Text = title;
		InitButtons(buttons);
		InitIcon(icon);
		_msgBox.Size = MessageSize(message);
		_msgBox.ShowDialog();
		MessageBeep(0u);
		return _buttonResult;
	}

	public static DialogResult Show(string message, string title, Buttons buttons, Icon icon, AnimateStyle style)
	{
		_msgBox = new MsgBox();
		_msgBox._lblMessage.Text = message;
		_msgBox._lblTitle.Text = title;
		_msgBox.Height = 0;
		InitButtons(buttons);
		InitIcon(icon);
		_timer = new Timer();
		Size size = MessageSize(message);
		switch (style)
		{
		case AnimateStyle.SlideDown:
			_msgBox.Size = new Size(size.Width, 0);
			_timer.Interval = 1;
			_timer.Tag = new AnimateMsgBox(size, style);
			break;
		case AnimateStyle.FadeIn:
			_msgBox.Size = size;
			_msgBox.Opacity = 0.0;
			_timer.Interval = 20;
			_timer.Tag = new AnimateMsgBox(size, style);
			break;
		case AnimateStyle.ZoomIn:
			_msgBox.Size = new Size(size.Width + 100, size.Height + 100);
			_timer.Tag = new AnimateMsgBox(size, style);
			_timer.Interval = 1;
			break;
		}
		_timer.Tick += timer_Tick;
		_timer.Start();
		_msgBox.ShowDialog();
		MessageBeep(0u);
		return _buttonResult;
	}

	private static void timer_Tick(object sender, EventArgs e)
	{
		AnimateMsgBox animateMsgBox = (AnimateMsgBox)((Timer)sender).Tag;
		switch (animateMsgBox.Style)
		{
		case AnimateStyle.SlideDown:
			if (_msgBox.Height < animateMsgBox.FormSize.Height)
			{
				_msgBox.Height += 17;
				_msgBox.Invalidate();
			}
			else
			{
				_timer.Stop();
				_timer.Dispose();
			}
			break;
		case AnimateStyle.FadeIn:
			if (_msgBox.Opacity < 1.0)
			{
				_msgBox.Opacity += 0.1;
				_msgBox.Invalidate();
			}
			else
			{
				_timer.Stop();
				_timer.Dispose();
			}
			break;
		case AnimateStyle.ZoomIn:
			if (_msgBox.Width > animateMsgBox.FormSize.Width)
			{
				_msgBox.Width -= 17;
				_msgBox.Invalidate();
			}
			if (_msgBox.Height > animateMsgBox.FormSize.Height)
			{
				_msgBox.Height -= 17;
				_msgBox.Invalidate();
			}
			break;
		}
	}

	private static void InitButtons(Buttons buttons)
	{
		switch (buttons)
		{
		case Buttons.AbortRetryIgnore:
			_msgBox.InitAbortRetryIgnoreButtons();
			break;
		case Buttons.OK:
			_msgBox.InitOKButton();
			break;
		case Buttons.OKCancel:
			_msgBox.InitOKCancelButtons();
			break;
		case Buttons.RetryCancel:
			_msgBox.InitRetryCancelButtons();
			break;
		case Buttons.YesNo:
			_msgBox.InitYesNoButtons();
			break;
		case Buttons.YesNoCancel:
			_msgBox.InitYesNoCancelButtons();
			break;
		}
		foreach (Button item in _msgBox._buttonCollection)
		{
			item.ForeColor = Color.White;
			item.Font = new Font("Electrolize", 8f);
			item.Padding = new Padding(3);
			item.FlatStyle = FlatStyle.Flat;
			item.Height = 30;
			item.FlatAppearance.BorderColor = Color.FromArgb(191, 37, 33);
			_msgBox._flpButtons.Controls.Add(item);
		}
	}

	private static void InitIcon(Icon icon)
	{
		switch (icon)
		{
		case Icon.Application:
			_msgBox._picIcon.Image = SystemIcons.Application.ToBitmap();
			break;
		case Icon.Exclamation:
			_msgBox._picIcon.Image = SystemIcons.Exclamation.ToBitmap();
			break;
		case Icon.Error:
			_msgBox._picIcon.Image = SystemIcons.Error.ToBitmap();
			break;
		case Icon.Info:
			_msgBox._picIcon.Image = SystemIcons.Information.ToBitmap();
			break;
		case Icon.Question:
			_msgBox._picIcon.Image = SystemIcons.Question.ToBitmap();
			break;
		case Icon.Shield:
			_msgBox._picIcon.Image = SystemIcons.Shield.ToBitmap();
			break;
		case Icon.Warning:
			_msgBox._picIcon.Image = SystemIcons.Warning.ToBitmap();
			break;
		}
	}

	private void InitAbortRetryIgnoreButtons()
	{
		Button button = new Button();
		button.Text = "Abort";
		button.Click += ButtonClick;
		Button button2 = new Button();
		button2.Text = "Retry";
		button2.Click += ButtonClick;
		Button button3 = new Button();
		button3.Text = "Ignore";
		button3.Click += ButtonClick;
		_buttonCollection.Add(button);
		_buttonCollection.Add(button2);
		_buttonCollection.Add(button3);
	}

	private void InitOKButton()
	{
		Button button = new Button();
		button.Text = "OK";
		button.Click += ButtonClick;
		_buttonCollection.Add(button);
	}

	private void InitOKCancelButtons()
	{
		Button button = new Button();
		button.Text = "OK";
		button.Click += ButtonClick;
		Button button2 = new Button();
		button2.Text = "Cancel";
		button2.Click += ButtonClick;
		_buttonCollection.Add(button);
		_buttonCollection.Add(button2);
	}

	private void InitRetryCancelButtons()
	{
		Button button = new Button();
		button.Text = "OK";
		button.Click += ButtonClick;
		Button button2 = new Button();
		button2.Text = "Cancel";
		button2.Click += ButtonClick;
		_buttonCollection.Add(button);
		_buttonCollection.Add(button2);
	}

	private void InitYesNoButtons()
	{
		Button button = new Button();
		button.Text = "Yes";
		button.Click += ButtonClick;
		Button button2 = new Button();
		button2.Text = "No";
		button2.Click += ButtonClick;
		_buttonCollection.Add(button);
		_buttonCollection.Add(button2);
	}

	private void InitYesNoCancelButtons()
	{
		Button button = new Button();
		button.Text = "Abort";
		button.Click += ButtonClick;
		Button button2 = new Button();
		button2.Text = "Retry";
		button2.Click += ButtonClick;
		Button button3 = new Button();
		button3.Text = "Cancel";
		button3.Click += ButtonClick;
		_buttonCollection.Add(button);
		_buttonCollection.Add(button2);
		_buttonCollection.Add(button3);
	}

	private static void ButtonClick(object sender, EventArgs e)
	{
		switch (((Button)sender).Text)
		{
		case "Abort":
			_buttonResult = DialogResult.Abort;
			break;
		case "Retry":
			_buttonResult = DialogResult.Retry;
			break;
		case "Ignore":
			_buttonResult = DialogResult.Ignore;
			break;
		case "OK":
			_buttonResult = DialogResult.OK;
			break;
		case "Cancel":
			_buttonResult = DialogResult.Cancel;
			break;
		case "Yes":
			_buttonResult = DialogResult.Yes;
			break;
		case "No":
			_buttonResult = DialogResult.No;
			break;
		}
		_msgBox.Dispose();
	}

	private static Size MessageSize(string message)
	{
		Graphics graphics = _msgBox.CreateGraphics();
		int num = 350;
		int num2 = 230;
		SizeF sizeF = graphics.MeasureString(message, new Font("Electrolize", 10f));
		if (message.Length < 150 && (int)sizeF.Width > 350)
		{
			num = (int)sizeF.Width;
		}
		return new Size(num, num2);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		Graphics graphics = e.Graphics;
		Rectangle rect = new Rectangle(new Point(0, 0), new Size(base.Width - 1, base.Height - 1));
		Pen pen = new Pen(Color.FromArgb(191, 37, 33));
		graphics.DrawRectangle(pen, rect);
	}
}
}