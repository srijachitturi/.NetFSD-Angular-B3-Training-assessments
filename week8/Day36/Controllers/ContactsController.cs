using Microsoft.AspNetCore.Mvc;
using WebApplication7.DataAccess;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            var contacts = await _contactRepository.GetAllContactsAsync();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var contact = await _contactRepository.GetContactByIdAsync(id);

            if (contact == null)
            {
                return NotFound("Requested contact does not exist");
            }

            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(ContactInfo contact)
        {
            if (string.IsNullOrWhiteSpace(contact.FirstName) ||
                string.IsNullOrWhiteSpace(contact.LastName) ||
                string.IsNullOrWhiteSpace(contact.EmailId) ||
                string.IsNullOrWhiteSpace(contact.Designation))
            {
                return BadRequest("Required fields are missing");
            }

            var newContact = await _contactRepository.AddContactAsync(contact);

            return CreatedAtAction(
                nameof(GetContactById),
                new { id = newContact.ContactId },
                newContact
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, ContactInfo contact)
        {
            if (string.IsNullOrWhiteSpace(contact.FirstName) ||
                string.IsNullOrWhiteSpace(contact.LastName) ||
                string.IsNullOrWhiteSpace(contact.EmailId) ||
                string.IsNullOrWhiteSpace(contact.Designation))
            {
                return BadRequest("Required fields are missing");
            }

            var updatedContact = await _contactRepository.UpdateContactAsync(id, contact);

            if (updatedContact == null)
            {
                return NotFound("Requested contact does not exist");
            }

            return Ok(updatedContact);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var deletedContact = await _contactRepository.DeleteContactAsync(id);

            if (deletedContact == null)
            {
                return NotFound("Requested contact does not exist");
            }

            return Ok(deletedContact);
        }
    }
}
