﻿using Microsoft.EntityFrameworkCore;
using Neximus.WorkShop.Domain.HumanResources.Customers;
using Neximus.WorkShop.Persistance.Infrastructures;
using Neximus.WorkShop.Services.HumanResources.Customers.Contracts;

namespace Neximus.WorkShop.Persistance.HumanResources.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DbSet<Customer> _customer;

        public CustomerRepository(EFDataContext context)
        {
            _customer = context.Customres;
        }

        public void Add(Customer customer)
        {
            _customer.Add(customer);
        }

        public void Delete(Customer customer)
        {
            _customer.Remove(customer);
        }

        public async Task<Customer?> FindById(string id)
        {
            return await _customer.FindAsync(id);
        }

        public void Update(Customer customer)
        {
            _customer.Update(customer);
        }
    }
}
