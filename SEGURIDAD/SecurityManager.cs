using System;
using System.Text;
using System.Security.Cryptography;

namespace SEGURIDAD
{
    public class SecurityManager
    {
        public MD5 CrearMD5()
        {
            MD5 md5Hash = MD5.Create();
            return md5Hash;
        }

        public string GenerarHash(string input)
        {
            string Hash = GetMd5Hash(CrearMD5(), input);
            return Hash;
        }

        public bool Verificar(string input, string Hash)
        {
            if (VerifyMd5Hash(CrearMD5(), input, Hash))
                return true;
            else
                return false;
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            string hashOfInput = GetMd5Hash(md5Hash, input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
