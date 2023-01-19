using FaktureAPI.Data;
using FaktureAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FaktureAPI.Repository
{
    public class BillHeaderRepository : RepositoryBase<BillHeader>, IBillHeaderRepository
    {

        public BillHeaderRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }

        public async Task<IEnumerable<BillHeader>> GetAll()
        {
            return await FindAll()
                .OrderBy(b => b.Id)
                .ToListAsync();

        }

        public async Task<BillHeader> GetById(int id)
        {
            return await FindByCondition(b => b.Id.Equals(id))
            .FirstOrDefaultAsync();
        }

        public void CreateHeader(BillHeader billHeader)
        {
            Create(billHeader);
        }
        public void UpdateHeader(BillHeader billHeader)
        {
            Update(billHeader);
        }
        public void DeleteHeader(BillHeader billHeader)
        {
            Delete(billHeader);
        }
    }
}
