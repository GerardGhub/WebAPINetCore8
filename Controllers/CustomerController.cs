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
    }
}
