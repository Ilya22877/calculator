using Сalculator.ExpressionTree.Arguments;

namespace Сalculator.ExpressionTree.Operators
{
    public class Plus : Operator
    {
        public override Argument GetResult()
        {
            // todo перегрузка операторов поможет?
            return new DoubleArgument(Left.Value + Right.Value);
        }
    }
}