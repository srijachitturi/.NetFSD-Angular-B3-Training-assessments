using WebApplication4.Models;

namespace WebApplication4.Services
{
    public interface IContactService
    {
        List<ContactInfo> GetAllContacts();
        ContactInfo GetContactById(int id);
        void AddContact(ContactInfo contact);
    }
}