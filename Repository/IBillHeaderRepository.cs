using FaktureAPI.Models;

namespace FaktureAPI.Repository
{
    public interface IBillHeaderRepository : IRepository<BillHeader>
    {
        Task<IEnumerable<BillHeader>> GetAll();
        Task<BillHeader> GetById(int id);
        void Create(BillHeader owner);
        void Update(BillHeader owner);
        void Delete(BillHeader owner);
    }
}
