using System;
using System.Collections.Generic;
using Сalculator.ExpressionСhain;

namespace Сalculator
{
    public class Calculator
    {
        public Calculator()
        {
            // todo так бы конфигурировать калькулятор через конструктор
        }

        public double Resolve(string expression)
        {
            // todo может тоже в какой-то класс?
            var pointer = 0;
            var chain = ReadNext(expression, ref pointer);
            // todo заменить цикл
            while (expression.Length != pointer)
            {
                var chainLink = ReadNext(expression, ref pointer);
                chain.AddNext(chainLink);
                // todo если скобок не хватает или больше?
                if (chainLink is RightBracket rightBracket)
                {
                    rightBracket.ResolveBrackets();
                }
            }

        }

        private СhainLink ReadNext(string expression, ref int pointer)
        {
            throw new NotImplementedException();
        }
    }
}