using System;
using System.Numerics;

namespace ElgamalCore.NumerosGrandes
{
    public static class TestesPrimalidade
    {
        public static bool MillerRabin(BigInteger numero, int iteracoes)
        {
            if (numero < 2) return false;

            BigInteger d = numero - 1;
            int r = 0;

            while (d % 2 == 0)
            {
                d /= 2;
                r++;
            }

            Random rand = new Random();
            for (int i = 0; i < iteracoes; i++)
            {
                BigInteger a = 2 + (BigInteger)rand.Next() % (numero - 4);
                BigInteger x = BigInteger.ModPow(a, d, numero);

                if (x == 1 || x == numero - 1) continue;

                bool composto = true;
                for (int j = 0; j < r - 1; j++)
                {
                    x = BigInteger.ModPow(x, 2, numero);
                    if (x == numero - 1)
                    {
                        composto = false;
                        break;
                    }
                }

                if (composto) return false;
            }

            return true;
        }
    }
}
