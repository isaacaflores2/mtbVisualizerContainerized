using System.Collections.Generic;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace StravaVisualizer.Controllers
{    
    public class ErrorController : Controller
    {                       
        public IActionResult Index()
        {                        
            return View();
        }
    }
}