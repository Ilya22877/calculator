using System;
using Сalculator;
using Сalculator.ExpressionTree;

namespace StringСalculator
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
                    result = MyCalculator.Resolve(new StringExpressionReader(input));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    continue;
                }
                
                Console.WriteLine($"Result: {result}");
            }
        }
    }
}
