using Microsoft.AspNetCore.Mvc;
using OrderApp.ApplicationCore.Contracts.Service;
using OrderApp.ApplicationCore.Model.Request;
using OrderApp.ApplicationCore.Model.Response;

namespace OrderApp.WebAPiApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderServiceAsync _orderService;

    public OrderController(IOrderServiceAsync orderService)
    {
        _orderService = orderService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return Ok(orders);
    }

    [HttpPost]
    public async Task<IActionResult> SaveOrder(OrderRequestModel model)
    {
        var result = await _orderService.AddOrderAsync(model);
        if (result > 0)
        {
            return CreatedAtAction(nameof(GetOrderById), new { id = model.Id }, model);
        }
        return BadRequest();
    }

    [HttpGet("customer/{customerId}")]
    public async Task<IActionResult> GetOrderByCustomerId(int customerId)
    {
        var orders = await _orderService.GetOrdersByCustomerIdAsync(customerId);
        return Ok(orders);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        if (order != null)
        {
            return Ok(order);
        }
        return NotFound();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var result = await _orderService.DeleteOrderAsync(id);
        if (result > 0)
        {
            return Ok("Order has been deleted successfully");
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrder(int id, OrderRequestModel order)
    {

        var result = await _orderService.UpdateOrderAsync(id,order);
        if (result > 0)
        {
            return Ok("Order has been updated");
        }
        return NotFound();
    }
    
}