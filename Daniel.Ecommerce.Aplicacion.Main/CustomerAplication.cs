using Daniel.Ecommece.Domain.Core;
using Daniel.Ecommerce.Aplicacion.Dto;
using Daniel.Ecommerce.Domain.Entity;
using Daniel.Ecommerce.Aplicacion.Interface;
using Daniel.Ecommerce.Transversal.Common;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using Daniel.Ecommerce.Tranversal.Domain.Interfaces;
using System.Collections.ObjectModel;


namespace Daniel.Ecommerce.Aplicacion.Main
{
    public class CustomerAplication : ICustomerAplication
    {
        private readonly IMapper _mapper;
        private readonly ICustomersDomian _customersDomian;
        public CustomerAplication(IMapper mapper, ICustomersDomian customersDomian)
        {
            _mapper = mapper;
            _customersDomian = customersDomian;
        }

        public Response<bool> Delete(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _customersDomian.Delete(customerId);
                if (response.Data == true)
                {
                    response.IsSuccess = true;
                    response.Message = "Clientes Borrado";

                }
            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;

            }
            return response;
        }
        public async Task<Response<bool>> DeleteAsync(CustomerDto customerDto)
        {
            // eliminar por id, no por obejto cambiar
            var response = new Response<bool>();
            try
            {
                var customer =  _mapper.Map<Customer>(customerDto);
                response.Data = await _customersDomian.DeleteAsync(customer);
                if (response.Data == true) response.IsSuccess = true;

            }catch(Exception ex)
            {
                response.Message= ex.Message;   

            }
            return response;
        }

     

        public Response<IEnumerable<CustomerDto>> GetAllCustomers()
        {
            var response = new Response<IEnumerable<CustomerDto>>();
            try
            {
                var customers = _customersDomian.GetAllCustomers();
                var customersDto = _mapper.Map<CustomerDto>(customers);

                  if(customersDto != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Datos obtenidos";


                }

            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<IEnumerable<CustomerDto>>> GetAllCustomersAsync()
        {
            var response = new Response<IEnumerable<CustomerDto>>();
            try
            {
                var customers = await _customersDomian.GetAllCustomersAsync();
                var customersDto = _mapper.Map<IEnumerable<CustomerDto>>(customers);

                response.Data = customersDto;
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Datos obtenidos";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;

            }
            return response;
        }

        public Response<CustomerDto> GetCustomer(string customerId)
        {
            
            var response = new Response<CustomerDto>();
            try
            {
                var customer = _customersDomian.GetCustomer(customerId);
                var customerDto = _mapper.Map<CustomerDto>(customer);
                response.Data = customerDto;
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Datos obtenidos";
                }
            } catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;

            }
            return response;




        }

        public async Task<Response<CustomerDto>> GetCustomerAsync(string customerId)
        {
            var response = new Response<CustomerDto>();
            try
            {
                var customer = await _customersDomian.GetCustomerAsync(customerId);
                var customerDto = _mapper.Map<CustomerDto>(customer);
                response.Data = customerDto;
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Datos obtenidos";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;

            }
            return response;
        }

        public Response<bool> Insert(CustomerDto customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customerDto);
                response.Data = _customersDomian.Insert(customer);

                if (response.Data == true)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro exitoso";
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;


        }

        public async Task<Response<bool>> InsertAsync(CustomerDto customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customerDto);
                response.Data = await _customersDomian.InsertAsync(customer);
                if (response.Data == true)
                {
                    response.IsSuccess = true;
                    response.Message = "Cliente registrado";
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;

            }
            return response;
        }

        public Response<bool> Update(CustomerDto customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customerDto);
                response.Data =_customersDomian.Update(customer);
                // falta validar
                if(response.Data == true)
                {

                    response.IsSuccess = true;
                    response.Message = "Cliente actualiado";
                }

            }
            catch(Exception ex)
            {
                response.Message = ex.Message;

            }
            return response;
        }

        public async Task<Response<bool>> UpdateAsync(CustomerDto customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customerDto);
                response.Data = await _customersDomian.UpdateAsync(customer);
                if (response.Data == true)
                {

                    response.IsSuccess = true;
                    response.Message = "Cliente actualiado";
                }



            }
            catch( Exception ex) 
            {
                response.Message = ex.Message;

            }
            return response;

            
        }
    }
}
