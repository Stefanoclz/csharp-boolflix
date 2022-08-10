using System.ComponentModel.DataAnnotations;

namespace csharp_boolflix.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string? CardName { get; set; }
        public string? CardSurname { get; set; }
        public string? CardNumber { get; set; }
        public string? GiftCode { get; set; }
        public string? PaypalName { get; set; }
        public string? PaypalPW { get; set; }


        public Payment()
        {

        }
    }
}