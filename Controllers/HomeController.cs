using csharp_boolflix.DataBase;
using csharp_boolflix.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace csharp_boolflix.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            using(BoolflixContext db = new BoolflixContext())
            {
                List<VideoContent> list = db.VideoContents.ToList();
                int max = list.Count;

                List<Genre> genres = db.Genres.ToList();

                List<Playlist> PlaylistsList = new List<Playlist>();

                foreach (Genre gen in genres)
                {
                    Playlist playlist = new Playlist();

                    PlaylistsList.Add(playlist.PlaylistGenre(gen));
                }


                ViewData["Playlists"] = PlaylistsList;
                
                return View(list);
            }
            
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}