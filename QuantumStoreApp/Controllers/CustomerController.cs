using Microsoft.AspNetCore.Mvc;
using QuantumStore;
using System.Collections.Generic;


namespace QuantumStore
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("all")]
        public IActionResult GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("getby{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost("add")]
        public IActionResult AddCustomer([FromBody] CustomerDTO customerDTO)
        {
            if (_customerService.AddCustomer(customerDTO))
                return Ok("Customer added successfully");
            return BadRequest("Failed to add customer.");
        }

        [HttpPut("update{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] CustomerDTO customerDTO)
        {
            if (id != customerDTO.Id) return BadRequest("ID mismatch.");
            if (_customerService.UpdateCustomer(customerDTO))
                return Ok("Customer Updated Successfully");
            return NotFound("Customer not Found");
        }

        [HttpDelete("delete{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            if (_customerService.DeleteCustomer(id))
                return Ok("Customer Deleted Successfully");
            return NotFound("Customer not Found");
        }
    }
}