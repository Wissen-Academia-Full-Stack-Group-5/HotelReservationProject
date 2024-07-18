using Entity.Entites;
using Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Services
{
	public interface IRoomService
	{
        Task<List<RoomViewModel>> GetAvailableRooms(int hotelId, DateTime checkInDate, DateTime checkOutDate);
        Task<List<RoomViewModel>> GetRoomsByHotelAndDateAsync(int hotelId, DateTime checkInDate, DateTime checkOutDate);
        Task<List<RoomViewModel>> GetRoomsByHotel(int hotelId, DateTime checkInDate, DateTime checkOutDate);


    }
}
