using AutoMapper;
using HR.Data;
using HR_Models.Models;
using HR_Models.Models.VM;

namespace HR.Repositry
{
    public class RepoSalary : RepositryAllModels<Salary, SalarySummary>
    {
        public RepoSalary(HR_Context context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
