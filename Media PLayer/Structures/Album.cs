using System;
using System.Collections.Generic;

namespace Media_Player.Structures
{
    public class Album
    {
        public string Name { get; set; }
        public Dictionary<uint, Song> Songs { get; }

        public string CoverUrl { get; set; }
        public int Year { get; set; }


        public Album(string name)
        {
            Name = name;
            Songs = new Dictionary<uint, Song>();
        }

        public Album(string coverUrl, int year, string name)
        {
            CoverUrl = coverUrl;
            Year = year;
            Name = name;
            Songs = new Dictionary<uint, Song>();
        }

        public void AddSong(Song song)
        {
            Songs.Add((uint) (Songs.Keys.Count + 1), song);
        }

        public override string ToString()
        {
            return string.Format("{0,20}({2})", Name, Year);
        }
    }
}