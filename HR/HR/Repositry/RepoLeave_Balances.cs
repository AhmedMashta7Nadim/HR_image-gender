﻿using AutoMapper;
using HR.Data;
using HR_Models.Models;
using HR_Models.Models.VM;

namespace HR.Repositry
{
    public class RepoLeave_Balances : RepositryAllModels<Leave_Balances, Leave_BalancesSummary>
    {
        public RepoLeave_Balances(HR_Context context, IMapper mapper) : base(context, mapper)
        {
        }



    }
}