using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.TestLabArchive
{
    internal class TestLab5a
    {
        public static void Lab5a()
        {
            Point p1 = new(1, 1);
            Console.WriteLine(p1);
            Point p2 = p1.Next(Direction.Right);
            Console.WriteLine(p2);
            p2 = p2.Next(Direction.Right);
            p2 = p2.Next(Direction.Up);
            p2 = p2.Next(Direction.Right);
            p2 = p2.Next(Direction.Up);
            p2 = p2.NextDiagonal(Direction.Up);
            p2 = p2.NextDiagonal(Direction.Up);
            p2 = p2.Next(Direction.Left);
            Console.WriteLine(p2);
            p1 = p1.NextDiagonal(Direction.Down);
            Console.WriteLine(p1);

            Point p3 = new(100, 100);
            p3 = p3.NextDiagonal(Direction.Down);
            p3 = p3.NextDiagonal(Direction.Left);
            Console.WriteLine(p3);
            p3 = p3.NextDiagonal(Direction.Up);
            p3 = p3.NextDiagonal(Direction.Right);
            Console.WriteLine(p3);

            Rectangle R1 = new(1, 1, 7, 8);
            Console.WriteLine(R1);

            Console.WriteLine(R1.Contains(p1)); //False
            Console.WriteLine(R1.Contains(p2)); //True
            Console.WriteLine(R1.Contains(new Point(1, 7))); //True
            Console.WriteLine(R1.Contains(new Point(8, 8))); //False

            Rectangle R2 = new(new Point(-1, -5), new Point(10, 11));
            Console.WriteLine(R2);

            Rectangle R3 = new(p1, p2);
            Console.WriteLine(R3);

            Rectangle R4 = new(2, 8, -5, -4); // odwrócenie współrzędnych
            Console.WriteLine(R4);

            Rectangle R5 = new(p2, p1); // odwrócenie współrzędnych
            Console.WriteLine(R5);


            try
            {
                Rectangle R6 = new(new Point(-1, -1), new Point(11, 11)); // No Exception expected
                Console.WriteLine(R6);

                Rectangle R7 = new(new Point(-1, -1), new Point(-1, 11)); //Exception expected -> X direction
                Console.WriteLine(R7); //exception expected

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }
            finally
            {
                try
                {
                    Rectangle R8 = new(new Point(-1, -1), new Point(11, -1)); //Exception expected -> Y direction
                    Console.WriteLine(R8); //exception expected
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception thrown: {ex.Message}");
                }
            }

            /*
            Expected output:
            (1, 1)
            (2, 1)
            (5, 5)
            (0, 0)
            (98, 100)
            (100, 100)
            (1, 1):(7, 8)
            False
            True
            True
            False
            (-1, -5):(10,11)
            (0, 0):(5, 5)
            (-5, -4):(2, 8)
            (0, 0):(5, 5)
            (-1, -1):(11, 11)
            Exception thrown: X1 and X2 cannot be equal. Rectangle definition requires different point coordinates in both directions. (Parameter 'x2')
            Exception thrown: Y1 and Y2 cannot be equal. Rectangle definition requires different point coordinates in both directions. (Parameter 'y2')
            */
        }
    }
}
