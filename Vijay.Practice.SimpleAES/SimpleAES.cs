using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Vijay.Practice.SimpleAES
{
    public static class SimpleAES
    {
        public static void Process()
        {
            Aes aes = Aes.Create();
            aes.KeySize = 256;
            aes.Mode = CipherMode.CBC;
            aes.GenerateKey();
            aes.GenerateIV();

            string plaintext = "Hello, world!";
            byte[] ciphertext;

            using (ICryptoTransform encryptor = aes.CreateEncryptor())
            {
                byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
                ciphertext = encryptor.TransformFinalBlock(plaintextBytes, 0, plaintextBytes.Length);
            }

            string decryptedText;

            using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
            {
                byte[] decryptedBytes = decryptor.TransformFinalBlock(ciphertext, 0, ciphertext.Length);
                decryptedText = Encoding.UTF8.GetString(decryptedBytes);
            }

            Console.WriteLine($"Plaintext: {plaintext}");
            Console.WriteLine($"Ciphertext: {Convert.ToBase64String(ciphertext)}");
            Console.WriteLine($"Decrypted text: {decryptedText}");
        }
    }
}