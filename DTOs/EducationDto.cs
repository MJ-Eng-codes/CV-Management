using System.ComponentModel.DataAnnotations;

namespace CV_Management.DTOs
{
    public class EducationDto
    {
        public int UserID { get; set; }
        public int EduID { get; set; }

        [MaxLength(20)]
        public string? School { get; set; }

        [MaxLength(60)]
        public string? Degree { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
