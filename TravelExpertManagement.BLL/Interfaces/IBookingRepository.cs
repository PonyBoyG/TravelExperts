using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExpertManagement.Data.Models;

namespace TravelExpertManagement.BLL.Interfaces
{
    public interface IBookingRepository
    {
        Task<IList<Booking>> GetAllBookings();
        Task<Booking> GetBooking(int id);
        Task<Booking> AddBooking(Booking booking);
        Task<Booking> UpdateBooking(Booking booking);
        Task<List<Booking>> GetUserBookings(string username);
        Task<Booking> DeleteBooking(int id);

    }
}
