using System.Security.Cryptography;
using System.Text;

namespace ClimaTempoWebAPI.Helper
{
    public static class Criptografia
    {
        public static string HashGenerate(this string value)
        {
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(value);

            array = SHA1.HashData(array);

            var strHexa = new StringBuilder();

            foreach (var item in array)
            {
                strHexa.Append(item.ToString("x2"));
            }

            return strHexa.ToString();
        }
    }
}
