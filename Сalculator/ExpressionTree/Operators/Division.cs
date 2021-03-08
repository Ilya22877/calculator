using System;
using StringСalculator.ExpressionTree.Arguments;

namespace StringСalculator.ExpressionTree.Operators
{
    public class Division : Operator
    {
        public override Argument GetResult()
        {
            var denominator = Right.Value;
            if (denominator == 0.0)
            {
                throw new DivideByZeroException();
            }
            return new DoubleArgument(Left.Value / denominator);
        }

        public override int Priority => 2;
    }
}