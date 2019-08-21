using System;
using System.Threading;
using System.Threading.Tasks;

namespace Listing_01._14
{
    class Program
    {
        static void DoWork(int taskNumber)
        {
            Console.WriteLine($"Do work on task: {taskNumber}");
            Thread.Sleep(1000);
            Console.WriteLine($"Completed work on task: {taskNumber}");
        }

        static void Main(string[] args)
        {
            Task[] tasks = new Task[10];

            for (int i = 0; i < 10; ++i)
            {
                int taskNumber = i;
                tasks[i] = Task.Run(() =>
                {
                    DoWork(taskNumber);
                });
            }

            Task.WaitAll(tasks);
        }
    }
}
