using Microsoft.EntityFrameworkCore;
using src.VecRepositories.Entities;

namespace src.VecRepositories
{
    public class VecDbContext : DbContext
    {
        public VecDbContext(DbContextOptions<VecDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OrganizationEntity> OrganizationEntities { get; set; }
    }
}