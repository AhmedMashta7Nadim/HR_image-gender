using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HR_Models.Models.Creation
{
    public class PenaltiesCreation
    {
        public Guid EmployeeId { get; set; }
        public DateTime Date_Penalties { get; set; }
        public IFormFile file { get; set; }

        [JsonIgnore]
        public  string Path_file { get; set; }

        public Decimal Price_Penalties { get; set; }
        public string Reason_Penalties { get; set; }
    }
}
