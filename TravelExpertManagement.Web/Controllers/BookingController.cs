using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelExpertManagement.Data.Models;
using TravelExpertManagement.Web.ViewModels;

namespace TravelExpertManagement.Web.Controllers
{
    public class BookingController : Controller
    {
        private TravelExpertsContext _context { get; set; }
        public BookingController(TravelExpertsContext context)
        {
            _context = context;
        }

        // GET: BookingsController
        [Authorize(Roles = "Customer")]
        public ActionResult Index()
        {
            List<Booking> bookings = BookingsManager.GetAll(_context);
            List<BookingViewModel> viewModels = bookings.Select(b => new BookingViewModel
            {
                BookingId = b.BookingId,
                BookingDate = b.BookingDate,
                BookingNo = b.BookingNo,
                TravelerCount = b.TravelerCount,
                CustomerId = b.CustomerId,
                TripTypeId = b.TripTypeId,
            }).ToList();
            return View(viewModels);
        }

        [Authorize]
        public async Task<IActionResult> List()
        {
            // Geting the currently logged-in user's username
            var username = User.Identity.Name;

            // Fetching the user's bookings using the DbContext (TravelExpertsContext)
            var bookings = await _context.Bookings
                .Include(b => b.Customer)
                .Where(b => b.Customer.Username == username)
                .ToListAsync();

            return View(bookings);
        }


        [Authorize]
        public IActionResult MyBookings()
        {
            // Geting the currently logged-in user 
            var currentUser = UserManager.Authenticate(User.Identity.Name, "password");

            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Fetching the user's bookings using the UserManager approach
            var bookings = _context.Bookings
                .Where(b => b.CustomerId == currentUser.Id)
                .ToList();

            var bookingViewModels = bookings.Select(b => new BookingViewModel
            {
                BookingId = b.BookingId,
                BookingDate = b.BookingDate,
                CustomerId = b.CustomerId,
                BookingNo = b.BookingNo,
            }).ToList();

            // Passing the bookingViewModels to the view
            return View(bookingViewModels);
        }
    }
}
