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
            var expressionChain = new Stack<СhainLink>();
            // todo заменить цикл
            while (true)
            {
                var chainLink = ReadNext(expression, ref pointer);
                // todo если скобок не хватает или больше?
                if (chainLink is RightBracket)
                {
                    var operatorsInBrackets = new List<Operator>();
                    do
                    {
                        var 
                    } while (b);

                }
                else
                {
                    expressionChain.Push(chainLink);
                }
            }
        }

        private СhainLink ReadNext(string expression, ref int pointer)
        {
            throw new NotImplementedException();
        }
    }
}