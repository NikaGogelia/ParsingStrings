using System;

namespace ParsingStrings
{
    public static class NumberParser
    {
        /// <summary>
        /// Converts the string representation of a number to its 32-bit signed integer equivalent. A return value indicates whether the operation succeeded.
        /// </summary>
        /// <param name="str">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the 32-bit signed integer value equivalent of the number contained in <see cref="str"/>, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if <see cref="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseInteger(string str, out int result)
        {
            return int.TryParse(str, out result);
        }

        /// <summary>
        /// Converts the string representation of a number to its 32-bit signed integer equivalent.
        /// </summary>
        /// <param name="str">A string containing a number to convert.</param>
        /// <returns>A 32-bit signed integer equivalent to the number contained in <see cref="str"/>. If a formatting error occurs returns zero. If an overflow error occurs returns minus one.</returns>
        public static int ParseInteger(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str), "Input string cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(str))
            {
                return 0;
            }

            str = str.Trim();

            try
            {
                int result = int.Parse(str);
                return result;
            }
            catch (FormatException)
            {
                return 0;
            }
            catch (OverflowException)
            {
                return -1;
            }
        }

        /// <summary>
        /// Tries to convert the string representation of a number to its 32-bit unsigned integer equivalent. A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="str">A string that represents the number to convert.</param>
        /// <param name="result">When this method returns, contains the 32-bit unsigned integer value that is equivalent to the number contained in <see cref="str"/>, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if <see cref="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseUnsignedInteger(string str, out uint result)
        {
            result = 0;

            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            str = str.Trim();

            if (uint.TryParse(str, out result))
            {
                return result <= uint.MaxValue;
            }

            return false;
        }

        /// <summary>
        /// Converts the string representation of a number to its 32-bit unsigned integer equivalent.
        /// </summary>
        /// <param name="str">A string representing the number to convert.</param>
        /// <returns>A 32-bit unsigned integer equivalent to the number contained in <see cref="str"/>. If a formatting error occurs returns minimum value of unsigned int. If an overflow error occurs returns maximum value of unsigned int.</returns>
        public static uint ParseUnsignedInteger(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str), "Input string cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(str))
            {
                return uint.MinValue;
            }

            str = str.Trim();

            if (str.StartsWith("-"))
            {
                return uint.MaxValue;
            }

            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                {
                    return uint.MinValue;
                }
            }

            if (uint.TryParse(str, out uint result))
            {
                return result;
            }

            return uint.MaxValue;
        }

        /// <summary>
        /// Tries to convert the string representation of a number to its Byte equivalent, and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="str">A string that contains a number to convert.</param>
        /// <param name="result">When this method returns, contains the Byte value equivalent to the number contained in <see cref="str"/> if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if <see cref="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseByte(string str, out byte result)
        {
            result = 0;

            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            str = str.Trim();

            if (str.StartsWith("-"))
            {
                return false;
            }

            if (byte.TryParse(str, out byte parsedValue))
            {
                result = parsedValue;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Converts the string representation of a number to its Byte equivalent.
        /// </summary>
        /// <param name="str">A string that contains a number to convert.</param>
        /// <returns>A byte value that is equivalent to the number contained in <see cref="str"/>. If a formatting error occurs returns maximum value of byte. If an overflow error occurs returns minimum value of byte.</returns>
        public static byte ParseByte(string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            try
            {
                str = str.Trim();

                if (byte.TryParse(str, out byte result))
                    return result;

                if (int.TryParse(str, out int tempResult))
                {
                    if (tempResult < byte.MinValue || tempResult > byte.MaxValue)
                        return byte.MinValue;
                }

                return byte.MaxValue;
            }
            catch (FormatException)
            {
                return byte.MaxValue;
            }
            catch (OverflowException)
            {
                return byte.MinValue;
            }
        }

        /// <summary>
        /// Tries to convert the string representation of a number to its SByte equivalent, and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="str">A string that contains a number to convert.</param>
        /// <param name="result">When this method returns, contains the 8-bit signed integer value that is equivalent to the number contained in <see cref="str"/> if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if <see cref="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TrySignedByte(string str, out sbyte result)
        {
            result = 0;
            if (str == null)
                return false;

            str = str.Trim();
            return sbyte.TryParse(str, out result);
        }

        /// <summary>
        /// Converts the string representation of a number to its 8-bit signed integer equivalent.
        /// </summary>
        /// <param name="str">A string that represents a number to convert.</param>
        /// <returns>An 8-bit signed integer that is equivalent to the number contained in the <see cref="str"/> parameter. If a formatting error occurs returns maximum value of signed byte.</returns>
        public static sbyte ParseSignedByte(string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            str = str.Trim();

            if (sbyte.TryParse(str, out sbyte result))
            {
                return result;
            }

            if (int.TryParse(str, out int tempResult))
            {
                if (tempResult < sbyte.MinValue || tempResult > sbyte.MaxValue)
                {
                    throw new OverflowException("Value is outside the range of a signed byte.");
                }
            }

            return sbyte.MaxValue;
        }

        /// <summary>
        /// Converts the string representation of a number to its 16-bit signed integer equivalent.
        /// </summary>
        /// <param name="str">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the 16-bit signed integer value equivalent to the number contained in <see cref="str"/>, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if <see cref="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseShort(string str, out short result)
        {
            result = 0;
            if (str == null)
                return false;

            str = str.Trim();

            return short.TryParse(str, out result);
        }

        /// <summary>
        /// Converts the string representation of a number to its 16-bit signed integer equivalent.
        /// </summary>
        /// <param name="str">A string containing a number to convert.</param>
        /// <returns>A 16-bit signed integer equivalent to the number contained in <see cref="str"/>. If an overflow error occurs returns maximum value of short.</returns>
        public static short ParseShort(string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            try
            {
                str = str.Trim();

                if (short.TryParse(str, out short result))
                    return result;

                if (int.TryParse(str, out int tempResult))
                {
                    if (tempResult < short.MinValue || tempResult > short.MaxValue)
                        throw new OverflowException();
                }

                throw new FormatException("Input string was not in a correct format.");
            }
            catch (FormatException)
            {
                throw new FormatException("Input string was not in a correct format.");
            }
            catch (OverflowException)
            {
                throw new OverflowException("The number is too large or too small for a 16-bit signed integer.");
            }
        }

        /// <summary>
        /// Converts the string representation of a number to its 16-bit unsigned integer equivalent.
        /// </summary>
        /// <param name="str">A string that represents the number to convert.</param>
        /// <param name="result">When this method returns, contains the 16-bit unsigned integer value that is equivalent to the number contained in <see cref="str"/>, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if <see cref="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseUnsignedShort(string str, out ushort result)
        {
            result = 0; // Initialize the result to zero in case the parsing fails.

            if (str == null)
                return false; // Return false if the string is null.

            try
            {
                str = str.Trim(); // Remove leading and trailing spaces.

                // Try parsing the string to an unsigned short (ushort).
                if (ushort.TryParse(str, out result))
                {
                    return true; // Successfully parsed.
                }

                // If parsing fails, return false.
                return false;
            }
            catch (FormatException)
            {
                // Handle the case where the string is not a valid format.
                return false;
            }
            catch (OverflowException)
            {
                // Handle the case where the value is out of the range of ushort.
                return false;
            }
        }

        /// <summary>
        /// Converts the string representation of a number to its 16-bit unsigned integer equivalent.
        /// </summary>
        /// <param name="str">A string that represents the number to convert.</param>
        /// <returns>A 16-bit unsigned integer equivalent to the number contained in <see cref="str"/>. If a formatting error occurs returns zero. If an overflow error occurs returns maximum value of unsigned short.</returns>
        public static ushort ParseUnsignedShort(string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            try
            {
                str = str.Trim();

                if (ushort.TryParse(str, out ushort result))
                    return result;

                if (int.TryParse(str, out int tempResult))
                {
                    if (tempResult < 0 || tempResult > ushort.MaxValue)
                        return ushort.MaxValue;
                }

                return 0;
            }
            catch (FormatException)
            {
                return 0;
            }
            catch (OverflowException)
            {
                return ushort.MaxValue;
            }
        }

        /// <summary>
        /// Converts the string representation of a number to its 64-bit signed integer equivalent.
        /// </summary>
        /// <param name="str">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the 64-bit signed integer value equivalent of the number contained in <see cref="str"/>, if the conversion succeeded, or zero if the conversion failed. </param>
        /// <returns>true if <see cref="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseLong(string str, out long result)
        {
            result = 0;
            if (str == null)
                return false;

            str = str.Trim();

            return long.TryParse(str, out result);
        }

        /// <summary>
        /// Converts the string representation of a number to its 64-bit signed integer equivalent.
        /// </summary>
        /// <param name="str">A string containing a number to convert.</param>
        /// <returns>A 64-bit signed integer equivalent to the number contained in <see cref="str"/>. If a formatting error occurs returns minimum value of long. If an overflow error occurs returns minus one.</returns>
        public static long ParseLong(string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            try
            {
                str = str.Trim();

                if (long.TryParse(str, out long result))
                {
                    return result;
                }

                if (str.Length > 19 || (str.Length == 19 && str.CompareTo("9223372036854775807") > 0) || (str.Length == 20 && str.CompareTo("-9223372036854775808") > 0))
                {
                    return -1;
                }

                return long.MinValue;
            }
            catch (FormatException)
            {
                return long.MinValue;
            }
            catch (OverflowException)
            {
                return -1;
            }
        }

        /// <summary>
        /// Tries to convert the string representation of a number to its 64-bit unsigned integer equivalent.
        /// </summary>
        /// <param name="str">A string that represents the number to convert.</param>
        /// <param name="result">When this method returns, contains the 64-bit unsigned integer value that is equivalent to the number contained in <see cref=""/>, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if <see cref="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseUnsignedLong(string str, out ulong result)
        {
            result = 0;
            if (str == null)
                return false;

            str = str.Trim();

            return ulong.TryParse(str, out result);
        }

        /// <summary>
        /// Converts the string representation of a number to its 64-bit unsigned integer equivalent.
        /// </summary>
        /// <param name="str">A string that represents the number to convert.</param>
        /// <returns>A 64-bit unsigned integer equivalent to the number contained in <see cref="str"/>.</returns>
        public static ulong ParseUnsignedLong(string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            str = str.Trim();

            if (ulong.TryParse(str, out ulong result))
            {
                return result;
            }
            else
            {
                if (str.StartsWith("-"))
                {
                    throw new OverflowException("The number is negative and cannot be parsed to a 64-bit unsigned integer.");
                }

                if (decimal.TryParse(str, out decimal tempResult) && tempResult > ulong.MaxValue)
                {
                    throw new OverflowException("The number is too large for a 64-bit unsigned integer.");
                }

                throw new FormatException("Input string was not in a correct format.");
            }
        }
    }
}
