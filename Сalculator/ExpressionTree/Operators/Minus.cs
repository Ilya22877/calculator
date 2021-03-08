using StringСalculator.ExpressionTree.Arguments;

namespace StringСalculator.ExpressionTree.Operators
{
    public class Minus : Operator
    {
        public override Argument GetResult()
        {
            // todo (Left?.Value ?? 0)
            return new DoubleArgument(Left.Value - Right.Value);
        }

        public override int Priority => 1;
    }
}