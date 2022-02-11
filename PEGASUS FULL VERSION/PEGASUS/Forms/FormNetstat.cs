using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PEGASUS.Connection;
using PEGASUS.MessagePack;
using PEGASUS.Properties;

namespace PEGASUS.Forms
	{
public class FormNetstat : Form
{
	private IContainer components;

	private ColumnHeader lv_id;

	public ListView listView1;

	public System.Windows.Forms.Timer timer1;

	private ColumnHeader lv_localAddr;

	private ColumnHeader lv_remoteAddr;

	private ColumnHeader lv_state;

	private Guna2Panel guna2Panel1;

	private Guna2PictureBox guna2PictureBox1;

	private Label label1;

	private PictureBox pictureBox1;

	private Guna2ContextMenuStrip guna2ContextMenuStrip2;

	private ToolStripMenuItem toolStripMenuItem1;

	private ToolStripMenuItem toolStripMenuItem2;

	private Guna2Separator guna2Separator1;

	private Guna2BorderlessForm guna2BorderlessForm1;

	private Guna2ShadowForm guna2ShadowForm1;

	public PEGASUSMain F { get; set; }

	internal Clients Client { get; set; }

	internal Clients ParentClient { get; set; }

	public FormNetstat()
	{
		InitializeComponent();
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		try
		{
			if (!Client.TcpClient.Connected || !ParentClient.TcpClient.Connected)
			{
				Close();
			}
		}
		catch
		{
			Close();
		}
	}

	private async void killToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (listView1.SelectedItems.Count <= 0)
		{
			return;
		}
		foreach (ListViewItem P in listView1.SelectedItems)
		{
			await Task.Run(delegate
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "Netstat";
				msgPack.ForcePathObject("Option").AsString = "Kill";
				msgPack.ForcePathObject("ID").AsString = P.SubItems[lv_id.Index].Text;
				ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
			});
		}
	}

	private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
	{
		ThreadPool.QueueUserWorkItem(delegate
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "Netstat";
			msgPack.ForcePathObject("Option").AsString = "List";
			ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
		});
	}

	private void FormNetstat_FormClosed(object sender, FormClosedEventArgs e)
	{
		try
		{
			ThreadPool.QueueUserWorkItem(delegate
			{
				Client?.Disconnected();
			});
		}
		catch
		{
		}
	}

	private void SetLastColumnWidth()
	{
		listView1.Columns[listView1.Columns.Count - 1].Width = -2;
	}

	private void FormNetstat_Load(object sender, EventArgs e)
	{
		SetLastColumnWidth();
		listView1.Layout += delegate
		{
			SetLastColumnWidth();
		};
		listView1.View = View.Details;
		listView1.HideSelection = false;
		listView1.OwnerDraw = true;
		listView1.GridLines = false;
		listView1.BackColor = Color.FromArgb(24, 24, 24);
		listView1.DrawColumnHeader += delegate (object sender1, DrawListViewColumnHeaderEventArgs args)
		{
			Brush brush = new SolidBrush(Color.FromArgb(30, 30, 30));
			args.Graphics.FillRectangle(brush, args.Bounds);
			TextRenderer.DrawText(args.Graphics, args.Header.Text, args.Font, args.Bounds, Color.WhiteSmoke);
		};
		listView1.DrawItem += delegate (object sender1, DrawListViewItemEventArgs args)
		{
			args.DrawDefault = true;
		};
		listView1.DrawSubItem += delegate (object sender1, DrawListViewSubItemEventArgs args)
		{
			args.DrawDefault = true;
		};
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNetstat));
		listView1 = new System.Windows.Forms.ListView();
		lv_id = new System.Windows.Forms.ColumnHeader();
		lv_localAddr = new System.Windows.Forms.ColumnHeader();
		lv_remoteAddr = new System.Windows.Forms.ColumnHeader();
		lv_state = new System.Windows.Forms.ColumnHeader();
		guna2ContextMenuStrip2 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
		toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
		timer1 = new System.Windows.Forms.Timer(components);
		guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
		guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		label1 = new System.Windows.Forms.Label();
		guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
		guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
		guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
		guna2ContextMenuStrip2.SuspendLayout();
		guna2Panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
		SuspendLayout();
		listView1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		listView1.BackgroundImage = Properties.Resources.back;
		listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[4] { lv_id, lv_localAddr, lv_remoteAddr, lv_state });
		listView1.ContextMenuStrip = guna2ContextMenuStrip2;
		listView1.Dock = System.Windows.Forms.DockStyle.Fill;
		listView1.Enabled = false;
		listView1.ForeColor = System.Drawing.Color.LightGray;
		listView1.FullRowSelect = true;
		listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
		listView1.HideSelection = false;
		listView1.Location = new System.Drawing.Point(0, 67);
		listView1.Margin = new System.Windows.Forms.Padding(2);
		listView1.Name = "listView1";
		listView1.ShowGroups = false;
		listView1.ShowItemToolTips = true;
		listView1.Size = new System.Drawing.Size(750, 396);
		listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
		listView1.TabIndex = 0;
		listView1.UseCompatibleStateImageBehavior = false;
		listView1.View = System.Windows.Forms.View.Details;
		lv_id.Text = "ID";
		lv_id.Width = 92;
		lv_localAddr.Text = "LocalAddress";
		lv_localAddr.Width = 161;
		lv_remoteAddr.Text = "RemoteAddress";
		lv_remoteAddr.Width = 177;
		lv_state.Text = "State";
		lv_state.Width = 110;
		guna2ContextMenuStrip2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2ContextMenuStrip2.ImageScalingSize = new System.Drawing.Size(26, 26);
		guna2ContextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { toolStripMenuItem1, toolStripMenuItem2 });
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
		guna2ContextMenuStrip2.Size = new System.Drawing.Size(114, 48);
		toolStripMenuItem1.ForeColor = System.Drawing.Color.LightGray;
		toolStripMenuItem1.Name = "toolStripMenuItem1";
		toolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
		toolStripMenuItem1.Text = "Kill";
		toolStripMenuItem1.Click += new System.EventHandler(killToolStripMenuItem_Click);
		toolStripMenuItem2.ForeColor = System.Drawing.Color.LightGray;
		toolStripMenuItem2.Name = "toolStripMenuItem2";
		toolStripMenuItem2.Size = new System.Drawing.Size(113, 22);
		toolStripMenuItem2.Text = "Refresh";
		toolStripMenuItem2.Click += new System.EventHandler(refreshToolStripMenuItem_Click);
		timer1.Interval = 1000;
		timer1.Tick += new System.EventHandler(timer1_Tick);
		guna2Panel1.Controls.Add(guna2Separator1);
		guna2Panel1.Controls.Add(pictureBox1);
		guna2Panel1.Controls.Add(label1);
		guna2Panel1.Controls.Add(guna2PictureBox1);
		guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		guna2Panel1.Location = new System.Drawing.Point(0, 0);
		guna2Panel1.Name = "guna2Panel1";
		guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
		guna2Panel1.Size = new System.Drawing.Size(750, 67);
		guna2Panel1.TabIndex = 1;
		guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
		guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		guna2Separator1.BackColor = System.Drawing.Color.Transparent;
		guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2Separator1.Location = new System.Drawing.Point(-274, 61);
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
		label1.Location = new System.Drawing.Point(291, 20);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(135, 19);
		label1.TabIndex = 11;
		label1.Text = "CONNECTIONS";
		guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
		guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
		guna2PictureBox1.ImageRotate = 0f;
		guna2PictureBox1.Location = new System.Drawing.Point(709, 12);
		guna2PictureBox1.Name = "guna2PictureBox1";
		guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
		guna2PictureBox1.Size = new System.Drawing.Size(29, 27);
		guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		guna2PictureBox1.TabIndex = 7;
		guna2PictureBox1.TabStop = false;
		guna2PictureBox1.UseTransparentBackground = true;
		guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
		guna2BorderlessForm1.ContainerControl = this;
		guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2ShadowForm1.TargetForm = this;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		base.ClientSize = new System.Drawing.Size(750, 463);
		base.Controls.Add(listView1);
		base.Controls.Add(guna2Panel1);
		ForeColor = System.Drawing.Color.LightGray;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(2);
		base.Name = "FormNetstat";
		Text = "Netstat";
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FormNetstat_FormClosed);
		base.Load += new System.EventHandler(FormNetstat_Load);
		guna2ContextMenuStrip2.ResumeLayout(false);
		guna2Panel1.ResumeLayout(false);
		guna2Panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
		ResumeLayout(false);
	}
}
}