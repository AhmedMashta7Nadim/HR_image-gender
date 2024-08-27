using Azure;
using HR_Models.Models.VM;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Converters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using JsonPatchDocument = Microsoft.AspNetCore.JsonPatch.JsonPatchDocument;
namespace HR.Repositry.Serves
{
        
    public interface IRepositryAllModels<T,V> : IRepositryUpdate<T> where T:class
    {

        // All Models in T=Classes and V=ClassSummary
        Task<List<V>> GetAll();
        Task<List<T>> GetAllT();

        Task<V> GetById(Guid id);

        T Add(T item);

        Task<T> Put(Guid id, T item);

        Task<T> Delete(Guid id);





        // Controller Employee : return List Salarys the One Employee
        Task<List<T>> GetAllEmplyeeAndSalarys();



        // Controller City : return List Employees in City
        Task<List<T>> GetEmployeesInCity();


    }
}
