using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Vijay.Practice.CryptGEN
{
	public static class DecreateAES
	{
		public static string DecryptDataWithAes(string cipherText, string keyBase64, string vectorBase64)
		{
			using (Aes aesAlgorithm = Aes.Create())
			{
				aesAlgorithm.Key = Convert.FromBase64String(keyBase64);
				aesAlgorithm.IV = Convert.FromBase64String(vectorBase64);

				Console.WriteLine($"Aes Cipher Mode : {aesAlgorithm.Mode}");
				Console.WriteLine($"Aes Padding Mode: {aesAlgorithm.Padding}");
				Console.WriteLine($"Aes Key Size : {aesAlgorithm.KeySize}");
				Console.WriteLine($"Aes Block Size : {aesAlgorithm.BlockSize}");


				// Create decryptor object
				ICryptoTransform decryptor = aesAlgorithm.CreateDecryptor();

				byte[] cipher = Convert.FromBase64String(cipherText);

				//Decryption will be done in a memory stream through a CryptoStream object
				using (MemoryStream ms = new MemoryStream(cipher))
				{
					using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
					{
						using (StreamReader sr = new StreamReader(cs))
						{
							return sr.ReadToEnd();
						}
					}
				}
			}
		}
	}
}
