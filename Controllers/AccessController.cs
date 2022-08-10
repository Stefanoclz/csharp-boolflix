using csharp_boolflix.DataBase;
using csharp_boolflix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace csharp_boolflix.Controllers
{
    public class AccessController : Controller
    {
        public IActionResult Entrance()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register(string email)
        {
            if (!ModelState.IsValid)
            {
                return View("Entrance");
            }
            Account newAccount = new Account();
            newAccount.Email = email;
            ViewData["email"] = newAccount;
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckLogin(string email, string password)
        {
            if (!ModelState.IsValid)
            {
                return View("Login");
            }
            using(BoolflixContext db = new BoolflixContext())
            {
                Account find = db.Registered.Where(a => a.Email == email).Where(a => a.Password == password).Include("Sub").Include("ProfilesList").FirstOrDefault();

                if(find != null)
                {
                    return View("Logged", find);
                }

                return View("Login");
            }
   
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register2(Account account, string pw)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", account);
            }
            account.SetPW(pw);

            BoolflixContext db = new BoolflixContext();
            List<Subscription> subs = db.Subscriptions.ToList();

            ViewData["subslist"] = subs;
            ViewData["account"] = account;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register3(Account account)
        {
            if (!ModelState.IsValid)
            {
                return View("Register2", account);
            }

            BoolflixContext db = new BoolflixContext();
            Subscription find = db.Subscriptions.Where(s => s.Name == account.SubsName).FirstOrDefault();
            if(find != null)
            {
                account.SubscriptionId = find.Id;
                account.Sub = find;
            }
            
            //ViewData["account"] = account;

            return View(account);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Pay(Account account, string payName)
        {
            if (!ModelState.IsValid)
            {
                return View("Register3", account);
            }

            BoolflixContext db = new BoolflixContext();
            
            Payment newPay = new Payment();

            newPay.Name = payName;
            account.Payment = newPay;


            if (account.Payment.Name.Contains("Credit"))
            {
                return View("CreditPay", account);
            }
            else if (account.Payment.Name.Contains("PayPal"))
            {
                return View("Paypal", account);
            }
            else if (account.Payment.Name.Contains("Gift"))
            {
                return View("Gift", account);
            }
            else
            {
                return View("Register3", account);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckPay(Account account)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Pay", account);
            }

            BoolflixContext db = new BoolflixContext();

            Subscription sub = db.Subscriptions.Where(s => s.Id == account.SubscriptionId).FirstOrDefault();

            account.Sub = sub;

            db.Registered.Add(account);
            db.PaymentMethods.Add(account.Payment);
            db.SaveChanges();

            return View("ProfilesCreate", account);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Definition(Profile main)
        {
            using (BoolflixContext db = new BoolflixContext())
            {
                Account find = db.Registered.Where(p => p.Id == main.AccountId).FirstOrDefault();
                if (!ModelState.IsValid)
                {
                    return View("ProfilesCreate");
                }

                main.Account = find;
                main.AccountId = find.Id;

                List<VideoContent> filmList = db.VideoContents.ToList();
                //List<SelectListItem> list = new List<SelectListItem>();
                //foreach (VideoContent film in filmList)
                //{
                //    list.Add(new SelectListItem { Text = film.Title, Value = film.Id.ToString() });
                //}
                ViewData["films"] = filmList;

                return View("FilmsList", main);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Playlist(Profile profile, List<VideoBool> videos)
        {
            if (!ModelState.IsValid)
            {
                return View("FilmsList", profile);
            }

            using(BoolflixContext db = new BoolflixContext())
            {
                List<VideoContent> filmList = new List<VideoContent>();

                foreach(VideoBool vid in videos)
                {
                    if(vid.added == true)
                    {
                        VideoContent find = db.VideoContents.Where(v => v.Id == vid.videoId).Include("GenresList").FirstOrDefault();
                        if (find != null)
                        {
                            filmList.Add(find);
                        }
                    }                  
                }

                profile.VideoContents = filmList;

                Playlist PlaylistFavourite = new Playlist();
                
                PlaylistFavourite.Name = "La mia lista";
                PlaylistFavourite.VideoContents = new List<VideoContent>();
                foreach (VideoContent film in filmList)
                {
                    PlaylistFavourite.VideoContents.Add(film);
                    film.PlaylistsList = new List<Playlist>();
                    film.PlaylistsList.Add(PlaylistFavourite);

                    db.VideoContents.Update(film);
                }

                profile.Playlist = PlaylistFavourite;

                db.Add(profile);
                db.SaveChanges();

                return View("Completed", profile);
            }
            
        }
    }
}
