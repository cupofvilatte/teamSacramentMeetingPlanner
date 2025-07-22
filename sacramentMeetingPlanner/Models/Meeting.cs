using System.ComponentModel.DataAnnotations;

namespace sacramentMeetingPlanner.Models
{
    public class Meeting
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Meeting")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Conducting Leader")]
        [StringLength(100)]
        public string ConductingLeader { get; set; }

        [Required]
        [Display(Name = "Opening Song")]
        [StringLength(100)]
        public string OpeningSong { get; set; }

        [Required]
        [Display(Name = "Sacrament Hymn")]
        [StringLength(100)]
        public string SacramentHymn { get; set; }

        [Required]
        [Display(Name = "Closing Song")]
        [StringLength(100)]
        public string ClosingSong { get; set; }

        [Display(Name = "Intermediate Number")]
        [StringLength(100)]
        public string? IntermediateNumber { get; set; }

        [Required]
        [Display(Name = "Opening Prayer")]
        [StringLength(100)]
        public string OpeningPrayer { get; set; }

        [Required]
        [Display(Name = "Closing Prayer")]
        [StringLength(100)]
        public string ClosingPrayer { get; set; }

        // Navigation
        public List<Speaker> Speakers { get; set; } = new();
    }
}
