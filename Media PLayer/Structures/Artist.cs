using System.Collections.Generic;
using Media_Player.Structures;

namespace Media_Player
{
    public class Artist
    {
        public string Name { get; set; }
        public Dictionary<string, Album> Albums { get; set; }

        public Artist (string name)
        {
            Name = name;
            Albums = new Dictionary<string, Album>();
        }

        public void AddAlbum(Album album)
        {
            Albums.Add(album.Name, album);
        }

        public void AddSong(string album, Song song)
        {
            if(!Albums.ContainsKey(album))
                Albums.Add(album, new Album(album));
            Albums[album].AddSong(song);
        }

        public List<Song> Songs
        {
            get
            {
                var songs = new List<Song>();
                foreach (Album album in Albums.Values)
                {
                    songs.AddRange(album.Songs.Values);
                }
                return songs;
            }
        }
    }
}