using WMPLib;
namespace Media_PLayer.Structures
{
    public class Player
    {
        private readonly WindowsMediaPlayer _player;


        private bool IsPlaying => _player.playState == WMPPlayState.wmppsPlaying;
        private bool IsPaused => _player.playState == WMPPlayState.wmppsPaused;

        private double CurrentPosition { get; set; }

        private Media CurrentMedia { get; set; }

        public Player()
        {
            _player = new WindowsMediaPlayerClass();
            CurrentPosition = 0;
        }

        public void PlayMusicFile(Media song)
        {
            if(IsPlaying)
                _player.controls.stop();
            else if (IsPaused)
                PlayMusicFile(song, CurrentPosition);
            else
            {
                CurrentPosition = 0;
                PlayMusicFile(song, CurrentPosition);
            }
        }

        private void PlayMusicFile(Media song, double startPosition)
        { 
            _player.controls.currentPosition = startPosition;
            _player.URL = song.PathToFile;
            _player.controls.play();
            CurrentMedia = song;
        }


        public void Pause()
        {
            if (IsPlaying)
            {
                CurrentPosition = _player.controls.currentPosition;
                _player.controls.pause();
            }
            else if (CurrentMedia != null)
            {
                PlayMusicFile(CurrentMedia, CurrentPosition);
            }
        }

        public void Stop()
        {
            if (IsPlaying || IsPaused)
            {
                _player.controls.stop();
                CurrentMedia = null;
            }
        }

        public void VolumeUp()
        {
            _player.settings.volume++;
        }

        public void VolumeDown()
        {
            _player.settings.volume--;
        }

        public void Mute()
        {
            _player.settings.mute = !_player.settings.mute;
        }


    }
}
