using System;
using System.Numerics;

namespace ParsingStrings
{
    public static class FloatingPointParser
    {
        /// <summary>
        /// Converts the string representation of a number to its single-precision floating-point number equivalent.
        /// </summary>
        /// <param name="str">A string representing a number to convert.</param>
        /// <param name="result">When this method returns, contains single-precision floating-point number equivalent to the numeric value or symbol contained in <paramref name="str"/>, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if <paramref name="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseFloat(string str, out float result)
        {
            result = 0.0f;

            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            return float.TryParse(str, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out result);
        }

        /// <summary>
        /// Converts the string representation of a number to its single-precision floating-point number equivalent.
        /// </summary>
        /// <param name="str">A string that contains a number to convert.</param>
        /// <returns>A single-precision floating-point number equivalent to the numeric str or symbol specified in <paramref name="str"/>.  If a formatting error occurs returns NaN. </returns>
        public static float ParseFloat(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str), "Input string cannot be null.");
            }

            if (float.TryParse(str, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out float result))
            {
                return result;
            }

            return float.NaN;
        }

        /// <summary>
        /// Converts the string representation of a number to its double-precision floating-point number equivalent.
        /// </summary>
        /// <param name="str">A string representing a number to convert.</param>
        /// <param name="result">When this method returns, contains double-precision floating-point number equivalent to the numeric value or symbol contained in <paramref name="str"/>, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if <paramref name="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseDouble(string str, out double result)
        {
            result = 0.0;

            if (double.TryParse(str, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out result))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Converts the string representation of a number to its double-precision floating-point number equivalent.
        /// </summary>
        /// <param name="str">A string that contains a number to convert.</param>
        /// <returns>A double-precision floating-point number equivalent to the numeric str or symbol specified in <paramref name="str"/>. If a formatting error occurs returns Epsilon.</returns>
        public static double ParseDouble(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str), "Input string cannot be null.");
            }

            if (double.TryParse(str, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double result))
            {
                return result;
            }

            return double.Epsilon;
        }

        /// <summary>
        /// Converts the string representation of a number to its Decimal equivalent.
        /// </summary>
        /// <param name="str">The string representation of the number to convert.</param>
        /// <param name="result">When this method returns, contains the Decimal number that is equivalent to the numeric value contained in <paramref name="str"/>, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if <paramref name="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseDecimal(string str, out decimal result)
        {
            result = 0.0m;

            if (decimal.TryParse(str, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out result))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Converts the string representation of a number to its Decimal equivalent.
        /// </summary>
        /// <param name="str">The string representation of the number to convert.</param>
        /// <returns>The equivalent to the number contained in <paramref name="str"/>.</returns>
        public static decimal ParseDecimal(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str), "Input string cannot be null.");
            }

            str = str.Trim();

            if (string.IsNullOrEmpty(str))
            {
                return 0m;
            }

            if (decimal.TryParse(str, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out decimal result))
            {
                return result;
            }

            return 0m;
        }
    }
}
