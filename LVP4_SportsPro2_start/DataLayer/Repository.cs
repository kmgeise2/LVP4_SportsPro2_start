using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LVP4_SportsPro2_start.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        // ** Update sections below **
        protected SportsProContext context { get; set; }
        private DbSet<T> dbset { get; set; }
        public Repository(SportsProContext ctx)
        {
            context = ctx;
            dbset = context.Set<T>();
        }

        // get number of retrieved entities - use private backing field bc 
        // when filtering, count might be less than dbset.Count()
       

        // retrieve a list of entities
        

        // retrieve a single entity (3 overloads)
        

        // insert, update, delete, save
        

        // private helper method to build query expression
        
    }
}
