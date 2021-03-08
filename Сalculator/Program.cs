using System;
using Сalculator.Exceptions;

namespace Сalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter expression:");
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    continue;
                }

                if (input.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
                {
                    break;
                }

                double result;
                try
                {
                    var reader = new StringExpressionReader(input);
                    result = MyCalculator.Resolve(reader);
                }
                catch (CalculatorException e)
                {
                    Console.WriteLine(
                        $"An error has occured. {e.Message}");
                    continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine(
                        $"An error has occured. {e}");
                    continue;
                }

                Console.WriteLine($"Result: {result}");
            }
        }
    }
}
