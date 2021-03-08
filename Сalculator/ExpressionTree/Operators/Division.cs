using System;
using Сalculator.Exceptions;
using Сalculator.ExpressionTree.Arguments;

namespace Сalculator.ExpressionTree.Operators
{
    public class Division : Operator
    {
        public override Argument GetResult()
        {
            if (Left == null || Right == null)
            {
                throw new CalculatorException(
                    $"Argument is missing. Operator: {nameof(Division)}");
            }

            var denominator = Right.Value;
            if (denominator == 0.0)
            {
                throw new CalculatorException("Attempt to Divide By Zero");
            }
            return new DoubleArgument(Left.Value / denominator);
        }

        public override int Priority => 3;
    }
}