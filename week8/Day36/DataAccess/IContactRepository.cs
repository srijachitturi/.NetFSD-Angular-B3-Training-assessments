using WebApplication7.Models;

namespace WebApplication7.DataAccess
{
    public interface IContactRepository
    {
        Task<List<ContactInfo>> GetAllContactsAsync();
        Task<ContactInfo?> GetContactByIdAsync(int id);
        Task<ContactInfo> AddContactAsync(ContactInfo contact);
        Task<ContactInfo?> UpdateContactAsync(int id, ContactInfo contact);
        Task<ContactInfo?> DeleteContactAsync(int id);
    }
}