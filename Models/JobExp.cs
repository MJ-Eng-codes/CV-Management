using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CV_Management.Models
{
    public class JobExp
    {
        [Key]
        public int JobID { get; set; }

        [StringLength(20)]
        public string? JobTitle { get; set; }

        [StringLength(20)]
        public string? Company { get; set; }

        [StringLength(250)]
        public string? WorkDescription { get; set; }

        public float? Duration { get; set; }

        [ForeignKey("User")]
        public int? UserID_Fk { get; set; }

        public virtual User User { get; set; }
    }
}
