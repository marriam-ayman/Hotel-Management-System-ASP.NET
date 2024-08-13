using System.ComponentModel.DataAnnotations;

namespace Visual_Project.Models
{
	public class RoomClass
	{
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(1, 10)]
        public int NumOfBeds { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
