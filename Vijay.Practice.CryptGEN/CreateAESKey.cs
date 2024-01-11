using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Vijay.Practice.CryptGEN
{
	public static class CreateAESKey
	{
		public static string Generate()
		{
			string keyBase64 = "";
			using (Aes aesAlgorithm = Aes.Create())
			{
				aesAlgorithm.KeySize = 256;
				aesAlgorithm.GenerateKey();
				keyBase64 = Convert.ToBase64String(aesAlgorithm.Key);
				Console.WriteLine($"Aes Key Size : {aesAlgorithm.KeySize}");
				Console.WriteLine("Here is the Aes key in Base64:");
				Console.WriteLine(keyBase64);
			}

			return keyBase64;
		}

	}
}
