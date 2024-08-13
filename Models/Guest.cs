using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Visual_Project.Models
{
    public class Guest:EndUser
    {
       
        public virtual ICollection<Reservation> Reservations { get; set; }=new List<Reservation>();

        //public static void AddGuest(Guest guest)
        //{
        //    var _context = HotelDbContext.GetService(typeof(HotelDbContext));
        //    using (HotelDbContext dbContext = new HotelDbContext())
        //    {

               
        //        guest.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(guest.Password, 13);
        //        dbContext.Guests.Add(guest);
        //        dbContext.SaveChanges();
        //    }
        
        //}

        //public static bool UserLogin(Guest guest)
        //{
        //    using (HotelDbContext dbContext = new HotelDbContext())
        //    {
        //        var cnt = dbContext.Guests.Where(gst => gst.Username == guest.Username && gst.Password == guest.Password).Count();
        //        return cnt > 0;

                
        //    }

        //}
    }
}
