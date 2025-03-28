using System.ComponentModel.DataAnnotations;

namespace CV_Management.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string? Description { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public virtual List<Education> Education { get; set; }
        public virtual List<JobExp> JobExp { get; set; }
    }
}
