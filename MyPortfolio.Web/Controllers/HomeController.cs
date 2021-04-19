using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Shared.Entities;
using MyPortfolio.Shared.UnitOfWorks.Interfaces;
using MyPortfolio.Web.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MyPortfolio.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork<Owner> _owner;
        private readonly IUnitOfWork<Project> _project;

        public HomeController(IUnitOfWork<Owner> owner, IUnitOfWork<Project> project)
        {
            _owner = owner;
            _project = project;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(new HomeViewModel
                {
                    Owner = (await _owner.Repository.Get()).FirstOrDefault(),
                    Projects = (await _project.Repository.Get()).OrderBy(_ => Guid.NewGuid())
                });
            }
            catch
            {
                return NotFound("An unexpected error occurred while fetching data from the database!");
            }
        }

        [HttpGet]
        public ActionResult Contact() => View();

        [HttpPost]
        public async Task<ActionResult> Contact(ContactViewModel contact)
        {
            try
            {
                if (!ModelState.IsValid) return NotFound("Please fill in all fields!");

                MailMessage mail = new(contact.Mail, "ahmetbakirci30@gmail.com", $"Website Contact Form: {contact.Name}", $"You have received a new message from your website contact form.\n\nHere are the details:\n\nName: {contact.Name}\n\nEmail: {contact.Mail}\n\nPhone: {contact.Phone}\n\nMessage:\n{contact.Message}");

                using SmtpClient client = new("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("ahmetbakircia@gmail.com", "ah124578");
                client.Send(mail);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(new HomeViewModel
                {
                    Owner = (await _owner.Repository.Get()).FirstOrDefault(),
                    Projects = await _project.Repository.Get()
                });
            }
        }
    }
}