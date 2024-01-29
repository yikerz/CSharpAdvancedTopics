namespace JoinAndAlive
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Main thread is started...");
        //    Thread thread1 = new Thread(ThreadFunction1);
        //    Thread thread2 = new Thread(ThreadFunction2);
        //    thread1.Start();
        //    // join thread lets thread 1 taking over the calling thread (main thread), 
        //    // main thread will wait until thread 1 is done
        //    thread1.Join();
        //    thread2.Start();

        //    Console.WriteLine("Main thread is done...");
        //}

        static void Main(string[] args)
        {
            Console.WriteLine("Main thread is started...");
            Thread thread1 = new Thread(ThreadFunction1);
            Thread thread2 = new Thread(ThreadFunction2);
            thread1.Start();
            // only let thread 1 to take over main thread for 1 second and check if thread is done
            if (thread1.Join(1000))
            {
                Console.WriteLine("Thread 1 is done within 1 second...");
            }
            else
            {
                Console.WriteLine("Thread 1 takes longer than 1 second to execute");
            }
            thread2.Start();

            Console.WriteLine("Main thread is done...");

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(300);
                if (thread1.IsAlive)
                {
                    Console.WriteLine("Thread 1 is still running...");
                }
                else
                {
                    Console.WriteLine("Thread 1 is terminated...");
                }
            }
        }

        public static void ThreadFunction1()
        {
            Console.WriteLine("Thread function 1 is started...");
            Thread.Sleep(3000);
            Console.WriteLine("Thread function 1 is done...");
        }

        public static void ThreadFunction2()
        {
            Console.WriteLine("Thread function 2 is started...");
            Console.WriteLine("Thread function 2 is done...");
        }
    }
}
