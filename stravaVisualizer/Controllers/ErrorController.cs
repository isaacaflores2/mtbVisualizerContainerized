using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace StravaVisualizer.Controllers
{    
    [AllowAnonymous]
    public class ErrorController : Controller
    {        
        public IActionResult Index()
        {                        
            return View();
        }

        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}