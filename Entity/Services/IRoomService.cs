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
        Task<IEnumerable<RoomViewModel>> GetAll();
        Task<List<Room>> GetRoomsByHotelId(int hotelId);
        Task<RoomViewModel> GetRoomById(int roomId);
        Task Delete(int id);
        Task Update(RoomViewModel model);
        Task<List<RoomViewModel>> Get(int HotelId);
        Task Add(RoomViewModel model);

    }
}
