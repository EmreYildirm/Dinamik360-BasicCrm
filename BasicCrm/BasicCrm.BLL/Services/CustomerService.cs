using BasicCrm.BLL.IServices;
using BasicCrm.DAL.UnitOfWork;
using System;
using BasicCrm.Entities;
using System.Collections.Generic;
using System.Text;

namespace BasicCrm.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteCustomer(Customer customer)
        {
            _unitOfWork.Customers.Remove(customer);
            _unitOfWork.Commit();
        }

        public List<Customer> GetAllCustomers()
        {
            return _unitOfWork.Customers.GetAll();
        }

        public Customer GetCustomerById(int? id)
        {
            return _unitOfWork.Customers.GetById(id);
        }

        public void InsertCustomer(Customer customer)
        {
            _unitOfWork.Customers.Add(customer);
            _unitOfWork.Commit();
        }

        public void UpdateCustomer(Customer customer)
        {
            _unitOfWork.Customers.Update(customer);
            _unitOfWork.Commit();
        }
    }
}
