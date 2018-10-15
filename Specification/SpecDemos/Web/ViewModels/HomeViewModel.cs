using System.Collections.Generic;
using System.Linq;
using Web.Models;

namespace Web.ViewModels
{
    public class HomeViewModel
    {
        public List<string> Artists { get; set; }
        public List<Genre> Genres { get; set; }
        public List<string> SelectedArtists { get; set; }
        public List<Genre> SelectedGenres { get; set; }
        public List<Song> Songs { get; set; }

        public IEnumerable<int> Ratings
        {
            get
            {
                return new[] {1, 2, 3, 4, 5};
            }
        } 
    }
}