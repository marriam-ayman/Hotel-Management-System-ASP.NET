using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Visual_Project.Models;

namespace Visual_Project.Controllers
{
    public class ProfileController : Controller
    {
        private readonly HotelDbContext dbcontext;
        private readonly IWebHostEnvironment _environment;
       
        public ProfileController(HotelDbContext context, IWebHostEnvironment environment)
        {
            dbcontext = context;
            _environment = environment;
        }
      
        public IActionResult Profile()
        {

            var username = HttpContext.Session.GetString("Username");
           

            var CurUser = (from user in dbcontext.Users
                         where user.Username == username
                         select user).FirstOrDefault();

           
            return View(CurUser);
        }

        public IActionResult EditProfile()
        {
            var username = HttpContext.Session.GetString("Username");


            var CurUser = (from user in dbcontext.Users
                           where user.Username == username
                           select user).FirstOrDefault();


            return View(CurUser);
        }
        [HttpPost]
        public async Task<IActionResult> EditProfileDetails(EndUser updateUser, IFormFile img_file)
        {


            var username = HttpContext.Session.GetString("Username");
    
            var CurUser = (from user in dbcontext.Users
                           where user.Username == username
                           select user).FirstOrDefault();

           
                if (updateUser.Firstname != null)
                    CurUser.Firstname = updateUser.Firstname;
                if (updateUser.Lastname != null)
                    CurUser.Lastname = updateUser.Lastname;
                if (updateUser.Email != null)
                    CurUser.Email = updateUser.Email;
                if (updateUser.PhoneNumber != null)
                    CurUser.PhoneNumber = updateUser.PhoneNumber;

            if (updateUser.Password != null)
            {
                CurUser.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(updateUser.Password, 13);
              //  CurUser.Password = updateUser.Password;
            }
              string path = Path.Combine(_environment.WebRootPath, "Img"); // wwwroot/Img/
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (img_file != null)
            {
                path = Path.Combine(path, img_file.FileName); // for exmple : /Img/Photoname.png
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await img_file.CopyToAsync(stream);
                    ViewBag.Message = string.Format("<b>{0}</b> uploaded.</br>", img_file.FileName.ToString());
                }
                CurUser.Image = img_file.FileName;
            }
            else
            {
                CurUser.Image = "Team.jpg"; // to save the default image path in database.
            }
            dbcontext.SaveChanges();
            return RedirectToAction("Profile");
        }
               
            
        
        public IActionResult Logout()
        {
            // Clear the user's authentication status
            HttpContext.Session.Clear();
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home"); // Redirect to the homepage after logout
        }

    }
}
