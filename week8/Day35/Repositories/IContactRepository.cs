using WebApplication6.Models;

namespace WebApplication6.Repositories
{
    public interface IContactRepository
    {
        List<ContactInfo> GetAllContacts();
        ContactInfo? GetContactById(int id);
        void AddContact(ContactInfo contact);
        void UpdateContact(ContactInfo contact);
        void DeleteContact(int id);

        List<Company> GetAllCompanies();
        List<Department> GetAllDepartments();
    }
}
