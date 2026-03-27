using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicLibrary
{
    public class Artist
    {
        private string _name;

        public string Name
        {
            get => _name;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Artist name cannot be empty.");
                }

                _name = value;
            }
        }

        public DateTime DateOfBirth { get; set; }

        public List<Album> Albums { get; set; } = new List<Album>();

        public Artist(string name, DateTime dateOfBirth)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
        }

        public override string ToString()
        {
            return $"{Name} Born: {DateOfBirth:yyyy-MM-dd}";
        }

        public void AddAlbum(Album album)
        {
            if (album == null)
            {
                throw new ArgumentNullException(nameof(album));
            }

            Albums.Add(album);
        }

        public bool RemoveAlbum(Album album)
        {
            return Albums.Remove(album);
        }

        public void RemoveAlbumAt(int index)
        {
            if (index < 0 || index >= Albums.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            Albums.RemoveAt(index);
        }

        public bool RemoveAlbumByTitle(string title)
        {
            var album = Albums.FirstOrDefault(a => a.Title == title);

            if (album == null)
            {
                return false;
            }

            Albums.Remove(album);
            return true;
        }

        public bool RemoveAlbumByReleaseDate(DateTime releaseDate)
        {
            var album = Albums.FirstOrDefault(a => a.ReleaseDate == releaseDate);

            if (album == null)
            {
                return false;
            }

            Albums.Remove(album);
            return true;
        }
    }
}
