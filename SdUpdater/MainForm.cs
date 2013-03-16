using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SdUpdater
{
    public partial class MainForm : Form
    {
        private string ver = "";
        private bool _reallyClose = false;
        static bool formOpen = false;
        static AutoItX3Lib.AutoItX3Class au3;			//our au3 class that gives us au3 functionality
        static string srcUrl;
        static string saveFile;
        public MainForm()
        {
            InitializeComponent();
            ProcessorArchitecture Arc = Utils.GetProcessorArchitecture();
            //MessageBox.Show(Arc.ToString());
            if (Arc.ToString().Equals("Amd64"))
            {
                ver = "-x64";
            }
            //最小化
            this.Hide();
            trayMenuItem1.Checked = false;
            trayMenuItem2.Checked = true;
            formOpen = false;
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
        }


        private void ManBtn_Click(object sender, EventArgs e)
        {
            downloadFile("");
            install("");
        }
        private void downloadFile(string type) {
            ManBtn.Enabled = false;
            InstallBtn.Enabled = false;
            //检查与本地文件是否一致
            UpdateDes.Text = "正在检查更新,请稍后...";
            string sPath = Environment.CurrentDirectory + @"\360upd\";
            if (!Directory.Exists(sPath)) Directory.CreateDirectory(sPath);
            saveFile = sPath + @"360sd-upd" + type + ver + ".exe";
            string md5hash = "";
            if (File.Exists(saveFile))
            {
                md5hash = Utils.MD5File(saveFile);
            }
            UpdateDes.Text = md5hash + "正在检查更新,请稍后..." ;
            string md5Remote = Utils.GetFileContents("http://192.168.1.186/360SD/?act=md5&ver="+ver+"&type="+type);
            if (md5hash.Equals(md5Remote))
            {
                UpdateDes.Text = "您已经安装了最新的病毒库！";
                ManBtn.Enabled = true;
                InstallBtn.Enabled = true;
            }
            else
            {
                DlProgressBar.Visible = true;
                DlProgressBar.Value = 0;
                UpdateDes.Text = "发现了新病毒库，准备下载最新病毒库...";

                srcUrl = "http://192.168.1.186/360SD/360sd-upd" + type + ver + ".exe";
                
                DownloadWorker.RunWorkerAsync();
            }
 
        }
        private void downloadSd() {
            string version = "se";
            string type = "full";
            if (ver.Equals("-x64"))
            {
                version = ver.Substring(1, 3);
            }
            ManBtn.Enabled = false;
            InstallBtn.Enabled = false;
            //检查与本地文件是否一致
            UpdateDes.Text = "正在360杀毒软件,请稍后...";
            string sPath = Environment.CurrentDirectory + @"\360upd\";
            if (!Directory.Exists(sPath)) Directory.CreateDirectory(sPath);
            saveFile = sPath + @"360sd_" + version + ".exe";
            string md5hash = "";
            if (File.Exists(saveFile))
            {
                md5hash = Utils.MD5File(saveFile);
            }
            UpdateDes.Text = md5hash + "正在检查更新,请稍后...";
            string md5Remote = Utils.GetFileContents("http://192.168.1.186/360SD/?act=md5&ver=" + version + "&type=" + type);
            if (md5hash.Equals(md5Remote))
            {
                UpdateDes.Text = "您已经安装了最新的病毒库！";
                ManBtn.Enabled = true;
                InstallBtn.Enabled = true;
            }
            else
            {
                DlProgressBar.Visible = true;
                DlProgressBar.Value = 0;
                UpdateDes.Text = "发现了新版本360杀毒软件，准备下载...";

                srcUrl = "http://192.168.1.186/360SD/360sd_" + version + ".exe";

                DownloadWorker.RunWorkerAsync();
            }        
        }
        private void install(string type)
        {
            UpdateDes.Text = "正在准备安装最新的病毒库...";
            au3 = new AutoItX3Lib.AutoItX3Class();								//initialize our au3 class library
            //au3.AutoItSetOption("WinDetectHiddenText", 1);
            au3.AutoItSetOption("WinTitleMatchMode", 2);						//advanced window matching
            string sPath = Environment.CurrentDirectory + @"\360upd\";

            sPath = sPath + @"360sd-upd" + type + ver + ".exe";
            //MessageBox.Show(sPath);
            au3.Run(sPath, "", au3.SW_MINIMIZE);
            au3.WinWaitActive("360杀毒");
            string title = au3.WinGetTitle("360杀毒");
            string text = au3.ControlGetText("360杀毒", "", "[CLASS:Static; INSTANCE:1]");
            if (text.Equals("在您的机器中发现未安装360杀毒, 请先安装360杀毒！"))
            {
                UpdateDes.Text = text;
                au3.Send("{ENTER}");
                downloadSd();
                installSd();
                install("");
                return;
                //downloadFile("-savapi-full");
                //install("-savapi-full");
            }
             text  = au3.ControlGetText("360杀毒", "", "[CLASS:Static]");

            if (text.Equals("您安装的是迷你版360杀毒, 请下载病毒库完整安装包！"))
            {
                UpdateDes.Text = "您安装的是迷你版360杀毒, 系统需要下载完整安装包！";
                au3.Send("{ENTER}");

                downloadFile("-savapi-full");
                install("-savapi-full");
            }
            
            if (title.Equals("360杀毒提示"))
            {

                text = au3.ControlGetText("360杀毒提示", "", "[CLASS:Static; INSTANCE:2]");
                //MessageBox.Show(text);
                if (text.Equals("即将关闭正在运行的360杀毒，您确认要立即更新吗？"))
                au3.Send("!y");
                au3.WinWaitActive("360杀毒", "已成功完成病毒库更新");
                au3.WinActivate("360杀毒", "已成功完成病毒库更新");
                au3.Send("!l");
            }
        }

        private void installSd() {
            string version = "se";
            if (ver.Equals("-x64"))
            {
                version = ver.Substring(1, 3);
            }
            UpdateDes.Text = "正在准备安装最新360杀毒软件...";
            au3 = new AutoItX3Lib.AutoItX3Class();								//initialize our au3 class library
            //au3.AutoItSetOption("WinDetectHiddenText", 1);
            au3.AutoItSetOption("WinTitleMatchMode", 2);						//advanced window matching
            string sPath = Environment.CurrentDirectory + @"\360upd\";
            if (!Directory.Exists(sPath)) Directory.CreateDirectory(sPath);
            sPath = sPath + @"360sd_" + version + ".exe";
            //MessageBox.Show(sPath);
            au3.Run(sPath, "", au3.SW_MINIMIZE);
            //string title = au3.WinGetTitle("360杀毒 安装");
            //MessageBox.Show(title);
            au3.WinWaitActive("360杀毒 安装");
            au3.Send("{ENTER}");

        }
        private void DownloadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //return;
            // the URL to download the file from
            string sUrlToReadFileFrom = srcUrl;
            // the path to write the file to
            
            string sFilePathToWriteFileTo = saveFile;

            // first, we need to get the exact size (in bytes) of the file we are downloading
            Uri url = new Uri(sUrlToReadFileFrom);
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
            response.Close();
            // gets the size of the file in bytes
            Int64 iSize = response.ContentLength;

            // keeps track of the total bytes downloaded so we can update the progress bar
            Int64 iRunningByteTotal = 0;

            // use the webclient object to download the file
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                // open the file at the remote URL for reading
                using (System.IO.Stream streamRemote = client.OpenRead(new Uri(sUrlToReadFileFrom)))
                {
                    // using the FileStream object, we can write the downloaded bytes to the file system
                    using (Stream streamLocal = new FileStream(sFilePathToWriteFileTo, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        // loop the stream and get the file into the byte buffer
                        int iByteSize = 0;
                        byte[] byteBuffer = new byte[iSize];
                        while ((iByteSize = streamRemote.Read(byteBuffer, 0, byteBuffer.Length)) > 0)
                        {
                            // write the bytes to the file system at the file path specified
                            streamLocal.Write(byteBuffer, 0, iByteSize);
                            iRunningByteTotal += iByteSize;

                            // calculate the progress out of a base "100"
                            double dIndex = (double)(iRunningByteTotal);
                            double dTotal = (double)byteBuffer.Length;
                            double dProgressPercentage = (dIndex / dTotal);
                            int iProgressPercentage = (int)(dProgressPercentage * 100);
                           
                            // update the progress bar
                            DownloadWorker.ReportProgress(iProgressPercentage);
                        }

                        // clean up the file stream
                        streamLocal.Close();
                    }

                    // close the connection to the remote server
                    streamRemote.Close();
                }
            }
        }

        private void DownloadWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            DlProgressBar.Value = e.ProgressPercentage;
            UpdateDes.Text = "已经完成 " + e.ProgressPercentage.ToString() + "%,请耐心等待一会...";
        }

        private void DownloadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateDes.Text = "下载完成！";
            DlProgressBar.Visible = false;
            ManBtn.Enabled = true;
            InstallBtn.Enabled = true;
        }
        private void InstallBtn_Click(object sender, EventArgs e)
        {
            install("");
        }
        private void trayMenuItem1_Click(object sender, EventArgs e)
        {
            this.Show();
            trayMenuItem1.Checked = true;
            trayMenuItem2.Checked = false;
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            formOpen = true;
        }

        private void trayMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            trayMenuItem1.Checked = false;
            trayMenuItem2.Checked = true;
            formOpen = false;
        }

        private void trayMenuItem3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确认要退出吗，退出后不会即时的更新病毒库?", "退出360病毒库自动更新器", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _reallyClose = true;
                this.Close();
            } 
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (!_reallyClose)
            {
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
        }

        private void autoUpdateTimer_Tick(object sender, EventArgs e)
        {
            ManBtn.Enabled = false;
            InstallBtn.Enabled = false;
            string sPath = Environment.CurrentDirectory + @"\360upd\";
            if (!Directory.Exists(sPath)) Directory.CreateDirectory(sPath);
            saveFile = sPath + @"360sd-upd" + ver + ".exe";
            string md5hash = "";
            if (File.Exists(saveFile))
            {
                md5hash = Utils.MD5File(saveFile);
            }
           
            string md5Remote = Utils.GetFileContents("http://192.168.1.186/360SD/?act=md5&ver=" + ver + "&type=");
            if (md5hash.Equals(md5Remote))
            {
                UpdateDes.Text = "您已经安装了最新的病毒库！";
                ManBtn.Enabled = true;
                InstallBtn.Enabled = true;
            }
            else {
                downloadFile("");
                install("");
            }
        }



    }
}
