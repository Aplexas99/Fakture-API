namespace FaktureAPI.Repository
{
    public interface IRepositoryWrapper
    {
        IBillBodyRepository BillBody { get; }
        IBillHeaderRepository BillHeader { get; }
        IPartnerRepository Partner { get; }

        Task SaveAsync();
    }
}
