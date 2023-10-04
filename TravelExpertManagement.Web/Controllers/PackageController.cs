using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelExpertManagement.BLL.Interfaces;
using TravelExpertManagement.Data.Models;

namespace TravelExpertManagement.Web.Controllers
{
    public class PackageController : Controller
    {
        private readonly IPackageRepository _packageRepository;

        public PackageController(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        // GET: PackageController
        public async Task<IActionResult> Index()
        {
            var packagesList = await _packageRepository.GetAllPackages();
            var packages = packagesList.ToList();
            return View(packages);
        }



        // GET: PackageController/Details/5
        public IActionResult Details(int id)
        {
            var package = _packageRepository.GetPackage(id);
            if (package == null)
            {
                return NotFound();
            }
            return View(package);
        }

        // GET: PackageController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PackageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Package package)
        {
            if (ModelState.IsValid)
            {
                _packageRepository.AddPackage(package);
                return RedirectToAction(nameof(Index));
            }
            return View(package);
        }

        // GET: PackageController/Edit/5
        public IActionResult Edit(int id)
        {
            var package = _packageRepository.GetPackage(id);
            if (package == null)
            {
                return NotFound();
            }
            return View(package);
        }

        // POST: PackageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Package package)
        {
            if (id != package.PackageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _packageRepository.UpdatePackage(package);
                return RedirectToAction(nameof(Index));
            }
            return View(package);
        }

        // GET: PackageController/Delete/5
        public IActionResult Delete(int id)
        {
            var package = _packageRepository.GetPackage(id);
            if (package == null)
            {
                return NotFound();
            }
            return View(package);
        }

        // POST: PackageController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _packageRepository.DeletePackage(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
