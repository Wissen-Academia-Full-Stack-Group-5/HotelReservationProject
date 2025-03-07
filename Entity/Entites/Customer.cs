﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entites
{
    public class Customer
    {

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
		public string IdentityUserId { get; set; } // Identity kullanıcı kimliği
        public string CardHolderName { get; set; } = "";
        public string CardNumber { get; set; } = "";
        public string ExpirationDate { get; set; } = "";
        public string CVV { get; set; } = "";
        public string Address { get; set; } = "";
        public string TCKimlikNo { get; set; } = "";

        // Navigation Property
        public ICollection<Reservation> Reservations { get; set; }
    }
}
