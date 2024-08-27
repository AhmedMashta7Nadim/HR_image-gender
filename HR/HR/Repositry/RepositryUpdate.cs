using AutoMapper;
using HR.Data;
using HR.Repositry.Serves;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Xml.XPath;

namespace HR.Repositry
{
    public class RepositryUpdate<Z> :IRepositryUpdate<Z>
        where Z : class
    {
        private readonly HR_Context context;
        private readonly IMapper mapper;

        public RepositryUpdate(
            HR_Context context,
            IMapper mapper
            )
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Z> UpdateAsync(Guid id, JsonPatchDocument<Z> json)
        {
            var get = context.Set<Z>().Find(id);
            if (get == null)
            {
                return null;
            }

            var mapping = mapper.Map<Z>(get);
            json.ApplyTo(mapping);

            var added = mapper.Map(mapping, get);

            context.SaveChanges();

            return added;
        }
       

    }
}
