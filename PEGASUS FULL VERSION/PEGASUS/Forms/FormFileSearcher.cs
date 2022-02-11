using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace PEGASUS.Forms
	{
public class FormFileSearcher : Form
{
	private IContainer components;

	private Label label1;

	private Label label2;

	private Label label3;

	private Guna2PictureBox guna2PictureBox1;

	private Guna2GradientButton btnOk;

	public Guna2TextBox txtExtnsions;

	private Guna2Panel guna2Panel1;

	private PictureBox pictureBox1;

	private Label label4;

	public Guna2NumericUpDown numericUpDown1;

	private Guna2Separator guna2Separator1;

	private Guna2BorderlessForm guna2BorderlessForm1;

	private Guna2ShadowForm guna2ShadowForm1;

	public FormFileSearcher()
	{
		InitializeComponent();
	}

	private void btnOk_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrWhiteSpace(txtExtnsions.Text) && numericUpDown1.Value > 0m)
		{
			base.DialogResult = DialogResult.OK;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFileSearcher));
		label1 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
		btnOk = new Guna.UI2.WinForms.Guna2GradientButton();
		txtExtnsions = new Guna.UI2.WinForms.Guna2TextBox();
		guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
		guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		label4 = new System.Windows.Forms.Label();
		numericUpDown1 = new Guna.UI2.WinForms.Guna2NumericUpDown();
		guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
		guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
		((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
		guna2Panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
		SuspendLayout();
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(86, 90);
		label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(34, 13);
		label1.TabIndex = 0;
		label1.Text = "Type:";
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(86, 120);
		label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(51, 13);
		label2.TabIndex = 3;
		label2.Text = "Max size:";
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Electrolize", 7f);
		label3.Location = new System.Drawing.Point(211, 121);
		label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(23, 13);
		label3.TabIndex = 6;
		label3.Text = "MB";
		guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
		guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
		guna2PictureBox1.ImageRotate = 0f;
		guna2PictureBox1.Location = new System.Drawing.Point(454, 11);
		guna2PictureBox1.Name = "guna2PictureBox1";
		guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
		guna2PictureBox1.Size = new System.Drawing.Size(29, 27);
		guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		guna2PictureBox1.TabIndex = 7;
		guna2PictureBox1.TabStop = false;
		guna2PictureBox1.UseTransparentBackground = true;
		guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
		btnOk.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		btnOk.BorderThickness = 1;
		btnOk.CheckedState.Parent = btnOk;
		btnOk.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		btnOk.CustomImages.Parent = btnOk;
		btnOk.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		btnOk.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		btnOk.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		btnOk.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		btnOk.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		btnOk.DisabledState.Parent = btnOk;
		btnOk.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnOk.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		btnOk.Font = new System.Drawing.Font("Electrolize", 9f);
		btnOk.ForeColor = System.Drawing.Color.White;
		btnOk.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		btnOk.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		btnOk.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		btnOk.HoverState.ForeColor = System.Drawing.Color.LightGray;
		btnOk.HoverState.Parent = btnOk;
		btnOk.Location = new System.Drawing.Point(109, 153);
		btnOk.Name = "btnOk";
		btnOk.ShadowDecoration.Parent = btnOk;
		btnOk.Size = new System.Drawing.Size(244, 30);
		btnOk.TabIndex = 9;
		btnOk.Text = "Ok";
		btnOk.Click += new System.EventHandler(btnOk_Click);
		txtExtnsions.Animated = true;
		txtExtnsions.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtExtnsions.Cursor = System.Windows.Forms.Cursors.IBeam;
		txtExtnsions.DefaultText = ".txt .pdf .doc";
		txtExtnsions.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
		txtExtnsions.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
		txtExtnsions.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		txtExtnsions.DisabledState.Parent = txtExtnsions;
		txtExtnsions.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		txtExtnsions.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		txtExtnsions.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		txtExtnsions.FocusedState.Parent = txtExtnsions;
		txtExtnsions.Font = new System.Drawing.Font("Electrolize", 9f);
		txtExtnsions.ForeColor = System.Drawing.Color.White;
		txtExtnsions.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		txtExtnsions.HoverState.Parent = txtExtnsions;
		txtExtnsions.Location = new System.Drawing.Point(125, 83);
		txtExtnsions.Name = "txtExtnsions";
		txtExtnsions.PasswordChar = '\0';
		txtExtnsions.PlaceholderText = "";
		txtExtnsions.SelectedText = "";
		txtExtnsions.SelectionStart = 14;
		txtExtnsions.ShadowDecoration.Parent = txtExtnsions;
		txtExtnsions.Size = new System.Drawing.Size(244, 20);
		txtExtnsions.TabIndex = 10;
		guna2Panel1.Controls.Add(guna2Separator1);
		guna2Panel1.Controls.Add(pictureBox1);
		guna2Panel1.Controls.Add(label4);
		guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		guna2Panel1.Location = new System.Drawing.Point(0, 0);
		guna2Panel1.Name = "guna2Panel1";
		guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
		guna2Panel1.Size = new System.Drawing.Size(495, 67);
		guna2Panel1.TabIndex = 11;
		guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
		guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		guna2Separator1.BackColor = System.Drawing.Color.Transparent;
		guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2Separator1.Location = new System.Drawing.Point(-402, 61);
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
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label4.Location = new System.Drawing.Point(192, 19);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(80, 19);
		label4.TabIndex = 11;
		label4.Text = "SEARCH";
		numericUpDown1.BackColor = System.Drawing.Color.Transparent;
		numericUpDown1.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		numericUpDown1.Cursor = System.Windows.Forms.Cursors.IBeam;
		numericUpDown1.DisabledState.Parent = numericUpDown1;
		numericUpDown1.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		numericUpDown1.FocusedState.Parent = numericUpDown1;
		numericUpDown1.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		numericUpDown1.ForeColor = System.Drawing.Color.LightGray;
		numericUpDown1.Location = new System.Drawing.Point(150, 109);
		numericUpDown1.Maximum = new decimal(new int[4] { 100000, 0, 0, 0 });
		numericUpDown1.Name = "numericUpDown1";
		numericUpDown1.ShadowDecoration.Parent = numericUpDown1;
		numericUpDown1.Size = new System.Drawing.Size(56, 27);
		numericUpDown1.TabIndex = 145;
		numericUpDown1.UpDownButtonFillColor = System.Drawing.Color.FromArgb(191, 37, 33);
		numericUpDown1.UpDownButtonForeColor = System.Drawing.Color.White;
		numericUpDown1.Value = new decimal(new int[4] { 5, 0, 0, 0 });
		guna2BorderlessForm1.ContainerControl = this;
		guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2ShadowForm1.TargetForm = this;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		base.ClientSize = new System.Drawing.Size(495, 199);
		base.Controls.Add(numericUpDown1);
		base.Controls.Add(txtExtnsions);
		base.Controls.Add(btnOk);
		base.Controls.Add(guna2PictureBox1);
		base.Controls.Add(label3);
		base.Controls.Add(label2);
		base.Controls.Add(label1);
		base.Controls.Add(guna2Panel1);
		DoubleBuffered = true;
		ForeColor = System.Drawing.Color.LightGray;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(2);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FormFileSearcher";
		base.ShowInTaskbar = false;
		base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "File Searcher";
		((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
		guna2Panel1.ResumeLayout(false);
		guna2Panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
}