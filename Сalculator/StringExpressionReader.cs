using StringСalculator.ExpressionTree;
using Сalculator.Exceptions;
using Сalculator.ExpressionTree.Arguments;
using Сalculator.ExpressionTree.Operators;

namespace Сalculator
{
    public class StringExpressionReader : IExpressionReader
    {
        public string Expression { get; }
        
        public int Pointer { get; private set; }

        public bool CanRead => Expression.Length > Pointer;

        public StringExpressionReader(string expression)
        {
            Expression = expression.Replace(" ", "");
            Pointer = 0;
        }

        public ExpressionItem ReadNext()
        {
            var character = Expression[Pointer];
            var newPointer = Pointer + 1;

            ExpressionItem result;
            if (char.IsDigit(character))
            {
                while (Expression.Length > newPointer &&
                       (char.IsDigit(Expression[newPointer]) ||
                        Expression[newPointer] == ','))
                {
                    newPointer++;
                }

                var stringDigit = Expression.Substring(Pointer, newPointer - Pointer);
                if (double.TryParse(stringDigit, out var digit))
                {
                    result = new DoubleArgument(digit);
                }
                else
                {
                    throw new CalculatorException(
                        $"Incorrect digit. Expression: {Expression}. position: from {Pointer} to {newPointer}.");
                }
            }
            else switch (character)
            {
                case '+':
                    result = new Plus();
                    break;
                case '-':
                    result = new Minus();
                    break;
                case '*':
                    result = new Multiplication();
                    break;
                case '/':
                    result = new Division();
                    break;
                case '(':
                    result = new LeftBracket();
                    break;
                case ')':
                    result = new RightBracket();
                    break;
                default:
                    throw new CalculatorException(
                        $"Unexpected character: {character}. Expression: {Expression}. position: {Pointer}.");
            }

            Pointer = newPointer;
            return result;
        }
    }
}