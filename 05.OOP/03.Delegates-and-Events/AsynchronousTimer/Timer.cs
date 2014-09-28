using System;
using System.Threading;

namespace AsynchronousTimer
{
    public class Timer
    {
        public static void Work1(int num)
        {
            Console.WriteLine(num);
        }

        public static void Work2(int num)
        {
            Console.Beep();
        }

        static void Main(string[] args)
        {
            AsyncTimer timer1 = new AsyncTimer(Work1, 1000, 10);
            timer1.Start();

            AsyncTimer timer2 = new AsyncTimer(Work2, 900, 10);
            timer2.Start();
        }
    }
}
