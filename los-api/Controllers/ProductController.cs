using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using los_api.Models;
using los_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;

namespace los_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            this._service = service;
        }
        

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody]ProductModel model)
        {
            var result = new ResultModel();
            try
            {
                await _service.AddProduct(model);
                result.success = true;
                result.Message = "Add Product Success.";
                result.StatucCode = 200;
                return Ok(result);
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.StatucCode = 400;
                return BadRequest(result);
            }

        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody]ProductModel model)
        {
            var result = new ResultModel();
            try
            {
                await _service.UpdateProduct(model);
                result.success = true;
                result.Message = "Update Product Success.";
                result.StatucCode = 200;
                return Ok(result);
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.StatucCode = 400;
                return BadRequest(result);
            }

        }
        
        [HttpDelete]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            var result = new ResultModel();
            try
            {
                await _service.DeleteProduct(id);
                result.success = true;
                result.Message = "Update Product Success.";
                result.StatucCode = 200;
                return Ok(result);
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.StatucCode = 400;
                return BadRequest(result);
            }

        }
    }
}