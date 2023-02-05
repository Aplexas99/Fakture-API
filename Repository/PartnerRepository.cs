﻿using FaktureAPI.Data;
using FaktureAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FaktureAPI.Repository
{
    public class JobRepository : RepositoryBase<Job>, IJobRepository
    {
        public JobRepository(ApplicationContext repositoryContext)
            : base(repositoryContext)
        {
        }


        public async Task<IEnumerable<Job>> GetAll()
        {
            return await FindAll()
                .OrderBy(p => p.Id)
                .ToListAsync();
        }
        public async Task<Job> GetById(int id)
        {
            return await FindByCondition(p => p.Id.Equals(id))
                .FirstOrDefaultAsync();
        }
        public void CreateJob(Job job){   
            Create(job);
        }
        public void UpdateJob(Job job)
        {
            Update(job);
        }
        public void DeleteJob(Job job)
        {
            Delete(job);
        }
        
        
    }
}