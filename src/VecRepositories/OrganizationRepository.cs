using Microsoft.EntityFrameworkCore;
using src.VecRepositories.Abstractions;
using src.VecRepositories.Entities;

namespace src.VecRepositories
{
    public class OrganizationRepository : ReadWriteEntityRepository<OrganizationEntity>, IOrganizationRepository
    {
        protected OrganizationRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}