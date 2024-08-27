using HR.Data;
using HR.Repositry.Serves;
using HR_Models.Models;
using HR_Models.Models.VM;

namespace HR.Repositry
{
    public class RepoCity : RepositryAllModels<City,CitySummary>,IRepoCity
    {
        public RepoCity(HR_Context context) : base(context)
        {
        }

    }
}
