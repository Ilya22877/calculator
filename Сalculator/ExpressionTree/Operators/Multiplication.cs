using StringСalculator.ExpressionTree.Arguments;

namespace StringСalculator.ExpressionTree.Operators
{
    public class Multiplication : Operator
    {
        public override Argument GetResult()
        {
            return new DoubleArgument(Left.Value * Right.Value);
        }

        // todo enum
        public override int Priority => 1;
    }
}