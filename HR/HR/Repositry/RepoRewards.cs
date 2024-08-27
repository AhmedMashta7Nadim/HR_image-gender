using AutoMapper;
using HR.Data;
using HR_Models.Models;
using HR_Models.Models.VM;

namespace HR.Repositry
{
    public class RepoRewards : RepositryAllModels<Rewards, RewardsSummary>
    {

        public RepoRewards(HR_Context context, IMapper mapper) : base(context, mapper)
        {
        }

    }
}
