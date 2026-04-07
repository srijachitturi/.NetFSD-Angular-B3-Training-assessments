using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication6.Models;
using WebApplication6.Repositories;

namespace WebApplication6.Controllers
{
    [Route("Contact")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _repository;

        public ContactController(IContactRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("ShowContacts")]
        public IActionResult ShowContacts()
        {
            var contacts = _repository.GetAllContacts();
            return View(contacts);
        }

        [HttpGet("AddContact")]
        public IActionResult AddContact()
        {
            LoadDropdowns();
            return View();
        }

        [HttpPost("AddContact")]
        public IActionResult AddContact(ContactInfo contact)
        {
            LoadDropdowns();
            _repository.AddContact(contact);
            return RedirectToAction("ShowContacts");
        }

        [HttpGet("GetContactById/{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _repository.GetContactById(id);
            if (contact == null)
                return NotFound();

            return View(contact);
        }

        [HttpGet("EditContact/{id}")]
        public IActionResult EditContact(int id)
        {
            var contact = _repository.GetContactById(id);
            if (contact == null)
                return NotFound();

            LoadDropdowns();
            return View(contact);
        }

        [HttpPost("EditContact")]
        public IActionResult EditContact(ContactInfo contact)
        {
            if (contact.ContactId == 0)
                return BadRequest();

            LoadDropdowns();

            if (!ModelState.IsValid)
                return View(contact);

            _repository.UpdateContact(contact);
            return RedirectToAction("ShowContacts");
        }

        [HttpGet("DeleteContact/{id}")]
        public IActionResult DeleteContact(int id)
        {
            var contact = _repository.GetContactById(id);
            if (contact == null)
                return NotFound();

            return View(contact);
        }

        [HttpPost("DeleteContact")]
        public IActionResult DeleteContact(ContactInfo contact)
        {
            _repository.DeleteContact(contact.ContactId);
            return RedirectToAction("ShowContacts");
        }

        private void LoadDropdowns()
        {
            ViewBag.Companies = new SelectList(_repository.GetAllCompanies(), "CompanyId", "CompanyName");
            ViewBag.Departments = new SelectList(_repository.GetAllDepartments(), "DepartmentId", "DepartmentName");
        }
    }
}