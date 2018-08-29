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
    [Route("api/upodobania")]
    [ApiController]
    public class UpodobaniaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UpodobaniaService upodobaniaService;


        public UpodobaniaController(ApplicationDbContext context)
        {
            _context = context;
            upodobaniaService = new UpodobaniaService(context);
        }

        [HttpGet("calculate/{id}")]
        public async Task<IActionResult> CalculateUpodobanie([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            upodobaniaService.ObliczUpodobaniaUzytkownika(id);

            return Ok();
        }

        [HttpGet("ordertime/{id}")]
        public async Task<IActionResult> GetDayAndTimeSystemOr([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = upodobaniaService.GetDayAndTimeSystemOrder(id);

            if(!(order.Day >= 1 && order.Day <=7))
            {
                return NotFound();
            }

            return Json(order);
        }

        [HttpPost("ordertime/{id}")]
        public async Task<IActionResult> PostDayAndTimeSystemOr([FromRoute] string id,
            [FromBody] SystemOrderViewModel order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            upodobaniaService.PostDayAndTimeSystemOrder(id, order);

            return Ok();
        }

        [HttpGet("systemorder/{id}")]
        public async Task<IActionResult> SystemOrder([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var zamowienie = upodobaniaService.SystemOrder(id);          

            if (zamowienie != null)
            {
                _context.Zamowienia.Add(zamowienie);
                _context.SaveChanges();

                return Json(zamowienie.Produkty);
            }
            else
            {
                return NoContent();
            }
        }
        
    }
}