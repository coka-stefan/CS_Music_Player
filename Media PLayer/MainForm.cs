using System;
using System.IO;
using System.Windows.Forms;
using Media_PLayer.Structures;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

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
            lblVolume.Text = scrollBar.Value.ToString();
        }

        private void OpenMusicFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMusicFile();
        }

        private void OpenFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter =
                    @"All files (*.flac, *.mp3, *.wav)|*.flac;*.mp3;*.wav|Mp3 files(*.mp3)|*.mp3|Flac files (*.flac)|*.flac|Wav files (*.wav)|*.wav",
                Title = @"Open Music",
                Multiselect = true
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;
            OpenMusicFiles(ofd.FileNames);
        }

        private void OpenFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() != DialogResult.OK) return;
            var files = Directory.GetFiles(fbd.SelectedPath).ToList();
            OpenMusicFiles(files.Where(IsSong).ToArray());
        }

        private void OpenMusicFiles(string[] files)
        {
            ClearGui();
            var albumCover = "";
            var awaiter = DisplayAlbumCover(Path.GetDirectoryName(files[0])).GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                albumCover = awaiter.GetResult();
                pbAlbumCover.ForeColor = ForeColor;
                pbAlbumCover.SizeMode = PictureBoxSizeMode.StretchImage;
                pbAlbumCover.ImageLocation = albumCover;
            });
            var openedFiles = new List<MusicFile>();
            foreach (var fileName in files)
            {
                MusicFile newMedia = new MusicFile(fileName, (uint) lbOpenedFiles.Items.Count + 1)
                {
                    AlbumCover = albumCover
                };
                lbOpenedFiles.Items.Add(newMedia);
                openedFiles.Add(newMedia);
            }
            Player.PlayMusicFiles(openedFiles, true);
        }

        private void OpenMusicFile()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter =
                    @"All files (*.flac, *.mp3, *.wav)|*.flac;*.mp3;*.wav|Mp3 files(*.mp3)|*.mp3|Flac files (*.flac)|*.flac|Wav files (*.wav)|*.wav",
                Title = @"Open Music"
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;
            ClearGui();
            MusicFile newMedia = new MusicFile(ofd.FileName, (uint) lbOpenedFiles.Items.Count + 1);
            var awaiter = DisplayAlbumCover(Path.GetDirectoryName(ofd.FileName)).GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                var albumCover = awaiter.GetResult();
                pbAlbumCover.SizeMode = PictureBoxSizeMode.StretchImage;
                pbAlbumCover.ImageLocation = albumCover;
                newMedia.AlbumCover = albumCover;
            });
            CurrentMedia = newMedia;
            lbOpenedFiles.Items.Add(newMedia);
            Player.PlayMusicFile(CurrentMedia);
        }

        private static async Task<string> DisplayAlbumCover(string lookingDirectory)
        {
            return await Task.Run(() =>
            {
                return Directory.GetFiles(lookingDirectory)
                    .FirstOrDefault(file => file.EndsWith(".jpg") || file.EndsWith(".png") || file.EndsWith(".bmp"));
            });
        }



        private static bool IsSong(string file)
        {
            return file.EndsWith(".mp3") || file.EndsWith(".flac") || file.EndsWith(".wav");
        }

        public void ClearGui()
        {
            lbOpenedFiles.Items.Clear();
            pbAlbumCover.ImageLocation = null;
            Player.Clear();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (lbOpenedFiles.SelectedIndex != -1)
            {
                Media selectedItem = lbOpenedFiles.SelectedItem as Media;
                Player.PlayMusicFile(selectedItem);
                CurrentMedia = selectedItem;
            }
            else if (lbOpenedFiles.Items.Count > 0)
            {
                Player.PlayMusicFile(lbOpenedFiles.Items[0] as Media);
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            Player.Pause();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Player.Stop();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            Player.Previous();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Player.Next();
        }

        private void scrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            Player.SetVolume(100 - e.NewValue);
            lblVolume.Text = (100 - e.NewValue).ToString();
        }

       
    }
}