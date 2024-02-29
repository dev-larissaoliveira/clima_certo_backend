using System;
using System.Security.Cryptography;

namespace ClimaTempoWebAPI.Helpers
{
    public static class KeyGenerator
    {
        public static string GenerateRandomKey(int length)
        {
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var randomBytes = new byte[length];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomBytes);
            }
            var result = new char[length];
            var charsLength = validChars.Length;
            for (int i = 0; i < length; i++)
            {
                result[i] = validChars[randomBytes[i] % charsLength];
            }
            return new string(result);
        }
    }
}