using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    abstract class Shape
    {
        protected int x;
        protected int y;
        protected int length;
        protected int points;

        public abstract decimal CalculateArea();
        public abstract bool CalculateHit(int x, int y);

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public int Length { get { return length; } set { length = value; } }
        public int Points { get { return points; } set { points = value; } }
        public abstract int TypePoint { get; }

    }
}
