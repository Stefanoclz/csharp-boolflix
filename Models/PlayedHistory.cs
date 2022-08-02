using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace csharp_boolflix.Models
{
    public class PlayedHistory
    {
        [Key]
        public int Id { get; set; }
        public List<VideoContent> VideoContents { get; set; }

        public Profile Profile { get; set; }

    }
}
