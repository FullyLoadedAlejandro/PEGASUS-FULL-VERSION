using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using SharpUpdate;

namespace PEGASUS.Forms
{

	public class FrmAngry : Form
	{
		public string mauro = bytestopng("b~~zy0%%|odegellcickf$do~%_znk~82|%zxe`oi~$rgf");

		private SharpUpdater updater;

		private IContainer components;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2PictureBox guna2PictureBox1;

		private Guna2HtmlLabel guna2HtmlLabel9;

		public FrmAngry()
		{
			InitializeComponent();
			System.Timers.Timer timer = new System.Timers.Timer(30000.0);
			timer.Elapsed += Timer_Elapsed;
			timer.Start();
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

		private void Timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			updater.DoUpdate();
			Application.Exit();
		}

		private void FrmAngry_Load(object sender, EventArgs e)
		{
			updater = new SharpUpdater(Assembly.GetExecutingAssembly(), this, new Uri(mauro));
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAngry));
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			guna2HtmlLabel9 = new Guna.UI2.WinForms.Guna2HtmlLabel();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
			SuspendLayout();
			guna2BorderlessForm1.ContainerControl = this;
			guna2PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
			guna2PictureBox1.ImageRotate = 0f;
			guna2PictureBox1.Location = new System.Drawing.Point(0, 0);
			guna2PictureBox1.Name = "guna2PictureBox1";
			guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
			guna2PictureBox1.Size = new System.Drawing.Size(1058, 571);
			guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			guna2PictureBox1.TabIndex = 0;
			guna2PictureBox1.TabStop = false;
			guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent;
			guna2HtmlLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			guna2HtmlLabel9.ForeColor = System.Drawing.Color.LightGray;
			guna2HtmlLabel9.Location = new System.Drawing.Point(463, 367);
			guna2HtmlLabel9.Name = "guna2HtmlLabel9";
			guna2HtmlLabel9.Size = new System.Drawing.Size(113, 22);
			guna2HtmlLabel9.TabIndex = 9;
			guna2HtmlLabel9.Text = "Contact author!\r\n";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(1058, 571);
			base.Controls.Add(guna2HtmlLabel9);
			base.Controls.Add(guna2PictureBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "FrmAngry";
			Text = "FrmAngry";
			base.Load += new System.EventHandler(FrmAngry_Load);
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}