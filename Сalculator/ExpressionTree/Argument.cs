namespace StringСalculator.ExpressionTree
{
    // todo нужны вообще разные аргументы?
    // todo кроме double нужны другие?
    // todo большой int посчитает??
    public abstract class Argument : ExpressionItem
    {
        public Operator Parent { get; set; }

        public abstract double Value { get; }
    }
}