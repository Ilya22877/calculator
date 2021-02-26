using System;

namespace Сalculator.ExpressionСhain
{
    // todo добавить NumberСhainLink
    public class Argument : СhainLink
    {
        public Argument(double value)
        {
            Value = value;
        }

        //public ExpressionСhainLink Left { get; set; }
        //public ExpressionСhainLink Right { get; set; }

        public double Value { get; }

        public void Replace(Argument newArgument)
        {
            // todo а если null?
            Left.Right = newArgument;
            Right.Left = newArgument;
        }

        public override void AddNext(СhainLink chainLink)
        {
            // todo Exception замени
            // todo Exception добавить скобки?
            if (!(chainLink is Operator))
            {
                throw new Exception();
            }

            base.AddNext(chainLink);
        }
    }
}