namespace StringСalculator.ExpressionTree.Arguments
{
    public class DoubleArgument : Argument
    {
        public DoubleArgument(double value)
        {
            Value = value;
        }

        public override double Value { get; }
    }
}