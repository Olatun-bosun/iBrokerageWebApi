using iBrokerageWebApi.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace iBrokerageWebApi.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Policy> Policies { get; set; }
        public DbSet<Claim> ClaimsReserved { get; set; }
    }
}
