using BookStore.Auth.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("login")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] User user, [FromServices] AccessManager accessManager)
        {
            if (accessManager.ValidateCredentials(user))
            {
                var token = accessManager.GenerateToken(user);
                return Ok(token);
            }

            var authError = new
            {
                Authenticated = false,
                Message = "Falha na autenticação"
            };
            return BadRequest(authError);
        }
    }
}
