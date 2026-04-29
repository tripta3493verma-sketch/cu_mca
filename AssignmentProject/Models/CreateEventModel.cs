using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentProject.Models
{
    public class CreateEventModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter title")]
        [Display(Name ="Title")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please enter Location")]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Start Time")]
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        public string  Time { get; set; }

        [Display(Name ="Type")]
        public string Type { get; set; }
        [Display(Name = "Duration In Hours")]
        [Range(0, 4)]
        public int? Duration { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        [MaxLength(500)]
        [Display(Name = "Other Details")]
        public string OtherDetails { get; set; }

        [Display(Name = "Invite Others")]
        public string InviteByEmail { get; set; }

        public string CreatedBy { get; set; }

        public string Comments { get; set; }

        public int TotalInvites { get; set; }
    }
}
