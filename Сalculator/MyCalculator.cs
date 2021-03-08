using System;
using System.Collections.Generic;
using System.Linq;
using StringСalculator.ExpressionTree;
using Сalculator.Exceptions;
using Сalculator.ExpressionTree;
using Сalculator.ExpressionTree.Arguments;

namespace Сalculator
{
    public static class MyCalculator
    {
        public static double Resolve(IExpressionReader reader, bool isBrackets = false)
        {
            var expression = new List<Argument>();
            while (reader.CanRead)
            {
                var expressionItem = reader.ReadNext();
                switch (expressionItem)
                {
                    case Operator newOperator:
                        AddOperator(expression, newOperator);
                        break;
                    case Argument newArgument:
                        AddArgument(expression, newArgument);
                        break;
                    case RightBracket rightBracket:
                        if (!isBrackets)
                        {
                            throw new CalculatorException("Left bracket is missing");
                        }
                        var rootInBrackets = GetRoot(expression);
                        return rootInBrackets.Value;
                    case LeftBracket leftBracket:
                        var valueInBrackets = Resolve(reader, true);
                        AddArgument(expression, new DoubleArgument(valueInBrackets));
                        continue;
                    default:
                        throw new NotImplementedException("Unrecognized expression item.");
                }
            }

            if (isBrackets)
            {
                throw new CalculatorException("Right bracket is missing");
            }

            var root = GetRoot(expression);
            return root.Value;
        }

        private static Argument GetRoot(List<Argument> expression)
        {
            return expression.Single(x => x.Parent == null);
        }

        private static void AddArgument(List<Argument> expression, Argument newArgument)
        {
            if (expression.Any())
            {
                var previousOperator = expression.Last() as Operator;
                if (previousOperator == null)
                {
                    throw new CalculatorException("There must be an operator before an argument");
                }
                previousOperator.Right = newArgument; 
            }

            expression.Add(newArgument);
        }

        private static void AddOperator(List<Argument> expression, Operator newOperator)
        {
            if (expression.Any())
            {
                var previousArgument = expression.Last();
                if (previousArgument is Operator)
                {
                    throw new CalculatorException("There must be an argument before an operator");
                }
                newOperator.Left = previousArgument;
            }

            expression.Add(newOperator);
        }
    }
}