using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Visual_Project.Models
{
    public class FeedBack
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public string Feedback { get; set; }

        [Required]
        public virtual Reservation Reservation { get; set; }

        //public static void AddFeedBack(FeedBack feedBack)
        //{
        //    using (HotelDbContext dbContext = new HotelDbContext())
        //    {
        //        dbContext.FeedBacks.Add(feedBack);
        //        dbContext.SaveChanges();
        //    }
        //}

        //public static List<FeedBack> GetFeedBacks()
        //{
        //    using (HotelDbContext db = new HotelDbContext())
        //    {
        //        //var reslut = db.FeedBacks
        //        //    .Include(r => r.Reservation)
        //        //    .ThenInclude(t => t.Guest)
        //        //    .ToList();
        //        //return reslut;
        //    }
        //}
    }

}
