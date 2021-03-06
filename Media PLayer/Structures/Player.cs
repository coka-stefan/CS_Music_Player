﻿using System;
using System.Collections.Generic;
using WMPLib;
namespace Media_Player.Structures
{
    public class Player
    {
        private readonly WindowsMediaPlayer _player;
        private IWMPPlaylist CurrentPlayList { get; set; }
        private bool IsPlaying => _player.playState == WMPPlayState.wmppsPlaying;
        private bool IsPaused => _player.playState == WMPPlayState.wmppsPaused;
        private double CurrentPosition { get; set; }
        public string CurrentMediaDurationString => _player.currentMedia.durationString;
        public string CurrentPositionString => _player.controls.currentPositionString;
        private int CurrentMediaDuration { get; set; }
        public event EventHandler<CurrentMediaChangedEventArgs> MediaChanged; 

        public Player(EventHandler<CurrentMediaChangedEventArgs> mediaChangedEventHandler)
        {
            _player = new WindowsMediaPlayerClass();
            CurrentPosition = 0;
            MediaChanged = mediaChangedEventHandler;
            _player.OpenStateChange += _player_OpenStateChange;
            _player.MediaChange += _player_MediaChange;
        }

        private void _player_MediaChange(object item)
        {
            OnMediaChanged(
                new CurrentMediaChangedEventArgs((int) _player.controls.currentPosition, (int)_player.currentMedia.duration, _player.currentMedia.durationString, _player.currentMedia.sourceURL));
        }

        private void _player_OpenStateChange(int newState)
        {
            if (newState == (int) WMPOpenState.wmposMediaOpen)
                CurrentMediaDuration = (int) _player.currentMedia.duration;
        }

        public void PlayMusicFiles(List<MusicFile> musicFiles, bool newPlaylist)
        {
            if (newPlaylist)
            {
                Stop();
                CurrentPlayList = _player.playlistCollection.newPlaylist("newSongs");
                musicFiles.ForEach(mFile => CurrentPlayList.appendItem(_player.newMedia(mFile.Url)));
                _player.currentPlaylist = CurrentPlayList;
                _player.controls.play();
            }
            else
            {
                musicFiles.ForEach(mFile => CurrentPlayList.appendItem(_player.newMedia(mFile.Url)));
            }
            
            
        }

        public void PlayMusicFile(MusicFile media)
        {
            if (IsPaused && _player.currentMedia != null && media.Url == _player.currentMedia.sourceURL)
            {
                Resume(CurrentPosition);
            }
            else if (CurrentPlayList != null)
            {
                var i = 0;
                while (i < CurrentPlayList.count && CurrentPlayList.Item[i].sourceURL != media.Url)
                    i++;
                _player.controls.playItem(_player.currentPlaylist.Item[i]);
            }
            else
            {
                CurrentPosition = 0;
                _player.URL = media.Url;
                _player.controls.play();
            }
        }

        public string CurrentMediaTimeRemaining()
        {
            if (_player.controls.currentItem != null)
                return
                    TimeSpan.FromMinutes(_player.controls.currentItem.duration - _player.controls.currentPosition)
                        .ToString()
                        .Substring(0, 5);
            else return "";
        }

       private void Resume(double position)
       {
           _player.controls.currentPosition = position;
           _player.controls.play();
       }

        public bool Pause()
        {
            if (IsPlaying)
            {
                _player.controls.pause();
                CurrentPosition = _player.controls.currentPosition;
                return true;
            }
            if (!IsPaused) return false;
            Resume(CurrentPosition);
            return false;
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

        public int Volume
        {
            get => _player.settings.volume;
            set => _player.settings.volume = value;
        }

        public bool Mute()
        {
           _player.settings.mute = !_player.settings.mute;
           return !_player.settings.mute;
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

        public void SetCurrentPosition(double position)
        {
            if (IsPlaying)
            {
                _player.controls.currentPosition = position;
            }
        }

        public void Clear()
        {
            Stop();
            _player.currentPlaylist.clear();
            CurrentPosition = 0;
            CurrentPlayList = null;
        }

        protected virtual void OnMediaChanged(CurrentMediaChangedEventArgs e)
        {
            MediaChanged?.Invoke(this, e);
        }
    }
}