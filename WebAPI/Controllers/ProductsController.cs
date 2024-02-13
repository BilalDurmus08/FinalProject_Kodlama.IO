using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Loosely Coupled
        //Naming Convention
        //IoC Container --> Inversion of Control
        IProductService _ProductService;
        public ProductsController(IProductService productService)
        {
                _ProductService = productService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _ProductService.GetAll();
            if(result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id) 
        {
            var result = _ProductService.GetByProductId(id);
            if(result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _ProductService.Add(product);
            if(result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


    }

}
