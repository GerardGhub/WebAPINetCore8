using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using WebAPINetCore8.Modal;
using WebAPINetCore8.Service;

namespace WebAPINetCore8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        public CustomerController(ICustomerService service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await this._service.Getall();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("Getbycode")]
        public async Task<IActionResult> Getbycode(string code)
        {
            var data = await this._service.Getbycode(code);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);    
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CustomerModal _data)
        {
            var data = await this._service.Create(_data);
            return Ok(data);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(CustomerModal _data, string code)
        {
            var data = await this._service.Update(_data, code);
            return Ok(data);    
        }

        [HttpDelete("Delete")]

        public async Task<IActionResult> Remove(string code)
        {
            var data = await this._service.Remove(code);
            return Ok(data);
        }

    }
}
