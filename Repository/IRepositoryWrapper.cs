namespace FaktureAPI.Repository
{
    public interface IRepositoryWrapper
    {
        IBillBodyRepository BillBody { get; }
        IBillHeaderRepository BillHeader { get; }

        Task SaveAsync();
    }
}
