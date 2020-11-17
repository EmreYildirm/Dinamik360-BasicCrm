using BasicCrm.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCrm.DAL.Configurations
{
    public class CustomerConfiguration
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(c => c.CustomerId);

            builder
                .Property(c => c.CustomerId)
                .UseIdentityColumn();

            builder
                .Property(c => c.CompanyName)
                .IsRequired()
                .HasMaxLength(50);


            builder
                .Property(c => c.Address).HasMaxLength(70);

            builder
                .Property(c => c.Phone).IsRequired().HasMaxLength(11);


            builder.ToTable("Customers");
        }
    }
}
