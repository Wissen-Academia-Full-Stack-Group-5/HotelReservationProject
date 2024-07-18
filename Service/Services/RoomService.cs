using Data.Contexts;
using Entity.Services;
using Entity.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class RoomService : IRoomService
{
    private readonly HotelDbContext _context;

    public RoomService(HotelDbContext context)
    {
        _context = context;
    }

    public async Task<List<RoomViewModel>> GetAvailableRooms(int hotelId, DateTime checkInDate, DateTime checkOutDate)
    {
        var reservedRooms = await _context.Reservations
            .Where(r => r.CheckInDate < checkOutDate && r.CheckOutDate > checkInDate)
            .Select(r => r.RoomId)
            .ToListAsync();

        var rooms = await _context.Rooms
            .Where(r => r.HotelId == hotelId)
            .Select(r => new RoomViewModel
            {
                RoomId = r.RoomId,
                RoomNumber = r.RoomNumber,
                Type = r.Type,
                Price = r.Price,
                Description = r.Description,
                IsAvailable = !reservedRooms.Contains(r.RoomId)
            })
            .ToListAsync();

        return rooms;
    }

    public async Task<List<RoomViewModel>> GetRoomsByHotel(int hotelId, DateTime checkInDate, DateTime checkOutDate)
    {
        var rooms = await _context.Rooms
            .Where(r => r.HotelId == hotelId)
            .Select(r => new RoomViewModel
            {
                RoomId = r.RoomId,
                RoomNumber = r.RoomNumber,
                Type = r.Type,
                Price = r.Price,
                Description = r.Description,
                PictureUrl = r.PictureUrl,
                IsAvailable = !_context.Reservations.Any(res => res.RoomId == r.RoomId &&
                                                               ((checkInDate >= res.CheckInDate && checkInDate <= res.CheckOutDate) ||
                                                                (checkOutDate >= res.CheckInDate && checkOutDate <= res.CheckOutDate)))
            }).ToListAsync();

        return rooms;
    }

    public async Task<List<RoomViewModel>> GetRoomsByHotelAndDateAsync(int hotelId, DateTime checkInDate, DateTime checkOutDate)
    {
        var rooms = await _context.Rooms
                .Where(r => r.HotelId == hotelId)
                .Select(r => new RoomViewModel
                {
                    RoomId = r.RoomId,
                    Type = r.Type,
                    RoomNumber = r.RoomNumber,
                    Price = r.Price,
                    Description = r.Description,
                    IsAvailable = !r.Reservations.Any(res => res.CheckInDate < checkOutDate && res.CheckOutDate > checkInDate)
                }).ToListAsync();

        return rooms;
    }
}
