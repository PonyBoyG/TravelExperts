using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TravelExpertManagement.BLL.Interfaces;
using TravelExpertManagement.Web.Models;

namespace TravelExpertManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPackageRepository _packageRepository;

        public HomeController(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public async Task<IActionResult> Index()
        {
            var packagesList = await _packageRepository.GetAllPackages();
            var packages = packagesList.ToList();
            return View(packages);
        }


    }
}