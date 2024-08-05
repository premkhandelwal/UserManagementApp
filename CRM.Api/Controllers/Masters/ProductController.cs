using Microsoft.AspNetCore.Mvc;
using CRM.Api.Models.Masters;
using CRM.Api.Models.UserManagementRequests;
using CRM.Admin.Data;
using CRM.Admin.Service.Models;

namespace CRM.Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ClientApplicationDbContext _context;

        public ProductController(ClientApplicationDbContext clientApplicationDbContext)
        {
            _context = clientApplicationDbContext;
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductModel product)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to add Product!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            product.AddedOn = DateTime.Now;
            product.IsDeleted = false;
            await _context.Products!.AddAsync(product);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Product created successfully!!";
                response.StatusCode = 201;
                return StatusCode(StatusCodes.Status201Created, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpGet("ReadProducts")]
        public IActionResult ReadProducts()
        {
            List<ProductModel> result = _context.Products!.Where(product => product.IsDeleted == false).ToList();
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductModel product)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to update Product!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            var existingProduct = await _context.Products!.FindAsync(product.Id);
            if (existingProduct == null)
            {
                response.Response = "Product not found!!";
                response.StatusCode = 404;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }

            existingProduct.ProductName = product.ProductName;

            _context.Update(existingProduct);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Product updated successfully!!";
                response.StatusCode = 200;
                return StatusCode(StatusCodes.Status200OK, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromBody] ProductModel product)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to delete Product!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            var existingProduct = await _context.Products!.FindAsync(product.Id);
            if (existingProduct == null)
            {
                response.Response = "Product not found!!";
                response.StatusCode = 404;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }

            existingProduct.IsDeleted = true;
            _context.Update(existingProduct);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Product deleted successfully!!";
                response.StatusCode = 200;
                return StatusCode(StatusCodes.Status200OK, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }
    }
}
