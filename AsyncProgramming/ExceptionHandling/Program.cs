using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            try
            {
                SyncExceptionFunction();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Catch Sync Exception");
            }
            finally
            {

            }

            new Thread(GoAysncException).Start();

            //Task task = Task.Run(() =>
            //{
            //    Thread.Sleep(1000);
            //    throw null;
            //});

            Task task = Task.Run<int>(() =>
            {
                Thread.Sleep(1000);
                throw null;

                return 1;
            });

            try
            {

                task.Wait();
            }
            catch (AggregateException aggregateException)
            {
                if (aggregateException.InnerException is NullReferenceException)
                    Console.WriteLine("Null from task");
                else
                    throw;
            }
        }

        public static void SyncExceptionFunction()
        {
            throw new NotImplementedException();
        }

        public static void GoAysncException()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch
            {
                Console.WriteLine("Catch threading exception");
            }
        }
    }
}
