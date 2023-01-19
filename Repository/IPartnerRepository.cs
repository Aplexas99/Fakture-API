using FaktureAPI.Models;

namespace FaktureAPI.Repository
{
    public interface IPartnerRepository: IRepository<Partner>
    {
        Task<IEnumerable<Partner>> GetAll();
        Task<Partner> GetById(int id);
        void CreatePartner(Partner owner);
        void UpdatePartner(Partner owner);
        void DeletePartner(Partner owner);
    }
}
