using System.ComponentModel.DataAnnotations;

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
        public List<Genre>? GenresList { get; set; }

        public List<Profile>? Profiles { get; set; }

        public List<Playlist>? PlaylistsList { get; set; }
    }
}
