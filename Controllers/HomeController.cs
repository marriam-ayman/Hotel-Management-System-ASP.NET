using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Transactions;
using Visual_Project.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;

namespace Visual_Project.Controllers
{
    public class HomeController : Controller
    {

        private readonly HotelDbContext DbContext;
       
        public HomeController(HotelDbContext context)
        {
            DbContext = context;
          
        }
     
      
        public IActionResult About()
        {
            return View();
        }
  
        public IActionResult Index()
        {
        
            return View();
        }
       
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
      
  
        [HttpPost]
        public IActionResult Login(UserLogin user)
        {
            
            Console.WriteLine(BCrypt.Net.BCrypt.EnhancedHashPassword(user.Password,13));
                int userType = 0;
                var is_Guest = DbContext.Guests.Any(guest => guest.Username == user.Username);
                var is_Admin = DbContext.Admins.Any(admin => admin.Username == user.Username);

  
                // User is Guest
                if (is_Guest)
                {
                    var guest = DbContext.Guests.FirstOrDefault(gst => gst.Username == user.Username);
                    //if (SecretHasher.HashPassword($"{user.Password}{guest.Salt}") == guest.Password)
                    if (BCrypt.Net.BCrypt.EnhancedVerify(user.Password, guest.Password)) ;
                    {
                        userType = 1;
                    }
                }
                // User is Admin
                if (is_Admin)
                {
                    var admin = DbContext.Admins.FirstOrDefault(admin => admin.Username == user.Username);
                    //if (SecretHasher.HashPassword($"{user.Password}{admin.Salt}") == admin.Password)
                    if (BCrypt.Net.BCrypt.EnhancedVerify(user.Password, admin.Password))
                    {
                        // Adimn is Receptionist
                        if (admin.Type == "Receptionist")
                            userType = 2;
                        else // Admin is Manager
                            userType = 3;

                    }
                }
                if (userType == 1)
                {
                    HttpContext.Session.SetString("Username", user.Username);
                    HttpContext.Session.SetString("Type", "Guest");
                    return RedirectToAction("Index");
                }
                else if (userType == 2)
                {
                    HttpContext.Session.SetString("Username", user.Username);
                    HttpContext.Session.SetString("Type", "Receptionist");
                    return RedirectToAction("Index");
                }
                else if (userType == 3)
                {
                    HttpContext.Session.SetString("Username", user.Username);
                    HttpContext.Session.SetString("Type", "Manager");
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["Error"] = "Wrong Username or Password";
                    return View();
                }
            
            
         
        }
        public IActionResult ManageDetails()
        {
            return View();
        }
        public IActionResult Rooms()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
       
       




        [HttpGet]

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}