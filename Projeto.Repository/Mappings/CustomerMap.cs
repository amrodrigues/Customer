using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Projeto.Repository.Mappings
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            ToTable("Customer");

            HasKey(c => c.IdCustomer);

            Property(c => c.IdCustomer)
                .HasColumnName("idCustomer")
                .IsRequired();

            Property(c => c.CPF)
                .HasColumnName("CPF")
                .HasMaxLength(11)
                .IsRequired();

            Property(c => c.Name)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsRequired();

            Property(c => c.DateOfBirth)
               .HasColumnName("DateOfBirth")
               .IsRequired();
        }
    }
}
