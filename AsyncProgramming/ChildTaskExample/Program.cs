using System;
using System.Threading;
using System.Threading.Tasks;

namespace ChildTaskExample
{
    class Program
    {
        static void PerformChildTask(object taskNo)
        {
            Console.WriteLine($"Performing child task: {taskNo}");
            Thread.Sleep(1000);
            Console.WriteLine($"Finisned performing child task: {taskNo}.");
        }

        static async Task Main(string[] args)
        {
            var parent = Task.Run(() =>
            {
                Console.WriteLine("Parent starts");

                for (int i = 0; i < 10; ++i)
                {
                    int taskNo = i;
                    Task.Factory.StartNew((x) =>
                    {
                        PerformChildTask(x);
                    }, taskNo, TaskCreationOptions.AttachedToParent);
                }
            });

            await parent;
        }
    }
}
