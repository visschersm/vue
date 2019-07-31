using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    class Program
    {
        class Test
        {
            public async Task<int> DoSomeThingAsync(IProgress<int> progress, CancellationToken cancellationToken)
            {
                for (int i = 0; i < 100; ++i)
                {
                    progress.Report(i + 1);

                    Thread.Sleep(100);
                }

                return 100;
            }
        };

        static async Task Main(string[] args)
        {
            Test test = new Test();

            Progress<int> progress = new Progress<int>(x =>
            {
                Console.WriteLine($"Current progress: {x}/100");
            });

            CancellationToken cancellationToken = new CancellationToken();
            var asyncTask = test.DoSomeThingAsync(progress, cancellationToken);

            Thread.Sleep(2000);

            var result = await asyncTask;

            Task<int> primeNumberTask = Task.Run(() =>
                Enumerable.Range(2, 3000000).Count(n =>
                    Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));

            var awaiter = primeNumberTask.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                int awaiterResult = awaiter.GetResult();
                Console.WriteLine(awaiterResult);
            });

            var task3 = Task.Run<int>(() =>
            {
                var task1 = Task.Run<int>(() => { Thread.Sleep(2000); return 1; });
                var task2 = Task.Run<int>(() => { Thread.Sleep(2000); return 2; });

                return task1.Result + task2.Result;
            });

            var awaiter2 = task3.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                int awaiterResult = awaiter2.GetResult();
                Console.WriteLine("Tasks complemeted");
            });

            var continuationExampleTask = Task.Run(() => { Console.WriteLine("Another continuation example"); });
            var continuationAwaiter = continuationExampleTask.ConfigureAwait(false).GetAwaiter();
            continuationAwaiter.OnCompleted(() =>
            {
                Console.WriteLine("Same context awaiter");
            });


            var otherContinuationExampleTask = Task.Run<int>(() => { Console.WriteLine("Yet another continuation example"); return 7; });

            otherContinuationExampleTask.ContinueWith(continuationTask =>
            {
                var continuationResult = continuationTask.Result;
                Console.WriteLine($"Continuation result: {continuationResult}");
            });

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
