using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hastane.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hastane.Controllers
{
    [Authorize]
    public class RandevuController : Controller
    {
        
        public IActionResult RandevuAl()
        {
        

            return View();
        }
        public IActionResult Randevularım()
        {
            return View();
        }
    }
}

