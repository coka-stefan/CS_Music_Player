namespace Media_PLayer
{
    partial class PlaylistForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.songsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.allSongsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedSongsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnShowAlbums = new System.Windows.Forms.Button();
            this.btnShowArtists = new System.Windows.Forms.Button();
            this.btnShowSongs = new System.Windows.Forms.Button();
            this.lbSongsView = new System.Windows.Forms.ListBox();
            this.tbSearchBar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tvArtistsView = new System.Windows.Forms.TreeView();
            this.tvAlbumsView = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.addToolStripMenuItem,
            this.playToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1451, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.fileToolStripMenuItem.Text = "Playlist";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.songsToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.removeAllToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.addToolStripMenuItem.Text = "Songs";
            // 
            // songsToolStripMenuItem
            // 
            this.songsToolStripMenuItem.Name = "songsToolStripMenuItem";
            this.songsToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.songsToolStripMenuItem.Text = "Add";
            this.songsToolStripMenuItem.Click += new System.EventHandler(this.songsToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // removeAllToolStripMenuItem
            // 
            this.removeAllToolStripMenuItem.Name = "removeAllToolStripMenuItem";
            this.removeAllToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.removeAllToolStripMenuItem.Text = "Delete All";
            this.removeAllToolStripMenuItem.Click += new System.EventHandler(this.removeAllToolStripMenuItem_Click);
            // 
            // playToolStripMenuItem1
            // 
            this.playToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allSongsToolStripMenuItem,
            this.selectedSongsToolStripMenuItem});
            this.playToolStripMenuItem1.Name = "playToolStripMenuItem1";
            this.playToolStripMenuItem1.Size = new System.Drawing.Size(48, 24);
            this.playToolStripMenuItem1.Text = "Play";
            // 
            // allSongsToolStripMenuItem
            // 
            this.allSongsToolStripMenuItem.Name = "allSongsToolStripMenuItem";
            this.allSongsToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.allSongsToolStripMenuItem.Text = "All Songs";
            this.allSongsToolStripMenuItem.Click += new System.EventHandler(this.allSongsToolStripMenuItem_Click);
            // 
            // selectedSongsToolStripMenuItem
            // 
            this.selectedSongsToolStripMenuItem.Name = "selectedSongsToolStripMenuItem";
            this.selectedSongsToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.selectedSongsToolStripMenuItem.Text = "Selected Songs";
            this.selectedSongsToolStripMenuItem.Click += new System.EventHandler(this.selectedSongsToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnShowAlbums);
            this.groupBox1.Controls.Add(this.btnShowArtists);
            this.groupBox1.Controls.Add(this.btnShowSongs);
            this.groupBox1.Location = new System.Drawing.Point(21, 60);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Size = new System.Drawing.Size(356, 842);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "View";
            // 
            // btnShowAlbums
            // 
            this.btnShowAlbums.Location = new System.Drawing.Point(39, 235);
            this.btnShowAlbums.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnShowAlbums.Name = "btnShowAlbums";
            this.btnShowAlbums.Size = new System.Drawing.Size(217, 53);
            this.btnShowAlbums.TabIndex = 4;
            this.btnShowAlbums.Text = "Albums";
            this.btnShowAlbums.UseVisualStyleBackColor = true;
            this.btnShowAlbums.Click += new System.EventHandler(this.btnShowAlbums_Click);
            // 
            // btnShowArtists
            // 
            this.btnShowArtists.Location = new System.Drawing.Point(39, 139);
            this.btnShowArtists.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnShowArtists.Name = "btnShowArtists";
            this.btnShowArtists.Size = new System.Drawing.Size(217, 53);
            this.btnShowArtists.TabIndex = 3;
            this.btnShowArtists.Text = "Artists";
            this.btnShowArtists.UseVisualStyleBackColor = true;
            this.btnShowArtists.Click += new System.EventHandler(this.btnShowArtists_Click);
            // 
            // btnShowSongs
            // 
            this.btnShowSongs.Location = new System.Drawing.Point(39, 46);
            this.btnShowSongs.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnShowSongs.Name = "btnShowSongs";
            this.btnShowSongs.Size = new System.Drawing.Size(217, 53);
            this.btnShowSongs.TabIndex = 2;
            this.btnShowSongs.Text = "Songs";
            this.btnShowSongs.UseVisualStyleBackColor = true;
            this.btnShowSongs.Click += new System.EventHandler(this.btnShowSongs_Click);
            // 
            // lbSongsView
            // 
            this.lbSongsView.FormattingEnabled = true;
            this.lbSongsView.ItemHeight = 16;
            this.lbSongsView.Location = new System.Drawing.Point(388, 100);
            this.lbSongsView.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lbSongsView.Name = "lbSongsView";
            this.lbSongsView.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbSongsView.Size = new System.Drawing.Size(1051, 644);
            this.lbSongsView.TabIndex = 0;
            // 
            // tbSearchBar
            // 
            this.tbSearchBar.Location = new System.Drawing.Point(1209, 53);
            this.tbSearchBar.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tbSearchBar.Name = "tbSearchBar";
            this.tbSearchBar.Size = new System.Drawing.Size(230, 22);
            this.tbSearchBar.TabIndex = 2;
            this.tbSearchBar.TextChanged += new System.EventHandler(this.tbSearchBar_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1147, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search";
            // 
            // tvArtistsView
            // 
            this.tvArtistsView.Location = new System.Drawing.Point(388, 100);
            this.tvArtistsView.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tvArtistsView.Name = "tvArtistsView";
            this.tvArtistsView.Size = new System.Drawing.Size(1051, 644);
            this.tvArtistsView.TabIndex = 4;
            this.tvArtistsView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvArtistsView_NodeMouseDoubleClick);
            this.tvArtistsView.DoubleClick += new System.EventHandler(this.tvArtistsView_DoubleClick);
            // 
            // tvAlbumsView
            // 
            this.tvAlbumsView.Location = new System.Drawing.Point(388, 100);
            this.tvAlbumsView.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tvAlbumsView.Name = "tvAlbumsView";
            this.tvAlbumsView.Size = new System.Drawing.Size(1051, 644);
            this.tvAlbumsView.TabIndex = 5;
            // 
            // PlaylistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 752);
            this.Controls.Add(this.tvAlbumsView);
            this.Controls.Add(this.tvArtistsView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSearchBar);
            this.Controls.Add(this.lbSongsView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "PlaylistForm";
            this.Text = "Playlist";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbSongsView;
        private System.Windows.Forms.ToolStripMenuItem songsToolStripMenuItem;
        private System.Windows.Forms.Button btnShowAlbums;
        private System.Windows.Forms.Button btnShowArtists;
        private System.Windows.Forms.Button btnShowSongs;
        private System.Windows.Forms.TextBox tbSearchBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView tvArtistsView;
        private System.Windows.Forms.TreeView tvAlbumsView;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem allSongsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectedSongsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAllToolStripMenuItem;
    }
}