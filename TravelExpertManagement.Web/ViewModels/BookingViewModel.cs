using System.ComponentModel.DataAnnotations;

namespace TravelExpertManagement.Web.ViewModels
{
    public class BookingViewModel
    {
        public int BookingId { get; set; }

        [Display(Name = "Booking Date")]
        [DataType(DataType.Date)]
        public DateTime? BookingDate { get; set; }

        [Display(Name = "Booking Number")]
        public string BookingNo { get; set; }

        [Display(Name = "Traveler Count")]
        public double? TravelerCount { get; set; }

        [Display(Name = "Customer ID")]
        public int? CustomerId { get; set; }

        [Display(Name = "Trip Type ID")]
        public string TripTypeId { get; set; }

        [Display(Name = "Package ID")]
        public int? PackageId { get; set; }

    }
}
