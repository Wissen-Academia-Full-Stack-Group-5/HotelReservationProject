using Entity.Entites;
using Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Services
{
    public interface IHotelService
    {



        Task<Hotel> GetHotelById(int id);
        List<HotelGroupViewModel> GetAllHotelsGroupedByCity();




        Task<IEnumerable<HotelViewModel>> GetAll();
        Task<HotelViewModel> GetHotelByHotelId(int HotelId);
        Task<HotelViewModel> Get(int id);
        Task Delete(int id);
        Task Update(HotelViewModel model);
        Task Add(HotelViewModel model);
        Task<List<HotelViewModel>> GetFilteredHotels(DateTime checkInDate, DateTime checkOutDate, string City, string Type);
        Task<List<string>> GetCities();
    }

}
