namespace Media_Player
{
    public abstract class Media
    {
        public string PathToFile { get; set; }
        
        protected Media(string pathToFile)
        {
            PathToFile = pathToFile;
        }

    }
}
