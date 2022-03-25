using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    class Circle : Shape
    {
        public override int TypePoint { get { return 2; } }

        public Circle() 
        {}

        public override decimal CalculateArea()
        {
            decimal r;
            r = Convert.ToDecimal(length / (2 * Math.PI));
            return ((r * r) * Convert.ToDecimal(Math.PI));
        }

        public override bool CalculateHit(int x, int y)
        {
            decimal r;
            r = Convert.ToDecimal(length / (2 * Math.PI));
            /* Help from https://www.geeksforgeeks.org/find-if-a-point-lies-inside-or-on-circle/ */
            return ((x - this.x) * (x - this.x) + (y - this.y) * (y - this.y) <= (r * r));
        }
    }
}
