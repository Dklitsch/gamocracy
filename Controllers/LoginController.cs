using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gamocracy.Models;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;

namespace gamocracy.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public partial class LoginController : ControllerBase
    {
        private readonly GamocracyContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AuthOptions _authOptions;

        public LoginController(GamocracyContext context, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, 
            IOptions<AuthOptions> authOptions)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _authOptions = authOptions.Value;
        }

        // POST: Login
        [HttpPost]
        public async Task<ActionResult<string>> PostLogin(LoginInputModel input)
        {
            var result = await _signInManager.PasswordSignInAsync(input.Email, input.Password, false, lockoutOnFailure: false);
            var userId =  _userManager.FindByEmailAsync(input.Email).Result.Id;

            if (!result.Succeeded)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authOptions.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
