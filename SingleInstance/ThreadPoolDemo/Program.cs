using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadPoolDemo
{
    class Program
    {
        static void ShowMyText(Object state)
        {
            string Text = (string)state + $" {Thread.CurrentThread.ManagedThreadId}";
            Console.WriteLine(Text);
        }
        static void Main(string[] args)
        {
            var thread1 = new WaitCallback(ShowMyText);
            ThreadPool.QueueUserWorkItem(thread1);
            Console.ReadKey();
        }
    }
}
