using Media_Player.Structures;

namespace Media_Player
{
    public class MusicFile
    {
        private Song Song { get; set; }

        public string AlbumCover { get; set; }

        public string Url => Song.Url;

        public int Duration => Song.Duration;

        public MusicFile(string url, uint trackNumber) 
        {
            var file = TagLib.File.Create(url);
            Song = new Song(url, file.Tag.Title, file.Tag.FirstPerformer, file.Tag.Album, file.Tag.Genres, trackNumber, file.Properties.Duration);
        }

        public MusicFile(Song song)
        {
            Song = song;
        }

        public override string ToString()
        {
            return $"{Song.Number + ".",-4}{Song.Title,-50}\t{Song.DurationString, 5}";
        }
    }
}