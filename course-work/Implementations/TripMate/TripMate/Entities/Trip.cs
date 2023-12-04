using System.ComponentModel.DataAnnotations;

namespace TripMate.Entities
{
    public class Trip
    {
        [Key]
        public int TripID { get; set; } 
        public int? DriverID { get; set; } 
        public virtual Driver? User { get; set; } 

        [StringLength(100, MinimumLength = 3)]
        public string? FromCity { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string? ToCity { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DepartureDateTime { get; set; }

        public int AvailableSeats { get; set;  }
    }
}
