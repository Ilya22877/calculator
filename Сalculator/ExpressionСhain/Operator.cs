using System;

namespace Сalculator.ExpressionСhain
{
    // todo может это цепочка, а не дерево?
    public abstract class Operator : СhainLink
    {
        // todo комменты?
        //public NumberСhainLink Left { get; set; }
        //public NumberСhainLink Right { get; set; }

        public Argument Resolve()
        {
            var result = GetResult();
            // todo дичь вообще-то
            ((Argument)Left).Replace(result);
            ((Argument)Right).Replace(result);
            return result;
        }

        protected abstract Argument GetResult();

        public override void AddNext(СhainLink chainLink)
        {
            // todo Exception замени
            // todo Exception добавить скобки?
            // todo Exception кто должен знать что с чем конектится?
            if (!(chainLink is Argument))
            {
                throw new Exception();
            }

            base.AddNext(chainLink);
        }
    }
}