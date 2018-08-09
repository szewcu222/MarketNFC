using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketNFC.Data;
using MarketNFC.Models;

namespace MarketNFC.Controllers
{
    [Route("api/lodowka")]
    [ApiController]
    public class LodowkaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LodowkaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/lodowka
        [HttpGet]
        public IEnumerable<Lodowka> GetLodowka()
        {
            return _context.Lodowki
                .Include("StanLodowki.Produkt");
        }

        // GET: api/lodowka/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLodowka([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lodowka = _context.Lodowki
                .Include("StanLodowki.Produkt")
                .Where(l => l.LodowkaId == id);

            if (lodowka == null)
            {
                return NotFound();
            }

            return Ok(lodowka);
        }

        // PUT: api/lodowka/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLodowka([FromRoute] int id, [FromBody] Lodowka lodowka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lodowka.LodowkaId)
            {
                return BadRequest();
            }

            _context.Entry(lodowka).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LodowkaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/lodowka
        [HttpPost]
        public async Task<IActionResult> PostLodowka([FromBody] Lodowka lodowka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Lodowki.Add(lodowka);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLodowka", new { id = lodowka.LodowkaId}, lodowka);
        }

        // DELETE: api/lodowka/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLodowka([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lodowka = await _context.Lodowki.FindAsync(id);
            if (lodowka == null)
            {
                return NotFound();
            }

            _context.Lodowki.Remove(lodowka);
            await _context.SaveChangesAsync();

            return Ok(lodowka);
        }

        private bool LodowkaExists(int id)
        {
            return _context.Lodowki.Any(l => l.LodowkaId == id);
        }

        // // GET: api/lodowka/grupa/5
        // [HttpGet("grupa/{id}")]
        // public async Task<IActionResult> GetLodowkaGrupy([FromRoute] int id)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     //var zamowienie = await _context.Zamowienia.FindAsync(id);

        //     var lodowka = _context.Lodowki
        //         .Where(l => l.GrupaId == id)
        //         .Include("GrupaLodowka.Produkt");
        //         //.Include(e => e.)

        //     //foreach (var zam in zamowienie)
        //     //{
        //     //    var produkt = _context.Produkty
        //     //        //.Where(p => p.ZamowienieProdukty == zam.ZamowienieProdukty)
        //     //        .Include("ZamowienieProdukty.Zamowienie")
        //     //        .FirstOrDefault();
        //     //    zam.Produkty.Add(produkt);
        //     //}


        //     if (zamowienie == null)
        //     {
        //         return NotFound();
        //     }

        //     return Ok(zamowienie);
        // }
    }
}