using System;
using System.Net;

namespace DistanceCalculatorRESTClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new WebClient())
            {
                var response = client.UploadString("http://localhost:15082/Sum?x=10&y=9", "POST", "");
                Console.WriteLine(response);
            }
        }
    }
}