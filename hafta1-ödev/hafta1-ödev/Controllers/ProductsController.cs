
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace hafta1_ödev.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Ürün 1", Price = 10.99M }, //"10.99M" represents the decimal number "10.99" in decimal type
            new Product { Id = 2, Name = "Ürün 2", Price = 20.49M },
            new Product { Id = 3, Name = "Ürün 3", Price = 15.99M }
        };

        // Endpoint that fetches all products
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_products);
        }

        // Endpoint that fetches a specific product by ID
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound("Product not found!");
            return Ok(product);
        }

        // Endpoint that creates a new product
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (product == null)
                return BadRequest("Invalid request!");

            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        // Endpoint that updates an existing product
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
                return NotFound("Product not found!");

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;

            return NoContent();
        }

        // Endpoint that deletes a product by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound("Product not found!");

            _products.Remove(product);

            return NoContent();
        }

        // Endpoint that lists and sorts the products
        [HttpGet("list")]
        public IActionResult ListProducts([FromQuery] string name = "")
        {
            var filteredProducts = _products.Where(p => string.IsNullOrEmpty(name) || p.Name.Contains(name)).ToList();
            return Ok(filteredProducts);
        }
    }
}
