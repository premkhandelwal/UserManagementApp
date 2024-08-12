﻿using Crm.Tenant.Service.Models.Requests.Product.CreateProduct;
using Crm.Tenant.Service.Models.Requests.Product.DeleteProduct;
using Crm.Tenant.Service.Models.Requests.Product.UpdateProduct;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest product)
        {
            var result = await _productService.CreateAsync(product);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest product)
        {
            var result = await _productService.UpdateAsync(product);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductRequest product)
        {
            var result = await _productService.DeleteAsync(product);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("ReadProducts")]
        public async Task<IActionResult> ReadProducts()
        {
            var result = await _productService.ReadAsync();
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
