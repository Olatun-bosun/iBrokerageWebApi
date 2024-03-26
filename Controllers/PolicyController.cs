using iBrokerageWebApi.Data;
using iBrokerageWebApi.Model.Domain;
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
    }
}
