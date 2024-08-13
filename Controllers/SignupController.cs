using Microsoft.AspNetCore.Mvc;
using Visual_Project.Models;

namespace Visual_Project.Controllers
{
    public class SignupController : Controller
    {
        private readonly HotelDbContext DbContext;
        private readonly IWebHostEnvironment _environment;
        public SignupController(HotelDbContext context, IWebHostEnvironment environment)
        {
            DbContext = context;
            _environment = environment;
        }
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(Guest guest, IFormFile img_file)
        {
            if (ModelState.IsValid)
            {


                // to create Images folder in the project Path.
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
                    guest.Image = img_file.FileName;
                }
                else
                {
                    guest.Image = "Team.jpg"; // to save the default image path in database.
                }
                guest.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(guest.Password, 13);
                //Console.WriteLine(user.Password);
                DbContext.Guests.Add(guest);
                DbContext.SaveChanges();
                return RedirectToAction("Login", "Home");

            }
            else
            {
                return View();
            }
        }
    }
}
