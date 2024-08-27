using AutoMapper;
using HR.Data;
using HR_Models.Models;
using HR_Models.Models.VM;

namespace HR.Repositry
{
    public class RepoVacation : RepositryAllModels<Vacation, VacationSummary>
    {

        public RepoVacation(HR_Context context, IMapper mapper) : base(context, mapper)
        {
        }


    }
}
