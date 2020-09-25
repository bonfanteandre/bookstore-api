using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("application")]
    public class ApplicationController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Ok()
        {
            return Ok(new { Message = "Application is running" });
        }
    }
}
