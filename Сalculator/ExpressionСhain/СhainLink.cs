namespace Сalculator.ExpressionСhain
{
    public abstract class СhainLink
    {
        public СhainLink Left { get; set; }
        public СhainLink Right { get; set; }

        public virtual void AddNext(СhainLink number)
        {
            Right = number;
            number.Left = this;
        }

        public virtual void ResolveСhain()
        {
            
        }
    }
}