using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Chirper.Data;
using Chirper.Models;


namespace Chirper.Services
{
    public class ChirpService
    {
        private readonly AppDbContext _context;

        public ChirpService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Chirp>> GetChirpsAsync()
        {
            return await _context.Chirps.ToListAsync();
        }

        public async Task AddChirpAsync(Chirp chirp)
        {
            _context.Chirps.Add(chirp);
            await _context.SaveChangesAsync();
        }
    }
}