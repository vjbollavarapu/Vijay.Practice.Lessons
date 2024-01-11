using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Vijay.Practice.CryptGEN
{
	public static class CreateAES
	{
		public static string EncryptDataWithAes(string plainText, string keyBase64, out string vectorBase64)
		{
			using (Aes aesAlgorithm = Aes.Create())
			{
				aesAlgorithm.Key = Convert.FromBase64String(keyBase64);
				aesAlgorithm.GenerateIV();
				Console.WriteLine($"Aes Cipher Mode : {aesAlgorithm.Mode}");
				Console.WriteLine($"Aes Padding Mode: {aesAlgorithm.Padding}");
				Console.WriteLine($"Aes Key Size : {aesAlgorithm.KeySize}");

				//set the parameters with out keyword
				vectorBase64 = Convert.ToBase64String(aesAlgorithm.IV);

				// Create encryptor object
				ICryptoTransform encryptor = aesAlgorithm.CreateEncryptor();

				byte[] encryptedData;

				//Encryption will be done in a memory stream through a CryptoStream object
				using (MemoryStream ms = new MemoryStream())
				{
					using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter sw = new StreamWriter(cs))
						{
							sw.Write(plainText);
						}
						encryptedData = ms.ToArray();
					}
				}

				return Convert.ToBase64String(encryptedData);
			}
		}
	}
}
