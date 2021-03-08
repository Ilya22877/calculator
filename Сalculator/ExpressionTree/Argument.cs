using StringСalculator.ExpressionTree;

namespace Сalculator.ExpressionTree
{
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
    }
}