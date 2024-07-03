using Daniel.Ecommerce.Domain.Entity;
using Daniel.Ecommerce.Infrastructure.Interface;
using Daniel.Ecommerce.Tranversal.Domain.Interfaces;
using System.Collections.Generic;

namespace Daniel.Ecommece.Domain.Core
{
    public class CustomersDomain : ICustomersDomian
        // implementacion de laz interfaces (uso de estas)
    {
        private readonly ICustomersRepository _customersRepository;
        public CustomersDomain(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }
        public bool Insert(Customer customer)
        {
            return _customersRepository.Insert(customer);
        }
        public async Task<bool> InsertAsync(Customer customer)
        {
            return await _customersRepository.InsertAsync(customer);
        }
       public bool Delete(string customerId)
        {
            return _customersRepository.Delete(customerId);
        }

        Task<bool> ICustomersDomian.DeleteAsync(Customer customer)
        {
            return _customersRepository.DeleteAsync(customer);

        }

        IEnumerable<Customer> ICustomersDomian.GetAllCustomers()
        {
            return _customersRepository.GetAllCustomers();
        }

        Task<IEnumerable<Customer>> ICustomersDomian.GetAllCustomersAsync()
        {
            return _customersRepository.GetAllCustomersAsync();
        }

        Customer ICustomersDomian.GetCustomer(string customerId)
        {
            return _customersRepository.GetCustomer(customerId);    
        }
        // otra forma de escribirlo
        Task<Customer> ICustomersDomian.GetCustomerAsync(string customerId) => _customersRepository.GetCustomerAsync(customerId);

        Task<bool> ICustomersDomian.InsertAsync(Customer customer)
        {
           return _customersRepository.InsertAsync(customer);
        }

        bool ICustomersDomian.Update(Customer customer)
        {
            return _customersRepository.Update(customer);   
        }

        Task<bool> ICustomersDomian.UpdateAsync(Customer customer)
        {
              return _customersRepository.UpdateAsync(customer);
        }
    }
}
