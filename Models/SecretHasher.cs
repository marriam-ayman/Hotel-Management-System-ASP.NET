using System.Security.Cryptography;
using System.Text;

namespace Visual_Project.Models
{
   
        public static class SecretHasher
        {
          

        public static string HashPassword(string password)
        {
            SHA256 hash = SHA256.Create();

            var passwordBytes = Encoding.Default.GetBytes(password);

            var hashedpassword = hash.ComputeHash(passwordBytes);

            return Convert.ToHexString(hashedpassword);

        }
    }
    
}
