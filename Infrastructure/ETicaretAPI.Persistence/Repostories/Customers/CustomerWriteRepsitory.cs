using System;
using ETicaretAPI.Application.Repostories.Customers;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;

namespace ETicaretAPI.Persistence.Repostories.Customers
{
    public class CustomerWriteRepsitory : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepsitory(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}

