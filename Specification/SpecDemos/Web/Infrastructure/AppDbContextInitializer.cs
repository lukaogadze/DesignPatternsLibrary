using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using Web.Models;
using Web.Models.Specs;
using WebGrease.Configuration;
using WebGrease.Css.Extensions;

namespace Web.Infrastructure
{
    public class AppDbContextInitializer : DropCreateDatabaseAlways<AppDbContext>
    {
        private readonly Random _random = new Random();
        protected override void Seed(AppDbContext dbContext)
        {
            var sampleData = new SampleData();
            dbContext.Albums.AddRange(sampleData.Albums);
            dbContext.SaveChanges();

            dbContext.Genres.AddRange(sampleData.Genres);
            dbContext.SaveChanges();

            dbContext.Songs.AddRange(sampleData.Songs);
            dbContext.SaveChanges();

            var playlist = new SmartPlaylist
            {
                Specification = new GlobalSongSpecification()
                {
                    MinRating = 2,
                    ArtistsToInclude = {"Tool"}
                },
                Name="CoolTool"
            };
            dbContext.SmartPlaylists.Add(playlist);

            dbContext.SaveChanges();

            base.Seed(dbContext);
        }

        private TimeSpan RandomSongLength()
        {
            int minutes = _random.Next(7) + 1;
            int seconds = _random.Next(60);

            return new TimeSpan(0, 0, minutes, seconds);
        }
    }
}