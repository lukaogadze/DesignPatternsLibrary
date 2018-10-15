using System;
using System.Linq.Expressions;
using Web.Interfaces;

namespace Web.Models.Specs
{
    public class SongArtistSpecification : ISpecification<Song>
    {
        public string Artist { get; set; }

        public SongArtistSpecification(string artist)
        {
            Artist = artist;
        }

        public Expression<Func<Song, bool>> Criteria
        {
            get { return s => s.Artist.ToLower() == Artist.ToLower(); }
        }
    }
}