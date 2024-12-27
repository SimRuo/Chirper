using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Chirper.Data;
using Chirper.Models;

namespace Chirper.Controllers
{
    /* nothing here is actually used, will need to implement proper API calls later, right now the services just use the entity framework to interact with the database directly */
    [Route("api/[controller]")]
    [ApiController]
    public class ChirpsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ChirpsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetChirps()
        {
            var chirps = await _context.Chirps.ToListAsync();
            return Ok(chirps);
        }

        [HttpPost]
        public async Task<IActionResult> AddChirp([FromBody] Chirp chirp)
        {
            if (chirp == null || string.IsNullOrWhiteSpace(chirp.Content))
            {
                return BadRequest("Invalid chirp data.");
            }

            chirp.CreatedAt = DateTime.UtcNow;
            _context.Chirps.Add(chirp);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetChirps), new { id = chirp.Id }, chirp);
        }
    }
}