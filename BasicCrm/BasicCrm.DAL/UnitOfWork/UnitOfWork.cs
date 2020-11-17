using BasicCrm.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCrm.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly BasicCrmDbContext _context;
        private CustomerRepository _customerRepository;

        public UnitOfWork(BasicCrmDbContext context)
        {
            _context = context;
        }


        public ICustomerRepository Customers => _customerRepository = _customerRepository ?? new CustomerRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
