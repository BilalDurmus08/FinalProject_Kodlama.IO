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
        [HttpGet]
        public List<Product> Get()
        {
            var result = _ProductService.GetAll();
            return result.Data;


        }

    }

}
