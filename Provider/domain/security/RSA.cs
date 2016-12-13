using IO.Swagger.Model;
using System;
using System.Numerics;
using System.Text;

namespace Provider.domain.security
{
    public class RSA
    {
        private BigInteger e;
        private BigInteger n;       

        public RSA(PublicKey publicKey)
        {
            e = BigInteger.Parse(publicKey.E);
            n = BigInteger.Parse(publicKey.N);
            
        }

        public string Encrypt(string message)
        {   
            // Convert the message to a char array of the individual chars in the string
            char[] charArray = message.ToCharArray();

            // Convert the char array to its corresponding byte and put it into a byte array
            byte[] byteArray = Encoding.UTF8.GetBytes(charArray);

            // Reverses the byte array, because Java uses Big-Endian and C# uses Little-Endian
            Array.Reverse(byteArray);

            // Convert the byte array into a BigInteger to do the encrypt algorithm
            BigInteger byteArrayAsBigInt = new BigInteger(byteArray);

            // Returns the encrypted message as a string
            return BigInteger.ModPow(byteArrayAsBigInt, e, n).ToString();
        }
        
    }
}
