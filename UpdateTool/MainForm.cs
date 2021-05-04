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

        private string m_strBackUpPath;

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

            if (!File.Exists(strExePath) || !strDirName.Contains("ADSW11000"))
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

            m_strBackUpPath = txtDes.Text + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");

            // Back the old version
            DirectoryCopy(txtDes.Text, m_strBackUpPath, true);

            // Delete the all files and folders except "LocalData" from old version
            DeleteFilesFromOld(txtDes.Text);

            // Copy all files and folders except "LocalData" from new version to old version
            CopyFilesFromNewToOld(new DirectoryInfo(txtSrc.Text), new DirectoryInfo(txtDes.Text));

            // Replace all xml from backup "Module" folder and Alarm.xls from new version
            ReplaceSpecificFiles();

            MessageBox.Show("Update Ok!!");

            Logger.Debug("OnUpdateClicked() +");
        }

        private void DirectoryCopy(string srcDirPath, string backupDirPath, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(srcDirPath);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + srcDirPath);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the backup directory doesn't exist, create it.
            Directory.CreateDirectory(backupDirPath);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(backupDirPath, file.Name);
                file.CopyTo(tempPath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(backupDirPath, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }

        private void DeleteFilesFromOld(string strPath)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(strPath);

                foreach (FileInfo file in di.GetFiles())
                {
                    File.SetAttributes(file.DirectoryName + "\\" + file.Name, FileAttributes.Normal);
                    file.Delete();
                }

                foreach (DirectoryInfo dirInfo in di.GetDirectories())
                {
                    if (dirInfo.Name != "LocalData")
                    //if (dirInfo.Name != "Module" && dirInfo.Name != "LocalData")
                    {
                        foreach (FileInfo file in dirInfo.GetFiles())
                        {
                            File.SetAttributes(Path.Combine(file.DirectoryName, file.Name), FileAttributes.Normal);
                        }

                        dirInfo.Delete(true);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
        }

        public static void CopyFilesFromNewToOld(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                if (diSourceSubDir.Name != "LocalData")
                {
                    DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                    CopyFilesFromNewToOld(diSourceSubDir, nextTargetSubDir);
                }
            }
        }

        private void ReplaceSpecificFiles()
        {
            Logger.Debug("ReplaceSpecificFiles() +");

            #region Copy all xml files from backup folder to destination folder

            string[] originalFiles = Directory.GetFiles(m_strBackUpPath + "\\" + "Module", "*.xml", SearchOption.AllDirectories);
            List<string> originalFilesLst = new List<string>();

            foreach (var file in originalFiles)
            {
                originalFilesLst.Add(Path.GetFileName(file));
                Logger.Debug(file);
            }

            string[] replacedFiles = Directory.GetFiles(txtDes.Text + "\\" + "Module", "*.xml", SearchOption.AllDirectories);
            List<string> replacedFilesLst = new List<string>();

            foreach (var file in replacedFiles)
            {
                replacedFilesLst.Add(Path.GetFileName(file));
                Logger.Debug(file);
            }

            var updateLst = originalFilesLst.Intersect(replacedFilesLst);

            foreach (var strFile in updateLst)
            {
                string strSrcFile = Array.Find(originalFiles, x => x.EndsWith(strFile, StringComparison.Ordinal));
                string strDesFile = Array.Find(replacedFiles, x => x.EndsWith(strFile, StringComparison.Ordinal));

                new FileInfo(strSrcFile).CopyTo(strDesFile, true);
            }

            #endregion

            #region Copy Local\Alarm.xls from new release folder to destination folder

            FileInfo fInfo = new FileInfo(txtSrc.Text + "\\LocalData\\Alarm.xls");
            fInfo.CopyTo(txtDes.Text + "\\LocalData\\Alarm.xls", true);

            #endregion

            Logger.Debug("ReplaceSpecificFiles() -");
        }
    }
}
