using System.Collections.Generic;

namespace Web.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Song> Songs { get; set; }

        public Genre()
        {
            Songs = new List<Song>();
        }
    }
}