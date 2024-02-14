using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApiBeta.Controllers;
using WebApiBeta.Data;
using WebApiBeta.Models;


namespace WebApiBeta.Services
{
    public class ProductService : IProductService 
    {
        private ProductDbContext _db;
        public ProductService(ProductDbContext db)
        {
            _db = db;
        }

        public ActionResult GetProduct()
        {
            var products = _db.Products.ToList();  

            return new ObjectResult(products)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        //method for adding product 
       public ActionResult<ProductEntity> AddProduct(ProductEntity productEntity)
        {
           var products = _db.Products.Add(productEntity);
            _db.SaveChanges();
            return new ObjectResult(products)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        //method for updating product 
        public ActionResult<ProductEntity> UpdateProduct(int id , ProductEntity productEntity)
        {
            if (id <= 0)
            {
                return new BadRequestObjectResult("Invalid id");
            }

            var product = _db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return new ObjectResult("Product not found");
            }
            product.Name = productEntity.Name;
            product.Price = productEntity.Price;

            
            _db.SaveChanges();
            return new ObjectResult(product);
                
        }

        //method for deleting product 
        public ActionResult DeleteProduct(int id)
        {
            if (id <= 0)
            {
                return new BadRequestObjectResult("Invalid id");
            }
            var product = _db.Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return new ObjectResult("Product not found");
            }
           
            _db.Products.Remove(product);
            _db.SaveChanges();
            return new ObjectResult("Removed");
           
        }

    }
}
