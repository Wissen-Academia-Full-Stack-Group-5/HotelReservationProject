using AutoMapper;
using Data.Contexts;
using Entity.Entites;
using Entity.Services;
using Entity.UnitOfWorks;
using Entity.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly HotelDbContext _hotelDbContext;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, HotelDbContext hotelDbContext)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _hotelDbContext = hotelDbContext;
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAll()
        {
            var list = await _unitOfWork.GetRepository<Customer>().GetAllAsync();
            return _mapper.Map<List<CustomerViewModel>>(list);
        }
        public async Task<CustomerViewModel> GetReservationById(int CustomerId)
        {
            var customer = await _unitOfWork.GetRepository<Customer>().GetByIdAsync(CustomerId);
            return _mapper.Map<CustomerViewModel>(customer);
        }

        public async Task Update(CustomerViewModel model)
        {
            var existingHotel = await _hotelDbContext.Customers.FirstOrDefaultAsync(h => h.CustomerId == model.CustomerId);

            if (existingHotel != null)
            {
                // Mevcut oteli güncelle
                existingHotel.FirstName = model.FirstName;
                existingHotel.Email = model.Email;
                existingHotel.LastName = model.LastName;
                existingHotel.Phone = model.Phone;


                // Veritabanındaki değişiklikleri kaydet
                await _unitOfWork.CommitAsync();
            }
        }
        public async Task Delete(int CustomerId)
        {
            var existingHotel = await _hotelDbContext.Customers.FirstOrDefaultAsync(h => h.CustomerId == CustomerId);

            if (existingHotel != null)
            {
                _hotelDbContext.Customers.Remove(existingHotel);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
