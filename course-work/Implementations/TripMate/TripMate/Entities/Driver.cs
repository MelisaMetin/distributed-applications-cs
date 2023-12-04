using System.ComponentModel.DataAnnotations;

namespace TripMate.Entities
{
    public class Driver
    {

        [Key]
        public int DriverID { get; set; }
        public string? Username { get; set; }

        [Display(Name = "First name")]
        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string? FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string? LastName { get; set; }

        [Display(Name = "Email")]
        [Required]
        [StringLength(150, MinimumLength = 5)]
        public string? Email { get; set; }

        [Display(Name = "Phone")]
        [Required]
        public int Phone { get; set; }

        [Display(Name = "Car")]
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string? Car { get; set; }



        public ICollection<Trip>? Trips { get; set; }
    }
   
}

