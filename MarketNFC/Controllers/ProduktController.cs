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
    [Route("api/produkt")]
    [ApiController]
    public class ProduktController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ProduktService produktService;


        public ProduktController(ApplicationDbContext context)
        {
            _context = context;
            produktService = new ProduktService(context);
        }

        // GET: api/Produkt
        [HttpGet]
        public IEnumerable<Produkt> GetProdukty()
        {
            return produktService.GetProdukty();
        }

        [HttpGet("bytag/{tag}")]
        public async Task<IActionResult> ByTag([FromRoute] string tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //   var produkt = await _context.Produkty.FindAsync(id);
            var produkt = produktService.GetByTag(tag);

            if (produkt == null)
            {
                return NotFound();
            }

            return Ok(produkt);
        }

        // GET: api/Produkt/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProdukt([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //   var produkt = await _context.Produkty.FindAsync(id);
            var produkt = produktService.GetProdukt(id);

            if (produkt == null)
            {
                return NotFound();
            }

            return Ok(produkt);
        }

        // PUT: api/Produkt/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdukt([FromRoute] int id, [FromBody] Produkt produkt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produkt.ProduktId)
            {
                return BadRequest();
            }

            _context.Entry(produkt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduktExists(id))
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

        // POST: api/Produkt
        [HttpPost]
        public async Task<IActionResult> PostProdukt([FromBody] Produkt produkt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var res = produktService.PostProdukt(produkt);

            if (res)
                return Ok();
            else
                return Accepted();
        }

        // DELETE: api/Produkt/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdukt([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produkt = await _context.Produkty.FindAsync(id);
            if (produkt == null)
            {
                return NotFound();
            }

            _context.Produkty.Remove(produkt);
            await _context.SaveChangesAsync();

            return Ok(produkt);
        }

        private bool ProduktExists(int id)
        {
            return _context.Produkty.Any(e => e.ProduktId == id);
        }
    }
}