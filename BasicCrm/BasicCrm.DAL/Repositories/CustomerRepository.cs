using BasicCrm.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BasicCrm.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BasicCrmDbContext _context;
        public CustomerRepository(BasicCrmDbContext context)
        {
            _context = context;
        }

        public void Add(Customer entity)
        {
            _context.Database.ExecuteSqlCommand
                ("InsertCustomer @p0,@p1,@p2", new[] { entity.CompanyName, entity.Address, entity.Phone });
        }

        public List<Customer> GetAll()
        {
            return _context.Customers.FromSqlRaw("GetCustomers").ToList(); ;
        }

        public Customer GetById(int? id)
        {
            return _context.Customers.FromSqlRaw("GetCustomerById {0}", id)
                .ToList()
                .FirstOrDefault();
        }

        public void Remove(Customer entity)
        {
            _context.Database.ExecuteSqlCommand("DeleteCustomer {0}", entity.CustomerId);
        }

        public void Update(Customer entity)
        {
            _context.Database.ExecuteSqlCommand("UpdateCustomer @CustomerId = {0}, @CompanyName = {1}, @Address = {2}, @Phone = {3}", entity.CustomerId, entity.CompanyName, entity.Address, entity.Phone);
        }
    }
}
