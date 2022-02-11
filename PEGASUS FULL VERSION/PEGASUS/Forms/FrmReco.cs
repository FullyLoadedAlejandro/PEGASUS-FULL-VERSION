using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace PEGASUS.Forms
{

	public class FrmReco : Form
	{
		private IContainer components;

		private Guna2TabControl guna2TabControl1;

		private TabPage tabPage1;

		private TextBox txtPasswords;

		private TabPage tabPage4;

		private TextBox txtCookies;

		private Guna2Panel guna2Panel1;

		private Guna2Separator guna2Separator1;

		private PictureBox pictureBox1;

		private Label label15;

		private Guna2PictureBox guna2PictureBox1;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ShadowForm guna2ShadowForm1;

		public FrmReco(string pass, string cookies)
		{
			InitializeComponent();
			string text = File.ReadAllText(pass);
			txtPasswords.Text = text;
			string text2 = File.ReadAllText(cookies);
			txtCookies.Text = text2;
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

		private void FrmReco_Load(object sender, EventArgs e)
		{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReco));
			guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			txtPasswords = new System.Windows.Forms.TextBox();
			tabPage4 = new System.Windows.Forms.TabPage();
			txtCookies = new System.Windows.Forms.TextBox();
			guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label15 = new System.Windows.Forms.Label();
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			guna2TabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage4.SuspendLayout();
			guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			guna2TabControl1.Controls.Add(tabPage1);
			guna2TabControl1.Controls.Add(tabPage4);
			guna2TabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
			guna2TabControl1.ItemSize = new System.Drawing.Size(180, 40);
			guna2TabControl1.Location = new System.Drawing.Point(0, 81);
			guna2TabControl1.Name = "guna2TabControl1";
			guna2TabControl1.SelectedIndex = 0;
			guna2TabControl1.Size = new System.Drawing.Size(800, 522);
			guna2TabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2TabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2TabControl1.TabButtonHoverState.Font = new System.Drawing.Font("Electrolize", 10f);
			guna2TabControl1.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
			guna2TabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2TabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2TabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2TabControl1.TabButtonIdleState.Font = new System.Drawing.Font("Electrolize", 10f);
			guna2TabControl1.TabButtonIdleState.ForeColor = System.Drawing.Color.LightGray;
			guna2TabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.Transparent;
			guna2TabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2TabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2TabControl1.TabButtonSelectedState.Font = new System.Drawing.Font("Electrolize", 10f);
			guna2TabControl1.TabButtonSelectedState.ForeColor = System.Drawing.Color.LightGray;
			guna2TabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2TabControl1.TabButtonSize = new System.Drawing.Size(180, 40);
			guna2TabControl1.TabIndex = 136;
			guna2TabControl1.TabMenuBackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2TabControl1.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
			tabPage1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			tabPage1.Controls.Add(txtPasswords);
			tabPage1.Location = new System.Drawing.Point(4, 44);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new System.Windows.Forms.Padding(3);
			tabPage1.Size = new System.Drawing.Size(792, 474);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Passwords";
			txtPasswords.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			txtPasswords.BorderStyle = System.Windows.Forms.BorderStyle.None;
			txtPasswords.Dock = System.Windows.Forms.DockStyle.Fill;
			txtPasswords.ForeColor = System.Drawing.Color.LightGray;
			txtPasswords.Location = new System.Drawing.Point(3, 3);
			txtPasswords.Multiline = true;
			txtPasswords.Name = "txtPasswords";
			txtPasswords.Size = new System.Drawing.Size(786, 468);
			txtPasswords.TabIndex = 0;
			tabPage4.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			tabPage4.Controls.Add(txtCookies);
			tabPage4.Location = new System.Drawing.Point(4, 44);
			tabPage4.Name = "tabPage4";
			tabPage4.Padding = new System.Windows.Forms.Padding(3);
			tabPage4.Size = new System.Drawing.Size(792, 474);
			tabPage4.TabIndex = 3;
			tabPage4.Text = "Cookies";
			txtCookies.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			txtCookies.BorderStyle = System.Windows.Forms.BorderStyle.None;
			txtCookies.Dock = System.Windows.Forms.DockStyle.Fill;
			txtCookies.ForeColor = System.Drawing.Color.LightGray;
			txtCookies.Location = new System.Drawing.Point(3, 3);
			txtCookies.Multiline = true;
			txtCookies.Name = "txtCookies";
			txtCookies.Size = new System.Drawing.Size(786, 468);
			txtCookies.TabIndex = 1;
			guna2Panel1.Controls.Add(guna2PictureBox1);
			guna2Panel1.Controls.Add(guna2Separator1);
			guna2Panel1.Controls.Add(pictureBox1);
			guna2Panel1.Controls.Add(label15);
			guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			guna2Panel1.Location = new System.Drawing.Point(0, 0);
			guna2Panel1.Name = "guna2Panel1";
			guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
			guna2Panel1.Size = new System.Drawing.Size(800, 72);
			guna2Panel1.TabIndex = 137;
			guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
			guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
			guna2PictureBox1.ImageRotate = 0f;
			guna2PictureBox1.Location = new System.Drawing.Point(759, 12);
			guna2PictureBox1.Name = "guna2PictureBox1";
			guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
			guna2PictureBox1.Size = new System.Drawing.Size(29, 27);
			guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox1.TabIndex = 114;
			guna2PictureBox1.TabStop = false;
			guna2PictureBox1.UseTransparentBackground = true;
			guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
			guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator1.BackColor = System.Drawing.Color.Transparent;
			guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2Separator1.Location = new System.Drawing.Point(-198, 66);
			guna2Separator1.Name = "guna2Separator1";
			guna2Separator1.Size = new System.Drawing.Size(1197, 11);
			guna2Separator1.TabIndex = 13;
			guna2Separator1.UseTransparentBackground = true;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(12, 13);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(40, 46);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 12;
			pictureBox1.TabStop = false;
			label15.AutoSize = true;
			label15.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label15.Location = new System.Drawing.Point(352, 25);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(101, 19);
			label15.TabIndex = 11;
			label15.Text = "RECOVERY";
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(800, 603);
			base.Controls.Add(guna2Panel1);
			base.Controls.Add(guna2TabControl1);
			Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ForeColor = System.Drawing.Color.LightGray;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FrmReco";
			Text = "FrmReco";
			base.Load += new System.EventHandler(FrmReco_Load);
			guna2TabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			tabPage4.ResumeLayout(false);
			tabPage4.PerformLayout();
			guna2Panel1.ResumeLayout(false);
			guna2Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}
	}
}