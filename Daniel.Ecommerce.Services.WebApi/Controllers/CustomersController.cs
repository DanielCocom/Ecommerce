using Microsoft.AspNetCore.Mvc;
using Daniel.Ecommerce.Aplicacion.Interface;
using Daniel.Ecommerce.Aplicacion.Dto;
using Microsoft.AspNetCore.Authorization;


namespace Daniel.Ecommerce.Services.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomerAplication _customerAplication;
        public CustomersController(ICustomerAplication customerAplication)
        {
            _customerAplication = customerAplication;
        }
        #region Metodos Sincronos

        [HttpPost]
        public IActionResult Insert([FromBody] CustomerDto customerDto)
        {
            if (customerDto == null) return BadRequest();
            var customerInsert = _customerAplication.Insert(customerDto);
            if (customerInsert.IsSuccess)
            {
                return Ok(customerInsert);
            }
            return BadRequest(customerInsert);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CustomerDto customerDto)
        {
            if (customerDto == null) return BadRequest();

            var response = await _customerAplication.UpdateAsync(customerDto);
            if (response.IsSuccess) return Ok(response); else return BadRequest(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] CustomerDto customerDto)
        {
            if (customerDto == null) return BadRequest();
            var response = await _customerAplication.DeleteAsync(customerDto);
            if (response.IsSuccess) return Ok(response); else return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomer(string idCustomer)
        {
            if (idCustomer == null) return BadRequest();
            var response = await _customerAplication.GetCustomerAsync(idCustomer);
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response);

        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var response = await _customerAplication.GetAllCustomersAsync();
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response);

        }
        
        #endregion
    }
}
