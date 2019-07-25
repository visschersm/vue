using System;
using System.Threading;

namespace Signaling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Signaling!");

            var signal = new ManualResetEvent(false);

            var t1 = new Thread(() =>
            {
                Console.WriteLine("Waiting for signal...");
                signal.WaitOne();
                //signal.Dispose();
                Console.WriteLine("Got signal!");
            });

            t1.Start();

            Thread.Sleep(2000);
            signal.Set();
            signal.Reset();

            t1.Join();

            new Thread(() =>
            {
                Console.WriteLine("Waiting for second signal...");
                signal.WaitOne();
                signal.Dispose();
                Console.WriteLine("Got second signal!");
            }).Start();
            Thread.Sleep(2000);
            signal.Set();
        }
    }
}
