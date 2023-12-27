using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hastane.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using Hastane.Models;
using NETCore.Encrypt.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hastane.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _databaseContext;

        public AdminController(ApplicationDbContext databaseContext)
        {
            _databaseContext = databaseContext;

        }
        public IActionResult Index()
        {
            var anaBilimDallari = _databaseContext.AnaBilimDallari.ToList();
            return View(anaBilimDallari);
        }
        public IActionResult YeniAnaBilimDali()
        {

            return View();
        }
        [HttpPost]
        public IActionResult YeniAnaBilimDali(AnaBilimDali yeniDal)
        {
            _databaseContext.Add(yeniDal);
            _databaseContext.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult AnaBilimDaliSil(Guid id)
        {
            var silinecek = _databaseContext.AnaBilimDallari.FirstOrDefault(abd => abd.Id == id);

            _databaseContext.AnaBilimDallari.Remove(silinecek);
            _databaseContext.SaveChanges();
            return RedirectToAction("index");
        }


        public IActionResult AnaBilimDaliGetir(Guid id)
        {
            var dal = _databaseContext.AnaBilimDallari.FirstOrDefault(abd => abd.Id == id);

            return View(dal);
        }
        public IActionResult AnaBilimDaliGuncelle(AnaBilimDali anaBilim)
        {
            var dal = _databaseContext.AnaBilimDallari.FirstOrDefault(abd => abd.Id == anaBilim.Id);

            dal.Name = anaBilim.Name;
            _databaseContext.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult PoliklinikIndex()
        {
            var poliklinikler = _databaseContext.Poliklinikler.Include(x=>x.AnaBilimDali).ToList();
            return View(poliklinikler);
        } 

    }
}

 