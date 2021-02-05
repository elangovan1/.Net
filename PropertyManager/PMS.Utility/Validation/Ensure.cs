using System;

namespace PMS.Utility.Validation
{
    public class Ensure
    {
        public static void IsNotNull(object argumentValue, string argumentName)
        {
            if (argumentValue == null)
                throw new ArgumentNullException(null, $"Argument {argumentName} cannot be null.");
        }
        public static void IsNotNullOrEmpty(string argumentValue, string argumentName)
        {
            if (string.IsNullOrEmpty(argumentValue))
                throw new ArgumentNullException(null, $"Argument {argumentName} cannot be null or empty.");
        }
        public static void IsNullOrWhiteSpace(string argumentValue, string argumentName)
        {
            if (string.IsNullOrWhiteSpace(argumentValue))
                throw new ArgumentNullException(null, $"Argument {argumentName} cannot be null or whitespace.");
        }
        public static void IsNotZero(int argumentValue, string argumentName)
        {
            if (argumentValue == 0)
                throw new ArgumentException($"Argument {argumentName} cannot be zero.", string.Empty);
        }
        public static void IsLessThan(int maxValue, int argumentValue, string argumentName)
        {
            if (argumentValue >= maxValue)
                throw new ArgumentException($"Argument {argumentName} cannot exceed.", string.Empty);
        }
        public static void IsMoreThan(int minValue, int argumentValue, string argumentName)
        {
            if (argumentValue <= minValue)
                throw new ArgumentException($"Argument {argumentName} cannot be lower than {minValue}.", string.Empty);
        }
    }
}
