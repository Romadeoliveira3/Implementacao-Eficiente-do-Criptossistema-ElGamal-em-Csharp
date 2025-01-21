using System;
using System.Numerics;
using ElgamalCore.NumerosGrandes;
using ElgamalCore.Criptografia;

namespace ElgamalCore
{
    class Teste_el_gamal   
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Teste de Primalidade - Número de Mersenne");
            BigInteger mersenne = BigInteger.Pow(2, 521) - 1;
            bool ehPrimo = TestesPrimalidade.MillerRabin(mersenne, 10);
            Console.WriteLine($"O número de Mersenne é primo? {ehPrimo}");

            Console.WriteLine("Teste de Criptografia ElGamal");
            BigInteger primoSeguro = BigInteger.Parse("104723");
            BigInteger raizPrimitiva = BigInteger.Parse("5");
            BigInteger chavePrivada = 12345;

            var (g, p, t) = ElGamal.GerarChavePublica(primoSeguro, raizPrimitiva, chavePrivada);
            Console.WriteLine($"Chave Pública: g={g}, p={p}, t={t}"); //Chave Pública: g = 5, p = 104723, t = 1024


        }
    }
}
