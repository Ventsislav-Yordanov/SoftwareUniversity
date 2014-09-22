using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space3D
{
    static class Storage
    {
        public static void SavePath(string fullFileName, bool append, Path3D path)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(fullFileName, append, Encoding.GetEncoding("UTF-8")))
                {
                    streamWriter.WriteLine(path.ToString());
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw exception.InnerException;
            }
        }

        public static List<Path3D> LoadPaths(string fullFileName)
        {
            try
            {
                List<Path3D> paths = new List<Path3D>();
                using (StreamReader streamReader = new StreamReader(fullFileName, Encoding.GetEncoding("UTF-8")))
                {
                    string line = streamReader.ReadLine();
                    while (line != null)
                    {
                        Path3D points = new Path3D();
                        var lines = line.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var lin in lines)
                        {
                            points.Add(Point3D.Deserialize(lin));
                        }

                        line = streamReader.ReadLine();
                        paths.Add(points);
                    }
                }
                return paths;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw exception.InnerException;
            }
        }
    }
}