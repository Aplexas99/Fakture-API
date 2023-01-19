using FaktureAPI.Data;
using FaktureAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FaktureAPI.Repository
{
    public class BillBodyRepository : RepositoryBase<BillBody>, IBillBodyRepository
    {

        public BillBodyRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }

        public async Task<IEnumerable<BillBody>> GetAll()
        {
            return await FindAll()
                .OrderBy(b => b.Id)
                .ToListAsync();

        }

        public async Task<BillBody> GetById(int id)
        {
            return await FindByCondition(b => b.Id.Equals(id))
            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<BillBody>> GetBillBodiesByBillHeaderId(int id)
        {
            return await FindByCondition(b => b.BillHeaderId.Equals(id))
                .ToListAsync();
        }

        public void CreateBillBody(BillBody billBody)
        {
            Create(billBody);
        }
        public void UpdateBillBody(BillBody billBody)
        {
            Update(billBody);
        }
        public void DeleteBillBody(BillBody billBody)
        {
            Delete(billBody);
        }
    }
}
