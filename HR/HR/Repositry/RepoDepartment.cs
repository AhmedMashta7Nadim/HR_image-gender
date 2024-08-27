using AutoMapper;
using HR.Data;
using HR_Models.Models;
using HR_Models.Models.VM;

namespace HR.Repositry
{
    public class RepoDepartment : RepositryAllModels<Department, DepartmentSummary>
    {



        public RepoDepartment(HR_Context context, IMapper mapper) : base(context, mapper)
        {
        }



    }
}
