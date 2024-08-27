using Token_HR.Model;

namespace HR.Repositry.ServesToken
{
    public interface IAccessEmployeeRepositry
    {


        void Set(Guid guid, object obj);
        AccessEmployee exist(Guid id);
        string getRoles(Guid id);
    }
}
