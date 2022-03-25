using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    class Gameplan
    {
        private List<Shape> shapeList = new List<Shape>() { };
        private List<Shape> hitList = new List<Shape>() { };
        private List<Shape> missList = new List<Shape>() { };

        /// <summary>
        /// Add individual shapes to the coordinate system (gameplan).
        /// </summary>
        /// <param name="shapeInput"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="length"></param>
        /// <param name="points"></param>
        public void AddShape(string shapeInput, int x, int y, int length, int points) 
        {
            if (shapeInput == "CIRCLE") 
            {
                Circle shape = new Circle()
                {
                    X = x,
                    Y = y,
                    Length = length,
                    Points = points
                };
                shapeList.Add(shape);
            }
            else if (shapeInput == "SQUARE")
            {
                Square shape = new Square()
                {
                    X = x,
                    Y = y,
                    Length = length,
                    Points = points
                };
                shapeList.Add(shape);
            }
            else
            {
                throw new Exception("Invalid shape!");
            }
        }


        /// <summary>
        /// Return list of shapes where dot was determined to be inside.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>List<Shape></returns>
        public List<Shape> ReturnHits(int x, int y)
        {
            for (int i = 0; i < shapeList.Count; i++)
            {
                switch (shapeList[i].CalculateHit(x, y))
                {
                    case (true):
                        hitList.Add(shapeList[i]);
                        break; 
                }
            }
            return hitList;
        }

        /// <summary>
        /// Return list of shapes where dot was determined to be outside.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>List<Shape></returns>
        public List<Shape> ReturnMisses(int x, int y)
        {
            for (int i = 0; i < shapeList.Count; i++)
            {
                switch (shapeList[i].CalculateHit(x, y))
                {
                    case (false):
                        missList.Add(shapeList[i]);
                        break;
                }
            }
            return missList;
        }

        public decimal CalculateShapeScore(List<Shape> inputShapeList) 
        {
            decimal sum = 0m;

            for (int i = 0; i < inputShapeList.Count; i++)
            {
                sum += Convert.ToDecimal((inputShapeList[i].TypePoint * inputShapeList[i].Points)) / inputShapeList[i].CalculateArea();
            }
            return sum;
        }

        public decimal CalculatePointScore(decimal hitScoreSum, decimal missScoreSum)
        {
            return hitScoreSum - (Convert.ToDecimal(0.25) * missScoreSum);
        }
    }
}
