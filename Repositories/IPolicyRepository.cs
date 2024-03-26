using iBrokerageWebApi.Model.Domain;

namespace iBrokerageWebApi.Repositories
{
    public interface IPolicyRepository
    {
        Task<List<Policy>> GetAllAsync();
        Task<Policy?> GetByPolicyNoAsync(string policyNo);

       Task<Policy> CreateAsync(Policy policy);
    }
}
