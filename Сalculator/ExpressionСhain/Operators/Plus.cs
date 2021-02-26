namespace Сalculator.ExpressionСhain.Operators
{
    // todo в отдельную папочку выражения?
    // todo название папки?
    public class Plus: Operator
    {
        protected override Argument GetResult()
        {
            // todo точен ли будет результат? везде double?
            // todo нужно указать с какими аргументами может работать
            return new Argument(Right.Value + Left.Value);
        }
    }
}