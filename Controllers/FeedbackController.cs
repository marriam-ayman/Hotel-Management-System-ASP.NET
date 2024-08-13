using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Visual_Project.Models;

namespace Visual_Project.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly HotelDbContext DbContext;
        public FeedbackController(HotelDbContext context)
        {
            DbContext = context;
        }

        [HttpGet]
        public IActionResult Feedback()
        {


            
            return View();
        }
        [HttpPost]
        public IActionResult AddFeedBack(FeedBack feedback)
        {
                DbContext.FeedBacks.Add(feedback);
                DbContext.SaveChanges();
         
            return View("Index");
        }


        [HttpGet]
        public IActionResult Testimonial()
        {
            List<FeedBack> list = new List<FeedBack>();
            //  list = FeedBack.GetFeedBacks();
             list  = DbContext.FeedBacks
          .Include(r => r.Reservation)
          .ThenInclude(t => t.Guest)
           .ToList();
       
            return View("Testimonial", list);
           

        }
    }
}
