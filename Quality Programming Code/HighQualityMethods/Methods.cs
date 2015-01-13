using System;

namespace Methods
{
    class Methods
    {
        static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("All sides of the triangle should be positive integer numbers.");
            }
            else if (a + b <= c)
            {
                throw new ArgumentOutOfRangeException(c.ToString(), "Side C must be bigger than the sum of side A and side B");
            }
            else if (a + c <= b)
            {
                throw new ArgumentOutOfRangeException(b.ToString(), "Side B must be bigger than the sum of side A and side C");
            }
            else if (b + c <= a)
            {
                throw new ArgumentOutOfRangeException(a.ToString(), "Side A must be bigger than the sum of side B and side C");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            return area;
        }

        static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    throw new ArgumentException(String.Format("Number {0} can not be converted", number));
            }
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Parameter elements cannot be null or empty!");
            }

            int maxElement = int.MinValue;
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }
            return maxElement;
        }

        static void PrintAsNumber(object number, string format)
        {
            if ((number is int) || (number is double) || (number is float) || (number is long) || (number is decimal))
            {
                switch (format)
                {
                    case "f":
                        Console.WriteLine("{0:f2}", number);
                        break;
                    case "%":
                        Console.WriteLine("{0:p0}", number);
                        break;
                    case "r":
                        Console.WriteLine("{0,8}", number);
                        break;
                    default:
                        throw new ArgumentException("The specified format is not valid");
                }
            }
            else
            {
                throw new ArgumentException("Number is not valid. Type must be int, double, float, long or decimal.");
            }
        }


        static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            
            return distance;
        }

        static bool LineIsHorizontal(double x1, double y1, double x2, double y2)
        {
            return y1 == y2;
        }

        static bool LineIsVertical(double x1, double y1, double x2, double y2)
        {
            return x1 == x2;
        }

        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(NumberToDigit(5));

            Console.WriteLine(FindMax(5));

            PrintAsNumber(1375234.3462d, "f");
            PrintAsNumber(50.89m, "%");
            PrintAsNumber(-230.6773547434743354272f, "r");

            Console.WriteLine("Distance : {0}", CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine("Is line horizontal ? - {0}", LineIsHorizontal(3, -1, 3, 2.5));
            Console.WriteLine("Is line vertical ? - {0}", LineIsVertical(3, -1, 3, 2.5));

            Student ivo = new Student() { FirstName = "Ivo", LastName = "Petrov" };
            ivo.OtherInfo = "From Ruse, born at 11.10.1994";

            Student marto = new Student() { FirstName = "Martin", LastName = "Mitev" };
            marto.OtherInfo = "From Burgas, programmer, likes dogs, born at 03.11.1993";

            if (ivo.IsOlderThan(marto))
            {
                Console.WriteLine("{0} is older than {1}", ivo.FirstName, marto.FirstName);
            }
            else
            {
                Console.WriteLine("{0} is older than {1}", marto.FirstName, ivo.FirstName);
            }
        }
    }
}
