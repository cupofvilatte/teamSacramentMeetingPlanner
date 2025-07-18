using System.ComponentModel.DataAnnotations;
namespace sacramentMeetingPlanner.Models
{
    public class Speaker
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Subject")]
        [StringLength(500)]
        public string Subject { get; set; }

        // Foreign key
        [Required]
        public int MeetingId { get; set; }
        public Meeting Meeting { get; set; }
    }
}
