using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Space3D
{
    class PathsClass
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Console.WriteLine(Point3D.StartingPoint.ToString());

            Point3D rectA = new Point3D("A", 1.4, 3, 35.6);
            Point3D rectB = new Point3D("B", 3.2, 5, 15.6);
            Console.WriteLine(rectB.ToString());
            Point3D rectC = new Point3D("C", 1.2, -3, 2.6);
            Point3D rectD = new Point3D("D", 2.2, 4, -5.6);

            Path3D path = new Path3D(rectA, rectB, rectC, rectD);

            Console.WriteLine("Distance between rectA and rectD : {0}",DistanceCalculator.CalculateDistance3D(rectA,rectD));

            Storage.SavePath(@"../../UserFiles/SavedPaths.txt", false, path);
            Storage.SavePath(@"../../UserFiles/SavedPaths.txt", true, path);

            var loadedList = Storage.LoadPaths(@"../../UserFiles/SavedPaths.txt");
            loadedList.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
