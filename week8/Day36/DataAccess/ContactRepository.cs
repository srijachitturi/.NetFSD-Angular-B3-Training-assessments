using WebApplication7.Models;

namespace WebApplication7.DataAccess
{
    public class ContactRepository : IContactRepository
    {
        // Mandatory static list as per requirement
        public static List<ContactInfo> contacts = new List<ContactInfo>()
        {
            new ContactInfo
            {
                ContactId = 1,
                FirstName = "Srija",
                LastName = "Chowdary",
                EmailId = "srija@gmail.com",
                MobileNo = 9876543210,
                Designation = "Developer",
                CompanyId = 101,
                DepartmentId = 201
            },
            new ContactInfo
            {
                ContactId = 2,
                FirstName = "Rahul",
                LastName = "Kumar",
                EmailId = "rahul@gmail.com",
                MobileNo = 9876501234,
                Designation = "Tester",
                CompanyId = 102,
                DepartmentId = 202
            }
        };

        public async Task<List<ContactInfo>> GetAllContactsAsync()
        {
            return await Task.FromResult(contacts);
        }

        public async Task<ContactInfo?> GetContactByIdAsync(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            return await Task.FromResult(contact);
        }

        public async Task<ContactInfo> AddContactAsync(ContactInfo contact)
        {
            int newId = 1;

            if (contacts.Count > 0)
            {
                newId = contacts.Max(c => c.ContactId) + 1;
            }

            contact.ContactId = newId;
            contacts.Add(contact);

            return await Task.FromResult(contact);
        }

        public async Task<ContactInfo?> UpdateContactAsync(int id, ContactInfo contact)
        {
            var existingContact = contacts.FirstOrDefault(c => c.ContactId == id);

            if (existingContact == null)
            {
                return await Task.FromResult<ContactInfo?>(null);
            }

            existingContact.FirstName = contact.FirstName;
            existingContact.LastName = contact.LastName;
            existingContact.EmailId = contact.EmailId;
            existingContact.MobileNo = contact.MobileNo;
            existingContact.Designation = contact.Designation;
            existingContact.CompanyId = contact.CompanyId;
            existingContact.DepartmentId = contact.DepartmentId;

            return await Task.FromResult(existingContact);
        }

        public async Task<ContactInfo?> DeleteContactAsync(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);

            if (contact == null)
            {
                return await Task.FromResult<ContactInfo?>(null);
            }

            contacts.Remove(contact);
            return await Task.FromResult(contact);
        }
    }
}
