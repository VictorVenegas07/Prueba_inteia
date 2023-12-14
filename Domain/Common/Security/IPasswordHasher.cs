using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Security
{
    public interface IPasswordHasher
    {
        byte[] HashPassword(string password);
        bool VerifyPassword(byte[] hashedPassword, string providedPassword);
    }
}
