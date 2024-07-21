using Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Services
{
    public interface IUserService
    {
        Task<IEnumerable<CustomerViewModel>> GetAll();
        Task Update(CustomerViewModel model);
        Task<CustomerViewModel> GetReservationById(int CustomerId);
        Task Delete(int id);
    }
}
