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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Song0");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Song1");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Album0", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Artists0", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.songsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnShowAlbums = new System.Windows.Forms.Button();
            this.btnShowArtists = new System.Windows.Forms.Button();
            this.btnShowSongs = new System.Windows.Forms.Button();
            this.lbSongsView = new System.Windows.Forms.ListBox();
            this.tbSearchBar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tvArtistsView = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.addToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1019, 24);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.fileToolStripMenuItem.Text = "Playlist";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.songsToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // songsToolStripMenuItem
            // 
            this.songsToolStripMenuItem.Name = "songsToolStripMenuItem";
            this.songsToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.songsToolStripMenuItem.Text = "Songs";
            this.songsToolStripMenuItem.Click += new System.EventHandler(this.songsToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnShowAlbums);
            this.groupBox1.Controls.Add(this.btnShowArtists);
            this.groupBox1.Controls.Add(this.btnShowSongs);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 556);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "View";
            // 
            // btnShowAlbums
            // 
            this.btnShowAlbums.Location = new System.Drawing.Point(22, 155);
            this.btnShowAlbums.Name = "btnShowAlbums";
            this.btnShowAlbums.Size = new System.Drawing.Size(163, 43);
            this.btnShowAlbums.TabIndex = 4;
            this.btnShowAlbums.Text = "Albums";
            this.btnShowAlbums.UseVisualStyleBackColor = true;
            // 
            // btnShowArtists
            // 
            this.btnShowArtists.Location = new System.Drawing.Point(22, 92);
            this.btnShowArtists.Name = "btnShowArtists";
            this.btnShowArtists.Size = new System.Drawing.Size(163, 43);
            this.btnShowArtists.TabIndex = 3;
            this.btnShowArtists.Text = "Artists";
            this.btnShowArtists.UseVisualStyleBackColor = true;
            this.btnShowArtists.Click += new System.EventHandler(this.btnShowArtists_Click);
            // 
            // btnShowSongs
            // 
            this.btnShowSongs.Location = new System.Drawing.Point(22, 30);
            this.btnShowSongs.Name = "btnShowSongs";
            this.btnShowSongs.Size = new System.Drawing.Size(163, 43);
            this.btnShowSongs.TabIndex = 2;
            this.btnShowSongs.Text = "Songs";
            this.btnShowSongs.UseVisualStyleBackColor = true;
            this.btnShowSongs.Click += new System.EventHandler(this.btnShowSongs_Click);
            // 
            // lbSongsView
            // 
            this.lbSongsView.FormattingEnabled = true;
            this.lbSongsView.Location = new System.Drawing.Point(218, 66);
            this.lbSongsView.Name = "lbSongsView";
            this.lbSongsView.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbSongsView.Size = new System.Drawing.Size(789, 524);
            this.lbSongsView.TabIndex = 0;
            // 
            // tbSearchBar
            // 
            this.tbSearchBar.Location = new System.Drawing.Point(907, 40);
            this.tbSearchBar.Name = "tbSearchBar";
            this.tbSearchBar.Size = new System.Drawing.Size(100, 20);
            this.tbSearchBar.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(860, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search";
            // 
            // tvArtistsView
            // 
            this.tvArtistsView.Location = new System.Drawing.Point(218, 66);
            this.tvArtistsView.Name = "tvArtistsView";
            treeNode1.Name = "Node3";
            treeNode1.Text = "Song0";
            treeNode2.Name = "Node4";
            treeNode2.Text = "Song1";
            treeNode3.Name = "Node2";
            treeNode3.Text = "Album0";
            treeNode4.Name = "Node0";
            treeNode4.Text = "Artists0";
            this.tvArtistsView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.tvArtistsView.Size = new System.Drawing.Size(789, 524);
            this.tvArtistsView.TabIndex = 4;
            // 
            // PlaylistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 617);
            this.Controls.Add(this.tvArtistsView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSearchBar);
            this.Controls.Add(this.lbSongsView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
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
    }
}