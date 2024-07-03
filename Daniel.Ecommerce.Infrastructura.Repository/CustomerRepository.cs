using Daniel.Ecommerce.Domain.Entity;
using Daniel.Ecommerce.Infrastructure.Interface;
using Daniel.Ecommerce.Transversal.Common;
using Dapper;
using System.Threading;
using System.Data;
using System.Security.Cryptography.X509Certificates;
namespace Daniel.Ecommerce.Infrastructura.Repository
{
    // implementacion de las interfaces
    public class CustomerRepository : ICustomersRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public CustomerRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        #region Sincronos
        public bool Insert(Customer customer)
        {
            using (var connection = _connectionFactory.GetDbConnection)
            {
                var query = "CustomersInsert";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTitle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);
                //executar el proceso almacenado junto con los parametros
                var resulto = connection.Execute(query, parameters, commandType: CommandType.StoredProcedure);

                return resulto > 0;



            }
            

        }

        public bool Update(Customer customer)
        {
            using (var connection = _connectionFactory.GetDbConnection)
            {
                var query = "CustomersUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTitle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);
                //executar el proceso almacenado junto con los parametros
                var resulto = connection.Execute(query, parameters, commandType: CommandType.StoredProcedure);

                return resulto > 0;



            }
        }
        public bool Delete(string customerId)
        {
            using (var connection = _connectionFactory.GetDbConnection)
            {
                var query = "CustomersDelete";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);
               
                //executar el proceso almacenado junto con los parametros
                var resulto = connection.Execute(query, parameters, commandType: CommandType.StoredProcedure);

                return resulto > 0;



            }
        }
        public Customer GetCustomer(string customerId)
        {
            using (var connection = _connectionFactory.GetDbConnection)
            {
                var query = "CustomersGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);

                //executar el proceso almacenado junto con los parametros
                var customer = connection.QuerySingle<Customer>(query, param: parameters, commandType: CommandType.StoredProcedure);


                return customer;

            }


        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            using (var connection = _connectionFactory.GetDbConnection)
            {
                var query = "CustomersList";
                

                //executar el proceso almacenado junto con los parametros
                var customers = connection.Query<Customer>(query, commandType: CommandType.StoredProcedure);


                return customers;

            }


        }
        #endregion

        #region
        public async Task<bool> InsertAsync(Customer customer)
        {
            using (var connection = _connectionFactory.GetDbConnection)
            {
                var query = "CustomersInsert";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTitle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);
                //executar el proceso almacenado junto con los parametros
                var resulto = await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);

                return resulto > 0;



            }


        }
        public async Task<bool> UpdateAsync(Customer customer)
        {
            using (var connection = _connectionFactory.GetDbConnection)
            {
                var query = "CustomersInsert";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTitle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);
                //executar el proceso almacenado junto con los parametros
                var resulto = await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);

                return resulto > 0;


            }


        }
        public async Task<bool> DeleteAsync(Customer customer)
        {
            using (var connection = _connectionFactory.GetDbConnection)
            {
                var query = "CustomersInsert";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customer.CustomerId);
               
                //executar el proceso almacenado junto con los parametros
                var resulto = await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);

                return resulto > 0;

            }


        }
        public async Task<Customer> GetCustomerAsync(string customerId)
        {
            using (var connection = _connectionFactory.GetDbConnection)
            {
                var query = "CustomerGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);

                //executar el proceso almacenado junto con los parametros
                var customer = await connection.QuerySingleAsync<Customer>(query, param: parameters, commandType: CommandType.StoredProcedure);


                return customer;

            }


        }
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            using (var connection = _connectionFactory.GetDbConnection)
            {
                var query = "CustomersList";


                //executar el proceso almacenado junto con los parametros
                var customers = await connection.QueryAsync<Customer>(query, commandType: CommandType.StoredProcedure);


                return customers;

            }


        }

        #endregion


    }
}
