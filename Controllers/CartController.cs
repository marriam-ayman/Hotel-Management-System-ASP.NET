using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Visual_Project.Models;

namespace Visual_Project.Controllers
{
    public class CartController : Controller
    {
        private readonly HotelDbContext _context;
        public CartController(HotelDbContext context)
        {
            _context = context;
        }
      
        public IActionResult ShowCart()
        {
            var cart = HttpContext.Session.Get<List<Room>>("ShoppingCart") ?? new List<Room>();
            return View(cart);
        }
        public IActionResult RemoveFromCart(string id)
        {
         //   Console.WriteLine(id);

            var cart = HttpContext.Session.Get<List<Room>>("ShoppingCart") ?? new List<Room>();

            // Remove the Room from the cart based on RoomID
            var productToRemove = cart.FirstOrDefault(room => room.ID == id);
            if (productToRemove != null)
                cart.Remove(productToRemove);

            // Save the updated cart back to session
            HttpContext.Session.Set("ShoppingCart", cart);

            return RedirectToAction("ShowCart", "Cart"); // Redirect to the product list or any other page
        }
        public IActionResult Done()
        {

            return View();
        }

        public IActionResult CheckOut(Reservation reservation)
        {
            decimal AmountOfReservation = 0;
            var cart = HttpContext.Session.Get<List<Room>>("ShoppingCart") ?? new List<Room>();
            foreach (var room in cart)
            {
                AmountOfReservation += room.Price;
              
            }
            foreach (var room in cart)
            {
                _context.Entry(room).State = EntityState.Unchanged;
            }
            reservation.Rooms = cart;
            reservation.CheckInDate = DateTime.Parse(HttpContext.Session.GetString("CheckInDate"));
            reservation.CheckOutDate = DateTime.Parse(HttpContext.Session.GetString("CheckOutDate"));
            reservation.PaymentAmount = AmountOfReservation;
         
            if (HttpContext.Session.GetString("Type") == "Guest")
            {
                var username = HttpContext.Session.GetString("Username");
                var id = (from user in _context.Guests
                          where username == user.Username
                          select user.ID).FirstOrDefault();

                reservation.GuestID = id;
            }
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            HttpContext.Session.SetString("CheckInDate", "");
            HttpContext.Session.SetString("CheckOutDate", "");
            cart.Clear();
            HttpContext.Session.Set("ShoppingCart", cart);

            return RedirectToAction("Done", "Cart");
        }
        [HttpGet]
        public IActionResult ProccedToPay()
        {
            decimal AmountOfReservation = 0;
            var cart = HttpContext.Session.Get<List<Room>>("ShoppingCart") ?? new List<Room>();
            foreach (var room in cart) AmountOfReservation += room.Price;
            ViewBag.AmountOfReservation = AmountOfReservation;
            return View();
        }

    }
}
