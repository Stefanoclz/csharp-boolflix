using System.ComponentModel.DataAnnotations;

namespace csharp_boolflix.Models
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int? MaxProfilesNumber { get; set; }

        public string? VideoQuality { get; set; }

        public string? Resolution { get; set; }

        [Range(2, 2)]
        public decimal? Price { get; set; }
        public Subscription()
        {

        }


    }
}