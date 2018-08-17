using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketNFC.Data;
using MarketNFC.Models;
using MarketNFC.Services;

namespace MarketNFC.Controllers
{
    [Route("api/lodowka")]
    [ApiController]
    public class LodowkaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly LodowkaService lodowkaService;

        public LodowkaController(ApplicationDbContext context)
        {
            _context = context;
            lodowkaService = new LodowkaService(context);
        }

        // GET: api/lodowka
        [HttpGet]
        public IEnumerable<Lodowka> GetLodowki()
        {
            return lodowkaService.GetLodowki();
        }

        // GET: api/lodowka/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLodowka([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lodowka = lodowkaService.GetLodowka(id);

            if (lodowka == null)
            {
                return NotFound();
            }

            return Ok(lodowka);
        }
        // bedzie sluzylo do edycji
        // tak naprawde bedzie sie podawalo id lodowki i lodowke z jednym produktem potem wyszukiwala ta lodowke i zmienialo jej ilosc produktow
        // mozna rozgraniczyc metody na deleteProdukt,editProdukt,addProdukt
        // wszystkie beda mialy podobna zasade i tez beda PUTami

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

            lodowka = lodowkaService.PutLodowka(id, lodowka);

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