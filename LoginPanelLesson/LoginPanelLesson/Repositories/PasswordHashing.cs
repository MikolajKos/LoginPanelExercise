using System;
using System.Security.Cryptography;
using System.Text;

namespace LoginPanelLesson.Repositories
{
    public class PasswordHashing
    {
        public string HashPassword(string password)
        {
            SHA256 hash = SHA256.Create();
            
            var passwordBytes = Encoding.Default.GetBytes(password);
            var hashedPassword = hash.ComputeHash(passwordBytes);
            return Convert.ToHexString(hashedPassword);
        }
    }
}
