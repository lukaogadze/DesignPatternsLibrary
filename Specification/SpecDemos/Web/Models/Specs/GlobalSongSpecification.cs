using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Newtonsoft.Json;
using Web.Interfaces;

namespace Web.Models.Specs
{
    public class GlobalSongSpecification : ISpecification<Song>
    {
        public List<int> GenreIdsToInclude { get; set; } = new List<int>();
        public List<int> AlbumIdsToInclude { get; set; } = new List<int>();
        public List<string> ArtistsToInclude { get; set; } = new List<string>();
        public string TitleFilter { get; set; }
        public int MinRating { get; set; }

        [JsonIgnore]
        public Expression<Func<Song, bool>> Criteria
        {
            get
            {
                return s =>
                    (!GenreIdsToInclude.Any() || s.Genres.Any(g => GenreIdsToInclude.Any(gId => gId == g.Id))) &&
                    (!AlbumIdsToInclude.Any() || AlbumIdsToInclude.Contains(s.AlbumId)) &&
                    (!ArtistsToInclude.Any() ||ArtistsToInclude.Contains(s.Artist)) &&
                    (String.IsNullOrEmpty(this.TitleFilter) || s.Title.Contains(TitleFilter)) &&
                    s.Rating >= MinRating;
            }
        }
    }
}