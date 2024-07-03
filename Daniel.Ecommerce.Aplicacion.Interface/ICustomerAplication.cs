using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daniel.Ecommerce.Aplicacion.Dto;
using Daniel.Ecommerce.Transversal.Common;


namespace Daniel.Ecommerce.Aplicacion.Interface
{
    public interface ICustomerAplication
    {

        #region definicion de los metodos
        Response<bool> Insert(CustomerDto customer);
        Response<bool> Update(CustomerDto customer);
        Response<bool> Delete(string customerId);
        Response<CustomerDto> GetCustomer(string customerId);
        Response<IEnumerable<CustomerDto>> GetAllCustomers();

        #endregion

        #region
        public Task<Response<bool>> InsertAsync(CustomerDto customerDto);
        public Task<Response<bool>> UpdateAsync(CustomerDto customerDto);
        public Task<Response<bool>> DeleteAsync(CustomerDto customerDto);
        public Task<Response<CustomerDto>> GetCustomerAsync(string customerId);
        Task<Response<IEnumerable<CustomerDto>>> GetAllCustomersAsync();
        #endregion

    }
}
