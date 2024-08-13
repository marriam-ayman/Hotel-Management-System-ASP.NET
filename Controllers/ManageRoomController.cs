using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
using System.Runtime.Intrinsics.Arm;
using Visual_Project.Models;

namespace Visual_Project.Controllers
{
    public class ManageRoomController : Controller
    {
        private readonly HotelDbContext DbContext;
        public ManageRoomController(HotelDbContext context)
        {
            DbContext = context;
        }
        
        // Add Room Controllers 
        [HttpGet]
        public IActionResult AddRoom()
        {
            return View("AddRoom");
        }
        [HttpPost]
        public IActionResult AddRoom(RoomViewModel room)
        {
          
               
                var roomclassid = (from roomclass in DbContext.RoomClasses
                                   where roomclass.Type == room.RoomType
                                   select roomclass.ID).First();

                Room RoomToAdd = new()
                {
                    ID = room.RoomID,
                    Floor = room.Floor,
                    Price = room.Price,
                    Rate = room.Rate,
                    RoomClassID = roomclassid,
                    View = room.View,
                };
                DbContext.Rooms.Add(RoomToAdd);
                DbContext.SaveChanges();
                return RedirectToAction("ManageDetails", "Home");
           
        }

        // Remove Room Controllers
        [HttpGet]
        public IActionResult RoomList()
        {
            List<Room>result = DbContext.Rooms.ToList();
            return View(result);
        }
     
        public IActionResult RemoveRoom(string id)
        {
           Console.WriteLine(id);

                
                var roomToRemove = DbContext.Rooms.FirstOrDefault(room => room.ID == id);

                if (roomToRemove != null)
                {
                   
                    DbContext.Rooms.Remove(roomToRemove);
                    DbContext.SaveChanges();
                }
              
                return RedirectToAction("RoomList", "ManageRoom"); 
          

        }

        // Edit Room Controllers
        [HttpGet]
        public IActionResult EditRoom()
        {

            return View();
        }

        [HttpPost]
        public IActionResult EditRoom(RoomViewModel roomView)
        {
          
                var room = DbContext.Rooms.Find(roomView.RoomID);
                var classRoom = (from roomclass in DbContext.RoomClasses
                                 where roomclass.Type == roomView.RoomType
                                 select roomclass).First();

                if (classRoom != null)
                    room.RoomClassID = classRoom.ID;
                if (room.Price != 0)
                    room.Price = roomView.Price;
                if (room.Rate != 0)
                    room.Rate = roomView.Rate;

                DbContext.SaveChanges();
                return RedirectToAction("ManageDetails", "Home");
            
        }
    }
}

