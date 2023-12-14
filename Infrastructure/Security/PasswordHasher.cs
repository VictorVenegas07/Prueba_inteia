using Domain.Common.Security;
using System.Text;

namespace Infrastructure.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        public byte[] HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPassword(byte[] hashedPassword, string providedPassword)
        {
            byte[] providedPasswordHash = HashPassword(providedPassword);
            return hashedPassword.SequenceEqual(providedPasswordHash);
        }
    }
}
