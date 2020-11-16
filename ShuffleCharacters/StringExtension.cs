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

            StringBuilder sb = new StringBuilder(256);

            for (int i = 0; i < count; i++)
            {
                sb.Remove(0, sb.Length);
                for (int even = 0; even < source.Length; even += 2)
                {
                    sb.Append(source[even]);
                }

                for (int odd = 1; odd < source.Length; odd += 2)
                {
                    sb.Append(source[odd]);
                }

                source = sb.ToString();
            }

            return source;
        }
    }
}
