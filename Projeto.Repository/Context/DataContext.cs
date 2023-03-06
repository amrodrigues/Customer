using Projeto.Entities;
using Projeto.Repository.Mappings;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext(): base(ConfigurationManager.ConnectionStrings["aula"].ConnectionString) 
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
        }

        public DbSet<Customer> Customer { get; set; }
    }
}
