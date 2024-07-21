using Data.Contexts;
using Entity.Entites;
using Entity.Services;
using Entity.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProService:IProService
    {
        private readonly HotelDbContext _dbContext;

        public ProService(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
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
                await _dbContext.Rooms.AddAsync(room);

                // Değişiklikleri kaydet
                await _dbContext.SaveChangesAsync();

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
}
