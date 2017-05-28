using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Media_Player.Structures;

namespace Media_PLayer
{
    public class PlaylistPlayClickedEventArgs : EventArgs
    {
        public List<Song> SongsToBePlayed { get; set; }

        public PlaylistPlayClickedEventArgs(List<Song> songsToBePlayed)
        {
            SongsToBePlayed = songsToBePlayed;
        }
    }
}
