using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.VecRepositories;
using src.VecRepositories.Entities;

namespace src.VecApi.Controllers
{
    [Route("/api/Organization/")]
    public class OrganizationController
    {
        private OrganizationRepository _organizationRepository;

        public OrganizationController(OrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<OrganizationEntity>> GetAsync()
        {
            return await _organizationRepository.GetAllAsync(1);
        }
    }
}