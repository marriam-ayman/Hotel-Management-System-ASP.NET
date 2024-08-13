using Microsoft.CodeAnalysis.Scripting;
using System.ComponentModel.DataAnnotations;

namespace Visual_Project.Models
{
	public class Admin:EndUser
	{

        [Required]
        public string Type { get; set; }
     
        //public static void AddAdmin(Admin admin)
        //{
        //    using (HotelDbContext dbContext = new HotelDbContext())
        //    {
        //        //admin.Salt = DateTime.Now.ToString();
        //        //admin.Password = SecretHasher.HashPassword($"{admin.Password}{admin.Salt}");
        //        admin.Password =BCrypt.Net.BCrypt.EnhancedHashPassword(admin.Password,13);
        //        dbContext.Admins.Add(admin);
        //        dbContext.SaveChanges();
        //    }
        
        //}
        //public static List<Admin> GetAdmins()
        //{
        //    using (var context = new HotelDbContext())
        //    {
        //     var result= context.Admins.ToList();

        //        return result;
        //    }
        //}
    }
}
