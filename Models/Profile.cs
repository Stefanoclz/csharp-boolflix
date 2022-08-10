using System.ComponentModel.DataAnnotations;

namespace csharp_boolflix.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsChild { get; set; }

        public int AccountId { get; set; }
        public Account? Account { get; set; }

        public List<VideoContent>? VideoContents { get; set; }

        public int? PlaylistId { get; set; }
        public Playlist? Playlist { get; set; }

        public Profile()
        {

        }

    }
}
