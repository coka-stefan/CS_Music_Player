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
            FillComponents();
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
                    lbSongsView.Hide();
                    tvArtistsView.Hide();
                    tvAlbumsView.Show();
                    break;
                default:
                    return;
            }
        }

        private void FillComponents()
        {
            Playlist.ShowArtistsOnTreeView(tvArtistsView);
            Playlist.ShowSongsOnControl(lbSongsView);
            Playlist.ShowAlbumsOnTreeView(tvAlbumsView);
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
            //TODO: transport the selected item(s) into the main form to be played
        }

        private void tbSearchBar_TextChanged(object sender, EventArgs e)
        {
            tvArtistsView.Hide();
            tvAlbumsView.Hide();
            lbSongsView.Show();
            ViewMode = ViewMode.Songs;
            Playlist.Search(tbSearchBar.Text, lbSongsView);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Control | Keys.F):
                    tbSearchBar.Focus();
                    break; //return true;
                case (Keys.Control | Keys.A):
                    switch (ViewMode)
                    {
                        case ViewMode.Songs:
                            SelectAllSongs(lbSongsView);
                            break;
                        case ViewMode.Artists:
                            SelectAllSongs(tvArtistsView);
                            break;
                        case ViewMode.Albums:
                            SelectAllSongs(tvAlbumsView);
                            break;
                    }
                    break;
                case (Keys.Delete):
                    RemoveSelectedItems();
                    break;
                case (Keys.Escape):
                    switch (ViewMode)
                    {
                        case ViewMode.Songs:
                            DeselectAllSongs(lbSongsView);
                            break;
                        case ViewMode.Artists:
                            DeselectAllSongs(tvArtistsView);
                            break;
                        case ViewMode.Albums:
                            DeselectAllSongs(tvAlbumsView);
                            break;
                    }
                    break;
                case Keys.Enter:
                    //TODO: Play selected songs
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void DeselectAllSongs(Control control)
        {
            if (control.GetType() == typeof(ListBox))
            {
                var lb = (ListBox)control;
                for (var i = 0; i < lb.Items.Count; i++)
                    lb.SetSelected(i, false);
            }
            else
            {
                tvArtistsView.Hide();
                tvAlbumsView.Hide();
                lbSongsView.Show();
                ViewMode = ViewMode.Songs;
                DeselectAllSongs(lbSongsView);
            }
        }


        private void RemoveSelectedItems()
        {
            switch (ViewMode)
            {
                case ViewMode.Songs:
                    Playlist.RemoveSelectedSongs(lbSongsView, tvArtistsView, tvAlbumsView);
                    break;
                case ViewMode.Artists:
                    Playlist.RemoveSelectedSongs(tvArtistsView, lbSongsView, tvAlbumsView);
                    break;
                case ViewMode.Albums:
                    Playlist.RemoveSelectedSongs(tvAlbumsView, tvArtistsView, lbSongsView);
                    break;
                default:
                    return;
            }
            //TODO: Remove selected items (if any) from the playlist Dictionary and all the controls 
        }

        private void SaveFile()
        {
            if (_fileName is null)
            {
                var saveFileDialog = new SaveFileDialog()
                {
                    Filter = @"Playlist file (*.plst)|*.plst",
                    Title = @"Save playlist"
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    _fileName = saveFileDialog.FileName;
            }
            if (_fileName == null) return;
            using (var fileStream = new FileStream(_fileName, FileMode.Create))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, Playlist);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fileName = null;
            SaveFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

        private void LoadFile()
        {
            var openFileDialog = new OpenFileDialog()
            {
                Filter = @"Playlist file (*.plst)|*.plst",
                Title = @"Save playlist"
            };
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            _fileName = openFileDialog.FileName;
            try
            {
                using (var fileStream = new FileStream(_fileName, FileMode.Open))
                {
                    IFormatter formater = new BinaryFormatter();
                    Playlist = (Playlist) formater.Deserialize(fileStream);
                    FillComponents();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Could not read file: " + _fileName);
                _fileName = null;
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (ViewMode)
            {
                case ViewMode.Songs:
                    SelectAllSongs(lbSongsView);
                    break;
                case ViewMode.Artists:
                    SelectAllSongs(tvArtistsView);
                    break;
                case ViewMode.Albums:
                    SelectAllSongs(tvAlbumsView);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        private void SelectAllSongs(Control control)
        {
            if (control.GetType() == typeof(ListBox))
            {
                var lb = (ListBox) control;
                for (var i = 0; i < lb.Items.Count; i++)
                    lb.SetSelected(i, true);
            }
            else
            {
                tvArtistsView.Hide();
                tvAlbumsView.Hide();
                lbSongsView.Show();
                ViewMode = ViewMode.Songs;
                SelectAllSongs(lbSongsView);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to save current playlist first?", "Save?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SaveFile();
            }
            else
            {
                Playlist.Clear();
                tvArtistsView.Nodes.Clear();
                lbSongsView.Items.Clear();
                tvAlbumsView.Nodes.Clear();
                _fileName = null;
            }
        }
    }
}