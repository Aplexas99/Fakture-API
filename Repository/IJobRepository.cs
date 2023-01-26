using FaktureAPI.Models;

namespace FaktureAPI.Repository
{
    public interface IJobRepository: IRepository<Job>
    {
        Task<IEnumerable<Job>> GetAll();
        Task<Job> GetById(int id);
        void CreateJob(Job owner);
        void UpdateJob(Job owner);
        void DeleteJob(Job owner);
    }
}
