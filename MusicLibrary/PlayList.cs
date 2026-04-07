using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary
{
    internal class PlayList
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdated { get; private set; }

        public List<Song> Songs { get; private set; }

        public int SongCount => Songs.Count;

        // в моем классе Song, длительность с типом double
        public TimeSpan TotalDuration =>
        TimeSpan.FromMinutes(Songs.Sum(s => s.DurationMinutes));

        public double AverageRating => Songs.Count == 0 ? 0 : Songs.Average(s => s.Rating);

        public PlayList()
        {
            Name = string.Empty;
            Description = string.Empty;
            Songs = new List<Song>();
            CreatedDate = DateTime.Now;
            LastUpdated = CreatedDate;
        }

        public PlayList(string name, string description) : this()
        {
            Name = name;
            Description = description;
        }

        public void AddSong(Song song)
        {
            if (song == null)
            {
                throw new ArgumentNullException(nameof(song));
            }
            Songs.Add(song);
            LastUpdated = DateTime.Now;
        }

        public bool RemoveSong(Song song)
        {
            if (song == null)
            {
                return false;
            }

            bool removed = Songs.Remove(song);
            if (removed)
            {
                LastUpdated = DateTime.Now;
            }
            return removed;
        }
        public void RemoveSong(int index)
        {
            if (index < 0 || index >= Songs.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            Songs.RemoveAt(index);
            LastUpdated = DateTime.Now;
        }

        public void ClearSongs()
        {
            if (Songs.Count == 0)
            {
                return;
            }

            Songs.Clear();
            LastUpdated = DateTime.Now;
        }
        public void ShuffleSongs()
        {
            if (Songs.Count <= 1)
            {
                return;
            }

            var rng = new Random();

            for (int i = Songs.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                (Songs[i], Songs[j]) = (Songs[j], Songs[i]);
            }
        }

        public List<Song> GetSongsByArtist(Artist artist)
        {
            if (artist == null)
            {
                throw new ArgumentNullException(nameof(artist));
            }

            return Songs.Where(s => s.Artist == artist).ToList();
        }

        public static PlayList CreateFromAlbum(Album album, string? customName = null)
        {
            if (album == null)
            {
                throw new ArgumentNullException(nameof(album));
            }

            var playlist = new PlayList
            {
                Name = customName ?? album.Title,
                Description = $"Playlist created from album: {album.Title}",
                CreatedDate = DateTime.Now,
                LastUpdated = DateTime.Now
            };

            foreach (var song in album.Song)
            {
                playlist.AddSong(song);
            }

            return playlist;
        }

    }
}
