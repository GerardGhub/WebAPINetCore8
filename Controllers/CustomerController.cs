using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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


    }
}
