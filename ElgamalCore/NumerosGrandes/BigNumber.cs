using System;
using System.Numerics;
using System.Security.Cryptography;

namespace ElgamalCore.NumerosGrandes
{
    public static class BigNumber
    {
        /// <summary>
        /// Gera um número grande aleatório com o tamanho especificado em bits.
        /// </summary>
        /// <param name="bitLength">Quantidade de bits do número gerado.</param>
        /// <returns>Número grande aleatório do tipo BigInteger.</returns>
        /// 
        public static BigInteger GerarNumeroAleatorio(int bitLength)
        {
            if (bitLength <= 0)
                throw new ArgumentException("O tamanho em bits deve ser maior que zero.");

            int byteLength = (bitLength + 7) / 8; // Convertendo bits para bytes
            byte[] bytes = new byte[byteLength];

            // Preenchendo o array com bytes criptograficamente seguros
            RandomNumberGenerator.Fill(bytes);

            // Assegurando que o número gerado seja do tamanho desejado em bits
            BigInteger numero = new BigInteger(bytes);
            numero = BigInteger.Abs(numero); // Garante que o número seja positivo
            numero |= BigInteger.One << (bitLength - 1); // Define o bit mais significativo

            return numero;
        }

        /// <summary>
        /// Gera um número primo grande com o tamanho especificado em bits.
        /// </summary>
        /// <param name="bitLength">Quantidade de bits do número primo gerado.</param>
        /// <returns>Número primo grande do tipo BigInteger.</returns>
        public static BigInteger GerarNumeroPrimo(int bitLength)
        {
            BigInteger candidato;

            do
            {
                candidato = GerarNumeroAleatorio(bitLength);
            } while (!TestesPrimalidade.MillerRabin(candidato, 10));

            return candidato;
        }
    }
}
