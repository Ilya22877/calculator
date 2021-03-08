using Сalculator.Exceptions;
using Сalculator.ExpressionTree.Arguments;

namespace Сalculator.ExpressionTree.Operators
{
    public class Multiplication : Operator
    {
        public override Argument GetResult()
        {
            if (Left == null || Right == null)
            {
                throw new CalculatorException(
                    $"Argument is missing. Operator: {nameof(Multiplication)}");
            }

            return new DoubleArgument(Left.Value * Right.Value);
        }

        public override int Priority => 4;
    }
}