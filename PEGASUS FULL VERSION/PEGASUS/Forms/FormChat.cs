using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PEGASUS.Algorithm;
using PEGASUS.Connection;
using PEGASUS.MessagePack;

namespace PEGASUS.Forms
	{
public class FormChat : Form
{
	private string Nickname = "Admin";

	private IContainer components;

	public RichTextBox richTextBox1;

	public System.Windows.Forms.Timer timer1;

	public TextBox textBox1;

	private PictureBox pictureBox1;

	private Label label1;

	private Guna2GradientButton button1;

	private Guna2PictureBox guna2PictureBox1;

	private Guna2Panel guna2Panel1;

	private PictureBox pictureBox2;

	private Label label2;

	private Label label3;

	private Guna2Separator guna2Separator1;

	private Guna2BorderlessForm guna2BorderlessForm1;

	private Guna2ShadowForm guna2ShadowForm1;

	public PEGASUSMain F { get; set; }

	internal Clients ParentClient { get; set; }

	internal Clients Client { get; set; }

	public FormChat()
	{
		InitializeComponent();
	}

	private void FormChat_Load(object sender, EventArgs e)
	{
		string text = InputDialog.Show("TYPE YOUR NICKNAME");
		if (string.IsNullOrEmpty(text))
		{
			Close();
			return;
		}
		Nickname = text;
		MsgPack msgPack = new MsgPack();
		msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
		msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\CT.dll");
		ThreadPool.QueueUserWorkItem(ParentClient.Send, msgPack.Encode2Bytes());
	}

	private void FormChat_FormClosed(object sender, FormClosedEventArgs e)
	{
		if (Client != null)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "chatExit";
				ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
			}
			catch
			{
			}
		}
	}

	private void Timer1_Tick(object sender, EventArgs e)
	{
		try
		{
			if (!ParentClient.TcpClient.Connected || !Client.TcpClient.Connected)
			{
				Close();
			}
		}
		catch
		{
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		if (textBox1.Enabled && !string.IsNullOrWhiteSpace(textBox1.Text))
		{
			richTextBox1.SelectionColor = Color.FromArgb(3, 130, 200);
			richTextBox1.AppendText("ME: \n");
			richTextBox1.SelectionColor = Color.FromArgb(3, 130, 200);
			richTextBox1.AppendText(textBox1.Text + Environment.NewLine);
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "chatWriteInput";
			msgPack.ForcePathObject("Input").AsString = Nickname + ": \n";
			msgPack.ForcePathObject("Input2").AsString = textBox1.Text;
			ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
			textBox1.Clear();
		}
	}

	private void guna2PictureBox1_Click(object sender, EventArgs e)
	{
		Close();
	}

	[DllImport("user32.DLL")]
	private static extern void ReleaseCapture();

	[DllImport("user32.DLL")]
	private static extern void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

	private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
	{
		ReleaseCapture();
		SendMessage(base.Handle, 274, 61458, 0);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChat));
		richTextBox1 = new System.Windows.Forms.RichTextBox();
		textBox1 = new System.Windows.Forms.TextBox();
		timer1 = new System.Windows.Forms.Timer(components);
		pictureBox1 = new System.Windows.Forms.PictureBox();
		label1 = new System.Windows.Forms.Label();
		button1 = new Guna.UI2.WinForms.Guna2GradientButton();
		guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
		guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
		guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
		label3 = new System.Windows.Forms.Label();
		pictureBox2 = new System.Windows.Forms.PictureBox();
		label2 = new System.Windows.Forms.Label();
		guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
		guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
		guna2Panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
		SuspendLayout();
		richTextBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		richTextBox1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
		richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		richTextBox1.CausesValidation = false;
		richTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
		richTextBox1.Font = new System.Drawing.Font("SimSun", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		richTextBox1.ForeColor = System.Drawing.Color.LightGray;
		richTextBox1.Location = new System.Drawing.Point(15, 108);
		richTextBox1.Margin = new System.Windows.Forms.Padding(2);
		richTextBox1.Name = "richTextBox1";
		richTextBox1.ReadOnly = true;
		richTextBox1.Size = new System.Drawing.Size(486, 173);
		richTextBox1.TabIndex = 3;
		richTextBox1.Text = "";
		textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
		textBox1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
		textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		textBox1.Enabled = false;
		textBox1.Font = new System.Drawing.Font("SimSun", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		textBox1.ForeColor = System.Drawing.Color.LightGray;
		textBox1.Location = new System.Drawing.Point(15, 294);
		textBox1.Margin = new System.Windows.Forms.Padding(2);
		textBox1.Multiline = true;
		textBox1.Name = "textBox1";
		textBox1.Size = new System.Drawing.Size(588, 172);
		textBox1.TabIndex = 0;
		timer1.Interval = 1000;
		timer1.Tick += new System.EventHandler(Timer1_Tick);
		pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
		pictureBox1.Location = new System.Drawing.Point(506, 134);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(97, 124);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 3;
		pictureBox1.TabStop = false;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		label1.Location = new System.Drawing.Point(86, 496);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(86, 14);
		label1.TabIndex = 4;
		label1.Text = "Chat Connected\r\n";
		button1.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		button1.BorderThickness = 1;
		button1.CheckedState.Parent = button1;
		button1.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		button1.CustomImages.Parent = button1;
		button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		button1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		button1.DisabledState.Parent = button1;
		button1.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		button1.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		button1.Font = new System.Drawing.Font("Electrolize", 9f);
		button1.ForeColor = System.Drawing.Color.White;
		button1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		button1.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		button1.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		button1.HoverState.ForeColor = System.Drawing.Color.LightGray;
		button1.HoverState.Parent = button1;
		button1.Location = new System.Drawing.Point(359, 480);
		button1.Name = "button1";
		button1.ShadowDecoration.Parent = button1;
		button1.Size = new System.Drawing.Size(244, 30);
		button1.TabIndex = 9;
		button1.Text = "Send";
		guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
		guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
		guna2PictureBox1.ImageRotate = 0f;
		guna2PictureBox1.Location = new System.Drawing.Point(593, 12);
		guna2PictureBox1.Name = "guna2PictureBox1";
		guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
		guna2PictureBox1.Size = new System.Drawing.Size(29, 27);
		guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		guna2PictureBox1.TabIndex = 10;
		guna2PictureBox1.TabStop = false;
		guna2PictureBox1.UseTransparentBackground = true;
		guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
		guna2Panel1.Controls.Add(guna2Separator1);
		guna2Panel1.Controls.Add(label3);
		guna2Panel1.Controls.Add(pictureBox2);
		guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		guna2Panel1.Location = new System.Drawing.Point(0, 0);
		guna2Panel1.Name = "guna2Panel1";
		guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
		guna2Panel1.Size = new System.Drawing.Size(634, 67);
		guna2Panel1.TabIndex = 11;
		guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
		guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		guna2Separator1.BackColor = System.Drawing.Color.Transparent;
		guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2Separator1.Location = new System.Drawing.Point(-332, 61);
		guna2Separator1.Name = "guna2Separator1";
		guna2Separator1.Size = new System.Drawing.Size(1299, 10);
		guna2Separator1.TabIndex = 12;
		guna2Separator1.UseTransparentBackground = true;
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(264, 20);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(100, 19);
		label3.TabIndex = 11;
		label3.Text = "Chat Room";
		pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
		pictureBox2.Location = new System.Drawing.Point(12, 12);
		pictureBox2.Name = "pictureBox2";
		pictureBox2.Size = new System.Drawing.Size(41, 41);
		pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox2.TabIndex = 4;
		pictureBox2.TabStop = false;
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(12, 496);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(68, 14);
		label2.TabIndex = 12;
		label2.Text = "Chat Status:";
		guna2BorderlessForm1.ContainerControl = this;
		guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2ShadowForm1.TargetForm = this;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		base.ClientSize = new System.Drawing.Size(634, 519);
		base.Controls.Add(label2);
		base.Controls.Add(guna2PictureBox1);
		base.Controls.Add(button1);
		base.Controls.Add(label1);
		base.Controls.Add(pictureBox1);
		base.Controls.Add(textBox1);
		base.Controls.Add(richTextBox1);
		base.Controls.Add(guna2Panel1);
		ForeColor = System.Drawing.Color.LightGray;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(2);
		base.Name = "FormChat";
		Text = "Chat";
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FormChat_FormClosed);
		base.Load += new System.EventHandler(FormChat_Load);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
		guna2Panel1.ResumeLayout(false);
		guna2Panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
}