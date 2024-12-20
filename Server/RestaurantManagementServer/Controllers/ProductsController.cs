using Microsoft.AspNetCore.Mvc;
using RestaurantManagementServer.Data;
using RestaurantManagementServer.Models.Dto.Add;
using RestaurantManagementServer.Models.Dto.Update;
using RestaurantManagementServer.Models.Entities;

namespace RestaurantManagementServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly FinalTermContext productContext;

        public ProductsController(FinalTermContext productContext)
        {
            this.productContext = productContext;
        }

        [HttpGet]
        public IActionResult getProduct()
        {
            var product = productContext.Products.ToList();

            return Ok(product);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult getProductById(int id)
        {
            var product = productContext.Products.Find(id);

            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult addProduct(AddProductDto addProductDto)
        {
            var products = new Product()
            {
                ProductName = addProductDto.ProductName,
                Price = addProductDto.Price,
                Quantity = addProductDto.Quantity,
                Description = addProductDto.Description,
                Image = addProductDto.Image,
                Type = addProductDto.Type
            };
            productContext.Products.Add(products);
            productContext.SaveChanges();
            return Ok(products);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult updateProduct(int id, UpdateProductDto updateProductDto)
        {
            var product = productContext.Products.Find(id);

            if (product is null)
            {
                return NotFound();
            }

            product.ProductName = updateProductDto.ProductName;
            product.Price = updateProductDto.Price;
            product.Quantity = updateProductDto.Quantity;
            product.Description = updateProductDto.Description;
            product.Image = updateProductDto.Image;
            product.Type = updateProductDto.Type;

            productContext.SaveChanges();
            return Ok(product);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult deleteProduct(int id)
        {
            var product = productContext.Products.Find(id);

            if (product is null)
            {
                return NotFound();
            }
            productContext.Products.Remove(product);
            productContext.SaveChanges();
            return Ok("Removed Success");
        }
    }
}
