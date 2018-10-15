using System;
using System.Linq.Expressions;
using System.Web.WebPages;
using Web.Interfaces;

namespace Web.Models.Specs
{
    public class AllSongsSpecification : ISpecification<Song>
    {
        public Expression<Func<Song, bool>> Criteria { get; } = s => true;
    }
}