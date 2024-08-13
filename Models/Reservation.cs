using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Visual_Project.Migrations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Visual_Project.Models
{
	public class Reservation
	{
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CheckInDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        
        public DateTime CheckOutDate { get; set; }
        [Required]
        [RegularExpression("[0-9] {14}")]
        public string GuestID { get; set; }
        public virtual Guest Guest { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal PaymentAmount { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
        public virtual ICollection<FeedBack>? FeedBacks { get; set; }

        [NotMapped]
		public string CheckIn { get; set; }
        [NotMapped]
        public string CheckOut { get; set; }
   //     public static List<Reservation> FilterByDate(Reservation reservation)
   //     {
			//reservation.CheckInDate = DateTime.Parse(reservation.CheckIn);
			//reservation.CheckOutDate = DateTime.Parse(reservation.CheckOut);

   //         using (HotelDbContext DbContext=new()) {
			
			//	var result = (from res in DbContext.Reservations
			//				  where reservation.CheckInDate >= res.CheckInDate && reservation.CheckOutDate <= res.CheckOutDate
   //                           select res).ToList();
			//	return result;
			//}
   //     }
        //public static List<Reservation> FilterByGuest(Reservation reservation)
        //{
           

        //    using (HotelDbContext DbContext = new())
        //    {
               
        //        var result = (from res in DbContext.Reservations
        //                      where reservation.GuestID == res.GuestID
        //                      select res).ToList();
        //        return result;
        //    }
        //}
        //public static List<Reservation> FilterByRoom(string id)
        //{


        //    using (HotelDbContext DbContext = new())
        //    {

        //        var result = DbContext.Reservations
        //                      .Include(res => res.Rooms.Where(room => room.ID == id))
        //                      .ToList();

                              
        //        return result;
        //    }
        //}
        //public static int OccupiedRooms()
        //{

        //    using (HotelDbContext DbContext = new())
        //    {
        //        int NumOfRooms=0;
        //        DateTime date = DateTime.Now;
        //        var result = DbContext.Reservations
        //                      .Where(res => date>=res.CheckInDate&&date<=res.CheckOutDate)
        //                      .Include(res =>res.Rooms)
        //                      .ToList();
        //        foreach (var reservation in result)
        //        {
        //            NumOfRooms += reservation.Rooms.Count();
        //        }
        //       // Console.WriteLine(NumOfRooms);

        //        return NumOfRooms;
        //    }
        //}
    }
}
