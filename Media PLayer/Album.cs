using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_PLayer
{
    public class Album
    {
        public String CoverURL { get; set; }
        public int Year { get; set; }
        public Dictionary<int, Song> Songs { get; }
        public String Name { get; set; }

        public Album(String CoverURL, int Year, String Name)
        {
            this.CoverURL = CoverURL;
            this.Year = Year;
            this.Name = Name;
            Songs = new Dictionary<int, Song>();
        }

        public void addSong(Song song)
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
            return Name == o.Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
