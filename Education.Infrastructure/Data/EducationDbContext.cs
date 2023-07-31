using Education.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Education.Infrastructure.Data
{
    public class EducationDbContext : DbContext
    {
        public EducationDbContext(DbContextOptions<EducationDbContext> options):base(options)
        {

        }
        public virtual DbSet<tb_EducationGroup> EducationGroup { get; set; }
    }
}
