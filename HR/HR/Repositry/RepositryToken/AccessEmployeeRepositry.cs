using HR.Data;
using HR.Repositry.ServesToken;
using System.Data;
using System.Security.Claims;
using Token_HR.Model;

namespace HR.Repositry.RepositryToken
{
    public class AccessEmployeeRepositry : IAccessEmployeeRepositry
    {
        private readonly HR_Context context;
        private List<Claim> claims = new List<Claim>();
        public AccessEmployeeRepositry(HR_Context context)
        {
            this.context = context;
        }




        public AccessEmployee exist(Guid id)
        {
            var x = context.accessEmployees.FirstOrDefault(x => x.IdEmployee == id)?? null;
            return x;
        }





        public string Role;

        public void Set(Guid guid,object obj)
        {
            var z=new AccessEmployee() { IdEmployee=guid };
            var x=context.accessEmployees.Add(z);
            z.Role = obj.ToString();
            context.SaveChanges();
        }



        //62c4ed0e-8836-4d64-3ae3-08dcb6758de8
        private string SetRoles(object obj)
        {
            //claims.Add(new Claim("role",obj.ToString()));
            return obj.ToString();
        }

        public string getRoles(Guid id)
        {
            var x = context.accessEmployees.FirstOrDefault(x => x.IdEmployee == id);
            return x.Role;
        }
    }
}
