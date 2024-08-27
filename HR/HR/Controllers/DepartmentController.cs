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
    public class DepartmentController : ControllerBase
    {

        private readonly IMapper mapper;
        private readonly IRepositryAllModels<Department, DepartmentSummary> repositry;

        public DepartmentController(
            IMapper mapper,
            IRepositryAllModels<Department, DepartmentSummary> repositry
            )
        {
            this.mapper = mapper;
            this.repositry = repositry;
        }




        [HttpGet]
        public async Task<ActionResult<List<DepartmentSummary>>> GetAll()
        {
            var gets =await repositry.GetAll();
            //var emp = mapper.Map<List<EmployeeSummary>>(gets);
            return Ok(gets);

        }

        [HttpGet("GetDepartment/{id}")]
        public async Task<ActionResult<DepartmentSummary>> GetBYId(Guid id)
        {
            var get =await repositry.GetById(id);
            return Ok(get);
        }



        [HttpPost("/api/DepartmentAdded")]
        public async Task<ActionResult<Department>> AddUniverCity([FromBody] DepartmentCreation Department)
        {
            var map = mapper.Map<Department>(Department);

            var request = repositry.Add(map);

            //repositry.GetById(map.EmployeeId);

            return CreatedAtAction(nameof(GetAll), new { id = request.id }, map);
        }






        [HttpPut("/api/PutsDepartment/{id}")]
        public async Task<ActionResult<Department>> PutUniverCity(Guid id, [FromBody] Department Department)
        {
            await repositry.Put(id, Department);
            return NoContent();
        }



        [HttpDelete("Deleted")]
        public async Task<ActionResult<Department>> DeleteDepartment(Guid id)
        {
            var delete = repositry.Delete(id);

            if (delete is null)
            {
                return BadRequest(" Department Not Found ... ");
            }
            var Department = mapper.Map<DepartmentSummary>(delete);

            return NoContent();
        }



        [HttpPatch("/api/Department/Patch")]
        public async Task<ActionResult<Department>> UpdateDepartment(Guid id, JsonPatchDocument<Department> emp)
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
