using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModels
{
    public class SearchViewModel
    {
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public string City { get; set; }
        public string Type { get; set; }
        public List<string> Cities { get; set; }
    }
}
