using BasicCrm.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCrm.DAL.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetById(int? id);
        List<Customer> GetAll();
        void Add(Customer entity);
        void Remove(Customer entity);
        void Update(Customer entity);
    }
}
