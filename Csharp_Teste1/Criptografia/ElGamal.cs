using System;
using System.Numerics;

namespace ElgamalCore.Criptografia
{
    public static class ElGamal
    {
        public static (BigInteger g, BigInteger p, BigInteger t) GerarChavePublica(BigInteger primoSeguro, BigInteger raizPrimitiva, BigInteger chavePrivada)
        {
            BigInteger chavePublica = BigInteger.ModPow(raizPrimitiva, chavePrivada, primoSeguro);
            return (raizPrimitiva, primoSeguro, chavePublica);
        }
        ///<summary>
        ///Gerar o par de chaves pública e privada para o ElGamal.
        /// </summary>
        public static (BigInteger y, BigInteger z) Criptografar(BigInteger mensagem, BigInteger g, BigInteger p, BigInteger t, BigInteger k)
        {
            BigInteger y = BigInteger.ModPow(g, k, p);
            BigInteger z = (mensagem * BigInteger.ModPow(t, k, p)) % p;
            return (y, z);
        }

        ///<summary>
        ///Descriptografa a mensagem com a chave privada.
        /// </summary>
        public static BigInteger Descriptografar(BigInteger y, BigInteger z, BigInteger s, BigInteger p)
        {
            BigInteger ys = BigInteger.ModPow(y, s, p);
            BigInteger inverso = BigInteger.ModPow(ys, p - 2, p); // Usando propriedade do primo para calcular o inverso
            return (z * inverso) % p;
        }
    }
}
