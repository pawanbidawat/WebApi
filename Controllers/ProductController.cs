using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiBeta.Data;
using WebApiBeta.Models;
using WebApiBeta.Services;

namespace WebApiBeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductDbContext _db;
        private IProductService _productService;
        public ProductController(ProductDbContext db , IProductService productService)
        {
            _db = db;
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public ActionResult GetProducts()
        {
            return _productService.GetProduct();
        }
     

        [HttpGet("GetProductDetail")]
        public ActionResult<ProductEntity> GetProductDetail(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var product = _db.Products.FirstOrDefault(x => x.Id == id);

            if(product == null)
            {
                return NotFound();
            }
            return product;


        }

        [HttpPost("AddProducts")]
        public ActionResult<ProductEntity> AddProducts( ProductEntity productEntity)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
           _productService.AddProduct(productEntity);
            return Ok(productEntity);

        }


        [HttpPut("UpdateProducts")]
        public ActionResult<ProductEntity> UpdateProducts(int id , [FromBody] ProductEntity productEntity)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            _productService.UpdateProduct(id, productEntity);

            return Ok(productEntity);

        }

        //Delete method 
        [HttpDelete ("Delete")]
        public ActionResult<ProductEntity> DeleteProducts(int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();

            }

           var message = _productService.DeleteProduct(id);
            return message;

        }
    }
}
