using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space3D
{
    class PathsClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Point3D.StartingPoint.ToString());

            Point3D rectA = new Point3D("A", 1.5, 3, 5.3);
            Point3D rectB = new Point3D("B", 2.5, -3, 5.6);
            Point3D rectC = new Point3D("C", 3.5, 0, 10);
            Point3D rectD = new Point3D("D", -4.5, 8, 8.3);

            Path3D path = new Path3D(rectA, rectB, rectC, rectD);
            Console.WriteLine(path.ToString());

            Console.WriteLine(DistanceCalculator.CalculateDistance3D(rectA, rectD));

            // storage tests
            Storage.SavePath(@"../../userFiles/SavedPaths.txt", false, path);
            //Storage.SavePath(@"../userFiles/SavedPaths.txt", true, path);

            //var loadedList = Storage.LoadPaths(@"../../userFiles/SavedPaths.txt");
            //loadedList.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
