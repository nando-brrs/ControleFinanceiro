using System;
using System.Security.Cryptography;
using System.Text;

namespace ControleFinanceiro.Api.Helpers
{
    public class Helpers
    {
        public static string ConvertMD5(string password)
        {
            byte[] encodedPassword = new UTF8Encoding().GetBytes(password);
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
            string encoded = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
            return encoded;
        }
    }
}
