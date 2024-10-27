using hw_01._11._24.Core.Interfaces;
using hw_01._11._24.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hw_01._11._24.API.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers([FromQuery] int skip = 0, [FromQuery] int take = 20)
        {
            var customers = await _customerService.GetCustomers(skip, take);

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById([FromRoute] int id)
        {
            var customer = await _customerService.GetCustomerById(id);

            if (customer is null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> AddCustomer([FromBody] Customer customer)
        {
            try
            {
                var createdCustomer = await _customerService.AddCustomer(customer);

                return Created($"customers/{createdCustomer.Id}", createdCustomer);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> UpdateCustomer([FromRoute] int id, [FromBody] Customer customer)
        {
            try
            {
                var updatedCustomer = await _customerService.UpdateCustomer(id, customer);

                return Ok(updatedCustomer);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer([FromRoute] int id)
        {
            try
            {
                await _customerService.DeleteCustomer(id);

                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
