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
    [Serializable]
    public class Playlist
    {
        private Dictionary<string, Artist> Artists { get; }

        public Playlist()
        {
            Artists = new Dictionary<string, Artist>();
        }

        public void AddSong(string fileName)
        {
            var file = TagLib.File.Create(fileName);
            var artist = file.Tag.FirstPerformer;
            var album = file.Tag.Album;
            var song = new Song(fileName, file.Tag.Title, artist, album, file.Tag.Genres, file.Tag.Track,
                file.Properties.Duration);
            AddSongToArtist(artist, album, song);
        }

        private void AddSongToArtist(string artist, string album, Song song)
        {
            if (!Artists.ContainsKey(artist))
                Artists.Add(artist, new Artist(artist));
            Artists[artist].AddSong(album, song);
        }

        public void ShowSongsOnControl(ListBox listBox)
        {
            listBox.DataSource = null;

            foreach (var artist in Artists.Values)
            {
                artist.Songs.ForEach(song =>
                {
                    if (!listBox.Items.Contains(song))
                        listBox.Items.Add(song);
                });
            }
        }

        public void ShowAlbumsOnTreeView(TreeView treeView)
        {
            treeView.Nodes.Clear();

            foreach (var artist in Artists.Values)
            {
                foreach (var album in artist.Albums.Values)
                {
                    var albumExists = treeView.Nodes.ContainsKey(album.Name);

                    if (albumExists)
                    {
                        AddNodeToAlbum(album, treeView);
                    }
                    else
                    {
                        var albumNode = new TreeNode(album.Name)
                        {
                            Name = album.Name,
                            ImageKey = album.Name,
                            Tag = album
                        };

                        treeView.Nodes.Add(albumNode);

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
                }
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

            // MessageBox.Show(@"NOT IMPLEMENTED YET Should play " + e.Node.Text);

            //   var songToPlay = (Song) e.Node.Tag;
        }

        public void Search(string pattern, ListBox lb)
        {
            lb.DataSource = (from artist in Artists.Values
                from album in artist.Albums.Values
                from song in album.Songs.Values
                where song.Title.ToLower().Contains(pattern.ToLower())
                      || song.Artist.ToLower().Contains(pattern.ToLower())
                      || song.Album.ToLower().Contains(pattern.ToLower())
                select song).ToList();
        }

        public void RemoveSelectedSongs(ListBox lbSongsView, TreeView artistView, TreeView albumView)
        {
            var songsToRemove = lbSongsView.SelectedItems;

            foreach (var song in songsToRemove)
            {
                foreach (var artist in Artists.Values)
                {
                    foreach (var album in artist.Albums.Values)
                    {
                        var tmp = new Dictionary<uint, Song>(album.Songs);
                        foreach (var albumSong in tmp)
                        {
                            if (albumSong.Value == song)
                                album.Songs.Remove(albumSong.Key);
                        }
                    }
                }
            }

            CheckForDeleted(lbSongsView, artistView, albumView);
        }

        private void CheckForDeleted(ListBox lbSongsView, TreeView artistView, TreeView albumView)
        {
            var artists = new Dictionary<string, Artist>(Artists);
            foreach (var artist in artists)
            {
                if (artist.Value.Albums.Count == 0)
                    Artists.Remove(artist.Key);
                else
                {
                    var albums = new Dictionary<string, Album>(artist.Value.Albums);
                    foreach (var album in albums)
                    {
                        if (album.Value.Songs.Count != 0) continue;
                        artist.Value.Albums.Remove(album.Key);
                        CheckForDeleted(lbSongsView, artistView, albumView);
                    }
                }
            }

            lbSongsView.Items.Clear();
            artistView.Nodes.Clear();
            albumView.Nodes.Clear();
            ShowAlbumsOnTreeView(albumView);
            ShowArtistsOnTreeView(artistView);
            ShowSongsOnControl(lbSongsView);
        }

        public void RemoveSelectedSongs(TreeView tvArtistsView, ListBox lbSongsView, TreeView albumView)
        {
            var remove = tvArtistsView.SelectedNode;

            switch (remove.Level)
            {
                case 0:
                    {
                        var artist = (Artist)remove.Tag;
                        Artists.Remove(artist.Name);
                    }
                    break;
                case 1:
                    {
                        var album = (Album)remove.Tag;
                        var artist = (Artist)remove.Parent.Tag;
                        Artists[artist.Name].Albums.Remove(album.Name);
                    }
                    break;
                case 2:
                    {
                        //var album = (Album)remove.Parent.Tag;
                        //var artist = (Artist)remove.Parent.Parent.Tag;
                        var song = (Song)remove.Tag;
                        for (var i = 0; i < lbSongsView.Items.Count; i++)
                        {
                            lbSongsView.SetSelected(i, false);
                            if (lbSongsView.Items[i] == song)
                            {
                                lbSongsView.SetSelected(i, true);
                            }
                        }
                        RemoveSelectedSongs(lbSongsView, tvArtistsView, albumView);
                        //Artists[artist.Name].Albums[album.Name].Songs.Remove(song.Number);
                    }
                    break;
                default:
                    return;
            }

            CheckForDeleted(lbSongsView, tvArtistsView, albumView);
        }

        public void RemoveSelectedSongs(TreeView tvAlbumView, TreeView tvArtistView, ListBox lbSongsView)
        {
            var remove = tvAlbumView.SelectedNode;
            var artists = new Dictionary<string, Artist>(Artists);

            switch (remove.Level)
            {
                case 0:
                    foreach (var artist in artists)
                    {
                        artist.Value.Albums.Remove(remove.Name);
                    }
                    break;
                case 1:
                    foreach (var artist in artists)
                    {
                        //var album = (Album) remove.Parent.Tag;
                        var song = (Song) remove.Tag;
                        //artist.Value.Albums[album.Name].Songs.Remove(song.Number);

                        for (var i = 0; i < lbSongsView.Items.Count; i++)
                        {
                            lbSongsView.SetSelected(i,false);
                            if (lbSongsView.Items[i] == song)
                            {
                                lbSongsView.SetSelected(i, true);
                            }
                        }
                        RemoveSelectedSongs(lbSongsView, tvArtistView, tvAlbumView);
                    }
                    break;
                default:
                    return;
            }
            CheckForDeleted(lbSongsView, tvArtistView, tvAlbumView);
        }
    }
}