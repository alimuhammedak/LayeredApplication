using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _orderService.GetAll();
        if (result.IsSuccess) return Ok(result);
        return BadRequest(result.Message);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
        var result = _orderService.GetOrderById(id);
        if (result.IsSuccess) return Ok(result);
        return BadRequest(result.Message);
    }

    [HttpGet("getByTime")]
    public IActionResult GetByTime(DateTime begin, DateTime end)
    {
        var result = _orderService.GetByTime(begin, end);

        if (result.IsSuccess) return Ok(result);

        return BadRequest(result.Message);
    }

    [HttpPost("add")]
    public IActionResult AddProduct(Order order)
    {
        var result = _orderService.OrderAdd(order);
        if (result.IsSuccess) return Ok(result.Message);

        return BadRequest(result.Message);
    }
}