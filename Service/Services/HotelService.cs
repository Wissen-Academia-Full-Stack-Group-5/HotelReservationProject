using AutoMapper;
using Data.Contexts;
using Data.Repositories;
using Data.UnitOfWorks;
using Entity.Entites;
using Entity.Repositories;
using Entity.Services;
using Entity.UnitOfWorks;
using Entity.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly HotelDbContext _context;

        public HotelService(IUnitOfWork uow, IMapper mapper, HotelDbContext context, IHotelRepository hotelRepository)
        {
            _uow = uow;
            _mapper = mapper;
            _context = context;
            _hotelRepository = hotelRepository;
        }

        public async Task<IEnumerable<HotelViewModel>> GetAll()
        {
            var list = await _uow.GetRepository<Hotel>().GetAllAsync();
            return _mapper.Map<List<HotelViewModel>>(list);
        }

        public Task Add(HotelViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<HotelViewModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<HotelViewModel>> GetFilteredHotels(DateTime checkInDate, DateTime checkOutDate, string city, string type)
        {
            var hotels = await _hotelRepository.GetAvailableHotelsAsync(checkInDate, checkOutDate, city, type);

            var hotelViewModels = hotels.Select(hotel => new HotelViewModel
            {
                HotelId = hotel.HotelId,
                Name = hotel.Name,
                Address = hotel.Address, // Address bilgisini ekliyoruz
                City = hotel.City,
                Country = hotel.Country,
                PictureUrl = hotel.PictureUrl
            }).ToList();

            return hotelViewModels;
        }

        public async Task<List<string>> GetCities()
        {
            return await _context.Hotels
                .Select(h => h.City)
                .Distinct()
                .ToListAsync();
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            return await _context.Hotels.FirstOrDefaultAsync(h => h.HotelId == id);

        }

        public List<HotelGroupViewModel> GetAllHotelsGroupedByCity()
        {
            var hotels = _context.Hotels.ToList();

            var groupedHotels = hotels
                .GroupBy(h => h.City)
                .Select(g => new HotelGroupViewModel
                {
                    City = g.Key,
                    Hotels = g.ToList()
                })
                .ToList();

            return groupedHotels;
        }

        public async Task<HotelViewModel> GetHotelByHotelId(int HotelId)
        {
            var article = await _uow.GetRepository<Hotel>().GetByIdAsync(HotelId);
            return _mapper.Map<HotelViewModel>(article);
        }

        public async Task Delete(int id)
        {
            var existingHotel = await _context.Hotels.FirstOrDefaultAsync(h => h.HotelId == id);

            if (existingHotel != null)
            {
                _context.Hotels.Remove(existingHotel);
                await _uow.CommitAsync();
            }
        }
        public async Task Update(HotelViewModel model)
        {
            var existingHotel = await _context.Hotels.FirstOrDefaultAsync(h => h.HotelId == model.HotelId);

            if (existingHotel != null)
            {
                // Mevcut oteli güncelle
                existingHotel.Name = model.Name;
                existingHotel.City = model.City;
                existingHotel.Country = model.Country;
                existingHotel.Address = model.Address;
                existingHotel.PictureUrl = model.PictureUrl;
                existingHotel.Description = model.Description;
                existingHotel.Rating = model.Rating;
                // Veritabanındaki değişiklikleri kaydet
                await _uow.CommitAsync();
            }
        }
    }
}
