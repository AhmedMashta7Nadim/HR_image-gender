using HR.Repositry.ServesToken;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Token_HR.Model;

namespace HR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IAccessEmployeeRepositry repositry;

        public AccountController(
            IConfiguration configuration,
            IAccessEmployeeRepositry repositry
            )
        {
            this.configuration = configuration;
            this.repositry = repositry;
        }


        [HttpPost("auth")]
        public ActionResult<AccessEmployee> Authontication(AccessEmployee authRequest)
        {
            var user =
                ValidationUserInformation(authRequest.IdEmployee);

            if (user == null)
            {
                return Unauthorized();
            }

            var SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Authintication:Key"]));

            var siningCredantions = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            var typeRole = repositry.getRoles(authRequest.IdEmployee);
            var claims = new[]
                {
                    new Claim("role",typeRole)
                };



            var scurityTokin = new JwtSecurityToken(
                configuration["Authintication:Issure"],
                configuration["Authintication:Audions"],
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddYears(2),
                siningCredantions
                );

            var token = new JwtSecurityTokenHandler().WriteToken(scurityTokin);

            return Ok(token);
        }

        private object ValidationUserInformation(Guid EmployeeAccessId)
        {

            var x = repositry.exist(EmployeeAccessId);
            if (x == null)
            {
                return null;
            }
            return x;

        }
    }
}
