using Data.Contexts;
using Entity.Entites;
using Entity.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelDbContext _context;

        public HotelRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<List<Hotel>> GetAvailableHotelsAsync(DateTime CheckInDate, DateTime CheckOutDate)
        {
            var availableHotels = await _context.Hotels
            .Where(h => h.Rooms.Any(r => r.Reservations.All(rez => !(rez.CheckOutDate <= CheckInDate || rez.CheckInDate >= CheckOutDate))))
            .ToListAsync();

            return availableHotels;
        }
    }
}
