using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace PEGASUS.Forms
{

	public class FrmInfo : Form
	{
		private IContainer components;

		private Guna2Panel guna2Panel1;

		private PictureBox pictureBox1;

		private Label label1;

		private Guna2PictureBox guna2PictureBox1;

		private RichTextBox textBox1;

		private Guna2Separator guna2Separator1;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ShadowForm guna2ShadowForm1;

		public FrmInfo(string path)
		{
			InitializeComponent();
			string text = File.ReadAllText(path);
			textBox1.Text = text;
		}

		private void FrmInfo_Load(object sender, EventArgs e)
		{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInfo));
			guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label1 = new System.Windows.Forms.Label();
			guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			textBox1 = new System.Windows.Forms.RichTextBox();
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
			SuspendLayout();
			guna2Panel1.Controls.Add(guna2Separator1);
			guna2Panel1.Controls.Add(pictureBox1);
			guna2Panel1.Controls.Add(label1);
			guna2Panel1.Controls.Add(guna2PictureBox1);
			guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			guna2Panel1.Location = new System.Drawing.Point(0, 0);
			guna2Panel1.Name = "guna2Panel1";
			guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
			guna2Panel1.Size = new System.Drawing.Size(800, 67);
			guna2Panel1.TabIndex = 2;
			guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
			guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator1.BackColor = System.Drawing.Color.Transparent;
			guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2Separator1.Location = new System.Drawing.Point(-249, 61);
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
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(326, 20);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(132, 19);
			label1.TabIndex = 11;
			label1.Text = "INFORMATION";
			guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
			guna2PictureBox1.ImageRotate = 0f;
			guna2PictureBox1.Location = new System.Drawing.Point(759, 12);
			guna2PictureBox1.Name = "guna2PictureBox1";
			guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
			guna2PictureBox1.Size = new System.Drawing.Size(29, 27);
			guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox1.TabIndex = 7;
			guna2PictureBox1.TabStop = false;
			guna2PictureBox1.UseTransparentBackground = true;
			guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
			textBox1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			textBox1.ForeColor = System.Drawing.Color.LightGray;
			textBox1.Location = new System.Drawing.Point(0, 67);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(800, 383);
			textBox1.TabIndex = 3;
			textBox1.Text = "";
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(800, 450);
			base.Controls.Add(textBox1);
			base.Controls.Add(guna2Panel1);
			ForeColor = System.Drawing.Color.LightGray;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FrmInfo";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "FrmInfo";
			base.Load += new System.EventHandler(FrmInfo_Load);
			guna2Panel1.ResumeLayout(false);
			guna2Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
			ResumeLayout(false);
		}
	}
}