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
    public class ReservationService : IReservationService
    {
        private readonly HotelDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ReservationService(HotelDbContext context, IMapper mapper, IUnitOfWork uow)
        {
            _context = context;
            _mapper = mapper;
            _uow = uow;
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
        public async Task<IEnumerable<ReservationViewModel>> GetAll()
        {
            var list = await _uow.GetRepository<Reservation>().GetAllAsync();
            return _mapper.Map<List<ReservationViewModel>>(list);
        }

        public async Task<ReservationViewModel> GetReservationById(int ReservationId)
        {
            var reservation = await _uow.GetRepository<Reservation>().GetByIdAsync(ReservationId);
            return _mapper.Map<ReservationViewModel>(reservation);
        }

        public async Task Update(ReservationViewModel model)
        {
            var existingHotel = await _context.Reservations.FirstOrDefaultAsync(h => h.ReservationId == model.ReservationId);

            if (existingHotel != null)
            {
                // Mevcut oteli güncelle
                existingHotel.TotalPrice = model.TotalPrice;
                //existingHotel.CheckOutDate = model.CheckOutDate;
                //existingHotel.CheckInDate = model.CheckInDate;
                existingHotel.CustomerId = model.CustomerId;
                existingHotel.RoomId = model.RoomId;

                // Veritabanındaki değişiklikleri kaydet
                await _uow.CommitAsync();
            }
        }
        public async Task Delete(int ReservationId)
        {
            var existingHotel = await _context.Reservations.FirstOrDefaultAsync(h => h.ReservationId == ReservationId);

            if (existingHotel != null)
            {
                _context.Reservations.Remove(existingHotel);
                await _uow.CommitAsync();
            }
        }
    }
}
