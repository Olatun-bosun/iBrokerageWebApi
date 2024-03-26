using iBrokerageWebApi.Data;
using iBrokerageWebApi.Model.Domain;
using iBrokerageWebApi.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization.DataContracts;

namespace iBrokerageWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly DataContext dbContext;
        public PolicyController(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var policies = dbContext.Policies.ToList();
            return Ok(policies);
        }

        [HttpGet]
        [Route("{policyNo}")]
        public IActionResult GetByPolicyNo([FromRoute] string policyNo)
        {
            var policy = dbContext.Policies.Find(policyNo);
            if (policy == null)
            {
                return NotFound();
            }
            return Ok(policy);
        }


        [HttpPost]
        public IActionResult Create([FromBody] Policy policy)
        {
            //var policyDomainModel = new Policy
            //{
            //    CoPolicyNo = addPolicyRequestDto.CoPolicyNo,
            //    BranchID = addPolicyRequestDto.BranchID,
            //    Branch = addPolicyRequestDto.Branch,
            //    BizSource = addPolicyRequestDto.BizSource
            //};

            dbContext.Policies.Add(policy);
            dbContext.SaveChanges();

            //var policyDto = new PolicyDto
            //{
            //    PolicyNo = policyDomainModel.PolicyNo,
            //    BranchID = policyDomainModel.BranchID,
            //    Branch = policyDomainModel.Branch,
            //    BizSource = policyDomainModel.BizSource
            //};

            return Ok();

        }
    }
}
