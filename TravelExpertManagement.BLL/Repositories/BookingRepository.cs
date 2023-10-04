using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelExpertManagement.BLL.Interfaces;
using TravelExpertManagement.Data.Models;

namespace TravelExpertManagement.BLL.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly TravelExpertsContext _context;

        public BookingRepository(TravelExpertsContext context)
        {
            _context = context;
        }

        public async Task<Booking> AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return null; // Or handle not found case as needed
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<IList<Booking>> GetAllBookings()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<Booking> GetBooking(int id)
        {
            return await _context.Bookings.FindAsync(id);
        }

        public async Task<List<Booking>> GetUserBookings(string username)
        {
            return await _context.Bookings
                .Include(b => b.Customer)
                .Where(b => b.Customer.Username == username)
                .ToListAsync();
        }

        public async Task<Booking> UpdateBooking(Booking booking)
        {
            _context.Entry(booking).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return booking;
        }
    }
}
