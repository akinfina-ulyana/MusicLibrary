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

        public List<Song> GetSongs()
        {
            return _songs;
        }
        public override string ToString()
        {
            return $"{Title}-{Artist.Name} ({ReleaseDate:yyyy-MM-dd})";
        }

        public void AddSong(Song song)
        {
            if (song == null)
            {
                throw new ArgumentNullException(nameof(song));
            }

            _songs.Add(song);
        }

        public bool RemoveSong(Song song)
        {
            return _songs.Remove(song);
        }

        public void RemoveSongAt(int index)
        {
            if (index < 0 || index >= _songs.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            _songs.RemoveAt(index);
        }

        public void ClearSongs()
        {
            _songs.Clear();
        }
    }
}
