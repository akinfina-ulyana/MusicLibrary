namespace MusicLibrary
{
    // Этот клас я переписала в большей степени, так как объявление атрибутов класса не совпадает с инициализацией объекта
    // поэтому я добавила пару полей и так же изменила некоторые другие классы
    public class Song
    {
        private string _title;
        private Artist _artist;
        private Genre _genre;
        private double _durationMinutes;
        private int _rating;

        public Song(string title, Artist artist, Genre genre, double durationMinutes, int rating)
        {
            this.Title = title;
            this.Artist = artist;
            this.Genre = genre;
            this.DurationMinutes = durationMinutes;
            this.Rating = rating;
        }

        public Artist Artist { get; set; }

        public string Title
        {
            get => this._title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Song title cannot be empty.");
                }

                this._title = value;
            }
        }

        public Genre Genre
        {
            get => _genre;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _genre = value;
            }
        }

        public int Rating
        {
            get => _rating;
            set
            {
                if (value < 0 || value > 5)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Rating must be in range 0..5.");
                }

                _rating = value;
            }
        }

        public double DurationMinutes
        {
            get => this._durationMinutes;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Duration must be > 0");
                }

                this._durationMinutes = value;
            }
        }
    }
}
