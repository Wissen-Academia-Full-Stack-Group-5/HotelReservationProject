using Entity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repositories
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> GetAvailableHotelsAsync(DateTime CheckInDate, DateTime CheckOutDate);
    }
}
