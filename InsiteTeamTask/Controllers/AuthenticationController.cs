using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using InsiteTeamTask.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace InsiteTeamTask.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly string _username = "fortress";
        private readonly string _password = "insite";

        [HttpPost]
        public IActionResult Login([FromBody]Login login)
        {
            if (string.IsNullOrWhiteSpace(login.Username) ||
                string.IsNullOrWhiteSpace(login.Password))
                return BadRequest("Login details not valid");

            if (login.Username.ToLower() == _username && login.Password == _password)
            {
                // If the username/password are correct, return a JWT which expires in 10 minutes time
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@987"));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44376/",
                    audience: "https://localhost:44376/",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: signingCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                // If username/password doesn't match, return 401 Unauthorised
                return Unauthorized();
            }
        }
    }
}
