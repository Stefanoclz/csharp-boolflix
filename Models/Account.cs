using System.ComponentModel.DataAnnotations;

namespace csharp_boolflix.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Surname { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string? Password { get; set; }

        public string? SubsName { get; set; }
        public int? SubscriptionId { get; set; }
        public Subscription? Sub { get; set; }

        public int? PaymentId { get; set; }
        public Payment? Payment { get; set; }

        public List<Profile>? ProfilesList { get; set; }

        public Account()
        {

        }

        public void SetPW(string pw)
        {
            this.Password = pw;
        }

        public string GetPW()
        {
            string pw = this.Password;
            return pw;
        }
    }
}
