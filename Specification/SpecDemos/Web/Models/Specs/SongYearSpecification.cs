using System;
using System.Linq.Expressions;
using Web.Interfaces;

namespace Web.Models.Specs
{
    public class SongYearSpecification : ISpecification<Song>
    {
        public int Year { get; set; }

        public SongYearSpecification(int year)
        {
            Year = year;
        }

        public Expression<Func<Song, bool>> Criteria
        {
            get { return s => s.Year == Year; }
        }
    }
}