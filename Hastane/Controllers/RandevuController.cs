using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Hastane.Entities;
using Hastane.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hastane.Controllers
{
    [Authorize]
    public class RandevuController : Controller
    {

        private readonly ApplicationDbContext _databaseContext;

        public RandevuController(ApplicationDbContext databaseContext)
        {
            _databaseContext = databaseContext;

        }
        public IActionResult RandevuAl()
        {
            SelectList anabilim = new SelectList(_databaseContext.AnaBilimDallari, "Id", "Name");
            RandevuAlViewModel model = new RandevuAlViewModel()
            {

                AnaBilimDallari = anabilim,

                // Başlangıçta şehir verisi yoktur ama kayıt düzenleme yaparsanız burayı da doldurunuz.
                Poliklinikler = new SelectList(new List<Poliklinik>()),
                Doktorlar = new SelectList(new List<Doktor>())
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult RandevuAl(RandevuAlViewModel model)
        {
            // Model içinde gönderdiğimiz citiesData ve countriesData verileri View'dan alınmaz.
            // POST işlemi sonrasında aynı sayfa tekrar açılacak ise, 
            // Model e  değerlerini tekrar yüklemeliyiz. 
            // Bu verileri bir Cache mekanizmasından yükleyerek sürekli DB ye gitme gerekliliği kaldırabilirsiniz.
            // Performans açısından da daha doğru olacaktır. Tabii veriler sürekli değişmiyorsa..!
            SelectList AnaBilimDallarii = new SelectList(_databaseContext.AnaBilimDallari, "Id", "Name");
            SelectList Polikliniklerr = new SelectList(_databaseContext.Poliklinikler, "Id", "Name");
            SelectList Doktorlarr = new SelectList(_databaseContext.Doktorlar, "Id", "Name");
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            Randevu randevu = new()
            {
                AnaBilimDaliId = model.SelectedAnaBilimDaliId,
                PoliklinikId = model.SelectedPoliklinikId,
                DoktorId = model.SelectedDoktorId,
                RandevuTarihi = model.RandevuTarihi,
                UserId =userId
               
            };

            _databaseContext.Randevular.Add(randevu);
            _databaseContext.SaveChanges();

            model.AnaBilimDallari = AnaBilimDallarii;
            model.Poliklinikler = Polikliniklerr;
            model.Doktorlar = Doktorlarr;

            return View(model);
        }
        public JsonResult GetCitiesByCountry(Guid id)
        {
            return Json(
                _databaseContext.Poliklinikler.Where(ci => ci.AnaBilimDaliId == id).ToList());
        }
        public JsonResult GetCitiesByCountr(Guid id)
        {
            return Json(
                _databaseContext.Doktorlar.Where(ci => ci.PoliklinikId == id).ToList());
        }


        public IActionResult Randevularım()
            {
                return View();
            }
        }
    }
