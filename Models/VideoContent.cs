using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace csharp_boolflix.Models
{
    public abstract class VideoContent
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        [Url]
        public string CoverImage { get; set; }
        public int Duration { get; set; }
        public string Type { get; set; }
        [NotMapped]
        public List<string> ReferenceGenres { get; set; }
        public List<Genre>? GenresList { get; set; }
        [NotMapped]
        public List<SelectListItem>? Genres { get; set; }
        public List<Profile>? Profiles { get; set; }

        public List<Playlist>? PlaylistsList { get; set; }
    }
}
