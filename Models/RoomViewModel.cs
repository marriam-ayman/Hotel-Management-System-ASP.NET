using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Visual_Project.Models
{
    public class RoomViewModel
    {
       
        public string RoomID { get; set; }

       
        public int Floor { get; set; }

       
        public decimal Price { get; set; }

      
        public int Rate { get; set; }
        public string View { get; set; }
        public string RoomType { get; set; }
        public string Description { get; set; }
     
        public int NumOfBeds { get; set; }
      
        public string Check_inDate { get; set; }
     
        public string Check_OutDate { get; set; }
        //public static void AddRoom(RoomViewModel room)
        //{
        //    using (HotelDbContext dbContext = new HotelDbContext())
        //    {
        //        var roomclassid = (from roomclass in dbContext.RoomClasses
        //                           where roomclass.Type == room.RoomType
        //                           select roomclass.ID).First();

        //        Room RoomToAdd = new() {ID=room.RoomID,
        //            Floor=room.Floor,
        //            Price=room.Price,
        //            Rate=room.Rate,
        //            RoomClassID=roomclassid,
        //            View=room.View,
        //          };

        //        dbContext.Rooms.Add(RoomToAdd);
        //        dbContext.SaveChanges();
        //    }
        //}
        //public static List<RoomViewModel> Result(RoomViewModel search)
        //{
        //    using (HotelDbContext dbContext = new HotelDbContext())
        //    {

        //        DateTime From = DateTime.Parse(search.Check_inDate),To= DateTime.Parse(search.Check_OutDate);
        //       // Console.WriteLine(from);
        //        var roomclassid = (from roomclass in dbContext.RoomClasses
        //                           where roomclass.Type == search.RoomType
        //                           select roomclass.ID).First();


        //        var availableRooms = dbContext.Rooms
        //       .Include(r => r.Reservations)
        //       .Where(room => room.Reservations.All(reservation =>
        //       reservation.CheckOutDate <= From
        //       || reservation.CheckInDate >=To)
        //       && room.RoomClassID == roomclassid)
        //       .ToList();
        //    //  foreach (var room in availableRooms) Console.WriteLine(room.Reservations.First().Check_outDate);

        //        var rooms = (from room in availableRooms
        //                     join roomclass in dbContext.RoomClasses
        //                     on room.RoomClassID equals roomclass.ID
        //                     where room.RoomClassID == roomclassid
        //                     && room.Price <= search.Price
        //                     && room.Rate == search.Rate
        //                     && room.View == search.View
        //                     select new RoomViewModel {
        //                         RoomID = room.ID,
        //                         Price =room.Price,
        //                         Rate=room.Rate,
        //                         View=room.View,
        //                         RoomType=roomclass.Type,
        //                         NumOfBeds=roomclass.NumOfBeds,
        //                         Description=roomclass.Description,

        //                     }).ToList();

              
        //        return rooms;
        //    }

        //}
    }
}
