using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_PLayer
{
    public class Artist
    {
        public String Name { get; set; }
        public HashSet<Album> Albums { get; }

        public Artist (String Name)
        {
            this.Name = Name;
            this.Albums = new HashSet<Album>();
        }

        public void addAlbum(Album album)
        {
            Albums.Add(album);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
