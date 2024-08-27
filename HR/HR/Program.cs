using HR.Data;
using HR.Repositry;
using HR.Repositry.RepositryToken;
using HR.Repositry.Serves;
using HR.Repositry.ServesToken;
using HR_Models.Models;
using HR_Models.Models.VM;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

namespace HR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("loggers/logger.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();





                builder.Services.AddControllers()
                  .AddNewtonsoftJson(options =>
                  {
                      options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                  });

         

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

              



            builder.Services.AddDbContext<HR_Context>(
                options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                }
                );





            builder.Services.AddScoped<IRepositryAllModels<City, CitySummary>, RepositryAllModels<City, CitySummary>>();
            builder.Services.AddScoped<IRepositryAllModels<Employee, EmployeeSummary>, RepositryAllModels<Employee, EmployeeSummary>>();
            builder.Services.AddScoped<IRepositryAllModels<UniverCity, UniverCitySummary>, RepositryAllModels<UniverCity, UniverCitySummary>>();
            builder.Services.AddScoped<IRepositryAllModels<Salary, SalarySummary>, RepositryAllModels<Salary, SalarySummary>>();
            builder.Services.AddScoped<IRepositryAllModels<EmployeeDepartment, EmployeeDepartmentSummary >, RepositryAllModels<EmployeeDepartment, EmployeeDepartmentSummary>>();
            builder.Services.AddScoped<IRepositryAllModels<Department, DepartmentSummary>, RepositryAllModels<Department, DepartmentSummary>>();
            builder.Services.AddScoped<IRepositryAllModels<Leave_Balances, Leave_BalancesSummary>, RepositryAllModels<Leave_Balances, Leave_BalancesSummary>>();
            builder.Services.AddScoped<IRepositryAllModels<Penalties, PenaltiesSummary>, RepositryAllModels<Penalties, PenaltiesSummary>>();
            builder.Services.AddScoped<IRepositryAllModels<Vacation, VacationSummary>, RepositryAllModels<Vacation, VacationSummary>>();
            builder.Services.AddScoped<IRepositryAllModels<Rewards, RewardsSummary>, RepositryAllModels<Rewards, RewardsSummary>>();

            builder.Services.AddScoped<IRepoCity, RepoCity>();
            builder.Services.AddScoped<IRepoPenalties, RepoPenalties>();

            builder.Services.AddScoped<HR.Repositry.RepoEmployee>();





            builder.Services.AddScoped<IRepositryUpdate<Employee>, RepositryUpdate<Employee>>();


            builder.Services.AddScoped<IAccessEmployeeRepositry, AccessEmployeeRepositry>();



            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            builder.Services.AddControllers()
                   .AddNewtonsoftJson(options =>
                   {
                       options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                   });

            builder.Host.UseSerilog();


                    builder.Services.AddAuthentication(/*JwtBearerDefaults.AuthenticationScheme*/)
                    .AddJwtBearer(options =>
                    {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authintication:Key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "https://localhost:7138",
                    ValidAudience = "HR",

                    };
                    });




            builder.Services.AddSwaggerGen(options =>
            {
                //  ⁄—Ì› «·‹ Bearer Token ›Ì Swagger
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "Input your Bearer token in this format - Bearer {your token here} to access this API",
                    In = ParameterLocation.Header
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();




            }


            app.UseHttpsRedirection();


            app.UseAuthentication();


            app.UseAuthorization();



            app.MapControllers();

            app.Run();
        }
    }
}
////