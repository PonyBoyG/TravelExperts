using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelExpertManagement.BLL.Interfaces;
using TravelExpertManagement.Data.Models;

namespace TravelExpertManagement.Web.Controllers
{
    public class AgencyController : Controller
    {
        private readonly IAgencyRepository _agencyRepository;

        public AgencyController(IAgencyRepository agencyRepository)
        {
            _agencyRepository = agencyRepository;
        }

        // GET: AgencyController
        public IActionResult Index()
        {
            var agencies = _agencyRepository.GetAllAgencies();
            return View(agencies);
        }

        // GET: AgencyController/Details/5
        public IActionResult Details(int id)
        {
            var agency = _agencyRepository.GetAgency(id);
            if (agency == null)
            {
                return NotFound();
            }
            return View(agency);
        }

        // GET: AgencyController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AgencyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Agency agency)
        {
            if (ModelState.IsValid)
            {
                _agencyRepository.AddAgency(agency);
                return RedirectToAction(nameof(Index));
            }
            return View(agency);
        }

        // GET: AgencyController/Edit/5
        public IActionResult Edit(int id)
        {
            var agency = _agencyRepository.GetAgency(id);
            if (agency == null)
            {
                return NotFound();
            }
            return View(agency);
        }

        // POST: AgencyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Agency agency)
        {
            if (id != agency.AgencyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _agencyRepository.UpdateAgency(agency);
                return RedirectToAction(nameof(Index));
            }
            return View(agency);
        }

        // GET: AgencyController/Delete/5
        public IActionResult Delete(int id)
        {
            var agency = _agencyRepository.GetAgency(id);
            if (agency == null)
            {
                return NotFound();
            }
            return View(agency);
        }

        // POST: AgencyController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _agencyRepository.DeleteAgency(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
