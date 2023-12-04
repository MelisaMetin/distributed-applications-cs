using System.ComponentModel.DataAnnotations;

namespace TripMate.Entities
{
    public class Feedback
    {
        [Key]
        public int FeedbackID { get; set; } 

        public int? TripID { get; set; } 
        public virtual Trip? Trip { get; set; } 

        public int UserID { get; set; } 
        public string? UserName { get; set; } 

        [Required]
        public string? Comment { get; set; } 

        [Range(1, 5)]
        public int Rating { get; set; } 

    }
}
