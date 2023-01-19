using FaktureAPI.Models;

namespace FaktureAPI.Repository
{
    public interface IBillBodyRepository: IRepository<BillBody>
    {
        Task<IEnumerable<BillBody>> GetAll();
        Task<BillBody> GetById(int id);
        Task<IEnumerable<BillBody>> GetBillBodiesByBillHeaderId(int id);
        void Create(BillBody owner);
        void Update(BillBody owner);
        void Delete(BillBody owner);

    }
}
