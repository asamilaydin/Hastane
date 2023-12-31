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
            var poliklinikler = _databaseContext.Poliklinikler.Include(x => x.AnaBilimDali).ToList();
            return View(poliklinikler);
        }

        public IActionResult YeniPoliklinik()
        {

            List<SelectListItem> dallar = (from x in _databaseContext.AnaBilimDallari.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.dgr = dallar;
            return View();
        }
        [HttpPost]
        public IActionResult YeniPoliklinik(Poliklinik p)
        {
            var existingPoliklinik = _databaseContext.Poliklinikler.FirstOrDefault(x => x.Name == p.Name);

            if (existingPoliklinik != null)
            {
                var mesaj = "Poliklinik Zaten Kayıtlı";
                ViewBag.deger = mesaj;
                return RedirectToAction("PoliklinikIndex");
            }
            var pol = _databaseContext.AnaBilimDallari.Where(x => x.Id == p.AnaBilimDali.Id).FirstOrDefault();
            p.AnaBilimDali = pol;
            _databaseContext.Add(p);
            _databaseContext.SaveChanges();

            return RedirectToAction("PoliklinikIndex");
        }
        public IActionResult PoliklinikSil(Guid id)
        {
            var silinecek = _databaseContext.Poliklinikler.FirstOrDefault(abd => abd.Id ==id);
            if (silinecek != null)
            {
                _databaseContext.Poliklinikler.Remove(silinecek);
                _databaseContext.SaveChanges();
            }
            return RedirectToAction("PoliklinikIndex");
        }

        public IActionResult PoliklinikGetir(Guid id)
        {
            var pol = _databaseContext.Poliklinikler.FirstOrDefault(pol => pol.Id == id);

            return View(pol);
        }

        public IActionResult PoliklinikGuncelle(Poliklinik pol)
        {
            var poliklinik_1 = _databaseContext.Poliklinikler.FirstOrDefault(abd => abd.Id == pol.Id);

            poliklinik_1.Name = pol.Name;
            _databaseContext.SaveChanges();
            return RedirectToAction("PoliklinikIndex");
        }
        public IActionResult DoktorIndex()
        {
            var doktorlar = _databaseContext.Doktorlar.Include(x => x.poliklinik).ToList();
            return View(doktorlar);
        }
        public IActionResult YeniDoktor()
        {

            List<SelectListItem> Pol = (from x in _databaseContext.Poliklinikler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.dgr = Pol;
            return View();
        }
        [HttpPost]
        public IActionResult YeniDoktor(Doktor d)
        {

            var doc = _databaseContext.Poliklinikler.Where(x => x.Id == d.poliklinik.Id).FirstOrDefault();
            d.poliklinik = doc;
            _databaseContext.Add(d);
            _databaseContext.SaveChanges();

            return RedirectToAction("DoktorIndex");
        }

        public IActionResult DoktorSil(Guid id)
        {
            var silinecek = _databaseContext.Doktorlar.FirstOrDefault(doc => doc.Id == id);
            if (silinecek != null)
            {
                _databaseContext.Doktorlar.Remove(silinecek);
                _databaseContext.SaveChanges();
            }
            return RedirectToAction("DoktorIndex");
        }

        public IActionResult DoktorGetir(Guid id)
        {
            var doc = _databaseContext.Doktorlar.FirstOrDefault(doc => doc.Id == id);

            return View(doc);
        }
        public IActionResult DoktorGuncelle(Doktor doc)
        {
            var docc = _databaseContext.Doktorlar.FirstOrDefault(abd => abd.Id == doc.Id);

            docc.Name = doc.Name;
            _databaseContext.SaveChanges();
            return RedirectToAction("DoktorIndex");
        }

        public IActionResult KullaniciIndex()
        {
            var kullanicilar = _databaseContext.Users.ToList();
            return View(kullanicilar);
        }
        public IActionResult KullaniciSil(Guid id)
        {
            var silinecek = _databaseContext.Users.FirstOrDefault(abd => abd.UserID == id);

            _databaseContext.Users.Remove(silinecek);
            _databaseContext.SaveChanges();
            return RedirectToAction("KullaniciIndex");
        }
        public IActionResult KullaniciGetir(Guid id)
        {
            var usr = _databaseContext.Users.FirstOrDefault(abd => abd.UserID == id);

            return View(usr);
        }
        public IActionResult KullaniciGuncelle(User user)
        {
            var usr = _databaseContext.Users.FirstOrDefault(abd => abd.UserID == user.UserID);

            usr.Name = user.Name;
            usr.Surname = user.Surname;
            _databaseContext.SaveChanges();
            return RedirectToAction("KullaniciIndex");
        }

    }
}

 