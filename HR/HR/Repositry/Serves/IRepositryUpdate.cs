using Azure;
using Microsoft.AspNetCore.JsonPatch;

namespace HR.Repositry.Serves
{
    public interface IRepositryUpdate<Z> 
        where Z : class
    {


        Task<Z> UpdateAsync(Guid id,JsonPatchDocument<Z> json);


    }
}
