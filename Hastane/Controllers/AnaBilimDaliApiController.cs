using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hastane.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hastane.Controllers
{
    [Route("api/[controller]")]
    public class AnaBilimDaliApiController : Controller
    {
        // GET: api/values
        private ApplicationDbContext _context;

        public AnaBilimDaliApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<DoctorApiController>
        [HttpGet]
        public List<AnaBilimDali> GetAllAnaBilimDali()
        {
            return _context.AnaBilimDallari.ToList();
        }

        // GET api/<DoctorApiController>/5
        [HttpGet("{id}")]
        public ActionResult<AnaBilimDali> GetAnaBilimDaliDetails(Guid id)
        {
            if (id == null) { return BadRequest(); }
            var AnaBilimDaliDetail = _context.AnaBilimDallari.FirstOrDefault(x => x.Id == id);

            if (AnaBilimDaliDetail == null) { return NotFound(); }
            return AnaBilimDaliDetail;
        }

        // POST api/<DoctorApiController>
        [HttpPost]
        public ActionResult<AnaBilimDali> AddAnaBilimDali([FromBody] AnaBilimDali anabilim)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            _context.AnaBilimDallari.Add(anabilim);
            _context.SaveChanges();

            return Ok(anabilim);
        }

        // PUT api/<UserApiController>/5
        [HttpPut("{id}")]
        public ActionResult<AnaBilimDali> UpdateDoctor(Guid id, [FromBody] AnaBilimDali anabilim)
        {
            if (anabilim == null) { return BadRequest(anabilim); }

            var AnaBilimDaliDetail = _context.AnaBilimDallari.FirstOrDefault(x => x.Id == id);

            if (AnaBilimDaliDetail == null) { return NotFound(); }

            AnaBilimDaliDetail.Name = anabilim.Name;
            
            _context.SaveChanges();

            return Ok(AnaBilimDaliDetail);
        }

        // DELETE api/<UserApiController>/5
        [HttpDelete("{id}")]
        public ActionResult<AnaBilimDali> Delete(Guid id)
        {

            var AnaBilimDaliDetail = _context.AnaBilimDallari.FirstOrDefault(x => x.Id == id);
            if (AnaBilimDaliDetail == null)
            {
                return NotFound();
            }
            _context.Remove(AnaBilimDaliDetail);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

