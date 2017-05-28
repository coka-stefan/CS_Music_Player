using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Media_PLayer
{
    internal enum ViewMode
    {
        Songs,
        Artists,
        Albums
    }

    public partial class PlaylistForm : Form
    {
        private string _fileName;
        public Playlist Playlist { get; set; }
        private ViewMode ViewMode { get; set; }

        public PlaylistForm()
        {
            InitializeComponent();
            ViewMode = ViewMode.Songs;
            tvArtistsView.Hide();
            tvAlbumsView.Hide();
            Playlist = new Playlist();
        }

        private void songsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter =
                    @"All files (*.flac, *.mp3, *.wav)|*.flac;*.mp3;*.wav|Mp3 files(*.mp3)|*.mp3|Flac files (*.flac)|*.flac|Wav files (*.wav)|*.wav",
                Title = @"Open Music",
                Multiselect = true
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;
            foreach (var fileName in ofd.FileNames)
                Playlist.AddSong(fileName);
            Playlist.ShowArtistsOnTreeView(tvArtistsView);
            Playlist.ShowSongsOnControl(lbSongsView);
            Playlist.ShowAlbumsOnTreeView(tvAlbumsView);
            switch (ViewMode)
            {
                case ViewMode.Songs:
                    tvArtistsView.Hide();
                    tvAlbumsView.Hide();
                    lbSongsView.Show();
                    break;
                case ViewMode.Artists:
                    lbSongsView.Hide();
                    tvAlbumsView.Hide();
                    tvArtistsView.Show();
                    break;
                case ViewMode.Albums:
                    break;
                default:
                    lbSongsView.Hide();
                    tvArtistsView.Hide();
                    tvAlbumsView.Show();
                    break;
            }
        }

        private void btnShowSongs_Click(object sender, EventArgs e)
        {
            if (ViewMode == ViewMode.Songs) return;
            tvArtistsView.Hide();
            tvAlbumsView.Hide();
            lbSongsView.Show();
            ViewMode = ViewMode.Songs;
        }

        private void btnShowArtists_Click(object sender, EventArgs e)
        {
            if (ViewMode == ViewMode.Artists) return;
            lbSongsView.Hide();
            tvAlbumsView.Hide();
            tvArtistsView.Show();
            ViewMode = ViewMode.Artists;
        }

        private void btnShowAlbums_Click(object sender, EventArgs e)
        {
            if (ViewMode == ViewMode.Albums) return;
            lbSongsView.Hide();
            tvArtistsView.Hide();
            tvAlbumsView.Show();
            ViewMode = ViewMode.Albums;
        }

        private void tvArtistsView_DoubleClick(object sender, EventArgs e)
        {
            //TODO: do not implement this. 
        }

        private void tvArtistsView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Playlist.PlaySong(e, Parent);
        }

        private void tbSearchBar_TextChanged(object sender, EventArgs e)
        {
            Playlist.Search(tbSearchBar.Text, lbSongsView);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Control | Keys.F):
                    tbSearchBar.Focus();
                    return true;
                case (Keys.Control | Keys.A):
                    switch (ViewMode)
                    {
                        case ViewMode.Songs:
                            for (var i = lbSongsView.Items.Count - 1; i >= 0; i--)
                            {
                                lbSongsView.SetSelected(i, true);
                            }
                            break;
                        case ViewMode.Artists:
                            for (var i = tvArtistsView.Nodes.Count - 1; i >= 0; i--)
                            {
                                //TODO: Not implemented
                            }
                            break;

                        case ViewMode.Albums:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void SaveFile()
        {
            if (_fileName is null)
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Playlist file (*.plst)|*.plst",
                    Title = "Save playlist"
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _fileName = saveFileDialog.FileName;
                }
            }
            if (_fileName == null) return;
            using (var fileStream = new FileStream(_fileName, FileMode.Create))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, Playlist);
            }
        }

        public void LoadFile()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Playlist file (*.plst)|*.plst",
                Title = "Save playlist"
            };
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            _fileName = openFileDialog.FileName;
            try
            {
                using (var fileStream = new FileStream(_fileName, FileMode.Open))
                {
                    IFormatter formater = new BinaryFormatter();
                    Playlist = (Playlist) formater.Deserialize(fileStream);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not read file: " + _fileName);
                _fileName = null;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFile();
        }
    }
}