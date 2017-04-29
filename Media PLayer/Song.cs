using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_PLayer
{
    public class Song
    {
        public int Count { get; set; }
        public String Name { get; set; }
        public String URL { get; set; }
//        public enum Rating { get; set; }
        public int Number { get; set; }
        public TimeSpan Length { get; set; }
        public String Genre { get; set; }

        public Song(String URL, String Name, int Number, TimeSpan Length)
        {
            this.URL = URL;
            Count = 0;
            this.Name = Name;
            this.Number = Number;
            this.Length = Length;

        }

        public override string ToString()
        {
            String FormatedName;
            if(Name.Length>=20)
            {
                FormatedName = Name.Substring(0, 17) + "...";
            } else
            {
                FormatedName = this.Name;
            }
            return String.Format("{0,2}.{1,20}{2}", this.Number, FormatedName, this.Length ); 
        }

        public override bool Equals(object obj)
        {
            Song o = (Song)obj;
            return this.Name == o.Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
