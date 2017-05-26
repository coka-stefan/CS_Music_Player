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

        public void AddSong(string fileName, ListBox lb)
        {
            TagLib.File file = TagLib.File.Create(fileName);
            var artist = file.Tag.FirstPerformer;
            var album = file.Tag.Album;
            Song song = new Song(fileName, file.Tag.Title, artist, album, file.Tag.Genres, (uint) (lb.Items.Count + 1),
                file.Properties.Duration);
            AddSongToArtist(artist, album, song);
            lb.Items.Add(song);
        }

        private void AddSongToArtist(string artist, string album, Song song)
        {
            if (!Artists.ContainsKey(artist))
                Artists.Add(artist, new Artist(artist));
            Artists[artist].AddSong(album, song);
        }

        public void ShowSongsOnControl(ListBox listBox)
        {
            foreach (Artist artist in Artists.Values)
            {
                artist.Songs.ForEach(song => listBox.Items.Add(song));
            }
        }

        public void ShowArtistsOnTreeView(TreeView treeView)
        {
            // show artists as root nodes, albums as child nodes to artists nodes, songs as leafs to every album node

            foreach (Artist artist in Artists.Values)
            {
                TreeNode artistNode = new TreeNode(artist.Name)
                {
                    Name = artist.Name,
                    ImageKey = artist.Name,
                    Tag = artist // Use this for retrieval of artist
                };
                Boolean artistExists = treeView.Nodes.ContainsKey(artistNode.ImageKey);

                if (artistExists)
                {
                    TreeNode artistNodeNew = treeView.Nodes.Find(artist.Name, true)[0];

                    foreach (Album album in artist.Albums.Values)
                    {
                        TreeNode albumNodeTest = new TreeNode(album.Name)
                        {
                            Name = album.Name,
                            ImageKey = album.Name,
                            Tag = album // Use this for retrieval of album
                        };

                        Boolean albumExists = artistNodeNew.Nodes.ContainsKey(albumNodeTest.ImageKey);

                        if (albumExists)
                        {
                            TreeNode albumNode = treeView.Nodes.Find(album.Name, true)[0];
                            foreach (Song song in album.Songs.Values)
                            {
                                TreeNode songNode = new TreeNode(song.Title)
                                {
                                    Name = song.Title,
                                    ImageKey = song.Url,
                                    Tag = song // Use this for retrieval of song
                                };
                                albumNode.Nodes.Add(songNode);
                            }
                        }
                        else
                        {
                            artistNodeNew.Nodes.Add(albumNodeTest);
                        }
                    }
                }
                else
                {
                    treeView.Nodes.Add(artistNode);

                    foreach (Album album in artist.Albums.Values)
                    {
                        TreeNode albumNodeTest = new TreeNode(album.Name)
                        {
                            Name = album.Name,
                            ImageKey = album.Name,
                            Tag = album
                        };
                        Boolean albumExists = artistNode.Nodes.ContainsKey(albumNodeTest.ImageKey);

                        if (albumExists)
                        {
                            TreeNode albumNode = treeView.Nodes.Find(album.Name, true)[0];
                            foreach (Song song in album.Songs.Values)
                            {
                                TreeNode songNode = new TreeNode(song.Title)
                                {
                                    Name = song.Title,
                                    ImageKey = song.Url,
                                    Tag = song
                                };
                                albumNode.Nodes.Add(songNode);
                            }
                        }
                        else
                        {
                            artistNode.Nodes.Add(albumNodeTest);

                            foreach (Song song in album.Songs.Values)
                            {
                                TreeNode songNode = new TreeNode(song.Title)
                                {
                                    Name = song.Title,
                                    ImageKey = song.Url,
                                    Tag = song
                                };
                                albumNodeTest.Nodes.Add(songNode);
                            }
                        }
                    }
                }
            }
        }

        public void PlaySong(TreeNodeMouseClickEventArgs e)
        {
            //TODO: Play song from e

            MessageBox.Show(@"NOT IMPLEMENTED YET
Should play " + e.Node.Text);

            Song songToPlay = (Song) e.Node.Tag;
        }
    }
}