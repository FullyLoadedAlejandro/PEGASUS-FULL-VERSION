// Token: 0x02000010 RID: 16
internal partial class InputDialog : global::System.Windows.Forms.Form
{
	// Token: 0x0600008E RID: 142 RVA: 0x0000BA80 File Offset: 0x00009C80
	private void InitializeComponent()
	{
		this.components = new global::System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputDialog));
		this.guna2Panel1 = new global::Guna.UI2.WinForms.Guna2Panel();
		this.guna2PictureBox1 = new global::Guna.UI2.WinForms.Guna2PictureBox();
		this.guna2Separator1 = new global::Guna.UI2.WinForms.Guna2Separator();
		this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
		this.label3 = new global::System.Windows.Forms.Label();
		this.guna2BorderlessForm1 = new global::Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
		this.guna2ShadowForm1 = new global::Guna.UI2.WinForms.Guna2ShadowForm(this.components);
		this.guna2Panel1.SuspendLayout();
		((global::System.ComponentModel.ISupportInitialize)this.guna2PictureBox1).BeginInit();
		((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		base.SuspendLayout();
		this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
		this.guna2Panel1.Controls.Add(this.guna2Separator1);
		this.guna2Panel1.Controls.Add(this.pictureBox1);
		this.guna2Panel1.Controls.Add(this.label3);
		this.guna2Panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
		this.guna2Panel1.Location = new global::System.Drawing.Point(0, 0);
		this.guna2Panel1.Name = "guna2Panel1";
		this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
		this.guna2Panel1.Size = new global::System.Drawing.Size(284, 67);
		this.guna2Panel1.TabIndex = 13;
		this.guna2PictureBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
		this.guna2PictureBox1.BackColor = global::System.Drawing.Color.Transparent;
		this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
		this.guna2PictureBox1.ImageRotate = 0f;
		this.guna2PictureBox1.Location = new global::System.Drawing.Point(243, 12);
		this.guna2PictureBox1.Name = "guna2PictureBox1";
		this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
		this.guna2PictureBox1.Size = new global::System.Drawing.Size(29, 31);
		this.guna2PictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.guna2PictureBox1.TabIndex = 115;
		this.guna2PictureBox1.TabStop = false;
		this.guna2PictureBox1.UseTransparentBackground = true;
		this.guna2Separator1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.guna2Separator1.BackColor = global::System.Drawing.Color.Transparent;
		this.guna2Separator1.FillColor = global::System.Drawing.Color.FromArgb(36, 36, 36);
		this.guna2Separator1.Location = new global::System.Drawing.Point(-477, 61);
		this.guna2Separator1.Name = "guna2Separator1";
		this.guna2Separator1.Size = new global::System.Drawing.Size(1238, 10);
		this.guna2Separator1.TabIndex = 15;
		this.guna2Separator1.UseTransparentBackground = true;
		this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
		this.pictureBox1.Location = new global::System.Drawing.Point(15, 12);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new global::System.Drawing.Size(40, 42);
		this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox1.TabIndex = 14;
		this.pictureBox1.TabStop = false;
		this.label3.AutoSize = true;
		this.label3.Font = new global::System.Drawing.Font("Electrolize", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
		this.label3.ForeColor = global::System.Drawing.Color.LightGray;
		this.label3.Location = new global::System.Drawing.Point(112, 20);
		this.label3.Name = "label3";
		this.label3.Size = new global::System.Drawing.Size(52, 19);
		this.label3.TabIndex = 11;
		this.label3.Text = "Input";
		this.guna2BorderlessForm1.ContainerControl = this;
		this.guna2BorderlessForm1.ShadowColor = global::System.Drawing.Color.FromArgb(198, 25, 31);
		this.guna2ShadowForm1.ShadowColor = global::System.Drawing.Color.FromArgb(198, 25, 31);
		this.guna2ShadowForm1.TargetForm = this;
		this.BackColor = global::System.Drawing.Color.FromArgb(22, 22, 22);
		base.ClientSize = new global::System.Drawing.Size(284, 261);
		base.Controls.Add(this.guna2Panel1);
		this.ForeColor = global::System.Drawing.Color.LightGray;
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
		base.Name = "InputDialog";
		this.guna2Panel1.ResumeLayout(false);
		this.guna2Panel1.PerformLayout();
		((global::System.ComponentModel.ISupportInitialize)this.guna2PictureBox1).EndInit();
		((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		base.ResumeLayout(false);
	}

	// Token: 0x04000054 RID: 84
	private global::Guna.UI2.WinForms.Guna2Panel guna2Panel1;

	// Token: 0x04000055 RID: 85
	private global::Guna.UI2.WinForms.Guna2Separator guna2Separator1;

	// Token: 0x04000056 RID: 86
	private global::System.Windows.Forms.PictureBox pictureBox1;

	// Token: 0x04000057 RID: 87
	private global::System.Windows.Forms.Label label3;

	// Token: 0x04000058 RID: 88
	private global::System.ComponentModel.IContainer components;

	// Token: 0x04000059 RID: 89
	private global::Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;

	// Token: 0x0400005A RID: 90
	private global::Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;

	// Token: 0x0400005B RID: 91
	private global::Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
}
