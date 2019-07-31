using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Listing_01._03
{
    class Program
    {
        static void WorkOnItem(object item)
        {
            Console.WriteLine($"Started working on: {item}");
            Thread.Sleep(100);
            Console.WriteLine($"Finished working on: {item}");
        }

        static void Main(string[] args)
        {
            var items = Enumerable.Range(0, 500).ToArray();

            Parallel.For(0, items.Length, i =>
            {
                WorkOnItem(items[i]);
            });
        }
    }
}
