using System;
using System.Text;

namespace ShuffleCharacters
{
    public static class StringExtension
    {
        /// <summary>
        /// Shuffles characters in source string according some rule.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="count">The count of iterations.</param>
        /// <returns>Result string.</returns>
        /// <exception cref="ArgumentException">Source string is null or empty or white spaces.</exception>
        /// <exception cref="ArgumentException">Count of iterations less than 0.</exception>
        public static string ShuffleChars(string source, int count)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentException("Source string is null or empty or white spaces.");
            }

            if (count < 0)
            {
                throw new ArgumentException("Count of iterations less than 0.");
            }

            var iterationsForCompleteCycle = 0;
            var tmpSource = source;
            do
            {
                tmpSource = Transposition(tmpSource);
                iterationsForCompleteCycle++;
            }
            while (tmpSource != source);

            if (count > iterationsForCompleteCycle)
            {
                do
                {
                    count -= iterationsForCompleteCycle;
                }
                while (count - iterationsForCompleteCycle > 0);
            }

            for (int i = 0; i < count; i++)
            {
                source = Transposition(source);
            }

            return source;
        }

        private static string Transposition(string source)
        {
            StringBuilder sb = new StringBuilder(source.Length);
            for (int even = 0; even < source.Length; even += 2)
            {
                sb.Append(source[even]);
            }

            for (int odd = 1; odd < source.Length; odd += 2)
            {
                sb.Append(source[odd]);
            }

            return sb.ToString();
        }
    }
}
