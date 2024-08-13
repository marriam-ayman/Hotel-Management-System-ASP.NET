using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Visual_Project.Models;

namespace Visual_Project.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly HotelDbContext DbContext;
        public StatisticsController(HotelDbContext context)
        {
            DbContext = context;
        }
        public IActionResult Statistics()
        {
            //ViewBag.Occupied=Reservation.OccupiedRooms()*1.0/Room.Rooms()*100;
            int NumOfRooms = 0;
            DateTime date = DateTime.Now;
            var result = DbContext.Reservations
                          .Where(res => date >= res.CheckInDate && date <= res.CheckOutDate)
                          .Include(res => res.Rooms)
                          .ToList();
            foreach (var reservation in result)
            {
                NumOfRooms += reservation.Rooms.Count();
            }
           
            ViewBag.Occupied = NumOfRooms * 1.0 / DbContext.Rooms.Count() * 100;
            return View();
        }
        [HttpGet]
        public IActionResult Date()
        {
            return View();
        }
       [HttpPost]
        public IActionResult Date(Reservation reservation)

        {
           
                reservation.CheckInDate = DateTime.Parse(reservation.CheckIn);
                reservation.CheckOutDate = DateTime.Parse(reservation.CheckOut);
            Console.WriteLine(reservation.CheckInDate);
                var result = (from res in DbContext.Reservations
                              where reservation.CheckInDate <= res.CheckInDate && reservation.CheckOutDate >= res.CheckOutDate
                              select res).ToList();
                return View("DateResults", result);
          
        }
        public IActionResult Guest()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Guest(Reservation reservation)
        {
           
                var result = (from res in DbContext.Reservations
                              where reservation.GuestID == res.GuestID
                              select res).ToList();
                return View("GuestResults", result);
            
        }
        [HttpGet]
        public IActionResult Rooms()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Rooms(string id)
        {
           
                var result = DbContext.Reservations
                                  .Include(res => res.Rooms.Where(room => room.ID == id))
                                  .ToList();
                return View("RoomResults", result);
           
        }
        
    }

}
