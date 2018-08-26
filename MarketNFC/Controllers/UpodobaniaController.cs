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
    public class UpodobaniaController : ControllerBase
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

        

        
        private bool ProduktExists(int id)
        {
            return _context.Produkty.Any(e => e.ProduktId == id);
        }
    }
}