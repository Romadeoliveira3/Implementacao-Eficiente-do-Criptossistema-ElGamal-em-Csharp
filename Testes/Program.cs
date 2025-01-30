using System;
using System.Numerics;
using ElgamalCore.NumerosGrandes;
using ElgamalCore.Criptografia;
using ElgamalCore.Codificacao;

namespace ElgamalCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Teste de Criptografia com ElGamal\n");

            // Gerar número primo seguro (p)
            int bitLength = 2048;
            int P = 127;
            BigInteger primoSeguro = MersenneGenerator.GerarMersenne(P);
            //BigInteger primoSeguro = BigNumber.GerarNumeroPrimo(bitLength);
            Console.WriteLine($"Número primo seguro gerado (p): {primoSeguro}");

            // Gerar chave privada (s)
            BigInteger chavePrivada = BigNumber.GerarNumeroAleatorio(bitLength - 1);
            Console.WriteLine($"Chave privada gerada (s): {chavePrivada}");

            // Gerar chave pública (g, p, t)
            BigInteger raizPrimitiva = 5; // Exemplo de raiz primitiva
            var (g, p, t) = ElGamal.GerarChavePublica(primoSeguro, raizPrimitiva, chavePrivada);
            Console.WriteLine($"Chave pública: g={g}, p={p}, t={t}");

            // Mensagem a ser criptografada
            string mensagemOriginal = "Mensagem de teste";
            Console.WriteLine($"Mensagem original: {mensagemOriginal}");
            BigInteger mensagemCodificada = CodificadorTexto.Codificar(mensagemOriginal);

            // Gerar valor aleatório k
            BigInteger k;
            do
            {
                k = BigNumber.GerarNumeroAleatorio(bitLength - 1);
            } while (BigInteger.GreatestCommonDivisor(k, primoSeguro - 1) != 1);

            Console.WriteLine($"Número aleatório gerado (k): {k}");

            // Criptografar a mensagem
            var (y, z) = ElGamal.Criptografar(mensagemCodificada, g, p, t, k);
            Console.WriteLine($"Mensagem criptografada: y={y}, z={z}");

            // Descriptografar a mensagem
            BigInteger mensagemDescriptografada = ElGamal.Descriptografar(y, z, chavePrivada, p);
            Console.WriteLine($"Mensagem descriptografada como número: {mensagemDescriptografada}");

            // Decodificar a mensagem
            string mensagemRecuperada = CodificadorTexto.Decodificar(mensagemDescriptografada);
            Console.WriteLine($"Mensagem recuperada: {mensagemRecuperada}");
        }
    }
}
