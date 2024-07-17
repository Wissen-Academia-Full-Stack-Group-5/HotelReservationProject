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
            return await _hotelRepository.GetAvailableHotelsAsync(checkInDate, checkOutDate, city, type);
        }

        public async Task<List<string>> GetCities()
        {
            return await _context.Hotels
                .Select(h => h.City)
                .Distinct()
                .ToListAsync();
        }
    }
}
