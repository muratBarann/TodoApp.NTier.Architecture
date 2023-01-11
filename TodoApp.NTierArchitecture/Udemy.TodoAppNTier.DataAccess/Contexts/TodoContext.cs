using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.TodoAppNTier.DataAccess.Configurations;
using Udemy.TodoAppNTier.Entities.Domains;

namespace Udemy.TodoAppNTier.DataAccess.Contexts
{
    public class TodoContext :DbContext
    {

        //Dependecy olarak burada DBContextOptions'ile birlikte tanımladık
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorkConfiguration());
        }
        public DbSet<Work> Works{ get; set; }

    }
}
