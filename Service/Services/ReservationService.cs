using Data.Contexts;
using Entity.Entites;
using Entity.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ReservationService : IReservationService
    {
        private readonly HotelDbContext _context;

        public ReservationService(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reservation>> GetReservationsByHotelAndDateRange(int hotelId, DateTime checkInDate, DateTime checkOutDate)
        {
            return await _context.Reservations
                .Include(r => r.Room)
                .Where(r => r.Room.HotelId == hotelId &&
                            ((r.CheckInDate >= checkInDate && r.CheckInDate <= checkOutDate) ||
                             (r.CheckOutDate >= checkInDate && r.CheckOutDate <= checkOutDate)))
                .ToListAsync();
        }
    }
}
