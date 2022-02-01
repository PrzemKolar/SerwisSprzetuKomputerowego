using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Security.Cryptography;
using System.Text;

namespace Serwis.Authentication
{
    public class HashPasswordGenerator
    {
        public string GetHashPassword(string password)
        {
            string hashed;

            // Creates an instance of the default implementation of the MD5 hash algorithm.
            using (var md5Hash = MD5.Create())
            {
                // Byte array representation of source string
                var sourceBytes = Encoding.UTF8.GetBytes(password);

                // Generate hash value(Byte Array) for input data
                var hashBytes = md5Hash.ComputeHash(sourceBytes);

                // Convert hash byte array to string
                hashed = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            }
            return hashed.ToString();
        }
    }
}
