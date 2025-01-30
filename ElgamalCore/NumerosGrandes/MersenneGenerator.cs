using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Security;


namespace ElgamalCore.NumerosGrandes
{
    internal class MersenneGenerator
    {
        // <summary>
        // Gera num número de Mersenne para um dado primo p.
        // </summary>
        // <param name="p">Valor de p (deve ser primo).</param>
        // <returns>Número de Mersenne correspondente M_p = 2^p - 1.</returns>
        public static BigInteger GerarMersenne(int p)
        {
            if (p <= 0)
                throw new ArgumentException("O valor de p deve ser maior que zero.");
            int primo = p;
            while (!TestesPrimalidade.MillerRabin(primo, 10))
                primo++;
            return BigInteger.Pow(2, primo) - 1;

        }

        ///// <summary>
        ///// Encontra o próximo número primo maior ou igual a um dado valor
        ///// </summary>
        ///// <param name="p">Número inicial.</param>
        ///// <returns> O próximo número primo maior ou igual a p.</returns>
        //public static int ProximoPrimo(int P)
        //{
        //    if (P <= 0)
        //        throw new ArgumentException("O valor de p deve ser maior que zero.");
        //    int primo = P;
        //    while (!TestesPrimalidade.MillerRabin(primo, 10))
        //        primo++;
        //    return primo;
        //}
    }
}
