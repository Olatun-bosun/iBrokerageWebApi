using iBrokerageWebApi.Data;
using iBrokerageWebApi.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace iBrokerageWebApi.Repositories
{
    public class SQLPolicyRepository : IPolicyRepository
    {
        private readonly DataContext dbContext;
        public SQLPolicyRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Policy> CreateAsync(Policy policy)
        {
            await dbContext.Policies.AddAsync(policy);
            await dbContext.SaveChangesAsync();
            return policy;
        }

        public async Task<List<Policy>> GetAllAsync()
        {
           return await dbContext.Policies.ToListAsync();
        }

        public async Task<Policy?> GetByPolicyNoAsync(string policyNo)
        {
           return await dbContext.Policies.FirstOrDefaultAsync(x => x.PolicyNo == policyNo);
        }
    }
}
