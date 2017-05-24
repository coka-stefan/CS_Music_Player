using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Player
{
    public class CurrentMediaChangedEventArgs : EventArgs
    {
        public int Duration { get; set; }

        public int CurrentPosition { get; set; }

        public string DurationString { get; set; }

        public string Url { get; set; }



        public CurrentMediaChangedEventArgs(int currentPosition, int duration, string durationString, string url)
        {
            CurrentPosition = currentPosition;
            Duration = duration;
            DurationString = durationString;
            Url = url;
        }
    }
}
