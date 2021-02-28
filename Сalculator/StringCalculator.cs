using System;
using System.Collections.Generic;
using System.Linq;
using StringСalculator.ExpressionTree;
using StringСalculator.ExpressionTree.Arguments;
using StringСalculator.ExpressionTree.Operators;
using Сalculator.ExpressionTree;

namespace Сalculator
{
    public class StringCalculator
    {
        public StringCalculator()
        {
            // todo так бы конфигурировать калькулятор через конструктор
        }

        public double Resolve(ExpressionReader reader)
        {
            // todo prepare expression + validate
            // todo перенести выше
            // todo может тоже в какой-то класс?
            var stack = new Stack<ExpressionItem>();
            // todo заменить цикл
            while (reader.CanRead)
            {
                var expressionItem = reader.ReadNext();
                // todo если скобок не хватает или больше?
                switch (expressionItem)
                {
                    case Operator newOperator:
                        AddOperator(stack, newOperator);
                        break;
                    case Argument newArgument:
                        AddArgument(stack, newArgument);
                        break;
                    case RightBracket rightBracket:
                        var rootInBrackets = GetRoot(stack);
                        return rootInBrackets.Value;
                    case LeftBracket leftBracket:
                        // todo бесконечный цикл?
                        var valueInBrackets = Resolve(reader);
                        expressionItem = new DoubleArgument(valueInBrackets);
                        AddArgument(stack, (Argument)expressionItem);
                        break;
                    default:
                        throw new NotImplementedException("Unrecognized expression item.");
                }
                // todo может не добавлять все?
                stack.Push(expressionItem);
            }

            var root = GetRoot(stack);
            return root.Value;
        }

        private Argument GetRoot(Stack<ExpressionItem> stack)
        {
            return stack
                .OfType<Argument>()
                .Single(x => x.Parent == null);
        }

        private static void AddArgument(Stack<ExpressionItem> stack, Argument newArgument)
        {
            if (stack.Any())
            {
                var previousOperator = (Operator)stack.Peek();
                previousOperator.Right = newArgument;
            }
        }

        private static void AddOperator(Stack<ExpressionItem> stack, Operator newOperator)
        {
            var previousArgument = (Argument) stack.Pop();
            // todo исключение?
            // todo а если скобка?
            Operator previousOperator = null;
            // todo tryPeek?
            if (stack.Any())
            {
                previousOperator = (Operator)stack.Peek();
            }
            if (previousOperator == null)
            {
                newOperator.Left = previousArgument;
            }
            else if (newOperator.Priority >= previousOperator.Priority)
            {
                previousOperator.Right = newOperator;
                newOperator.Left = previousArgument;
            }
            else
            {
                do
                {
                    previousOperator = stack.Pop() as Operator;
                    // todo возможен вечный цикл
                    // todo что со скобками?
                } while (
                    previousOperator == null ||
                    // todo там может быть аргумент?
                    stack.Any() ||
                    // todo может ли прилепиться в середину дерева?
                    newOperator.Priority > previousOperator.Priority);

                newOperator.Left = previousOperator;
            }
        }
    }
}