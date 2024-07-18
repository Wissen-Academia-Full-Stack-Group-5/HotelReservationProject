using Entity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Services
{
    public interface IReservationService
    {
        Task<List<Reservation>> GetReservationsByHotelAndDateRange(int hotelId, DateTime checkInDate, DateTime checkOutDate);

    }
}
