using System;
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
            Console.WriteLine("Experimento de Criptografia e Recuperação\n");

            // Configuração do experimento
            string mensagemOriginal = "Mensagem curta";
            int bitLength = 2048;

            Console.WriteLine($"Mensagem Original: {mensagemOriginal}");

            // Gerar chaves
            Console.WriteLine("\nGerando chaves...");
            BigInteger p = BigNumber.GerarNumeroPrimo(bitLength); // Primo seguro
            BigInteger s = BigNumber.GerarNumeroAleatorio(bitLength - 1); // Chave privada
            BigInteger g = 5; // Raiz primitiva
            BigInteger t = BigInteger.ModPow(g, s, p); // Parte da chave pública
            Console.WriteLine($"Chave pública: g={g}, p={p}, t={t}");
            Console.WriteLine($"Chave privada: s={s}");

            // Codificar a mensagem
            BigInteger mensagemCodificada = CodificadorTexto.Codificar(mensagemOriginal);
            Console.WriteLine($"\nMensagem codificada como número: {mensagemCodificada}");

            // Criptografar a mensagem
            Console.WriteLine("\nCriptografando a mensagem...");
            BigInteger k;
            do
            {
                k = BigNumber.GerarNumeroAleatorio(bitLength - 1);
            } while (BigInteger.GreatestCommonDivisor(k, p - 1) != 1);
            var (y, z) = ElGamal.Criptografar(mensagemCodificada, g, p, t, k);
            Console.WriteLine($"Par criptografado: y={y}, z={z}");

            // Descriptografar a mensagem
            Console.WriteLine("\nDescriptografando a mensagem...");
            BigInteger mensagemDescriptografada = ElGamal.Descriptografar(y, z, s, p);
            Console.WriteLine($"Mensagem descriptografada como número: {mensagemDescriptografada}");

            // Decodificar a mensagem
            string mensagemRecuperada = CodificadorTexto.Decodificar(mensagemDescriptografada);
            Console.WriteLine($"Mensagem recuperada: {mensagemRecuperada}");

            // Validar integridade
            Console.WriteLine($"\nIntegridade da mensagem: {(mensagemOriginal == mensagemRecuperada ? "Correta" : "Incorreta")}");
        }
    }
}
