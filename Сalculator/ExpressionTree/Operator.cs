namespace Сalculator.ExpressionTree
{
    public abstract class Operator : Argument
    {
        private Argument _left;

        public Argument Left { 
            get => _left;
            set
            {
                if (value.Parent == null || this.Priority >= value.Parent.Priority)
                {
                    value.Parent = this;
                    _left = value;
                }
                else
                {
                    Left = value.Parent;
                }
            }
        }

        private Argument _right;

        public Argument Right
        {
            get => _right;
            set
            {
                value.Parent = this;
                _right = value;
            }
        }

        public abstract Argument GetResult();

        public override double Value => GetResult().Value;

        public abstract int Priority { get; }
    }
}