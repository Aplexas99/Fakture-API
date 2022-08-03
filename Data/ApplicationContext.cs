using FaktureAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FaktureAPI.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base(options)
        {

        }

        public DbSet<Partner> Partners { get; set; }
        public DbSet<BillBody> BillBodies { get; set; }
        public DbSet<BillHeader> BillHeaders { get; set; }
    }
}
