using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PEGASUS.Pegasus;
using PEGASUS.Properties;

namespace PEGASUS.Forms
{

	public class Welcome : Form
	{
		private IContainer components;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2PictureBox guna2PictureBox3;

		private Guna2PictureBox guna2PictureBox2;

		private Guna2PictureBox guna2PictureBox1;

		private Guna2PictureBox guna2PictureBox5;

		private Guna2Panel guna2Panel1;

		private Guna2Separator guna2Separator1;

		private PictureBox pictureBox1;

		private Label label1;

		private Guna2PictureBox guna2PictureBox7;

		private Guna2PictureBox guna2PictureBox4;

		private ToolTip toolTip1;

		private Guna2PictureBox guna2PictureBox6;

		private Guna2GradientButton btnIcon;

		public Welcome()
		{
			InitializeComponent();
		}

		private void guna2PictureBox1_Click(object sender, EventArgs e)
		{
			Process.Start("https://discord.gg/w2hVN45E");
		}

		private void guna2PictureBox2_Click(object sender, EventArgs e)
		{
			MsgBox.Show("SkynetCorporation@protonmail.com");
		}

		private void guna2PictureBox3_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.youtube.com/channel/UCd6mDeM9gLKOMlbUGynEUbQ");
		}

		private void guna2PictureBox4_Click(object sender, EventArgs e)
		{
		}

		private void guna2PictureBox5_Click(object sender, EventArgs e)
		{
			Process.Start("https://skynet-corporation.com/");
		}

		private void guna2PictureBox4_Click_1(object sender, EventArgs e)
		{
			Process.Start("https://t.me/joinchat/Izuv0GvwIOU3ZTNk");
		}

		private void guna2PictureBox7_Click(object sender, EventArgs e)
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

		private static string reupload(string str)
		{
			char c = '\n';
			StringBuilder stringBuilder = new StringBuilder();
			char[] array = str.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				char value = (char)(array[i] ^ c);
				stringBuilder.Append(value);
			}
			return stringBuilder.ToString();
		}

		public static void DeleteDirectory(string target_dir)
		{
			string[] files = Directory.GetFiles(target_dir);
			string[] directories = Directory.GetDirectories(target_dir);
			string[] array = files;
			foreach (string path in array)
			{
				File.SetAttributes(path, FileAttributes.Normal);
				File.Delete(path);
			}
			array = directories;
			for (int i = 0; i < array.Length; i++)
			{
				DeleteDirectory(array[i]);
			}
			Directory.Delete(target_dir, recursive: false);
		}

		private void btnIcon_Click(object sender, EventArgs e)
		{
			Hide();
			ABC.abgd(reupload("ZOMKY_YL_FF"), reupload("82:<??"), "3xiUwGhkAtLTJwExKH00BLkC89apvFTwypK", reupload(";$:$:$>"));
			using FormPorts formPorts = new FormPorts();
			formPorts.ShowDialog();
		}

		private void Welcome_Load(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
			guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
			guna2PictureBox5 = new Guna.UI2.WinForms.Guna2PictureBox();
			guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			label1 = new System.Windows.Forms.Label();
			guna2PictureBox7 = new Guna.UI2.WinForms.Guna2PictureBox();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			guna2PictureBox4 = new Guna.UI2.WinForms.Guna2PictureBox();
			toolTip1 = new System.Windows.Forms.ToolTip(components);
			guna2PictureBox6 = new Guna.UI2.WinForms.Guna2PictureBox();
			btnIcon = new Guna.UI2.WinForms.Guna2GradientButton();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox3).BeginInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox5).BeginInit();
			guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox7).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox4).BeginInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox6).BeginInit();
			SuspendLayout();
			guna2BorderlessForm1.ContainerControl = this;
			guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox1.Image = Properties.Resources.discordicon;
			guna2PictureBox1.ImageRotate = 0f;
			guna2PictureBox1.Location = new System.Drawing.Point(185, 321);
			guna2PictureBox1.Name = "guna2PictureBox1";
			guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
			guna2PictureBox1.Size = new System.Drawing.Size(64, 69);
			guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			guna2PictureBox1.TabIndex = 0;
			guna2PictureBox1.TabStop = false;
			toolTip1.SetToolTip(guna2PictureBox1, "Discord Channel!");
			guna2PictureBox1.UseTransparentBackground = true;
			guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
			guna2PictureBox2.Image = Properties.Resources.email;
			guna2PictureBox2.ImageRotate = 0f;
			guna2PictureBox2.Location = new System.Drawing.Point(277, 321);
			guna2PictureBox2.Name = "guna2PictureBox2";
			guna2PictureBox2.ShadowDecoration.Parent = guna2PictureBox2;
			guna2PictureBox2.Size = new System.Drawing.Size(64, 64);
			guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			guna2PictureBox2.TabIndex = 1;
			guna2PictureBox2.TabStop = false;
			toolTip1.SetToolTip(guna2PictureBox2, "Our new Email!");
			guna2PictureBox2.Click += new System.EventHandler(guna2PictureBox2_Click);
			guna2PictureBox3.Image = Properties.Resources.youtube_icon;
			guna2PictureBox3.ImageRotate = 0f;
			guna2PictureBox3.Location = new System.Drawing.Point(369, 321);
			guna2PictureBox3.Name = "guna2PictureBox3";
			guna2PictureBox3.ShadowDecoration.Parent = guna2PictureBox3;
			guna2PictureBox3.Size = new System.Drawing.Size(64, 69);
			guna2PictureBox3.TabIndex = 2;
			guna2PictureBox3.TabStop = false;
			toolTip1.SetToolTip(guna2PictureBox3, "Our New Youtube Channel!");
			guna2PictureBox3.Click += new System.EventHandler(guna2PictureBox3_Click);
			guna2PictureBox5.Image = Properties.Resources.site;
			guna2PictureBox5.ImageRotate = 0f;
			guna2PictureBox5.Location = new System.Drawing.Point(553, 321);
			guna2PictureBox5.Name = "guna2PictureBox5";
			guna2PictureBox5.ShadowDecoration.Parent = guna2PictureBox5;
			guna2PictureBox5.Size = new System.Drawing.Size(64, 69);
			guna2PictureBox5.TabIndex = 4;
			guna2PictureBox5.TabStop = false;
			toolTip1.SetToolTip(guna2PictureBox5, "Our New Website/Shop !");
			guna2PictureBox5.Click += new System.EventHandler(guna2PictureBox5_Click);
			guna2Panel1.Controls.Add(label1);
			guna2Panel1.Controls.Add(guna2PictureBox7);
			guna2Panel1.Controls.Add(guna2Separator1);
			guna2Panel1.Controls.Add(pictureBox1);
			guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			guna2Panel1.Location = new System.Drawing.Point(0, 0);
			guna2Panel1.Name = "guna2Panel1";
			guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
			guna2Panel1.Size = new System.Drawing.Size(800, 72);
			guna2Panel1.TabIndex = 15;
			guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.Color.LightGray;
			label1.Location = new System.Drawing.Point(358, 25);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(77, 19);
			label1.TabIndex = 15;
			label1.Text = "UPDATE";
			guna2PictureBox7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox7.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox7.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox7.Image");
			guna2PictureBox7.ImageRotate = 0f;
			guna2PictureBox7.Location = new System.Drawing.Point(759, 13);
			guna2PictureBox7.Name = "guna2PictureBox7";
			guna2PictureBox7.ShadowDecoration.Parent = guna2PictureBox7;
			guna2PictureBox7.Size = new System.Drawing.Size(29, 29);
			guna2PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox7.TabIndex = 14;
			guna2PictureBox7.TabStop = false;
			guna2PictureBox7.UseTransparentBackground = true;
			guna2PictureBox7.Click += new System.EventHandler(guna2PictureBox7_Click);
			guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator1.BackColor = System.Drawing.Color.Transparent;
			guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2Separator1.Location = new System.Drawing.Point(-250, 66);
			guna2Separator1.Name = "guna2Separator1";
			guna2Separator1.Size = new System.Drawing.Size(1300, 11);
			guna2Separator1.TabIndex = 13;
			guna2Separator1.UseTransparentBackground = true;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(12, 13);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(40, 45);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 12;
			pictureBox1.TabStop = false;
			guna2PictureBox4.Image = Properties.Resources.telegram;
			guna2PictureBox4.ImageRotate = 0f;
			guna2PictureBox4.Location = new System.Drawing.Point(461, 321);
			guna2PictureBox4.Name = "guna2PictureBox4";
			guna2PictureBox4.ShadowDecoration.Parent = guna2PictureBox4;
			guna2PictureBox4.Size = new System.Drawing.Size(64, 64);
			guna2PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			guna2PictureBox4.TabIndex = 16;
			guna2PictureBox4.TabStop = false;
			toolTip1.SetToolTip(guna2PictureBox4, "Our New Telegram Channel!");
			guna2PictureBox4.Click += new System.EventHandler(guna2PictureBox4_Click_1);
			toolTip1.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
			toolTip1.ForeColor = System.Drawing.Color.LightGray;
			toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			toolTip1.ToolTipTitle = "Skynet!";
			guna2PictureBox6.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox6.Dock = System.Windows.Forms.DockStyle.Fill;
			guna2PictureBox6.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox6.Image");
			guna2PictureBox6.ImageRotate = 0f;
			guna2PictureBox6.Location = new System.Drawing.Point(0, 0);
			guna2PictureBox6.Name = "guna2PictureBox6";
			guna2PictureBox6.ShadowDecoration.Parent = guna2PictureBox6;
			guna2PictureBox6.Size = new System.Drawing.Size(800, 485);
			guna2PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox6.TabIndex = 17;
			guna2PictureBox6.TabStop = false;
			guna2PictureBox6.UseTransparentBackground = true;
			btnIcon.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			btnIcon.BorderThickness = 1;
			btnIcon.CheckedState.Parent = btnIcon;
			btnIcon.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnIcon.CustomImages.Parent = btnIcon;
			btnIcon.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			btnIcon.DisabledState.CustomBorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
			btnIcon.DisabledState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnIcon.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btnIcon.DisabledState.ForeColor = System.Drawing.Color.DimGray;
			btnIcon.DisabledState.Parent = btnIcon;
			btnIcon.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnIcon.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btnIcon.Font = new System.Drawing.Font("Electrolize", 9f);
			btnIcon.ForeColor = System.Drawing.Color.White;
			btnIcon.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnIcon.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnIcon.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnIcon.HoverState.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btnIcon.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnIcon.HoverState.Parent = btnIcon;
			btnIcon.Location = new System.Drawing.Point(306, 429);
			btnIcon.Name = "btnIcon";
			btnIcon.ShadowDecoration.Parent = btnIcon;
			btnIcon.Size = new System.Drawing.Size(182, 32);
			btnIcon.TabIndex = 125;
			btnIcon.Text = "ok";
			btnIcon.Click += new System.EventHandler(btnIcon_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
			BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
			base.ClientSize = new System.Drawing.Size(800, 485);
			base.Controls.Add(btnIcon);
			base.Controls.Add(guna2PictureBox4);
			base.Controls.Add(guna2PictureBox5);
			base.Controls.Add(guna2PictureBox3);
			base.Controls.Add(guna2PictureBox2);
			base.Controls.Add(guna2PictureBox1);
			base.Controls.Add(guna2Panel1);
			base.Controls.Add(guna2PictureBox6);
			Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ForeColor = System.Drawing.Color.LightGray;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Welcome";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Welcome";
			base.TopMost = true;
			base.Load += new System.EventHandler(Welcome_Load);
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox3).EndInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox5).EndInit();
			guna2Panel1.ResumeLayout(false);
			guna2Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox7).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox4).EndInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox6).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}