using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolProgramming
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello ThreadPool!");

            var firstTask = Task.Run<int>(() =>
            {
                Console.WriteLine("Hello from the thread pool");
                return 0;
            });

            ThreadPool.QueueUserWorkItem(notUsed => Console.WriteLine("Hello from old thread pool"));

            /*TaskCompletionSource<int> taskCompletionSource = new TaskCompletionSource<int>()
            {
                Task = new Task<int>(x =>
                {
                    Console.WriteLine("How do I need to use this?");
                })
            };*/

            // Writing a Producer/Consumer Queue P950,C23


            var taskResult = await firstTask;

            var secondTask = Task.Run<int>(() =>
            {
                Console.WriteLine("When result, when await?");
                Thread.Sleep(1000);
                return 777;
            });

            var result = secondTask.Result;
            Console.WriteLine(result);

            Console.WriteLine("Prime example");
            Task<int> primeNumberTask = Task.Run(() =>
            {
                return Enumerable.Range(2, 3000000).Count(n =>
                    Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0));
            });

            Console.WriteLine("Prime Task running...");
            Console.WriteLine($"The answer is: {primeNumberTask.Result}");

        }
    }
}
