using System;
using System.Numerics;
using ElgamalCore.NumerosGrandes;

namespace MeuProjeto
{
    class Teste_Mersenne
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Gerando número de Mersenne...\n");

                int p = 5; // Exemplo: valor de p
                BigInteger mersenne =  MersenneGenerator.GerarMersenne(p);
                Console.WriteLine($"Número de Mersenne M_{p} = {mersenne}");

                int proximoPrimo = MersenneGenerator.ProximoPrimo(p);
                Console.WriteLine($"Próximo primo maior ou igual a {p} é {proximoPrimo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
