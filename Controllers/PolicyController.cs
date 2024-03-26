using iBrokerageWebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace iBrokerageWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly string connectionString;

        public PolicyController(IConfiguration configuration)
        {
            connectionString = configuration["ConnectionStrings:SqlServerDb"] ?? "";
        }

        [HttpPost]
        public IActionResult CreatePolicy(Policy policy)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO policies " +
                        "(PolicyNo, CoPolicyNo, BranchID, Branch, BizSource) VALUES " +
                        "(@PolicyNo, @CoPolicyNo, @BranchID, @Branch, @BizSource)";

                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("PolicyNo", policy.PolicyNo);
                        command.Parameters.AddWithValue("CoPolicyNo", policy.CoPolicyNo);
                        command.Parameters.AddWithValue("BranchID", policy.BranchID);
                        command.Parameters.AddWithValue("Branch", policy.Branch);
                        command.Parameters.AddWithValue("BizSource", policy.BizSource);


                        command.ExecuteNonQuery();

                    }
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Product", "Sorry but we have an exception");
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpGet("{PolicyNo}")]
        public IActionResult GetPolicy(string PolicyNo)
        {
            Policy policy = new Policy();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Policies WHERE PolicyNo=@PolicyNo";


                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("PolicyNo", PolicyNo);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                policy.PolicyNo = reader.GetString(1);
                                policy.CoPolicyNo = reader.GetString(2);
                                policy.BranchID = reader.GetString(3);
                                policy.Branch = reader.GetString(4);
                                policy.BizSource = reader.GetString(5);



                            }
                            else
                            {
                                return NotFound();
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Product", "Sorry but we have an exception");
                return BadRequest(ModelState);
            }

            return Ok(policy);
        }

    }
}
