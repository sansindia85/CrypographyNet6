// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;

Console.WriteLine("Random Number Demonstration in .NET 6");

for (var i = 0; i < 10; i++)
{
    var randomNumbers = RandomNumberGenerator.GetBytes(32);
    Console.WriteLine("Random Number "+ i + " : " 
                      + Convert.ToBase64String(randomNumbers));
}

Console.ReadLine();
