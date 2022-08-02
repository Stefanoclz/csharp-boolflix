using System.ComponentModel.DataAnnotations;

namespace csharp_boolflix.Models
{
    public class Playlist
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<VideoContent> VideoContents { get; set; }

        public Profile Profile { get; set; }

    }
}
