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

            //StringBuilder sb = new StringBuilder(256);

            //for (int i = 0; i < count; i++)
            //{
            //    sb.Remove(0, sb.Length);
            //    for (int even = 0; even < source.Length; even += 2)
            //    {
            //        sb.Append(source[even]);
            //    }

            //    for (int odd = 1; odd < source.Length; odd += 2)
            //    {
            //        sb.Append(source[odd]);
            //    }

            //    source = sb.ToString();
            //}

            //return source;

            var sourceArray = source.ToCharArray();
            var destination = source.ToCharArray();
            var length = sourceArray.Length;

            int middle;
            if (length % 2 == 0)
            {
                middle = length / 2;
            }
            else
            {
                middle = (length / 2) + 1;
            }

            for (int cnt = 0; cnt < count; cnt++)
            {
                var indexOfEven = 0;
                var indexOfOdd = 0;
                for (int i = 0; i < length; i++)
                {
                    if ((i & 1) == 0)
                    {
                        destination[indexOfEven] = source[i];
                        indexOfEven++;
                    }
                    else
                    {
                        destination[middle + indexOfOdd] = source[i];
                        indexOfOdd++;
                    }
                }

                source = new string(destination);
            }

            return new string(destination);
        }
    }
}
