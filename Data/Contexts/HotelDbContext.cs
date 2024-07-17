using Data.Identity;
using Entity.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Contexts
{
    public class HotelDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships
            modelBuilder.Entity<Hotel>()
                .HasMany(h => h.Rooms)
                .WithOne(r => r.Hotel)
                .HasForeignKey(r => r.HotelId);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Reservations)
                .WithOne(r => r.Customer)
                .HasForeignKey(r => r.CustomerId);

            modelBuilder.Entity<Room>()
                .HasMany(r => r.Reservations)
                .WithOne(res => res.Room)
                .HasForeignKey(res => res.RoomId);

            modelBuilder.Entity<Reservation>()
                .HasMany(res => res.Payments)
                .WithOne(p => p.Reservation)
                .HasForeignKey(p => p.ReservationId);
           
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Reservation)
                .WithMany(r => r.Payments)
                .HasForeignKey(p => p.ReservationId);


            // Seed data
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    HotelId = 1,
                    Name = "Büyük Otel",
                    Address = "İstiklal Caddesi No:123",
                    City = "İstanbul",
                    Country = "Türkiye",
                    Description = "Şehrin merkezinde lüks bir otel.",
                    Rating = 4.5,
                    PictureUrl = "/images/hotel-1.jpg"
                },
                new Hotel
                {
                    HotelId = 2,
                    Name = "Deniz Manzaralı Otel",
                    Address = "Sahil Yolu No:456",
                    City = "Antalya",
                    Country = "Türkiye",
                    Description = "Deniz manzaralı güzel bir otel.",
                    Rating = 4.7,
                    PictureUrl = "/images/hotel-2.jpg"
                },
                new Hotel
                {
                    HotelId = 3,
                    Name = "Dağ Evi",
                    Address = "Dağ Yolu No:789",
                    City = "Bursa",
                    Country = "Türkiye",
                    Description = "Dağ manzaralı huzurlu bir otel.",
                    Rating = 4.8,
                    PictureUrl = "/images/hotel-3.jpg"
                },
                new Hotel
                {
                    HotelId = 4,
                    Name = "Şehir Oteli",
                    Address = "Merkez Mahallesi No:321",
                    City = "Ankara",
                    Country = "Türkiye",
                    Description = "Şehir merkezinde konforlu bir otel.",
                    Rating = 4.3,
                    PictureUrl = "/images/hotel-4.jpg"
                },
                new Hotel
                {
                    HotelId = 5,
                    Name = "Tatil Köyü",
                    Address = "Plaj Yolu No:654",
                    City = "İzmir",
                    Country = "Türkiye",
                    Description = "Tatil köyünde huzurlu bir konaklama.",
                    Rating = 4.6,
                    PictureUrl = "/images/hotel-5.jpg"
                },
                new Hotel
                {
                    HotelId = 6,
                    Name = "Boğaz Oteli",
                    Address = "Boğaz Sokak No:987",
                    City = "İstanbul",
                    Country = "Türkiye",
                    Description = "Boğaz manzaralı lüks bir otel.",
                    Rating = 4.9,
                    PictureUrl = "/images/hotel-6.jpg"
                },
                new Hotel
                {
                    HotelId = 7,
                    Name = "Yeşil Vadi Oteli",
                    Address = "Vadi Caddesi No:147",
                    City = "Trabzon",
                    Country = "Türkiye",
                    Description = "Yeşillikler içinde huzurlu bir otel.",
                    Rating = 4.5,
                    PictureUrl = "/images/hotel-7.jpg"
                },
                new Hotel
                {
                    HotelId = 8,
                    Name = "Deniz Tatil Köyü",
                    Address = "Deniz Caddesi No:258",
                    City = "Muğla",
                    Country = "Türkiye",
                    Description = "Deniz kenarında lüks bir tatil köyü.",
                    Rating = 4.7,
                    PictureUrl = "/images/hotel-8.jpg"
                },
                new Hotel
                {
                    HotelId = 9,
                    Name = "Kaplıca Oteli",
                    Address = "Kaplıca Yolu No:369",
                    City = "Afyon",
                    Country = "Türkiye",
                    Description = "Kaplıca suları ile ünlü bir otel.",
                    Rating = 4.4,
                    PictureUrl = "/images/hotel-9.jpg"
                },
                new Hotel
                {
                    HotelId = 10,
                    Name = "Ege Oteli",
                    Address = "Ege Sahili No:951",
                    City = "İzmir",
                    Country = "Türkiye",
                    Description = "Ege Denizi kıyısında konforlu bir otel.",
                    Rating = 4.6,
                    PictureUrl = "/images/hotel-10.jpg"
                },
                new Hotel
                {
                    HotelId = 11,
                    Name = "Tarihi Otel",
                    Address = "Tarihi Sokak No:753",
                    City = "İstanbul",
                    Country = "Türkiye",
                    Description = "Tarihi dokusuyla dikkat çeken bir otel.",
                    Rating = 4.8,
                    PictureUrl = "/images/hotel-11.jpg"
                },
                new Hotel
                {
                    HotelId = 12,
                    Name = "Butik Otel",
                    Address = "Şirin Sokak No:159",
                    City = "Antalya",
                    Country = "Türkiye",
                    Description = "Butik tarzda küçük ve sevimli bir otel.",
                    Rating = 4.4,
                    PictureUrl = "/images/hotel-12.jpg"
                },
                new Hotel
                {
                    HotelId = 13,
                    Name = "Kayak Oteli",
                    Address = "Kayak Yolu No:852",
                    City = "Erzurum",
                    Country = "Türkiye",
                    Description = "Kayak merkezine yakın bir otel.",
                    Rating = 4.5,
                    PictureUrl = "/images/hotel-13.jpg"
                },
                new Hotel
                {
                    HotelId = 14,
                    Name = "Spa Oteli",
                    Address = "Spa Sokak No:951",
                    City = "Bolu",
                    Country = "Türkiye",
                    Description = "Spa hizmetleri ile ünlü bir otel.",
                    Rating = 4.7,
                    PictureUrl = "/images/hotel-14.jpg"
                },
                new Hotel
                {
                    HotelId = 15,
                    Name = "Lüks Tatil Köyü",
                    Address = "Lüks Caddesi No:753",
                    City = "Muğla",
                    Country = "Türkiye",
                    Description = "Lüks hizmetleri ile ünlü bir tatil köyü.",
                    Rating = 4.9,
                    PictureUrl = "/images/hotel-15.jpg"
                }
            );

            modelBuilder.Entity<Room>().HasData(
    // Hotel 1 Rooms
    new Room { RoomId = 1, RoomNumber = "101", Type = "Tek Kişilik", Price = 750.00m, Description = "Konforlu tek kişilik oda", IsAvailable = true, HotelId = 1, PictureUrl = "/images/room-1.jpg" },
    new Room { RoomId = 2, RoomNumber = "102", Type = "Çift Kişilik", Price = 1200.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 1, PictureUrl = "/images/room-2.jpg" },
    new Room { RoomId = 3, RoomNumber = "103", Type = "Aile Odası", Price = 1500.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 1, PictureUrl = "/images/room-3.jpg" },
    new Room { RoomId = 4, RoomNumber = "104", Type = "Süit", Price = 1800.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 1, PictureUrl = "/images/room-4.jpg" },
    new Room { RoomId = 5, RoomNumber = "105", Type = "Tek Kişilik", Price = 750.00m, Description = "Konforlu tek kişilik oda", IsAvailable = true, HotelId = 1, PictureUrl = "/images/room-5.jpg" },
    new Room { RoomId = 6, RoomNumber = "106", Type = "Çift Kişilik", Price = 1200.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 1, PictureUrl = "/images/room-6.jpg" },
    new Room { RoomId = 7, RoomNumber = "107", Type = "Aile Odası", Price = 1500.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 1, PictureUrl = "/images/room-7.jpg" },
    new Room { RoomId = 8, RoomNumber = "108", Type = "Süit", Price = 1800.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 1, PictureUrl = "/images/room-8.jpg" },
    new Room { RoomId = 9, RoomNumber = "109", Type = "Tek Kişilik", Price = 750.00m, Description = "Konforlu tek kişilik oda", IsAvailable = true, HotelId = 1, PictureUrl = "/images/room-9.jpg" },
    new Room { RoomId = 10, RoomNumber = "110", Type = "Çift Kişilik", Price = 1200.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 1, PictureUrl = "/images/room-10.jpg" },

    // Hotel 2 Rooms
    new Room { RoomId = 11, RoomNumber = "201", Type = "Tek Kişilik", Price = 850.00m, Description = "Deniz manzaralı tek kişilik oda", IsAvailable = true, HotelId = 2, PictureUrl = "/images/room-11.jpg" },
    new Room { RoomId = 12, RoomNumber = "202", Type = "Çift Kişilik", Price = 1200.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 2, PictureUrl = "/images/room-12.jpg" },
    new Room { RoomId = 13, RoomNumber = "203", Type = "Aile Odası", Price = 1500.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 2, PictureUrl = "/images/room-13.jpg" },
    new Room { RoomId = 14, RoomNumber = "204", Type = "Süit", Price = 1800.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 2, PictureUrl = "/images/room-14.jpg" },
    new Room { RoomId = 15, RoomNumber = "205", Type = "Tek Kişilik", Price = 850.00m, Description = "Deniz manzaralı tek kişilik oda", IsAvailable = true, HotelId = 2, PictureUrl = "/images/room-15.jpg" },
    new Room { RoomId = 16, RoomNumber = "206", Type = "Çift Kişilik", Price = 1200.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 2, PictureUrl = "/images/room-16.jpg" },
    new Room { RoomId = 17, RoomNumber = "207", Type = "Aile Odası", Price = 1500.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 2, PictureUrl = "/images/room-17.jpg" },
    new Room { RoomId = 18, RoomNumber = "208", Type = "Süit", Price = 1800.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 2, PictureUrl = "/images/room-18.jpg" },
    new Room { RoomId = 19, RoomNumber = "209", Type = "Tek Kişilik", Price = 850.00m, Description = "Deniz manzaralı tek kişilik oda", IsAvailable = true, HotelId = 2, PictureUrl = "/images/room-19.jpg" },
    new Room { RoomId = 20, RoomNumber = "210", Type = "Çift Kişilik", Price = 1200.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 2, PictureUrl = "/images/room-20.jpg" },

    // Hotel 3 Rooms
    new Room { RoomId = 21, RoomNumber = "301", Type = "Tek Kişilik", Price = 700.00m, Description = "Dağ manzaralı tek kişilik oda", IsAvailable = true, HotelId = 3, PictureUrl = "/images/room-21.jpg" },
    new Room { RoomId = 22, RoomNumber = "302", Type = "Çift Kişilik", Price = 1100.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 3, PictureUrl = "/images/room-22.jpg" },
    new Room { RoomId = 23, RoomNumber = "303", Type = "Aile Odası", Price = 1400.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 3, PictureUrl = "/images/room-23.jpg" },
    new Room { RoomId = 24, RoomNumber = "304", Type = "Süit", Price = 1700.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 3, PictureUrl = "/images/room-24.jpg" },
    new Room { RoomId = 25, RoomNumber = "305", Type = "Tek Kişilik", Price = 700.00m, Description = "Dağ manzaralı tek kişilik oda", IsAvailable = true, HotelId = 3, PictureUrl = "/images/room-25.jpg" },
    new Room { RoomId = 26, RoomNumber = "306", Type = "Çift Kişilik", Price = 1100.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 3, PictureUrl = "/images/room-26.jpg" },
    new Room { RoomId = 27, RoomNumber = "307", Type = "Aile Odası", Price = 1400.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 3, PictureUrl = "/images/room-27.jpg" },
    new Room { RoomId = 28, RoomNumber = "308", Type = "Süit", Price = 1700.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 3, PictureUrl = "/images/room-28.jpg" },
    new Room { RoomId = 29, RoomNumber = "309", Type = "Tek Kişilik", Price = 700.00m, Description = "Dağ manzaralı tek kişilik oda", IsAvailable = true, HotelId = 3, PictureUrl = "/images/room-29.jpg" },
    new Room { RoomId = 30, RoomNumber = "310", Type = "Çift Kişilik", Price = 1100.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 3, PictureUrl = "/images/room-30.jpg" },

    // Hotel 4 Rooms
    new Room { RoomId = 31, RoomNumber = "401", Type = "Tek Kişilik", Price = 750.00m, Description = "Şehir manzaralı tek kişilik oda", IsAvailable = true, HotelId = 4, PictureUrl = "/images/room-31.jpg" },
    new Room { RoomId = 32, RoomNumber = "402", Type = "Çift Kişilik", Price = 1200.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 4, PictureUrl = "/images/room-32.jpg" },
    new Room { RoomId = 33, RoomNumber = "403", Type = "Aile Odası", Price = 1500.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 4, PictureUrl = "/images/room-33.jpg" },
    new Room { RoomId = 34, RoomNumber = "404", Type = "Süit", Price = 1800.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 4, PictureUrl = "/images/room-34.jpg" },
    new Room { RoomId = 35, RoomNumber = "405", Type = "Tek Kişilik", Price = 750.00m, Description = "Şehir manzaralı tek kişilik oda", IsAvailable = true, HotelId = 4, PictureUrl = "/images/room-35.jpg" },
    new Room { RoomId = 36, RoomNumber = "406", Type = "Çift Kişilik", Price = 1200.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 4, PictureUrl = "/images/room-36.jpg" },
    new Room { RoomId = 37, RoomNumber = "407", Type = "Aile Odası", Price = 1500.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 4, PictureUrl = "/images/room-37.jpg" },
    new Room { RoomId = 38, RoomNumber = "408", Type = "Süit", Price = 1800.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 4, PictureUrl = "/images/room-38.jpg" },
    new Room { RoomId = 39, RoomNumber = "409", Type = "Tek Kişilik", Price = 750.00m, Description = "Şehir manzaralı tek kişilik oda", IsAvailable = true, HotelId = 4, PictureUrl = "/images/room-39.jpg" },
    new Room { RoomId = 40, RoomNumber = "410", Type = "Çift Kişilik", Price = 1200.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 4, PictureUrl = "/images/room-40.jpg" },

    // Hotel 5 Rooms
    new Room { RoomId = 41, RoomNumber = "501", Type = "Tek Kişilik", Price = 850.00m, Description = "Plaj manzaralı tek kişilik oda", IsAvailable = true, HotelId = 5, PictureUrl = "/images/room-41.jpg" },
    new Room { RoomId = 42, RoomNumber = "502", Type = "Çift Kişilik", Price = 1200.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 5, PictureUrl = "/images/room-42.jpg" },
    new Room { RoomId = 43, RoomNumber = "503", Type = "Aile Odası", Price = 1500.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 5, PictureUrl = "/images/room-43.jpg" },
    new Room { RoomId = 44, RoomNumber = "504", Type = "Süit", Price = 1800.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 5, PictureUrl = "/images/room-44.jpg" },
    new Room { RoomId = 45, RoomNumber = "505", Type = "Tek Kişilik", Price = 850.00m, Description = "Plaj manzaralı tek kişilik oda", IsAvailable = true, HotelId = 5, PictureUrl = "/images/room-45.jpg" },
    new Room { RoomId = 46, RoomNumber = "506", Type = "Çift Kişilik", Price = 1200.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 5, PictureUrl = "/images/room-46.jpg" },
    new Room { RoomId = 47, RoomNumber = "507", Type = "Aile Odası", Price = 1500.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 5, PictureUrl = "/images/room-47.jpg" },
    new Room { RoomId = 48, RoomNumber = "508", Type = "Süit", Price = 1800.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 5, PictureUrl = "/images/room-48.jpg" },
    new Room { RoomId = 49, RoomNumber = "509", Type = "Tek Kişilik", Price = 850.00m, Description = "Plaj manzaralı tek kişilik oda", IsAvailable = true, HotelId = 5, PictureUrl = "/images/room-49.jpg" },
    new Room { RoomId = 50, RoomNumber = "510", Type = "Çift Kişilik", Price = 1200.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 5, PictureUrl = "/images/room-50.jpg" },

    // Hotel 6 Rooms
    new Room { RoomId = 51, RoomNumber = "601", Type = "Tek Kişilik", Price = 950.00m, Description = "Boğaz manzaralı tek kişilik oda", IsAvailable = true, HotelId = 6, PictureUrl = "/images/room-51.jpg" },
    new Room { RoomId = 52, RoomNumber = "602", Type = "Çift Kişilik", Price = 1300.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 6, PictureUrl = "/images/room-52.jpg" },
    new Room { RoomId = 53, RoomNumber = "603", Type = "Aile Odası", Price = 1600.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 6, PictureUrl = "/images/room-53.jpg" },
    new Room { RoomId = 54, RoomNumber = "604", Type = "Süit", Price = 1900.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 6, PictureUrl = "/images/room-54.jpg" },
    new Room { RoomId = 55, RoomNumber = "605", Type = "Tek Kişilik", Price = 950.00m, Description = "Boğaz manzaralı tek kişilik oda", IsAvailable = true, HotelId = 6, PictureUrl = "/images/room-55.jpg" },
    new Room { RoomId = 56, RoomNumber = "606", Type = "Çift Kişilik", Price = 1300.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 6, PictureUrl = "/images/room-56.jpg" },
    new Room { RoomId = 57, RoomNumber = "607", Type = "Aile Odası", Price = 1600.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 6, PictureUrl = "/images/room-57.jpg" },
    new Room { RoomId = 58, RoomNumber = "608", Type = "Süit", Price = 1900.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 6, PictureUrl = "/images/room-58.jpg" },
    new Room { RoomId = 59, RoomNumber = "609", Type = "Tek Kişilik", Price = 950.00m, Description = "Boğaz manzaralı tek kişilik oda", IsAvailable = true, HotelId = 6, PictureUrl = "/images/room-59.jpg" },
    new Room { RoomId = 60, RoomNumber = "610", Type = "Çift Kişilik", Price = 1300.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 6, PictureUrl = "/images/room-60.jpg" },

    // Hotel 7 Rooms
    new Room { RoomId = 61, RoomNumber = "701", Type = "Tek Kişilik", Price = 800.00m, Description = "Yeşil vadi manzaralı tek kişilik oda", IsAvailable = true, HotelId = 7, PictureUrl = "/images/room-61.jpg" },
    new Room { RoomId = 62, RoomNumber = "702", Type = "Çift Kişilik", Price = 1100.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 7, PictureUrl = "/images/room-62.jpg" },
    new Room { RoomId = 63, RoomNumber = "703", Type = "Aile Odası", Price = 1400.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 7, PictureUrl = "/images/room-63.jpg" },
    new Room { RoomId = 64, RoomNumber = "704", Type = "Süit", Price = 1700.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 7, PictureUrl = "/images/room-64.jpg" },
    new Room { RoomId = 65, RoomNumber = "705", Type = "Tek Kişilik", Price = 800.00m, Description = "Yeşil vadi manzaralı tek kişilik oda", IsAvailable = true, HotelId = 7, PictureUrl = "/images/room-65.jpg" },
    new Room { RoomId = 66, RoomNumber = "706", Type = "Çift Kişilik", Price = 1100.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 7, PictureUrl = "/images/room-66.jpg" },
    new Room { RoomId = 67, RoomNumber = "707", Type = "Aile Odası", Price = 1400.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 7, PictureUrl = "/images/room-67.jpg" },
    new Room { RoomId = 68, RoomNumber = "708", Type = "Süit", Price = 1700.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 7, PictureUrl = "/images/room-68.jpg" },
    new Room { RoomId = 69, RoomNumber = "709", Type = "Tek Kişilik", Price = 800.00m, Description = "Yeşil vadi manzaralı tek kişilik oda", IsAvailable = true, HotelId = 7, PictureUrl = "/images/room-69.jpg" },
    new Room { RoomId = 70, RoomNumber = "710", Type = "Çift Kişilik", Price = 1100.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 7, PictureUrl = "/images/room-70.jpg" },

    // Hotel 8 Rooms
    new Room { RoomId = 71, RoomNumber = "801", Type = "Tek Kişilik", Price = 900.00m, Description = "Deniz manzaralı tek kişilik oda", IsAvailable = true, HotelId = 8, PictureUrl = "/images/room-71.jpg" },
    new Room { RoomId = 72, RoomNumber = "802", Type = "Çift Kişilik", Price = 1300.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 8, PictureUrl = "/images/room-72.jpg" },
    new Room { RoomId = 73, RoomNumber = "803", Type = "Aile Odası", Price = 1600.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 8, PictureUrl = "/images/room-73.jpg" },
    new Room { RoomId = 74, RoomNumber = "804", Type = "Süit", Price = 1900.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 8, PictureUrl = "/images/room-74.jpg" },
    new Room { RoomId = 75, RoomNumber = "805", Type = "Tek Kişilik", Price = 900.00m, Description = "Deniz manzaralı tek kişilik oda", IsAvailable = true, HotelId = 8, PictureUrl = "/images/room-75.jpg" },
    new Room { RoomId = 76, RoomNumber = "806", Type = "Çift Kişilik", Price = 1300.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 8, PictureUrl = "/images/room-76.jpg" },
    new Room { RoomId = 77, RoomNumber = "807", Type = "Aile Odası", Price = 1600.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 8, PictureUrl = "/images/room-77.jpg" },
    new Room { RoomId = 78, RoomNumber = "808", Type = "Süit", Price = 1900.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 8, PictureUrl = "/images/room-78.jpg" },
    new Room { RoomId = 79, RoomNumber = "809", Type = "Tek Kişilik", Price = 900.00m, Description = "Deniz manzaralı tek kişilik oda", IsAvailable = true, HotelId = 8, PictureUrl = "/images/room-79.jpg" },
    new Room { RoomId = 80, RoomNumber = "810", Type = "Çift Kişilik", Price = 1300.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 8, PictureUrl = "/images/room-80.jpg" },

    // Hotel 9 Rooms
    new Room { RoomId = 81, RoomNumber = "901", Type = "Tek Kişilik", Price = 950.00m, Description = "Kaplıca manzaralı tek kişilik oda", IsAvailable = true, HotelId = 9, PictureUrl = "/images/room-81.jpg" },
    new Room { RoomId = 82, RoomNumber = "902", Type = "Çift Kişilik", Price = 1400.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 9, PictureUrl = "/images/room-82.jpg" },
    new Room { RoomId = 83, RoomNumber = "903", Type = "Aile Odası", Price = 1700.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 9, PictureUrl = "/images/room-83.jpg" },
    new Room { RoomId = 84, RoomNumber = "904", Type = "Süit", Price = 2000.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 9, PictureUrl = "/images/room-84.jpg" },
    new Room { RoomId = 85, RoomNumber = "905", Type = "Tek Kişilik", Price = 950.00m, Description = "Kaplıca manzaralı tek kişilik oda", IsAvailable = true, HotelId = 9, PictureUrl = "/images/room-85.jpg" },
    new Room { RoomId = 86, RoomNumber = "906", Type = "Çift Kişilik", Price = 1400.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 9, PictureUrl = "/images/room-86.jpg" },
    new Room { RoomId = 87, RoomNumber = "907", Type = "Aile Odası", Price = 1700.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 9, PictureUrl = "/images/room-87.jpg" },
    new Room { RoomId = 88, RoomNumber = "908", Type = "Süit", Price = 2000.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 9, PictureUrl = "/images/room-88.jpg" },
    new Room { RoomId = 89, RoomNumber = "909", Type = "Tek Kişilik", Price = 950.00m, Description = "Kaplıca manzaralı tek kişilik oda", IsAvailable = true, HotelId = 9, PictureUrl = "/images/room-89.jpg" },
    new Room { RoomId = 90, RoomNumber = "910", Type = "Çift Kişilik", Price = 1400.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 9, PictureUrl = "/images/room-90.jpg" },

    // Hotel 10 Rooms
    new Room { RoomId = 91, RoomNumber = "1001", Type = "Tek Kişilik", Price = 850.00m, Description = "Ege manzaralı tek kişilik oda", IsAvailable = true, HotelId = 10, PictureUrl = "/images/room-91.jpg" },
    new Room { RoomId = 92, RoomNumber = "1002", Type = "Çift Kişilik", Price = 1200.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 10, PictureUrl = "/images/room-92.jpg" },
    new Room { RoomId = 93, RoomNumber = "1003", Type = "Aile Odası", Price = 1500.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 10, PictureUrl = "/images/room-93.jpg" },
    new Room { RoomId = 94, RoomNumber = "1004", Type = "Süit", Price = 1800.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 10, PictureUrl = "/images/room-94.jpg" },
    new Room { RoomId = 95, RoomNumber = "1005", Type = "Tek Kişilik", Price = 850.00m, Description = "Ege manzaralı tek kişilik oda", IsAvailable = true, HotelId = 10, PictureUrl = "/images/room-95.jpg" },
    new Room { RoomId = 96, RoomNumber = "1006", Type = "Çift Kişilik", Price = 1200.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 10, PictureUrl = "/images/room-96.jpg" },
    new Room { RoomId = 97, RoomNumber = "1007", Type = "Aile Odası", Price = 1500.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 10, PictureUrl = "/images/room-97.jpg" },
    new Room { RoomId = 98, RoomNumber = "1008", Type = "Süit", Price = 1800.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 10, PictureUrl = "/images/room-98.jpg" },
    new Room { RoomId = 99, RoomNumber = "1009", Type = "Tek Kişilik", Price = 850.00m, Description = "Ege manzaralı tek kişilik oda", IsAvailable = true, HotelId = 10, PictureUrl = "/images/room-99.jpg" },
    new Room { RoomId = 100, RoomNumber = "1010", Type = "Çift Kişilik", Price = 1200.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 10, PictureUrl = "/images/room-100.jpg" },

    // Hotel 11 Rooms
    new Room { RoomId = 101, RoomNumber = "1101", Type = "Tek Kişilik", Price = 750.00m, Description = "Tarihi dokusuyla tek kişilik oda", IsAvailable = true, HotelId = 11, PictureUrl = "/images/room-101.jpg" },
    new Room { RoomId = 102, RoomNumber = "1102", Type = "Çift Kişilik", Price = 1200.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 11, PictureUrl = "/images/room-102.jpg" },
    new Room { RoomId = 103, RoomNumber = "1103", Type = "Aile Odası", Price = 1500.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 11, PictureUrl = "/images/room-103.jpg" },
    new Room { RoomId = 104, RoomNumber = "1104", Type = "Süit", Price = 1800.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 11, PictureUrl = "/images/room-104.jpg" },
    new Room { RoomId = 105, RoomNumber = "1105", Type = "Tek Kişilik", Price = 750.00m, Description = "Tarihi dokusuyla tek kişilik oda", IsAvailable = true, HotelId = 11, PictureUrl = "/images/room-105.jpg" },
    new Room { RoomId = 106, RoomNumber = "1106", Type = "Çift Kişilik", Price = 1200.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 11, PictureUrl = "/images/room-106.jpg" },
    new Room { RoomId = 107, RoomNumber = "1107", Type = "Aile Odası", Price = 1500.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 11, PictureUrl = "/images/room-107.jpg" },
    new Room { RoomId = 108, RoomNumber = "1108", Type = "Süit", Price = 1800.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 11, PictureUrl = "/images/room-108.jpg" },
    new Room { RoomId = 109, RoomNumber = "1109", Type = "Tek Kişilik", Price = 750.00m, Description = "Tarihi dokusuyla tek kişilik oda", IsAvailable = true, HotelId = 11, PictureUrl = "/images/room-109.jpg" },
    new Room { RoomId = 110, RoomNumber = "1110", Type = "Çift Kişilik", Price = 1200.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 11, PictureUrl = "/images/room-110.jpg" },

    // Hotel 12 Rooms
    new Room { RoomId = 111, RoomNumber = "1201", Type = "Tek Kişilik", Price = 850.00m, Description = "Butik tarzda tek kişilik oda", IsAvailable = true, HotelId = 12, PictureUrl = "/images/room-111.jpg" },
    new Room { RoomId = 112, RoomNumber = "1202", Type = "Çift Kişilik", Price = 1200.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 12, PictureUrl = "/images/room-112.jpg" },
    new Room { RoomId = 113, RoomNumber = "1203", Type = "Aile Odası", Price = 1500.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 12, PictureUrl = "/images/room-113.jpg" },
    new Room { RoomId = 114, RoomNumber = "1204", Type = "Süit", Price = 1800.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 12, PictureUrl = "/images/room-114.jpg" },
    new Room { RoomId = 115, RoomNumber = "1205", Type = "Tek Kişilik", Price = 850.00m, Description = "Butik tarzda tek kişilik oda", IsAvailable = true, HotelId = 12, PictureUrl = "/images/room-115.jpg" },
    new Room { RoomId = 116, RoomNumber = "1206", Type = "Çift Kişilik", Price = 1200.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 12, PictureUrl = "/images/room-116.jpg" },
    new Room { RoomId = 117, RoomNumber = "1207", Type = "Aile Odası", Price = 1500.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 12, PictureUrl = "/images/room-117.jpg" },
    new Room { RoomId = 118, RoomNumber = "1208", Type = "Süit", Price = 1800.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 12, PictureUrl = "/images/room-118.jpg" },
    new Room { RoomId = 119, RoomNumber = "1209", Type = "Tek Kişilik", Price = 850.00m, Description = "Butik tarzda tek kişilik oda", IsAvailable = true, HotelId = 12, PictureUrl = "/images/room-119.jpg" },
    new Room { RoomId = 120, RoomNumber = "1210", Type = "Çift Kişilik", Price = 1200.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 12, PictureUrl = "/images/room-120.jpg" },

    // Hotel 13 Rooms
    new Room { RoomId = 121, RoomNumber = "1301", Type = "Tek Kişilik", Price = 900.00m, Description = "Kayak merkezine yakın tek kişilik oda", IsAvailable = true, HotelId = 13, PictureUrl = "/images/room-121.jpg" },
    new Room { RoomId = 122, RoomNumber = "1302", Type = "Çift Kişilik", Price = 1400.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 13, PictureUrl = "/images/room-122.jpg" },
    new Room { RoomId = 123, RoomNumber = "1303", Type = "Aile Odası", Price = 1700.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 13, PictureUrl = "/images/room-123.jpg" },
    new Room { RoomId = 124, RoomNumber = "1304", Type = "Süit", Price = 2000.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 13, PictureUrl = "/images/room-124.jpg" },
    new Room { RoomId = 125, RoomNumber = "1305", Type = "Tek Kişilik", Price = 900.00m, Description = "Kayak merkezine yakın tek kişilik oda", IsAvailable = true, HotelId = 13, PictureUrl = "/images/room-125.jpg" },
    new Room { RoomId = 126, RoomNumber = "1306", Type = "Çift Kişilik", Price = 1400.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 13, PictureUrl = "/images/room-126.jpg" },
    new Room { RoomId = 127, RoomNumber = "1307", Type = "Aile Odası", Price = 1700.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 13, PictureUrl = "/images/room-127.jpg" },
    new Room { RoomId = 128, RoomNumber = "1308", Type = "Süit", Price = 2000.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 13, PictureUrl = "/images/room-128.jpg" },
    new Room { RoomId = 129, RoomNumber = "1309", Type = "Tek Kişilik", Price = 900.00m, Description = "Kayak merkezine yakın tek kişilik oda", IsAvailable = true, HotelId = 13, PictureUrl = "/images/room-129.jpg" },
    new Room { RoomId = 130, RoomNumber = "1310", Type = "Çift Kişilik", Price = 1400.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 13, PictureUrl = "/images/room-130.jpg" },

    // Hotel 14 Rooms
    new Room { RoomId = 131, RoomNumber = "1401", Type = "Tek Kişilik", Price = 1000.00m, Description = "Spa merkezine yakın tek kişilik oda", IsAvailable = true, HotelId = 14, PictureUrl = "/images/room-131.jpg" },
    new Room { RoomId = 132, RoomNumber = "1402", Type = "Çift Kişilik", Price = 1500.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 14, PictureUrl = "/images/room-132.jpg" },
    new Room { RoomId = 133, RoomNumber = "1403", Type = "Aile Odası", Price = 1800.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 14, PictureUrl = "/images/room-133.jpg" },
    new Room { RoomId = 134, RoomNumber = "1404", Type = "Süit", Price = 2100.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 14, PictureUrl = "/images/room-134.jpg" },
    new Room { RoomId = 135, RoomNumber = "1405", Type = "Tek Kişilik", Price = 1000.00m, Description = "Spa merkezine yakın tek kişilik oda", IsAvailable = true, HotelId = 14, PictureUrl = "/images/room-135.jpg" },
    new Room { RoomId = 136, RoomNumber = "1406", Type = "Çift Kişilik", Price = 1500.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 14, PictureUrl = "/images/room-136.jpg" },
    new Room { RoomId = 137, RoomNumber = "1407", Type = "Aile Odası", Price = 1800.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 14, PictureUrl = "/images/room-137.jpg" },
    new Room { RoomId = 138, RoomNumber = "1408", Type = "Süit", Price = 2100.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 14, PictureUrl = "/images/room-138.jpg" },
    new Room { RoomId = 139, RoomNumber = "1409", Type = "Tek Kişilik", Price = 1000.00m, Description = "Spa merkezine yakın tek kişilik oda", IsAvailable = true, HotelId = 14, PictureUrl = "/images/room-139.jpg" },
    new Room { RoomId = 140, RoomNumber = "1410", Type = "Çift Kişilik", Price = 1500.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 14, PictureUrl = "/images/room-140.jpg" },

    // Hotel 15 Rooms
    new Room { RoomId = 141, RoomNumber = "1501", Type = "Tek Kişilik", Price = 1200.00m, Description = "Lüks tatil köyünde tek kişilik oda", IsAvailable = true, HotelId = 15, PictureUrl = "/images/room-141.jpg" },
    new Room { RoomId = 142, RoomNumber = "1502", Type = "Çift Kişilik", Price = 1600.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 15, PictureUrl = "/images/room-142.jpg" },
    new Room { RoomId = 143, RoomNumber = "1503", Type = "Aile Odası", Price = 2000.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 15, PictureUrl = "/images/room-143.jpg" },
    new Room { RoomId = 144, RoomNumber = "1504", Type = "Süit", Price = 2500.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 15, PictureUrl = "/images/room-144.jpg" },
    new Room { RoomId = 145, RoomNumber = "1505", Type = "Tek Kişilik", Price = 1200.00m, Description = "Lüks tatil köyünde tek kişilik oda", IsAvailable = true, HotelId = 15, PictureUrl = "/images/room-145.jpg" },
    new Room { RoomId = 146, RoomNumber = "1506", Type = "Çift Kişilik", Price = 1600.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 15, PictureUrl = "/images/room-146.jpg" },
    new Room { RoomId = 147, RoomNumber = "1507", Type = "Aile Odası", Price = 2000.00m, Description = "Geniş aile odası", IsAvailable = true, HotelId = 15, PictureUrl = "/images/room-147.jpg" },
    new Room { RoomId = 148, RoomNumber = "1508", Type = "Süit", Price = 2500.00m, Description = "Lüks süit oda", IsAvailable = true, HotelId = 15, PictureUrl = "/images/room-148.jpg" },
    new Room { RoomId = 149, RoomNumber = "1509", Type = "Tek Kişilik", Price = 1200.00m, Description = "Lüks tatil köyünde tek kişilik oda", IsAvailable = true, HotelId = 15, PictureUrl = "/images/room-149.jpg" },
    new Room { RoomId = 150, RoomNumber = "1510", Type = "Çift Kişilik", Price = 1600.00m, Description = "Geniş çift kişilik oda", IsAvailable = true, HotelId = 15, PictureUrl = "/images/room-150.jpg" }
);



            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    FirstName = "Ahmet",
                    LastName = "Yılmaz",
                    Email = "ahmet.yilmaz@example.com",
                    Phone = "0532-123-4567",
                    IdentityUserId = "1"
                },
                new Customer
                {
                    CustomerId = 2,
                    FirstName = "Ayşe",
                    LastName = "Kara",
                    Email = "ayse.kara@example.com",
                    Phone = "0543-987-6543",
                    IdentityUserId = "2"
                }
            );

            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    PaymentId = 1,
                    PaymentDate = new DateTime(2024, 6, 28),
                    Amount = 1000.00m, // TL cinsinden
                    PaymentMethod = "Kredi Kartı",
                    ReservationId = 1
                },
                new Payment
                {
                    PaymentId = 2,
                    PaymentDate = new DateTime(2024, 6, 29),
                    Amount = 2000.00m, // TL cinsinden
                    PaymentMethod = "Nakit",
                    ReservationId = 2
                }
            );

            modelBuilder.Entity<Reservation>().HasData(
                new Reservation
                {
                    ReservationId = 1,
                    CheckInDate = new DateTime(2024, 6, 28),
                    CheckOutDate = new DateTime(2024, 6, 30),
                    TotalPrice = 1500.00m, // TL cinsinden
                    ReservationStatus = "Onaylandı",
                    CustomerId = 1,
                    RoomId = 1
                },
                new Reservation
                {
                    ReservationId = 2,
                    CheckInDate = new DateTime(2024, 7, 1),
                    CheckOutDate = new DateTime(2024, 7, 5),
                    TotalPrice = 4000.00m, // TL cinsinden
                    ReservationStatus = "Onaylandı",
                    CustomerId = 2,
                    RoomId = 3
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
