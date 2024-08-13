using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Visual_Project.Models;

namespace Visual_Project.Controllers
{
    public class ReservationsController : Controller
    {

        private readonly HotelDbContext _context;
        public ReservationsController(HotelDbContext context)
        {
            _context = context;
        }

        public IActionResult PastReservations()
        {
            var username = HttpContext.Session.GetString("Username");
            var id = (from user in _context.Guests
                      where username == user.Username
                      select user.ID).FirstOrDefault();

            var reservation = (from res in _context.Reservations
                               where res.GuestID == id
                               select res).ToList();

            return View(reservation);
        }

        public IActionResult CurrentReservations()
        {
            DateTime? date = DateTime.Now;
            var reservation = (from res in _context.Reservations
                               where date >= res.CheckInDate && date <= res.CheckOutDate
                               select res).ToList();

            return View(reservation);
        }

    }
}
