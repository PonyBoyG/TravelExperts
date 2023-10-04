using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExpertManagement.Data.Models;

namespace TravelExpertManagement.BLL.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IList<Customer>> GetAllCustomers();
        Task<Customer> GetCustomer(int id);
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer> UpdateCustomer(Customer customer);
        Task<Customer> DeleteCustomer(int id);
    }
}
