using Microsoft.AspNetCore.Mvc;
using QuantumStore;
using System.Collections.Generic;


namespace QuantumStore
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _customerService;

        public OrderController(IOrderService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("all")]
        public IActionResult GetAllOrders()
        {
            var customers = _customerService.GetAllOrders();
            return Ok(customers);
        }

        [HttpGet("getby{id}")]
        public IActionResult GetOrderById(int id)
        {
            var customer = _customerService.GetOrderById(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost("add")]
        public IActionResult AddOrder([FromBody] OrderDTO customerDTO)
        {
            if (_customerService.AddOrder(customerDTO))
                return Ok("Order added successfully");
            return BadRequest("Failed to add customer.");
        }

        [HttpPut("update{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] OrderDTO customerDTO)
        {
            if (id != customerDTO.Id) return BadRequest("ID mismatch.");
            if (_customerService.UpdateOrder(customerDTO))
                return Ok("Order Updated Successfully");
            return NotFound("Order not Found");
        }

        [HttpDelete("delete{id}")]
        public IActionResult DeleteOrder(int id)
        {
            if (_customerService.DeleteOrder(id))
                return Ok("Order Deleted Successfully");
            return NotFound("Order not Found");
        }
    }
}