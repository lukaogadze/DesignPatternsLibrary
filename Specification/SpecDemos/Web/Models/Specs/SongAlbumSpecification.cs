using System;
using System.Linq.Expressions;
using Web.Interfaces;

namespace Web.Models.Specs
{
    public class SongAlbumSpecification : ISpecification<Song>
    {
        public int AlbumId { get; set; }

        public SongAlbumSpecification(int albumId)
        {
            AlbumId = albumId;
        }

        public Expression<Func<Song, bool>> Criteria
        {
            get { return s => s.AlbumId == AlbumId; }
        }
    }
}