using Data.Identity;
using Entity.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts
{
    public class HotelDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }


        public  DbSet<Hotel> Hotels { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-to-Many relationship between Hotel and Room
            modelBuilder.Entity<Room>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Rooms)
                .HasForeignKey(r => r.HotelId);

            // One-to-Many relationship between Customer and Reservation
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.CustomerId);

            // One-to-Many relationship between Room and Reservation
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Room)
                .WithMany(rm => rm.Reservations)
                .HasForeignKey(r => r.RoomId);

            // One-to-Many relationship between Reservation and Payment
            //modelBuilder.Entity<Payment>()
            //    .Property(p => p.PaymentId)
            //    .ValueGeneratedOnAdd();

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Reservation)
                .WithMany(r => r.Payments)
                .HasForeignKey(p => p.ReservationId); 
            base.OnModelCreating(modelBuilder);
            
            //seed data


            //modelBuilder.Entity<Hotel>().HasData(

            //        new Hotel() { HotelId = 1, Name = "Grand Hotel", Address = "123 Main St", City = "Springfield", Country = "USA", Description = "A luxurious hotel in the heart of the city.", Rating = 4.5 },
            //        new Hotel() { HotelId = 2, Name = "Ocean View", Address = "456 Ocean Dr", City = "Miami", Country = "USA", Description = "Enjoy the beautiful ocean view.", Rating = 4.7 },
            //        new Hotel() { HotelId = 3, Name = "Mountain Retreat", Address = "789 Mountain Rd", City = "Aspen", Country = "USA", Description = "A peaceful retreat in the mountains.", Rating = 4.8 },
            //        new Hotel() { HotelId = 4, Name = "City Center Hotel", Address = "101 Center St", City = "New York", Country = "USA", Description = "Located in the bustling city center.", Rating = 4.3 },
            //        new Hotel() { HotelId = 5, Name = "Sunset Inn", Address = "202 Sunset Blvd", City = "Los Angeles", Country = "USA", Description = "Experience stunning sunsets.", Rating = 4.6 },
            //        new Hotel() { HotelId = 6, Name = "Lake House", Address = "303 Lakeview Dr", City = "Chicago", Country = "USA", Description = "A serene hotel by the lake.", Rating = 4.4 },
            //        new Hotel() { HotelId = 7, Name = "Forest Lodge", Address = "404 Forest Ln", City = "Seattle", Country = "USA", Description = "Surrounded by lush forests.", Rating = 4.9 },
            //        new Hotel() { HotelId = 8, Name = "Desert Oasis", Address = "505 Desert Rd", City = "Phoenix", Country = "USA", Description = "An oasis in the desert.", Rating = 4.2 },
            //        new Hotel() { HotelId = 9, Name = "Historic Inn", Address = "606 Historic St", City = "Boston", Country = "USA", Description = "A historic hotel with charm.", Rating = 4.7 },
            //        new Hotel() { HotelId = 10, Name = "Beach Resort", Address = "707 Beach Dr", City = "San Diego", Country = "USA", Description = "Relax at the beach.", Rating = 4.8 },
            //        new Hotel() { HotelId = 11, Name = "Urban Hotel", Address = "808 Urban Blvd", City = "Houston", Country = "USA", Description = "Modern hotel in the city.", Rating = 4.3 },
            //        new Hotel() { HotelId = 12, Name = "Country Inn", Address = "909 Country Rd", City = "Nashville", Country = "USA", Description = "A cozy country inn.", Rating = 4.6 },
            //        new Hotel() { HotelId = 13, Name = "Riverfront Hotel", Address = "1010 Riverfront Ave", City = "Portland", Country = "USA", Description = "Scenic views by the river.", Rating = 4.5 },
            //        new Hotel() { HotelId = 14, Name = "Garden Hotel", Address = "1111 Garden St", City = "San Francisco", Country = "USA", Description = "Beautiful gardens and flowers.", Rating = 4.7 },
            //        new Hotel() { HotelId = 15, Name = "Luxury Suites", Address = "1212 Luxury Ln", City = "Las Vegas", Country = "USA", Description = "Experience luxury at its best.", Rating = 4.9 }

            //    );

            //modelBuilder.Entity<Room>().HasData(

            //        new Room() { RoomId = 1, RoomNumber = "101", Type = "Single", Price = 75.50m, Description = "Cozy single room", IsAvailable = true },
            //        new Room() { RoomId = 2, RoomNumber = "102", Type = "Single", Price = 75.50m, Description = "Cozy single room", IsAvailable = true },
            //        new Room() { RoomId = 3, RoomNumber = "103", Type = "Double", Price = 150.00m, Description = "Spacious double room", IsAvailable = true },
            //        new Room() { RoomId = 4, RoomNumber = "104", Type = "Double", Price = 150.00m, Description = "Spacious double room", IsAvailable = true },
            //        new Room() { RoomId = 5, RoomNumber = "105", Type = "Suite", Price = 300.00m, Description = "Luxury suite", IsAvailable = true },
            //        new Room() { RoomId = 6, RoomNumber = "106", Type = "Suite", Price = 300.00m, Description = "Luxury suite", IsAvailable = true },
            //        new Room() { RoomId = 7, RoomNumber = "107", Type = "Single", Price = 75.50m, Description = "Cozy single room", IsAvailable = true },
            //        new Room() { RoomId = 8, RoomNumber = "108", Type = "Double", Price = 150.00m, Description = "Spacious double room", IsAvailable = true },
            //        new Room() { RoomId = 9, RoomNumber = "109", Type = "Suite", Price = 300.00m, Description = "Luxury suite", IsAvailable = true },
            //        new Room() { RoomId = 10, RoomNumber = "110", Type = "Single", Price = 75.50m, Description = "Cozy single room", IsAvailable = true },
            //        new Room() { RoomId = 11, RoomNumber = "201", Type = "Double", Price = 150.00m, Description = "Spacious double room", IsAvailable = true },
            //        new Room() { RoomId = 12, RoomNumber = "202", Type = "Suite", Price = 300.00m, Description = "Luxury suite", IsAvailable = true },
            //        new Room() { RoomId = 13, RoomNumber = "203", Type = "Single", Price = 75.50m, Description = "Cozy single room", IsAvailable = true },
            //        new Room() { RoomId = 14, RoomNumber = "204", Type = "Double", Price = 150.00m, Description = "Spacious double room", IsAvailable = true },
            //        new Room() { RoomId = 15, RoomNumber = "205", Type = "Suite", Price = 300.00m, Description = "Luxury suite", IsAvailable = true },
            //        new Room() { RoomId = 16, RoomNumber = "206", Type = "Single", Price = 75.50m, Description = "Cozy single room", IsAvailable = true },
            //        new Room() { RoomId = 17, RoomNumber = "207", Type = "Double", Price = 150.00m, Description = "Spacious double room", IsAvailable = true },
            //        new Room() { RoomId = 18, RoomNumber = "208", Type = "Suite", Price = 300.00m, Description = "Luxury suite", IsAvailable = true },
            //        new Room() { RoomId = 19, RoomNumber = "209", Type = "Single", Price = 75.50m, Description = "Cozy single room", IsAvailable = true },
            //        new Room() { RoomId = 20, RoomNumber = "210", Type = "Double", Price = 150.00m, Description = "Spacious double room", IsAvailable = true },
            //        new Room() { RoomId = 21, RoomNumber = "301", Type = "Suite", Price = 300.00m, Description = "Luxury suite", IsAvailable = true },
            //        new Room() { RoomId = 22, RoomNumber = "302", Type = "Single", Price = 75.50m, Description = "Cozy single room", IsAvailable = true },
            //        new Room() { RoomId = 23, RoomNumber = "303", Type = "Double", Price = 150.00m, Description = "Spacious double room", IsAvailable = true },
            //        new Room() { RoomId = 24, RoomNumber = "304", Type = "Suite", Price = 300.00m, Description = "Luxury suite", IsAvailable = true },
            //        new Room() { RoomId = 25, RoomNumber = "305", Type = "Single", Price = 75.50m, Description = "Cozy single room", IsAvailable = true },
            //        new Room() { RoomId = 26, RoomNumber = "306", Type = "Double", Price = 150.00m, Description = "Spacious double room", IsAvailable = true },
            //        new Room() { RoomId = 27, RoomNumber = "307", Type = "Suite", Price = 300.00m, Description = "Luxury suite", IsAvailable = true },
            //        new Room() { RoomId = 28, RoomNumber = "308", Type = "Single", Price = 75.50m, Description = "Cozy single room", IsAvailable = true },
            //        new Room() { RoomId = 29, RoomNumber = "309", Type = "Double", Price = 150.00m, Description = "Spacious double room", IsAvailable = true },
            //        new Room() { RoomId = 30, RoomNumber = "310", Type = "Suite", Price = 300.00m, Description = "Luxury suite", IsAvailable = true },
            //        new Room() { RoomId = 31, RoomNumber = "401", Type = "Single", Price = 75.50m, Description = "Cozy single room", IsAvailable = true },
            //        new Room() { RoomId = 32, RoomNumber = "402", Type = "Double", Price = 150.00m, Description = "Spacious double room", IsAvailable = true },
            //        new Room() { RoomId = 33, RoomNumber = "403", Type = "Suite", Price = 300.00m, Description = "Luxury suite", IsAvailable = true },
            //        new Room() { RoomId = 34, RoomNumber = "404", Type = "Single", Price = 75.50m, Description = "Cozy single room", IsAvailable = true },
            //        new Room() { RoomId = 35, RoomNumber = "405", Type = "Double", Price = 150.00m, Description = "Spacious double room", IsAvailable = true },
            //        new Room() { RoomId = 36, RoomNumber = "406", Type = "Suite", Price = 300.00m, Description = "Luxury suite", IsAvailable = true },
            //        new Room() { RoomId = 37, RoomNumber = "407", Type = "Single", Price = 75.50m, Description = "Cozy single room", IsAvailable = true },
            //        new Room() { RoomId = 38, RoomNumber = "408", Type = "Double", Price = 150.00m, Description = "Spacious double room", IsAvailable = true },
            //        new Room() { RoomId = 39, RoomNumber = "409", Type = "Suite", Price = 300.00m, Description = "Luxury suite", IsAvailable = true },
            //        new Room() { RoomId = 40, RoomNumber = "410", Type = "Single", Price = 75.50m, Description = "Cozy single room", IsAvailable = true },
            //        new Room() { RoomId = 41, RoomNumber = "501", Type = "Double", Price = 150.00m, Description = "Spacious double room", IsAvailable = true },
            //        new Room() { RoomId = 42, RoomNumber = "502", Type = "Suite", Price = 300.00m, Description = "Luxury suite", IsAvailable = true }
            //    // Add the remaining rooms similarly up to RoomId 45

            //    );


            //modelBuilder.Entity<Customer>().HasData(

            //    new Customer() { CustomerId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Phone = "555-1234" },
            //    new Customer() { CustomerId = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Phone = "555-5678" },
            //    new Customer() { CustomerId = 3, FirstName = "Michael", LastName = "Johnson", Email = "michael.johnson@example.com", Phone = "555-9012" },
            //    new Customer() { CustomerId = 4, FirstName = "Emily", LastName = "Williams", Email = "emily.williams@example.com", Phone = "555-3456" },
            //    new Customer() { CustomerId = 5, FirstName = "James", LastName = "Brown", Email = "james.brown@example.com", Phone = "555-7890" },
            //    new Customer() { CustomerId = 6, FirstName = "Sarah", LastName = "Jones", Email = "sarah.jones@example.com", Phone = "555-2345" },
            //    new Customer() { CustomerId = 7, FirstName = "David", LastName = "Garcia", Email = "david.garcia@example.com", Phone = "555-6789" },
            //    new Customer() { CustomerId = 8, FirstName = "Maria", LastName = "Martinez", Email = "maria.martinez@example.com", Phone = "555-1234" },
            //    new Customer() { CustomerId = 9, FirstName = "Daniel", LastName = "Lopez", Email = "daniel.lopez@example.com", Phone = "555-5678" },
            //    new Customer() { CustomerId = 10, FirstName = "Jessica", LastName = "Lee", Email = "jessica.lee@example.com", Phone = "555-9012" },
            //    new Customer() { CustomerId = 11, FirstName = "Matthew", LastName = "Taylor", Email = "matthew.taylor@example.com", Phone = "555-3456" },
            //    new Customer() { CustomerId = 12, FirstName = "Amanda", LastName = "Hernandez", Email = "amanda.hernandez@example.com", Phone = "555-7890" },
            //    new Customer() { CustomerId = 13, FirstName = "Christopher", LastName = "Moore", Email = "christopher.moore@example.com", Phone = "555-2345" },
            //    new Customer() { CustomerId = 14, FirstName = "Elizabeth", LastName = "Davis", Email = "elizabeth.davis@example.com", Phone = "555-6789" },
            //    new Customer() { CustomerId = 15, FirstName = "Andrew", LastName = "Miller", Email = "andrew.miller@example.com", Phone = "555-1234" },
            //    new Customer() { CustomerId = 16, FirstName = "Jennifer", LastName = "Wilson", Email = "jennifer.wilson@example.com", Phone = "555-5678" },
            //    new Customer() { CustomerId = 17, FirstName = "Joshua", LastName = "Gonzalez", Email = "joshua.gonzalez@example.com", Phone = "555-9012" },
            //    new Customer() { CustomerId = 18, FirstName = "Linda", LastName = "White", Email = "linda.white@example.com", Phone = "555-3456" },
            //    new Customer() { CustomerId = 19, FirstName = "Ryan", LastName = "Thomas", Email = "ryan.thomas@example.com", Phone = "555-7890" },
            //    new Customer() { CustomerId = 20, FirstName = "Olivia", LastName = "Jackson", Email = "olivia.jackson@example.com", Phone = "555-2345" },
            //    new Customer() { CustomerId = 21, FirstName = "Kevin", LastName = "Clark", Email = "kevin.clark@example.com", Phone = "555-6789" },
            //    new Customer() { CustomerId = 22, FirstName = "Patricia", LastName = "Lewis", Email = "patricia.lewis@example.com", Phone = "555-1234" },
            //    new Customer() { CustomerId = 23, FirstName = "Jason", LastName = "Walker", Email = "jason.walker@example.com", Phone = "555-5678" },
            //    new Customer() { CustomerId = 24, FirstName = "Hannah", LastName = "Hall", Email = "hannah.hall@example.com", Phone = "555-9012" },
            //    new Customer() { CustomerId = 25, FirstName = "Brian", LastName = "Young", Email = "brian.young@example.com", Phone = "555-3456" },
            //    new Customer() { CustomerId = 26, FirstName = "Samantha", LastName = "Allen", Email = "samantha.allen@example.com", Phone = "555-7890" },
            //    new Customer() { CustomerId = 27, FirstName = "Robert", LastName = "Scott", Email = "robert.scott@example.com", Phone = "555-2345" },
            //    new Customer() { CustomerId = 28, FirstName = "Katherine", LastName = "Green", Email = "katherine.green@example.com", Phone = "555-6789" },
            //    new Customer() { CustomerId = 29, FirstName = "William", LastName = "Adams", Email = "william.adams@example.com", Phone = "555-1234" },
            //    new Customer() { CustomerId = 30, FirstName = "Megan", LastName = "Baker", Email = "megan.baker@example.com", Phone = "555-5678" }

            //     );


            //modelBuilder.Entity<Payment>().HasData(

            //    new Payment() { PaymentId = 1, PaymentDate = new DateTime(2024, 6, 28), Amount = 10000, PaymentMethod = "Credit Card", ReservationId = 1 },
            //    new Payment() { PaymentId = 2, PaymentDate = new DateTime(2024, 6, 28), Amount = 7500, PaymentMethod = "PayPal", ReservationId = 1 },
            //    new Payment() { PaymentId = 3, PaymentDate = new DateTime(2024, 6, 27), Amount = 12000, PaymentMethod = "Bank Transfer", ReservationId = 2 },
            //    new Payment() { PaymentId = 4, PaymentDate = new DateTime(2024, 6, 27), Amount = 5000, PaymentMethod = "Credit Card", ReservationId = 2 },
            //    new Payment() { PaymentId = 5, PaymentDate = new DateTime(2024, 6, 26), Amount = 8000, PaymentMethod = "Cash", ReservationId = 3 },
            //    new Payment() { PaymentId = 6, PaymentDate = new DateTime(2024, 6, 26), Amount = 9500, PaymentMethod = "PayPal", ReservationId = 3 },
            //    new Payment() { PaymentId = 7, PaymentDate = new DateTime(2024, 6, 25), Amount = 11000, PaymentMethod = "Credit Card", ReservationId = 4 },
            //    new Payment() { PaymentId = 8, PaymentDate = new DateTime(2024, 6, 25), Amount = 7000, PaymentMethod = "Bank Transfer", ReservationId = 4 },
            //    new Payment() { PaymentId = 9, PaymentDate = new DateTime(2024, 6, 24), Amount = 8500, PaymentMethod = "Credit Card", ReservationId = 5 },
            //    new Payment() { PaymentId = 10, PaymentDate = new DateTime(2024, 6, 24), Amount = 9000, PaymentMethod = "PayPal", ReservationId = 5 },
            //    new Payment() { PaymentId = 11, PaymentDate = new DateTime(2024, 6, 23), Amount = 6000, PaymentMethod = "Credit Card", ReservationId = 6 },
            //    new Payment() { PaymentId = 12, PaymentDate = new DateTime(2024, 6, 23), Amount = 10000, PaymentMethod = "Bank Transfer", ReservationId = 6 },
            //    new Payment() { PaymentId = 13, PaymentDate = new DateTime(2024, 6, 22), Amount = 9500, PaymentMethod = "Credit Card", ReservationId = 7 },
            //    new Payment() { PaymentId = 14, PaymentDate = new DateTime(2024, 6, 22), Amount = 8500, PaymentMethod = "PayPal", ReservationId = 7 },
            //    new Payment() { PaymentId = 15, PaymentDate = new DateTime(2024, 6, 21), Amount = 7000, PaymentMethod = "Credit Card", ReservationId = 8 },
            //    new Payment() { PaymentId = 16, PaymentDate = new DateTime(2024, 6, 21), Amount = 12000, PaymentMethod = "Bank Transfer", ReservationId = 8 },
            //    new Payment() { PaymentId = 17, PaymentDate = new DateTime(2024, 6, 20), Amount = 5000, PaymentMethod = "Credit Card", ReservationId = 9 },
            //    new Payment() { PaymentId = 18, PaymentDate = new DateTime(2024, 6, 20), Amount = 8000, PaymentMethod = "Cash", ReservationId = 9 },
            //    new Payment() { PaymentId = 19, PaymentDate = new DateTime(2024, 6, 19), Amount = 9500, PaymentMethod = "Credit Card", ReservationId = 10 },
            //    new Payment() { PaymentId = 20, PaymentDate = new DateTime(2024, 6, 19), Amount = 11000, PaymentMethod = "PayPal", ReservationId = 10 },
            //    new Payment() { PaymentId = 21, PaymentDate = new DateTime(2024, 6, 18), Amount = 7000, PaymentMethod = "Credit Card", ReservationId = 11 },
            //    new Payment() { PaymentId = 22, PaymentDate = new DateTime(2024, 6, 18), Amount = 9000, PaymentMethod = "Bank Transfer", ReservationId = 11 },
            //    new Payment() { PaymentId = 23, PaymentDate = new DateTime(2024, 6, 17), Amount = 6000, PaymentMethod = "Credit Card", ReservationId = 12 },
            //    new Payment() { PaymentId = 24, PaymentDate = new DateTime(2024, 6, 17), Amount = 8500, PaymentMethod = "PayPal", ReservationId = 12 },
            //    new Payment() { PaymentId = 25, PaymentDate = new DateTime(2024, 6, 16), Amount = 10000, PaymentMethod = "Credit Card", ReservationId = 13 },
            //    new Payment() { PaymentId = 26, PaymentDate = new DateTime(2024, 6, 16), Amount = 9500, PaymentMethod = "Bank Transfer", ReservationId = 13 },
            //    new Payment() { PaymentId = 27, PaymentDate = new DateTime(2024, 6, 15), Amount = 7000, PaymentMethod = "Credit Card", ReservationId = 14 },
            //    new Payment() { PaymentId = 28, PaymentDate = new DateTime(2024, 6, 15), Amount = 8000, PaymentMethod = "PayPal", ReservationId = 14 },
            //    new Payment() { PaymentId = 29, PaymentDate = new DateTime(2024, 6, 14), Amount = 11000, PaymentMethod = "Credit Card", ReservationId = 15 },
            //    new Payment() { PaymentId = 30, PaymentDate = new DateTime(2024, 6, 14), Amount = 5000, PaymentMethod = "Bank Transfer", ReservationId = 15 },
            //    new Payment() { PaymentId = 31, PaymentDate = new DateTime(2024, 6, 13), Amount = 8500, PaymentMethod = "Credit Card", ReservationId = 16 },
            //    new Payment() { PaymentId = 32, PaymentDate = new DateTime(2024, 6, 13), Amount = 9000, PaymentMethod = "PayPal", ReservationId = 16 },
            //    new Payment() { PaymentId = 33, PaymentDate = new DateTime(2024, 6, 12), Amount = 6000, PaymentMethod = "Credit Card", ReservationId = 17 },
            //    new Payment() { PaymentId = 34, PaymentDate = new DateTime(2024, 6, 12), Amount = 12000, PaymentMethod = "Bank Transfer", ReservationId = 17 },
            //    new Payment() { PaymentId = 35, PaymentDate = new DateTime(2024, 6, 11), Amount = 9500, PaymentMethod = "Credit Card", ReservationId = 18 },
            //    new Payment() { PaymentId = 36, PaymentDate = new DateTime(2024, 6, 11), Amount = 7000, PaymentMethod = "PayPal", ReservationId = 18 },
            //    new Payment() { PaymentId = 37, PaymentDate = new DateTime(2024, 6, 10), Amount = 7000, PaymentMethod = "Credit Card", ReservationId = 19 },
            //    new Payment() { PaymentId = 38, PaymentDate = new DateTime(2024, 6, 10), Amount = 8500, PaymentMethod = "Bank Transfer", ReservationId = 19 },
            //    new Payment() { PaymentId = 39, PaymentDate = new DateTime(2024, 6, 9), Amount = 8000, PaymentMethod = "Credit Card", ReservationId = 20 },
            //    new Payment() { PaymentId = 40, PaymentDate = new DateTime(2024, 6, 9), Amount = 9500, PaymentMethod = "PayPal", ReservationId = 20 },
            //    new Payment() { PaymentId = 41, PaymentDate = new DateTime(2024, 6, 8), Amount = 11000, PaymentMethod = "Credit Card", ReservationId = 21 },
            //    new Payment() { PaymentId = 42, PaymentDate = new DateTime(2024, 6, 8), Amount = 6000, PaymentMethod = "Bank Transfer", ReservationId = 21 },
            //    new Payment() { PaymentId = 43, PaymentDate = new DateTime(2024, 6, 7), Amount = 8500, PaymentMethod = "Credit Card", ReservationId = 22 },
            //    new Payment() { PaymentId = 44, PaymentDate = new DateTime(2024, 6, 7), Amount = 7000, PaymentMethod = "PayPal", ReservationId = 22 },
            //    new Payment() { PaymentId = 45, PaymentDate = new DateTime(2024, 6, 6), Amount = 10000, PaymentMethod = "Credit Card", ReservationId = 23 },
            //    new Payment() { PaymentId = 46, PaymentDate = new DateTime(2024, 6, 6), Amount = 7500, PaymentMethod = "Bank Transfer", ReservationId = 23 },
            //    new Payment() { PaymentId = 47, PaymentDate = new DateTime(2024, 6, 5), Amount = 8000, PaymentMethod = "Credit Card", ReservationId = 24 },
            //    new Payment() { PaymentId = 48, PaymentDate = new DateTime(2024, 6, 5), Amount = 9500, PaymentMethod = "PayPal", ReservationId = 24 },
            //    new Payment() { PaymentId = 49, PaymentDate = new DateTime(2024, 6, 4), Amount = 11000, PaymentMethod = "Credit Card", ReservationId = 25 },
            //    new Payment() { PaymentId = 50, PaymentDate = new DateTime(2024, 6, 4), Amount = 7000, PaymentMethod = "Bank Transfer", ReservationId = 25 }

            //    );



            //modelBuilder.Entity<Reservation>().HasData(

            //    new Reservation() { ReservationId = 1, CheckInDate = new DateTime(2024, 6, 28), CheckOutDate = new DateTime(2024, 6, 30), TotalPrice = 500, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 2, CheckInDate = new DateTime(2024, 6, 29), CheckOutDate = new DateTime(2024, 7, 1), TotalPrice = 700, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 3, CheckInDate = new DateTime(2024, 6, 30), CheckOutDate = new DateTime(2024, 7, 2), TotalPrice = 600, ReservationStatus = "Pending" },
            //    new Reservation() { ReservationId = 4, CheckInDate = new DateTime(2024, 7, 1), CheckOutDate = new DateTime(2024, 7, 3), TotalPrice = 800, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 5, CheckInDate = new DateTime(2024, 7, 2), CheckOutDate = new DateTime(2024, 7, 4), TotalPrice = 900, ReservationStatus = "Cancelled" },
            //    new Reservation() { ReservationId = 6, CheckInDate = new DateTime(2024, 7, 3), CheckOutDate = new DateTime(2024, 7, 5), TotalPrice = 750, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 7, CheckInDate = new DateTime(2024, 7, 4), CheckOutDate = new DateTime(2024, 7, 6), TotalPrice = 950, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 8, CheckInDate = new DateTime(2024, 7, 5), CheckOutDate = new DateTime(2024, 7, 7), TotalPrice = 700, ReservationStatus = "Pending" },
            //    new Reservation() { ReservationId = 9, CheckInDate = new DateTime(2024, 7, 6), CheckOutDate = new DateTime(2024, 7, 8), TotalPrice = 850, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 10, CheckInDate = new DateTime(2024, 7, 7), CheckOutDate = new DateTime(2024, 7, 9), TotalPrice = 1100, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 11, CheckInDate = new DateTime(2024, 7, 8), CheckOutDate = new DateTime(2024, 7, 10), TotalPrice = 600, ReservationStatus = "Cancelled" },
            //    new Reservation() { ReservationId = 12, CheckInDate = new DateTime(2024, 7, 9), CheckOutDate = new DateTime(2024, 7, 11), TotalPrice = 950, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 13, CheckInDate = new DateTime(2024, 7, 10), CheckOutDate = new DateTime(2024, 7, 12), TotalPrice = 800, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 14, CheckInDate = new DateTime(2024, 7, 11), CheckOutDate = new DateTime(2024, 7, 13), TotalPrice = 1200, ReservationStatus = "Pending" },
            //    new Reservation() { ReservationId = 15, CheckInDate = new DateTime(2024, 7, 12), CheckOutDate = new DateTime(2024, 7, 14), TotalPrice = 750, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 16, CheckInDate = new DateTime(2024, 7, 13), CheckOutDate = new DateTime(2024, 7, 15), TotalPrice = 850, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 17, CheckInDate = new DateTime(2024, 7, 14), CheckOutDate = new DateTime(2024, 7, 16), TotalPrice = 900, ReservationStatus = "Cancelled" },
            //    new Reservation() { ReservationId = 18, CheckInDate = new DateTime(2024, 7, 15), CheckOutDate = new DateTime(2024, 7, 17), TotalPrice = 700, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 19, CheckInDate = new DateTime(2024, 7, 16), CheckOutDate = new DateTime(2024, 7, 18), TotalPrice = 950, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 20, CheckInDate = new DateTime(2024, 7, 17), CheckOutDate = new DateTime(2024, 7, 19), TotalPrice = 1100, ReservationStatus = "Pending" },
            //    new Reservation() { ReservationId = 21, CheckInDate = new DateTime(2024, 7, 18), CheckOutDate = new DateTime(2024, 7, 20), TotalPrice = 800, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 22, CheckInDate = new DateTime(2024, 7, 19), CheckOutDate = new DateTime(2024, 7, 21), TotalPrice = 950, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 23, CheckInDate = new DateTime(2024, 7, 20), CheckOutDate = new DateTime(2024, 7, 22), TotalPrice = 700, ReservationStatus = "Cancelled" },
            //    new Reservation() { ReservationId = 24, CheckInDate = new DateTime(2024, 7, 21), CheckOutDate = new DateTime(2024, 7, 23), TotalPrice = 850, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 25, CheckInDate = new DateTime(2024, 7, 22), CheckOutDate = new DateTime(2024, 7, 24), TotalPrice = 1000, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 26, CheckInDate = new DateTime(2024, 7, 23), CheckOutDate = new DateTime(2024, 7, 25), TotalPrice = 750, ReservationStatus = "Pending" },
            //    new Reservation() { ReservationId = 27, CheckInDate = new DateTime(2024, 7, 24), CheckOutDate = new DateTime(2024, 7, 26), TotalPrice = 900, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 28, CheckInDate = new DateTime(2024, 7, 25), CheckOutDate = new DateTime(2024, 7, 27), TotalPrice = 950, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 29, CheckInDate = new DateTime(2024, 7, 26), CheckOutDate = new DateTime(2024, 7, 28), TotalPrice = 700, ReservationStatus = "Cancelled" },
            //    new Reservation() { ReservationId = 30, CheckInDate = new DateTime(2024, 7, 27), CheckOutDate = new DateTime(2024, 7, 29), TotalPrice = 850, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 31, CheckInDate = new DateTime(2024, 7, 28), CheckOutDate = new DateTime(2024, 7, 30), TotalPrice = 1100, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 32, CheckInDate = new DateTime(2024, 7, 29), CheckOutDate = new DateTime(2024, 7, 31), TotalPrice = 600, ReservationStatus = "Pending" },
            //    new Reservation() { ReservationId = 33, CheckInDate = new DateTime(2024, 7, 30), CheckOutDate = new DateTime(2024, 8, 1), TotalPrice = 950, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 34, CheckInDate = new DateTime(2024, 7, 31), CheckOutDate = new DateTime(2024, 8, 2), TotalPrice = 800, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 35, CheckInDate = new DateTime(2024, 8, 1), CheckOutDate = new DateTime(2024, 8, 3), TotalPrice = 1200, ReservationStatus = "Cancelled" },
            //    new Reservation() { ReservationId = 36, CheckInDate = new DateTime(2024, 8, 2), CheckOutDate = new DateTime(2024, 8, 4), TotalPrice = 750, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 37, CheckInDate = new DateTime(2024, 8, 3), CheckOutDate = new DateTime(2024, 8, 5), TotalPrice = 850, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 38, CheckInDate = new DateTime(2024, 8, 4), CheckOutDate = new DateTime(2024, 8, 6), TotalPrice = 900, ReservationStatus = "Pending" },
            //    new Reservation() { ReservationId = 39, CheckInDate = new DateTime(2024, 8, 5), CheckOutDate = new DateTime(2024, 8, 7), TotalPrice = 700, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 40, CheckInDate = new DateTime(2024, 8, 6), CheckOutDate = new DateTime(2024, 8, 8), TotalPrice = 950, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 41, CheckInDate = new DateTime(2024, 8, 7), CheckOutDate = new DateTime(2024, 8, 9), TotalPrice = 1100, ReservationStatus = "Cancelled" },
            //    new Reservation() { ReservationId = 42, CheckInDate = new DateTime(2024, 8, 8), CheckOutDate = new DateTime(2024, 8, 10), TotalPrice = 800, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 43, CheckInDate = new DateTime(2024, 8, 9), CheckOutDate = new DateTime(2024, 8, 11), TotalPrice = 950, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 44, CheckInDate = new DateTime(2024, 8, 10), CheckOutDate = new DateTime(2024, 8, 12), TotalPrice = 700, ReservationStatus = "Pending" },
            //    new Reservation() { ReservationId = 45, CheckInDate = new DateTime(2024, 8, 11), CheckOutDate = new DateTime(2024, 8, 13), TotalPrice = 850, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 46, CheckInDate = new DateTime(2024, 8, 12), CheckOutDate = new DateTime(2024, 8, 14), TotalPrice = 1000, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 47, CheckInDate = new DateTime(2024, 8, 13), CheckOutDate = new DateTime(2024, 8, 15), TotalPrice = 750, ReservationStatus = "Cancelled" },
            //    new Reservation() { ReservationId = 48, CheckInDate = new DateTime(2024, 8, 14), CheckOutDate = new DateTime(2024, 8, 16), TotalPrice = 900, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 49, CheckInDate = new DateTime(2024, 8, 15), CheckOutDate = new DateTime(2024, 8, 17), TotalPrice = 950, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 50, CheckInDate = new DateTime(2024, 8, 16), CheckOutDate = new DateTime(2024, 8, 18), TotalPrice = 700, ReservationStatus = "Pending" },
            //    new Reservation() { ReservationId = 51, CheckInDate = new DateTime(2024, 8, 17), CheckOutDate = new DateTime(2024, 8, 19), TotalPrice = 850, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 52, CheckInDate = new DateTime(2024, 8, 18), CheckOutDate = new DateTime(2024, 8, 20), TotalPrice = 1100, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 53, CheckInDate = new DateTime(2024, 8, 19), CheckOutDate = new DateTime(2024, 8, 21), TotalPrice = 600, ReservationStatus = "Cancelled" },
            //    new Reservation() { ReservationId = 54, CheckInDate = new DateTime(2024, 8, 20), CheckOutDate = new DateTime(2024, 8, 22), TotalPrice = 950, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 55, CheckInDate = new DateTime(2024, 8, 21), CheckOutDate = new DateTime(2024, 8, 23), TotalPrice = 800, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 56, CheckInDate = new DateTime(2024, 8, 22), CheckOutDate = new DateTime(2024, 8, 24), TotalPrice = 1200, ReservationStatus = "Pending" },
            //    new Reservation() { ReservationId = 57, CheckInDate = new DateTime(2024, 8, 23), CheckOutDate = new DateTime(2024, 8, 25), TotalPrice = 750, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 58, CheckInDate = new DateTime(2024, 8, 24), CheckOutDate = new DateTime(2024, 8, 26), TotalPrice = 850, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 59, CheckInDate = new DateTime(2024, 8, 25), CheckOutDate = new DateTime(2024, 8, 27), TotalPrice = 900, ReservationStatus = "Cancelled" },
            //    new Reservation() { ReservationId = 60, CheckInDate = new DateTime(2024, 8, 26), CheckOutDate = new DateTime(2024, 8, 28), TotalPrice = 700, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 61, CheckInDate = new DateTime(2024, 8, 27), CheckOutDate = new DateTime(2024, 8, 29), TotalPrice = 950, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 62, CheckInDate = new DateTime(2024, 8, 28), CheckOutDate = new DateTime(2024, 8, 30), TotalPrice = 1100, ReservationStatus = "Pending" },
            //    new Reservation() { ReservationId = 63, CheckInDate = new DateTime(2024, 8, 29), CheckOutDate = new DateTime(2024, 8, 31), TotalPrice = 600, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 64, CheckInDate = new DateTime(2024, 8, 30), CheckOutDate = new DateTime(2024, 9, 1), TotalPrice = 950, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 65, CheckInDate = new DateTime(2024, 8, 31), CheckOutDate = new DateTime(2024, 9, 2), TotalPrice = 800, ReservationStatus = "Cancelled" },
            //    new Reservation() { ReservationId = 66, CheckInDate = new DateTime(2024, 9, 1), CheckOutDate = new DateTime(2024, 9, 3), TotalPrice = 1200, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 67, CheckInDate = new DateTime(2024, 9, 2), CheckOutDate = new DateTime(2024, 9, 4), TotalPrice = 750, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 68, CheckInDate = new DateTime(2024, 9, 3), CheckOutDate = new DateTime(2024, 9, 5), TotalPrice = 850, ReservationStatus = "Pending" },
            //    new Reservation() { ReservationId = 69, CheckInDate = new DateTime(2024, 9, 4), CheckOutDate = new DateTime(2024, 9, 6), TotalPrice = 900, ReservationStatus = "Confirmed" },
            //    new Reservation() { ReservationId = 70, CheckInDate = new DateTime(2024, 9, 5), CheckOutDate = new DateTime(2024, 9, 7), TotalPrice = 700, ReservationStatus = "Confirmed" }


        


                

        }


    }
}
