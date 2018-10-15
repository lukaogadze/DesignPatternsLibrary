using System;
using System.Linq.Expressions;
using Web.Interfaces;

namespace Web.Models.Specs
{
    public class SongTitleSpecification : ISpecification<Song>
    {
        public string SearchString { get; set; }

        public SongTitleSpecification(string searchString)
        {
            SearchString = searchString;
        }

        public Expression<Func<Song, bool>> Criteria
        {
            get { return s => s.Title.Contains(SearchString); }
        }
    }
}