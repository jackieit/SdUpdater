namespace SdUpdater
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SdTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.trayMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.DlProgressBar = new System.Windows.Forms.ProgressBar();
            this.UpdateDes = new System.Windows.Forms.Label();
            this.ManBtn = new System.Windows.Forms.Button();
            this.DownloadWorker = new System.ComponentModel.BackgroundWorker();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.InstallBtn = new System.Windows.Forms.Button();
            this.autoUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.contextMenuTray.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SdTray
            // 
            this.SdTray.ContextMenuStrip = this.contextMenuTray;
            this.SdTray.Icon = ((System.Drawing.Icon)(resources.GetObject("SdTray.Icon")));
            this.SdTray.Text = "360病毒自动更新器";
            this.SdTray.Visible = true;
            // 
            // contextMenuTray
            // 
            this.contextMenuTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenuItem1,
            this.trayMenuItem2,
            this.trayMenuItem3});
            this.contextMenuTray.Name = "contextMenuTray";
            this.contextMenuTray.Size = new System.Drawing.Size(101, 70);
            // 
            // trayMenuItem1
            // 
            this.trayMenuItem1.Name = "trayMenuItem1";
            this.trayMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.trayMenuItem1.Text = "显示";
            this.trayMenuItem1.Click += new System.EventHandler(this.trayMenuItem1_Click);
            // 
            // trayMenuItem2
            // 
            this.trayMenuItem2.Name = "trayMenuItem2";
            this.trayMenuItem2.Size = new System.Drawing.Size(100, 22);
            this.trayMenuItem2.Text = "隐藏";
            this.trayMenuItem2.Click += new System.EventHandler(this.trayMenuItem2_Click);
            // 
            // trayMenuItem3
            // 
            this.trayMenuItem3.Name = "trayMenuItem3";
            this.trayMenuItem3.Size = new System.Drawing.Size(100, 22);
            this.trayMenuItem3.Text = "退出";
            this.trayMenuItem3.Click += new System.EventHandler(this.trayMenuItem3_Click);
            // 
            // DlProgressBar
            // 
            this.DlProgressBar.Location = new System.Drawing.Point(46, 47);
            this.DlProgressBar.Name = "DlProgressBar";
            this.DlProgressBar.Size = new System.Drawing.Size(480, 13);
            this.DlProgressBar.TabIndex = 0;
            this.DlProgressBar.Visible = false;
            // 
            // UpdateDes
            // 
            this.UpdateDes.AutoSize = true;
            this.UpdateDes.ForeColor = System.Drawing.Color.Red;
            this.UpdateDes.Location = new System.Drawing.Point(156, 17);
            this.UpdateDes.Name = "UpdateDes";
            this.UpdateDes.Size = new System.Drawing.Size(0, 12);
            this.UpdateDes.TabIndex = 1;
            this.UpdateDes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ManBtn
            // 
            this.ManBtn.Location = new System.Drawing.Point(191, 77);
            this.ManBtn.Name = "ManBtn";
            this.ManBtn.Size = new System.Drawing.Size(75, 23);
            this.ManBtn.TabIndex = 2;
            this.ManBtn.Text = "手动更新";
            this.ManBtn.UseVisualStyleBackColor = true;
            this.ManBtn.Click += new System.EventHandler(this.ManBtn_Click);
            // 
            // DownloadWorker
            // 
            this.DownloadWorker.WorkerReportsProgress = true;
            this.DownloadWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DownloadWorker_DoWork);
            this.DownloadWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.DownloadWorker_ProgressChanged);
            this.DownloadWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DownloadWorker_RunWorkerCompleted);
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.InstallBtn);
            this.TopPanel.Controls.Add(this.ManBtn);
            this.TopPanel.Controls.Add(this.DlProgressBar);
            this.TopPanel.Controls.Add(this.UpdateDes);
            this.TopPanel.Location = new System.Drawing.Point(13, 2);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(580, 100);
            this.TopPanel.TabIndex = 3;
            // 
            // InstallBtn
            // 
            this.InstallBtn.Location = new System.Drawing.Point(298, 77);
            this.InstallBtn.Name = "InstallBtn";
            this.InstallBtn.Size = new System.Drawing.Size(75, 23);
            this.InstallBtn.TabIndex = 3;
            this.InstallBtn.Text = "强制安装";
            this.InstallBtn.UseVisualStyleBackColor = true;
            this.InstallBtn.Click += new System.EventHandler(this.InstallBtn_Click);
            // 
            // autoUpdateTimer
            // 
            this.autoUpdateTimer.Enabled = true;
            this.autoUpdateTimer.Interval = 7200000;
            this.autoUpdateTimer.Tick += new System.EventHandler(this.autoUpdateTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 194);
            this.Controls.Add(this.TopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "360病毒库自动更新器";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.contextMenuTray.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon SdTray;
        private System.Windows.Forms.ProgressBar DlProgressBar;
        private System.Windows.Forms.Label UpdateDes;
        private System.Windows.Forms.Button ManBtn;
        private System.Windows.Forms.ContextMenuStrip contextMenuTray;
        private System.Windows.Forms.ToolStripMenuItem trayMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem trayMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem trayMenuItem3;
        private System.ComponentModel.BackgroundWorker DownloadWorker;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Button InstallBtn;
        private System.Windows.Forms.Timer autoUpdateTimer;
    }
}

