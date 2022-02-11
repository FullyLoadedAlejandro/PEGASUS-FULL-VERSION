using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PEGASUS.Helper;

namespace PEGASUS.Forms
{

	public class FormRegValueEditString : Form
	{
		private readonly RegistrySeeker.RegValueData _value;

		private IContainer components;

		private Label label2;

		private Label label1;

		private Guna2GradientButton btnCancel;

		private Guna2GradientButton okbutton;

		private Guna2TextBox valueNameTxtBox;

		private Guna2TextBox valueDataTxtBox;

		private Guna2Panel guna2Panel1;

		private PictureBox pictureBox1;

		private Label label3;

		private Guna2PictureBox guna2PictureBox1;

		private Guna2Separator guna2Separator1;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ShadowForm guna2ShadowForm1;

		public FormRegValueEditString(RegistrySeeker.RegValueData value)
		{
			_value = value;
			InitializeComponent();
			valueNameTxtBox.Text = RegValueHelper.GetName(value.Name);
			valueDataTxtBox.Text = Helper.ByteConverter.ToString(value.Data);
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			_value.Data = Helper.ByteConverter.GetBytes(valueDataTxtBox.Text);
			base.Tag = _value;
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegValueEditString));
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			btnCancel = new Guna.UI2.WinForms.Guna2GradientButton();
			okbutton = new Guna.UI2.WinForms.Guna2GradientButton();
			valueNameTxtBox = new Guna.UI2.WinForms.Guna2TextBox();
			valueDataTxtBox = new Guna.UI2.WinForms.Guna2TextBox();
			guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label3 = new System.Windows.Forms.Label();
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(9, 134);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(61, 13);
			label2.TabIndex = 8;
			label2.Text = "Value data:";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(9, 82);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(66, 13);
			label1.TabIndex = 10;
			label1.Text = "Value name:";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnCancel.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			btnCancel.BorderThickness = 1;
			btnCancel.CheckedState.Parent = btnCancel;
			btnCancel.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnCancel.CustomImages.Parent = btnCancel;
			btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			btnCancel.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			btnCancel.DisabledState.Parent = btnCancel;
			btnCancel.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnCancel.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btnCancel.Font = new System.Drawing.Font("Electrolize", 9f);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnCancel.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnCancel.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			btnCancel.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnCancel.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnCancel.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnCancel.HoverState.Parent = btnCancel;
			btnCancel.Location = new System.Drawing.Point(256, 183);
			btnCancel.Name = "btnCancel";
			btnCancel.ShadowDecoration.Parent = btnCancel;
			btnCancel.Size = new System.Drawing.Size(103, 30);
			btnCancel.TabIndex = 119;
			btnCancel.Text = "Cancel";
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			okbutton.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			okbutton.BorderThickness = 1;
			okbutton.CheckedState.Parent = okbutton;
			okbutton.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			okbutton.CustomImages.Parent = okbutton;
			okbutton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			okbutton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			okbutton.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			okbutton.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			okbutton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			okbutton.DisabledState.Parent = okbutton;
			okbutton.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			okbutton.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			okbutton.Font = new System.Drawing.Font("Electrolize", 9f);
			okbutton.ForeColor = System.Drawing.Color.White;
			okbutton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			okbutton.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			okbutton.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			okbutton.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			okbutton.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			okbutton.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			okbutton.HoverState.Parent = okbutton;
			okbutton.Location = new System.Drawing.Point(12, 183);
			okbutton.Name = "okbutton";
			okbutton.ShadowDecoration.Parent = okbutton;
			okbutton.Size = new System.Drawing.Size(103, 30);
			okbutton.TabIndex = 118;
			okbutton.Text = "Ok";
			okbutton.Click += new System.EventHandler(okButton_Click);
			valueNameTxtBox.Animated = true;
			valueNameTxtBox.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			valueNameTxtBox.Cursor = System.Windows.Forms.Cursors.IBeam;
			valueNameTxtBox.DefaultText = "";
			valueNameTxtBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			valueNameTxtBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			valueNameTxtBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			valueNameTxtBox.DisabledState.Parent = valueNameTxtBox;
			valueNameTxtBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			valueNameTxtBox.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			valueNameTxtBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
			valueNameTxtBox.FocusedState.Parent = valueNameTxtBox;
			valueNameTxtBox.Font = new System.Drawing.Font("Electrolize", 9f);
			valueNameTxtBox.ForeColor = System.Drawing.Color.White;
			valueNameTxtBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
			valueNameTxtBox.HoverState.Parent = valueNameTxtBox;
			valueNameTxtBox.Location = new System.Drawing.Point(10, 98);
			valueNameTxtBox.Name = "valueNameTxtBox";
			valueNameTxtBox.PasswordChar = '\0';
			valueNameTxtBox.PlaceholderText = "";
			valueNameTxtBox.SelectedText = "";
			valueNameTxtBox.ShadowDecoration.Parent = valueNameTxtBox;
			valueNameTxtBox.Size = new System.Drawing.Size(349, 20);
			valueNameTxtBox.TabIndex = 120;
			valueDataTxtBox.Animated = true;
			valueDataTxtBox.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			valueDataTxtBox.Cursor = System.Windows.Forms.Cursors.IBeam;
			valueDataTxtBox.DefaultText = "";
			valueDataTxtBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			valueDataTxtBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			valueDataTxtBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			valueDataTxtBox.DisabledState.Parent = valueDataTxtBox;
			valueDataTxtBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			valueDataTxtBox.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			valueDataTxtBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
			valueDataTxtBox.FocusedState.Parent = valueDataTxtBox;
			valueDataTxtBox.Font = new System.Drawing.Font("Electrolize", 9f);
			valueDataTxtBox.ForeColor = System.Drawing.Color.White;
			valueDataTxtBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
			valueDataTxtBox.HoverState.Parent = valueDataTxtBox;
			valueDataTxtBox.Location = new System.Drawing.Point(10, 150);
			valueDataTxtBox.Name = "valueDataTxtBox";
			valueDataTxtBox.PasswordChar = '\0';
			valueDataTxtBox.PlaceholderText = "";
			valueDataTxtBox.SelectedText = "";
			valueDataTxtBox.ShadowDecoration.Parent = valueDataTxtBox;
			valueDataTxtBox.Size = new System.Drawing.Size(349, 20);
			valueDataTxtBox.TabIndex = 121;
			guna2Panel1.Controls.Add(guna2Separator1);
			guna2Panel1.Controls.Add(guna2PictureBox1);
			guna2Panel1.Controls.Add(pictureBox1);
			guna2Panel1.Controls.Add(label3);
			guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			guna2Panel1.Location = new System.Drawing.Point(0, 0);
			guna2Panel1.Name = "guna2Panel1";
			guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
			guna2Panel1.Size = new System.Drawing.Size(373, 67);
			guna2Panel1.TabIndex = 122;
			guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
			guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator1.BackColor = System.Drawing.Color.Transparent;
			guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2Separator1.Location = new System.Drawing.Point(-463, 61);
			guna2Separator1.Name = "guna2Separator1";
			guna2Separator1.Size = new System.Drawing.Size(1299, 10);
			guna2Separator1.TabIndex = 17;
			guna2Separator1.UseTransparentBackground = true;
			guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
			guna2PictureBox1.ImageRotate = 0f;
			guna2PictureBox1.Location = new System.Drawing.Point(330, 12);
			guna2PictureBox1.Name = "guna2PictureBox1";
			guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
			guna2PictureBox1.Size = new System.Drawing.Size(29, 27);
			guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox1.TabIndex = 16;
			guna2PictureBox1.TabStop = false;
			guna2PictureBox1.UseTransparentBackground = true;
			guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(12, 12);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(40, 42);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 15;
			pictureBox1.TabStop = false;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(115, 22);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(137, 19);
			label3.TabIndex = 14;
			label3.Text = "ValueEditString";
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(373, 225);
			base.Controls.Add(guna2Panel1);
			base.Controls.Add(valueDataTxtBox);
			base.Controls.Add(valueNameTxtBox);
			base.Controls.Add(btnCancel);
			base.Controls.Add(okbutton);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			ForeColor = System.Drawing.Color.LightGray;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FormRegValueEditString";
			Text = "FormRegValueEditString";
			guna2Panel1.ResumeLayout(false);
			guna2Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}