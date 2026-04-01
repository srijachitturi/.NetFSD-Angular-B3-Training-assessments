using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class ContactInfo
    {
        [Required(ErrorMessage = "Contact Id is required")]
        [Range(1, 9999, ErrorMessage = "Contact Id must be greater than 0")]
        public int ContactId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Email Id is required")]
        [EmailAddress(ErrorMessage = "Enter valid Email Id")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Mobile No is required")]
        [Range(1000000000, 9999999999, ErrorMessage = "Mobile No must be 10 digits")]
        public long MobileNo { get; set; }

        [Required(ErrorMessage = "Designation is required")]
        public string Designation { get; set; }
    }
}