using System;
using System.Diagnostics;
using System.Numerics;
using ElgamalCore.NumerosGrandes;
using ElgamalCore.Codificacao;
using ElgamalCore.Criptografia;

namespace ElgamalCore
{
    class Program
    {
        static void Main(string[] args)
        {
            // Executa os testes para diferentes tamanhos de chave
            ExecutarTestes();
        }

        public static void ExecutarTestes()
        {
            int[] tamanhosBits = { 512, 1024, 2048, 4096 }; // Tamanhos das chaves
            string mensagemOriginal = "Mensagem de teste";

            foreach (int bitLength in tamanhosBits)
            {
                Console.WriteLine($"\n=== Testando com chave de {bitLength} bits ===");

                // Medir tempo de geração de chaves
                Stopwatch stopwatch = Stopwatch.StartNew();
                BigInteger p = BigNumber.GerarNumeroPrimo(bitLength);
                BigInteger s = BigNumber.GerarNumeroAleatorio(bitLength - 1);
                BigInteger g = 5;
                BigInteger t = BigInteger.ModPow(g, s, p);
                stopwatch.Stop();
                Console.WriteLine($"Tempo para gerar chaves: {stopwatch.ElapsedMilliseconds} ms");

                // Codificar a mensagem
                BigInteger mensagemCodificada = CodificadorTexto.Codificar(mensagemOriginal);

                // Medir tempo de criptografia
                stopwatch.Restart();
                BigInteger k;
                do
                {
                    k = BigNumber.GerarNumeroAleatorio(bitLength - 1);
                } while (BigInteger.GreatestCommonDivisor(k, p - 1) != 1);
                var (y, z) = ElGamal.Criptografar(mensagemCodificada, g, p, t, k);
                stopwatch.Stop();
                Console.WriteLine($"Tempo para criptografar: {stopwatch.ElapsedMilliseconds} ms");

                // Medir tempo de descriptografia
                stopwatch.Restart();
                BigInteger mensagemDescriptografada = ElGamal.Descriptografar(y, z, s, p);
                stopwatch.Stop();
                Console.WriteLine($"Tempo para descriptografar: {stopwatch.ElapsedMilliseconds} ms");

                // Validar precisão
                string mensagemRecuperada = CodificadorTexto.Decodificar(mensagemDescriptografada);
                Console.WriteLine($"Mensagem recuperada: {mensagemRecuperada}");
                Console.WriteLine($"Precisão: {(mensagemOriginal == mensagemRecuperada ? "Correto" : "Erro")}");
            }
        }
    }
}
