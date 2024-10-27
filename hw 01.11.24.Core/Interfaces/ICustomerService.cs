using hw_01._11._24.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_01._11._24.Core.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomers(int skip = 0, int take = 20);

        Task<Customer?> GetCustomerById(int id);

        Task<Customer> AddCustomer(Customer customer);

        Task<Customer> UpdateCustomer(int id, Customer customer);

        Task DeleteCustomer(int id);
    }
}
