using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPINetCore8.Modal;
using WebAPINetCore8.Repos;

namespace WebAPINetCore8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly LearndataContext _context;
        private readonly JwtSettings _jwtSettings;
        public AuthorizeController(LearndataContext context, IOptions<JwtSettings> options)
        {
            this._context = context;
            this._jwtSettings = options.Value;
        }

        [HttpPost("GenerateToken")]
       public async Task<IActionResult> GenerateToken([FromBody] UserCred userCred)
        {
            var user = await this._context.TblUsers.FirstOrDefaultAsync(item => item.Code == userCred.Username && item.Password == userCred.Password);
            if (user != null)
            {
                //generate token
                var tokenhandler = new JwtSecurityTokenHandler();
                var tokenkey = Encoding.UTF8.GetBytes(this._jwtSettings.SecurityKey);
                var tokendesc = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Code),
                        new Claim(ClaimTypes.Role, user.Role)
                    }),
                    Expires = DateTime.UtcNow.AddSeconds(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
                };
                
                var token = tokenhandler.CreateToken(tokendesc);
                var finaltoken = tokenhandler.WriteToken(token);
                return Ok(finaltoken);
            }
            else
            {
                return Unauthorized();
            }

        }

    }
}
