using System.Linq;
using System.Web.Mvc;
using Web.Infrastructure;
using Web.Interfaces;
using Web.Models;
using Web.Models.Specs;

namespace Web.Controllers
{
    public class SongsController : Controller
    {
        private readonly ISongRepository _songRepository;

        public SongsController(ISongRepository songRepository)
        {
            _songRepository = songRepository;
        }

        public SongsController() : this(new SongRepository(new AppDbContext()))
        {
        }

        public ActionResult Index()
        {
            return View(_songRepository.List(new AllSongsSpecification()));
        }
        public ActionResult ByArtist(string artist)
        {
            ViewBag.Artist = artist;
            
            return View(_songRepository.List(new SongArtistSpecification(artist)));
        }
        public ActionResult ByAlbum(int albumId)
        {
            var songs = _songRepository.List(new SongAlbumSpecification(albumId));
            if (songs.Any())
            {
                ViewBag.Album = songs.FirstOrDefault().Album.Title;
            }
            return View(songs);
        }
        public ActionResult ByYear(int year)
        {
            ViewBag.Year = year;
            return View(_songRepository.List(new SongYearSpecification(year)));
        }
        public ActionResult MinRating(int rating)
        {
            ViewBag.MinRating = rating;
            return View(_songRepository.List(new SongRatingSpecification(rating)));
        }

        public ActionResult RecentFavorites()
        {
            return View(_songRepository.List(new AllSongsSpecification()).Where(s => s.IsRecentFavorite()));
        }

        public ActionResult ByPlaylist(string playlistName)
        {
            // TODO: Use DI
            var playlistRepo = new SmartPlaylistRepository(new AppDbContext());

            var playlist = playlistRepo.GetByName(playlistName);
            if (playlist == null)
            {
                return HttpNotFound("Playlist not found.");
            }
            ViewBag.PlaylistName = playlist.Name;
            return View(_songRepository.List(playlist.Specification));

        }
    }
}