using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TravelExpertManagement.BLL.Interfaces;
using TravelExpertManagement.Data.Models;
using TravelExpertManagement.Lib.Models;
using TravelExpertManagement.Web.ViewModels;

namespace TravelExpertManagement.Web.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IBookingRepository _bookingRepository;

        public CustomerController(ICustomerRepository customerRepository, SignInManager<ApplicationUser> signInManager, IBookingRepository bookingRepository)
        {
            _customerRepository = customerRepository;
            _signInManager = signInManager;
            _bookingRepository = bookingRepository;
        }

        // GET: CustomerController
        public IActionResult Index()
        {
            var customers = _customerRepository.GetAllCustomers();
            return View(customers);
        }

        // GET: CustomerController/Details/5
        public IActionResult Details(int id)
        {
            var customer = _customerRepository.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // GET: CustomerController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerRepository.AddCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: CustomerController/Edit/5
        public IActionResult Edit(int id)
        {
            var customer = _customerRepository.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _customerRepository.UpdateCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: CustomerController/Delete/5
        public IActionResult Delete(int id)
        {
            var customer = _customerRepository.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: CustomerController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _customerRepository.DeleteCustomer(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    // Redirect to the desired page after successful login.
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            return View(model);
        }



        [Authorize]
        public IActionResult MyBookings()
        {
            var userBookings = _bookingRepository.GetUserBookings(User.Identity.Name);

            return View(userBookings);
        }

    }
}
