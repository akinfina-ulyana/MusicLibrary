using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicLibrary
{
    public class MusicPlayer
    {
        private List<Album> _albums = new();
        private List<Song> _playlist = new();

        private int _currentIndex = 0;
        private bool _isPlaying = false;

        private Album _currentAlbum;
        public void AddAlbum(Album album)
        {
            if (album == null)
            {
                throw new ArgumentNullException(nameof(album));
            }

            _albums.Add(album);
        }

        public void SelectAlbum(string title)
        {
            _currentAlbum = _albums.FirstOrDefault(a => a.Title == title);

            if (_currentAlbum == null)
            {
                throw new Exception("Album not found");
            }

            Console.WriteLine($"Selected album: {_currentAlbum.Title}");
        }

        public void CreatePlaylist(params Song[] songs)
        {
            if (songs == null || songs.Length == 0)
            {
                throw new ArgumentException("Playlist cannot be empty");
            }

            _playlist = songs.ToList();
            _currentIndex = 0;

            Console.WriteLine("Playlist created");
        }

        public void Play()
        {
            if (_playlist.Count == 0)
            {
                Console.WriteLine("Playlist is empty");
                return;
            }

            _isPlaying = true;

            Console.WriteLine($"▶ Playing: {_playlist[_currentIndex]}");
        }
        public void Pause()
        {
            _isPlaying = false;
            Console.WriteLine("⏸ Paused");
        }


        public void Next()
        {
            if (_playlist.Count == 0)
            {
                return;
            }

            _currentIndex++;

            if (_currentIndex >= _playlist.Count)
            {
                this._currentIndex = 0;
            }

            Console.WriteLine($"⏭ Next: {_playlist[_currentIndex]}");

            if (_isPlaying)
            {
                this.Play();
            }
        }
    }
}
