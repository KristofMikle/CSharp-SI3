using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SimpleThreadingDemo
{
    class Program
    {
        public static Thread thread1;
        public static Thread thread2;
        static void Counting()
        {
            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine($"{i} "+ Thread.CurrentThread.ManagedThreadId);
                if (Thread.CurrentThread.Name == "Thread1" &&
          thread2.ThreadState != ThreadState.Unstarted)
                    thread2.Join();

                Thread.Sleep(10);
                Console.WriteLine("\nCurrent thread: {0}", Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("Thread1: {0}", thread1.ThreadState);
                Console.WriteLine("Thread2: {0}\n", thread2.ThreadState);
            }
        }
        static void Main(string[] args)
        {
            thread1 = new Thread(Counting);
            thread1.Start();
            thread2 = new Thread(Counting);
            thread2.Start();
            
            Console.ReadKey();
        }
    }
}
