using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Web.Models
{
    public class SampleData
    {
        private readonly Random _random = new Random();

        public SampleData()
        {
            PopulateAlbums();
            PopulateGenres();
            PopulateSongs();
        }
        public List<Album> Albums { get; private set; } = new List<Album>();
        public List<Genre> Genres { get; private set; } = new List<Genre>();
        public List<Song> Songs { get; private set; } = new List<Song>();
        private void PopulateAlbums()
        {
            Albums = new List<Album>
            {
                new Album {Artist = "311", Title = "Greatest Hits '93-'03", Year = 2004},
                new Album {Artist = "A Perfect Circle", Title = "10,000 Days", Year = 2006},
                new Album {Artist = "Daft Punk", Title = "Tron Legacy", Year = 2010},
                new Album {Artist = "Deadmau5", Title = "4x4=12", Year = 2011},
                new Album {Artist = "Franklin Brothers", Title = "Lifeboat To Nowhere", Year = 2011},
                new Album {Artist = "Metallica", Title = "...And Justice for All", Year = 1990},
                new Album {Artist = "Modest Mouse", Title = "Good News For People Who Love Bad News", Year = 2004},
                new Album {Artist = "Rage Against the Machine", Title = "Rage Against the Machine", Year = 1992},
                new Album {Artist = "Rage Against the Machine", Title = "Evil Empire", Year = 1996},
                new Album {Artist = "Tool", Title = "10,000 Days", Year = 2006}
            };
        }

        private void PopulateGenres()
        {
            Genres = new List<Genre>
            {
                new Genre {Name = "Alternative"},
                new Genre {Name = "Alt Rock"},
                new Genre {Name = "Jazz"},
                new Genre {Name = "Metal"},
                new Genre {Name = "Progressive"},
                new Genre {Name = "Rap"},
                new Genre {Name = "Rock"},
                new Genre {Name = "Techno"}
            };
        }

        private void PopulateSongs()
        {
            
            Songs.Add(new Song { Artist = "311", AlbumId = 1, Title = "Amber", Year = 2004, Rating = 5, Length = RandomSongLength() });
            Songs.Add(new Song { Artist = "A Perfect Circle", AlbumId = 2, Title = "The Noose", Year = 2003, Rating = 5, Length = RandomSongLength() });
            Songs.Add(new Song { Artist = "A Perfect Circle", AlbumId = 2, Title = "Blue", Year = 2003, Rating = 4, Length = RandomSongLength() });
            Songs.Add(new Song { Artist = "A Perfect Circle", AlbumId = 2, Title = "Pet", Year = 2003, Rating = 3, Length = RandomSongLength() });
            Songs.Add(new Song { Artist = "Daft Punk", AlbumId = 3, Title = "The Game Has Changed", Year = 2010, Rating = 4, Length = RandomSongLength() });
            Songs.Add(new Song { Artist = "Daft Punk", AlbumId = 3, Title = "End Of Line", Year = 2010, Rating = 3, Length = RandomSongLength() });
            Songs.Add(new Song { Artist = "Daft Punk", AlbumId = 3, Title = "C.L.U", Year = 2010, Rating = 3, Length = RandomSongLength() });
            Songs.Add(new Song { Artist = "Daft Punk", AlbumId = 3, Title = "Tron Legacy (End Titles)", Year = 2010, Rating = 4, Length = RandomSongLength() });
            Songs.Add(new Song { Artist = "Deadmau5", AlbumId = 4, Title = "Some Chords", Year = 2013, Rating = 5, Length = RandomSongLength() });
            Songs.Add(new Song { Artist = "Franklin Brothers", AlbumId = 5, Title = "She Won", Year = 2011, Rating = 4, Length = RandomSongLength() });
            Songs.Add(new Song { Artist = "Metallica", AlbumId = 6, Title = "Blackened", Year = 1990, Rating = 4, Length = RandomSongLength() });
            Songs.Add(new Song { Artist = "Metallica", AlbumId = 6, Title = "...And Justice for All", Year = 1990, Rating = 5, Length = RandomSongLength() });
            Songs.Add(new Song { Artist = "Metallica", AlbumId = 6, Title = "One", Year = 1990, Rating = 5, Length = RandomSongLength() });
            Songs.Add(new Song { Artist = "Modest Mouse", AlbumId = 7, Title = "One", Year = 1990, Rating = 5, Length = RandomSongLength() });
            Songs.Add(new Song { Artist = "Rage Against the Machine", AlbumId = 8, Title = "Killing in the Name", Year = 1992, Rating = 4, Length = RandomSongLength() });
            Songs.Add(new Song { Artist = "Rage Against the Machine", AlbumId = 9, Title = "Bulls on Parade", Year = 1996, Rating = 5, Length = RandomSongLength() });
            Songs.Add(new Song { Artist = "Tool", AlbumId = 10, Title = "The Pot", Year = 2006, Rating = 5, Length = RandomSongLength() });
            Songs.Add(new Song { Artist = "Tool", AlbumId = 10, Title = "Rosetta Stoned", Year = 2006, Rating = 5, Length = RandomSongLength() });
            Songs.Add(new Song { Artist = "Tool", AlbumId = 10, Title = "Wings for Marie (Pt 1)", Year = 2006, Rating = 4, Length = RandomSongLength() });
            Songs.Add(new Song { Artist = "Tool", AlbumId = 10, Title = "10,000 Days (Wings Pt 2)", Year = 2006, Rating = 5, Length = RandomSongLength() });

            // Add Genres to Songs
            var alternativeGenre = Genres.FirstOrDefault(g => g.Name == "Alternative");
            var altRockGenre = Genres.FirstOrDefault(g => g.Name == "Alt Rock");
            var jazzGenre = Genres.FirstOrDefault(g => g.Name == "Jazz");
            var metalGenre = Genres.FirstOrDefault(g => g.Name == "Metal");
            var progressiveGenre = Genres.FirstOrDefault(g => g.Name == "Progressive");
            var rapGenre = Genres.FirstOrDefault(g => g.Name == "Rap");
            var rockGenre = Genres.FirstOrDefault(g => g.Name == "Rock");
            var technoGenre = Genres.FirstOrDefault(g => g.Name == "Techno");

            Songs
                .Where(s => s.Artist == "311").ToList()
                .ForEach(s => s.Genres.Add(alternativeGenre));

            Songs
                .Where(s => s.Artist == "A Perfect Circle").ToList()
                .ForEach(s => s.Genres.Add(progressiveGenre));

            Songs
                .Where(s => s.Artist == "Daft Punk" || s.Artist == "DeadMau5").ToList()
                .ForEach(s => s.Genres.Add(technoGenre));

            Songs
                .Where(s => s.Artist == "Franklin Brothers").ToList()
                .ForEach(s => s.Genres.Add(jazzGenre));

            Songs
                .Where(s => s.Artist == "Metallica").ToList()
                .ForEach(s => s.Genres.Add(metalGenre));

            Songs
                .Where(s => s.Artist == "Modest Mouse").ToList()
                .ForEach(s => s.Genres.Add(altRockGenre));

            Songs
                .Where(s => s.Artist == "Rage Against the Machine").ToList()
                .ForEach(s =>
                {
                    s.Genres.Add(metalGenre);
                    s.Genres.Add(rapGenre);
                });

            Songs
                .Where(s => s.Artist == "Tool").ToList()
                .ForEach(s =>
                {
                    s.Genres.Add(metalGenre);
                    s.Genres.Add(progressiveGenre);
                });
        }

        private TimeSpan RandomSongLength()
        {
            int minutes = _random.Next(7) + 1;
            int seconds = _random.Next(60);

            return new TimeSpan(0, 0, minutes, seconds);
        }

    }
}
