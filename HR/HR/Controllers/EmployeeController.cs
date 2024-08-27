using AutoMapper;
using ClosedXML.Excel;
using HR.Repositry;
using HR.Repositry.Serves;
using HR.Repositry.ServesToken;
using HR_Models.Models;
using HR_Models.Models.Creation;
using HR_Models.Models.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepositryAllModels<Employee, EmployeeSummary> repoEmp;
        private readonly IMapper mapper;
        private readonly IRepositryAllModels<City, CitySummary> repoCity;
        private readonly RepoEmployee repo;
        private readonly IRepositryUpdate<Employee> repoupdate;
        private readonly IAccessEmployeeRepositry accessEmployee;

        public EmployeeController(
            IRepositryAllModels<Employee, EmployeeSummary> repoEmp,
            IMapper mapper,
            IRepositryAllModels<City, CitySummary> RepoCity,
            RepoEmployee repo,
            IRepositryUpdate<Employee> repoupdate,
            IAccessEmployeeRepositry accessEmployee
            )
        {
            this.repoEmp = repoEmp;
            this.mapper = mapper;
            repoCity = RepoCity;
            this.repo = repo;
            this.repoupdate = repoupdate;
            this.accessEmployee = accessEmployee;
        }


        [HttpGet]
        public async Task<ActionResult<List<EmployeeSummary>>> GetAllEmployee()
        {
            var gets = await repoEmp.GetAll();

            //var emp = mapper.Map<List<EmployeeSummary>>(gets);
            return Ok(gets);

        }

        [HttpGet("GetEmployee/{id:guid}")]
        public async Task<ActionResult<EmployeeSummary>> GetEmployee(Guid id)
        {
            var get = await repoEmp.GetById(id);
            if (get == null)
            {
                return BadRequest("No Is Not Data");
            }
            return Ok(get);
        }







        //[Authorize(Roles = "Admin,User")]
        [HttpPost("/api/AddEmployee")]
        public async Task<ActionResult<Employee>> AddEmployee(/*[FromBody]*/[FromForm] EmployeeCreation employee)
        {
            var map = mapper.Map<Employee>(employee);

            repo.AddImg(map);

            var request = repoEmp.Add(map);
            if (request.Functional_ID == HR_Models.EnumClass.enum_Functional.Admin || request.Functional_ID == HR_Models.EnumClass.enum_Functional.User)
            {
                accessEmployee.Set(request.id, request.Functional_ID);
            }
            else { BadRequest("value Type is Functionality eRROR"); }
            return CreatedAtAction(nameof(GetAllEmployee), new { id = request.id }, map);
        }








        //[Authorize(Roles = "Admin,User")]
        [HttpPut("/api/PutEmployee/{id}")]
        public async Task<ActionResult<Employee>> PutEmployee(Guid id, [FromBody] Employee employee)
        {
            var updatedEmployee = await repoEmp.Put(id, employee);

            if (updatedEmployee == null)
            {
                return NotFound();
            }
            return NoContent();
        }
        //[Authorize(Roles = "Admin")]
        [HttpDelete("Deleted")]
        public async Task<ActionResult<Employee>> DeleteEmployee(Guid id)
        {
            var delete = await repoEmp.Delete(id);

            if (delete is null)
            {
                return BadRequest(" Employee Not Found ... ");
            }
            var empdelete = mapper.Map<EmployeeSummary>(delete);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("/api/Patch")]
        public async Task<ActionResult<Employee>> UpdateEmployee(Guid id, JsonPatchDocument<Employee> emp)
        {
            var patches = repoEmp.UpdateAsync(id, emp);
            if (patches == null)
            {
                return NotFound();
            }
            return Ok(patches);
        }









        /// <summary>
        /// /////////////
        /// </summary>
        /// <returns></returns> 

        [HttpGet("Api/EmployeeinSalarys")]
        public async Task<ActionResult<List<Employee>>> GetEmployeeInSalarys()
        {
            var responce = repoEmp.GetAllEmplyeeAndSalarys();
            if (responce == null)
            {
                return BadRequest(" is Employee null City");
            }

            var json = JsonConvert.SerializeObject(responce, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });


            return Ok(responce);
        }


        [HttpGet("api/EmployeeDep")]
        public async Task<ActionResult<(List<int>, List<Employee>)>> GetEmployee_Dep()
        {
            var repoEmployees = await repo.getEmployee_dep();

            return Ok(repoEmployees);
        }

        [HttpGet("ExportEmployees")]
        public async Task<ActionResult> ExportEmployees()
        {
            var get = await repoEmp.GetAllT();
            var employees = get.Select(e => new
            {
                e.Name,
                e.Father,
                e.LastName,
                e.BirthDate,
                e.date_of_employment,
                e.Salary_basis,
                e.Functional_ID,
                e.CityId,
                e.UniverCityId
            }).ToList();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Employees");
                var currentRow = 1;

                // إضافة عناوين الأعمدة
                worksheet.Cell(currentRow, 1).Value = "Name";
                worksheet.Cell(currentRow, 2).Value = "Father";
                worksheet.Cell(currentRow, 3).Value = "LastName";
                worksheet.Cell(currentRow, 4).Value = "BirthDate";
                worksheet.Cell(currentRow, 5).Value = "Date of Employment";
                worksheet.Cell(currentRow, 6).Value = "Salary Basis";
                worksheet.Cell(currentRow, 7).Value = "Functional ID";
                worksheet.Cell(currentRow, 8).Value = "CityId";
                worksheet.Cell(currentRow, 9).Value = "UniversityId";

                // إضافة البيانات
                foreach (var employee in employees)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = employee.Name;
                    worksheet.Cell(currentRow, 2).Value = employee.Father;
                    worksheet.Cell(currentRow, 3).Value = employee.LastName;
                    worksheet.Cell(currentRow, 4).Value = employee.BirthDate;
                    worksheet.Cell(currentRow, 5).Value = employee.date_of_employment;
                    worksheet.Cell(currentRow, 6).Value = employee.Salary_basis;
                    worksheet.Cell(currentRow, 7).Value = employee.Functional_ID.ToString();
                    worksheet.Cell(currentRow, 8).Value = employee.CityId.ToString();
                    worksheet.Cell(currentRow, 9).Value = employee.UniverCityId.ToString();
                }

                // حفظ الملف في ذاكرة مؤقتة
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    // إعادة الملف إلى العميل
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Employees.xlsx");
                }



            }
        }

    }
}


