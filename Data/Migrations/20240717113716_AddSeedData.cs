using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Address", "City", "Country", "Description", "Name", "PictureUrl", "Rating" },
                values: new object[,]
                {
                    { 3, "Dağ Yolu No:789", "Bursa", "Türkiye", "Dağ manzaralı huzurlu bir otel.", "Dağ Evi", "/images/hotel-3.jpg", 4.7999999999999998 },
                    { 4, "Merkez Mahallesi No:321", "Ankara", "Türkiye", "Şehir merkezinde konforlu bir otel.", "Şehir Oteli", "/images/hotel-4.jpg", 4.2999999999999998 },
                    { 5, "Plaj Yolu No:654", "İzmir", "Türkiye", "Tatil köyünde huzurlu bir konaklama.", "Tatil Köyü", "/images/hotel-5.jpg", 4.5999999999999996 },
                    { 6, "Boğaz Sokak No:987", "İstanbul", "Türkiye", "Boğaz manzaralı lüks bir otel.", "Boğaz Oteli", "/images/hotel-6.jpg", 4.9000000000000004 },
                    { 7, "Vadi Caddesi No:147", "Trabzon", "Türkiye", "Yeşillikler içinde huzurlu bir otel.", "Yeşil Vadi Oteli", "/images/hotel-7.jpg", 4.5 },
                    { 8, "Deniz Caddesi No:258", "Muğla", "Türkiye", "Deniz kenarında lüks bir tatil köyü.", "Deniz Tatil Köyü", "/images/hotel-8.jpg", 4.7000000000000002 },
                    { 9, "Kaplıca Yolu No:369", "Afyon", "Türkiye", "Kaplıca suları ile ünlü bir otel.", "Kaplıca Oteli", "/images/hotel-9.jpg", 4.4000000000000004 },
                    { 10, "Ege Sahili No:951", "İzmir", "Türkiye", "Ege Denizi kıyısında konforlu bir otel.", "Ege Oteli", "/images/hotel-10.jpg", 4.5999999999999996 },
                    { 11, "Tarihi Sokak No:753", "İstanbul", "Türkiye", "Tarihi dokusuyla dikkat çeken bir otel.", "Tarihi Otel", "/images/hotel-11.jpg", 4.7999999999999998 },
                    { 12, "Şirin Sokak No:159", "Antalya", "Türkiye", "Butik tarzda küçük ve sevimli bir otel.", "Butik Otel", "/images/hotel-12.jpg", 4.4000000000000004 },
                    { 13, "Kayak Yolu No:852", "Erzurum", "Türkiye", "Kayak merkezine yakın bir otel.", "Kayak Oteli", "/images/hotel-13.jpg", 4.5 },
                    { 14, "Spa Sokak No:951", "Bolu", "Türkiye", "Spa hizmetleri ile ünlü bir otel.", "Spa Oteli", "/images/hotel-14.jpg", 4.7000000000000002 },
                    { 15, "Lüks Caddesi No:753", "Muğla", "Türkiye", "Lüks hizmetleri ile ünlü bir tatil köyü.", "Lüks Tatil Köyü", "/images/hotel-15.jpg", 4.9000000000000004 }
                });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3,
                column: "Price",
                value: 1500.00m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 4,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Lüks süit oda", 1800.00m });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 5,
                columns: new[] { "Description", "HotelId", "PictureUrl", "Price", "RoomNumber", "Type" },
                values: new object[] { "Konforlu tek kişilik oda", 1, "/images/room-1.jpg", 750.00m, "105", "Tek Kişilik" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 6,
                columns: new[] { "HotelId", "PictureUrl", "Price", "RoomNumber", "Type" },
                values: new object[] { 1, "/images/room-2.jpg", 1200.00m, "106", "Çift Kişilik" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 7,
                columns: new[] { "HotelId", "PictureUrl", "Price", "RoomNumber" },
                values: new object[] { 1, "/images/room-3.jpg", 1500.00m, "107" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 8,
                columns: new[] { "Description", "HotelId", "PictureUrl", "Price", "RoomNumber" },
                values: new object[] { "Lüks süit oda", 1, "/images/room-4.jpg", 1800.00m, "108" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Description", "HotelId", "IsAvailable", "PictureUrl", "Price", "RoomNumber", "Type" },
                values: new object[,]
                {
                    { 9, "Konforlu tek kişilik oda", 1, true, "/images/room-1.jpg", 750.00m, "109", "Tek Kişilik" },
                    { 10, "Geniş çift kişilik oda", 1, true, "/images/room-2.jpg", 1200.00m, "110", "Çift Kişilik" },
                    { 11, "Deniz manzaralı tek kişilik oda", 2, true, "/images/room-5.jpg", 850.00m, "201", "Tek Kişilik" },
                    { 12, "Geniş çift kişilik oda", 2, true, "/images/room-6.jpg", 1200.00m, "202", "Çift Kişilik" },
                    { 13, "Geniş aile odası", 2, true, "/images/room-7.jpg", 1500.00m, "203", "Aile Odası" },
                    { 14, "Lüks süit oda", 2, true, "/images/room-8.jpg", 1800.00m, "204", "Süit" },
                    { 15, "Deniz manzaralı tek kişilik oda", 2, true, "/images/room-5.jpg", 850.00m, "205", "Tek Kişilik" },
                    { 16, "Geniş çift kişilik oda", 2, true, "/images/room-6.jpg", 1200.00m, "206", "Çift Kişilik" },
                    { 17, "Geniş aile odası", 2, true, "/images/room-7.jpg", 1500.00m, "207", "Aile Odası" },
                    { 18, "Lüks süit oda", 2, true, "/images/room-8.jpg", 1800.00m, "208", "Süit" },
                    { 19, "Deniz manzaralı tek kişilik oda", 2, true, "/images/room-5.jpg", 850.00m, "209", "Tek Kişilik" },
                    { 20, "Geniş çift kişilik oda", 2, true, "/images/room-6.jpg", 1200.00m, "210", "Çift Kişilik" },
                    { 21, "Dağ manzaralı tek kişilik oda", 3, true, "/images/room-9.jpg", 700.00m, "301", "Tek Kişilik" },
                    { 22, "Geniş çift kişilik oda", 3, true, "/images/room-10.jpg", 1100.00m, "302", "Çift Kişilik" },
                    { 23, "Geniş aile odası", 3, true, "/images/room-11.jpg", 1400.00m, "303", "Aile Odası" },
                    { 24, "Lüks süit oda", 3, true, "/images/room-12.jpg", 1700.00m, "304", "Süit" },
                    { 25, "Dağ manzaralı tek kişilik oda", 3, true, "/images/room-9.jpg", 700.00m, "305", "Tek Kişilik" },
                    { 26, "Geniş çift kişilik oda", 3, true, "/images/room-10.jpg", 1100.00m, "306", "Çift Kişilik" },
                    { 27, "Geniş aile odası", 3, true, "/images/room-11.jpg", 1400.00m, "307", "Aile Odası" },
                    { 28, "Lüks süit oda", 3, true, "/images/room-12.jpg", 1700.00m, "308", "Süit" },
                    { 29, "Dağ manzaralı tek kişilik oda", 3, true, "/images/room-9.jpg", 700.00m, "309", "Tek Kişilik" },
                    { 30, "Geniş çift kişilik oda", 3, true, "/images/room-10.jpg", 1100.00m, "310", "Çift Kişilik" },
                    { 31, "Şehir manzaralı tek kişilik oda", 4, true, "/images/room-1.jpg", 750.00m, "401", "Tek Kişilik" },
                    { 32, "Geniş çift kişilik oda", 4, true, "/images/room-2.jpg", 1200.00m, "402", "Çift Kişilik" },
                    { 33, "Geniş aile odası", 4, true, "/images/room-3.jpg", 1500.00m, "403", "Aile Odası" },
                    { 34, "Lüks süit oda", 4, true, "/images/room-4.jpg", 1800.00m, "404", "Süit" },
                    { 35, "Şehir manzaralı tek kişilik oda", 4, true, "/images/room-1.jpg", 750.00m, "405", "Tek Kişilik" },
                    { 36, "Geniş çift kişilik oda", 4, true, "/images/room-2.jpg", 1200.00m, "406", "Çift Kişilik" },
                    { 37, "Geniş aile odası", 4, true, "/images/room-3.jpg", 1500.00m, "407", "Aile Odası" },
                    { 38, "Lüks süit oda", 4, true, "/images/room-4.jpg", 1800.00m, "408", "Süit" },
                    { 39, "Şehir manzaralı tek kişilik oda", 4, true, "/images/room-1.jpg", 750.00m, "409", "Tek Kişilik" },
                    { 40, "Geniş çift kişilik oda", 4, true, "/images/room-2.jpg", 1200.00m, "410", "Çift Kişilik" },
                    { 41, "Plaj manzaralı tek kişilik oda", 5, true, "/images/room-5.jpg", 850.00m, "501", "Tek Kişilik" },
                    { 42, "Geniş çift kişilik oda", 5, true, "/images/room-6.jpg", 1200.00m, "502", "Çift Kişilik" },
                    { 43, "Geniş aile odası", 5, true, "/images/room-7.jpg", 1500.00m, "503", "Aile Odası" },
                    { 44, "Lüks süit oda", 5, true, "/images/room-8.jpg", 1800.00m, "504", "Süit" },
                    { 45, "Plaj manzaralı tek kişilik oda", 5, true, "/images/room-5.jpg", 850.00m, "505", "Tek Kişilik" },
                    { 46, "Geniş çift kişilik oda", 5, true, "/images/room-6.jpg", 1200.00m, "506", "Çift Kişilik" },
                    { 47, "Geniş aile odası", 5, true, "/images/room-7.jpg", 1500.00m, "507", "Aile Odası" },
                    { 48, "Lüks süit oda", 5, true, "/images/room-8.jpg", 1800.00m, "508", "Süit" },
                    { 49, "Plaj manzaralı tek kişilik oda", 5, true, "/images/room-5.jpg", 850.00m, "509", "Tek Kişilik" },
                    { 50, "Geniş çift kişilik oda", 5, true, "/images/room-6.jpg", 1200.00m, "510", "Çift Kişilik" },
                    { 51, "Boğaz manzaralı tek kişilik oda", 6, true, "/images/room-1.jpg", 950.00m, "601", "Tek Kişilik" },
                    { 52, "Geniş çift kişilik oda", 6, true, "/images/room-2.jpg", 1300.00m, "602", "Çift Kişilik" },
                    { 53, "Geniş aile odası", 6, true, "/images/room-3.jpg", 1600.00m, "603", "Aile Odası" },
                    { 54, "Lüks süit oda", 6, true, "/images/room-4.jpg", 1900.00m, "604", "Süit" },
                    { 55, "Boğaz manzaralı tek kişilik oda", 6, true, "/images/room-1.jpg", 950.00m, "605", "Tek Kişilik" },
                    { 56, "Geniş çift kişilik oda", 6, true, "/images/room-2.jpg", 1300.00m, "606", "Çift Kişilik" },
                    { 57, "Geniş aile odası", 6, true, "/images/room-3.jpg", 1600.00m, "607", "Aile Odası" },
                    { 58, "Lüks süit oda", 6, true, "/images/room-4.jpg", 1900.00m, "608", "Süit" },
                    { 59, "Boğaz manzaralı tek kişilik oda", 6, true, "/images/room-1.jpg", 950.00m, "609", "Tek Kişilik" },
                    { 60, "Geniş çift kişilik oda", 6, true, "/images/room-2.jpg", 1300.00m, "610", "Çift Kişilik" },
                    { 61, "Yeşil vadi manzaralı tek kişilik oda", 7, true, "/images/room-9.jpg", 800.00m, "701", "Tek Kişilik" },
                    { 62, "Geniş çift kişilik oda", 7, true, "/images/room-10.jpg", 1100.00m, "702", "Çift Kişilik" },
                    { 63, "Geniş aile odası", 7, true, "/images/room-11.jpg", 1400.00m, "703", "Aile Odası" },
                    { 64, "Lüks süit oda", 7, true, "/images/room-12.jpg", 1700.00m, "704", "Süit" },
                    { 65, "Yeşil vadi manzaralı tek kişilik oda", 7, true, "/images/room-9.jpg", 800.00m, "705", "Tek Kişilik" },
                    { 66, "Geniş çift kişilik oda", 7, true, "/images/room-10.jpg", 1100.00m, "706", "Çift Kişilik" },
                    { 67, "Geniş aile odası", 7, true, "/images/room-11.jpg", 1400.00m, "707", "Aile Odası" },
                    { 68, "Lüks süit oda", 7, true, "/images/room-12.jpg", 1700.00m, "708", "Süit" },
                    { 69, "Yeşil vadi manzaralı tek kişilik oda", 7, true, "/images/room-9.jpg", 800.00m, "709", "Tek Kişilik" },
                    { 70, "Geniş çift kişilik oda", 7, true, "/images/room-10.jpg", 1100.00m, "710", "Çift Kişilik" },
                    { 71, "Deniz manzaralı tek kişilik oda", 8, true, "/images/room-5.jpg", 900.00m, "801", "Tek Kişilik" },
                    { 72, "Geniş çift kişilik oda", 8, true, "/images/room-6.jpg", 1300.00m, "802", "Çift Kişilik" },
                    { 73, "Geniş aile odası", 8, true, "/images/room-7.jpg", 1600.00m, "803", "Aile Odası" },
                    { 74, "Lüks süit oda", 8, true, "/images/room-8.jpg", 1900.00m, "804", "Süit" },
                    { 75, "Deniz manzaralı tek kişilik oda", 8, true, "/images/room-5.jpg", 900.00m, "805", "Tek Kişilik" },
                    { 76, "Geniş çift kişilik oda", 8, true, "/images/room-6.jpg", 1300.00m, "806", "Çift Kişilik" },
                    { 77, "Geniş aile odası", 8, true, "/images/room-7.jpg", 1600.00m, "807", "Aile Odası" },
                    { 78, "Lüks süit oda", 8, true, "/images/room-8.jpg", 1900.00m, "808", "Süit" },
                    { 79, "Deniz manzaralı tek kişilik oda", 8, true, "/images/room-5.jpg", 900.00m, "809", "Tek Kişilik" },
                    { 80, "Geniş çift kişilik oda", 8, true, "/images/room-6.jpg", 1300.00m, "810", "Çift Kişilik" },
                    { 81, "Kaplıca manzaralı tek kişilik oda", 9, true, "/images/room-9.jpg", 950.00m, "901", "Tek Kişilik" },
                    { 82, "Geniş çift kişilik oda", 9, true, "/images/room-10.jpg", 1400.00m, "902", "Çift Kişilik" },
                    { 83, "Geniş aile odası", 9, true, "/images/room-11.jpg", 1700.00m, "903", "Aile Odası" },
                    { 84, "Lüks süit oda", 9, true, "/images/room-12.jpg", 2000.00m, "904", "Süit" },
                    { 85, "Kaplıca manzaralı tek kişilik oda", 9, true, "/images/room-9.jpg", 950.00m, "905", "Tek Kişilik" },
                    { 86, "Geniş çift kişilik oda", 9, true, "/images/room-10.jpg", 1400.00m, "906", "Çift Kişilik" },
                    { 87, "Geniş aile odası", 9, true, "/images/room-11.jpg", 1700.00m, "907", "Aile Odası" },
                    { 88, "Lüks süit oda", 9, true, "/images/room-12.jpg", 2000.00m, "908", "Süit" },
                    { 89, "Kaplıca manzaralı tek kişilik oda", 9, true, "/images/room-9.jpg", 950.00m, "909", "Tek Kişilik" },
                    { 90, "Geniş çift kişilik oda", 9, true, "/images/room-10.jpg", 1400.00m, "910", "Çift Kişilik" },
                    { 91, "Ege manzaralı tek kişilik oda", 10, true, "/images/room-1.jpg", 850.00m, "1001", "Tek Kişilik" },
                    { 92, "Geniş çift kişilik oda", 10, true, "/images/room-2.jpg", 1200.00m, "1002", "Çift Kişilik" },
                    { 93, "Geniş aile odası", 10, true, "/images/room-3.jpg", 1500.00m, "1003", "Aile Odası" },
                    { 94, "Lüks süit oda", 10, true, "/images/room-4.jpg", 1800.00m, "1004", "Süit" },
                    { 95, "Ege manzaralı tek kişilik oda", 10, true, "/images/room-1.jpg", 850.00m, "1005", "Tek Kişilik" },
                    { 96, "Geniş çift kişilik oda", 10, true, "/images/room-2.jpg", 1200.00m, "1006", "Çift Kişilik" },
                    { 97, "Geniş aile odası", 10, true, "/images/room-3.jpg", 1500.00m, "1007", "Aile Odası" },
                    { 98, "Lüks süit oda", 10, true, "/images/room-4.jpg", 1800.00m, "1008", "Süit" },
                    { 99, "Ege manzaralı tek kişilik oda", 10, true, "/images/room-1.jpg", 850.00m, "1009", "Tek Kişilik" },
                    { 100, "Geniş çift kişilik oda", 10, true, "/images/room-2.jpg", 1200.00m, "1010", "Çift Kişilik" },
                    { 101, "Tarihi dokusuyla tek kişilik oda", 11, true, "/images/room-9.jpg", 750.00m, "1101", "Tek Kişilik" },
                    { 102, "Geniş çift kişilik oda", 11, true, "/images/room-10.jpg", 1200.00m, "1102", "Çift Kişilik" },
                    { 103, "Geniş aile odası", 11, true, "/images/room-11.jpg", 1500.00m, "1103", "Aile Odası" },
                    { 104, "Lüks süit oda", 11, true, "/images/room-12.jpg", 1800.00m, "1104", "Süit" },
                    { 105, "Tarihi dokusuyla tek kişilik oda", 11, true, "/images/room-9.jpg", 750.00m, "1105", "Tek Kişilik" },
                    { 106, "Geniş çift kişilik oda", 11, true, "/images/room-10.jpg", 1200.00m, "1106", "Çift Kişilik" },
                    { 107, "Geniş aile odası", 11, true, "/images/room-11.jpg", 1500.00m, "1107", "Aile Odası" },
                    { 108, "Lüks süit oda", 11, true, "/images/room-12.jpg", 1800.00m, "1108", "Süit" },
                    { 109, "Tarihi dokusuyla tek kişilik oda", 11, true, "/images/room-9.jpg", 750.00m, "1109", "Tek Kişilik" },
                    { 110, "Geniş çift kişilik oda", 11, true, "/images/room-10.jpg", 1200.00m, "1110", "Çift Kişilik" },
                    { 111, "Butik tarzda tek kişilik oda", 12, true, "/images/room-1.jpg", 850.00m, "1201", "Tek Kişilik" },
                    { 112, "Geniş çift kişilik oda", 12, true, "/images/room-2.jpg", 1200.00m, "1202", "Çift Kişilik" },
                    { 113, "Geniş aile odası", 12, true, "/images/room-3.jpg", 1500.00m, "1203", "Aile Odası" },
                    { 114, "Lüks süit oda", 12, true, "/images/room-4.jpg", 1800.00m, "1204", "Süit" },
                    { 115, "Butik tarzda tek kişilik oda", 12, true, "/images/room-1.jpg", 850.00m, "1205", "Tek Kişilik" },
                    { 116, "Geniş çift kişilik oda", 12, true, "/images/room-2.jpg", 1200.00m, "1206", "Çift Kişilik" },
                    { 117, "Geniş aile odası", 12, true, "/images/room-3.jpg", 1500.00m, "1207", "Aile Odası" },
                    { 118, "Lüks süit oda", 12, true, "/images/room-4.jpg", 1800.00m, "1208", "Süit" },
                    { 119, "Butik tarzda tek kişilik oda", 12, true, "/images/room-1.jpg", 850.00m, "1209", "Tek Kişilik" },
                    { 120, "Geniş çift kişilik oda", 12, true, "/images/room-2.jpg", 1200.00m, "1210", "Çift Kişilik" },
                    { 121, "Kayak merkezine yakın tek kişilik oda", 13, true, "/images/room-5.jpg", 900.00m, "1301", "Tek Kişilik" },
                    { 122, "Geniş çift kişilik oda", 13, true, "/images/room-6.jpg", 1400.00m, "1302", "Çift Kişilik" },
                    { 123, "Geniş aile odası", 13, true, "/images/room-7.jpg", 1700.00m, "1303", "Aile Odası" },
                    { 124, "Lüks süit oda", 13, true, "/images/room-8.jpg", 2000.00m, "1304", "Süit" },
                    { 125, "Kayak merkezine yakın tek kişilik oda", 13, true, "/images/room-5.jpg", 900.00m, "1305", "Tek Kişilik" },
                    { 126, "Geniş çift kişilik oda", 13, true, "/images/room-6.jpg", 1400.00m, "1306", "Çift Kişilik" },
                    { 127, "Geniş aile odası", 13, true, "/images/room-7.jpg", 1700.00m, "1307", "Aile Odası" },
                    { 128, "Lüks süit oda", 13, true, "/images/room-8.jpg", 2000.00m, "1308", "Süit" },
                    { 129, "Kayak merkezine yakın tek kişilik oda", 13, true, "/images/room-5.jpg", 900.00m, "1309", "Tek Kişilik" },
                    { 130, "Geniş çift kişilik oda", 13, true, "/images/room-6.jpg", 1400.00m, "1310", "Çift Kişilik" },
                    { 131, "Spa merkezine yakın tek kişilik oda", 14, true, "/images/room-9.jpg", 1000.00m, "1401", "Tek Kişilik" },
                    { 132, "Geniş çift kişilik oda", 14, true, "/images/room-10.jpg", 1500.00m, "1402", "Çift Kişilik" },
                    { 133, "Geniş aile odası", 14, true, "/images/room-11.jpg", 1800.00m, "1403", "Aile Odası" },
                    { 134, "Lüks süit oda", 14, true, "/images/room-12.jpg", 2100.00m, "1404", "Süit" },
                    { 135, "Spa merkezine yakın tek kişilik oda", 14, true, "/images/room-9.jpg", 1000.00m, "1405", "Tek Kişilik" },
                    { 136, "Geniş çift kişilik oda", 14, true, "/images/room-10.jpg", 1500.00m, "1406", "Çift Kişilik" },
                    { 137, "Geniş aile odası", 14, true, "/images/room-11.jpg", 1800.00m, "1407", "Aile Odası" },
                    { 138, "Lüks süit oda", 14, true, "/images/room-12.jpg", 2100.00m, "1408", "Süit" },
                    { 139, "Spa merkezine yakın tek kişilik oda", 14, true, "/images/room-9.jpg", 1000.00m, "1409", "Tek Kişilik" },
                    { 140, "Geniş çift kişilik oda", 14, true, "/images/room-10.jpg", 1500.00m, "1410", "Çift Kişilik" },
                    { 141, "Lüks tatil köyünde tek kişilik oda", 15, true, "/images/room-1.jpg", 1200.00m, "1501", "Tek Kişilik" },
                    { 142, "Geniş çift kişilik oda", 15, true, "/images/room-2.jpg", 1600.00m, "1502", "Çift Kişilik" },
                    { 143, "Geniş aile odası", 15, true, "/images/room-3.jpg", 2000.00m, "1503", "Aile Odası" },
                    { 144, "Lüks süit oda", 15, true, "/images/room-4.jpg", 2500.00m, "1504", "Süit" },
                    { 145, "Lüks tatil köyünde tek kişilik oda", 15, true, "/images/room-1.jpg", 1200.00m, "1505", "Tek Kişilik" },
                    { 146, "Geniş çift kişilik oda", 15, true, "/images/room-2.jpg", 1600.00m, "1506", "Çift Kişilik" },
                    { 147, "Geniş aile odası", 15, true, "/images/room-3.jpg", 2000.00m, "1507", "Aile Odası" },
                    { 148, "Lüks süit oda", 15, true, "/images/room-4.jpg", 2500.00m, "1508", "Süit" },
                    { 149, "Lüks tatil köyünde tek kişilik oda", 15, true, "/images/room-1.jpg", 1200.00m, "1509", "Tek Kişilik" },
                    { 150, "Geniş çift kişilik oda", 15, true, "/images/room-2.jpg", 1600.00m, "1510", "Çift Kişilik" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 15);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3,
                column: "Price",
                value: 1200.00m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 4,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Lüks süit oda.", 850.00m });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 5,
                columns: new[] { "Description", "HotelId", "PictureUrl", "Price", "RoomNumber", "Type" },
                values: new object[] { "Deniz manzaralı tek kişilik oda", 2, "/images/room-5.jpg", 850.00m, "201", "Tek kişilik" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 6,
                columns: new[] { "HotelId", "PictureUrl", "Price", "RoomNumber", "Type" },
                values: new object[] { 2, "/images/room-6.jpg", 850.00m, "202", "Çift Kişik" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 7,
                columns: new[] { "HotelId", "PictureUrl", "Price", "RoomNumber" },
                values: new object[] { 2, "/images/room-1.jpg", 850.00m, "203" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 8,
                columns: new[] { "Description", "HotelId", "PictureUrl", "Price", "RoomNumber" },
                values: new object[] { "Lüks süit oda.", 2, "/images/room-2.jpg", 850.00m, "204" });
        }
    }
}
