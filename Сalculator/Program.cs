using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
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
