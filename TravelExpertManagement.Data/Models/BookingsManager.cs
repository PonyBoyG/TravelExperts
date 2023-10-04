using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TravelExpertManagement.Data.Models
{
    public static class BookingsManager
    {
        public static List<Booking> GetAll(TravelExpertsContext db)
        {
            List<Booking> bookings = db.Bookings.
                Include(b => b.Customer).Include(b => b.Package).ToList();
            return bookings;
        }

        public static List<Booking> GetBookingsByOwner(TravelExpertsContext db, int id = 0)
        {
            List<Booking> bookings = null;

            if (id == 0)
            {
                bookings = db.Bookings.Include(b => b.Customer).Include(b => b.Package).ToList();
            }
            else
            {
                bookings = db.Bookings.
                    Where(b => b.CustomerId == id).
                    Include(b => b.Customer).Include(b => b.Package).ToList();
            }
            return bookings;
        }

        public static void Add(TravelExpertsContext db, Booking booking)
        {
            db.Bookings.Add(booking);
            db.SaveChanges();
        }
    }
}
