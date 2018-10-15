using System;
using System.Collections.Generic;
using System.Linq;
using Web.Interfaces;
using Web.Models;

namespace Web.Infrastructure
{
    public class SongRepository : ISongRepository
    {
        private readonly AppDbContext _dbContext;

        public SongRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Song> List(ISpecification<Song> specification)
        {
            return _dbContext.Songs
                .Include("Genres")
                .Include("Album")
                .Where(specification.Criteria)
                .AsEnumerable();
        }

        //public IQueryable<Song> List()
        //{
        //    return _dbContext.Songs
        //        .Include("Genres")
        //        .Include("Album")
        //        .AsQueryable();
        //}

        public Song GetById(int id)
        {
            return _dbContext.Songs.Find(id);
        }

        public void Add(Song song)
        {
            _dbContext.Songs.Add(song);
            _dbContext.SaveChanges();
        }

        // Take a predicate - may or may not work with EF
        // Tends to bleed query logic into clients
        public IEnumerable<Song> List(Func<Song, bool> predicate)
        {
            return _dbContext.Songs.Where(predicate);
        }

        // More Query Methods
        public IEnumerable<Song> ListForAlbumId(int albumId)
        {
            return _dbContext.Songs.Where(s => s.AlbumId == albumId);
        }

        public IEnumerable<Song> ListForArtist(string artistName)
        {
            return _dbContext.Songs.Where(s => s.Artist == artistName);
        }

        public IEnumerable<Song> ListForYear(int year)
        {
            return _dbContext.Songs.Where(s => s.Year == year);
        }

        public IEnumerable<string> AllArtists()
        {
            return _dbContext.Songs.Select(s => s.Artist).Distinct();
        }

        public IEnumerable<Genre> AllGenres()
        {
            return _dbContext.Genres;
        } 
    }
}