using csharp_boolflix.DataBase;
using csharp_boolflix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Index(int id)
        {
            using(BoolflixContext db = new BoolflixContext())
            {
                Profile find = db.Profiles.Where(p => p.Id == id).Include("Playlist").FirstOrDefault();

                List<VideoContent> list = db.VideoContents.ToList();

                List<Genre> genres = db.Genres.ToList();

                List<Playlist> PlaylistsList = new List<Playlist>();

                Playlist personal = db.Playlists.Where(pl => pl.Id == find.PlaylistId).Include("VideoContents").FirstOrDefault();
                PlaylistsList.Add(personal);

                foreach (Genre gen in genres)
                {
                    Playlist playlist = new Playlist();

                    PlaylistsList.Add(playlist.PlaylistGenre(gen));
                }

                Account master = db.Registered.Where(a => a.Id == find.AccountId).FirstOrDefault();

                ViewData["profile"] = find;
                ViewData["account"] = master;
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