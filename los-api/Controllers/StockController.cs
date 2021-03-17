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
    public class StockController : ControllerBase
    {
        private readonly IStockService _service;

        public StockController(IStockService service)
        {
            this._service = service;
        }
        

        [HttpPost]
        public async Task<IActionResult> AddStock([FromBody]StockModel model)
        {
            var result = new ResultModel();
            try
            {
                await _service.AddStock(model);
                result.success = true;
                result.Message = "Add Stock Success.";
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
        public async Task<IActionResult> UpdateStock([FromBody]StockModel model)
        {
            var result = new ResultModel();
            try
            {
                await _service.UpdateStock(model);
                result.success = true;
                result.Message = "Update Stock Success.";
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
        public async Task<IActionResult> RemoveStock(int id)
        {
            var result = new ResultModel();
            try
            {
                await _service.DeleteStock(id);
                result.success = true;
                result.Message = "Update Stock Success.";
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