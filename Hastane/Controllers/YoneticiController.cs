using System;
using Hastane.Data;
using Hastane.Models;
using Microsoft.AspNetCore.Mvc;
using NETCore.Encrypt.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Hastane.Entities;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hastane.Controllers
{
    
    [Authorize(Roles ="admin")]
    public class YoneticiController : Controller
    {
        private readonly ApplicationDbContext _databaseContext;

        public YoneticiController(ApplicationDbContext databaseContext)
        {
            _databaseContext = databaseContext;
            
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AnaBilimDali()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AnaBilimDali(AnaBilimDaliViewModel anaBilimDalı)
        {
            if (ModelState.IsValid)
            {
                AnaBilimDali yeniDal = new()
                {
                    Name = anaBilimDalı.Name
                };
              _databaseContext.AnaBilimDallari.Add(yeniDal);
                int affectedRowCount = _databaseContext.SaveChanges();

                if (affectedRowCount == 0)
                {
                    ModelState.AddModelError("", "User can not be added.");
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(anaBilimDalı);

        }

      



    }
}

