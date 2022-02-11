using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PEGASUS.Connection;
using PEGASUS.MessagePack;

namespace PEGASUS.Forms
	{
public class FormFun : Form
{
	private IContainer components;

	public System.Windows.Forms.Timer timer1;

	private Guna2GroupBox guna2GroupBox1;

	private Guna2GroupBox guna2GroupBox2;

	private Guna2GroupBox guna2GroupBox3;

	private Guna2GroupBox guna2GroupBox4;

	private Guna2GroupBox guna2GroupBox5;

	private Guna2GroupBox guna2GroupBox6;

	private Guna2GroupBox guna2GroupBox8;

	private Guna2GroupBox guna2GroupBox9;

	private Guna2GradientButton guna2GradientButton1;

	private Guna2GradientButton btnAddIP;

	private Guna2GradientButton guna2GradientButton2;

	private Guna2GradientButton guna2GradientButton3;

	private Guna2GradientButton guna2GradientButton6;

	private Guna2GradientButton guna2GradientButton7;

	private Guna2GradientButton guna2GradientButton8;

	private Guna2GradientButton guna2GradientButton9;

	private Guna2GradientButton guna2GradientButton4;

	private Guna2GradientButton guna2GradientButton5;

	private Guna2GradientButton guna2GradientButton10;

	private Guna2GradientButton guna2GradientButton11;

	private Label label5;

	private Guna2GradientButton guna2GradientButton14;

	private Guna2NumericUpDown numericUpDown2;

	private Guna2GradientButton guna2GradientButton12;

	private Guna2GradientButton guna2GradientButton13;

	private Guna2NumericUpDown numericUpDown1;

	private Guna2GroupBox guna2GroupBox7;

	private Label label6;

	private Guna2GradientButton guna2GradientButton15;

	public Guna2GradientButton btnStartStopRecord;

	public Guna2GradientButton guna2GradientButton16;

	public Guna2GradientButton guna2GradientButton17;

	private Guna2Panel guna2Panel1;

	private Guna2PictureBox guna2PictureBox1;

	private Label label1;

	private PictureBox pictureBox1;

	private Guna2Separator guna2Separator1;

	private Guna2BorderlessForm guna2BorderlessForm1;

	private Guna2ShadowForm guna2ShadowForm1;

	public PEGASUSMain F { get; set; }

	internal Clients Client { get; set; }

	internal Clients ParentClient { get; set; }

	public FormFun()
	{
		InitializeComponent();
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
		MsgPack msgPack = new MsgPack();
		msgPack.ForcePathObject("Pac_ket").AsString = "Taskbar+";
		ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
	}

	private void button2_Click(object sender, EventArgs e)
	{
		MsgPack msgPack = new MsgPack();
		msgPack.ForcePathObject("Pac_ket").AsString = "Taskbar-";
		ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
	}

	private void button3_Click(object sender, EventArgs e)
	{
		MsgPack msgPack = new MsgPack();
		msgPack.ForcePathObject("Pac_ket").AsString = "Desktop+";
		ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
	}

	private void button4_Click(object sender, EventArgs e)
	{
		MsgPack msgPack = new MsgPack();
		msgPack.ForcePathObject("Pac_ket").AsString = "Desktop-";
		ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
	}

	private void button5_Click(object sender, EventArgs e)
	{
		MsgPack msgPack = new MsgPack();
		msgPack.ForcePathObject("Pac_ket").AsString = "Clock+";
		ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
	}

	private void button6_Click(object sender, EventArgs e)
	{
		MsgPack msgPack = new MsgPack();
		msgPack.ForcePathObject("Pac_ket").AsString = "Clock-";
		ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
	}

	private void button8_Click(object sender, EventArgs e)
	{
		MsgPack msgPack = new MsgPack();
		msgPack.ForcePathObject("Pac_ket").AsString = "swapMouseButtons";
		ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
	}

	private void button7_Click(object sender, EventArgs e)
	{
		MsgPack msgPack = new MsgPack();
		msgPack.ForcePathObject("Pac_ket").AsString = "restoreMouseButtons";
		ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
	}

	private void button10_Click(object sender, EventArgs e)
	{
		MsgPack msgPack = new MsgPack();
		msgPack.ForcePathObject("Pac_ket").AsString = "openCD+";
		ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
	}

	private void button9_Click(object sender, EventArgs e)
	{
		MsgPack msgPack = new MsgPack();
		msgPack.ForcePathObject("Pac_ket").AsString = "openCD-";
		ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
	}

	private void button18_Click(object sender, EventArgs e)
	{
		MsgPack msgPack = new MsgPack();
		msgPack.ForcePathObject("Pac_ket").AsString = "blankscreen+";
		ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
	}

	private void button17_Click(object sender, EventArgs e)
	{
		MsgPack msgPack = new MsgPack();
		msgPack.ForcePathObject("Pac_ket").AsString = "blankscreen-";
		ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
	}

	private void button11_Click(object sender, EventArgs e)
	{
		MsgPack msgPack = new MsgPack();
		msgPack.ForcePathObject("Pac_ket").AsString = "blockInput";
		msgPack.ForcePathObject("Time").AsString = numericUpDown1.Value.ToString();
		ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
	}

	private void button15_Click(object sender, EventArgs e)
	{
		MsgPack msgPack = new MsgPack();
		msgPack.ForcePathObject("Pac_ket").AsString = "holdMouse";
		msgPack.ForcePathObject("Time").AsString = numericUpDown2.Value.ToString();
		ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
	}

	private void button12_Click(object sender, EventArgs e)
	{
		MsgPack msgPack = new MsgPack();
		msgPack.ForcePathObject("Pac_ket").AsString = "monitorOff";
		ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
	}

	private void button14_Click(object sender, EventArgs e)
	{
		MsgPack msgPack = new MsgPack();
		msgPack.ForcePathObject("Pac_ket").AsString = "hangSystem";
		ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
	}

	private void FormFun_FormClosed(object sender, FormClosedEventArgs e)
	{
		ThreadPool.QueueUserWorkItem(delegate
		{
			Client?.Disconnected();
		});
	}

	private void button19_Click(object sender, EventArgs e)
	{
		MsgPack msgPack = new MsgPack();
		msgPack.ForcePathObject("Pac_ket").AsString = "webcamlight+";
		ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
	}

	private void button16_Click(object sender, EventArgs e)
	{
		MsgPack msgPack = new MsgPack();
		msgPack.ForcePathObject("Pac_ket").AsString = "webcamlight-";
		ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
	}

	private void button13_Click_1(object sender, EventArgs e)
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "(*.wav)|*.wav";
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			byte[] asBytes = File.ReadAllBytes(openFileDialog.FileName);
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "playAudio";
			msgPack.ForcePathObject("wavfile").SetAsBytes(asBytes);
			ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
		}
		else
		{
			MessageBox.Show("Please choose a wav file.");
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

	private void FormFun_MouseDown(object sender, MouseEventArgs e)
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFun));
		timer1 = new System.Windows.Forms.Timer(components);
		guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
		guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
		btnAddIP = new Guna.UI2.WinForms.Guna2GradientButton();
		guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
		guna2GradientButton2 = new Guna.UI2.WinForms.Guna2GradientButton();
		guna2GradientButton3 = new Guna.UI2.WinForms.Guna2GradientButton();
		guna2GroupBox3 = new Guna.UI2.WinForms.Guna2GroupBox();
		guna2GradientButton6 = new Guna.UI2.WinForms.Guna2GradientButton();
		guna2GradientButton7 = new Guna.UI2.WinForms.Guna2GradientButton();
		guna2GroupBox4 = new Guna.UI2.WinForms.Guna2GroupBox();
		guna2GradientButton8 = new Guna.UI2.WinForms.Guna2GradientButton();
		guna2GradientButton9 = new Guna.UI2.WinForms.Guna2GradientButton();
		guna2GroupBox5 = new Guna.UI2.WinForms.Guna2GroupBox();
		guna2GradientButton4 = new Guna.UI2.WinForms.Guna2GradientButton();
		guna2GradientButton5 = new Guna.UI2.WinForms.Guna2GradientButton();
		guna2GroupBox6 = new Guna.UI2.WinForms.Guna2GroupBox();
		guna2GradientButton10 = new Guna.UI2.WinForms.Guna2GradientButton();
		guna2GradientButton11 = new Guna.UI2.WinForms.Guna2GradientButton();
		guna2GroupBox8 = new Guna.UI2.WinForms.Guna2GroupBox();
		label5 = new System.Windows.Forms.Label();
		guna2GradientButton14 = new Guna.UI2.WinForms.Guna2GradientButton();
		numericUpDown2 = new Guna.UI2.WinForms.Guna2NumericUpDown();
		guna2GroupBox9 = new Guna.UI2.WinForms.Guna2GroupBox();
		guna2GradientButton12 = new Guna.UI2.WinForms.Guna2GradientButton();
		guna2GradientButton13 = new Guna.UI2.WinForms.Guna2GradientButton();
		numericUpDown1 = new Guna.UI2.WinForms.Guna2NumericUpDown();
		guna2GroupBox7 = new Guna.UI2.WinForms.Guna2GroupBox();
		label6 = new System.Windows.Forms.Label();
		guna2GradientButton15 = new Guna.UI2.WinForms.Guna2GradientButton();
		btnStartStopRecord = new Guna.UI2.WinForms.Guna2GradientButton();
		guna2GradientButton16 = new Guna.UI2.WinForms.Guna2GradientButton();
		guna2GradientButton17 = new Guna.UI2.WinForms.Guna2GradientButton();
		guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
		guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		label1 = new System.Windows.Forms.Label();
		guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
		guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
		guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
		guna2GroupBox1.SuspendLayout();
		guna2GroupBox2.SuspendLayout();
		guna2GroupBox3.SuspendLayout();
		guna2GroupBox4.SuspendLayout();
		guna2GroupBox5.SuspendLayout();
		guna2GroupBox6.SuspendLayout();
		guna2GroupBox8.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
		guna2GroupBox9.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
		guna2GroupBox7.SuspendLayout();
		guna2Panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
		SuspendLayout();
		timer1.Interval = 2000;
		timer1.Tick += new System.EventHandler(Timer1_Tick);
		guna2GroupBox1.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GroupBox1.Controls.Add(guna2GradientButton1);
		guna2GroupBox1.Controls.Add(btnAddIP);
		guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GroupBox1.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GroupBox1.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		guna2GroupBox1.ForeColor = System.Drawing.Color.LightGray;
		guna2GroupBox1.Location = new System.Drawing.Point(12, 80);
		guna2GroupBox1.Name = "guna2GroupBox1";
		guna2GroupBox1.ShadowDecoration.Parent = guna2GroupBox1;
		guna2GroupBox1.Size = new System.Drawing.Size(217, 154);
		guna2GroupBox1.TabIndex = 10;
		guna2GroupBox1.Text = "TaskBar";
		guna2GradientButton1.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		guna2GradientButton1.BorderThickness = 1;
		guna2GradientButton1.CheckedState.Parent = guna2GradientButton1;
		guna2GradientButton1.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		guna2GradientButton1.CustomImages.Parent = guna2GradientButton1;
		guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		guna2GradientButton1.DisabledState.Parent = guna2GradientButton1;
		guna2GradientButton1.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton1.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton1.Font = new System.Drawing.Font("Electrolize", 9f);
		guna2GradientButton1.ForeColor = System.Drawing.Color.White;
		guna2GradientButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		guna2GradientButton1.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton1.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton1.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton1.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GradientButton1.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton1.HoverState.Parent = guna2GradientButton1;
		guna2GradientButton1.Location = new System.Drawing.Point(15, 94);
		guna2GradientButton1.Name = "guna2GradientButton1";
		guna2GradientButton1.ShadowDecoration.Parent = guna2GradientButton1;
		guna2GradientButton1.Size = new System.Drawing.Size(179, 30);
		guna2GradientButton1.TabIndex = 116;
		guna2GradientButton1.Text = "Hide";
		guna2GradientButton1.Click += new System.EventHandler(button2_Click);
		btnAddIP.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		btnAddIP.BorderThickness = 1;
		btnAddIP.CheckedState.Parent = btnAddIP;
		btnAddIP.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		btnAddIP.CustomImages.Parent = btnAddIP;
		btnAddIP.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		btnAddIP.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		btnAddIP.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		btnAddIP.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		btnAddIP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		btnAddIP.DisabledState.Parent = btnAddIP;
		btnAddIP.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnAddIP.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		btnAddIP.Font = new System.Drawing.Font("Electrolize", 9f);
		btnAddIP.ForeColor = System.Drawing.Color.White;
		btnAddIP.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		btnAddIP.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		btnAddIP.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		btnAddIP.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnAddIP.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
		btnAddIP.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		btnAddIP.HoverState.Parent = btnAddIP;
		btnAddIP.Location = new System.Drawing.Point(15, 59);
		btnAddIP.Name = "btnAddIP";
		btnAddIP.ShadowDecoration.Parent = btnAddIP;
		btnAddIP.Size = new System.Drawing.Size(179, 30);
		btnAddIP.TabIndex = 115;
		btnAddIP.Text = "Show";
		btnAddIP.Click += new System.EventHandler(button1_Click);
		guna2GroupBox2.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GroupBox2.Controls.Add(guna2GradientButton2);
		guna2GroupBox2.Controls.Add(guna2GradientButton3);
		guna2GroupBox2.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GroupBox2.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GroupBox2.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		guna2GroupBox2.ForeColor = System.Drawing.Color.LightGray;
		guna2GroupBox2.Location = new System.Drawing.Point(12, 240);
		guna2GroupBox2.Name = "guna2GroupBox2";
		guna2GroupBox2.ShadowDecoration.Parent = guna2GroupBox2;
		guna2GroupBox2.Size = new System.Drawing.Size(217, 154);
		guna2GroupBox2.TabIndex = 11;
		guna2GroupBox2.Text = "Desktop";
		guna2GradientButton2.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		guna2GradientButton2.BorderThickness = 1;
		guna2GradientButton2.CheckedState.Parent = guna2GradientButton2;
		guna2GradientButton2.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		guna2GradientButton2.CustomImages.Parent = guna2GradientButton2;
		guna2GradientButton2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton2.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton2.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		guna2GradientButton2.DisabledState.Parent = guna2GradientButton2;
		guna2GradientButton2.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton2.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton2.Font = new System.Drawing.Font("Electrolize", 9f);
		guna2GradientButton2.ForeColor = System.Drawing.Color.White;
		guna2GradientButton2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		guna2GradientButton2.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton2.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton2.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton2.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GradientButton2.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton2.HoverState.Parent = guna2GradientButton2;
		guna2GradientButton2.Location = new System.Drawing.Point(15, 92);
		guna2GradientButton2.Name = "guna2GradientButton2";
		guna2GradientButton2.ShadowDecoration.Parent = guna2GradientButton2;
		guna2GradientButton2.Size = new System.Drawing.Size(179, 30);
		guna2GradientButton2.TabIndex = 118;
		guna2GradientButton2.Text = "Hide";
		guna2GradientButton2.Click += new System.EventHandler(button4_Click);
		guna2GradientButton3.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		guna2GradientButton3.BorderThickness = 1;
		guna2GradientButton3.CheckedState.Parent = guna2GradientButton3;
		guna2GradientButton3.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		guna2GradientButton3.CustomImages.Parent = guna2GradientButton3;
		guna2GradientButton3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton3.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton3.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		guna2GradientButton3.DisabledState.Parent = guna2GradientButton3;
		guna2GradientButton3.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton3.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton3.Font = new System.Drawing.Font("Electrolize", 9f);
		guna2GradientButton3.ForeColor = System.Drawing.Color.White;
		guna2GradientButton3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		guna2GradientButton3.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton3.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton3.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton3.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GradientButton3.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton3.HoverState.Parent = guna2GradientButton3;
		guna2GradientButton3.Location = new System.Drawing.Point(15, 57);
		guna2GradientButton3.Name = "guna2GradientButton3";
		guna2GradientButton3.ShadowDecoration.Parent = guna2GradientButton3;
		guna2GradientButton3.Size = new System.Drawing.Size(179, 30);
		guna2GradientButton3.TabIndex = 117;
		guna2GradientButton3.Text = "Show";
		guna2GradientButton3.Click += new System.EventHandler(button3_Click);
		guna2GroupBox3.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GroupBox3.Controls.Add(guna2GradientButton6);
		guna2GroupBox3.Controls.Add(guna2GradientButton7);
		guna2GroupBox3.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GroupBox3.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GroupBox3.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		guna2GroupBox3.ForeColor = System.Drawing.Color.LightGray;
		guna2GroupBox3.Location = new System.Drawing.Point(235, 80);
		guna2GroupBox3.Name = "guna2GroupBox3";
		guna2GroupBox3.ShadowDecoration.Parent = guna2GroupBox3;
		guna2GroupBox3.Size = new System.Drawing.Size(217, 154);
		guna2GroupBox3.TabIndex = 12;
		guna2GroupBox3.Text = "Mouse";
		guna2GradientButton6.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		guna2GradientButton6.BorderThickness = 1;
		guna2GradientButton6.CheckedState.Parent = guna2GradientButton6;
		guna2GradientButton6.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		guna2GradientButton6.CustomImages.Parent = guna2GradientButton6;
		guna2GradientButton6.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton6.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton6.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton6.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton6.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		guna2GradientButton6.DisabledState.Parent = guna2GradientButton6;
		guna2GradientButton6.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton6.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton6.Font = new System.Drawing.Font("Electrolize", 9f);
		guna2GradientButton6.ForeColor = System.Drawing.Color.White;
		guna2GradientButton6.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		guna2GradientButton6.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton6.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton6.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton6.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GradientButton6.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton6.HoverState.Parent = guna2GradientButton6;
		guna2GradientButton6.Location = new System.Drawing.Point(19, 94);
		guna2GradientButton6.Name = "guna2GradientButton6";
		guna2GradientButton6.ShadowDecoration.Parent = guna2GradientButton6;
		guna2GradientButton6.Size = new System.Drawing.Size(179, 30);
		guna2GradientButton6.TabIndex = 118;
		guna2GradientButton6.Text = "Restore";
		guna2GradientButton6.Click += new System.EventHandler(button7_Click);
		guna2GradientButton7.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		guna2GradientButton7.BorderThickness = 1;
		guna2GradientButton7.CheckedState.Parent = guna2GradientButton7;
		guna2GradientButton7.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		guna2GradientButton7.CustomImages.Parent = guna2GradientButton7;
		guna2GradientButton7.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton7.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton7.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton7.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton7.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		guna2GradientButton7.DisabledState.Parent = guna2GradientButton7;
		guna2GradientButton7.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton7.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton7.Font = new System.Drawing.Font("Electrolize", 9f);
		guna2GradientButton7.ForeColor = System.Drawing.Color.White;
		guna2GradientButton7.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		guna2GradientButton7.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton7.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton7.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton7.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GradientButton7.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton7.HoverState.Parent = guna2GradientButton7;
		guna2GradientButton7.Location = new System.Drawing.Point(19, 59);
		guna2GradientButton7.Name = "guna2GradientButton7";
		guna2GradientButton7.ShadowDecoration.Parent = guna2GradientButton7;
		guna2GradientButton7.Size = new System.Drawing.Size(179, 30);
		guna2GradientButton7.TabIndex = 117;
		guna2GradientButton7.Text = "Change";
		guna2GradientButton7.Click += new System.EventHandler(button8_Click);
		guna2GroupBox4.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GroupBox4.Controls.Add(guna2GradientButton8);
		guna2GroupBox4.Controls.Add(guna2GradientButton9);
		guna2GroupBox4.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GroupBox4.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GroupBox4.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		guna2GroupBox4.ForeColor = System.Drawing.Color.LightGray;
		guna2GroupBox4.Location = new System.Drawing.Point(235, 240);
		guna2GroupBox4.Name = "guna2GroupBox4";
		guna2GroupBox4.ShadowDecoration.Parent = guna2GroupBox4;
		guna2GroupBox4.Size = new System.Drawing.Size(217, 154);
		guna2GroupBox4.TabIndex = 13;
		guna2GroupBox4.Text = "CD Drive";
		guna2GradientButton8.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		guna2GradientButton8.BorderThickness = 1;
		guna2GradientButton8.CheckedState.Parent = guna2GradientButton8;
		guna2GradientButton8.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		guna2GradientButton8.CustomImages.Parent = guna2GradientButton8;
		guna2GradientButton8.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton8.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton8.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton8.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton8.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		guna2GradientButton8.DisabledState.Parent = guna2GradientButton8;
		guna2GradientButton8.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton8.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton8.Font = new System.Drawing.Font("Electrolize", 9f);
		guna2GradientButton8.ForeColor = System.Drawing.Color.White;
		guna2GradientButton8.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		guna2GradientButton8.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton8.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton8.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton8.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GradientButton8.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton8.HoverState.Parent = guna2GradientButton8;
		guna2GradientButton8.Location = new System.Drawing.Point(19, 92);
		guna2GradientButton8.Name = "guna2GradientButton8";
		guna2GradientButton8.ShadowDecoration.Parent = guna2GradientButton8;
		guna2GradientButton8.Size = new System.Drawing.Size(179, 30);
		guna2GradientButton8.TabIndex = 118;
		guna2GradientButton8.Text = "Close";
		guna2GradientButton8.Click += new System.EventHandler(button9_Click);
		guna2GradientButton9.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		guna2GradientButton9.BorderThickness = 1;
		guna2GradientButton9.CheckedState.Parent = guna2GradientButton9;
		guna2GradientButton9.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		guna2GradientButton9.CustomImages.Parent = guna2GradientButton9;
		guna2GradientButton9.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton9.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton9.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton9.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton9.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		guna2GradientButton9.DisabledState.Parent = guna2GradientButton9;
		guna2GradientButton9.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton9.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton9.Font = new System.Drawing.Font("Electrolize", 9f);
		guna2GradientButton9.ForeColor = System.Drawing.Color.White;
		guna2GradientButton9.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		guna2GradientButton9.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton9.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton9.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton9.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GradientButton9.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton9.HoverState.Parent = guna2GradientButton9;
		guna2GradientButton9.Location = new System.Drawing.Point(19, 57);
		guna2GradientButton9.Name = "guna2GradientButton9";
		guna2GradientButton9.ShadowDecoration.Parent = guna2GradientButton9;
		guna2GradientButton9.Size = new System.Drawing.Size(179, 30);
		guna2GradientButton9.TabIndex = 117;
		guna2GradientButton9.Text = "Open";
		guna2GradientButton9.Click += new System.EventHandler(button10_Click);
		guna2GroupBox5.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GroupBox5.Controls.Add(guna2GradientButton4);
		guna2GroupBox5.Controls.Add(guna2GradientButton5);
		guna2GroupBox5.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GroupBox5.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GroupBox5.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		guna2GroupBox5.ForeColor = System.Drawing.Color.LightGray;
		guna2GroupBox5.Location = new System.Drawing.Point(12, 399);
		guna2GroupBox5.Name = "guna2GroupBox5";
		guna2GroupBox5.ShadowDecoration.Parent = guna2GroupBox5;
		guna2GroupBox5.Size = new System.Drawing.Size(217, 154);
		guna2GroupBox5.TabIndex = 14;
		guna2GroupBox5.Text = "Clock";
		guna2GradientButton4.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		guna2GradientButton4.BorderThickness = 1;
		guna2GradientButton4.CheckedState.Parent = guna2GradientButton4;
		guna2GradientButton4.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		guna2GradientButton4.CustomImages.Parent = guna2GradientButton4;
		guna2GradientButton4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton4.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton4.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		guna2GradientButton4.DisabledState.Parent = guna2GradientButton4;
		guna2GradientButton4.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton4.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton4.Font = new System.Drawing.Font("Electrolize", 9f);
		guna2GradientButton4.ForeColor = System.Drawing.Color.White;
		guna2GradientButton4.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		guna2GradientButton4.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton4.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton4.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton4.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GradientButton4.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton4.HoverState.Parent = guna2GradientButton4;
		guna2GradientButton4.Location = new System.Drawing.Point(15, 98);
		guna2GradientButton4.Name = "guna2GradientButton4";
		guna2GradientButton4.ShadowDecoration.Parent = guna2GradientButton4;
		guna2GradientButton4.Size = new System.Drawing.Size(179, 30);
		guna2GradientButton4.TabIndex = 118;
		guna2GradientButton4.Text = "Hide";
		guna2GradientButton4.Click += new System.EventHandler(button6_Click);
		guna2GradientButton5.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		guna2GradientButton5.BorderThickness = 1;
		guna2GradientButton5.CheckedState.Parent = guna2GradientButton5;
		guna2GradientButton5.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		guna2GradientButton5.CustomImages.Parent = guna2GradientButton5;
		guna2GradientButton5.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton5.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton5.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton5.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton5.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		guna2GradientButton5.DisabledState.Parent = guna2GradientButton5;
		guna2GradientButton5.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton5.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton5.Font = new System.Drawing.Font("Electrolize", 9f);
		guna2GradientButton5.ForeColor = System.Drawing.Color.White;
		guna2GradientButton5.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		guna2GradientButton5.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton5.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton5.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton5.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GradientButton5.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton5.HoverState.Parent = guna2GradientButton5;
		guna2GradientButton5.Location = new System.Drawing.Point(15, 63);
		guna2GradientButton5.Name = "guna2GradientButton5";
		guna2GradientButton5.ShadowDecoration.Parent = guna2GradientButton5;
		guna2GradientButton5.Size = new System.Drawing.Size(179, 30);
		guna2GradientButton5.TabIndex = 117;
		guna2GradientButton5.Text = "Show";
		guna2GradientButton5.Click += new System.EventHandler(button5_Click);
		guna2GroupBox6.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GroupBox6.Controls.Add(guna2GradientButton10);
		guna2GroupBox6.Controls.Add(guna2GradientButton11);
		guna2GroupBox6.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GroupBox6.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GroupBox6.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		guna2GroupBox6.ForeColor = System.Drawing.Color.LightGray;
		guna2GroupBox6.Location = new System.Drawing.Point(235, 399);
		guna2GroupBox6.Name = "guna2GroupBox6";
		guna2GroupBox6.ShadowDecoration.Parent = guna2GroupBox6;
		guna2GroupBox6.Size = new System.Drawing.Size(217, 154);
		guna2GroupBox6.TabIndex = 15;
		guna2GroupBox6.Text = "Lock Screen";
		guna2GradientButton10.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		guna2GradientButton10.BorderThickness = 1;
		guna2GradientButton10.CheckedState.Parent = guna2GradientButton10;
		guna2GradientButton10.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		guna2GradientButton10.CustomImages.Parent = guna2GradientButton10;
		guna2GradientButton10.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton10.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton10.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton10.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton10.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		guna2GradientButton10.DisabledState.Parent = guna2GradientButton10;
		guna2GradientButton10.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton10.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton10.Font = new System.Drawing.Font("Electrolize", 9f);
		guna2GradientButton10.ForeColor = System.Drawing.Color.White;
		guna2GradientButton10.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		guna2GradientButton10.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton10.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton10.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton10.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GradientButton10.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton10.HoverState.Parent = guna2GradientButton10;
		guna2GradientButton10.Location = new System.Drawing.Point(19, 98);
		guna2GradientButton10.Name = "guna2GradientButton10";
		guna2GradientButton10.ShadowDecoration.Parent = guna2GradientButton10;
		guna2GradientButton10.Size = new System.Drawing.Size(179, 30);
		guna2GradientButton10.TabIndex = 118;
		guna2GradientButton10.Text = "Stop";
		guna2GradientButton10.Click += new System.EventHandler(button17_Click);
		guna2GradientButton11.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		guna2GradientButton11.BorderThickness = 1;
		guna2GradientButton11.CheckedState.Parent = guna2GradientButton11;
		guna2GradientButton11.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		guna2GradientButton11.CustomImages.Parent = guna2GradientButton11;
		guna2GradientButton11.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton11.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton11.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton11.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton11.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		guna2GradientButton11.DisabledState.Parent = guna2GradientButton11;
		guna2GradientButton11.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton11.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton11.Font = new System.Drawing.Font("Electrolize", 9f);
		guna2GradientButton11.ForeColor = System.Drawing.Color.White;
		guna2GradientButton11.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		guna2GradientButton11.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton11.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton11.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton11.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GradientButton11.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton11.HoverState.Parent = guna2GradientButton11;
		guna2GradientButton11.Location = new System.Drawing.Point(19, 63);
		guna2GradientButton11.Name = "guna2GradientButton11";
		guna2GradientButton11.ShadowDecoration.Parent = guna2GradientButton11;
		guna2GradientButton11.Size = new System.Drawing.Size(179, 30);
		guna2GradientButton11.TabIndex = 117;
		guna2GradientButton11.Text = "Start";
		guna2GradientButton11.Click += new System.EventHandler(button18_Click);
		guna2GroupBox8.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GroupBox8.Controls.Add(label5);
		guna2GroupBox8.Controls.Add(guna2GradientButton14);
		guna2GroupBox8.Controls.Add(numericUpDown2);
		guna2GroupBox8.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GroupBox8.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GroupBox8.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		guna2GroupBox8.ForeColor = System.Drawing.Color.LightGray;
		guna2GroupBox8.Location = new System.Drawing.Point(458, 240);
		guna2GroupBox8.Name = "guna2GroupBox8";
		guna2GroupBox8.ShadowDecoration.Parent = guna2GroupBox8;
		guna2GroupBox8.Size = new System.Drawing.Size(217, 154);
		guna2GroupBox8.TabIndex = 17;
		guna2GroupBox8.Text = "Hold Mouse";
		label5.AutoSize = true;
		label5.BackColor = System.Drawing.Color.Transparent;
		label5.Location = new System.Drawing.Point(82, 70);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(53, 15);
		label5.TabIndex = 140;
		label5.Text = "seconds";
		guna2GradientButton14.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		guna2GradientButton14.BorderThickness = 1;
		guna2GradientButton14.CheckedState.Parent = guna2GradientButton14;
		guna2GradientButton14.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		guna2GradientButton14.CustomImages.Parent = guna2GradientButton14;
		guna2GradientButton14.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton14.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton14.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton14.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton14.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		guna2GradientButton14.DisabledState.Parent = guna2GradientButton14;
		guna2GradientButton14.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton14.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton14.Font = new System.Drawing.Font("Electrolize", 9f);
		guna2GradientButton14.ForeColor = System.Drawing.Color.White;
		guna2GradientButton14.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		guna2GradientButton14.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton14.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton14.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton14.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GradientButton14.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton14.HoverState.Parent = guna2GradientButton14;
		guna2GradientButton14.Location = new System.Drawing.Point(20, 96);
		guna2GradientButton14.Name = "guna2GradientButton14";
		guna2GradientButton14.ShadowDecoration.Parent = guna2GradientButton14;
		guna2GradientButton14.Size = new System.Drawing.Size(179, 30);
		guna2GradientButton14.TabIndex = 139;
		guna2GradientButton14.Text = "Start";
		guna2GradientButton14.Click += new System.EventHandler(button15_Click);
		numericUpDown2.BackColor = System.Drawing.Color.Transparent;
		numericUpDown2.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		numericUpDown2.Cursor = System.Windows.Forms.Cursors.IBeam;
		numericUpDown2.DisabledState.Parent = numericUpDown2;
		numericUpDown2.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		numericUpDown2.FocusedState.Parent = numericUpDown2;
		numericUpDown2.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		numericUpDown2.ForeColor = System.Drawing.Color.LightGray;
		numericUpDown2.Location = new System.Drawing.Point(20, 65);
		numericUpDown2.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
		numericUpDown2.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown2.Name = "numericUpDown2";
		numericUpDown2.ShadowDecoration.Parent = numericUpDown2;
		numericUpDown2.Size = new System.Drawing.Size(56, 25);
		numericUpDown2.TabIndex = 138;
		numericUpDown2.UpDownButtonFillColor = System.Drawing.Color.FromArgb(191, 37, 33);
		numericUpDown2.UpDownButtonForeColor = System.Drawing.Color.White;
		numericUpDown2.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		guna2GroupBox9.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GroupBox9.Controls.Add(guna2GradientButton12);
		guna2GroupBox9.Controls.Add(guna2GradientButton13);
		guna2GroupBox9.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GroupBox9.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GroupBox9.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		guna2GroupBox9.ForeColor = System.Drawing.Color.LightGray;
		guna2GroupBox9.Location = new System.Drawing.Point(458, 400);
		guna2GroupBox9.Name = "guna2GroupBox9";
		guna2GroupBox9.ShadowDecoration.Parent = guna2GroupBox9;
		guna2GroupBox9.Size = new System.Drawing.Size(217, 154);
		guna2GroupBox9.TabIndex = 18;
		guna2GroupBox9.Text = "WebCam Light";
		guna2GradientButton12.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		guna2GradientButton12.BorderThickness = 1;
		guna2GradientButton12.CheckedState.Parent = guna2GradientButton12;
		guna2GradientButton12.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		guna2GradientButton12.CustomImages.Parent = guna2GradientButton12;
		guna2GradientButton12.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton12.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton12.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton12.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton12.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		guna2GradientButton12.DisabledState.Parent = guna2GradientButton12;
		guna2GradientButton12.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton12.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton12.Font = new System.Drawing.Font("Electrolize", 9f);
		guna2GradientButton12.ForeColor = System.Drawing.Color.White;
		guna2GradientButton12.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		guna2GradientButton12.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton12.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton12.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton12.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GradientButton12.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton12.HoverState.Parent = guna2GradientButton12;
		guna2GradientButton12.Location = new System.Drawing.Point(20, 98);
		guna2GradientButton12.Name = "guna2GradientButton12";
		guna2GradientButton12.ShadowDecoration.Parent = guna2GradientButton12;
		guna2GradientButton12.Size = new System.Drawing.Size(179, 30);
		guna2GradientButton12.TabIndex = 120;
		guna2GradientButton12.Text = "Turn Off";
		guna2GradientButton12.Click += new System.EventHandler(button16_Click);
		guna2GradientButton13.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		guna2GradientButton13.BorderThickness = 1;
		guna2GradientButton13.CheckedState.Parent = guna2GradientButton13;
		guna2GradientButton13.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		guna2GradientButton13.CustomImages.Parent = guna2GradientButton13;
		guna2GradientButton13.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton13.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton13.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton13.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton13.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		guna2GradientButton13.DisabledState.Parent = guna2GradientButton13;
		guna2GradientButton13.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton13.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton13.Font = new System.Drawing.Font("Electrolize", 9f);
		guna2GradientButton13.ForeColor = System.Drawing.Color.White;
		guna2GradientButton13.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		guna2GradientButton13.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton13.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton13.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton13.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GradientButton13.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton13.HoverState.Parent = guna2GradientButton13;
		guna2GradientButton13.Location = new System.Drawing.Point(20, 63);
		guna2GradientButton13.Name = "guna2GradientButton13";
		guna2GradientButton13.ShadowDecoration.Parent = guna2GradientButton13;
		guna2GradientButton13.Size = new System.Drawing.Size(179, 30);
		guna2GradientButton13.TabIndex = 119;
		guna2GradientButton13.Text = "Turn On";
		guna2GradientButton13.Click += new System.EventHandler(button19_Click);
		numericUpDown1.BackColor = System.Drawing.Color.Transparent;
		numericUpDown1.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		numericUpDown1.Cursor = System.Windows.Forms.Cursors.IBeam;
		numericUpDown1.DisabledState.Parent = numericUpDown1;
		numericUpDown1.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		numericUpDown1.FocusedState.Parent = numericUpDown1;
		numericUpDown1.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		numericUpDown1.ForeColor = System.Drawing.Color.LightGray;
		numericUpDown1.Location = new System.Drawing.Point(20, 65);
		numericUpDown1.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
		numericUpDown1.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown1.Name = "numericUpDown1";
		numericUpDown1.ShadowDecoration.Parent = numericUpDown1;
		numericUpDown1.Size = new System.Drawing.Size(56, 25);
		numericUpDown1.TabIndex = 138;
		numericUpDown1.UpDownButtonFillColor = System.Drawing.Color.FromArgb(191, 37, 33);
		numericUpDown1.UpDownButtonForeColor = System.Drawing.Color.White;
		numericUpDown1.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		guna2GroupBox7.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GroupBox7.Controls.Add(label6);
		guna2GroupBox7.Controls.Add(guna2GradientButton15);
		guna2GroupBox7.Controls.Add(numericUpDown1);
		guna2GroupBox7.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GroupBox7.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GroupBox7.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		guna2GroupBox7.ForeColor = System.Drawing.Color.LightGray;
		guna2GroupBox7.Location = new System.Drawing.Point(458, 80);
		guna2GroupBox7.Name = "guna2GroupBox7";
		guna2GroupBox7.ShadowDecoration.Parent = guna2GroupBox7;
		guna2GroupBox7.Size = new System.Drawing.Size(217, 154);
		guna2GroupBox7.TabIndex = 16;
		guna2GroupBox7.Text = "Block Input";
		label6.AutoSize = true;
		label6.BackColor = System.Drawing.Color.Transparent;
		label6.Location = new System.Drawing.Point(82, 70);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(53, 15);
		label6.TabIndex = 141;
		label6.Text = "seconds";
		guna2GradientButton15.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		guna2GradientButton15.BorderThickness = 1;
		guna2GradientButton15.CheckedState.Parent = guna2GradientButton15;
		guna2GradientButton15.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		guna2GradientButton15.CustomImages.Parent = guna2GradientButton15;
		guna2GradientButton15.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton15.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton15.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton15.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton15.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		guna2GradientButton15.DisabledState.Parent = guna2GradientButton15;
		guna2GradientButton15.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton15.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton15.Font = new System.Drawing.Font("Electrolize", 9f);
		guna2GradientButton15.ForeColor = System.Drawing.Color.White;
		guna2GradientButton15.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		guna2GradientButton15.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton15.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton15.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton15.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GradientButton15.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton15.HoverState.Parent = guna2GradientButton15;
		guna2GradientButton15.Location = new System.Drawing.Point(20, 96);
		guna2GradientButton15.Name = "guna2GradientButton15";
		guna2GradientButton15.ShadowDecoration.Parent = guna2GradientButton15;
		guna2GradientButton15.Size = new System.Drawing.Size(179, 30);
		guna2GradientButton15.TabIndex = 140;
		guna2GradientButton15.Text = "Start";
		guna2GradientButton15.Click += new System.EventHandler(button11_Click);
		btnStartStopRecord.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		btnStartStopRecord.BorderThickness = 1;
		btnStartStopRecord.CheckedState.Parent = btnStartStopRecord;
		btnStartStopRecord.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		btnStartStopRecord.CustomImages.Parent = btnStartStopRecord;
		btnStartStopRecord.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		btnStartStopRecord.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		btnStartStopRecord.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		btnStartStopRecord.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		btnStartStopRecord.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		btnStartStopRecord.DisabledState.Parent = btnStartStopRecord;
		btnStartStopRecord.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnStartStopRecord.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		btnStartStopRecord.Font = new System.Drawing.Font("Electrolize", 9f);
		btnStartStopRecord.ForeColor = System.Drawing.Color.White;
		btnStartStopRecord.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		btnStartStopRecord.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		btnStartStopRecord.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		btnStartStopRecord.HoverState.ForeColor = System.Drawing.Color.LightGray;
		btnStartStopRecord.HoverState.Parent = btnStartStopRecord;
		btnStartStopRecord.Location = new System.Drawing.Point(692, 263);
		btnStartStopRecord.Name = "btnStartStopRecord";
		btnStartStopRecord.ShadowDecoration.Parent = btnStartStopRecord;
		btnStartStopRecord.Size = new System.Drawing.Size(244, 30);
		btnStartStopRecord.TabIndex = 19;
		btnStartStopRecord.Text = "Play Audio";
		btnStartStopRecord.Click += new System.EventHandler(button13_Click_1);
		guna2GradientButton16.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		guna2GradientButton16.BorderThickness = 1;
		guna2GradientButton16.CheckedState.Parent = guna2GradientButton16;
		guna2GradientButton16.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		guna2GradientButton16.CustomImages.Parent = guna2GradientButton16;
		guna2GradientButton16.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton16.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton16.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton16.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton16.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		guna2GradientButton16.DisabledState.Parent = guna2GradientButton16;
		guna2GradientButton16.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton16.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton16.Font = new System.Drawing.Font("Electrolize", 9f);
		guna2GradientButton16.ForeColor = System.Drawing.Color.White;
		guna2GradientButton16.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		guna2GradientButton16.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		guna2GradientButton16.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GradientButton16.HoverState.ForeColor = System.Drawing.Color.LightGray;
		guna2GradientButton16.HoverState.Parent = guna2GradientButton16;
		guna2GradientButton16.Location = new System.Drawing.Point(692, 299);
		guna2GradientButton16.Name = "guna2GradientButton16";
		guna2GradientButton16.ShadowDecoration.Parent = guna2GradientButton16;
		guna2GradientButton16.Size = new System.Drawing.Size(244, 30);
		guna2GradientButton16.TabIndex = 20;
		guna2GradientButton16.Text = "Turn Monitor off";
		guna2GradientButton16.Click += new System.EventHandler(button12_Click);
		guna2GradientButton17.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		guna2GradientButton17.BorderThickness = 1;
		guna2GradientButton17.CheckedState.Parent = guna2GradientButton17;
		guna2GradientButton17.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		guna2GradientButton17.CustomImages.Parent = guna2GradientButton17;
		guna2GradientButton17.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton17.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton17.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton17.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton17.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		guna2GradientButton17.DisabledState.Parent = guna2GradientButton17;
		guna2GradientButton17.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton17.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton17.Font = new System.Drawing.Font("Electrolize", 9f);
		guna2GradientButton17.ForeColor = System.Drawing.Color.White;
		guna2GradientButton17.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		guna2GradientButton17.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		guna2GradientButton17.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GradientButton17.HoverState.ForeColor = System.Drawing.Color.LightGray;
		guna2GradientButton17.HoverState.Parent = guna2GradientButton17;
		guna2GradientButton17.Location = new System.Drawing.Point(692, 335);
		guna2GradientButton17.Name = "guna2GradientButton17";
		guna2GradientButton17.ShadowDecoration.Parent = guna2GradientButton17;
		guna2GradientButton17.Size = new System.Drawing.Size(244, 30);
		guna2GradientButton17.TabIndex = 21;
		guna2GradientButton17.Text = "Hang system";
		guna2GradientButton17.Click += new System.EventHandler(button14_Click);
		guna2Panel1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2Panel1.Controls.Add(guna2Separator1);
		guna2Panel1.Controls.Add(pictureBox1);
		guna2Panel1.Controls.Add(label1);
		guna2Panel1.Controls.Add(guna2PictureBox1);
		guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		guna2Panel1.ForeColor = System.Drawing.Color.LightGray;
		guna2Panel1.Location = new System.Drawing.Point(0, 0);
		guna2Panel1.Name = "guna2Panel1";
		guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
		guna2Panel1.Size = new System.Drawing.Size(945, 67);
		guna2Panel1.TabIndex = 22;
		guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
		guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		guna2Separator1.BackColor = System.Drawing.Color.Transparent;
		guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2Separator1.Location = new System.Drawing.Point(-177, 61);
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
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(436, 24);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(45, 19);
		label1.TabIndex = 11;
		label1.Text = "FUN";
		guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
		guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
		guna2PictureBox1.ImageRotate = 0f;
		guna2PictureBox1.Location = new System.Drawing.Point(904, 12);
		guna2PictureBox1.Name = "guna2PictureBox1";
		guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
		guna2PictureBox1.Size = new System.Drawing.Size(29, 27);
		guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		guna2PictureBox1.TabIndex = 7;
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
		base.ClientSize = new System.Drawing.Size(945, 569);
		base.Controls.Add(guna2Panel1);
		base.Controls.Add(guna2GradientButton17);
		base.Controls.Add(guna2GradientButton16);
		base.Controls.Add(btnStartStopRecord);
		base.Controls.Add(guna2GroupBox9);
		base.Controls.Add(guna2GroupBox8);
		base.Controls.Add(guna2GroupBox7);
		base.Controls.Add(guna2GroupBox6);
		base.Controls.Add(guna2GroupBox5);
		base.Controls.Add(guna2GroupBox4);
		base.Controls.Add(guna2GroupBox3);
		base.Controls.Add(guna2GroupBox2);
		base.Controls.Add(guna2GroupBox1);
		ForeColor = System.Drawing.Color.LightGray;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "FormFun";
		Text = "Fun";
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FormFun_FormClosed);
		base.MouseDown += new System.Windows.Forms.MouseEventHandler(FormFun_MouseDown);
		guna2GroupBox1.ResumeLayout(false);
		guna2GroupBox2.ResumeLayout(false);
		guna2GroupBox3.ResumeLayout(false);
		guna2GroupBox4.ResumeLayout(false);
		guna2GroupBox5.ResumeLayout(false);
		guna2GroupBox6.ResumeLayout(false);
		guna2GroupBox8.ResumeLayout(false);
		guna2GroupBox8.PerformLayout();
		((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
		guna2GroupBox9.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
		guna2GroupBox7.ResumeLayout(false);
		guna2GroupBox7.PerformLayout();
		guna2Panel1.ResumeLayout(false);
		guna2Panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
		ResumeLayout(false);
	}
}
}