using System;

namespace Aplikacja12
{
    public class Program
    {
        public static void Main1()
        {
            try
            {
                new Thread(Run1).Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception");
            }
        }
        static void Run1() { throw null; } // Throws a NullReferenceException

        public static void Main2()
        {
            new Thread(Run2).Start();
        }

        static void Run2()
        {
            try
            {
                throw null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception");
            }
        }

        static void Main3()
        {
            Task.Factory.StartNew(Run3);
            Thread.Sleep(1000); // delay
        }

        static void Run3()
        {
            Console.WriteLine("Hello !! The thread pool!");
        }

        static void Main4()
        {
            ThreadPool.QueueUserWorkItem(Run4);
            ThreadPool.QueueUserWorkItem(Run4, 123);
            Console.ReadLine();
        }

        static void Run4(object data)
        {
            Console.WriteLine("Hello !! The thread pool! " + data);
        }

        static void Main5()
        {
            Func<string, int> method = Do;
            // IAsyncResult cookie = method.BeginInvoke("test", null, null);
            // int result = method.EndInvoke(cookie);
            Task<int> task = Task.Run(() => method("test"));
            int result = task.Result;
            Console.WriteLine("String length is: " + result);
        }

        static int Do (string s)
        {
            return s.Length;
        }


    }
}
