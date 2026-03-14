using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoParkAnimalManagementSystem_EAMS_.Utilities
{
    /// <summary>
    /// Utility class for converting text input to numeric values.
    /// Returns tuples with the converted value and success status.
    /// </summary>
    public class NumericUtility
    {
        /// <summary>
        /// Thus methods attempts to convert a string to an integer.
        /// </summary>
        /// <param name="text">The text to convert.</param>
        /// <returns>Tuple with the integer value and success status.</returns>
         

        public static (int value, bool success) GetInteger(string text)
        {
            if (int.TryParse(text, out int result))
            {
                return (result, true);
            }
            return (0, false);
        }

        /// <summary>
        /// Attempts to convert a string to a double.
        /// </summary>
        /// <param name="text">The text to convert.</param>
        /// <returns>Tuple with the double value and success status.</returns>
        public static (double value, bool success) GetDouble(string text)
        {
            if (double.TryParse(text, out double result))
            {
                return (result, true);
            }
            return (0.0, false);
        }

    }
}
