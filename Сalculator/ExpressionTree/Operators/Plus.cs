using StringСalculator.ExpressionTree.Arguments;

namespace StringСalculator.ExpressionTree.Operators
{
    public class Plus : Operator
    {
        public override Argument GetResult()
        {
            // todo перегрузка операторов поможет?
            return new DoubleArgument(Left.Value + Right.Value);
        }

        public override int Priority => 1;
    }
}