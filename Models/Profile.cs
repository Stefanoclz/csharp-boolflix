using System.ComponentModel.DataAnnotations;

namespace csharp_boolflix.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsChild { get; set; }
        public List<VideoContent> PreferredList { get; set; }

        public int PlayedHistoryId { get; set; }
        public PlayedHistory HistoryList { get; set; }

        public Playlist Playlist { get; set; }

    }
}
