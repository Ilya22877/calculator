namespace StringСalculator.ExpressionTree
{
    // todo нужны вообще разные аргументы?
    // todo кроме double нужны другие?
    // todo большой int посчитает??
    public abstract class Argument : ExpressionItem
    {
        private Operator _parent;

        public Operator Parent
        {
            get => _parent;
            set
            {
                if (_parent != null)
                {
                    if (_parent.Left == this)
                    {
                        _parent.Left = value;
                    }
                    else if(_parent.Right == this)
                    {
                        _parent.Right = value;
                    }
                }
                _parent = value;
            }
        }

        public abstract double Value { get; }

        public virtual int Priority => 3;
    }
}