using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Media_Player;
using Media_Player.Structures;

namespace Media_PLayer
{
    public class Playlist
    {
        private Dictionary<string, Artist> Artists { get; }

        public Playlist()
        {
            Artists = new Dictionary<string, Artist>();
        }

        public void AddSong(string fileName, ListBox lb, string search)
        {
            var file = TagLib.File.Create(fileName);
            var artist = file.Tag.FirstPerformer;
            var album = file.Tag.Album;
            var song = new Song(fileName, file.Tag.Title, artist, album, file.Tag.Genres, (uint) (lb.Items.Count + 1),
                file.Properties.Duration);
            AddSongToArtist(artist, album, song);

            Search(search, lb); //updates list box
        }

        private void AddSongToArtist(string artist, string album, Song song)
        {
            if (!Artists.ContainsKey(artist))
                Artists.Add(artist, new Artist(artist));
            Artists[artist].AddSong(album, song);
        }

        public void ShowSongsOnControl(ListBox listBox)
        {
            foreach (var artist in Artists.Values)
            {
                artist.Songs.ForEach(song => listBox.Items.Add(song));
            }
        }

        public void ShowArtistsOnTreeView(TreeView treeView)
        {
            // show artists as root nodes, albums as child nodes to artists nodes, songs as leafs to every album node

            treeView.Nodes.Clear();

            foreach (var artist in Artists.Values)
            {
                var artistNode = new TreeNode(artist.Name)
                {
                    Name = artist.Name,
                    ImageKey = artist.Name,
                    Tag = artist // Use this for retrieval of artist
                };
                var artistExists = treeView.Nodes.ContainsKey(artist.Name);

                if (artistExists)
                {
                    AddNodeToArtist(artist, treeView);
                }
                else
                {
                    AddNewArtistNode(artistNode, treeView);
                }
            }
        }

        private static void AddNewArtistNode(TreeNode artistNode, TreeView treeView)
        {
            treeView.Nodes.Add(artistNode);
            var artist = (Artist) artistNode.Tag;

            foreach (var album in artist.Albums.Values)
            {
                var albumExists = artistNode.Nodes.ContainsKey(album.Name);

                if (albumExists)
                {
                    AddNodeToAlbum(album, treeView);
                }
                else
                {
                    AddNewAlbumNode(artistNode, album);
                }
            }
        }

        private static void AddNewAlbumNode(TreeNode artistNode, Album album)
        {
            var albumNode = new TreeNode(album.Name)
            {
                Name = album.Name,
                ImageKey = album.Name,
                Tag = album
            };

            artistNode.Nodes.Add(albumNode);

            foreach (var song in album.Songs.Values)
            {
                var songNode = new TreeNode(song.Title)
                {
                    Name = song.Title,
                    ImageKey = song.Url,
                    Tag = song
                };
                if (!albumNode.Nodes.ContainsKey(songNode.ImageKey))
                    albumNode.Nodes.Add(songNode);
            }
        }

        private static void AddNodeToAlbum(Album album, TreeView treeView)
        {
            var albumNode = treeView.Nodes.Find(album.Name, true)[0];
            foreach (var song in album.Songs.Values)
            {
                var songNode = new TreeNode(song.Title)
                {
                    Name = song.Title,
                    ImageKey = song.Url,
                    Tag = song
                };
                if (!albumNode.Nodes.ContainsKey(songNode.ImageKey))
                    albumNode.Nodes.Add(songNode);
            }
        }

        private static void AddNodeToArtist(Artist artist, TreeView treeView)
        {
            var artistNodeNew = treeView.Nodes.Find(artist.Name, true)[0];

            foreach (var album in artist.Albums.Values)
            {
                var albumExists = artistNodeNew.Nodes.ContainsKey(album.Name);

                if (albumExists)
                {
                    AddNodeToAlbum(album, treeView);
                }
                else
                {
                    AddNewAlbumNode(artistNodeNew, album);
                }
            }
        }

        public static void PlaySong(TreeNodeMouseClickEventArgs e, Control parent)
        {
            //TODO: Play song from e

            MessageBox.Show(@"NOT IMPLEMENTED YET
Should play " + e.Node.Text);

            var songToPlay = (Song) e.Node.Tag;

            var play = new MusicFile(songToPlay);
            var mf = (MainForm) parent;
            //mf.lbOpenedFiles.Items.Add(play);
        }

        public void Search(string search, ListBox lb)
        {
            lb.DataSource = (from artist in Artists.Values
                from album in artist.Albums.Values
                from song in album.Songs.Values
                where song.Title.ToLower().Contains(search.ToLower())
                select song).ToList();
        }
    }
}