using System;
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

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
