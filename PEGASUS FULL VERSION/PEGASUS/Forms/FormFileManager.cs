using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic;
using PEGASUS.Connection;
using PEGASUS.MessagePack;
using PEGASUS.Properties;

namespace PEGASUS.Forms
	{
public class FormFileManager : Form
{
	private IContainer components;

	public ListView listView1;

	public ImageList imageList1;

	private ContextMenuStrip contextMenuStrip1;

	private ToolStripMenuItem backToolStripMenuItem;

	public StatusStrip statusStrip1;

	public ToolStripStatusLabel toolStripStatusLabel1;

	public ToolStripStatusLabel toolStripStatusLabel2;

	private ToolStripMenuItem downloadToolStripMenuItem;

	private ToolStripSeparator toolStripSeparator1;

	private ToolStripMenuItem uPLOADToolStripMenuItem;

	private ToolStripMenuItem dELETEToolStripMenuItem;

	private ToolStripMenuItem rEFRESHToolStripMenuItem;

	private ToolStripMenuItem eXECUTEToolStripMenuItem;

	private ToolStripMenuItem gOTOToolStripMenuItem;

	private ToolStripMenuItem dESKTOPToolStripMenuItem;

	private ToolStripMenuItem aPPDATAToolStripMenuItem;

	private ToolStripSeparator toolStripSeparator4;

	private ToolStripMenuItem createFolderToolStripMenuItem;

	private ToolStripMenuItem copyToolStripMenuItem;

	private ToolStripMenuItem pasteToolStripMenuItem;

	private ToolStripMenuItem renameToolStripMenuItem;

	public ToolStripStatusLabel toolStripStatusLabel3;

	private ToolStripMenuItem userProfileToolStripMenuItem;

	private ToolStripSeparator toolStripSeparator2;

	private ToolStripMenuItem driversListsToolStripMenuItem;

	private ToolStripSeparator toolStripSeparator3;

	private ToolStripMenuItem openClientFolderToolStripMenuItem;

	public System.Windows.Forms.Timer timer1;

	private ToolStripSeparator toolStripSeparator5;

	private ToolStripMenuItem cutToolStripMenuItem1;

	private ToolStripMenuItem sevenZiplStripMenuItem1;

	private ToolStripMenuItem installToolStripMenuItem;

	private ToolStripSeparator toolStripSeparator6;

	private ToolStripMenuItem zipToolStripMenuItem;

	private ToolStripMenuItem unzipToolStripMenuItem;

	private ColumnHeader columnHeader1;

	private ColumnHeader columnHeader2;

	private Guna2PictureBox guna2PictureBox1;

	private Guna2Panel guna2Panel1;

	private Guna2ContextMenuStrip guna2ContextMenuStrip2;

	private ToolStripMenuItem toolStripMenuItem1;

	private ToolStripMenuItem toolStripMenuItem2;

	private ToolStripMenuItem toolStripMenuItem3;

	private ToolStripMenuItem toolStripMenuItem4;

	private ToolStripMenuItem toolStripMenuItem5;

	private ToolStripMenuItem toolStripMenuItem6;

	private ToolStripMenuItem toolStripMenuItem7;

	private ToolStripMenuItem toolStripMenuItem8;

	private ToolStripMenuItem toolStripMenuItem9;

	private ToolStripMenuItem toolStripMenuItem10;

	private ToolStripMenuItem toolStripMenuItem11;

	private ToolStripMenuItem toolStripMenuItem12;

	private ToolStripMenuItem toolStripMenuItem13;

	private ToolStripMenuItem toolStripMenuItem14;

	private ToolStripMenuItem toolStripMenuItem15;

	private ToolStripMenuItem toolStripMenuItem16;

	private ToolStripMenuItem toolStripMenuItem17;

	private ToolStripMenuItem toolStripMenuItem18;

	private ToolStripMenuItem toolStripMenuItem19;

	private ToolStripMenuItem toolStripMenuItem20;

	private ToolStripMenuItem toolStripMenuItem21;

	private Label label1;

	private PictureBox pictureBox1;

	private Guna2Separator guna2Separator1;

	private Guna2BorderlessForm guna2BorderlessForm1;

	private Guna2ShadowForm guna2ShadowForm1;

	public PEGASUSMain F { get; set; }

	internal Clients Client { get; set; }

	public string FullPath { get; set; }

	public FormFileManager()
	{
		InitializeComponent();
	}

	private void listView1_DoubleClick(object sender, EventArgs e)
	{
		try
		{
			if (listView1.SelectedItems.Count == 1)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
				msgPack.ForcePathObject("Command").AsString = "getPath";
				msgPack.ForcePathObject("Path").AsString = listView1.SelectedItems[0].ToolTipText;
				listView1.Enabled = false;
				toolStripStatusLabel3.ForeColor = Color.FromArgb(3, 130, 200);
				toolStripStatusLabel3.Text = "Please Wait";
				ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
			}
		}
		catch
		{
		}
	}

	private void backToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			MsgPack msgPack = new MsgPack();
			string text = toolStripStatusLabel1.Text;
			if (text.Length <= 3)
			{
				msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
				msgPack.ForcePathObject("Command").AsString = "getDrivers";
				toolStripStatusLabel1.Text = "";
				ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
			}
			else
			{
				text = text.Remove(text.LastIndexOfAny(new char[1] { '\\' }, text.LastIndexOf('\\')));
				msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
				msgPack.ForcePathObject("Command").AsString = "getPath";
				msgPack.ForcePathObject("Path").AsString = text + "\\";
				ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
			}
		}
		catch
		{
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "fileManager";
			msgPack2.ForcePathObject("Command").AsString = "getDrivers";
			toolStripStatusLabel1.Text = "";
			ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
		}
	}

	private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			if (!Directory.Exists(Path.Combine(Application.StartupPath, "ClientsFolder\\" + Client.ID)))
			{
				Directory.CreateDirectory(Path.Combine(Application.StartupPath, "ClientsFolder\\" + Client.ID));
			}
			foreach (ListViewItem selectedItem in listView1.SelectedItems)
			{
				if (selectedItem.ImageIndex == 0 && selectedItem.ImageIndex == 1 && selectedItem.ImageIndex == 2)
				{
					break;
				}
				MsgPack msgPack = new MsgPack();
				string dwid = Guid.NewGuid().ToString();
				msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
				msgPack.ForcePathObject("Command").AsString = "socketDownload";
				msgPack.ForcePathObject("File").AsString = selectedItem.ToolTipText;
				msgPack.ForcePathObject("DWID").AsString = dwid;
				ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
				BeginInvoke((MethodInvoker)delegate
				{
					if ((FormDownloadFile)Application.OpenForms["socketDownload:" + dwid] == null)
					{
						FormDownloadFile formDownloadFile = new FormDownloadFile();
						formDownloadFile.Name = "socketDownload:" + dwid;
						formDownloadFile.Text = "socketDownload:" + Client.ID;
						formDownloadFile.F = F;
						formDownloadFile.DirPath = FullPath;
						formDownloadFile.Show();
					}
				});
			}
		}
		catch
		{
		}
	}

	private void uPLOADToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (toolStripStatusLabel1.Text.Length < 3)
		{
			return;
		}
		try
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Multiselect = true;
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			string[] fileNames = openFileDialog.FileNames;
			foreach (string text in fileNames)
			{
				FormDownloadFile formDownloadFile = (FormDownloadFile)Application.OpenForms["socketDownload:"];
				if (formDownloadFile == null)
				{
					formDownloadFile = new FormDownloadFile
					{
						Name = "socketUpload:" + Guid.NewGuid().ToString(),
						Text = "socketUpload:" + Client.ID,
						F = Program.form1,
						Client = Client
					};
					formDownloadFile.FileSize = new FileInfo(text).Length;
					formDownloadFile.labelfile.Text = Path.GetFileName(text);
					formDownloadFile.FullFileName = text;
					formDownloadFile.label1.Text = "Upload:";
					formDownloadFile.ClientFullFileName = toolStripStatusLabel1.Text + "\\" + Path.GetFileName(text);
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
					msgPack.ForcePathObject("Command").AsString = "reqUploadFile";
					msgPack.ForcePathObject("ID").AsString = formDownloadFile.Name;
					formDownloadFile.Show();
					ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
				}
			}
		}
		catch
		{
		}
	}

	private void dELETEToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			foreach (ListViewItem selectedItem in listView1.SelectedItems)
			{
				if (selectedItem.ImageIndex != 0 && selectedItem.ImageIndex != 1 && selectedItem.ImageIndex != 2)
				{
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
					msgPack.ForcePathObject("Command").AsString = "deleteFile";
					msgPack.ForcePathObject("File").AsString = selectedItem.ToolTipText;
					ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
				}
				else if (selectedItem.ImageIndex == 0)
				{
					MsgPack msgPack2 = new MsgPack();
					msgPack2.ForcePathObject("Pac_ket").AsString = "fileManager";
					msgPack2.ForcePathObject("Command").AsString = "deleteFolder";
					msgPack2.ForcePathObject("Folder").AsString = selectedItem.ToolTipText;
					ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
				}
			}
		}
		catch
		{
		}
	}

	private void rEFRESHToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			if (toolStripStatusLabel1.Text != "")
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
				msgPack.ForcePathObject("Command").AsString = "getPath";
				msgPack.ForcePathObject("Path").AsString = toolStripStatusLabel1.Text;
				ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
			}
			else
			{
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "fileManager";
				msgPack2.ForcePathObject("Command").AsString = "getDrivers";
				ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
			}
		}
		catch
		{
		}
	}

	private void eXECUTEToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			foreach (ListViewItem selectedItem in listView1.SelectedItems)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
				msgPack.ForcePathObject("Command").AsString = "execute";
				msgPack.ForcePathObject("File").AsString = selectedItem.ToolTipText;
				ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
			}
		}
		catch
		{
		}
	}

	private void Timer1_Tick(object sender, EventArgs e)
	{
		try
		{
			if (!Client.TcpClient.Connected)
			{
				Close();
			}
		}
		catch
		{
			Close();
		}
	}

	private void DESKTOPToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
			msgPack.ForcePathObject("Command").AsString = "getPath";
			msgPack.ForcePathObject("Path").AsString = "DESKTOP";
			ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
		}
		catch
		{
		}
	}

	private void APPDATAToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
			msgPack.ForcePathObject("Command").AsString = "getPath";
			msgPack.ForcePathObject("Path").AsString = "APPDATA";
			ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
		}
		catch
		{
		}
	}

	private void CreateFolderToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			string text = Interaction.InputBox("Create Folder", "Name", Path.GetRandomFileName().Replace(".", ""));
			if (!string.IsNullOrEmpty(text))
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
				msgPack.ForcePathObject("Command").AsString = "createFolder";
				msgPack.ForcePathObject("Folder").AsString = Path.Combine(toolStripStatusLabel1.Text, text);
				ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
			}
		}
		catch
		{
		}
	}

	private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (ListViewItem selectedItem in listView1.SelectedItems)
			{
				stringBuilder.Append(selectedItem.ToolTipText + "-=>");
			}
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
			msgPack.ForcePathObject("Command").AsString = "copyFile";
			msgPack.ForcePathObject("File").AsString = stringBuilder.ToString();
			msgPack.ForcePathObject("IO").AsString = "copy";
			ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
		}
		catch
		{
		}
	}

	private void PasteToolStripMenuItem_Click_1(object sender, EventArgs e)
	{
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
			msgPack.ForcePathObject("Command").AsString = "pasteFile";
			msgPack.ForcePathObject("File").AsString = toolStripStatusLabel1.Text;
			ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
		}
		catch
		{
		}
	}

	private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (listView1.SelectedItems.Count != 1)
		{
			return;
		}
		try
		{
			string text = Interaction.InputBox("Rename File or Folder", "Name", listView1.SelectedItems[0].Text);
			if (!string.IsNullOrEmpty(text))
			{
				if (listView1.SelectedItems[0].ImageIndex != 0 && listView1.SelectedItems[0].ImageIndex != 1 && listView1.SelectedItems[0].ImageIndex != 2)
				{
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
					msgPack.ForcePathObject("Command").AsString = "renameFile";
					msgPack.ForcePathObject("File").AsString = listView1.SelectedItems[0].ToolTipText;
					msgPack.ForcePathObject("NewName").AsString = Path.Combine(toolStripStatusLabel1.Text, text);
					ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
				}
				else if (listView1.SelectedItems[0].ImageIndex == 0)
				{
					MsgPack msgPack2 = new MsgPack();
					msgPack2.ForcePathObject("Pac_ket").AsString = "fileManager";
					msgPack2.ForcePathObject("Command").AsString = "renameFolder";
					msgPack2.ForcePathObject("Folder").AsString = listView1.SelectedItems[0].ToolTipText + "\\";
					msgPack2.ForcePathObject("NewName").AsString = Path.Combine(toolStripStatusLabel1.Text, text);
					ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
				}
			}
		}
		catch
		{
		}
	}

	private void UserProfileToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
			msgPack.ForcePathObject("Command").AsString = "getPath";
			msgPack.ForcePathObject("Path").AsString = "USER";
			ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
		}
		catch
		{
		}
	}

	private void DriversListsToolStripMenuItem_Click(object sender, EventArgs e)
	{
		MsgPack msgPack = new MsgPack();
		msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
		msgPack.ForcePathObject("Command").AsString = "getDrivers";
		toolStripStatusLabel1.Text = "";
		ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
	}

	private void OpenClientFolderToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			if (!Directory.Exists(FullPath))
			{
				Directory.CreateDirectory(FullPath);
			}
			Process.Start(FullPath);
		}
		catch
		{
		}
	}

	private void FormFileManager_FormClosed(object sender, FormClosedEventArgs e)
	{
		ThreadPool.QueueUserWorkItem(delegate
		{
			Client?.Disconnected();
		});
	}

	private void CutToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		try
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (ListViewItem selectedItem in listView1.SelectedItems)
			{
				stringBuilder.Append(selectedItem.ToolTipText + "-=>");
			}
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
			msgPack.ForcePathObject("Command").AsString = "copyFile";
			msgPack.ForcePathObject("File").AsString = stringBuilder.ToString();
			msgPack.ForcePathObject("IO").AsString = "cut";
			ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
		}
		catch
		{
		}
	}

	private void ZipToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (ListViewItem selectedItem in listView1.SelectedItems)
			{
				stringBuilder.Append(selectedItem.ToolTipText + "-=>");
			}
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
			msgPack.ForcePathObject("Command").AsString = "zip";
			msgPack.ForcePathObject("Path").AsString = stringBuilder.ToString();
			msgPack.ForcePathObject("Zip").AsString = "true";
			ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
		}
		catch
		{
		}
	}

	private void UnzipToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			foreach (ListViewItem selectedItem in listView1.SelectedItems)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
				msgPack.ForcePathObject("Command").AsString = "zip";
				msgPack.ForcePathObject("Path").AsString = selectedItem.ToolTipText;
				msgPack.ForcePathObject("Zip").AsString = "false";
				ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
			}
		}
		catch
		{
		}
	}

	private void InstallToolStripMenuItem_Click(object sender, EventArgs e)
	{
		MsgPack msgPack = new MsgPack();
		msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
		msgPack.ForcePathObject("Command").AsString = "installZip";
		msgPack.ForcePathObject("exe").SetAsBytes(Resources._7z);
		msgPack.ForcePathObject("dll").SetAsBytes(Resources._7z1);
		ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
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
		System.Windows.Forms.ListViewGroup listViewGroup = new System.Windows.Forms.ListViewGroup("Folders", System.Windows.Forms.HorizontalAlignment.Left);
		System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("File", System.Windows.Forms.HorizontalAlignment.Left);
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFileManager));
		listView1 = new System.Windows.Forms.ListView();
		columnHeader1 = new System.Windows.Forms.ColumnHeader();
		columnHeader2 = new System.Windows.Forms.ColumnHeader();
		guna2ContextMenuStrip2 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
		toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem21 = new System.Windows.Forms.ToolStripMenuItem();
		imageList1 = new System.Windows.Forms.ImageList(components);
		contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
		backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		rEFRESHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		gOTOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		dESKTOPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		aPPDATAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		userProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
		driversListsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		uPLOADToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		eXECUTEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		cutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		dELETEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
		sevenZiplStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		installToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
		zipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		unzipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
		createFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
		openClientFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		statusStrip1 = new System.Windows.Forms.StatusStrip();
		toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
		toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
		toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
		timer1 = new System.Windows.Forms.Timer(components);
		guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
		guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
		guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		label1 = new System.Windows.Forms.Label();
		guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
		guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
		guna2ContextMenuStrip2.SuspendLayout();
		contextMenuStrip1.SuspendLayout();
		statusStrip1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
		guna2Panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		listView1.AllowColumnReorder = true;
		listView1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { columnHeader1, columnHeader2 });
		listView1.ContextMenuStrip = guna2ContextMenuStrip2;
		listView1.Dock = System.Windows.Forms.DockStyle.Fill;
		listView1.ForeColor = System.Drawing.Color.LightGray;
		listViewGroup.Header = "Folders";
		listViewGroup.Name = "Folders";
		listViewGroup2.Header = "File";
		listViewGroup2.Name = "File";
		listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[2] { listViewGroup, listViewGroup2 });
		listView1.HideSelection = false;
		listView1.LargeImageList = imageList1;
		listView1.Location = new System.Drawing.Point(0, 67);
		listView1.Margin = new System.Windows.Forms.Padding(2);
		listView1.Name = "listView1";
		listView1.ShowItemToolTips = true;
		listView1.Size = new System.Drawing.Size(799, 446);
		listView1.SmallImageList = imageList1;
		listView1.TabIndex = 0;
		listView1.UseCompatibleStateImageBehavior = false;
		listView1.View = System.Windows.Forms.View.Tile;
		listView1.DoubleClick += new System.EventHandler(listView1_DoubleClick);
		guna2ContextMenuStrip2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2ContextMenuStrip2.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		guna2ContextMenuStrip2.ImageScalingSize = new System.Drawing.Size(26, 26);
		guna2ContextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
		{
			toolStripMenuItem1, toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem8, toolStripMenuItem9, toolStripMenuItem10, toolStripMenuItem11, toolStripMenuItem12, toolStripMenuItem13, toolStripMenuItem14,
			toolStripMenuItem15, toolStripMenuItem16, toolStripMenuItem20, toolStripMenuItem21
		});
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
		guna2ContextMenuStrip2.Size = new System.Drawing.Size(177, 312);
		toolStripMenuItem1.ForeColor = System.Drawing.Color.LightGray;
		toolStripMenuItem1.Name = "toolStripMenuItem1";
		toolStripMenuItem1.Size = new System.Drawing.Size(176, 22);
		toolStripMenuItem1.Text = "Back";
		toolStripMenuItem1.Click += new System.EventHandler(backToolStripMenuItem_Click);
		toolStripMenuItem2.ForeColor = System.Drawing.Color.LightGray;
		toolStripMenuItem2.Name = "toolStripMenuItem2";
		toolStripMenuItem2.Size = new System.Drawing.Size(176, 22);
		toolStripMenuItem2.Text = "Refresh";
		toolStripMenuItem2.Click += new System.EventHandler(rEFRESHToolStripMenuItem_Click);
		toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { toolStripMenuItem4, toolStripMenuItem5, toolStripMenuItem6, toolStripMenuItem7 });
		toolStripMenuItem3.ForeColor = System.Drawing.Color.LightGray;
		toolStripMenuItem3.Name = "toolStripMenuItem3";
		toolStripMenuItem3.Size = new System.Drawing.Size(176, 22);
		toolStripMenuItem3.Text = "Go to";
		toolStripMenuItem4.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		toolStripMenuItem4.ForeColor = System.Drawing.Color.LightGray;
		toolStripMenuItem4.Name = "toolStripMenuItem4";
		toolStripMenuItem4.Size = new System.Drawing.Size(141, 22);
		toolStripMenuItem4.Text = "Desktop";
		toolStripMenuItem4.Click += new System.EventHandler(DESKTOPToolStripMenuItem_Click);
		toolStripMenuItem5.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		toolStripMenuItem5.ForeColor = System.Drawing.Color.LightGray;
		toolStripMenuItem5.Name = "toolStripMenuItem5";
		toolStripMenuItem5.Size = new System.Drawing.Size(141, 22);
		toolStripMenuItem5.Text = "AppData";
		toolStripMenuItem5.Click += new System.EventHandler(APPDATAToolStripMenuItem_Click);
		toolStripMenuItem6.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		toolStripMenuItem6.ForeColor = System.Drawing.Color.LightGray;
		toolStripMenuItem6.Name = "toolStripMenuItem6";
		toolStripMenuItem6.Size = new System.Drawing.Size(141, 22);
		toolStripMenuItem6.Text = "User Profile";
		toolStripMenuItem6.Click += new System.EventHandler(UserProfileToolStripMenuItem_Click);
		toolStripMenuItem7.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		toolStripMenuItem7.ForeColor = System.Drawing.Color.LightGray;
		toolStripMenuItem7.Name = "toolStripMenuItem7";
		toolStripMenuItem7.Size = new System.Drawing.Size(141, 22);
		toolStripMenuItem7.Text = "Drivers";
		toolStripMenuItem7.Click += new System.EventHandler(DriversListsToolStripMenuItem_Click);
		toolStripMenuItem8.ForeColor = System.Drawing.Color.LightGray;
		toolStripMenuItem8.Name = "toolStripMenuItem8";
		toolStripMenuItem8.Size = new System.Drawing.Size(176, 22);
		toolStripMenuItem8.Text = "Download";
		toolStripMenuItem8.Click += new System.EventHandler(downloadToolStripMenuItem_Click);
		toolStripMenuItem9.ForeColor = System.Drawing.Color.LightGray;
		toolStripMenuItem9.Name = "toolStripMenuItem9";
		toolStripMenuItem9.Size = new System.Drawing.Size(176, 22);
		toolStripMenuItem9.Text = "Upload";
		toolStripMenuItem9.Click += new System.EventHandler(uPLOADToolStripMenuItem_Click);
		toolStripMenuItem10.ForeColor = System.Drawing.Color.LightGray;
		toolStripMenuItem10.Name = "toolStripMenuItem10";
		toolStripMenuItem10.Size = new System.Drawing.Size(176, 22);
		toolStripMenuItem10.Text = "Execute";
		toolStripMenuItem10.Click += new System.EventHandler(eXECUTEToolStripMenuItem_Click);
		toolStripMenuItem11.ForeColor = System.Drawing.Color.LightGray;
		toolStripMenuItem11.Name = "toolStripMenuItem11";
		toolStripMenuItem11.Size = new System.Drawing.Size(176, 22);
		toolStripMenuItem11.Text = "Rename";
		toolStripMenuItem11.Click += new System.EventHandler(RenameToolStripMenuItem_Click);
		toolStripMenuItem12.ForeColor = System.Drawing.Color.LightGray;
		toolStripMenuItem12.Name = "toolStripMenuItem12";
		toolStripMenuItem12.Size = new System.Drawing.Size(176, 22);
		toolStripMenuItem12.Text = "Copy";
		toolStripMenuItem12.Click += new System.EventHandler(CopyToolStripMenuItem_Click);
		toolStripMenuItem13.ForeColor = System.Drawing.Color.LightGray;
		toolStripMenuItem13.Name = "toolStripMenuItem13";
		toolStripMenuItem13.Size = new System.Drawing.Size(176, 22);
		toolStripMenuItem13.Text = "Cut";
		toolStripMenuItem13.Click += new System.EventHandler(CutToolStripMenuItem1_Click);
		toolStripMenuItem14.ForeColor = System.Drawing.Color.LightGray;
		toolStripMenuItem14.Name = "toolStripMenuItem14";
		toolStripMenuItem14.Size = new System.Drawing.Size(176, 22);
		toolStripMenuItem14.Text = "Paste";
		toolStripMenuItem14.Click += new System.EventHandler(PasteToolStripMenuItem_Click_1);
		toolStripMenuItem15.ForeColor = System.Drawing.Color.LightGray;
		toolStripMenuItem15.Name = "toolStripMenuItem15";
		toolStripMenuItem15.Size = new System.Drawing.Size(176, 22);
		toolStripMenuItem15.Text = "Delete";
		toolStripMenuItem15.Click += new System.EventHandler(dELETEToolStripMenuItem_Click);
		toolStripMenuItem16.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { toolStripMenuItem17, toolStripMenuItem18, toolStripMenuItem19 });
		toolStripMenuItem16.ForeColor = System.Drawing.Color.LightGray;
		toolStripMenuItem16.Name = "toolStripMenuItem16";
		toolStripMenuItem16.Size = new System.Drawing.Size(176, 22);
		toolStripMenuItem16.Text = "7-Zip";
		toolStripMenuItem17.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		toolStripMenuItem17.ForeColor = System.Drawing.Color.LightGray;
		toolStripMenuItem17.Name = "toolStripMenuItem17";
		toolStripMenuItem17.Size = new System.Drawing.Size(108, 22);
		toolStripMenuItem17.Text = "Install";
		toolStripMenuItem17.Click += new System.EventHandler(InstallToolStripMenuItem_Click);
		toolStripMenuItem18.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		toolStripMenuItem18.ForeColor = System.Drawing.Color.LightGray;
		toolStripMenuItem18.Name = "toolStripMenuItem18";
		toolStripMenuItem18.Size = new System.Drawing.Size(108, 22);
		toolStripMenuItem18.Text = "Zip";
		toolStripMenuItem18.Click += new System.EventHandler(ZipToolStripMenuItem_Click);
		toolStripMenuItem19.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		toolStripMenuItem19.ForeColor = System.Drawing.Color.LightGray;
		toolStripMenuItem19.Name = "toolStripMenuItem19";
		toolStripMenuItem19.Size = new System.Drawing.Size(108, 22);
		toolStripMenuItem19.Text = "Unzip";
		toolStripMenuItem19.Click += new System.EventHandler(UnzipToolStripMenuItem_Click);
		toolStripMenuItem20.ForeColor = System.Drawing.Color.LightGray;
		toolStripMenuItem20.Name = "toolStripMenuItem20";
		toolStripMenuItem20.Size = new System.Drawing.Size(176, 22);
		toolStripMenuItem20.Text = "New Folder";
		toolStripMenuItem20.Click += new System.EventHandler(CreateFolderToolStripMenuItem_Click);
		toolStripMenuItem21.ForeColor = System.Drawing.Color.LightGray;
		toolStripMenuItem21.Name = "toolStripMenuItem21";
		toolStripMenuItem21.Size = new System.Drawing.Size(176, 22);
		toolStripMenuItem21.Text = "Open Client folder";
		toolStripMenuItem21.Click += new System.EventHandler(OpenClientFolderToolStripMenuItem_Click);
		imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
		imageList1.TransparentColor = System.Drawing.Color.Transparent;
		imageList1.Images.SetKeyName(0, "AsyncFolder.png");
		imageList1.Images.SetKeyName(1, "AsyncHDDFixed.png");
		imageList1.Images.SetKeyName(2, "AsyncUSB.png");
		contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
		contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[18]
		{
			backToolStripMenuItem, rEFRESHToolStripMenuItem, gOTOToolStripMenuItem, toolStripSeparator1, downloadToolStripMenuItem, uPLOADToolStripMenuItem, eXECUTEToolStripMenuItem, renameToolStripMenuItem, copyToolStripMenuItem, cutToolStripMenuItem1,
			pasteToolStripMenuItem, dELETEToolStripMenuItem, toolStripSeparator4, sevenZiplStripMenuItem1, toolStripSeparator5, createFolderToolStripMenuItem, toolStripSeparator3, openClientFolderToolStripMenuItem
		});
		contextMenuStrip1.Name = "contextMenuStrip1";
		contextMenuStrip1.Size = new System.Drawing.Size(172, 336);
		backToolStripMenuItem.Name = "backToolStripMenuItem";
		backToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
		backToolStripMenuItem.Text = "Back";
		backToolStripMenuItem.Click += new System.EventHandler(backToolStripMenuItem_Click);
		rEFRESHToolStripMenuItem.Name = "rEFRESHToolStripMenuItem";
		rEFRESHToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
		rEFRESHToolStripMenuItem.Text = "Refresh";
		rEFRESHToolStripMenuItem.Click += new System.EventHandler(rEFRESHToolStripMenuItem_Click);
		gOTOToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[5] { dESKTOPToolStripMenuItem, aPPDATAToolStripMenuItem, userProfileToolStripMenuItem, toolStripSeparator2, driversListsToolStripMenuItem });
		gOTOToolStripMenuItem.Name = "gOTOToolStripMenuItem";
		gOTOToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
		gOTOToolStripMenuItem.Text = "Go to";
		dESKTOPToolStripMenuItem.Name = "dESKTOPToolStripMenuItem";
		dESKTOPToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
		dESKTOPToolStripMenuItem.Text = "Desktop";
		dESKTOPToolStripMenuItem.Click += new System.EventHandler(DESKTOPToolStripMenuItem_Click);
		aPPDATAToolStripMenuItem.Name = "aPPDATAToolStripMenuItem";
		aPPDATAToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
		aPPDATAToolStripMenuItem.Text = "AppData";
		aPPDATAToolStripMenuItem.Click += new System.EventHandler(APPDATAToolStripMenuItem_Click);
		userProfileToolStripMenuItem.Name = "userProfileToolStripMenuItem";
		userProfileToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
		userProfileToolStripMenuItem.Text = "User Profile";
		userProfileToolStripMenuItem.Click += new System.EventHandler(UserProfileToolStripMenuItem_Click);
		toolStripSeparator2.Name = "toolStripSeparator2";
		toolStripSeparator2.Size = new System.Drawing.Size(131, 6);
		driversListsToolStripMenuItem.Name = "driversListsToolStripMenuItem";
		driversListsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
		driversListsToolStripMenuItem.Text = "Drivers";
		driversListsToolStripMenuItem.Click += new System.EventHandler(DriversListsToolStripMenuItem_Click);
		toolStripSeparator1.Name = "toolStripSeparator1";
		toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
		downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
		downloadToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
		downloadToolStripMenuItem.Text = "Download";
		downloadToolStripMenuItem.Click += new System.EventHandler(downloadToolStripMenuItem_Click);
		uPLOADToolStripMenuItem.Name = "uPLOADToolStripMenuItem";
		uPLOADToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
		uPLOADToolStripMenuItem.Text = "Upload";
		uPLOADToolStripMenuItem.Click += new System.EventHandler(uPLOADToolStripMenuItem_Click);
		eXECUTEToolStripMenuItem.Name = "eXECUTEToolStripMenuItem";
		eXECUTEToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
		eXECUTEToolStripMenuItem.Text = "Execute";
		eXECUTEToolStripMenuItem.Click += new System.EventHandler(eXECUTEToolStripMenuItem_Click);
		renameToolStripMenuItem.Name = "renameToolStripMenuItem";
		renameToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
		renameToolStripMenuItem.Text = "Rename";
		renameToolStripMenuItem.Click += new System.EventHandler(RenameToolStripMenuItem_Click);
		copyToolStripMenuItem.Name = "copyToolStripMenuItem";
		copyToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
		copyToolStripMenuItem.Text = "Copy";
		copyToolStripMenuItem.Click += new System.EventHandler(CopyToolStripMenuItem_Click);
		cutToolStripMenuItem1.Name = "cutToolStripMenuItem1";
		cutToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
		cutToolStripMenuItem1.Text = "Cut";
		cutToolStripMenuItem1.Click += new System.EventHandler(CutToolStripMenuItem1_Click);
		pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
		pasteToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
		pasteToolStripMenuItem.Text = "Paste";
		pasteToolStripMenuItem.Click += new System.EventHandler(PasteToolStripMenuItem_Click_1);
		dELETEToolStripMenuItem.Name = "dELETEToolStripMenuItem";
		dELETEToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
		dELETEToolStripMenuItem.Text = "Delete";
		dELETEToolStripMenuItem.Click += new System.EventHandler(dELETEToolStripMenuItem_Click);
		toolStripSeparator4.Name = "toolStripSeparator4";
		toolStripSeparator4.Size = new System.Drawing.Size(168, 6);
		sevenZiplStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { installToolStripMenuItem, toolStripSeparator6, zipToolStripMenuItem, unzipToolStripMenuItem });
		sevenZiplStripMenuItem1.Name = "sevenZiplStripMenuItem1";
		sevenZiplStripMenuItem1.Size = new System.Drawing.Size(171, 22);
		sevenZiplStripMenuItem1.Text = "7-Zip";
		installToolStripMenuItem.Name = "installToolStripMenuItem";
		installToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
		installToolStripMenuItem.Text = "Install";
		installToolStripMenuItem.Click += new System.EventHandler(InstallToolStripMenuItem_Click);
		toolStripSeparator6.Name = "toolStripSeparator6";
		toolStripSeparator6.Size = new System.Drawing.Size(102, 6);
		zipToolStripMenuItem.Name = "zipToolStripMenuItem";
		zipToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
		zipToolStripMenuItem.Text = "Zip";
		zipToolStripMenuItem.Click += new System.EventHandler(ZipToolStripMenuItem_Click);
		unzipToolStripMenuItem.Name = "unzipToolStripMenuItem";
		unzipToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
		unzipToolStripMenuItem.Text = "Unzip";
		unzipToolStripMenuItem.Click += new System.EventHandler(UnzipToolStripMenuItem_Click);
		toolStripSeparator5.Name = "toolStripSeparator5";
		toolStripSeparator5.Size = new System.Drawing.Size(168, 6);
		createFolderToolStripMenuItem.Name = "createFolderToolStripMenuItem";
		createFolderToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
		createFolderToolStripMenuItem.Text = "New Folder";
		createFolderToolStripMenuItem.Click += new System.EventHandler(CreateFolderToolStripMenuItem_Click);
		toolStripSeparator3.Name = "toolStripSeparator3";
		toolStripSeparator3.Size = new System.Drawing.Size(168, 6);
		openClientFolderToolStripMenuItem.Name = "openClientFolderToolStripMenuItem";
		openClientFolderToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
		openClientFolderToolStripMenuItem.Text = "Open Client folder";
		openClientFolderToolStripMenuItem.Click += new System.EventHandler(OpenClientFolderToolStripMenuItem_Click);
		statusStrip1.AutoSize = false;
		statusStrip1.BackColor = System.Drawing.Color.Transparent;
		statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
		statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { toolStripStatusLabel1, toolStripStatusLabel2, toolStripStatusLabel3 });
		statusStrip1.Location = new System.Drawing.Point(0, 513);
		statusStrip1.Name = "statusStrip1";
		statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 9, 0);
		statusStrip1.Size = new System.Drawing.Size(799, 21);
		statusStrip1.SizingGrip = false;
		statusStrip1.TabIndex = 2;
		statusStrip1.Text = "statusStrip1";
		statusStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
		toolStripStatusLabel1.Name = "toolStripStatusLabel1";
		toolStripStatusLabel1.Size = new System.Drawing.Size(13, 16);
		toolStripStatusLabel1.Text = "..";
		toolStripStatusLabel2.Name = "toolStripStatusLabel2";
		toolStripStatusLabel2.Size = new System.Drawing.Size(13, 16);
		toolStripStatusLabel2.Text = "..";
		toolStripStatusLabel3.ForeColor = System.Drawing.Color.DodgerBlue;
		toolStripStatusLabel3.Name = "toolStripStatusLabel3";
		toolStripStatusLabel3.Size = new System.Drawing.Size(13, 16);
		toolStripStatusLabel3.Text = "..";
		timer1.Interval = 1000;
		timer1.Tick += new System.EventHandler(Timer1_Tick);
		guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
		guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
		guna2PictureBox1.ImageRotate = 0f;
		guna2PictureBox1.Location = new System.Drawing.Point(758, 12);
		guna2PictureBox1.Name = "guna2PictureBox1";
		guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
		guna2PictureBox1.Size = new System.Drawing.Size(29, 27);
		guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		guna2PictureBox1.TabIndex = 12;
		guna2PictureBox1.TabStop = false;
		guna2PictureBox1.UseTransparentBackground = true;
		guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
		guna2Panel1.Controls.Add(guna2Separator1);
		guna2Panel1.Controls.Add(pictureBox1);
		guna2Panel1.Controls.Add(label1);
		guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		guna2Panel1.Location = new System.Drawing.Point(0, 0);
		guna2Panel1.Name = "guna2Panel1";
		guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
		guna2Panel1.Size = new System.Drawing.Size(799, 67);
		guna2Panel1.TabIndex = 13;
		guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
		guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		guna2Separator1.BackColor = System.Drawing.Color.Transparent;
		guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2Separator1.Location = new System.Drawing.Point(-250, 61);
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
		label1.Location = new System.Drawing.Point(332, 20);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(138, 19);
		label1.TabIndex = 11;
		label1.Text = "FILE MANAGER";
		guna2BorderlessForm1.ContainerControl = this;
		guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2ShadowForm1.TargetForm = this;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		base.ClientSize = new System.Drawing.Size(799, 534);
		base.Controls.Add(guna2PictureBox1);
		base.Controls.Add(listView1);
		base.Controls.Add(guna2Panel1);
		base.Controls.Add(statusStrip1);
		ForeColor = System.Drawing.Color.LightGray;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(2);
		base.Name = "FormFileManager";
		Text = "File Manager";
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FormFileManager_FormClosed);
		guna2ContextMenuStrip2.ResumeLayout(false);
		contextMenuStrip1.ResumeLayout(false);
		statusStrip1.ResumeLayout(false);
		statusStrip1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
		guna2Panel1.ResumeLayout(false);
		guna2Panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
	}
}
}