using BasicCrm.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BasicCrm.DAL
{
    public class BasicCrmDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Customer> Customers { get; set; }

        public BasicCrmDbContext(DbContextOptions<BasicCrmDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           builder.Entity<Customer>()
                .HasKey(c => c.CustomerId);

            builder.Entity<Customer>()
                .Property(c => c.CustomerId)
                .UseIdentityColumn();

            builder.Entity<Customer>()
                .Property(c => c.CompanyName)
                .IsRequired()
                .HasMaxLength(50);


            builder.Entity<Customer>()
                .Property(c => c.Address).HasMaxLength(70);

            builder.Entity<Customer>()
                .Property(c => c.Phone).IsRequired().HasMaxLength(11);


            builder.Entity<Customer>()
                .ToTable("Customers");

            base.OnModelCreating(builder);
        }
    }
}
