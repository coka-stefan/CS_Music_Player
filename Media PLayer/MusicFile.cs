using Media_Player.Structures;

namespace Media_Player
{
    public class MusicFile : Media
    {
        private Song Song { get; set; }

        public string AlbumCover { get; set; }

        public string Url => PathToFile;

        public int Duration => Song.Duration;

        public MusicFile(string pathToFile, uint trackNumber) : base(pathToFile)
        {
            TagLib.File file = TagLib.File.Create(pathToFile);
            Song = new Song(pathToFile, file.Tag.Title, file.Tag.Genres, trackNumber, file.Properties.Duration);
        }

        public override string ToString()
        {
            return Song.ToString();
        }
    }
}
