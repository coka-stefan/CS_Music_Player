using System;
using System.Collections.Generic;

namespace Media_Player.Structures
{
    [Serializable]
    public class Album
    {
        public string Name { get; set; }
        public Dictionary<uint, Song> Songs { get; }

        private string CoverUrl { get; set; }
        private int Year { get; set; }


        public Album(string name)
        {
            if (name is null)
                Name = "Unknown";
            else
                Name = name;
            Songs = new Dictionary<uint, Song>();
        }

        public Album(string coverUrl, int year, string name)
        {
            CoverUrl = coverUrl;
            Year = year;
            if (name is null)
                Name = "Unknown";
            else
                Name = name;
            Songs = new Dictionary<uint, Song>();
        }

        public void AddSong(Song song)
        {
            Songs.Add((uint) (Songs.Keys.Count + 1), song);
        }

        public override string ToString()
        {
            return $"{Name,20}({Year})";
        }
    }
}