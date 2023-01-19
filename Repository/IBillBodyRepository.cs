using FaktureAPI.Models;

namespace FaktureAPI.Repository
{
    public interface IBillBodyRepository: IRepository<BillBody>
    {
        Task<IEnumerable<BillBody>> GetAll();
        Task<BillBody> GetById(int id);
        Task<IEnumerable<BillBody>> GetBillBodiesByBillHeaderId(int id);
        void CreateBody(BillBody owner);
        void UpdateBody(BillBody owner);
        void DeleteBody(BillBody owner);

    }
}
