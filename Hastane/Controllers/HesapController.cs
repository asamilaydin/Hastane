using System;
using Hastane.Data;
using Hastane.Models;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hastane.Controllers
{
    public class HesapController : Controller
    {

        private readonly ApplicationDbContext _databaseContext;

        public HesapController(ApplicationDbContext databaseContext)
        {
            _databaseContext = databaseContext;
            
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);

        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {

            }
            return View(model);
            
        }


    }
}


