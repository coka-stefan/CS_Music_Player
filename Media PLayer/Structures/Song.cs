using System;

namespace Media_Player.Structures
{
    public class Song
    {
        public string Title { get; set; }
        public uint Number { get; set; }
        public TimeSpan Length { get; set; }
        public string [] Genres { get; set; }
        public int TimesPlayed { get; set; }
        public string Url { get; set; }

        public string Artist { get; set; }
        public string Album { get; set; }

        public int Duration => Length.Minutes * 60 + Length.Seconds;

        public string DurationString => $"{Length.Minutes,00:00}:{Length.Seconds,00:00}";

        public Song(string url, string title, string[] genres, uint trackNumber, TimeSpan length)
        {
            Url = url;
            Title = title;
            Genres = genres;
            Number = trackNumber;
            Length = length;
        }
        public Song(string url, string title, string artist, string album, string[] genres, uint trackNumber, TimeSpan length)
        {
            Url = url;
            Title = title;
            Genres = genres;
            Number = trackNumber;
            Length = length;
            Artist = artist;
            Album = album;
        }

        public Song(string url, string title, uint number, TimeSpan length)
        {
            Url = url;
            TimesPlayed = 0;
            Title = title;
            Number = number;
            Length = length;
        }

        public override string ToString()
        {
            var formattedTitle = Title;
            if (Title.Length > 20)
                formattedTitle = Title.Substring(0, 20) + "...";
            var formattedArtistName = Artist;
            if (formattedArtistName.Length >= 20)
                formattedArtistName = formattedArtistName.Substring(0, 17) + "...";
            var formattedAlbumName = Album;
            if (formattedAlbumName.Length >= 20)
                formattedAlbumName = formattedAlbumName.Substring(0, 17) + "...";
            return $"{formattedTitle,-60}\t{DurationString,-8}\t{formattedArtistName,-25}\t{formattedAlbumName,-25}";
        }

        public string PlaylistString()
        {
            {
                string formatedName;
                var duration = Length.Minutes + ":" + Length.Seconds;
                if (Title.Length >= 30)
                {
                    formatedName = Title.Substring(0, 27) + "...";
                }
                else
                {
                    formatedName = Title;
                }
                return $"{Number,-2}.{formatedName,-30}\t{duration,-30}";
            }
        }
    }
}
