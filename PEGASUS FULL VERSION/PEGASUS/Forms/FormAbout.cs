using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PEGASUS.Pegasus;
using SharpUpdate;

namespace PEGASUS.Forms
{

	public class FormAbout : Form
	{
		public static string userid = "ID:" + Convert.ToString(User.ID);

		public static string usersname = User.Username;

		public static string expirys = "Expiry Date:" + Convert.ToString(User.Expiry);

		public static string registerdates = "Registration Date:" + Convert.ToString(User.RegisterDate);

		public static string email = "Email:" + User.Email;

		public static string hwid = "HWID:" + Convert.ToString(User.HWID);

		public static string uservariable = "User Variable:" + Convert.ToString(User.UserVariable);

		public static string userrank = "Rank:" + Convert.ToString(User.Rank);

		public static string ip = "IP:" + Convert.ToString(User.IP);

		public static string lastlogin = "Last Login:" + Convert.ToString(User.LastLogin);

		public static string Version = "Last Login:" + Convert.ToString(ApplicationSettings.Version);

		public string mauro = bytestopng("b~~zy0%%|odegellcickf$do~%_znk~82|%zxe`oi~$rgf");

		private SharpUpdater updater;

		public static string IV = "qo1lc3sjd8zpt9cx";

		public static string Key = "ow7dxys8glfor9tnc2ansdfo1etkfjcv";

		private IContainer components;

		private Guna2PictureBox guna2PictureBox1;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2Panel guna2Panel1;

		private Guna2Separator guna2Separator1;

		private PictureBox pictureBox1;

		private Label label1;

		private Guna2GradientButton btnUpdate;

		private Guna2GradientButton guna2GradientButton1;

		private Label txtLastlogin;

		private Label txtUserRank;

		private Label txtHwid;

		private Label txtEmail;

		private Label expiry;

		private Label registerdate;

		private Label username;

		private Label label8;

		private Label label7;

		private Label label6;

		private Label label5;

		private Label label4;

		private Label label3;

		private Label label2;

		private Label txtVersion;

		private Label label9;

		private Guna2GroupBox guna2GroupBox1;

		private Guna2PictureBox guna2PictureBox2;

		private Guna2ShadowForm guna2ShadowForm1;

		public FormAbout()
		{
			InitializeComponent();
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

		private void FormAbout_Load(object sender, EventArgs e)
		{
			username.Text = User.Username;
			expiry.Text = User.Expiry;
			registerdate.Text = User.RegisterDate;
			txtEmail.Text = User.Email;
			txtHwid.Text = User.HWID;
			txtUserRank.Text = User.Rank;
			txtLastlogin.Text = User.LastLogin;
			txtVersion.Text = base.ProductName + base.ProductVersion;
			updater = new SharpUpdater(Assembly.GetExecutingAssembly(), this, new Uri(mauro));
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			updater.DoUpdate();
		}

		public static string Encrypt(string decrypted)
		{
			byte[] bytes = Encoding.ASCII.GetBytes(decrypted);
			AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider();
			aesCryptoServiceProvider.BlockSize = 128;
			aesCryptoServiceProvider.KeySize = 256;
			aesCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(Key);
			aesCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(IV);
			aesCryptoServiceProvider.Padding = PaddingMode.PKCS7;
			aesCryptoServiceProvider.Mode = CipherMode.CBC;
			ICryptoTransform cryptoTransform = aesCryptoServiceProvider.CreateEncryptor(aesCryptoServiceProvider.Key, aesCryptoServiceProvider.IV);
			byte[] inArray = cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length);
			cryptoTransform.Dispose();
			return Convert.ToBase64String(inArray);
		}

		public static string Decrypt(string encrypted)
		{
			byte[] array = Convert.FromBase64String(encrypted);
			AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider();
			aesCryptoServiceProvider.BlockSize = 128;
			aesCryptoServiceProvider.KeySize = 256;
			aesCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(Key);
			aesCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(IV);
			aesCryptoServiceProvider.Padding = PaddingMode.PKCS7;
			aesCryptoServiceProvider.Mode = CipherMode.CBC;
			ICryptoTransform cryptoTransform = aesCryptoServiceProvider.CreateDecryptor(aesCryptoServiceProvider.Key, aesCryptoServiceProvider.IV);
			byte[] bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
			cryptoTransform.Dispose();
			return Encoding.ASCII.GetString(bytes);
		}

		public static string bytestopng(string str)
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

		private void guna2GradientButton1_Click(object sender, EventArgs e)
		{
			Process.Start("https://skynet-corporation.com/shop/");
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
			guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label1 = new System.Windows.Forms.Label();
			guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
			btnUpdate = new Guna.UI2.WinForms.Guna2GradientButton();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			username = new System.Windows.Forms.Label();
			registerdate = new System.Windows.Forms.Label();
			expiry = new System.Windows.Forms.Label();
			txtEmail = new System.Windows.Forms.Label();
			txtHwid = new System.Windows.Forms.Label();
			txtUserRank = new System.Windows.Forms.Label();
			txtLastlogin = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			txtVersion = new System.Windows.Forms.Label();
			guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
			guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
			guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			guna2GroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox2).BeginInit();
			SuspendLayout();
			guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
			guna2PictureBox1.ImageRotate = 0f;
			guna2PictureBox1.Location = new System.Drawing.Point(596, 12);
			guna2PictureBox1.Name = "guna2PictureBox1";
			guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
			guna2PictureBox1.Size = new System.Drawing.Size(29, 27);
			guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox1.TabIndex = 6;
			guna2PictureBox1.TabStop = false;
			guna2PictureBox1.UseTransparentBackground = true;
			guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2Panel1.Controls.Add(guna2Separator1);
			guna2Panel1.Controls.Add(pictureBox1);
			guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			guna2Panel1.Location = new System.Drawing.Point(0, 0);
			guna2Panel1.Name = "guna2Panel1";
			guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
			guna2Panel1.Size = new System.Drawing.Size(637, 67);
			guna2Panel1.TabIndex = 14;
			guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
			guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator1.BackColor = System.Drawing.Color.Transparent;
			guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2Separator1.Location = new System.Drawing.Point(-250, 61);
			guna2Separator1.Name = "guna2Separator1";
			guna2Separator1.Size = new System.Drawing.Size(1137, 10);
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
			label1.Location = new System.Drawing.Point(281, 18);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(67, 19);
			label1.TabIndex = 11;
			label1.Text = "ABOUT";
			guna2GradientButton1.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			guna2GradientButton1.BorderThickness = 1;
			guna2GradientButton1.CheckedState.Parent = guna2GradientButton1;
			guna2GradientButton1.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			guna2GradientButton1.CustomImages.Parent = guna2GradientButton1;
			guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			guna2GradientButton1.DisabledState.Parent = guna2GradientButton1;
			guna2GradientButton1.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2GradientButton1.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2GradientButton1.Font = new System.Drawing.Font("Electrolize", 9f);
			guna2GradientButton1.ForeColor = System.Drawing.Color.White;
			guna2GradientButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			guna2GradientButton1.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			guna2GradientButton1.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2GradientButton1.HoverState.ForeColor = System.Drawing.Color.LightGray;
			guna2GradientButton1.HoverState.Parent = guna2GradientButton1;
			guna2GradientButton1.Location = new System.Drawing.Point(12, 321);
			guna2GradientButton1.Name = "guna2GradientButton1";
			guna2GradientButton1.ShadowDecoration.Parent = guna2GradientButton1;
			guna2GradientButton1.Size = new System.Drawing.Size(200, 32);
			guna2GradientButton1.TabIndex = 15;
			guna2GradientButton1.Text = "Donate";
			guna2GradientButton1.Click += new System.EventHandler(guna2GradientButton1_Click);
			btnUpdate.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			btnUpdate.BorderThickness = 1;
			btnUpdate.CheckedState.Parent = btnUpdate;
			btnUpdate.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnUpdate.CustomImages.Parent = btnUpdate;
			btnUpdate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			btnUpdate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			btnUpdate.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			btnUpdate.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			btnUpdate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			btnUpdate.DisabledState.Parent = btnUpdate;
			btnUpdate.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnUpdate.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btnUpdate.Font = new System.Drawing.Font("Electrolize", 9f);
			btnUpdate.ForeColor = System.Drawing.Color.White;
			btnUpdate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnUpdate.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnUpdate.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			btnUpdate.HoverState.ForeColor = System.Drawing.Color.LightGray;
			btnUpdate.HoverState.Parent = btnUpdate;
			btnUpdate.Location = new System.Drawing.Point(425, 321);
			btnUpdate.Name = "btnUpdate";
			btnUpdate.ShadowDecoration.Parent = btnUpdate;
			btnUpdate.Size = new System.Drawing.Size(200, 32);
			btnUpdate.TabIndex = 16;
			btnUpdate.Text = "Update";
			btnUpdate.Visible = false;
			btnUpdate.Click += new System.EventHandler(btnUpdate_Click);
			label2.AutoSize = true;
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.ForeColor = System.Drawing.Color.LightGray;
			label2.Location = new System.Drawing.Point(18, 57);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(33, 15);
			label2.TabIndex = 17;
			label2.Text = "User:";
			label3.AutoSize = true;
			label3.BackColor = System.Drawing.Color.Transparent;
			label3.ForeColor = System.Drawing.Color.LightGray;
			label3.Location = new System.Drawing.Point(18, 77);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(73, 15);
			label3.TabIndex = 18;
			label3.Text = "Registration:";
			label4.AutoSize = true;
			label4.BackColor = System.Drawing.Color.Transparent;
			label4.ForeColor = System.Drawing.Color.LightGray;
			label4.Location = new System.Drawing.Point(18, 97);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(91, 15);
			label4.TabIndex = 19;
			label4.Text = "Experation date:";
			label5.AutoSize = true;
			label5.BackColor = System.Drawing.Color.Transparent;
			label5.ForeColor = System.Drawing.Color.LightGray;
			label5.Location = new System.Drawing.Point(18, 117);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(39, 15);
			label5.TabIndex = 20;
			label5.Text = "Email:";
			label6.AutoSize = true;
			label6.BackColor = System.Drawing.Color.Transparent;
			label6.ForeColor = System.Drawing.Color.LightGray;
			label6.Location = new System.Drawing.Point(18, 137);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(38, 15);
			label6.TabIndex = 21;
			label6.Text = "Hwid:";
			label7.AutoSize = true;
			label7.BackColor = System.Drawing.Color.Transparent;
			label7.ForeColor = System.Drawing.Color.LightGray;
			label7.Location = new System.Drawing.Point(18, 157);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(62, 15);
			label7.TabIndex = 22;
			label7.Text = "User Rank:";
			label8.AutoSize = true;
			label8.BackColor = System.Drawing.Color.Transparent;
			label8.ForeColor = System.Drawing.Color.LightGray;
			label8.Location = new System.Drawing.Point(18, 177);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(64, 15);
			label8.TabIndex = 23;
			label8.Text = "Last Login:";
			username.AutoSize = true;
			username.BackColor = System.Drawing.Color.Transparent;
			username.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			username.Location = new System.Drawing.Point(115, 58);
			username.Name = "username";
			username.Size = new System.Drawing.Size(38, 15);
			username.TabIndex = 24;
			username.Text = "label9";
			registerdate.AutoSize = true;
			registerdate.BackColor = System.Drawing.Color.Transparent;
			registerdate.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			registerdate.Location = new System.Drawing.Point(115, 78);
			registerdate.Name = "registerdate";
			registerdate.Size = new System.Drawing.Size(44, 15);
			registerdate.TabIndex = 25;
			registerdate.Text = "label10";
			expiry.AutoSize = true;
			expiry.BackColor = System.Drawing.Color.Transparent;
			expiry.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			expiry.Location = new System.Drawing.Point(115, 98);
			expiry.Name = "expiry";
			expiry.Size = new System.Drawing.Size(44, 15);
			expiry.TabIndex = 26;
			expiry.Text = "label11";
			txtEmail.AutoSize = true;
			txtEmail.BackColor = System.Drawing.Color.Transparent;
			txtEmail.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtEmail.Location = new System.Drawing.Point(115, 118);
			txtEmail.Name = "txtEmail";
			txtEmail.Size = new System.Drawing.Size(44, 15);
			txtEmail.TabIndex = 27;
			txtEmail.Text = "label12";
			txtHwid.AutoSize = true;
			txtHwid.BackColor = System.Drawing.Color.Transparent;
			txtHwid.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtHwid.Location = new System.Drawing.Point(115, 138);
			txtHwid.Name = "txtHwid";
			txtHwid.Size = new System.Drawing.Size(44, 15);
			txtHwid.TabIndex = 28;
			txtHwid.Text = "label13";
			txtUserRank.AutoSize = true;
			txtUserRank.BackColor = System.Drawing.Color.Transparent;
			txtUserRank.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtUserRank.Location = new System.Drawing.Point(115, 158);
			txtUserRank.Name = "txtUserRank";
			txtUserRank.Size = new System.Drawing.Size(44, 15);
			txtUserRank.TabIndex = 29;
			txtUserRank.Text = "label14";
			txtLastlogin.AutoSize = true;
			txtLastlogin.BackColor = System.Drawing.Color.Transparent;
			txtLastlogin.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtLastlogin.Location = new System.Drawing.Point(115, 178);
			txtLastlogin.Name = "txtLastlogin";
			txtLastlogin.Size = new System.Drawing.Size(44, 15);
			txtLastlogin.TabIndex = 30;
			txtLastlogin.Text = "label15";
			label9.AutoSize = true;
			label9.BackColor = System.Drawing.Color.Transparent;
			label9.ForeColor = System.Drawing.Color.LightGray;
			label9.Location = new System.Drawing.Point(18, 197);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(101, 15);
			label9.TabIndex = 31;
			label9.Text = "PEGASUS Version:";
			txtVersion.AutoSize = true;
			txtVersion.BackColor = System.Drawing.Color.Transparent;
			txtVersion.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtVersion.Location = new System.Drawing.Point(115, 198);
			txtVersion.Name = "txtVersion";
			txtVersion.Size = new System.Drawing.Size(44, 15);
			txtVersion.TabIndex = 32;
			txtVersion.Text = "label15";
			guna2GroupBox1.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2GroupBox1.Controls.Add(guna2PictureBox2);
			guna2GroupBox1.Controls.Add(txtVersion);
			guna2GroupBox1.Controls.Add(label2);
			guna2GroupBox1.Controls.Add(label9);
			guna2GroupBox1.Controls.Add(label3);
			guna2GroupBox1.Controls.Add(txtLastlogin);
			guna2GroupBox1.Controls.Add(label4);
			guna2GroupBox1.Controls.Add(txtUserRank);
			guna2GroupBox1.Controls.Add(label5);
			guna2GroupBox1.Controls.Add(txtHwid);
			guna2GroupBox1.Controls.Add(label6);
			guna2GroupBox1.Controls.Add(txtEmail);
			guna2GroupBox1.Controls.Add(label7);
			guna2GroupBox1.Controls.Add(expiry);
			guna2GroupBox1.Controls.Add(label8);
			guna2GroupBox1.Controls.Add(registerdate);
			guna2GroupBox1.Controls.Add(username);
			guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2GroupBox1.FillColor = System.Drawing.Color.FromArgb(27, 27, 27);
			guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9f);
			guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(125, 137, 149);
			guna2GroupBox1.Location = new System.Drawing.Point(12, 77);
			guna2GroupBox1.Name = "guna2GroupBox1";
			guna2GroupBox1.ShadowDecoration.Parent = guna2GroupBox1;
			guna2GroupBox1.Size = new System.Drawing.Size(613, 233);
			guna2GroupBox1.TabIndex = 33;
			guna2GroupBox1.Text = "License Information";
			guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox2.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox2.Image");
			guna2PictureBox2.ImageRotate = 0f;
			guna2PictureBox2.Location = new System.Drawing.Point(440, 68);
			guna2PictureBox2.Name = "guna2PictureBox2";
			guna2PictureBox2.ShadowDecoration.Parent = guna2PictureBox2;
			guna2PictureBox2.Size = new System.Drawing.Size(127, 115);
			guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox2.TabIndex = 34;
			guna2PictureBox2.TabStop = false;
			guna2PictureBox2.UseTransparentBackground = true;
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(637, 365);
			base.Controls.Add(btnUpdate);
			base.Controls.Add(guna2GradientButton1);
			base.Controls.Add(label1);
			base.Controls.Add(guna2PictureBox1);
			base.Controls.Add(guna2Panel1);
			base.Controls.Add(guna2GroupBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(2);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormAbout";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "About";
			base.Load += new System.EventHandler(FormAbout_Load);
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
			guna2Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			guna2GroupBox1.ResumeLayout(false);
			guna2GroupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox2).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
