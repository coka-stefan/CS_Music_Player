using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Media_Player.Structures;

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
        
        public Playlist Playlist { get; set; }
        private ViewMode ViewMode { get; set; }

        private string _fileName;
        private EventHandler<PlaylistPlayClickedEventArgs> PlayClickedEventHandler { get; set; }

        public PlaylistForm(EventHandler<PlaylistPlayClickedEventArgs> playClickedEventHandler)
        {
            InitializeComponent();
            ViewMode = ViewMode.Songs;
            tvArtistsView.Hide();
            tvAlbumsView.Hide();
            PlayClickedEventHandler = playClickedEventHandler;
            
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
            //TODO: transport the selected item(s) into the main form to be played
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
                    break;//return true;
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
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void RemoveSelectedItems()
        {
            //TODO: Remove selected items (if any) from the playlist Dictionary and all the controls 
        }

        public void SaveFile()
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
            SaveFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

        public void LoadFile()
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
            if(ViewMode == ViewMode.Songs)
                SelectAllSongs(lbSongsView);
            else if (ViewMode == ViewMode.Artists)
                SelectAllSongs(tvArtistsView);
            else SelectAllSongs(tvAlbumsView);
        }


        private void SelectAllSongs(Control control)
        {
            if (control.GetType() == typeof(ListBox))
            {
                ListBox lb = (ListBox) control;
                for (var i = 0; i < lb.Items.Count; i++)
                    lb.SetSelected(i, true);
            }
            //TODO: Select all files in tvArtistView and tvAlbumsVieww

            else if (control.GetType() == typeof(TreeView))
            {

            }
            else
            {
                
            }
            
        }

        private void allSongsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayClickedEventHandler.Invoke(this, new PlaylistPlayClickedEventArgs(Playlist.AllSongs));
        }

        private void removeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: delete all songs from everywhere
        }

        private void selectedSongsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbSongsView.SelectedIndices.Count > 0)
            {
                var selectedSongs = lbSongsView.SelectedItems.Cast<Song>().ToList();
                PlayClickedEventHandler.Invoke(this, new PlaylistPlayClickedEventArgs(selectedSongs));
            }
        }
    }
}