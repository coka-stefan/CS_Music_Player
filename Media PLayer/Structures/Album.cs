using System;
using System.Collections.Generic;

namespace Media_PLayer.Structures
{
    public class Album
    {
        public string Name { get; set; }
        public Dictionary<uint, Song> Songs { get; }

        public string CoverUrl { get; set; }
        public int Year { get; set; }

        public Album(string coverUrl, int year, string name)
        {
            CoverUrl = coverUrl;
            Year = year;
            Name = name;
            Songs = new Dictionary<uint, Song>();
        }

        public void AddSong(Song song)
        {
            Songs.Add(song.Number, song);
        }

        public override string ToString()
        {
            return String.Format("{0,20}({2})", Name, Year);
        }

        public override bool Equals(object obj)
        {
            Album o = (Album)obj;
            return o != null && Name == o.Name;
        }

        public override int GetHashCode() => base.GetHashCode();
    }
}