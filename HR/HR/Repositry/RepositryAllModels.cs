using AutoMapper;
using Azure.Core.Serialization;
using HR.Data;
using HR.Repositry.Serves;
using HR_Models.Models.VM;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Converters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Dynamic;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Xml.XPath;

namespace HR.Repositry
{
    public class RepositryAllModels<T,V> :
        IRepositryAllModels<T,V>
        where T : Entity
        where V:class
   
    {
        private readonly HR_Context context;
        private readonly IMapper mapper;

     /* Constracor */   public RepositryAllModels(HR_Context context)
        {
            this.context = context;
        }

     /* Constracor */      public RepositryAllModels(HR_Context context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        // All Models 
        public virtual T Add(T item)
        {
            var entity = context.Set<T>().Add(item).Entity;
            context.SaveChanges();
            return entity;
        }

        public async Task<T> Delete(Guid id)
        {
           
                var get =  context.Set<T>()
                
                .FirstOrDefault(x => x.id == id);

            if (get == null)
            {
                return null;
            }
            context.Set<T>().Remove(get);
            await context.SaveChangesAsync();
            return get;
        }

        public async Task<List<V>> GetAll()
        {
            var getAll =await context.Set<T>().ToListAsync();
            var maps = mapper.Map<List<V>>(getAll).ToList();
            return maps;
        }
        public async Task<List<T>> GetAllT()
        {
            var getAll = await context.Set<T>().ToListAsync();
            return getAll;
        }
        public async Task<V?> GetById(Guid id)
        {
            var get =await context.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.id == id);

            if (get == null)
            {
                return null;
            }

            var map=mapper.Map<V?>(get);

            return map;
        }

        public async Task<T> Put(Guid id, T item)
        {
            var get =await GetById(id)?? null;
            try
            {
                context.Set<T>().Update(item);

                 context.SaveChanges();
            }
            catch (Exception exp)
            {
                throw new Exception("An error occurred while updating the entity.", exp);
            }

            return item;
        }


        public async Task<T> UpdateAsync(Guid id, JsonPatchDocument<T> json)
        {
            var get = context.Set<T>().Find(id);
            if (get == null)
            {
                return null;
            }

            var mapping = mapper.Map<T>(get);
            json.ApplyTo(mapping);

            var added = mapper.Map(mapping, get);

            context.SaveChanges();

            return added;
        }

















        public async Task<List<T>> GetAllEmplyeeAndSalarys()
        {
            var get = context.Set<T>()
                            .Include("salaries")
                            .ToList();
            return get;
        }



        // Controller : City , return LIST Employees 
        public async Task<List<T>> GetEmployeesInCity()
        {
            Console.WriteLine("asd");
            var getlist =await context
                                    .Set<T>()
                                    .Include("employees")
                                    .ToListAsync();

            return getlist;

        }




















        //هذه الدوال خاصة بهذا الكلاس

        private async Task<T?> getPrivate(Guid id)
        {
            var get =await context.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.id == id);

            if (get == null)
            {
                return null;
            }
            return get;
        }

        
    }
    
}
