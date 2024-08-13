using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Visual_Project.Models;

namespace Visual_Project.Controllers
{
    public class ManageAdminsController : Controller
    {
        private readonly HotelDbContext DbContext;
        public ManageAdminsController(HotelDbContext context)
        {
            DbContext = context;
        }
        //  HotelDbContext DbContext= new HotelDbContext();

        public IActionResult ManageAdmins()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAdmin(Admin addmin)
        {

           
            if (ModelState.IsValid)
            {
                addmin.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(addmin.Password, 13);
                DbContext.Admins.Add(addmin);
                DbContext.SaveChanges();
                return RedirectToAction("AdminResult", "ManageAdmins");
            }
            return View();
        }
        [HttpGet]
        public IActionResult AdminResult()
        {
            List<Admin> admins = new List<Admin>();
           
            admins = DbContext.Admins.ToList();

            return View("AdminResult", admins);
        }
       

            public IActionResult RemoveAdmin(string id)
            {

                // Fetch the admin from the database based on the provided identifier
                var adminToRemove = DbContext.Admins.FirstOrDefault(admin => admin.ID == id);

                if (adminToRemove != null)
                {
                   
                    DbContext.Admins.Remove(adminToRemove);
                    DbContext.SaveChanges();
                }
                // Optionally, you can redirect or return a success message
                return RedirectToAction("AdminResult", "ManageAdmins"); // Redirect to the admin list, adjust as needed


            }
    }

        //[HttpGet]
        //public IActionResult RemoveAdmin(string adminId)
        //{
        //    // Display a confirmation view with the details of the admin to be removed
        //    var adminToRemove = DbContext.Admins.FirstOrDefault(admin => admin.ID == adminId);
        //    return View(adminToRemove);
        //}

       
    }

