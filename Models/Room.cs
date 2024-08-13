using System.ComponentModel.DataAnnotations;
using static Visual_Project.Models.EndUser;

namespace Visual_Project.Models
{
    public class Room
    {
        [Key]
        [Required]
        [RegularExpression("[0-9]")]
        [UniqueRoomId(ErrorMessage = "This Room ID already in use. Please choose a different ID.")]
        public string ID { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Floor { get; set; }
        [Required]
        [Range(0.01, double.MaxValue)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required]
        [Range(1, 5)]
        public int Rate { get; set; }
        [Required]
        public string View { get; set; }
        [Required]
        public int RoomClassID { get; set; }
        public virtual RoomClass RoomClass { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

        //      public static int Rooms()
        //{
        //	using HotelDbContext DbContext = new();
        //	{
        //		return DbContext.Rooms.Count();

        //          }


        //}

        public class UniqueRoomIdAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var context = (HotelDbContext)validationContext.GetService(typeof(HotelDbContext)); // Replace YourDbContext with the actual DbContext class name
                var roomId = value.ToString();
                var existingUser = context.Rooms.FirstOrDefault(RoomId => RoomId.ID == roomId);

                if (existingUser != null)
                {
                    return new ValidationResult(ErrorMessage);
                }

                return ValidationResult.Success;
            }
        }
    }
}
