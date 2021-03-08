﻿using System;

namespace StringСalculator.ExpressionTree
{
    public abstract class Operator : Argument
    {
        private Argument _left;

        public Argument Left { 
            get => _left;
            set
            {
                if (value.Parent != null && (value is Operator || this.Priority < value.Parent.Priority))
                {
                    this.Left = value.Parent;
                }
                else
                {
                    value.Parent = this;
                    _left = value;
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
    }
}