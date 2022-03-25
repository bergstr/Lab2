using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            (int X, int Y) dotTuple;
            int shapePos = -1;
            int Xpos = -1;
            int Ypos = -1;
            int lengthPos = -1;
            int pointsPos = -1;
            Gameplan gameplan = gameplan = new Gameplan();

            try {

                if (args.Count() != 1)
                {
                    throw new Exception("Argument with shapes was incorrectly entered or not present.");
                }

                // Takes the dot input from the user, removes whitespaces, control characters and paranthesis
                // then splits the string into two and converts these to integers
                // finally assigns the integers to our XY tuples first and second position.
                Console.Write("Enter your guess (x,y): ");
                string dotInput = Console.ReadLine();
                string trimmedDotInput = String.Concat(dotInput.Where(x => !char.IsWhiteSpace(x) && !char.IsControl(x))).Replace("(", "").Replace(")", "");
                dotTuple = (Convert.ToInt32(trimmedDotInput.Split(",")[0]), Convert.ToInt32(trimmedDotInput.Split(",")[1]));

                // Read shapes from command line argument
                string shapesFromArgs = args[0].ToUpper();
                string formattedshapesInput = String.Concat(shapesFromArgs.Where(x => !char.IsWhiteSpace(x) && !char.IsControl(x))).Replace("\"", "");

                // Create definitions header from first row (row[0])
                // proceed to create instances of circle, square with foreach, which goes into list of shapes (gameplan)
                bool isFirstRow = true;
                foreach (var row in formattedshapesInput.Split(";", StringSplitOptions.RemoveEmptyEntries))
                {
                    string[] header = row.Split(",");

                    if (header.Count() == 5)
                    {

                        if (isFirstRow)
                        {
                            // Create definitions header from row[0]
                            // if row[0] special foreach-loop
                            shapePos = Array.IndexOf(header, "SHAPE");
                            Xpos = Array.IndexOf(header, "X");
                            Ypos = Array.IndexOf(header, "Y");
                            lengthPos = Array.IndexOf(header, "LENGTH");
                            pointsPos = Array.IndexOf(header, "POINTS");
                            isFirstRow = false;

                        }

                        else
                        {
                            gameplan.AddShape(header[shapePos], Convert.ToInt32(header[Xpos]), Convert.ToInt32(header[Ypos]), Convert.ToInt32(header[lengthPos]), Convert.ToInt32(header[pointsPos]));
                        }
                    }

                    else
                    {
                        throw new Exception("Invalid number of shape variables. Cannot create shapes.");
                    }
                }

                decimal scorehitsum = gameplan.CalculateShapeScore(gameplan.ReturnHits(dotTuple.X, dotTuple.Y));
                decimal scoremissum = gameplan.CalculateShapeScore(gameplan.ReturnMisses(dotTuple.X, dotTuple.Y));

                Console.WriteLine("Your score: " + decimal.Round(gameplan.CalculatePointScore(scorehitsum, scoremissum)));
            
                }

                catch (FormatException)
                {
                    Console.WriteLine("Invalid data format, please try again!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                }

                catch (ArgumentNullException)
                {
                    Console.WriteLine("Invalid data format, please try again!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                }

                catch (Exception e)
                {
                    Console.WriteLine("Error! " + e.Message);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                }
            }
        }
    }
