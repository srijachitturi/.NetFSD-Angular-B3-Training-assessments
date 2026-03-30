using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class ContactInfo
    {
        [Required]
        public int ContactId { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailId { get; set; }

        [Required]
        public long? MobileNo { get; set; }

        [Required]
        public string Designation { get; set; }
    }
}