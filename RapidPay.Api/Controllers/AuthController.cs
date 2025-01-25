using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RapidPay.Persistence.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RapidPay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public const string secret = "ThisIsATestingKeyForThisApplicationOnly";
        [HttpPost]
        public IActionResult Authenticate([FromBody] LoginUser user)
        {
            if (user.Username == "user" && user.Password == "password")
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim("user", user.Username)
                };

                var token = new JwtSecurityToken(
                    issuer: "RapidPay",
                    audience: "RapidPay",
                    claims,
                    expires: DateTime.Now.AddHours(8),
                    signingCredentials: credentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new { Token = tokenString });
            }

            return Unauthorized("Invalid Credentials");
        }
    }
}
