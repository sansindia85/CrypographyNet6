// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using System.Text;
using AES;

//TestAesCBC();
TestAesGCM();

static void TestAesCBC()
{
    const string original = "Text to encrypt";
    var key = RandomNumberGenerator.GetBytes(32);
    var iv = RandomNumberGenerator.GetBytes(16);

    var encrypted = AesEncryption.Encrypt(Encoding.UTF8.GetBytes(original), key, iv);
    var decrypted = AesEncryption.Decrypt(encrypted, key, iv);

    var decryptedMessage = Encoding.UTF8.GetString(decrypted);

    Console.WriteLine("AES Encryption Demonstration in .NET");
    Console.WriteLine("Original Text = " + original);
    Console.WriteLine("Encrypted Text = " + Convert.ToBase64String(encrypted));
    Console.WriteLine("Decrypted Text = " + decryptedMessage);
}

static void TestAesGCM()
{
    const string original = "Text to encrypt";

    var gcmkey = RandomNumberGenerator.GetBytes(32);
    var nonce = RandomNumberGenerator.GetBytes(12);

    try
    {
        (byte[] cipherText, byte[] tag) result = AesGCMEncryption.Encrypt(Encoding.UTF8.GetBytes(original), gcmkey,
            nonce, Encoding.UTF8.GetBytes("some metadata"));
        byte[] decryptedText = AesGCMEncryption.Decrypt(result.cipherText, gcmkey, nonce, result.tag,
            Encoding.UTF8.GetBytes("some metadata"));

        Console.WriteLine("AES GCM Encryption Demonstration in .NET");
        Console.WriteLine("Original Text = " + original);
        Console.WriteLine("Encrypted Text = " + Convert.ToBase64String(result.cipherText));
        Console.WriteLine("Decrypted Text = " + Encoding.UTF8.GetString(decryptedText));
    }
    catch (CryptographicException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
    
}
