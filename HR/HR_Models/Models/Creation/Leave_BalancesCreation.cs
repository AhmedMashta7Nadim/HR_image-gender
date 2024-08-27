﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Models.Models.Creation
{
    public class Leave_BalancesCreation
    {
        public Guid EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        //public Employee? Employee { get; set; }
        public int Remaining_Balance { get; set; } //الرصيد المتبقي
        public int Total_Balance { get; set; } //الرصيد الإجمالي
        public int Carryover_Balance { get; set; }//الرصيد المدور
    }
}