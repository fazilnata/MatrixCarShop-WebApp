using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Car.Controllers
{
    public class SampleController1 : Controller
    {[HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("APIs up & running");
        }
    }
}
