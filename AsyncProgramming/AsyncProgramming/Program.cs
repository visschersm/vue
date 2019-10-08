using System;
using System.Collections.Generic;
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

        static void DoOtherChildTask(object i)
        {
            Console.WriteLine($"Do child task: {i}");
            Thread.Sleep(100);
            Console.WriteLine($"Ending child task: {i}");
        }

        static void ThreadTask()
        {
            Console.WriteLine("Starting thread...");
            Thread.Sleep(1000);
            Console.WriteLine("Ending thread...");
        }

        static void ThreadTask2()
        {
            Console.WriteLine("Starting thread2...");
            Thread.Sleep(1000);
            Console.WriteLine("Ending thread2...");
        }

        static async Task Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread nextThread = new Thread((x) =>
                {
                    Console.WriteLine($"Starting thread: {x}");
                    Thread.Sleep(100);
                    Console.WriteLine($"Ending thread: {x}");
                });

                nextThread.Start(i);
            }

            return;

            Thread thread = new Thread(ThreadTask);
            Thread thread2 = new Thread(ThreadTask2);
            thread.Start();
            thread2.Start();

            thread.Join();
            thread2.Join();



            return;
            var papaTask = Task.Run(() =>
            {
                Console.WriteLine("Starting papa task");
                Thread.Sleep(1000);

                var child1Task = Task.Run(() =>
                {
                    Console.WriteLine("Starting child1 task");
                    Thread.Sleep(1000);
                    Console.WriteLine("Ending child1 task");
                });

                var child2Task = Task.Run(() =>
                {
                    Console.WriteLine("Starting child2 task");
                    Thread.Sleep(1000);
                    Console.WriteLine("Ending child2 task");
                });

                Task.WaitAll(child1Task, child2Task);

                Console.WriteLine("Ending papa task");
            });

            var otherPapaTask = Task.Run(() =>
            {
                Console.WriteLine("Starting other papa task");

                List<Task> tasks = new List<Task>();
                for (int i = 0; i < 10; ++i)
                {
                    var taskNum = i;
                    var task = Task.Run(() => DoOtherChildTask(taskNum));
                    tasks.Add(task);
                }

                Task.WaitAll(tasks.ToArray());
            });

            Task.WaitAll(papaTask, otherPapaTask);

            Console.WriteLine("Ending processing");

            return;

            Parallel.Invoke(() =>
            {
                Console.WriteLine("Starting task 1");
                Thread.Sleep(1000);
                Console.WriteLine("Ending task 1");
            },
            () =>
            {
                Console.WriteLine("Starting task 2");
                Thread.Sleep(1000);
                Console.WriteLine("Ending task 1");
            });

            Parallel.For(0, 10, (i) =>
            {
                Console.WriteLine($"For with index: {i}");
                Thread.Sleep(100);
                Console.WriteLine($"Done with index: {i}");
            });

            Parallel.ForEach(new List<int> { 1, 2, 3, 4, 5 }, i =>
            {
                Console.WriteLine($"ForEach with item: {i}");
                Thread.Sleep(100);
                Console.WriteLine($"Done with item: {i}");
            });

            Console.WriteLine("Done processing...");
            return;
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
