using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class MD5_Key
    {
        /// <summary>
        /// Данный метод шифрует строку в MD5 ключ.
        /// </summary>
        /// <param name="str">Принимает строку для шифрования.</param>
        public string MD5_Create_Key(string str)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, str);
                return hash;
            }
        }
        /// <summary>
        /// Производит сравнение строки и ключа MD5 если они идентичны возвращает true если не идентичны false.
        /// </summary>
        /// <param name="str">Строка "не шифрованая".</param>
        /// <param name="key">Строка "шифрованая".</param>
        public bool MD5_Check_Key(string str, string key)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                if (VerifyMd5Hash(md5Hash, str, key))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
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
        private string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
