
using System;
using System.ComponentModel.DataAnnotations;

namespace TripMate.Models
{
    public class TripViewModel
    {
        [Required(ErrorMessage = "From City is required")]
        public string? FromCity { get; set; }

        [Required(ErrorMessage = "To City is required")]
        public string? ToCity { get; set; }

        [Display(Name = "Departure Date and Time")]
        [Required(ErrorMessage = "Departure Date and Time is required")]
        public DateTime DepartureDateTime { get; set; }

        [Display(Name = "Available Seats")]
        [Required(ErrorMessage = "Available Seats is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value greater than 0")]
        public int AvailableSeats { get; set; }

        
    }
}
