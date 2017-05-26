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
            Song song = new Song(fileName, file.Tag.Title, artist, album, file.Tag.Genres, (uint) (lb.Items.Count + 1) , file.Properties.Duration);
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
        }
        

    }
}
