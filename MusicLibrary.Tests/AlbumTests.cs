using System;
using MusicLibrary;
using Xunit;

namespace MusicLibrary.Tests
{
    public class AlbumTests
    {
        private Artist CreateArtist()
        {
            return new Artist("Freddie Mercury", new DateTime(1946, 9, 5));
        }

        private Song CreateSong()
        {
            return new Song("Test Song", CreateArtist(), Genre.Rock, 3.5);
        }

        [Fact]
        public void AlbumCreationWorks()
        {
            var artist = CreateArtist();

            var album = new Album("Barcelona", artist, new DateTime(1988, 10, 10));

            Assert.Equal("Barcelona", album.Title);
            Assert.Equal(artist, album.Artist);
        }

     
        [Fact]
        public void AlbumThrowsWhenArtistIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new Album("Test", null, DateTime.Now));
        }

        
        [Fact]
        public void AlbumThrowsWhenTitleIsEmpty()
        {
            var artist = CreateArtist();

            Assert.Throws<ArgumentException>(() =>
                new Album("", artist, DateTime.Now));
        }

        
        [Fact]
        public void AddSongWorks()
        {
            var album = new Album("Test", CreateArtist(), DateTime.Now);
            var song = CreateSong();

            album.AddSong(song);

            Assert.Contains(song, album.GetSongs());
        }

        // 5. Удаление песни
        [Fact]
        public void RemoveSongWorks()
        {
            var album = new Album("Test", CreateArtist(), DateTime.Now);
            var song = CreateSong();

            album.AddSong(song);

            var result = album.RemoveSong(song);

            Assert.True(result);
            Assert.DoesNotContain(song, album.GetSongs());
        }

        // 6. Очистка
        [Fact]
        public void ClearSongsWorks()
        {
            var album = new Album("Test", CreateArtist(), DateTime.Now);

            album.AddSong(CreateSong());
            album.AddSong(CreateSong());

            album.ClearSongs();

            Assert.Empty(album.GetSongs());
        }

        // 7. ToString
        [Fact]
        public void ToStringReturnsCorrectFormat()
        {
            var artist = CreateArtist();
            var album = new Album("Barcelona", artist, new DateTime(1988, 10, 10));

            var result = album.ToString();

            Assert.Contains("Barcelona", result);
            Assert.Contains("Freddie Mercury", result);
        }
    }
}
