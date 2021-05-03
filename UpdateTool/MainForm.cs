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

namespace UpdateTool
{
    public partial class MainForm : Form
    {
        private string m_strDesFolderPath;
        private string m_strSrcFolderPath;

        public MainForm()
        {
            InitializeComponent();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            TextBox txt = btn == btnBrowseDes ? txtDes : txtSrc;
            Label lblVer = btn == btnBrowseDes ? lblDesVer : lblSrcVer;
            Label lblLastTime = btn == btnBrowseDes ? lblDesLastTime : lblSrcLastTime;

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

        private void MainForm_Load(object sender, EventArgs e)
        {
            Logger.Debug("MainForm_Load");
        }

        private string CheckOutFolder(string strPath)
        {
            string strExePath = strPath + "\\ADSW11000.exe";
            string strDirName = new DirectoryInfo(strPath).Name;

            if (!File.Exists(strExePath) || strDirName != "bin")
            {
                strExePath = "";
            }

            return strExePath;
        }

        private void OnUpdateClicked(object sender, EventArgs e)
        {
            Logger.Debug("OnUpdateClicked() +");

            Logger.Info(txtDes.Text);
            Logger.Info(txtSrc.Text);

            DirectoryCopy(txtDes.Text, txtDes.Text + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"), true);
            DeleteAllFiles(txtDes.Text);
            CopyFilesRecursively(txtSrc.Text, txtDes.Text);

            Logger.Debug("OnUpdateClicked() +");
        }

        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }

        private void DeleteAllFiles(string strPath)
        {
            DirectoryInfo di = new DirectoryInfo(strPath);

            foreach (FileInfo file in di.GetFiles())
            {
                File.SetAttributes(file.DirectoryName + "\\" + file.Name, FileAttributes.Normal);
                file.Delete();
            }

            foreach (DirectoryInfo dirInfo in di.GetDirectories())
            {
                if (dirInfo.Name != "Module" && dirInfo.Name != "LocalData")
                {
                    foreach (FileInfo file in dirInfo.GetFiles())
                    {
                        File.SetAttributes(Path.Combine(file.DirectoryName, file.Name), FileAttributes.Normal);
                    }

                    dirInfo.Delete(true);
                }
            }
        }

        private void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            // Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.TopDirectoryOnly))
            {
                string strDirName = new DirectoryInfo(dirPath).Name;

                if (strDirName != "Module" && strDirName != "LocalData")
                {
                    DirectoryInfo dirInfo = Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
                    DirectoryInfo dirInfo2 = new DirectoryInfo(sourcePath + "\\" + strDirName);

                    foreach (FileInfo file in dirInfo2.GetFiles())
                    {
                        string strDestFileName = Path.Combine(targetPath + "\\" + strDirName, file.Name);
                        string strSrcFileName = Path.Combine(sourcePath + "\\" + strDirName, file.Name);
                        File.Copy(strSrcFileName, strDestFileName, true);
                    }
                }
            }

            DirectoryInfo di = new DirectoryInfo(sourcePath);

            foreach (FileInfo file in di.GetFiles())
            {
                string strDestFileName = Path.Combine(targetPath, file.Name);
                string strSrcFileName = Path.Combine(sourcePath, file.Name);
                File.Copy(strSrcFileName, strDestFileName, true);
            }
        }
    }
}
