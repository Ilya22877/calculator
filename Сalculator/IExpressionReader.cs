using StringСalculator.ExpressionTree;

namespace Сalculator
{
    public interface IExpressionReader
    {
        bool CanRead { get; }

        ExpressionItem ReadNext();
    }
}