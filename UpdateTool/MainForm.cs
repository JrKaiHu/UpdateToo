using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

using System.Xml;
using System.Xml.Linq;
using System.Reflection;
using System.IO.Compression;

using Ionic.Zip;


namespace UpdateTool
{
    public partial class MainForm : Form
    {
        private string m_strProName;

        public MainForm()
        {
            InitializeComponent();
        }

        #region Button call back

        private void OnButtonClicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            TextBox txt = btn == btnBrowseDes ? txtDes : txtSrc;
            Label lblVer = btn == btnBrowseDes ? lblDesVer : lblSrcVer;
            Label lblLastTime = btn == btnBrowseDes ? lblDesLastTime : lblSrcLastTime;

            string strFileName = btn == btnBrowseDes ? "OldVersion.xml" : "NewVersion.xml";

            if (btn == btnBrowseDes || btn == btnBrowseSrc)
            {
                FolderBrowserDialog path = new FolderBrowserDialog();
                DialogResult res = path.ShowDialog();

                if (res == DialogResult.OK)
                {
                    string strExePath = CheckOutFolder(path.SelectedPath);

                    if (strExePath.Length != 0)
                    {
                        var versionInfo = FileVersionInfo.GetVersionInfo(strExePath);
                        lblVer.Text = "程式版本 : " + versionInfo.FileVersion;
                        lblLastTime.Text = "最後修改時間 : " + File.GetLastWriteTime(strExePath).ToString("yyyy/MM/dd HH:mm:ss");
                        txt.Text = path.SelectedPath;
                    }
                    else
                    {
                        MessageBox.Show("Invalid folder path!!");
                    }
                }
            }
        }

        private void OnCompareClicked(object sender, EventArgs e)
        {
            Logger.Debug("OnCompareClicked() +");

            if (txtDes.Text.Length == 0 || txtSrc.Text.Length == 0) return;

            tvNewVer.CheckBoxes = !File.Exists("Config\\NewVersion.xml");
            tvOldVer.CheckBoxes = !File.Exists("Config\\OldVersion.xml");

            tvNewVer.Nodes.Clear();
            tvOldVer.Nodes.Clear();

            DirectoryInfo rootDiNew = new DirectoryInfo(txtSrc.Text);
            DirectoryInfo rootDiOld = new DirectoryInfo(txtDes.Text);

            tvNewVer.Nodes.Add(CreateNewTree(rootDiNew));
            tvOldVer.Nodes.Add(CreateOldTree(rootDiOld));

            tvOldVer.AddLinkedTreeView(tvNewVer);

            SyncTwoTrees(tvOldVer.Nodes[0], tvNewVer.Nodes[0], Color.FromArgb(0x00, 0x80, 0xff));
            SyncTwoTrees(tvNewVer.Nodes[0], tvOldVer.Nodes[0], Color.FromArgb(0x00, 0x80, 0xff));

            tvNewVer.ExpandAll();
            tvOldVer.ExpandAll();

            //A custom file comparer defined below
            FileCompare myFileCompare = new FileCompare();

            // Take a snapshot of the file system.
            IEnumerable<FileInfo> lstNew = rootDiNew.GetFiles("*.*", SearchOption.AllDirectories);
            IEnumerable<FileInfo> lstOld = rootDiOld.GetFiles("*.*", SearchOption.AllDirectories);

            List<string> strOldFileLst = lstOld.Select(f => f.Name).ToList();
            List<string> strNewFileLst = lstNew.Select(f => f.Name).ToList();

            List<string> diffLst = strNewFileLst.Except(strOldFileLst).ToList();
            List<FileInfo> fLst1 = lstNew.Where(fi => diffLst.Contains(fi.Name)).ToList();

            diffLst = strOldFileLst.Except(strNewFileLst).ToList();
            List<FileInfo> fLst2 = lstOld.Where(fi => diffLst.Contains(fi.Name)).ToList();

            // Remove all files only belonging one folder
            lstNew = lstNew.Where(x => !fLst1.Contains(x));
            lstOld = lstOld.Where(x => !fLst2.Contains(x));

            Parallel.Invoke(() =>
            {
                IEnumerable<FileInfo> lstOldOnly = (from file in lstOld select file).Except(lstNew, myFileCompare);
                DrawColorToTree(tvOldVer, lstOldOnly);
            }, () =>
            {
                IEnumerable<FileInfo> lstNewOnly = (from file in lstNew select file).Except(lstOld, myFileCompare);
                DrawColorToTree(tvNewVer, lstNewOnly);
            });

            tvNewVer.Focus();

            Logger.Debug("OnCompareClicked() -");
        }

        private void OnUpdateClicked(object sender, EventArgs e)
        {
            Logger.Debug("OnUpdateClicked() +");

            // 確認xml中的檔案路經皆存在於實體目錄
            List<string> pathLst1 = new List<string>();
            List<string> pathLst2 = new List<string>();
            if (!CheckFilesByXml(txtDes.Text, "Config\\OldVersion.xml", pathLst1)) return;
            if (!CheckFilesByXml(txtSrc.Text, "Config\\NewVersion.xml", pathLst2)) return;

            // 備份舊版本資料夾
            string strBackUpPath = txtDes.Text + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            Directory.Move(txtDes.Text, txtDes.Text + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"));

            ZipFile zip = new ZipFile();
            zip.AddDirectory(strBackUpPath);
            zip.Save(strBackUpPath + ".zip");

            // 創建更新目標位置
            Directory.CreateDirectory(txtDes.Text);

            // 複製檔案至更新目標資料夾
            CopyFilesByXml(strBackUpPath, pathLst1);
            CopyFilesByXml(txtSrc.Text, pathLst2);

            // 刪除暫存資料夾
            DirectoryInfo di = new DirectoryInfo(strBackUpPath);
            di.Delete(true);

            // 更新目標位置的執行檔版號與時間
            string strExePath = txtDes.Text + "\\" + m_strProName + ".exe";
            var versionInfo = FileVersionInfo.GetVersionInfo(strExePath);
            lblDesVer.Text = "程式版本 : " + versionInfo.FileVersion;
            lblDesLastTime.Text = "最後修改時間 : " + File.GetLastWriteTime(strExePath).ToString("yyyy/MM/dd HH:mm:ss");

            MessageBox.Show("Update Ok!!");

            Logger.Debug("OnUpdateClicked() +");
        }

        private void OnCreateXmlClicked(object sender, EventArgs e)
        {
            Logger.Debug("OnCreateXmlClicked() +");

            string strCurrentDir =
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Config";

            // Determine whether the directory exists.
            if (!Directory.Exists(strCurrentDir))
            {
                DirectoryInfo di = Directory.CreateDirectory(strCurrentDir);
            }

            string path = Path.Combine(strCurrentDir, "OldVersion.xml");
            SerializeTreeView(tvOldVer, path);

            path = Path.Combine(strCurrentDir, "NewVersion.xml");
            SerializeTreeView(tvNewVer, path);

            MessageBox.Show("Create xml Ok!!");

            Logger.Debug("OnCreateXmlClicked() -");
        }

        #endregion

        #region Relative to comparison

        private void SyncTwoTrees(TreeNode node1, TreeNode node2, Color clr)
        {
            Logger.Debug("SyncTwoTrees() +");

            if (node1.Nodes.Count == 0 && node2.Nodes.Count == 0)
            {
                return;
            }

            foreach (TreeNode node in node2.Nodes)
            {
                TreeNode[] treeNodes = node1.Nodes.Cast<TreeNode>()
                                       .Where(r => r.Text == node.Text)
                                       .ToArray();

                if (treeNodes.Count() == 0)
                {
                    TreeNode tmpNode = new TreeNode
                    {
                        Text = node.Text,
                        ForeColor = clr,
                        Checked = false,
                        NodeFont = new Font("Consolas", 11, FontStyle.Regular | FontStyle.Strikeout)
                    };

                    node1.Nodes.Insert(node.Index + 1, tmpNode);

                    node.Checked = true;

                    SyncTwoTrees(tmpNode, node, clr);
                }
                else
                {
                    SyncTwoTrees(treeNodes[0], node, clr);
                }
            }

            Logger.Debug("SyncTwoTrees() -");
        }

        private void DrawColorToTree(TreeView tv, IEnumerable<FileInfo> queryLst)
        {
            Logger.Debug("DrawColorToTree() +");

            foreach (var v in queryLst)
            {
                string strFName = v.FullName;
                List<string> strFolderLst = strFName.Split('\\').ToList();
                List<string> strFolderLst2 = strFName.Split('\\').ToList();

                foreach (var s in strFolderLst)
                {
                    strFolderLst2.RemoveAt(0);

                    if (s.Contains(m_strProName))
                    {
                        break;
                    }
                }

                TreeNode tNode = tv.Nodes[0];

                while (strFolderLst2.Count() != 0)
                {
                    TreeNode[] treeNodes = tNode.Nodes
                                    .Cast<TreeNode>()
                                    .Where(r => r.Text == strFolderLst2[0])
                                    .ToArray();

                    tNode = treeNodes[0];

                    strFolderLst2.RemoveAt(0);
                }

                BeginInvoke(new Action(() =>
                {
                    tNode.ForeColor = Color.FromArgb(0xff, 0x51, 0x51);
                }));
            }

            Logger.Debug("DrawColorToTree() -");
        }

        private TreeNode CreateOldTree(DirectoryInfo dirInfo)
        {
            TreeNode dirNode = new TreeNode(dirInfo.Name)
            {
                ForeColor = Color.FromArgb(0x27, 0x27, 0x27),
                Checked = false
            };

            if (dirInfo.FullName.Contains("LocalData"))
            {
                dirNode.Checked = true;
            }

            foreach (var directory in dirInfo.GetDirectories())
            {
                dirNode.Nodes.Add(CreateOldTree(directory));
            }

            foreach (var fileInfo in dirInfo.GetFiles())
            {
                TreeNode fileNode = new TreeNode(fileInfo.Name)
                {
                    ForeColor = Color.FromArgb(0x27, 0x27, 0x27),
                    Checked = false
                };

                if (fileInfo.Directory.FullName.Contains("LocalData"))
                {
                    if (fileInfo.Name != "Alarm.xls")
                    {
                        fileNode.Checked = true;
                    }
                }

                if (dirInfo.Parent.Name == "Module" && fileInfo.Name.Contains("xml"))
                {
                    fileNode.Checked = true;
                }

                dirNode.Nodes.Add(fileNode);
            }

            return dirNode;
        }

        private TreeNode CreateNewTree(DirectoryInfo dirInfo)
        {
            TreeNode dirNode = new TreeNode(dirInfo.Name)
            {
                ForeColor = Color.FromArgb(0x27, 0x27, 0x27),
                Checked = true
            };

            if (dirInfo.Name == "LocalData" || dirInfo.Name == "Module" || dirInfo.Name.Contains(m_strProName))
            {
                dirNode.Checked = false;
            }

            DirectoryInfo di = dirInfo;

            if (dirInfo.FullName.Contains("LocalData") || dirInfo.FullName.Contains("Module"))
            {
                dirNode.Checked = false;
            }

            foreach (var directory in dirInfo.GetDirectories())
            {
                dirNode.Nodes.Add(CreateNewTree(directory));
            }

            foreach (var fileInfo in dirInfo.GetFiles())
            {
                TreeNode fileNode = new TreeNode(fileInfo.Name)
                {
                    ForeColor = Color.FromArgb(0x27, 0x27, 0x27)
                };

                if (dirNode.Text.Contains(m_strProName) ||
                    (fileInfo.Name == "Alarm.xls" && dirInfo.Name == "LocalData") ||
                    dirInfo.Parent.Name == "Module" && !fileInfo.Name.Contains("xml"))
                {
                    fileNode.Checked = true;
                }
                else
                {
                    fileNode.Checked = dirNode.Checked;
                }

                dirNode.Nodes.Add(fileNode);
            }

            return dirNode;
        }

        #endregion

        #region Relative to selecting folders

        private string CheckOutFolder(string strPath)
        {
            string strExePath = strPath + "\\" + m_strProName + ".exe";
            string strDirName = new DirectoryInfo(strPath).Name;

            if (!File.Exists(strExePath) || !strDirName.Contains(m_strProName))
            {
                strExePath = "";
            }

            return strExePath;
        }

        #endregion

        #region Relative to updating

        private bool CheckFilesByXml(string strDirPath, string strXmlPath, List<string> pathLst)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(strXmlPath);
            XmlNode node = doc.DocumentElement;

            List<XmlNode> xmlNodeLst = new List<XmlNode>();

            SearchAllChildNode(node, xmlNodeLst);

            for (int i = 0; i < xmlNodeLst.Count; i++)
            {
                XmlNode tmpNode = xmlNodeLst[i];

                string strPath = tmpNode.Attributes[0].Value.ToString();

                while (true)
                {
                    if (tmpNode.ParentNode.Attributes[0].Value.Contains(m_strProName)) break;
                    else
                    {
                        strPath = tmpNode.ParentNode.Attributes[0].Value + "\\" + strPath;
                        tmpNode = tmpNode.ParentNode;
                    }
                }

                pathLst.Add(strPath);
            }

            foreach (string str in pathLst)
            {
                string strFilePath = strDirPath + "\\" + str;
                if (!File.Exists(strFilePath))
                {
                    if (!(DialogResult.Yes == MessageBox.Show(strFilePath + " is not found!! Ignore?", "Warning", MessageBoxButtons.YesNo)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void CopyFilesByXml(string strDirPath, List<string> pathLst)
        {
            foreach(string str in pathLst)
            {
                int nIdx = str.LastIndexOf("\\");

                string strPath = "";
                if (nIdx >= 0)
                {
                    strPath = str.Substring(0, nIdx);
                }

                CopyFile(strDirPath + "\\" + str, txtDes.Text + "\\" + strPath);
            }
        }

        private void CopyFile(string sourceFilePath, string destinationFilePath, string destinationFileName = null)
        {
            if (!File.Exists(sourceFilePath)) return;

            Logger.Debug(string.Format("CopyFile() +, Source path = {0}, Destination path = {1}", 
                sourceFilePath, destinationFilePath));

            if (string.IsNullOrWhiteSpace(sourceFilePath))
                throw new ArgumentException("sourceFilePath cannot be null or whitespace.");

            if (string.IsNullOrWhiteSpace(destinationFilePath))
                throw new ArgumentException("destinationFilePath cannot be null or whitespace.");

            var targetDirectoryInfo = new DirectoryInfo(destinationFilePath);

            //this creates all the sub directories too
            if (!targetDirectoryInfo.Exists)
                targetDirectoryInfo.Create();

            var fileName = string.IsNullOrWhiteSpace(destinationFileName)
                ? Path.GetFileName(sourceFilePath)
                : destinationFileName;

            File.Copy(sourceFilePath, Path.Combine(destinationFilePath, fileName));

            Logger.Debug("CopyFile() -");
        }

        private void SearchAllChildNode(XmlNode node, List<XmlNode> lst)
        {
            foreach (XmlNode subNode in node.ChildNodes)
            {
                if (subNode.Name == "File")
                {
                    if (Convert.ToBoolean(subNode.Attributes[1].Value))
                    {
                        lst.Add(subNode);
                    }
                }
                else
                {
                    SearchAllChildNode(subNode, lst);
                }
            }
        }

        #endregion

        #region relative to creating xml

        public void SerializeTreeView(TreeView treeView, string fileName)
        {
            if (txtSrc.Text.Length == 0 || txtDes.Text.Length == 0)
            {
                Logger.Error("Folders path not found.");
                MessageBox.Show("請選擇新舊版本資料夾路徑!!");
                return;
            }

            XmlTextWriter textWriter = new XmlTextWriter(fileName, Encoding.ASCII)
            {
                Formatting = Formatting.Indented
            };

            // writing the xml declaration tag
            textWriter.WriteStartDocument();

            // save the nodes, recursive method
            SaveNodes(treeView.Nodes, textWriter);

            textWriter.Close();
        }

        private void SaveNodes(TreeNodeCollection nodesCollection, XmlTextWriter textWriter)
        {
            for (int i = 0; i < nodesCollection.Count; i++)
            {
                TreeNode node = nodesCollection[i];

                if (node.Nodes.Count != 0)
                {
                    textWriter.WriteStartElement("Folder");
                }
                else
                {
                    textWriter.WriteStartElement("File");

                }

                //textWriter.WriteStartElement(node.Text);
                textWriter.WriteAttributeString("Name", node.Text);
                textWriter.WriteAttributeString("IsChecked", node.Checked.ToString());

                // add other node properties to serialize here  
                if (node.Nodes.Count > 0)
                {
                    SaveNodes(node.Nodes, textWriter);
                }

                textWriter.WriteEndElement();
            }
        }

        #endregion

        #region Callback function

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            int nButtonSize = 15;
            int nButtonSize2 = 12;
            int nTextboxSize = 13;
            int nLabelSize = 12;

            if (Size.Width > 1500)
            {
                nButtonSize = 20;
                nButtonSize2 = 16;
                nTextboxSize = 17;
                nLabelSize = 15;
            }

            btnUpdate.Font = new Font(btnUpdate.Font.FontFamily, nButtonSize);
            btnGenerate.Font = new Font(btnUpdate.Font.FontFamily, nButtonSize);
            btnCompare.Font = new Font(btnUpdate.Font.FontFamily, nButtonSize);
            btnBrowseDes.Font = new Font(btnBrowseDes.Font.FontFamily, nButtonSize2);
            btnBrowseSrc.Font = new Font(btnBrowseSrc.Font.FontFamily, nButtonSize2);

            txtDes.Font = new Font(txtDes.Font.FontFamily, nTextboxSize);
            txtSrc.Font = new Font(txtSrc.Font.FontFamily, nTextboxSize);

            label1.Font = new Font(label1.Font.FontFamily, nLabelSize);
            label2.Font = new Font(label2.Font.FontFamily, nLabelSize);
            lblDesVer.Font = new Font(lblDesVer.Font.FontFamily, nLabelSize);
            lblSrcVer.Font = new Font(lblSrcVer.Font.FontFamily, nLabelSize);
            lblDesLastTime.Font = new Font(label2.Font.FontFamily, nLabelSize);
            lblSrcLastTime.Font = new Font(label2.Font.FontFamily, nLabelSize);
        }

        private void OnAfterChecked(object sender, TreeViewEventArgs e)
        {
            if (e.Node.ForeColor == Color.FromArgb(0x00, 0x80, 0xff) && e.Node.Checked)
            {
                e.Node.Checked = false;
            }
            else
            {
                Console.WriteLine("OnAfterChecked");
                CheckAllChildNode(e.Node);
            }
        }

        private void CheckAllChildNode(TreeNode node)
        {
            foreach (TreeNode subNode in node.Nodes)
            {
                subNode.Checked = node.Checked;
                CheckAllChildNode(subNode);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Setting.xml");

                XmlNode projectNameNode = doc.SelectSingleNode("/Setting/ProjectName");
                m_strProName = projectNameNode.InnerText;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
                MessageBox.Show("Fail to open Setting.xml!!");
                Close();
            }
        }

        #endregion
    }
}
