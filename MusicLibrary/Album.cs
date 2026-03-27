namespace MusicLibrary
{
    public class Album
    {
        private string _title;
        private Artist _artist;
        private DateTime _releaseDate;
        private List<Song> _songs;

        public Album(string title, Artist artist, DateTime releaseDate)
        {
            Title = title;
            Artist = artist;
            ReleaseDate = releaseDate;
            _songs = new List<Song>();
        }

        public Artist Artist
        {
            get => _artist;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _artist = value;
            }
        }


        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Album title cannot be empty.");
                }

                _title = value;
            }
        }

        // TODO: Implement a property to get and initialize the album's release date with validation
        public DateTime ReleaseDate
        {
            get => _releaseDate;
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Release date cannot be in the future.");
                }

                _releaseDate = value;
            }
        }

        // TODO: Implement a method to get the list of songs in the album
        public List<Song> GetSongs()
        {
            return _songs;
        }

        // TODO: Add the ToString method to return the album's title and release data as a string album representation
        public override string ToString()
        {
            return $"{Title}-{Artist.Name} ({ReleaseDate:yyyy-MM-dd})";
        }

        // TODO: Implement a method to add a song to the album's list of songs
        public void AddSong(Song song)
        {
            if (song == null)
            {
                throw new ArgumentNullException(nameof(song));
            }

            _songs.Add(song);
        }

        // TODO: Implement a method to remove a song from the album's list of songs by song object
        public bool RemoveSong(Song song)
        {
            return _songs.Remove(song);
        }

        // TODO: Implement a method to remove a song from the album's list of songs by index
        public void RemoveSongAt(int index)
        {
            if (index < 0 || index >= _songs.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            _songs.RemoveAt(index);
        }

        // TODO: Implement a method to remove all songs from the album's list of songs
        public void ClearSongs()
        {
            _songs.Clear();
        }
    }
}
