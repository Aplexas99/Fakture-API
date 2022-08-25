namespace FaktureAPI.Repository
{
    public interface IRepositoryWrapper
    {
        IBillBodyRepository BillBody { get; }

        Task SaveAsync();
    }
}
