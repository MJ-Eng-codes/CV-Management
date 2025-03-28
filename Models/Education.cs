using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CV_Management.Models
{
    public class Education
    {
       
        public int EduID { get; set; }

        [StringLength(20)]
        public string? School { get; set; }

        [StringLength(60)]
        public string? Degree { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        [ForeignKey("User")]
        public int? UserID_Fk { get; set; }

        public virtual User User { get; set; }

    }
}
