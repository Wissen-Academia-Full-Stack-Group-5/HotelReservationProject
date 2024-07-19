using Entity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModels
{
    public class HotelGroupViewModel
    {
        public string City { get; set; }
        public List<Hotel> Hotels { get; set; }
    }
}
