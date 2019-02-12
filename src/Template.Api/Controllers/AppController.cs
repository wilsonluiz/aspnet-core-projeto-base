using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Template.Api.Controllers
{
    [Route("app")]
    public class AppController : Controller
    {
        [HttpGet("index")]
        [Authorize(Policy = "ObrigatorioPerfilAdmin")]
        public IActionResult Index()
        {
            return View();
        }

    }
}
