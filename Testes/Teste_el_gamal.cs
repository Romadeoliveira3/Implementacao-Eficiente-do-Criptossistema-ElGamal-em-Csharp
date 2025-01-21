using System;
using System.Numerics;
using MeuProjeto.Codificacao;
using MeuProjeto.Criptografia;

namespace MeuProjeto
{
    class Teste_el_gamal
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Teste de Criptografia com Codificação de Mensagem\n");

            // Gerar chaves ElGamal
            BigInteger primoSeguro = BigInteger.Parse("104723");  // Exemplo de primo seguro
            BigInteger raizPrimitiva = BigInteger.Parse("5");      // Exemplo de raiz primitiva
            BigInteger chavePrivada = BigInteger.Parse("12345");   // Exemplo de chave privada

            var (g, p, t) = ElGamal.GerarChavePublica(primoSeguro, raizPrimitiva, chavePrivada);

            Console.WriteLine($"Chave Pública: g={g}, p={p}, t={t}");
            Console.WriteLine($"Chave Privada: {chavePrivada}");

            // Mensagem original
            string mensagemOriginal = "Fala Familia";
            Console.WriteLine($"\nMensagem original: {mensagemOriginal}");

            // Codificar a mensagem
            BigInteger mensagemCodificada = CodificadorTexto.Codificar(mensagemOriginal);
            Console.WriteLine($"Mensagem codificada como número: {mensagemCodificada}");

            // Verificar se a mensagem codificada é menor que o primo seguro
            if (mensagemCodificada >= primoSeguro)
            {
                Console.WriteLine("A mensagem codificada é maior ou igual ao primo seguro. Escolha uma mensagem menor.");
                return;
            }


            // Criptografar a mensagem
            BigInteger k = 123; // Valor aleatório secreto para cada criptografia
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
