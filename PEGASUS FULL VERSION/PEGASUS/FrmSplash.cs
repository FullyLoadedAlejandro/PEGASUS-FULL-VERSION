using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PEGASUS.Forms;

namespace PEGASUS
{ 

public class FrmSplash : Form
{
	private IContainer components;

	private ProgressBar progressBar1;

	private Timer timer1;

	private Panel panel1;

	private Guna2BorderlessForm guna2BorderlessForm1;

	private Guna2ShadowForm guna2ShadowForm1;

	private Guna2HtmlLabel guna2HtmlLabel1;

	public FrmSplash()
	{
		InitializeComponent();
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		timer1.Enabled = true;
		progressBar1.Increment(2);
		if (progressBar1.Value == 100)
		{
			timer1.Enabled = false;
			Splashes splashes = new Splashes();
			splashes.Show();
			splashes.FormClosing += delegate
			{
				Close();
			};
			Hide();
		}
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSplash));
		progressBar1 = new System.Windows.Forms.ProgressBar();
		timer1 = new System.Windows.Forms.Timer(components);
		panel1 = new System.Windows.Forms.Panel();
		guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
		guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
		guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
		panel1.SuspendLayout();
		SuspendLayout();
		progressBar1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		progressBar1.ForeColor = System.Drawing.Color.Red;
		progressBar1.Location = new System.Drawing.Point(-5, -21);
		progressBar1.Name = "progressBar1";
		progressBar1.Size = new System.Drawing.Size(205, 68);
		progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
		progressBar1.TabIndex = 0;
		timer1.Enabled = true;
		timer1.Tick += new System.EventHandler(timer1_Tick);
		panel1.Controls.Add(progressBar1);
		panel1.Location = new System.Drawing.Point(169, 315);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(198, 5);
		panel1.TabIndex = 1;
		guna2BorderlessForm1.ContainerControl = this;
		guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2ShadowForm1.TargetForm = this;
		guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
		guna2HtmlLabel1.ForeColor = System.Drawing.Color.Gainsboro;
		guna2HtmlLabel1.Location = new System.Drawing.Point(13, 308);
		guna2HtmlLabel1.Name = "guna2HtmlLabel1";
		guna2HtmlLabel1.Size = new System.Drawing.Size(125, 15);
		guna2HtmlLabel1.TabIndex = 2;
		guna2HtmlLabel1.Text = "Loading Pegasus Plugins:";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
		BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		base.ClientSize = new System.Drawing.Size(621, 325);
		base.Controls.Add(guna2HtmlLabel1);
		base.Controls.Add(panel1);
		DoubleBuffered = true;
		ForeColor = System.Drawing.Color.LightGray;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "FrmSplash";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "splash_screen";
		panel1.ResumeLayout(false);
		ResumeLayout(false);
		PerformLayout();
	}
}
}