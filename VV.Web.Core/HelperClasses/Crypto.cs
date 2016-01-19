using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VV.Web.Core.HelperClasses
{
    public class Crypto
    {
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        private static SHA512CryptoServiceProvider shaCsp = new SHA512CryptoServiceProvider();

        public static string Encrypt(string value, bool persist = false)
        {
            byte[] salt = new byte[128];
            rngCsp.GetNonZeroBytes(salt);
            var result = Encoding.UTF8.GetString(salt);
            var hash = shaCsp.ComputeHash(Encoding.UTF8.GetBytes(result + value));
            if (!persist)
                return Encoding.UTF8.GetString(hash);
            else
                return string.Format("Salt:{0},Hash:{1}", result, Encoding.UTF8.GetString(hash));
        }
    }
}
