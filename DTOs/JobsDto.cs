using System.ComponentModel.DataAnnotations;

namespace CV_Management.DTOs
{
    public class JobsDto
    {
        public int UserId { get; set; }
        public int JobID { get; set; }

        [MaxLength(20)]
        public string? JobTitle { get; set; }

        [MaxLength(20)]
        public string? Company { get; set; }

        [MaxLength(250)]
        public string? WorkDescription { get; set; }

        public float? Duration { get; set; }
    }
}
