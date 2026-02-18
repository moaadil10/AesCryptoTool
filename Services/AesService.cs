using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AesCryptoTool.Services
{
    public class AesService
    {
        public string Encrypt(string plainText, string key)
        {
            byte[] keyBytes = SHA256.HashData(Encoding.UTF8.GetBytes(key));
            byte[] iv = new byte[16];

            using Aes aes = Aes.Create();
            aes.Key = keyBytes;
            aes.IV = iv;

            using MemoryStream ms = new MemoryStream();
            using CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
            using StreamWriter sw = new StreamWriter(cs);

            sw.Write(plainText);
            sw.Close();

            return Convert.ToBase64String(ms.ToArray());
        }

        public string Decrypt(string cipherText, string key)
        {
            byte[] keyBytes = SHA256.HashData(Encoding.UTF8.GetBytes(key));
            byte[] iv = new byte[16];

            using Aes aes = Aes.Create();
            aes.Key = keyBytes;
            aes.IV = iv;

            byte[] buffer = Convert.FromBase64String(cipherText);

            using MemoryStream ms = new MemoryStream(buffer);
            using CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using StreamReader sr = new StreamReader(cs);

            return sr.ReadToEnd();
        }

        public string GenerateRandomKey()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(16));
        }
    }
}
