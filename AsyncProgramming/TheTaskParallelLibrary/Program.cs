﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace TheTaskParallelLibrary
{
    class Program
    {
        static void Task1()
        {
            Console.WriteLine("Task 1 starting");
            Thread.Sleep(1000);
            Console.WriteLine("Task 1 ending");
        }

        static void Task2()
        {
            Console.WriteLine("Task 2 starting");
            Thread.Sleep(1000);
            Console.WriteLine("Task 2 ending");
        }

        static void Main(string[] args)
        {
            Parallel.Invoke(() => Task1(), () => Task2());
            Console.WriteLine("Finished Processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}
