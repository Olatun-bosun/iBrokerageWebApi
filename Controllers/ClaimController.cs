using AutoMapper;
using iBrokerageWebApi.Model.Domain;
using iBrokerageWebApi.Model.DTO;
using iBrokerageWebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iBrokerageWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IClaimRepository claimRepository;

        public ClaimController(IMapper mapper, IClaimRepository claimRepository)
        {
            this.mapper = mapper;
            this.claimRepository = claimRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var claimsDomain = await claimRepository.GetAllAsync();

            var claimDto = mapper.Map<List<ClaimDto>>(claimsDomain);

            return Ok(claimDto);
        }

        [HttpGet]
        [Route("{claimReservedID}")]
        public async Task<IActionResult> GetByClaimReservedID([FromRoute] long claimReservedID)
        {
              
            var claimDomain = await claimRepository.GetByClaimReservedIDAsync(claimReservedID);
            if (claimDomain == null)
            {
                return NotFound();
            }

            var claimDto = mapper.Map<ClaimDto>(claimDomain);

            return Ok(claimDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddClaimRequest addClaimRequest)
        {
           var claimDomainModel = mapper.Map<Claim>(addClaimRequest);

            await claimRepository.CreateAsync(claimDomainModel);



            return Ok(mapper.Map<ClaimDto>(claimDomainModel));
        }



    }
}
