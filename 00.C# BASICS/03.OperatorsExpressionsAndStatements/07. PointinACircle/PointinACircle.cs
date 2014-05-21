/*Write an expression that checks if given point (x,  y) is inside a circle K({0, 0}, 2).
 Examples:
 x	    y	        inside
0	    1	        true
-2	    0	        true
-1	    2	        false
1.5	    -1	        true
-1.5   -1.5	        false
100	    -30	        false
0	     0	        true
0.2	    -0.8	    true
0.9	    -1.93	    false
1	    1.655	    true
*/
using System;
class PointinACircle
    {
        static void Main()
        {
            // first variant 
            double xCircle = 1;
            double yCircle = 1;
            double r = 2;
            double d = 2 * r;
            Console.Write("Write point x: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Write point y: ");
            double y = double.Parse(Console.ReadLine());
            //Operator * is faster than Math.Pow()
            bool isInsideTheCircle = Math.Pow(x - xCircle, 2) + Math.Pow(y - yCircle, 2) <= d;
            Console.WriteLine(
                "Point ({0}, {1}) is inside the circle k( x = {2}, y = {3},  r = {4}): {5}"
                 , x, y, xCircle, yCircle, r, isInsideTheCircle
                             );



            // second variant
            //double raduis = 2;

            //Console.Write("Enter X coordinate : ");
            //double x = double.Parse(Console.ReadLine());
            //Console.Write("Enter Y coordinate : ");
            //double y = double.Parse(Console.ReadLine());

            //double point = Math.Sqrt((x * x) + (y * y));

            //Console.WriteLine(point <= raduis ?
            //                    "The Point is IN the Circle"
            //                    : "The Point is OUT of the Circle");
        }
    }