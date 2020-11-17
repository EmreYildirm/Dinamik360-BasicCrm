using BasicCrm.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCrm.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        void Commit();
    }
}
