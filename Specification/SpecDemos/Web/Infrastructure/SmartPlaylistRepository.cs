using System.Collections.Generic;
using System.Linq;
using Antlr.Runtime.Misc;
using Web.Models;

namespace Web.Infrastructure
{
    public class SmartPlaylistRepository
    {
        private readonly AppDbContext _dbContext;

        public SmartPlaylistRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public SmartPlaylist GetByName(string name)
        {
            return _dbContext.SmartPlaylists.FirstOrDefault(s => s.Name.ToLower() == name.ToLower());
        }

        public void Add(SmartPlaylist playlist)
        {
            _dbContext.SmartPlaylists.Add(playlist);
            _dbContext.SaveChanges();
        }

        public IEnumerable<SmartPlaylist> List()
        {
            return _dbContext.SmartPlaylists.AsEnumerable();
        }


    }
}