using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gamocracy.Models;
using Microsoft.AspNetCore.Identity;

namespace gamocracy.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public partial class RegisterController : ControllerBase
    {
        private readonly StoryContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterController(StoryContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // POST: Register
        [HttpPost]
        public async Task<ActionResult<Boolean>> PostRegister(RegisterInputModel input)
        {
            var user = new IdentityUser { UserName = input.Email, Email = input.Email, EmailConfirmed = true };
            var result = await _userManager.CreateAsync(user, input.Password);

            return result.Succeeded;
        }
    }
}
