using System;
using StringСalculator.ExpressionTree;
using StringСalculator.ExpressionTree.Arguments;
using StringСalculator.ExpressionTree.Operators;

namespace Сalculator.ExpressionTree
{
    public class ExpressionReader
    {
        public string Expression { get; }

        public int Pointer { get; private set; }

        public bool CanRead => Expression.Length > Pointer;

        public ExpressionReader(string expression)
        {
            // todo можно и скобочки провалидировать
            Expression = expression.Replace(" ", "");
            Pointer = 0;
        }

        public ExpressionItem ReadNext()
        {
            ExpressionItem result = null;
            char character = Expression[Pointer];
            var newPointer = Pointer + 1;

            if (char.IsDigit(character))
            {
                while (Expression.Length > newPointer &&
                       (char.IsDigit(Expression[newPointer]) ||
                        Expression[newPointer] == ','))
                {
                    newPointer++;
                }

                var digit = Expression.Substring(Pointer, newPointer - Pointer);
                result = new DoubleArgument(double.Parse(digit));
            }
            else if (character == '+')
            {
                result = new Plus();
            }
            else if (character == '-')
            {
                result = new Minus();
            }
            else if (character == '*')
            {
                result = new Multiplication();
            }
            else if (character == '/')
            {
                result = new Division();
            }
            else if (character == '(')
            {
                result = new LeftBracket();
            }
            else if (character == ')')
            {
                result = new RightBracket();
            }
            else
            {
                throw new NotImplementedException();
            }

            Pointer = newPointer;
            return result;
        }
    }
}