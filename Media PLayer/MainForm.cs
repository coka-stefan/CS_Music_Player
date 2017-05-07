using System;
using System.IO;
using System.Windows.Forms;
using Media_PLayer.Structures;

namespace Media_PLayer
{
    public partial class MainForm : Form
    {
        private Media CurrentMedia { get; set; }
        private Player Player { get; set; } 

        public MainForm()
        {
            InitializeComponent();
            Player = new Player();
       }

        private void OpenMusicFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
               OpenMusicFile();
        }

        private void openFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
              
        }

        private void OpenMusicFile()
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = @"Music file (*.mp3)|*.mp3", Title = @"Open Music" };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            lbOpenedFiles.Items.Clear();
            pbAlbumCover.ImageLocation = null;

            var directoryPath = Path.GetDirectoryName(ofd.FileName);
            string albumCover = null;
            foreach (var file in Directory.GetFiles(directoryPath))
            {
                if (file.EndsWith(".jpg") || file.EndsWith(".png") || file.EndsWith(".bmp"))
                    albumCover = file;
            }

            MusicFile newMedia = new MusicFile(ofd.FileName, (uint) lbOpenedFiles.Items.Count + 1);
            newMedia.AlbumCover = albumCover ?? "";

            CurrentMedia = newMedia;
            DisplayAlbumCover(albumCover);          
            Player.PlayMusicFile(CurrentMedia);
            lbOpenedFiles.Items.Add(newMedia);
        }


        private void DisplayAlbumCover(string pathToAlbumCover)
        {
            pbAlbumCover.ImageLocation = pathToAlbumCover;
            pbAlbumCover.ForeColor = ForeColor;
            pbAlbumCover.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (lbOpenedFiles.SelectedIndex != -1)
            {
                Media selectedItem = lbOpenedFiles.SelectedItem as Media;
                Player.PlayMusicFile(selectedItem);
                CurrentMedia = selectedItem;
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            Player.Pause();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Player.Pause();
        }
    }
}