using AutoMapper;
using HR.Data;
using HR.Repositry.Serves;
using HR_Models.Models;
using HR_Models.Models.Creation;
using HR_Models.Models.VM;
using Microsoft.AspNetCore.Hosting;

namespace HR.Repositry
{
    public class RepoPenalties : RepositryAllModels<Penalties, PenaltiesSummary>, IRepoPenalties
    {
        private readonly HR_Context context;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment webHostEnvironment;

        public RepoPenalties(
            HR_Context context,
            IMapper mapper,
            IWebHostEnvironment webHostEnvironment
            ) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<Penalties> AddPenalties(PenaltiesCreation penalties)
        {
            if (penalties.file != null && penalties.file.Length > 0)
            {
                var fileName = Path.GetFileName(penalties.file.FileName);
                var filePath = Path.Combine(webHostEnvironment.WebRootPath, "uploads\\Penalties", fileName);

                if (!Directory.Exists(Path.Combine(webHostEnvironment.WebRootPath, "uploads\\Penalties")))
                {
                    Directory.CreateDirectory(Path.Combine(webHostEnvironment.WebRootPath, "uploads\\Penalties"));
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    penalties.file.CopyToAsync(stream);
                }

                penalties.Path_file = $"~/uploads/Penalties/{fileName}";
            }

            var map = mapper.Map<Penalties>(penalties);

            context.penalties.Add(map);
            context.SaveChanges();

            return new Penalties();

        }
   
        

    }
}
