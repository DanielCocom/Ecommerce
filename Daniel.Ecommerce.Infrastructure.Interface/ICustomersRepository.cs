using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daniel.Ecommerce.Domain.Entity;

namespace Daniel.Ecommerce.Infrastructure.Interface
{
    //Definicion de los metodos
    public interface ICustomersRepository
    {
        #region Metodos Sincronos
        bool Insert(Customer customer);
        bool Update(Customer customer);
        bool Delete(string customerId);
        Customer GetCustomer(string customerId);
        IEnumerable<Customer> GetAllCustomers();

        #endregion

        #region
        Task<bool> InsertAsync(Customer customer);
        Task<bool> UpdateAsync(Customer customer);
        Task<bool> DeleteAsync(Customer customer);
        Task<Customer> GetCustomerAsync(string customerId);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();


        #endregion
    }
}
