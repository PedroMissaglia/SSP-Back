using Microsoft.EntityFrameworkCore;
using superSecretProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace superSecretProject.Repository
{
    public class Context : DbContext
    {
       public DbSet<Users> Users { get; set; }

       public Context(DbContextOptions<Context> options) : base(options)
        {

        }

       public Context() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //String de Conexão do DB
            optionsBuilder.UseSqlServer(@"Server=PEDRO\SQLEXPRESS;Database=db_ssproject;User Id=sa; Password = Spectro@123;");
        }
    }
}
