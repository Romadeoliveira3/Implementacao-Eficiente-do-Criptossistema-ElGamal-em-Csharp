using System;
using System.Numerics;

namespace ElgamalCore.Codificacao
{
    public static class CodificadorTexto
    {
        private const int BASE = 53; // Base do sistema modular: 26 letras minúsculas + 1 espaço + 26 maiúsculas
        private const char ESPACO = ' '; // Representação do espaço como caractere

        /// <summary>
        /// Codifica uma frase em um número inteiro grande.
        /// </summary>
        /// <param name="frase">Frase a ser codificada (apenas letras minúsculas e espaços).</param>
        /// <returns>Número codificado como BigInteger.</returns>
        public static BigInteger Codificar(string frase)
        {
            BigInteger m = 0;

            for (int i = 0; i < frase.Length; i++)
            {
                int cod = ObterCodigo(frase[i]);
                m += cod * BigInteger.Pow(BASE, i);
            }

            return m;
        }

        /// <summary>
        /// Decodifica um número inteiro grande em uma frase.
        /// </summary>
        /// <param name="m">Número codificado como BigInteger.</param>
        /// <returns>Frase decodificada.</returns>
        public static string Decodificar(BigInteger m)
        {
            string frase = string.Empty;

            while (m > 0)
            {
                int cod = (int)(m % BASE); // Obtem o código do caractere
                frase = ObterCaractere(cod) + frase; // Concatena na ordem correta
                m /= BASE;
            }

            // Inverte a frase para a ordem correta
            char[] arr = frase.ToCharArray();
            Array.Reverse(arr);

            return new string(arr);
        }

        /// <summary>
        /// Calcula a restrição de tamanho do texto.
        /// </summary>
        /// <param name="bitsDisponiveis">Número de bits disponíveis para representar m.</param>
        /// <returns>Tamanho máximo do texto em caracteres.</returns>
        public static int CalcularTamanhoMaximo(int bitsDisponiveis)
        {
            return (int)Math.Floor(bitsDisponiveis / Math.Log2(BASE));
        }

        /// <summary>
        /// Obtem o código de um caractere.
        /// </summary>
        private static int ObterCodigo(char caractere)
        {
            if (caractere == ESPACO) return 0; // Espaço é o código 0
            if (char.IsLower(caractere)) return caractere - 'a' + 1; // Letras minúsculas começam em 'a'
            if (char.IsUpper(caractere)) return caractere - 'A' + 27; // Letras maiúsculas começam em 'A'
            throw new ArgumentException($"Caractere inválido:  + { caractere }");
        }

        /// <summary>
        /// Obtem o caractere correspondente a um código.
        /// </summary>
        private static char ObterCaractere(int codigo)
        {
            if (codigo == 0) return ESPACO;
            if (codigo >= 1 && codigo <= 26) return (char)('a' + codigo - 1); // Letras minúsculas
            if (codigo >= 27 && codigo <= 52) return (char)('A' + codigo - 27); // Letras maiúsculas
            throw new ArgumentException($"Código inválido: {codigo}");
        }
    }
}
