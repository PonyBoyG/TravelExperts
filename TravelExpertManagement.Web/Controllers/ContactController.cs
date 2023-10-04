using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelExpertManagement.Data.Models;
using TravelExpertManagement.Web.ViewModels;

namespace TravelExpertManagement.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly TravelExpertsContext _context;

        public ContactController(TravelExpertsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var agencies = _context.Agencies.ToList();
            var agents = _context.Agents.ToList();

            // Passing the agencies and agents data to the view
            return View(new ContactViewModel { Agencies = agencies, Agents = agents });
        }
    }
}
