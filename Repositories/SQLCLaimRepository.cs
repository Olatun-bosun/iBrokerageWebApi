using iBrokerageWebApi.Data;
using iBrokerageWebApi.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace iBrokerageWebApi.Repositories
{
    public class SQLCLaimRepository : IClaimRepository
    {
        private readonly DataContext dbContext;

        public SQLCLaimRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Claim> CreateAsync(Claim claim)
        {
           await dbContext.ClaimsReserved.AddAsync(claim);
            await dbContext.SaveChangesAsync();
            return claim;
        }
        public async Task<List<Claim>> GetAllAsync()
        {
            return await dbContext.ClaimsReserved.ToListAsync();
        }

        public async Task<Claim?> GetByClaimReservedIDAsync(long claimReservedID)
        {
            return await dbContext.ClaimsReserved.FirstOrDefaultAsync(x => x.ClaimReservedID == claimReservedID);
        }
    }
}
