using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entites
{
    public class Payment : BaseEntity
    {
        public int PaymentId { get; set; }
        public int ReservationId { get; set; } // Foreign Key
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }

        // Navigation Property
        public Reservation Reservation { get; set; }
    }
}
