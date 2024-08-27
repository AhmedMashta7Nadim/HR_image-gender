using AutoMapper;
using HR.Data;
using HR_Models.Models;
using HR_Models.Models.VM;

namespace HR.Repositry
{
    public class RepoEmployeeDepartment : RepositryAllModels<EmployeeDepartment, EmployeeDepartmentSummary>
    {
        public RepoEmployeeDepartment(HR_Context context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
