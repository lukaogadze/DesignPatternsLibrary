using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web.Infrastructure;
using Web.Interfaces;
using Web.Models;
using Web.Models.Specs;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly ISongRepository _songRepository;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _songRepository = new SongRepository(_dbContext);
        }

        public HomeController() : this(new AppDbContext())
        {
        }

        public ActionResult Index(List<int> selectedGenres = null, 
            List<string> selectedArtists = null, 
            string titleSearch = null,
            int minRating = 0,
            string filter = null,
            string save = null,
            string playlistName = null)
        {
            if (selectedArtists == null) { selectedArtists = new List<string>(); }
            if (selectedGenres == null) { selectedGenres = new List<int>(); }

            var spec = new GlobalSongSpecification();
            spec.ArtistsToInclude.AddRange(selectedArtists);
            spec.GenreIdsToInclude.AddRange(selectedGenres);
            spec.MinRating = minRating;
            spec.TitleFilter = titleSearch;

            var songs = _songRepository.List(spec);

            var viewModel = new HomeViewModel();
            viewModel.Artists = _songRepository.AllArtists().ToList();
            viewModel.Genres = _songRepository.AllGenres().ToList();
            viewModel.SelectedArtists = viewModel.Artists
                .Where(a => spec.ArtistsToInclude.Contains(a))
                .ToList();
            viewModel.SelectedGenres = viewModel.Genres
                .Where(g => selectedGenres.Contains(g.Id))
                .ToList();
            viewModel.Songs = songs.ToList();

            if (save != null)
            {
                var smartPlaylist = new SmartPlaylist();
                smartPlaylist.Name = playlistName;
                smartPlaylist.Specification = spec;
                var playlistRepo = new SmartPlaylistRepository(_dbContext);
                playlistRepo.Add(smartPlaylist);
                return RedirectToAction("Index", "SmartPlaylists");
            }

            return View(viewModel);
        }

        public ActionResult ResetDatabase()
        {
            _dbContext.Database.Initialize(force: true);
            return View();
        }
    }
}