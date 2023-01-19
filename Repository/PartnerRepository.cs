using FaktureAPI.Data;
using FaktureAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FaktureAPI.Repository
{
    public class PartnerRepository : RepositoryBase<Partner>, IPartnerRepository
    {
        public PartnerRepository(ApplicationContext repositoryContext)
            : base(repositoryContext)
        {
        }


        public async Task<IEnumerable<Partner>> GetAll()
        {
            return await FindAll()
                .OrderBy(p => p.Id)
                .ToListAsync();
        }
        public async Task<Partner> GetById(int id)
        {
            return await FindByCondition(p => p.Id.Equals(id))
                .FirstOrDefaultAsync();
        }
        public void CreatePartner(Partner partner)
        {
            Create(partner);
        }
        public void UpdatePartner(Partner partner)
        {
            Update(partner);
        }
        public void DeletePartner(Partner partner)
        {
            Delete(partner);
        }
        
        
    }
}
