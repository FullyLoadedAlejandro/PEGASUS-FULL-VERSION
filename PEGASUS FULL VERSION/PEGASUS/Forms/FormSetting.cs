using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PEGASUS.Properties;

namespace PEGASUS.Forms
{

	public class FormSetting : Form
	{
		private IContainer components;

		private Label label1;

		private Label label2;

		public Guna2GradientButton button1;

		private Guna2TextBox textBox1;

		private Guna2TextBox textBox2;

		private Guna2Panel guna2Panel1;

		private Guna2PictureBox guna2PictureBox1;

		private Guna2RadioButton checkBox1;

		private Label label3;

		private PictureBox pictureBox1;

		private Guna2Separator guna2Separator1;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ShadowForm guna2ShadowForm1;

		public FormSetting()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (checkBox1.Checked && (textBox1.Text == null || textBox2.Text == null))
			{
				MessageBox.Show("Input the WebHook and secret");
			}
			PEGASUS.Properties.Settings.Default.DingDing = checkBox1.Checked;
			PEGASUS.Properties.Settings.Default.WebHook = textBox1.Text;
			PEGASUS.Properties.Settings.Default.Secret = textBox2.Text;
			PEGASUS.Properties.Settings.Default.Save();
			Close();
		}

		private void FormSetting_Load(object sender, EventArgs e)
		{
			checkBox1.Checked = PEGASUS.Properties.Settings.Default.DingDing;
			textBox1.Text = PEGASUS.Properties.Settings.Default.WebHook;
			textBox2.Text = PEGASUS.Properties.Settings.Default.Secret;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetting));
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			button1 = new Guna.UI2.WinForms.Guna2GradientButton();
			textBox1 = new Guna.UI2.WinForms.Guna2TextBox();
			textBox2 = new Guna.UI2.WinForms.Guna2TextBox();
			guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label3 = new System.Windows.Forms.Label();
			guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			checkBox1 = new Guna.UI2.WinForms.Guna2RadioButton();
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(20, 128);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(57, 13);
			label1.TabIndex = 4;
			label1.Text = "Webhook:";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(20, 181);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(41, 13);
			label2.TabIndex = 5;
			label2.Text = "Secret:";
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
			button1.Location = new System.Drawing.Point(95, 228);
			button1.Name = "button1";
			button1.ShadowDecoration.Parent = button1;
			button1.Size = new System.Drawing.Size(157, 30);
			button1.TabIndex = 9;
			button1.Text = "Ok";
			button1.Click += new System.EventHandler(button1_Click);
			textBox1.Animated = true;
			textBox1.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
			textBox1.DefaultText = "";
			textBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			textBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			textBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			textBox1.DisabledState.Parent = textBox1;
			textBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			textBox1.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			textBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
			textBox1.FocusedState.Parent = textBox1;
			textBox1.Font = new System.Drawing.Font("Electrolize", 9f);
			textBox1.ForeColor = System.Drawing.Color.White;
			textBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
			textBox1.HoverState.Parent = textBox1;
			textBox1.Location = new System.Drawing.Point(83, 121);
			textBox1.Name = "textBox1";
			textBox1.PasswordChar = '\0';
			textBox1.PlaceholderText = "";
			textBox1.SelectedText = "";
			textBox1.ShadowDecoration.Parent = textBox1;
			textBox1.Size = new System.Drawing.Size(244, 20);
			textBox1.TabIndex = 10;
			textBox2.Animated = true;
			textBox2.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			textBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
			textBox2.DefaultText = "";
			textBox2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			textBox2.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			textBox2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			textBox2.DisabledState.Parent = textBox2;
			textBox2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			textBox2.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			textBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
			textBox2.FocusedState.Parent = textBox2;
			textBox2.Font = new System.Drawing.Font("Electrolize", 9f);
			textBox2.ForeColor = System.Drawing.Color.White;
			textBox2.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
			textBox2.HoverState.Parent = textBox2;
			textBox2.Location = new System.Drawing.Point(83, 174);
			textBox2.Name = "textBox2";
			textBox2.PasswordChar = '\0';
			textBox2.PlaceholderText = "";
			textBox2.SelectedText = "";
			textBox2.ShadowDecoration.Parent = textBox2;
			textBox2.Size = new System.Drawing.Size(244, 20);
			textBox2.TabIndex = 11;
			guna2Panel1.Controls.Add(guna2Separator1);
			guna2Panel1.Controls.Add(pictureBox1);
			guna2Panel1.Controls.Add(label3);
			guna2Panel1.Controls.Add(guna2PictureBox1);
			guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			guna2Panel1.Location = new System.Drawing.Point(0, 0);
			guna2Panel1.Name = "guna2Panel1";
			guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
			guna2Panel1.Size = new System.Drawing.Size(345, 67);
			guna2Panel1.TabIndex = 12;
			guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
			guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator1.BackColor = System.Drawing.Color.Transparent;
			guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2Separator1.Location = new System.Drawing.Point(-477, 61);
			guna2Separator1.Name = "guna2Separator1";
			guna2Separator1.Size = new System.Drawing.Size(1299, 10);
			guna2Separator1.TabIndex = 15;
			guna2Separator1.UseTransparentBackground = true;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(15, 12);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(40, 42);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 14;
			pictureBox1.TabStop = false;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(91, 20);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(155, 19);
			label3.TabIndex = 11;
			label3.Text = "Pastebin Settings";
			guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
			guna2PictureBox1.ImageRotate = 0f;
			guna2PictureBox1.Location = new System.Drawing.Point(304, 12);
			guna2PictureBox1.Name = "guna2PictureBox1";
			guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
			guna2PictureBox1.Size = new System.Drawing.Size(29, 27);
			guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox1.TabIndex = 7;
			guna2PictureBox1.TabStop = false;
			guna2PictureBox1.UseTransparentBackground = true;
			guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
			checkBox1.AutoSize = true;
			checkBox1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
			checkBox1.CheckedState.BorderThickness = 0;
			checkBox1.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
			checkBox1.CheckedState.InnerColor = System.Drawing.Color.White;
			checkBox1.CheckedState.InnerOffset = -4;
			checkBox1.Location = new System.Drawing.Point(260, 98);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(67, 17);
			checkBox1.TabIndex = 125;
			checkBox1.Text = "PasteBin";
			checkBox1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
			checkBox1.UncheckedState.BorderThickness = 2;
			checkBox1.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			checkBox1.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(345, 270);
			base.Controls.Add(checkBox1);
			base.Controls.Add(guna2Panel1);
			base.Controls.Add(textBox2);
			base.Controls.Add(textBox1);
			base.Controls.Add(button1);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			ForeColor = System.Drawing.Color.LightGray;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormSetting";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Setting";
			base.Load += new System.EventHandler(FormSetting_Load);
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
			guna2Panel1.ResumeLayout(false);
			guna2Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}