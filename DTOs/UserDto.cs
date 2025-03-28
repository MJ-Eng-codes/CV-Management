using System.ComponentModel.DataAnnotations;


namespace CV_Management.DTOs
{
    public class UserDto
    {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string? Description { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public List<EducationDto>? Education { get; set; }
        public List<JobsDto>? JobExp { get; set; }
    }
}
