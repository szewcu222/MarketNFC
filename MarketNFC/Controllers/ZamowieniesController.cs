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
    [Route("api/zamowienie")]
    [ApiController]
    public class ZamowieniesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ZamowieniesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Zamowienie
        [HttpGet]
        public IEnumerable<Zamowienie> GetZamowienia()
        {
            return _context.Zamowienia
                .Include("ZamowienieProdukty.Produkt");
        }

        // GET: api/Zamowienie/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetZamowienie([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var zamowienie = _context.Zamowienia
                .Include("ZamowienieProdukty.Produkt")
                .Where(z => z.ZamowienieId == id);

            if (zamowienie == null)
            {
                return NotFound();
            }

            return Ok(zamowienie);
        }

        // PUT: api/Zamowienie/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZamowienie([FromRoute] int id, [FromBody] Zamowienie zamowienie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zamowienie.ZamowienieId)
            {
                return BadRequest();
            }

            _context.Entry(zamowienie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZamowienieExists(id))
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

        // POST: api/Zamowienie
        [HttpPost]
        public async Task<IActionResult> PostZamowienie([FromBody] Zamowienie zamowienie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Zamowienia.Add(zamowienie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZamowienie", new { id = zamowienie.ZamowienieId }, zamowienie);
        }

        // DELETE: api/Zamowienie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZamowienie([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var zamowienie = await _context.Zamowienia.FindAsync(id);
            if (zamowienie == null)
            {
                return NotFound();
            }

            _context.Zamowienia.Remove(zamowienie);
            await _context.SaveChangesAsync();

            return Ok(zamowienie);
        }

        private bool ZamowienieExists(int id)
        {
            return _context.Zamowienia.Any(e => e.ZamowienieId == id);
        }

        // GET: api/Zamowienie/user/5
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetZamowienieUzytkownika([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var zamowienie = await _context.Zamowienia.FindAsync(id);

            var zamowienie = _context.Zamowienia
                .Where(z => z.UzytkownikId == id)
                .Include("ZamowienieProdukty.Produkt");
                //.Include(e => e.)

            //foreach (var zam in zamowienie)
            //{
            //    var produkt = _context.Produkty
            //        //.Where(p => p.ZamowienieProdukty == zam.ZamowienieProdukty)
            //        .Include("ZamowienieProdukty.Zamowienie")
            //        .FirstOrDefault();
            //    zam.Produkty.Add(produkt);
            //}


            if (zamowienie == null)
            {
                return NotFound();
            }

            return Ok(zamowienie);
        }
    }
}