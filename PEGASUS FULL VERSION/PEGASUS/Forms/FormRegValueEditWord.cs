using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.Win32;
using PEGASUS.Helper;

namespace PEGASUS.Forms
{

	public class FormRegValueEditWord : Form
	{
		private readonly RegistrySeeker.RegValueData _value;

		private const string DWORD_WARNING = "The decimal value entered is greater than the maximum value of a DWORD (32-bit number). Should the value be truncated in order to continue?";

		private const string QWORD_WARNING = "The decimal value entered is greater than the maximum value of a QWORD (64-bit number). Should the value be truncated in order to continue?";

		private IContainer components;

		private Label label2;

		private Label label1;

		private Guna2GradientButton btnCancel;

		private Guna2GradientButton guna2GradientButton1;

		private Guna2RadioButton radioHexa;

		private Guna2RadioButton radioDecimal;

		private Guna2Panel guna2Panel1;

		private PictureBox pictureBox1;

		private Guna2PictureBox guna2PictureBox1;

		private Label label3;

		private WordTextBox valueDataTxtBox;

		private TextBox valueNameTxtBox;

		private Guna2Separator guna2Separator1;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ShadowForm guna2ShadowForm1;

		public FormRegValueEditWord(RegistrySeeker.RegValueData value)
		{
			_value = value;
			InitializeComponent();
			valueNameTxtBox.Text = value.Name;
			if (value.Kind == RegistryValueKind.DWord)
			{
				Text = "Edit DWORD (32-bit) Value";
				valueDataTxtBox.Type = WordTextBox.WordType.DWORD;
				valueDataTxtBox.Text = Helper.ByteConverter.ToUInt32(value.Data).ToString("x");
			}
			else
			{
				Text = "Edit QWORD (64-bit) Value";
				valueDataTxtBox.Type = WordTextBox.WordType.QWORD;
				valueDataTxtBox.Text = Helper.ByteConverter.ToUInt64(value.Data).ToString("x");
			}
		}

		private void radioHex_CheckboxChanged(object sender, EventArgs e)
		{
			if (valueDataTxtBox.IsHexNumber != radioHexa.Checked)
			{
				if (valueDataTxtBox.IsConversionValid() || IsOverridePossible())
				{
					valueDataTxtBox.IsHexNumber = radioHexa.Checked;
				}
				else
				{
					radioDecimal.Checked = true;
				}
			}
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			if (valueDataTxtBox.IsConversionValid() || IsOverridePossible())
			{
				_value.Data = ((_value.Kind == RegistryValueKind.DWord) ? Helper.ByteConverter.GetBytes(valueDataTxtBox.UIntValue) : Helper.ByteConverter.GetBytes(valueDataTxtBox.ULongValue));
				base.Tag = _value;
				base.DialogResult = DialogResult.OK;
			}
			else
			{
				base.DialogResult = DialogResult.None;
			}
			Close();
		}

		private DialogResult ShowWarning(string msg, string caption)
		{
			return MessageBox.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
		}

		private bool IsOverridePossible()
		{
			string msg = ((_value.Kind == RegistryValueKind.DWord) ? "The decimal value entered is greater than the maximum value of a DWORD (32-bit number). Should the value be truncated in order to continue?" : "The decimal value entered is greater than the maximum value of a QWORD (64-bit number). Should the value be truncated in order to continue?");
			return ShowWarning(msg, "Overflow") == DialogResult.Yes;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegValueEditWord));
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			btnCancel = new Guna.UI2.WinForms.Guna2GradientButton();
			guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
			radioHexa = new Guna.UI2.WinForms.Guna2RadioButton();
			radioDecimal = new Guna.UI2.WinForms.Guna2RadioButton();
			guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			label3 = new System.Windows.Forms.Label();
			valueNameTxtBox = new System.Windows.Forms.TextBox();
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			valueDataTxtBox = new Helper.WordTextBox();
			guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
			SuspendLayout();
			label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(9, 127);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(61, 13);
			label2.TabIndex = 15;
			label2.Text = "Value data:";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(9, 82);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(66, 13);
			label1.TabIndex = 16;
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
			btnCancel.Location = new System.Drawing.Point(251, 186);
			btnCancel.Name = "btnCancel";
			btnCancel.ShadowDecoration.Parent = btnCancel;
			btnCancel.Size = new System.Drawing.Size(103, 30);
			btnCancel.TabIndex = 121;
			btnCancel.Text = "Cancel";
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
			guna2GradientButton1.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2GradientButton1.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2GradientButton1.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2GradientButton1.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2GradientButton1.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2GradientButton1.HoverState.Parent = guna2GradientButton1;
			guna2GradientButton1.Location = new System.Drawing.Point(8, 186);
			guna2GradientButton1.Name = "guna2GradientButton1";
			guna2GradientButton1.ShadowDecoration.Parent = guna2GradientButton1;
			guna2GradientButton1.Size = new System.Drawing.Size(103, 30);
			guna2GradientButton1.TabIndex = 120;
			guna2GradientButton1.Text = "Ok";
			guna2GradientButton1.Click += new System.EventHandler(okButton_Click);
			radioHexa.AutoSize = true;
			radioHexa.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
			radioHexa.CheckedState.BorderThickness = 0;
			radioHexa.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
			radioHexa.CheckedState.InnerColor = System.Drawing.Color.White;
			radioHexa.CheckedState.InnerOffset = -4;
			radioHexa.Location = new System.Drawing.Point(177, 140);
			radioHexa.Name = "radioHexa";
			radioHexa.Size = new System.Drawing.Size(86, 17);
			radioHexa.TabIndex = 124;
			radioHexa.Text = "Hexadecimal";
			radioHexa.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
			radioHexa.UncheckedState.BorderThickness = 2;
			radioHexa.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			radioHexa.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
			radioDecimal.AutoSize = true;
			radioDecimal.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
			radioDecimal.CheckedState.BorderThickness = 0;
			radioDecimal.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
			radioDecimal.CheckedState.InnerColor = System.Drawing.Color.White;
			radioDecimal.CheckedState.InnerOffset = -4;
			radioDecimal.Location = new System.Drawing.Point(269, 140);
			radioDecimal.Name = "radioDecimal";
			radioDecimal.Size = new System.Drawing.Size(63, 17);
			radioDecimal.TabIndex = 125;
			radioDecimal.Text = "Decimal";
			radioDecimal.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
			radioDecimal.UncheckedState.BorderThickness = 2;
			radioDecimal.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			radioDecimal.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
			guna2Panel1.Controls.Add(guna2Separator1);
			guna2Panel1.Controls.Add(pictureBox1);
			guna2Panel1.Controls.Add(guna2PictureBox1);
			guna2Panel1.Controls.Add(label3);
			guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			guna2Panel1.Location = new System.Drawing.Point(0, 0);
			guna2Panel1.Name = "guna2Panel1";
			guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
			guna2Panel1.Size = new System.Drawing.Size(362, 67);
			guna2Panel1.TabIndex = 0;
			guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator1.BackColor = System.Drawing.Color.Transparent;
			guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2Separator1.Location = new System.Drawing.Point(-468, 61);
			guna2Separator1.Name = "guna2Separator1";
			guna2Separator1.Size = new System.Drawing.Size(1299, 10);
			guna2Separator1.TabIndex = 17;
			guna2Separator1.UseTransparentBackground = true;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(12, 12);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(40, 42);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 16;
			pictureBox1.TabStop = false;
			guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
			guna2PictureBox1.ImageRotate = 0f;
			guna2PictureBox1.Location = new System.Drawing.Point(329, 12);
			guna2PictureBox1.Name = "guna2PictureBox1";
			guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
			guna2PictureBox1.Size = new System.Drawing.Size(29, 27);
			guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox1.TabIndex = 15;
			guna2PictureBox1.TabStop = false;
			guna2PictureBox1.UseTransparentBackground = true;
			guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(113, 20);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(131, 19);
			label3.TabIndex = 14;
			label3.Text = "ValueEditWord";
			valueNameTxtBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			valueNameTxtBox.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
			valueNameTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			valueNameTxtBox.ForeColor = System.Drawing.Color.LightGray;
			valueNameTxtBox.Location = new System.Drawing.Point(12, 98);
			valueNameTxtBox.Name = "valueNameTxtBox";
			valueNameTxtBox.ReadOnly = true;
			valueNameTxtBox.Size = new System.Drawing.Size(334, 13);
			valueNameTxtBox.TabIndex = 126;
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.TargetForm = this;
			valueDataTxtBox.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
			valueDataTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			valueDataTxtBox.ForeColor = System.Drawing.Color.LightGray;
			valueDataTxtBox.IsHexNumber = false;
			valueDataTxtBox.Location = new System.Drawing.Point(13, 144);
			valueDataTxtBox.MaxLength = 8;
			valueDataTxtBox.Multiline = true;
			valueDataTxtBox.Name = "valueDataTxtBox";
			valueDataTxtBox.Size = new System.Drawing.Size(158, 20);
			valueDataTxtBox.TabIndex = 127;
			valueDataTxtBox.Type = Helper.WordTextBox.WordType.DWORD;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(362, 227);
			base.Controls.Add(valueDataTxtBox);
			base.Controls.Add(valueNameTxtBox);
			base.Controls.Add(guna2Panel1);
			base.Controls.Add(radioDecimal);
			base.Controls.Add(radioHexa);
			base.Controls.Add(btnCancel);
			base.Controls.Add(guna2GradientButton1);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			ForeColor = System.Drawing.Color.LightGray;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FormRegValueEditWord";
			Text = "FormRegValueEditWord";
			guna2Panel1.ResumeLayout(false);
			guna2Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}