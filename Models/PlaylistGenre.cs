using csharp_boolflix.DataBase;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace csharp_boolflix.Models
{
    public class PlaylistGenre : Playlist
    {
        public PlaylistGenre(Genre genre)
        {
            using(BoolflixContext db = new BoolflixContext())
            {
                
                List<VideoContent> playlist = db.VideoContents.Include("GenresList").Where(v => v.GenresList.Contains(genre)).ToList();

            }
        }
    }
}
