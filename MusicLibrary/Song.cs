namespace MusicLibrary
{
    // Этот клас я переписала в большей степени, так как объявление атрибутов класса не совпадает с инициализацией объекта
    // поэтому я добавила пару полей и так же изменила некоторые другие классы
    public class Song
    {
        // TODO: Define a private fields
        private string _title;
        private Artist _artist;
        private Genre _genre;
        private double _durationMinutes;

        public Song(string title, Artist artist, Genre genre, double durationMinutes)
        {
            this.Title = title;
            this.Artist = artist;
            this.Genre = genre;
            this.DurationMinutes = durationMinutes;
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
            get => this._genre;
            set => this._genre = value;
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
        // TODO: Implement a property to get and set the song's title with validation
        // TODO: Implement a property to get and set the song's duration with validation
        // TODO: Implement a property to get and set the song's performer with validation
        // TODO: Add the ToString method to return the song's title, duration, and performer as a string song representation
    }
}
