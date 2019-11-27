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

       public DbSet<Token> Token { get; set; }

        public DbSet<Tasks> Tasks { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

       public Context() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //String de Conexão do DB
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-G38B1L8\DEV2014;Database=VisionDB;User Id=sa; Password = Wagner231214!;");
        }
    }
}
