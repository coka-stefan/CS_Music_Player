namespace Media_Player
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnPlay = new System.Windows.Forms.Button();
            this.pbAlbumCover = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playlistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playlistToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.playlistToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.lbOpenedFiles = new System.Windows.Forms.ListBox();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVolume = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tbVolume = new System.Windows.Forms.TrackBar();
            this.pbVolume = new System.Windows.Forms.ProgressBar();
            this.tbProgress = new System.Windows.Forms.TrackBar();
            this.lblEnd = new System.Windows.Forms.Label();
            this.btnMute = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbumCover)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(69, 429);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(96, 24);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // pbAlbumCover
            // 
            this.pbAlbumCover.Location = new System.Drawing.Point(24, 40);
            this.pbAlbumCover.Margin = new System.Windows.Forms.Padding(2);
            this.pbAlbumCover.Name = "pbAlbumCover";
            this.pbAlbumCover.Size = new System.Drawing.Size(560, 385);
            this.pbAlbumCover.TabIndex = 4;
            this.pbAlbumCover.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.playlistToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(916, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilesToolStripMenuItem,
            this.openFolderToolStripMenuItem,
            this.playlistToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.fileToolStripMenuItem.Text = "Music";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.OpenMusicFileToolStripMenuItem_Click);
            // 
            // openFilesToolStripMenuItem
            // 
            this.openFilesToolStripMenuItem.Name = "openFilesToolStripMenuItem";
            this.openFilesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openFilesToolStripMenuItem.Text = "Open Files";
            this.openFilesToolStripMenuItem.Click += new System.EventHandler(this.OpenFilesToolStripMenuItem_Click);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.OpenFolderToolStripMenuItem_Click);
            // 
            // playlistToolStripMenuItem
            // 
            this.playlistToolStripMenuItem.Name = "playlistToolStripMenuItem";
            this.playlistToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.playlistToolStripMenuItem.Text = "Open Playlist";
            // 
            // playlistToolStripMenuItem1
            // 
            this.playlistToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playlistToolStripMenuItem2});
            this.playlistToolStripMenuItem1.Name = "playlistToolStripMenuItem1";
            this.playlistToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.playlistToolStripMenuItem1.Text = "View";
            // 
            // playlistToolStripMenuItem2
            // 
            this.playlistToolStripMenuItem2.Name = "playlistToolStripMenuItem2";
            this.playlistToolStripMenuItem2.Size = new System.Drawing.Size(111, 22);
            this.playlistToolStripMenuItem2.Text = "Playlist";
            // 
            // lbOpenedFiles
            // 
            this.lbOpenedFiles.FormattingEnabled = true;
            this.lbOpenedFiles.Location = new System.Drawing.Point(617, 40);
            this.lbOpenedFiles.Name = "lbOpenedFiles";
            this.lbOpenedFiles.Size = new System.Drawing.Size(287, 550);
            this.lbOpenedFiles.TabIndex = 6;
            this.lbOpenedFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbOpenedFiles_MouseDoubleClick);
            // 
            // btnPause
            // 
            this.btnPause.Image = ((System.Drawing.Image)(resources.GetObject("btnPause.Image")));
            this.btnPause.Location = new System.Drawing.Point(256, 429);
            this.btnPause.Margin = new System.Windows.Forms.Padding(2);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(96, 24);
            this.btnPause.TabIndex = 7;
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(436, 429);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(96, 24);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(169, 429);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(63, 24);
            this.btnPrevious.TabIndex = 9;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(368, 429);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(63, 24);
            this.btnNext.TabIndex = 10;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(432, 563);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Volume";
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.Location = new System.Drawing.Point(454, 534);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(0, 13);
            this.lblVolume.TabIndex = 13;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // tbVolume
            // 
            this.tbVolume.LargeChange = 2;
            this.tbVolume.Location = new System.Drawing.Point(480, 554);
            this.tbVolume.Maximum = 100;
            this.tbVolume.Name = "tbVolume";
            this.tbVolume.Size = new System.Drawing.Size(104, 45);
            this.tbVolume.TabIndex = 15;
            this.tbVolume.Value = 50;
            this.tbVolume.Scroll += new System.EventHandler(this.tbVolume_Scroll);
            // 
            // pbVolume
            // 
            this.pbVolume.Location = new System.Drawing.Point(480, 524);
            this.pbVolume.MarqueeAnimationSpeed = 10;
            this.pbVolume.Name = "pbVolume";
            this.pbVolume.Size = new System.Drawing.Size(100, 23);
            this.pbVolume.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbVolume.TabIndex = 16;
            this.pbVolume.Value = 50;
            // 
            // tbProgress
            // 
            this.tbProgress.LargeChange = 1;
            this.tbProgress.Location = new System.Drawing.Point(24, 470);
            this.tbProgress.Maximum = 100;
            this.tbProgress.Name = "tbProgress";
            this.tbProgress.Size = new System.Drawing.Size(556, 45);
            this.tbProgress.TabIndex = 17;
            this.tbProgress.Scroll += new System.EventHandler(this.tbProgress_Scroll);
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(577, 481);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(34, 13);
            this.lblEnd.TabIndex = 19;
            this.lblEnd.Text = "00:00";
            this.lblEnd.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblEnd_MouseClick);
            // 
            // btnMute
            // 
            this.btnMute.Location = new System.Drawing.Point(368, 554);
            this.btnMute.Margin = new System.Windows.Forms.Padding(2);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(48, 27);
            this.btnMute.TabIndex = 20;
            this.btnMute.Text = "Mute";
            this.btnMute.UseVisualStyleBackColor = true;
            this.btnMute.Click += new System.EventHandler(this.btnMute_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 602);
            this.Controls.Add(this.btnMute);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.tbProgress);
            this.Controls.Add(this.pbVolume);
            this.Controls.Add(this.tbVolume);
            this.Controls.Add(this.lblVolume);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.lbOpenedFiles);
            this.Controls.Add(this.pbAlbumCover);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Music Player";
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbumCover)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbProgress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.PictureBox pbAlbumCover;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playlistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playlistToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem playlistToolStripMenuItem2;
        private System.Windows.Forms.ListBox lbOpenedFiles;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TrackBar tbVolume;
        private System.Windows.Forms.ProgressBar pbVolume;
        private System.Windows.Forms.TrackBar tbProgress;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Button btnMute;
    }
}

