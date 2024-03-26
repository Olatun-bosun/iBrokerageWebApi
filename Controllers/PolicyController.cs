using AutoMapper;
using iBrokerageWebApi.Data;
using iBrokerageWebApi.Model.Domain;
using iBrokerageWebApi.Model.DTO;
using iBrokerageWebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Runtime.Serialization.DataContracts;

namespace iBrokerageWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        //private readonly string connectionString;

        //public PolicyController(IConfiguration configuration)
        //{
        //    connectionString = configuration["ConnectionStrings:SqlServerDb"] ?? "";
        //}
        private readonly DataContext dbContext;
        private readonly IPolicyRepository policyRepository;
        private readonly IMapper mapper;

        public PolicyController(DataContext dbContext, IPolicyRepository policyRepository, IMapper mapper )
        {
            this.dbContext = dbContext;
            this.policyRepository = policyRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var policysDomain = await policyRepository.GetAllAsync();

            var policyDto = mapper.Map<List<PolicyDto>>(policysDomain);

            return Ok(policyDto);
        }

        [HttpGet]
        [Route("{policyNo}")]
        public async Task<IActionResult> GetByPolicyNo([FromRoute] string policyNo)
        {
            //var policy = dbContext.Policies.Find(policyNo);   
            var policyDomain = await policyRepository.GetByPolicyNoAsync(policyNo);
            if (policyDomain == null)
            {
                return NotFound();
            }

            var policyDto = mapper.Map<PolicyDto>(policyDomain);

            return Ok(policyDto);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddPolicyRequestDto addPolicyRequestDto)
        {
            var policyDomainModel = mapper.Map<Policy>(addPolicyRequestDto);
            policyDomainModel= await policyRepository.CreateAsync(policyDomainModel);

            var policyDto = mapper.Map<PolicyDto>(policyDomainModel);

            return CreatedAtAction(nameof(GetByPolicyNo), new { policyNo = policyDomainModel.PolicyNo }, policyDomainModel);

            }
            //[HttpPost]
            //public IActionResult CreatePolicy(AddPolicyRequestDto addPolicyRequestDto)
            //{
            //    try
            //    {
            //        using (var connection = new SqlConnection(connectionString))
            //        {
            //            connection.Open();
            //            string sql = "INSERT INTO policies " +
            //                "( CoPolicyNo, BranchID, Branch, BizSource) VALUES " +
            //                "( @CoPolicyNo, @BranchID, @Branch, @BizSource)";

            //            using (var command = new SqlCommand(sql, connection))
            //            {

            //                command.Parameters.AddWithValue("CoPolicyNo", addPolicyRequestDto.CoPolicyNo);
            //                command.Parameters.AddWithValue("BranchID", addPolicyRequestDto.BranchID);
            //                command.Parameters.AddWithValue("Branch", addPolicyRequestDto.Branch);
            //                command.Parameters.AddWithValue("BizSource", addPolicyRequestDto.BizSource);


            //                command.ExecuteNonQuery();

            //            }
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        ModelState.AddModelError("Product", "Sorry but we have an exception");
            //        return BadRequest(ModelState);
            //    }

            //    return Ok();
            //}
        }
}
