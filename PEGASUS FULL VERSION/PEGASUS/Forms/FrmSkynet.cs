using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PEGASUS.Helper;

namespace PEGASUS.Forms
{

	public class FrmSkynet : Form
	{
		private IContainer components;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private AeroListView aeroListView1;

		private ColumnHeader columnHeader1;

		private ColumnHeader columnHeader2;

		private Guna2ContextMenuStrip guna2ContextMenuStrip2;

		private ToolStripMenuItem exstractOpenToolStripMenuItem;

		private ToolStripMenuItem toolStripMenuItem70;

		private Guna2Panel guna2Panel1;

		private Guna2Separator guna2Separator1;

		private PictureBox pictureBox1;

		private Label label1;

		private Guna2PictureBox guna2PictureBox1;

		public FrmSkynet()
		{
			InitializeComponent();
		}

		private void SetLastColumnWidth()
		{
			aeroListView1.Columns[aeroListView1.Columns.Count - 1].Width = -2;
		}

		private void FrmSkynet_Load(object sender, EventArgs e)
		{
			ListviewDoubleBuffer.Enable(aeroListView1);
			aeroListView1.Columns[1].TextAlign = HorizontalAlignment.Center;
			aeroListView1.Columns[2].TextAlign = HorizontalAlignment.Center;
			SetLastColumnWidth();
			aeroListView1.Layout += delegate
			{
				SetLastColumnWidth();
			};
			aeroListView1.View = View.Details;
			aeroListView1.HideSelection = false;
			aeroListView1.OwnerDraw = true;
			aeroListView1.GridLines = false;
			aeroListView1.BackColor = Color.FromArgb(24, 24, 24);
			aeroListView1.DrawColumnHeader += delegate (object sender1, DrawListViewColumnHeaderEventArgs args)
			{
				Brush brush = new SolidBrush(Color.FromArgb(30, 30, 30));
				args.Graphics.FillRectangle(brush, args.Bounds);
				TextRenderer.DrawText(args.Graphics, args.Header.Text, args.Font, args.Bounds, Color.WhiteSmoke);
			};
			aeroListView1.DrawItem += delegate (object sender1, DrawListViewItemEventArgs args)
			{
				args.DrawDefault = true;
			};
			aeroListView1.DrawSubItem += delegate (object sender1, DrawListViewSubItemEventArgs args)
			{
				args.DrawDefault = true;
			};
		}

		private void exstractOpenToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void toolStripMenuItem70_Click(object sender, EventArgs e)
		{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSkynet));
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2ContextMenuStrip2 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
			exstractOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem70 = new System.Windows.Forms.ToolStripMenuItem();
			guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			label1 = new System.Windows.Forms.Label();
			guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			aeroListView1 = new Helper.AeroListView();
			columnHeader1 = new System.Windows.Forms.ColumnHeader();
			columnHeader2 = new System.Windows.Forms.ColumnHeader();
			guna2ContextMenuStrip2.SuspendLayout();
			guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			guna2BorderlessForm1.ContainerControl = this;
			guna2ContextMenuStrip2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2ContextMenuStrip2.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			guna2ContextMenuStrip2.ImageScalingSize = new System.Drawing.Size(29, 29);
			guna2ContextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { exstractOpenToolStripMenuItem, toolStripMenuItem70 });
			guna2ContextMenuStrip2.Margin = new System.Windows.Forms.Padding(3);
			guna2ContextMenuStrip2.Name = "guna2ContextMenuStrip1";
			guna2ContextMenuStrip2.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ContextMenuStrip2.RenderStyle.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2ContextMenuStrip2.RenderStyle.ColorTable = null;
			guna2ContextMenuStrip2.RenderStyle.RoundedEdges = true;
			guna2ContextMenuStrip2.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
			guna2ContextMenuStrip2.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ContextMenuStrip2.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
			guna2ContextMenuStrip2.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
			guna2ContextMenuStrip2.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			guna2ContextMenuStrip2.Size = new System.Drawing.Size(189, 76);
			exstractOpenToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			exstractOpenToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("exstractOpenToolStripMenuItem.Image");
			exstractOpenToolStripMenuItem.Name = "exstractOpenToolStripMenuItem";
			exstractOpenToolStripMenuItem.Size = new System.Drawing.Size(188, 36);
			exstractOpenToolStripMenuItem.Text = "      Exstract & Open";
			exstractOpenToolStripMenuItem.Click += new System.EventHandler(exstractOpenToolStripMenuItem_Click);
			toolStripMenuItem70.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem70.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem70.Image");
			toolStripMenuItem70.Name = "toolStripMenuItem70";
			toolStripMenuItem70.Size = new System.Drawing.Size(188, 36);
			toolStripMenuItem70.Text = "      Delete";
			toolStripMenuItem70.Click += new System.EventHandler(toolStripMenuItem70_Click);
			guna2Panel1.Controls.Add(label1);
			guna2Panel1.Controls.Add(guna2PictureBox1);
			guna2Panel1.Controls.Add(guna2Separator1);
			guna2Panel1.Controls.Add(pictureBox1);
			guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			guna2Panel1.Location = new System.Drawing.Point(0, 0);
			guna2Panel1.Name = "guna2Panel1";
			guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
			guna2Panel1.Size = new System.Drawing.Size(883, 67);
			guna2Panel1.TabIndex = 15;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.Color.LightGray;
			label1.Location = new System.Drawing.Point(404, 20);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(74, 19);
			label1.TabIndex = 15;
			label1.Text = "SKYNET";
			guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
			guna2PictureBox1.ImageRotate = 0f;
			guna2PictureBox1.Location = new System.Drawing.Point(842, 12);
			guna2PictureBox1.Name = "guna2PictureBox1";
			guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
			guna2PictureBox1.Size = new System.Drawing.Size(29, 27);
			guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox1.TabIndex = 14;
			guna2PictureBox1.TabStop = false;
			guna2PictureBox1.UseTransparentBackground = true;
			guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator1.BackColor = System.Drawing.Color.Transparent;
			guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2Separator1.Location = new System.Drawing.Point(-250, 61);
			guna2Separator1.Name = "guna2Separator1";
			guna2Separator1.Size = new System.Drawing.Size(1383, 10);
			guna2Separator1.TabIndex = 13;
			guna2Separator1.UseTransparentBackground = true;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(12, 12);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(40, 42);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 12;
			pictureBox1.TabStop = false;
			aeroListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { columnHeader1, columnHeader2 });
			aeroListView1.ContextMenuStrip = guna2ContextMenuStrip2;
			aeroListView1.FullRowSelect = true;
			aeroListView1.HideSelection = false;
			aeroListView1.Location = new System.Drawing.Point(12, 77);
			aeroListView1.Name = "aeroListView1";
			aeroListView1.Size = new System.Drawing.Size(859, 592);
			aeroListView1.TabIndex = 0;
			aeroListView1.UseCompatibleStateImageBehavior = false;
			aeroListView1.View = System.Windows.Forms.View.Details;
			columnHeader1.Text = "Zips";
			columnHeader1.Width = 308;
			columnHeader2.Text = "Date";
			columnHeader2.Width = 218;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(883, 681);
			base.Controls.Add(aeroListView1);
			base.Controls.Add(guna2Panel1);
			Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ForeColor = System.Drawing.Color.LightGray;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FrmSkynet";
			Text = "FrmSkynet";
			base.Load += new System.EventHandler(FrmSkynet_Load);
			guna2ContextMenuStrip2.ResumeLayout(false);
			guna2Panel1.ResumeLayout(false);
			guna2Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}
	}
}