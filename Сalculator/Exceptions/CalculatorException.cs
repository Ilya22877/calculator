using System;

namespace Сalculator.Exceptions
{
    public class CalculatorException : Exception
    {
        public CalculatorException(string message) : base(message)
        {
        }
    }
}