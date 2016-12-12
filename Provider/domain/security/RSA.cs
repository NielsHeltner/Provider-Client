using IO.Swagger.Model;
using System;
using System.Numerics;

namespace Provider.domain.security
{
    public class RSA
    {
        private BigInteger e;
        private BigInteger n;       

        public RSA(PublicKey publicKey)
        {
            e = (BigInteger) publicKey.E;
            n = (BigInteger) publicKey.N;
            
        }

        public byte[] Encrypt(byte[] message)
        {
            return (BigInteger.ModPow(new BigInteger(message), e, n).ToByteArray());
        }
        
    }
}
