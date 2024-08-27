using AutoMapper;
using Azure;
using HR.Data;
using HR.Repositry.Serves;
using HR_Models.Models;
using HR_Models.Models.VM;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Xml.XPath;

namespace HR.Repositry
{
    public class RepoEmployee : RepositryAllModels<Employee,EmployeeSummary>
    {
        private readonly HR_Context context;
        private readonly IMapper mapper;
        private readonly IRepositryAllModels<Employee, EmployeeSummary> repositry;
        private readonly IWebHostEnvironment webHostEnvironment;

        public RepoEmployee(HR_Context context,
            IMapper mapper,
            IRepositryAllModels<Employee,EmployeeSummary> repositry,
            IWebHostEnvironment webHostEnvironment
            ) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
            this.repositry = repositry;
            this.webHostEnvironment = webHostEnvironment;
        }


        public void AddImg(Employee employee)
        {
            if (employee.Img != null && employee.Img.Length > 0)
            {
                var fileName = Path.GetFileName(employee.Img.FileName);
                var filePath = Path.Combine(webHostEnvironment.WebRootPath, "uploads\\employee", fileName);

                if (!Directory.Exists(Path.Combine(webHostEnvironment.WebRootPath, "uploads\\employee")))
                {
                    Directory.CreateDirectory(Path.Combine(webHostEnvironment.WebRootPath, "uploads\\employee"));
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    employee.Img.CopyToAsync(stream);
                }

                employee.Path_Img = $"~/uploads/employee/{fileName}";
            }

        }






        public async Task<(List<int>,List<Employee>)> getEmployee_dep()
        {
            //    var exist = context.employees
            //        .AsNoTracking()
            //        .FirstOrDefault(x => x.id == id);
            //    if (exist == null)
            //    {
            //        return (0,null);
            //    }

            var employees =await context.employees
                .Include(x => x.departments)
                .AsNoTracking()
                .ToListAsync();

            var depCount = employees.Select(x => x.departments.Count).ToList();

            return (depCount, employees);

        }






    }
}







