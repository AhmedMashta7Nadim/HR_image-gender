using AutoMapper;
using HR.Repositry.Serves;
using HR_Models.Models.Creation;
using HR_Models.Models.VM;
using HR_Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

namespace HR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Leave_BalancesController : ControllerBase
    {


        private readonly IMapper mapper;
        private readonly IRepositryAllModels<Leave_Balances, Leave_BalancesSummary> repositry;

        public Leave_BalancesController(
            IMapper mapper,
            IRepositryAllModels<Leave_Balances, Leave_BalancesSummary> repositry
            )
        {
            this.mapper = mapper;
            this.repositry = repositry;
        }




        [HttpGet]
        public async Task<ActionResult<List<Leave_BalancesSummary>>> GetAll()
        {
            var gets =await repositry.GetAll();
            //var emp = mapper.Map<List<EmployeeSummary>>(gets);
            return Ok(gets);

        }

        [HttpGet("GetLeave_Balances/{id}")]
        public async Task<ActionResult<Leave_BalancesSummary>> GetBYId(Guid id)
        {
            var get =await repositry.GetById(id);
            return Ok(get);
        }



        [HttpPost("/api/Leave_BalancesAdded")]
        public async Task<ActionResult<Leave_Balances>> AddUniverCity([FromBody] Leave_BalancesCreation Leave_Balances)
        {
            var map = mapper.Map<Leave_Balances>(Leave_Balances);

            var request = repositry.Add(map);

            //repositry.GetById(map.EmployeeId);




            return CreatedAtAction(nameof(GetAll), new { id = request.id }, map);
        }






        [HttpPut("/api/PutsLeave_Balances/{id}")]
        public async Task<ActionResult<Leave_Balances>> PutUniverCity(Guid id, [FromBody] Leave_Balances Leave_Balances)
        {
            await repositry.Put(id, Leave_Balances);
            return NoContent();
        }



        [HttpDelete("Deleted")]
        public async Task<ActionResult<Leave_Balances>> DeleteLeave_Balances(Guid id)
        {
            var delete = repositry.Delete(id);

            if (delete is null)
            {
                return BadRequest(" Leave_Balances Not Found ... ");
            }
            var Leave_Balances = mapper.Map<Leave_BalancesSummary>(delete);

            return NoContent();
        }

        [HttpPatch("/api/Leave_Balances/Patch")]
        public async Task<ActionResult<Leave_Balances>> UpdateLeave_Balances(Guid id, JsonPatchDocument<Leave_Balances> emp)
        {
            var patches = repositry.UpdateAsync(id, emp);
            if (patches == null)
            {
                return NotFound();
            }
            return Ok(patches);
        }






    }
}
