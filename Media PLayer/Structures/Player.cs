using System.Collections.Generic;
using WMPLib;
namespace Media_PLayer.Structures
{
    public class Player
    {
        private readonly WindowsMediaPlayer _player;

        private double CurrentPosition { get; set; }
        private IWMPPlaylist CurrentPlayList { get; set; }

        private bool IsPlaying => _player.playState == WMPPlayState.wmppsPlaying;
        private bool IsPaused => _player.playState == WMPPlayState.wmppsPaused;

        public Player()
        {
            _player = new WindowsMediaPlayerClass();
            CurrentPosition = 0;
        }
        
        public void PlayMusicFiles(List<MusicFile> songs, bool newPlaylist)
        {
            Stop();
            CurrentPlayList = _player.playlistCollection.newPlaylist("newSongs");
            songs.ForEach(song => CurrentPlayList.appendItem(_player.newMedia(song.PathToFile)));
            _player.currentPlaylist = CurrentPlayList;
            _player.controls.play();
        }

        public void PlayMusicFile(Media song)
        {
            if (IsPaused && _player.currentMedia != null && song.PathToFile == _player.currentMedia.sourceURL)
            {
                Resume(CurrentPosition);
            }
            else if (CurrentPlayList != null)
            {
                var i = 0;
                while (i < CurrentPlayList.count && CurrentPlayList.Item[i].sourceURL != song.PathToFile)
                    i++;
                _player.controls.playItem(_player.currentPlaylist.Item[i]);
            }
            else {
                CurrentPosition = 0;
                _player.URL = song.PathToFile;
                _player.controls.play();
            }
        }

       private void Resume(double position)
        {
            _player.controls.currentPosition = position;
            _player.controls.play();
        }


        public void Pause()
        {
            if (IsPlaying)
            {
                _player.controls.pause();
                CurrentPosition = _player.controls.currentPosition;
            }
            else if (IsPaused)
            {
                Resume(CurrentPosition);
            }
        }

        public void Stop()
        {
            if (IsPlaying || IsPaused)
            {
                _player.controls.stop();
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

        public void SetVolume(int value)
        {
            _player.settings.volume = value;
        }

        public void Mute()
        {
            _player.settings.mute = !_player.settings.mute;
        }

        public void Next()
        {
            if (IsPaused)
                _player.controls.stop();
            _player.controls.next();
            _player.controls.play();
        }

        public void Previous()
        {
            if (IsPaused)
                _player.controls.stop();
            _player.controls.previous();
            _player.controls.play();
        }

        public void Clear()
        {
            Stop();
            _player.currentPlaylist.clear();
            CurrentPosition = 0;
            CurrentPlayList = null;
        }
    }
}