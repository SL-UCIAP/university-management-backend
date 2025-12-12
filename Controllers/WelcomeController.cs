using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace university_management_service.Controllers
{
    [Route("/")]
    [ApiController]
    public class WelcomeController : ControllerBase
    {

        [HttpGet]
        public IActionResult Welcome()
        {
            return Ok("Welcome University Management System");
        }
        
    }
}