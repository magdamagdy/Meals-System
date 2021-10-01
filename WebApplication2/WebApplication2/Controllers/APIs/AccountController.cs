using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Data.Models;
using WebApplication2.Services.View_Models;

namespace WebApplication2.Controllers.APIs
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        UserManager<User> userManager;
        private readonly IConfigurationSection _jwtSettings;
        public AccountController(UserManager<User> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            _jwtSettings = configuration.GetSection("JwtSettings");
        }
        public object Login(LoginCredentials cred /*string email,string password*/)
        {
            var user = userManager.FindByEmailAsync(cred.email).Result;

            if (user == null)
            {
                return new { IsSuccess = false, };
            }
            var result = userManager.CheckPasswordAsync(user, cred.password).Result;
            if (result)
            {
                var signingCredentials = GetSigningCredentials();
                var claims = GetClaims(user);
                var tokenOptions = GenerateTokenOptions(signingCredentials, claims.Result);
                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return new { IsSuccess = true, Data = token, };
            }
            return new { IsSuccess = false, };
        }

        [AllowAnonymous] // to be able to access with token instead of username and password
        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("securityKey").Value);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha512);
        }


        [AllowAnonymous]
        private async Task<List<Claim>> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email)
            };
            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        [AllowAnonymous]
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtSettings.GetSection("validIssuer").Value,
                audience: _jwtSettings.GetSection("validAudience").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings.GetSection("expiryInMinutes").Value)),
                signingCredentials: signingCredentials);

            return tokenOptions;
        }
    }
}
