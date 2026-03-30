using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ContactController : Controller
    {
        private static List<ContactInfo> contacts = new List<ContactInfo>
        {
            new ContactInfo
            {
                ContactId = 1,
                FirstName = "Srija",
                LastName = "Chowdary",
                CompanyName = "Infosys",
                EmailId = "srija@gmail.com",
                MobileNo = 9876543210,
                Designation = "Engineer"
            },
            new ContactInfo
            {
                ContactId = 2,
                FirstName = "Rahul",
                LastName = "Sharma",
                CompanyName = "TCS",
                EmailId = "rahul@gmail.com",
                MobileNo = 9123456780,
                Designation = "Developer"
            },
            new ContactInfo
            {
                ContactId = 3,
                FirstName = "Anjali",
                LastName = "Reddy",
                CompanyName = "Wipro",
                EmailId = "anjali@gmail.com",
                MobileNo = 9012345678,
                Designation = "Tester"
            }
        };

        // READ - Show all contacts
        public ActionResult ShowContacts()
        {
            return View(contacts);
        }

        // READ - Search by ID
        public ActionResult GetContactById(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            return View(contact);
        }

        // CREATE - GET
        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }

        // CREATE - POST
        [HttpPost]
        public ActionResult AddContact(ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
                contacts.Add(contactInfo);
                return RedirectToAction("ShowContacts");
            }

            return View(contactInfo);
        }

        // UPDATE - GET
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // UPDATE - POST
        [HttpPost]
        public ActionResult Edit(ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
                var existingContact = contacts.FirstOrDefault(c => c.ContactId == contactInfo.ContactId);

                if (existingContact == null)
                {
                    return NotFound();
                }

                existingContact.FirstName = contactInfo.FirstName;
                existingContact.LastName = contactInfo.LastName;
                existingContact.CompanyName = contactInfo.CompanyName;
                existingContact.EmailId = contactInfo.EmailId;
                existingContact.MobileNo = contactInfo.MobileNo;
                existingContact.Designation = contactInfo.Designation;

                return RedirectToAction("ShowContacts");
            }

            return View(contactInfo);
        }

        // DELETE - GET
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // DELETE - POST
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);

            if (contact != null)
            {
                contacts.Remove(contact);
            }

            return RedirectToAction("ShowContacts");
        }
    }
}