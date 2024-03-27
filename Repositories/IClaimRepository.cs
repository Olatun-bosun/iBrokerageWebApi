using iBrokerageWebApi.Model.Domain;

namespace iBrokerageWebApi.Repositories
{
    public interface IClaimRepository
    {
       Task<Claim> CreateAsync(Claim claim);
        Task<List<Claim>> GetAllAsync();
        Task<Claim?> GetByClaimReservedIDAsync(long claimReservedID);
    }
}
