﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Media_PLayer
{
    public partial class PlaylistForm : Form
    {

        public Playlist Playlist { get; set; }
        
        public PlaylistForm()
        {
            InitializeComponent();
            Playlist = new Playlist();
        }

        private void songsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = @"All files (*.flac, *.mp3, *.wav)|*.flac;*.mp3;*.wav|Mp3 files(*.mp3)|*.mp3|Flac files (*.flac)|*.flac|Wav files (*.wav)|*.wav",
                Title = @"Open Music",
                Multiselect = true
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;
            foreach (var fileName in ofd.FileNames)
                Playlist.AddSong(fileName, lbSongsView);
            //Playlist.ShowSongsOnControl(lbSongsView);
        }
        
    }
}
