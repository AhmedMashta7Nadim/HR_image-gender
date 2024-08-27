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
    public class RewardsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRepositryAllModels<Rewards, RewardsSummary> repositry;

        public RewardsController(
            IMapper mapper,
            IRepositryAllModels<Rewards, RewardsSummary> repositry
            )
        {
            this.mapper = mapper;
            this.repositry = repositry;
        }


        [HttpGet]
        public async Task<ActionResult<List<RewardsSummary>>> GetAllRewards()
        {
            var gets =await repositry.GetAll();
            //var emp = mapper.Map<List<EmployeeSummary>>(gets);
            return Ok(gets);

        }

        [HttpGet("GetRewards/{id}")]
        public async Task<ActionResult<RewardsSummary>> GetRewardsId(Guid id)
        {
            var get =await repositry.GetById(id);
            return Ok(get);
        }



        [HttpPost("/api/RewardsAdded")]
        public async Task<ActionResult<Rewards>> AddRewards([FromBody] RewardsCreation Rewards)
        {
            var map = mapper.Map<Rewards>(Rewards);

            var request = repositry.Add(map);

            return CreatedAtAction(nameof(GetAllRewards), new { id = request.id }, map);
        }



        [HttpPut("/api/PutsRewards/{id}")]
        public async Task<ActionResult<Rewards>> PutRewards(Guid id, [FromBody] Rewards Rewards)
        {
            await repositry.Put(id, Rewards);
            return NoContent();
        }

        [HttpDelete("Deleted")]
        public async Task<ActionResult<Rewards>> DeleteRewards(Guid id)
        {
            var delete = repositry.Delete(id);

            if (delete is null)
            {
                return BadRequest(" Rewards Not Found ... ");
            }
            var Rewardsdelete = mapper.Map<RewardsSummary>(delete);

            return NoContent();
        }


        [HttpPatch("/api/Rewards/Patch")]
        public async Task<ActionResult<Rewards>> UpdateRewards(Guid id, JsonPatchDocument<Rewards> emp)
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
