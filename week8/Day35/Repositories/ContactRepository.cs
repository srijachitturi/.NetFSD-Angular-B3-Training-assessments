using Dapper;
using WebApplication6.Models;

namespace WebApplication6.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DapperContext _context;

        public ContactRepository(DapperContext context)
        {
            _context = context;
        }

        public List<ContactInfo> GetAllContacts()
        {
            using var connection = _context.CreateConnection();

            string sql = @"
                SELECT 
                    c.ContactId,
                    c.FirstName,
                    c.LastName,
                    c.EmailId,
                    c.MobileNo,
                    c.Designation,
                    c.CompanyId,
                    c.DepartmentId,
                    co.CompanyName,
                    d.DepartmentName
                FROM ContactInfo c
                INNER JOIN Company co ON c.CompanyId = co.CompanyId
                LEFT JOIN Department d ON c.DepartmentId = d.DepartmentId
                ORDER BY c.ContactId";

            return connection.Query<ContactInfo>(sql).ToList();
        }

        public ContactInfo? GetContactById(int id)
        {
            using var connection = _context.CreateConnection();

            string sql = @"
                SELECT 
                    c.ContactId,
                    c.FirstName,
                    c.LastName,
                    c.EmailId,
                    c.MobileNo,
                    c.Designation,
                    c.CompanyId,
                    c.DepartmentId,
                    co.CompanyName,
                    d.DepartmentName
                FROM ContactInfo c
                INNER JOIN Company co ON c.CompanyId = co.CompanyId
                LEFT JOIN Department d ON c.DepartmentId = d.DepartmentId
                WHERE c.ContactId = @Id";

            return connection.QueryFirstOrDefault<ContactInfo>(sql, new { Id = id });
        }

        public void AddContact(ContactInfo contact)
        {
            using var connection = _context.CreateConnection();

            string sql = @"
                INSERT INTO ContactInfo
                (FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
                VALUES
                (@FirstName, @LastName, @EmailId, @MobileNo, @Designation, @CompanyId, @DepartmentId)";

            connection.Execute(sql, contact);
        }

        public void UpdateContact(ContactInfo contact)
        {
            using var connection = _context.CreateConnection();

            string sql = @"
        UPDATE ContactInfo
        SET FirstName = @FirstName,
            LastName = @LastName,
            EmailId = @EmailId,
            MobileNo = @MobileNo,
            Designation = @Designation,
            CompanyId = @CompanyId,
            DepartmentId = @DepartmentId
        WHERE ContactId = @ContactId";

            connection.Execute(sql, contact);
        }

        public void DeleteContact(int id)
        {
            using var connection = _context.CreateConnection();

            string sql = "DELETE FROM ContactInfo WHERE ContactId = @Id";
            connection.Execute(sql, new { Id = id });
        }

        public List<Company> GetAllCompanies()
        {
            using var connection = _context.CreateConnection();
            return connection.Query<Company>(
                "SELECT CompanyId, CompanyName FROM Company ORDER BY CompanyName").ToList();
        }

        public List<Department> GetAllDepartments()
        {
            using var connection = _context.CreateConnection();
            return connection.Query<Department>(
                "SELECT DepartmentId, DepartmentName FROM Department ORDER BY DepartmentName").ToList();
        }
    }
}