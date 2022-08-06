using csharp_boolflix.DataBase;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace csharp_boolflix.Models
{
    public class Playlist
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<VideoContent> VideoContents { get; set; }

        public Profile? Profile { get; set; }

        public Playlist()
        {

        }

        public Playlist PlaylistGenre(Genre genre)
        {
            using (BoolflixContext db = new BoolflixContext())
            {

                List<VideoContent> playlist = db.VideoContents.Include("GenresList").Where(v => v.GenresList.Contains(genre)).ToList();

                Playlist forGenre = new Playlist();
                forGenre.Name = genre.Name;
                forGenre.VideoContents = playlist;

                return forGenre;
            }
        }

    }
}
