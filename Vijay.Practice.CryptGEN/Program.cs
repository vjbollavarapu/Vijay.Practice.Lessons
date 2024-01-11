using Vijay.Practice.CryptGEN;

Console.WriteLine("Welcome to the Aes Encryption Test tool");
Console.WriteLine("Provide the Aes Key in base64 format :");
string keyBase64 = CreateAESKey.Generate();
Console.WriteLine("--------------------------------------------------------------");
Console.WriteLine("Please enter the text that you want to encrypt:");
string plainText = "I am Vijaya Babu Bollavarapu and Family.";
Console.WriteLine("--------------------------------------------------------------");
string cipherText = CreateAES.EncryptDataWithAes(plainText, keyBase64, out string vectorBase64);

Console.WriteLine("--------------------------------------------------------------");
Console.WriteLine("Here is the cipher text:");
Console.WriteLine(cipherText);

Console.WriteLine("--------------------------------------------------------------");
Console.WriteLine("Here is the Aes IV in Base64:");
Console.WriteLine(vectorBase64);


Console.WriteLine("Welcome to the Aes Encryption Test tool");
Console.WriteLine("Please enter the text that you want to decrypt:");
Console.WriteLine("--------------------------------------------------------------");

Console.WriteLine("Provide the Aes Key:" + keyBase64);
Console.WriteLine("--------------------------------------------------------------");

Console.WriteLine("Provide the initialization vector:");
Console.WriteLine("--------------------------------------------------------------");


plainText = DecreateAES.DecryptDataWithAes(cipherText, keyBase64, vectorBase64);

Console.WriteLine("--------------------------------------------------------------");
Console.WriteLine("Here is the decrypted data:");
Console.WriteLine(plainText);