using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    /// <summary>
    /// Implements the Square variant of Shape.
    /// </summary>
    class Square : Shape
    {
        private decimal[] rightDiagXY = new decimal[2] { 0, 0 };
        private decimal[] leftDiagXY = new decimal[2] { 0, 0 };

        public override int TypePoint { get { return 1; } }

        public Square()
        {}

        public override decimal CalculateArea() 
        {
            decimal deciLength = Convert.ToDecimal(Length);
            return (deciLength / 4) * (deciLength / 4);
        }
    
        public override bool CalculateHit(int x, int y)
        {
            decimal side = Convert.ToDecimal(this.length / 4.0);
            rightDiagXY[0] = this.x + (side / 2);
            rightDiagXY[1] = this.y + (side / 2);
            leftDiagXY[0] = this.x - (side / 2);
            leftDiagXY[1] = this.y - (side / 2);

            return (x >= leftDiagXY[0] && x <= rightDiagXY[0]) && (y >= leftDiagXY[1] && x <= rightDiagXY[1]);
        }


    }
}
