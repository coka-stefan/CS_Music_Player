using System.Collections.Generic;
using Media_PLayer.Structures;

namespace Media_PLayer
{
    public class Artist
    {
        public string Name { get; set; }
        public HashSet<Album> Albums { get; }

        public Artist (string name)
        {
            Name = name;
            Albums = new HashSet<Album>();
        }

        public void AddAlbum(Album album)
        {
            Albums.Add(album);
        }
    }
}