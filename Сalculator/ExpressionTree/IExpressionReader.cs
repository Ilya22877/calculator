using StringСalculator.ExpressionTree;

namespace Сalculator.ExpressionTree
{
    public interface IExpressionReader
    {
        bool CanRead { get; }

        ExpressionItem ReadNext();
    }
}