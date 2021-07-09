using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TT_Education_webAPI.API.ViewModels;

namespace TT_Education_webAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(LoginModel loginModel)
        {
            try
            {
                if (loginModel == null)
                {
                    throw new Exception("Login Model not found!");
                }
                var user = GetUser(loginModel.Login, loginModel.Password);
                if (user == null)
                {
                    throw new Exception("User or password does not match!");
                }
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Config.SecurityKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                { 
                    Issuer = Config.ValidIssuer,
                    Subject = new ClaimsIdentity(
                        new Claim[] { 
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName.ToString()),
                            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Aud, Config.ValidAudience),
                            new Claim(ClaimTypes.Role, "ApiUser") }),
                    Expires = DateTime.UtcNow.AddHours(24),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var result = tokenHandler.WriteToken(token);
            return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message    }   );
            }
        }

        private IdentityUser GetUser(string login, string password)
        {
            //total mock
            if(string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password) || !login.Equals("my_test_login") || !password.Equals("my_test_password"))
            {
                return null;
            }
            //mock of user database repository here
            return new IdentityUser()
            {
                Id = "",
                Email = "",
                UserName = ""
            };
        }
    }
}
