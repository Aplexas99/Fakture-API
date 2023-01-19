using FaktureAPI.Models;

namespace FaktureAPI.Repository
{
    public interface IBillHeaderRepository : IRepository<BillHeader>
    {
        Task<IEnumerable<BillHeader>> GetAll();
        Task<BillHeader> GetById(int id);
        void CreateHeader(BillHeader owner);
        void UpdateHeader(BillHeader owner);
        void DeleteHeader(BillHeader owner);
    }
}
