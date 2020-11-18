using System;
using System.Linq;

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

            var arrayOfSource = source.ToCharArray();            
            var tmpArray = (char[])arrayOfSource.Clone();
            
            for (int i = 0; i < count; i++)
            {
                if (tmpArray.SequenceEqual(arrayOfSource) && i != 0)
                {
                    count = (count % i) + i;
                }

                tmpArray = Transposition(tmpArray);
            }

            return new string(tmpArray);
        }

        private static char[] Transposition(char[] array)
        {
            var tmp = (char[])array.Clone();
            int middleOfArray;
            if (array.Length % 2 == 0)
            {
                middleOfArray = array.Length / 2;
            }
            else
            {
                middleOfArray = (array.Length / 2) + 1;
            }

            var indexOfEven = 0;
            var indexOfOdd = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if ((i & 1) == 0)
                {
                    tmp[indexOfEven] = array[i];
                    indexOfEven++;
                }
                else
                {
                    tmp[middleOfArray + indexOfOdd] = array[i];
                    indexOfOdd++;
                }
            }

            return tmp;
        }
    }
}
