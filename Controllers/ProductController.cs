using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiBeta.Data;
using WebApiBeta.Models;

namespace WebApiBeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductDbContext _db;
        public ProductController(ProductDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public List<ProductEntity> GetProducts()
        {
            return _db.Products.ToList();
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

        [HttpPost]
        public ActionResult<ProductEntity> AddProducts([FromBody] ProductEntity productEntity)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            _db.Products.Add(productEntity);
            _db.SaveChanges();
            return Ok(productEntity);

        }


        [HttpPut("UpdateProducts")]
        public ActionResult<ProductEntity> UpdateProducts(int id , [FromBody] ProductEntity productEntity)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();

            }

            var product = _db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            { return NotFound(); }

            product.Name = productEntity.Name;
           
            product.Price = productEntity.Price;

            _db.Products.Add(productEntity);
            _db.SaveChanges();
            return Ok(productEntity);

        }

        //Delete method 
        [HttpDelete]
        public ActionResult<ProductEntity> UpdateProducts(int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();

            }

            var product = _db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            { return NotFound(); }

           

            _db.Products.Remove(product);
            _db.SaveChanges();
            return NoContent();

        }
    }
}
