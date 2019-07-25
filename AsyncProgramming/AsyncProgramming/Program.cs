using System;
using System.Threading;

namespace AsyncProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello AsyncProgramming!");

            Thread t = new Thread(BackgroundTask);
            t.Start();

            for (int i = 0; i < 1000; ++i)
            {
                Console.WriteLine("Main");
            }

            t.Join();
            Console.WriteLine("Thread has ended");

            Console.WriteLine("Press any key");
            Console.Read();
        }

        static void BackgroundTask()
        {
            for (int i = 0; i < 1000; ++i)
            {
                Console.WriteLine("Thread");
            }
        }
    }
}
