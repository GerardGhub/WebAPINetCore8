using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPINetCore8.Modal;
using WebAPINetCore8.Service;

namespace WebAPINetCore8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(UserModal _data)
        {
            var data = await this._service.Create(_data);
            return Ok(data);
        }



    }
}
