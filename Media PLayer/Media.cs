using System.Windows.Forms;
using WMPLib;

namespace Media_PLayer
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
