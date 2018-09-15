using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SingleInstance
{
   
    class Program
    {
        const string Name = "RUNMEONLYONCE";
        static void Main(string[] args)
        {
             Mutex MyMutex = null;
            while (true)
            {
                try
                {
                    MyMutex = Mutex.OpenExisting(Name);
                    MyMutex.Close();
                }
                catch (WaitHandleCannotBeOpenedException)
                {
                    Console.WriteLine("Exc");
                }
            }
            
        }
    }
}
