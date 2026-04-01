using WebApplication4.Models;

namespace WebApplication4.Services
{
    public class ContactService : IContactService
    {
        private static List<ContactInfo> contacts = new List<ContactInfo>
        {
            new ContactInfo
            {
                ContactId = 1,
                FirstName = "Rahul",
                LastName = "Sharma",
                CompanyName = "ABC Infotech",
                EmailId = "rahul@gmail.com",
                MobileNo = 9876543210,
                Designation = "Developer"
            },
            new ContactInfo
            {
                ContactId = 2,
                FirstName = "Neha",
                LastName = "Reddy",
                CompanyName = "XYZ Solutions",
                EmailId = "neha@gmail.com",
                MobileNo = 9123456780,
                Designation = "Tester"
            }
        };

        public List<ContactInfo> GetAllContacts()
        {
            return contacts;
        }

        public ContactInfo GetContactById(int id)
        {
            return contacts.FirstOrDefault(c => c.ContactId == id);
        }

        public void AddContact(ContactInfo contact)
        {
            contacts.Add(contact);
        }
    }
}
