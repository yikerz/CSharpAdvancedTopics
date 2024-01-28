using System.Threading;

namespace BasicThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Hello World 1");
            Thread.Sleep(1000);
            Console.WriteLine("Hello World 2");
            Thread.Sleep(1000);
            Console.WriteLine("Hello World 3");
            Thread.Sleep(1000);
            Console.WriteLine("Hello World 4");
            Thread.Sleep(1000);
            */

            Thread thread1 = new Thread(() =>
            {
                Console.WriteLine("Thread 1");
                Thread.Sleep(1000);
            });
            Thread thread2 = new Thread(() =>
            {
                Console.WriteLine("Thread 2");
                Thread.Sleep(1000);
            });
            Thread thread3 = new Thread(() =>
            {
                Console.WriteLine("Thread 3");
                Thread.Sleep(1000);
            });
            Thread thread4 = new Thread(() =>
            {
                Console.WriteLine("Thread 4");
                Thread.Sleep(1000);
            });
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
        }
    }
}
