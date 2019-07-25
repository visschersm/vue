using System;
using System.Threading;

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
