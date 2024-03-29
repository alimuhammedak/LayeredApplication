using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    //Loosely coupled
    //IoC Container -- Inversion of Control
    private readonly IProductService _productService; //naming convention

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("getAll")]
    public IActionResult GetAll()
    {
        var result = _productService.GetAll();
        if (result.IsSuccess) return Ok(result.Data);

        return BadRequest(result.Message);
    }

    [HttpGet("getById")]
    public IActionResult GetById(int id)
    {
        var result = _productService.GetProductById(id);
        if (result.IsSuccess) return Ok(result.Data);

        return BadRequest(result.Message);
    }

    [HttpPost("add")]
    public IActionResult Add(Product product)
    {
        var result = _productService.Add(product);
        if (result.IsSuccess) return Ok(result.Message);
        return BadRequest(result.Message);
    }
}