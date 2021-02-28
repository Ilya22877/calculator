using System;
using Сalculator;

namespace StringСalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new StringCalculator();
            while (true)
            {
                Console.WriteLine("Enter expression:");
                var input = Console.ReadLine();
                // todo проверка пустой строки
                // todo switch?
                if (input.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
                {
                    break;
                }
            }
        }
    }
}
