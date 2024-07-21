using AutoMapper;
using Data.Contexts;
using Data.UnitOfWorks;
using Entity.Entites;
using Entity.Services;
using Entity.UnitOfWorks;
using Entity.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class RoomService : IRoomService
{
    private readonly HotelDbContext _context;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    public RoomService(HotelDbContext context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
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
    public async Task<bool> Add(RoomViewModel roomViewModel)
    {
        try
        {
            // RoomViewModel'den Room nesnesi oluştur
            var room = new Room
            {
                HotelId = roomViewModel.HotelId,
                RoomNumber = roomViewModel.RoomNumber,
                Type = roomViewModel.Type,
                Price = roomViewModel.Price,
                Description = roomViewModel.Description,
                IsAvailable = roomViewModel.IsAvailable,
                PictureUrl = roomViewModel.PictureUrl,
                City = roomViewModel.City,
                Country = roomViewModel.Country
            };

            // Veritabanına yeni Room nesnesini ekle
            await _context.Rooms.AddAsync(room);

            // Değişiklikleri kaydet
            await _context.SaveChangesAsync();

            // Ekleme işlemi başarılı ise true döndür
            return true;
        }
        catch (Exception ex)
        {
            // Hata mesajı logla
            Console.WriteLine($"Oda ekleme işlemi sırasında hata oluştu: {ex.Message}");
            // Hata durumu için false döndür
            return false;
        }
    }

    public async Task<List<RoomViewModel>> Get(int hotelId)
    {
        var rooms = await _context.Rooms
    .Where(r => r.HotelId == hotelId) // HotelId ile filtreleme yapıyoruz
    .Select(r => new RoomViewModel
    {
        RoomId = r.RoomId,
        HotelId = r.HotelId,
        Description = r.Description,
        Price = r.Price,
        PictureUrl = r.PictureUrl,
        City = r.Hotel.City,
        Country = r.Hotel.Country
        // Diğer özellikler
    })
    .ToListAsync();

        return rooms;

    }

    public async Task<IEnumerable<RoomViewModel>> GetAll()
    {
        var list = await unitOfWork.GetRepository<Room>().GetAllAsync();
        return mapper.Map<List<RoomViewModel>>(list);
    }
    public async Task<List<Room>> GetRoomsByHotelId(int hotelId)
    {
        return await _context.Rooms.Where(r => r.HotelId == hotelId).ToListAsync();
    }

    public async Task<RoomViewModel> GetRoomById(int roomId)
    {
        var room = await _context.Rooms.FirstOrDefaultAsync(r => r.RoomId == roomId);
        if (room == null) return null;

        return new RoomViewModel
        {
            RoomId = room.RoomId,
            HotelId = room.HotelId,
            RoomNumber = room.RoomNumber,
            Type = room.Type,
            Price = room.Price,
            Description = room.Description,
            IsAvailable = room.IsAvailable,
            PictureUrl = room.PictureUrl
        };
    }

    public async Task Update(RoomViewModel model)
    {
        var existingRoom = await _context.Rooms.FirstOrDefaultAsync(r => r.RoomId == model.RoomId);

        if (existingRoom != null)
        {
            // Mevcut odayı güncelle
            existingRoom.RoomNumber = model.RoomNumber;
            existingRoom.Type = model.Type;
            existingRoom.Price = model.Price;
            existingRoom.Description = model.Description;
            existingRoom.IsAvailable = model.IsAvailable;
            existingRoom.PictureUrl = model.PictureUrl;

            // Veritabanındaki değişiklikleri kaydet
            await _context.SaveChangesAsync();
        }
    }
    public async Task Delete(int id)
    {
        var existingHotel = await _context.Rooms.FirstOrDefaultAsync(h => h.RoomId == id);


        _context.Rooms.Remove(existingHotel);
        await unitOfWork.CommitAsync();

    }

    public async Task<List<RoomViewModel>> GetRoomsRoomId(int hotelId)
    {
        return await _context.Rooms
      .Where(r => r.HotelId == hotelId)
      .Select(r => new RoomViewModel
      {
          RoomId = r.RoomId,
          HotelId = r.HotelId,
          RoomNumber = r.RoomNumber,
          Type = r.Type,
          Price = r.Price,
          Description = r.Description,
          IsAvailable = r.IsAvailable,
          PictureUrl = r.PictureUrl,
          City = r.Hotel.City,
          Country = r.Hotel.Country
      })
      .ToListAsync();
    }

    public async Task<RoomViewModel> DeleteRoom(int RoomId)
    {
        var room = await _context.Rooms.FindAsync(RoomId);

        if (room == null)
        {
            return null; // veya  return new RoomViewModel(); 
        }
        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();

        // Silinen odayı temsil eden yeni bir RoomViewModel oluştur
        var deletedRoom = new RoomViewModel
        {
            RoomId = room.RoomId,
            // Diğer gerekli property'leri kopyala
        };

        return deletedRoom; // Silinen odayı temsil eden yeni nesneyi döndür
    }

    public async Task<bool> AddRoom(RoomViewModel roomViewModel)
    {
        
        try
        {
            // RoomViewModel'den Room nesnesi oluştur
            var room = new Room
            {
                HotelId = roomViewModel.HotelId,
                RoomNumber = roomViewModel.RoomNumber,
                Type = roomViewModel.Type,
                Price = roomViewModel.Price,
                Description = roomViewModel.Description,
                IsAvailable = roomViewModel.IsAvailable,
                PictureUrl = roomViewModel.PictureUrl,
                City = roomViewModel.City,
                Country = roomViewModel.Country
            };

            // Veritabanına yeni Room nesnesini ekle
            await _context.Rooms.AddAsync(room);

            // Değişiklikleri kaydet
            await _context.SaveChangesAsync();

            // Ekleme işlemi başarılı ise true döndür
            return true;
        }
        catch (Exception ex)
        {
            // Hata mesajı logla
            Console.WriteLine($"Oda ekleme işlemi sırasında hata oluştu: {ex.Message}");
            // Hata durumu için false döndür
            return false;
        }
    }
}