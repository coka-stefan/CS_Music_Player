using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_PLayer
{
    public class CurrentMediaChangedEventArgs : EventArgs
    {
        public int NewMediaDuration { get; set; }

        public int CurrentPosition { get; set; }

        public string Url { get; set; }



        public CurrentMediaChangedEventArgs(int currentPosition, int newMediaDuration, string url)
        {
            CurrentPosition = currentPosition;
            NewMediaDuration = newMediaDuration;
            Url = url;
        }
    }
}
