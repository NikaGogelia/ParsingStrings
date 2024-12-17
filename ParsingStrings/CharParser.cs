using System;

namespace ParsingStrings
{
    public static class CharParser
    {
        /// <summary>
        /// Converts the value of the specified string to its equivalent Unicode character.
        /// </summary>
        /// <param name="str">A string that contains a single character, or null.</param>
        /// <param name="result">When this method returns, contains a Unicode character equivalent to the sole character in <see cref="str"/>, if the conversion succeeded, or an undefined value if the conversion failed.</param>
        /// <returns>true if the <see cref="str"/> parameter was converted successfully; otherwise, false.</returns>
        public static bool TryParseChar(string str, out char result)
        {
            result = '\0';

            if (string.IsNullOrEmpty(str) || str.Length != 1)
            {
                return false;
            }

            result = str[0];
            return true;
        }

        /// <summary>
        /// Converts the value of the specified string to its equivalent Unicode character.
        /// </summary>
        /// <param name="str">A string that contains a single character, or null.</param>
        /// <returns>A Unicode character equivalent to the sole character in <see cref="str"/>. If a formatting error occurs returns space character.</returns>
        public static char ParseChar(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str), "Input string cannot be null.");
            }

            if (string.IsNullOrEmpty(str) || str.Length != 1)
            {
                return ' ';
            }

            return str[0];
        }
    }
}
