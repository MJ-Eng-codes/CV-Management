using CV_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace CV_Management.Data
{
    public class CVManageDBContext : DbContext
    {
        public CVManageDBContext(DbContextOptions<CVManageDBContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<JobExp> JobExp { get; set; }
    }
}
