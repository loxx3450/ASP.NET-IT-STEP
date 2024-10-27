using hw_01._11._24.Core.Interfaces;
using hw_01._11._24.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_01._11._24.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly List<Customer> _customers;
        private static int _idCounter = 4;

        public CustomerService()
        {
            _customers = new List<Customer>()
            {
                new Customer()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    PhoneNumber = "123-456-7890"
                },
                new Customer()
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@example.com",
                    PhoneNumber = "234-567-8901"
                },
                new Customer()
                {
                    Id = 3,
                    FirstName = "Bob",
                    LastName = "Johnson",
                    Email = "bob.johnson@example.com",
                    PhoneNumber = "345-678-9012"
                }
            };

        }

        public Task<IEnumerable<Customer>> GetCustomers(int skip = 0, int take = 20)
        {
            return Task.FromResult(_customers.Skip(skip).Take(take));
        }

        public Task<Customer?> GetCustomerById(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);

            return Task.FromResult(customer);
        }

        public Task<Customer> AddCustomer(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.FirstName)
                || string.IsNullOrEmpty(customer.LastName)
                || string.IsNullOrEmpty(customer.Email)
                || string.IsNullOrEmpty(customer.PhoneNumber))
            {
                throw new ArgumentException("Such fields as `FirstName`, `LastName`, `Email` and `PhoneNumber` should be initialized...");
            }

            customer.Id = _idCounter++;

            _customers.Add(customer);

            return Task.FromResult(customer);
        }

        public Task<Customer> UpdateCustomer(int id, Customer customer)
        {
            if (!CustomerExists(id))
            {
                throw new KeyNotFoundException();
            }

            customer.Id = id;

            var origCustomer = _customers.First(c => c.Id == id);

            int index = _customers.IndexOf(origCustomer);
            _customers[index] = customer;

            return Task.FromResult(customer);
        }

        public Task DeleteCustomer(int id)
        {
            if (!CustomerExists(id))
            {
                throw new KeyNotFoundException();
            }

            var origCustomer = _customers.First(c => c.Id == id);

            _customers.Remove(origCustomer);

            return Task.CompletedTask;
        }

        private bool CustomerExists(int id)
        {
            return _customers.Any(c => c.Id == id);
        }
    }
}
