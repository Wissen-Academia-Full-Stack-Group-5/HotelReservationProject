using System;
using System.ComponentModel.DataAnnotations;

namespace Entity.ViewModels
{
    public class ReservationViewModel
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }

        [Required]
        public DateTime? CheckInDate { get; set; }

        [Required]
        public DateTime? CheckOutDate { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public string ReservationStatus { get; set; } = "Beklemede";

        [Required]
        public string City { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public decimal RoomPrice { get; set; }

        [Required]
        public int NumberOfGuests { get; set; }
    }
}
