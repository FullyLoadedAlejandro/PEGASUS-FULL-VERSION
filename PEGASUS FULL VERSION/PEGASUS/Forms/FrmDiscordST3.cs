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

	public class FrmDiscordST3 : Form
	{
		public bool IsOK;

		private IContainer components;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2Panel guna2Panel1;

		private Guna2PictureBox guna2PictureBox1;

		private Guna2Separator guna2Separator1;

		private PictureBox pictureBox1;

		private Label label15;

		public Guna2GradientButton button3;

		public Guna2GradientButton button2;

		private Label label2;

		private Guna2GroupBox GroupTel;

		private Label label1;

		private Guna2CheckBox chkTel;

		private Guna2GroupBox GroupDisc;

		private Guna2CheckBox chkDisc;

		private Guna2ShadowForm guna2ShadowForm1;

		private Guna2TextBox txtWebHook;

		private Guna2TextBox txtTelID;

		private Guna2TextBox txtTelApi;

		public FrmDiscordST3()
		{
			InitializeComponent();
		}

		private void guna2PictureBox1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void chkDisc_CheckedChanged(object sender, EventArgs e)
		{
			if (chkDisc.Checked)
			{
				GroupDisc.Enabled = true;
			}
			else
			{
				GroupDisc.Enabled = false;
			}
		}

		private void chkTel_CheckedChanged(object sender, EventArgs e)
		{
			if (chkTel.Checked)
			{
				GroupTel.Enabled = true;
			}
			else
			{
				GroupTel.Enabled = false;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (chkDisc.Checked)
			{
				PEGASUS.Properties.Settings.Default.WebHook = txtWebHook.Text;
				PEGASUS.Properties.Settings.Default.Save();
				if (IsOK)
				{
					Hide();
				}
			}
			else if (chkTel.Checked)
			{
				PEGASUS.Properties.Settings.Default.TelAPI = txtTelApi.Text;
				PEGASUS.Properties.Settings.Default.TelID = txtTelID.Text;
				PEGASUS.Properties.Settings.Default.Save();
				if (IsOK)
				{
					Hide();
				}
			}
			Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			IsOK = false;
			Hide();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDiscordST3));
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label15 = new System.Windows.Forms.Label();
			button3 = new Guna.UI2.WinForms.Guna2GradientButton();
			button2 = new Guna.UI2.WinForms.Guna2GradientButton();
			label2 = new System.Windows.Forms.Label();
			GroupDisc = new Guna.UI2.WinForms.Guna2GroupBox();
			txtWebHook = new Guna.UI2.WinForms.Guna2TextBox();
			chkDisc = new Guna.UI2.WinForms.Guna2CheckBox();
			chkTel = new Guna.UI2.WinForms.Guna2CheckBox();
			GroupTel = new Guna.UI2.WinForms.Guna2GroupBox();
			txtTelID = new Guna.UI2.WinForms.Guna2TextBox();
			txtTelApi = new Guna.UI2.WinForms.Guna2TextBox();
			label1 = new System.Windows.Forms.Label();
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			GroupDisc.SuspendLayout();
			GroupTel.SuspendLayout();
			SuspendLayout();
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2Panel1.Controls.Add(guna2PictureBox1);
			guna2Panel1.Controls.Add(guna2Separator1);
			guna2Panel1.Controls.Add(pictureBox1);
			guna2Panel1.Controls.Add(label15);
			guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			guna2Panel1.Location = new System.Drawing.Point(0, 0);
			guna2Panel1.Name = "guna2Panel1";
			guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
			guna2Panel1.Size = new System.Drawing.Size(792, 72);
			guna2Panel1.TabIndex = 138;
			guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
			guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
			guna2PictureBox1.ImageRotate = 0f;
			guna2PictureBox1.Location = new System.Drawing.Point(751, 12);
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
			guna2Separator1.Size = new System.Drawing.Size(1189, 11);
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
			label15.ForeColor = System.Drawing.Color.LightGray;
			label15.Location = new System.Drawing.Point(247, 25);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(290, 19);
			label15.TabIndex = 11;
			label15.Text = "DISCORD/TELEGRAM  RECOVERY";
			button3.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			button3.BorderThickness = 1;
			button3.CheckedState.Parent = button3;
			button3.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			button3.CustomImages.Parent = button3;
			button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			button3.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			button3.DisabledState.Parent = button3;
			button3.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			button3.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			button3.Font = new System.Drawing.Font("Electrolize", 9f);
			button3.ForeColor = System.Drawing.Color.White;
			button3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			button3.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			button3.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			button3.HoverState.ForeColor = System.Drawing.Color.LightGray;
			button3.HoverState.Parent = button3;
			button3.Location = new System.Drawing.Point(626, 536);
			button3.Name = "button3";
			button3.ShadowDecoration.Parent = button3;
			button3.Size = new System.Drawing.Size(136, 30);
			button3.TabIndex = 149;
			button3.Text = "Cancel";
			button3.Click += new System.EventHandler(button3_Click);
			button2.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			button2.BorderThickness = 1;
			button2.CheckedState.Parent = button2;
			button2.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			button2.CustomImages.Parent = button2;
			button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			button2.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			button2.DisabledState.Parent = button2;
			button2.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			button2.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			button2.Font = new System.Drawing.Font("Electrolize", 9f);
			button2.ForeColor = System.Drawing.Color.White;
			button2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			button2.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			button2.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			button2.HoverState.ForeColor = System.Drawing.Color.LightGray;
			button2.HoverState.Parent = button2;
			button2.Location = new System.Drawing.Point(31, 536);
			button2.Name = "button2";
			button2.ShadowDecoration.Parent = button2;
			button2.Size = new System.Drawing.Size(136, 30);
			button2.TabIndex = 148;
			button2.Text = "Ok";
			button2.Click += new System.EventHandler(button2_Click);
			label2.AutoSize = true;
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.ForeColor = System.Drawing.Color.LightGray;
			label2.Location = new System.Drawing.Point(12, 72);
			label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(38, 15);
			label2.TabIndex = 147;
			label2.Text = "Input:";
			GroupDisc.BorderColor = System.Drawing.Color.FromArgb(26, 26, 26);
			GroupDisc.Controls.Add(txtWebHook);
			GroupDisc.Controls.Add(label2);
			GroupDisc.CustomBorderColor = System.Drawing.Color.FromArgb(27, 27, 27);
			GroupDisc.Enabled = false;
			GroupDisc.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			GroupDisc.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			GroupDisc.ForeColor = System.Drawing.Color.LightGray;
			GroupDisc.Location = new System.Drawing.Point(31, 107);
			GroupDisc.Name = "GroupDisc";
			GroupDisc.ShadowDecoration.Parent = GroupDisc;
			GroupDisc.Size = new System.Drawing.Size(731, 167);
			GroupDisc.TabIndex = 152;
			GroupDisc.Text = "Discord Options";
			txtWebHook.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtWebHook.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtWebHook.DefaultText = "";
			txtWebHook.DisabledState.BorderColor = System.Drawing.Color.DimGray;
			txtWebHook.DisabledState.FillColor = System.Drawing.Color.FromArgb(20, 20, 20);
			txtWebHook.DisabledState.ForeColor = System.Drawing.Color.DimGray;
			txtWebHook.DisabledState.Parent = txtWebHook;
			txtWebHook.DisabledState.PlaceholderForeColor = System.Drawing.Color.DimGray;
			txtWebHook.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			txtWebHook.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtWebHook.FocusedState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			txtWebHook.FocusedState.ForeColor = System.Drawing.Color.LightGray;
			txtWebHook.FocusedState.Parent = txtWebHook;
			txtWebHook.FocusedState.PlaceholderForeColor = System.Drawing.Color.Gray;
			txtWebHook.Font = new System.Drawing.Font("Segoe UI", 9f);
			txtWebHook.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtWebHook.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			txtWebHook.HoverState.ForeColor = System.Drawing.Color.LightGray;
			txtWebHook.HoverState.Parent = txtWebHook;
			txtWebHook.HoverState.PlaceholderForeColor = System.Drawing.Color.Gray;
			txtWebHook.Location = new System.Drawing.Point(14, 90);
			txtWebHook.Name = "txtWebHook";
			txtWebHook.PasswordChar = '\0';
			txtWebHook.PlaceholderText = "WebHook";
			txtWebHook.SelectedText = "";
			txtWebHook.ShadowDecoration.Parent = txtWebHook;
			txtWebHook.Size = new System.Drawing.Size(702, 30);
			txtWebHook.TabIndex = 151;
			chkDisc.AutoSize = true;
			chkDisc.CheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			chkDisc.CheckedState.BorderRadius = 0;
			chkDisc.CheckedState.BorderThickness = 1;
			chkDisc.CheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			chkDisc.CheckMarkColor = System.Drawing.Color.FromArgb(191, 37, 33);
			chkDisc.Font = new System.Drawing.Font("Electrolize", 8.249999f);
			chkDisc.Location = new System.Drawing.Point(31, 83);
			chkDisc.Name = "chkDisc";
			chkDisc.Size = new System.Drawing.Size(106, 18);
			chkDisc.TabIndex = 151;
			chkDisc.Text = "Send to Discord";
			chkDisc.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			chkDisc.UncheckedState.BorderRadius = 0;
			chkDisc.UncheckedState.BorderThickness = 1;
			chkDisc.UncheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			chkDisc.CheckedChanged += new System.EventHandler(chkDisc_CheckedChanged);
			chkTel.AutoSize = true;
			chkTel.CheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			chkTel.CheckedState.BorderRadius = 0;
			chkTel.CheckedState.BorderThickness = 1;
			chkTel.CheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			chkTel.CheckMarkColor = System.Drawing.Color.FromArgb(191, 37, 33);
			chkTel.Font = new System.Drawing.Font("Electrolize", 8.249999f);
			chkTel.Location = new System.Drawing.Point(31, 291);
			chkTel.Name = "chkTel";
			chkTel.Size = new System.Drawing.Size(114, 18);
			chkTel.TabIndex = 153;
			chkTel.Text = "Send to Telegram";
			chkTel.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			chkTel.UncheckedState.BorderRadius = 0;
			chkTel.UncheckedState.BorderThickness = 1;
			chkTel.UncheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			chkTel.CheckedChanged += new System.EventHandler(chkTel_CheckedChanged);
			GroupTel.BorderColor = System.Drawing.Color.FromArgb(26, 26, 26);
			GroupTel.Controls.Add(txtTelID);
			GroupTel.Controls.Add(txtTelApi);
			GroupTel.Controls.Add(label1);
			GroupTel.CustomBorderColor = System.Drawing.Color.FromArgb(27, 27, 27);
			GroupTel.Enabled = false;
			GroupTel.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			GroupTel.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			GroupTel.ForeColor = System.Drawing.Color.LightGray;
			GroupTel.Location = new System.Drawing.Point(31, 315);
			GroupTel.Name = "GroupTel";
			GroupTel.ShadowDecoration.Parent = GroupTel;
			GroupTel.Size = new System.Drawing.Size(731, 167);
			GroupTel.TabIndex = 154;
			GroupTel.Text = "Telegram Options";
			txtTelID.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtTelID.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtTelID.DefaultText = "";
			txtTelID.DisabledState.BorderColor = System.Drawing.Color.DimGray;
			txtTelID.DisabledState.FillColor = System.Drawing.Color.FromArgb(20, 20, 20);
			txtTelID.DisabledState.ForeColor = System.Drawing.Color.DimGray;
			txtTelID.DisabledState.Parent = txtTelID;
			txtTelID.DisabledState.PlaceholderForeColor = System.Drawing.Color.DimGray;
			txtTelID.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			txtTelID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtTelID.FocusedState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			txtTelID.FocusedState.ForeColor = System.Drawing.Color.LightGray;
			txtTelID.FocusedState.Parent = txtTelID;
			txtTelID.FocusedState.PlaceholderForeColor = System.Drawing.Color.Gray;
			txtTelID.Font = new System.Drawing.Font("Segoe UI", 9f);
			txtTelID.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtTelID.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			txtTelID.HoverState.ForeColor = System.Drawing.Color.LightGray;
			txtTelID.HoverState.Parent = txtTelID;
			txtTelID.HoverState.PlaceholderForeColor = System.Drawing.Color.Gray;
			txtTelID.Location = new System.Drawing.Point(14, 107);
			txtTelID.Name = "txtTelID";
			txtTelID.PasswordChar = '\0';
			txtTelID.PlaceholderText = "TelegramID";
			txtTelID.SelectedText = "";
			txtTelID.ShadowDecoration.Parent = txtTelID;
			txtTelID.Size = new System.Drawing.Size(702, 30);
			txtTelID.TabIndex = 152;
			txtTelApi.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtTelApi.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtTelApi.DefaultText = "";
			txtTelApi.DisabledState.BorderColor = System.Drawing.Color.DimGray;
			txtTelApi.DisabledState.FillColor = System.Drawing.Color.FromArgb(20, 20, 20);
			txtTelApi.DisabledState.ForeColor = System.Drawing.Color.DimGray;
			txtTelApi.DisabledState.Parent = txtTelApi;
			txtTelApi.DisabledState.PlaceholderForeColor = System.Drawing.Color.DimGray;
			txtTelApi.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			txtTelApi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtTelApi.FocusedState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			txtTelApi.FocusedState.ForeColor = System.Drawing.Color.LightGray;
			txtTelApi.FocusedState.Parent = txtTelApi;
			txtTelApi.FocusedState.PlaceholderForeColor = System.Drawing.Color.Gray;
			txtTelApi.Font = new System.Drawing.Font("Segoe UI", 9f);
			txtTelApi.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtTelApi.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			txtTelApi.HoverState.ForeColor = System.Drawing.Color.LightGray;
			txtTelApi.HoverState.Parent = txtTelApi;
			txtTelApi.HoverState.PlaceholderForeColor = System.Drawing.Color.Gray;
			txtTelApi.Location = new System.Drawing.Point(14, 71);
			txtTelApi.Name = "txtTelApi";
			txtTelApi.PasswordChar = '\0';
			txtTelApi.PlaceholderText = "TelegramAPI";
			txtTelApi.SelectedText = "";
			txtTelApi.ShadowDecoration.Parent = txtTelApi;
			txtTelApi.Size = new System.Drawing.Size(702, 30);
			txtTelApi.TabIndex = 153;
			label1.AutoSize = true;
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.ForeColor = System.Drawing.Color.LightGray;
			label1.Location = new System.Drawing.Point(12, 48);
			label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(38, 15);
			label1.TabIndex = 147;
			label1.Text = "Input:";
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(792, 596);
			base.Controls.Add(GroupTel);
			base.Controls.Add(chkTel);
			base.Controls.Add(GroupDisc);
			base.Controls.Add(chkDisc);
			base.Controls.Add(button3);
			base.Controls.Add(button2);
			base.Controls.Add(guna2Panel1);
			ForeColor = System.Drawing.Color.LightGray;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FrmDiscordST3";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "FrmDiscordST3";
			guna2Panel1.ResumeLayout(false);
			guna2Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			GroupDisc.ResumeLayout(false);
			GroupDisc.PerformLayout();
			GroupTel.ResumeLayout(false);
			GroupTel.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}