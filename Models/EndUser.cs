using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime;

namespace Visual_Project.Models
{
    [Index(nameof(Username), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class EndUser
    {
        [Key]
        [Required]
        [UniqueUserID(ErrorMessage = "This ID already in use. Please choose a different ID.")]
        [RegularExpression("[0-9]{14}" ,ErrorMessage = "Please enter 14 digits for Your ID")]
        public string ID { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]{3,20}$", ErrorMessage = "No numbers allowed in the FirstName and Minmum lengh is 3 and Mxmum lengh is 20")]
        public string Firstname { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]{3,20}$", ErrorMessage = "No numbers allowed in the LasttName and Minmum lengh is 3 and Mxmum lengh is 20.")]
        public string Lastname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [UniqueEmail(ErrorMessage = "Email already in use. Please choose a different email.")]
        [RegularExpression(@"^[a-zA-Z0-9]+([._-][a-zA-Z0-9]+)*@[a-zA-Z0-9]+([-.][a-zA-Z0-9]+)*\.[a-z]{2,6}$",
         ErrorMessage="This Email Address not Valid.")]
        public string Email { get; set; }

        [Required]
        [UniqueUsername(ErrorMessage = "Username already in use. Please choose a different username.")]
        [RegularExpression(@"^[a-zA-Z]+[a-zA-Z0-9-_.]{3,20}$",
        ErrorMessage = "Numbers are not permitted at the beginning,No space char is permitted ")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()-_=+{};:'"",.<>/?[\]\\|]).{8,}$", 
        ErrorMessage = "The Password must be at least 8 characters and contains at least one of all of this (lowercase character, uppercase, digit, special character).")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("[0-9]{11}", ErrorMessage = "Please enter 11 digits for Your PhoneNumber")]
        public string PhoneNumber { get; set; }


        public string? Image { get; set; }
        public class UniqueUserIDAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var context = (HotelDbContext)validationContext.GetService(typeof(HotelDbContext)); 
                var id = value.ToString();
                var existingUser = context.Users.FirstOrDefault(userID => userID.ID == id);

                if (existingUser != null)
                {
                    return new ValidationResult(ErrorMessage);
                }

                return ValidationResult.Success;
            }
        }

        public class UniqueUsernameAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var context = (HotelDbContext)validationContext.GetService(typeof(HotelDbContext)); 
                var username = value.ToString();
                var existingUser = context.Users.FirstOrDefault(userName => userName.Username == username);

                if (existingUser != null)
                {
                    return new ValidationResult(ErrorMessage);
                }

                return ValidationResult.Success;
            }
        }
        public class UniqueEmailAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var context = (HotelDbContext)validationContext.GetService(typeof(HotelDbContext)); 
                var email = value.ToString();
                var existingUser = context.Users.FirstOrDefault(userEmail => userEmail.Email == email);

                if (existingUser != null)
                {
                    return new ValidationResult(ErrorMessage);
                }

                return ValidationResult.Success;
            }
        }



    }
}
