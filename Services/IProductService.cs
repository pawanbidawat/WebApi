using Microsoft.AspNetCore.Mvc;
using WebApiBeta.Models;

namespace WebApiBeta.Services
{
    public interface IProductService
    {
        //ActionResult<ProductEntity> UpdateProduct(int id, ProductEntity productEntity);
        //ActionResult<ProductEntity> AddProduct(ProductEntity productEntity);

        ActionResult GetProduct();
    }
}