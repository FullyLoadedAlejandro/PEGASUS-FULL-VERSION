using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuAnimatorNS;
using PEGASUS.Properties;



public class alert : Form
{
	public enum AlertType
	{
		success,
		info,
		warnig,
		error
	}

	private int interval;

	private IContainer components;

	private ImageList imageList1;

	private BunifuDragControl bunifuDragControl1;

	private Timer timeout;

	private Timer show;

	private Timer closealert;

	private BunifuFormFadeTransition bunifuFormFadeTransition1;

	private BunifuTransition bunifuTransition1;

	private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;

	private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator2;

	private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator3;

	private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator4;

	private BunifuCards bunifuCards2;

	private BunifuImageButton bunifuImageButton1;

	private Label message;

	private PictureBox icon;

	public alert(string _message, AlertType type)
	{
		InitializeComponent();
		message.Text = _message;
		switch (type)
		{
			case AlertType.success:
				BackColor = Color.FromArgb(22, 22, 22);
				icon.Image = imageList1.Images[1];
				break;
			case AlertType.info:
				BackColor = Color.Gray;
				icon.Image = imageList1.Images[1];
				break;
			case AlertType.warnig:
				BackColor = Color.Crimson;
				icon.Image = imageList1.Images[1];
				break;
			case AlertType.error:
				BackColor = Color.FromArgb(22, 22, 22);
				icon.Image = imageList1.Images[2];
				break;
		}
	}

	public static void Show(string message, AlertType type)
	{
		new alert(message, type).Show();
	}

	private void alert_Load(object sender, EventArgs e)
	{
		base.Top = -1 * base.Height;
		base.Left = Screen.PrimaryScreen.Bounds.Width - base.Width - 60;
		show.Start();
	}

	private void bunifuImageButton1_Click(object sender, EventArgs e)
	{
		closealert.Start();
	}

	private void timeout_Tick(object sender, EventArgs e)
	{
		closealert.Start();
	}

	private void show_Tick(object sender, EventArgs e)
	{
		if (base.Top < 60)
		{
			base.Top += interval;
			interval += 2;
		}
		else
		{
			show.Stop();
		}
	}

	private void close_Tick(object sender, EventArgs e)
	{
		if (base.Opacity > 0.0)
		{
			base.Opacity -= 0.2;
		}
		else
		{
			Close();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(custom_alert_notifications.alert));
		Bunifu.UI.WinForms.BunifuAnimatorNS.Animation animation = new Bunifu.UI.WinForms.BunifuAnimatorNS.Animation();
		imageList1 = new System.Windows.Forms.ImageList(components);
		bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
		timeout = new System.Windows.Forms.Timer(components);
		show = new System.Windows.Forms.Timer(components);
		closealert = new System.Windows.Forms.Timer(components);
		bunifuFormFadeTransition1 = new Bunifu.Framework.UI.BunifuFormFadeTransition(components);
		bunifuTransition1 = new Bunifu.UI.WinForms.BunifuTransition(components);
		bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
		bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
		bunifuSeparator3 = new Bunifu.UI.WinForms.BunifuSeparator();
		bunifuSeparator4 = new Bunifu.UI.WinForms.BunifuSeparator();
		bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
		bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
		message = new System.Windows.Forms.Label();
		icon = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)bunifuImageButton1).BeginInit();
		((System.ComponentModel.ISupportInitialize)icon).BeginInit();
		SuspendLayout();
		imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
		imageList1.TransparentColor = System.Drawing.Color.Transparent;
		imageList1.Images.SetKeyName(0, "84f.png");
		imageList1.Images.SetKeyName(1, "Remote Computer.png");
		bunifuDragControl1.Fixed = true;
		bunifuDragControl1.Horizontal = true;
		bunifuDragControl1.TargetControl = this;
		bunifuDragControl1.Vertical = true;
		timeout.Enabled = true;
		timeout.Interval = 5000;
		timeout.Tick += new System.EventHandler(timeout_Tick);
		show.Interval = 1;
		show.Tick += new System.EventHandler(show_Tick);
		closealert.Tick += new System.EventHandler(close_Tick);
		bunifuFormFadeTransition1.Delay = 5;
		bunifuTransition1.AnimationType = Bunifu.UI.WinForms.BunifuAnimatorNS.AnimationType.Particles;
		bunifuTransition1.Cursor = null;
		animation.AnimateOnlyDifferences = true;
		animation.BlindCoeff = (System.Drawing.PointF)resources.GetObject("animation1.BlindCoeff");
		animation.LeafCoeff = 0f;
		animation.MaxTime = 1f;
		animation.MinTime = 0f;
		animation.MosaicCoeff = (System.Drawing.PointF)resources.GetObject("animation1.MosaicCoeff");
		animation.MosaicShift = (System.Drawing.PointF)resources.GetObject("animation1.MosaicShift");
		animation.MosaicSize = 1;
		animation.Padding = new System.Windows.Forms.Padding(100, 50, 100, 150);
		animation.RotateCoeff = 0f;
		animation.RotateLimit = 0f;
		animation.ScaleCoeff = (System.Drawing.PointF)resources.GetObject("animation1.ScaleCoeff");
		animation.SlideCoeff = (System.Drawing.PointF)resources.GetObject("animation1.SlideCoeff");
		animation.TimeCoeff = 2f;
		animation.TransparencyCoeff = 0f;
		bunifuTransition1.DefaultAnimation = animation;
		bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
		bunifuTransition1.SetDecoration(bunifuSeparator1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
		bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(105, 105, 105);
		bunifuSeparator1.LineThickness = 1;
		bunifuSeparator1.Location = new System.Drawing.Point(1, -4);
		bunifuSeparator1.Name = "bunifuSeparator1";
		bunifuSeparator1.Size = new System.Drawing.Size(302, 7);
		bunifuSeparator1.TabIndex = 122;
		bunifuSeparator1.Transparency = 255;
		bunifuSeparator1.Vertical = false;
		bunifuSeparator2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
		bunifuSeparator2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator2.BackgroundImage");
		bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		bunifuSeparator2.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
		bunifuTransition1.SetDecoration(bunifuSeparator2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
		bunifuSeparator2.LineColor = System.Drawing.Color.Silver;
		bunifuSeparator2.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
		bunifuSeparator2.LineThickness = 1;
		bunifuSeparator2.Location = new System.Drawing.Point(-2, 240);
		bunifuSeparator2.Margin = new System.Windows.Forms.Padding(2);
		bunifuSeparator2.Name = "bunifuSeparator2";
		bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
		bunifuSeparator2.Size = new System.Drawing.Size(514, 10);
		bunifuSeparator2.TabIndex = 255;
		bunifuSeparator3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		bunifuSeparator3.BackColor = System.Drawing.Color.Transparent;
		bunifuSeparator3.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator3.BackgroundImage");
		bunifuSeparator3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		bunifuSeparator3.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
		bunifuTransition1.SetDecoration(bunifuSeparator3, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
		bunifuSeparator3.LineColor = System.Drawing.Color.Silver;
		bunifuSeparator3.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
		bunifuSeparator3.LineThickness = 1;
		bunifuSeparator3.Location = new System.Drawing.Point(504, 1);
		bunifuSeparator3.Margin = new System.Windows.Forms.Padding(2);
		bunifuSeparator3.Name = "bunifuSeparator3";
		bunifuSeparator3.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
		bunifuSeparator3.Size = new System.Drawing.Size(10, 246);
		bunifuSeparator3.TabIndex = 256;
		bunifuSeparator4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		bunifuSeparator4.BackColor = System.Drawing.Color.Transparent;
		bunifuSeparator4.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator4.BackgroundImage");
		bunifuSeparator4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		bunifuSeparator4.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
		bunifuTransition1.SetDecoration(bunifuSeparator4, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
		bunifuSeparator4.LineColor = System.Drawing.Color.Silver;
		bunifuSeparator4.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
		bunifuSeparator4.LineThickness = 1;
		bunifuSeparator4.Location = new System.Drawing.Point(-5, 1);
		bunifuSeparator4.Margin = new System.Windows.Forms.Padding(2);
		bunifuSeparator4.Name = "bunifuSeparator4";
		bunifuSeparator4.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
		bunifuSeparator4.Size = new System.Drawing.Size(10, 244);
		bunifuSeparator4.TabIndex = 257;
		bunifuCards2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		bunifuCards2.BorderRadius = 5;
		bunifuCards2.BottomSahddow = true;
		bunifuCards2.color = System.Drawing.Color.FromArgb(191, 38, 33);
		bunifuTransition1.SetDecoration(bunifuCards2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
		bunifuCards2.Dock = System.Windows.Forms.DockStyle.Top;
		bunifuCards2.ForeColor = System.Drawing.Color.LightGray;
		bunifuCards2.LeftSahddow = false;
		bunifuCards2.Location = new System.Drawing.Point(0, 0);
		bunifuCards2.Name = "bunifuCards2";
		bunifuCards2.RightSahddow = false;
		bunifuCards2.ShadowDepth = 0;
		bunifuCards2.Size = new System.Drawing.Size(510, 10);
		bunifuCards2.TabIndex = 261;
		bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
		bunifuImageButton1.Cursor = System.Windows.Forms.Cursors.Hand;
		bunifuTransition1.SetDecoration(bunifuImageButton1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
        bunifuImageButton1.Image = Resources.x;
		bunifuImageButton1.ImageActive = null;
		bunifuImageButton1.Location = new System.Drawing.Point(477, 12);
		bunifuImageButton1.Name = "bunifuImageButton1";
		bunifuImageButton1.Size = new System.Drawing.Size(26, 27);
		bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		bunifuImageButton1.TabIndex = 260;
		bunifuImageButton1.TabStop = false;
		bunifuImageButton1.Visible = false;
		bunifuImageButton1.Zoom = 10;
		message.AutoSize = true;
		message.BackColor = System.Drawing.Color.Transparent;
		bunifuTransition1.SetDecoration(message, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
		message.Font = new System.Drawing.Font("Electrolize", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		message.ForeColor = System.Drawing.Color.White;
		message.Location = new System.Drawing.Point(123, 64);
		message.Name = "message";
		message.Size = new System.Drawing.Size(135, 18);
		message.TabIndex = 259;
		message.Text = "Success message ";
		icon.BackColor = System.Drawing.Color.Transparent;
		bunifuTransition1.SetDecoration(icon, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
		icon.Image = (System.Drawing.Image)resources.GetObject("icon.Image");
		icon.Location = new System.Drawing.Point(11, 39);
		icon.Name = "icon";
		icon.Size = new System.Drawing.Size(94, 105);
		icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		icon.TabIndex = 258;
		icon.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
		BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		base.ClientSize = new System.Drawing.Size(510, 246);
		base.Controls.Add(bunifuCards2);
		base.Controls.Add(bunifuImageButton1);
		base.Controls.Add(message);
		base.Controls.Add(icon);
		base.Controls.Add(bunifuSeparator2);
		base.Controls.Add(bunifuSeparator1);
		base.Controls.Add(bunifuSeparator3);
		base.Controls.Add(bunifuSeparator4);
		bunifuTransition1.SetDecoration(this, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
		ForeColor = System.Drawing.Color.White;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "alert";
		base.Opacity = 0.95;
		base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
		Text = "alert";
		base.TopMost = true;
		base.Load += new System.EventHandler(alert_Load);
		((System.ComponentModel.ISupportInitialize)bunifuImageButton1).EndInit();
		((System.ComponentModel.ISupportInitialize)icon).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
