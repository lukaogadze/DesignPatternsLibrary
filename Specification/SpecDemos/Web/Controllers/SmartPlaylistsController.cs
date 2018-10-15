using System.Linq;
using System.Web.Mvc;
using Web.Infrastructure;
using Web.Interfaces;
using Web.Models;
using Web.Models.Specs;

namespace Web.Controllers
{
    public class SmartPlaylistsController : Controller
    {
        private readonly SmartPlaylistRepository _smartPlaylistRepository;

        public SmartPlaylistsController(SmartPlaylistRepository smartPlaylistRepository)
        {
            _smartPlaylistRepository = smartPlaylistRepository;
        }

        public SmartPlaylistsController() : this(new SmartPlaylistRepository(new AppDbContext()))
        {
        }

        public ActionResult Index()
        {
            return View(_smartPlaylistRepository.List());
        }
    }
}