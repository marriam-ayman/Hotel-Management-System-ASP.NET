using Microsoft.EntityFrameworkCore;
namespace Visual_Project.Models
{
	public class HotelDbContext:DbContext
	{
       
        public HotelDbContext(DbContextOptions<HotelDbContext> options)
    : base(options)
        {
           
        }

        public DbSet<Guest> Guests { get; set; }
		public DbSet<Reservation> Reservations { get; set; }
		public DbSet<Room> Rooms { get; set; }
		public DbSet<RoomClass> RoomClasses { get; set; }
		public DbSet<Admin> Admins { get; set; }
		public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<EndUser> Users { get; set; }

        internal static object GetService(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
