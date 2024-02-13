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
            var products = _db.Products.ToList();  // Assuming Products is a DbSet in your DbContext

            return new ObjectResult(products)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }

    }
}
