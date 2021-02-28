using System;

namespace Сalculator.ExpressionTree
{
    public abstract class Operator : Argument
    {
        public Argument Left { get; set; }

        public Argument Right { get; set; }

        public abstract Argument GetResult();

        public override double Value => GetResult().Value;
    }
}