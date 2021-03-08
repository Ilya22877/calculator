using System;
using System.Collections.Generic;
using System.Linq;
using StringСalculator.ExpressionTree;
using StringСalculator.ExpressionTree.Arguments;
using Сalculator.ExpressionTree;

namespace Сalculator
{
    public static class MyCalculator
    {
        public static double Resolve(IExpressionReader reader)
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

        private static Argument GetRoot(Stack<ExpressionItem> stack)
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
            //Argument previousArgument = null;
            //do
            //{
            //    previousArgument = (Argument)stack.Pop();
            //    if (!stack.Any())
            //    {
            //        var cwecew = 1;
            //    }
            //    // todo возможен вечный цикл
            //    // todo это нужно перенести в свойства дерева
            //} while (
            //    // todo там может быть аргумент?
            //    stack.Any() ||
            //    // todo может ли прилепиться в середину дерева?
            //    newOperator.Priority < previousArgument.Priority);

            var previousArgument = (Argument)stack.Pop();
            newOperator.Left = previousArgument;

            //var previousArgument = (Argument)stack.Pop();
            //// todo исключение?
            //// todo а если скобка?
            //Operator previousOperator = null;
            //// todo tryPeek?
            //if (stack.Any())
            //{
            //    previousOperator = (Operator)stack.Peek();
            //}
            //if (previousOperator == null)
            //{
            //    newOperator.Left = previousArgument;
            //}
            //else if (newOperator.Priority >= previousOperator.Priority)
            //{
            //    newOperator.Left = previousArgument;
            //}
            //else
            //{
            //    do
            //    {
            //        previousOperator = stack.Pop() as Operator;
            //        // todo возможен вечный цикл
            //        // todo это нужно перенести в свойства дерева
            //    } while (
            //        // todo там может быть аргумент?
            //        stack.Any() );


            //    newOperator.Left = previousOperator;
            //}
        }
    }
}