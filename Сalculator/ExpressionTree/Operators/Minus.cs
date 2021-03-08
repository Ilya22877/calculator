using Сalculator.Exceptions;
using Сalculator.ExpressionTree.Arguments;

namespace Сalculator.ExpressionTree.Operators
{
    public class Minus : Operator
    {
        public override Argument GetResult()
        {
            if (Right == null)
            {
                throw new CalculatorException(
                    $"Argument is missing. Operator: {nameof(Minus)}");
            }

            var leftArgument = Left?.Value ?? 0.0;
            return new DoubleArgument(leftArgument - Right.Value);
        }

        public override int Priority => Left == null && Right != null? 5 : 2;
    }
}