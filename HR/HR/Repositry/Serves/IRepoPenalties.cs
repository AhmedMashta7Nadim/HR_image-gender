using HR_Models.Models;
using HR_Models.Models.Creation;
using HR_Models.Models.VM;

namespace HR.Repositry.Serves
{
    public interface IRepoPenalties:IRepositryAllModels<Penalties, PenaltiesSummary>
    {
        Task<Penalties> AddPenalties(PenaltiesCreation penalties);
    }
}
