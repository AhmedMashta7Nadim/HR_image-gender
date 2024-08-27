using AutoMapper;
using AutoMapper.Internal;
using HR.Repositry;
using HR.Repositry.Serves;
using HR_Models.Models;
using HR_Models.Models.Creation;
using HR_Models.Models.VM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRepositryAllModels<Salary, SalarySummary> repositry;

        public SalaryController(
            IMapper mapper,
            IRepositryAllModels<Salary,SalarySummary> repositry
            )
        {
            this.mapper = mapper;
            this.repositry = repositry;
        }




        [HttpGet]
        public async Task<ActionResult<List<SalarySummary>>> GetAll()
        {
            var gets =await repositry.GetAll();
            //var emp = mapper.Map<List<EmployeeSummary>>(gets);
            return Ok(gets);

        }

        [HttpGet("GetSalary/{id}")]
        public async Task<ActionResult<SalarySummary>> GetBYId(Guid id)
        {
            var get =await repositry.GetById(id);
            return Ok(get);
        }



        [HttpPost("/api/salaryAdded")]
        public async Task<ActionResult<Salary>> AddUniverCity([FromBody] SalaryCreation salary)
        {
            var map = mapper.Map<Salary>(salary);

            var request = repositry.Add(map);

            repositry.GetById(map.EmployeeId);




            return CreatedAtAction(nameof(GetAll), new { id = request.id }, map);
        }



      


        [HttpPut("/api/PutsSalary/{id}")]
        public async Task<ActionResult< Salary>> PutUniverCity(Guid id, [FromBody] Salary salary)
        {
            await repositry.Put(id, salary);
            return NoContent();
        }



        [HttpDelete("Deleted")]
        public async Task<ActionResult<Salary>> DeleteSalary(Guid id)
        {
            var delete = repositry.Delete(id);

            if (delete is null)
            {
                return BadRequest(" salary Not Found ... ");
            }
            var salary = mapper.Map<SalarySummary>(delete);

            return NoContent();
        }





        [HttpPatch("/api/Salary/Patch")]
        public async Task<ActionResult<Salary>> UpdateSalary(Guid id, JsonPatchDocument<Salary> emp)
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
