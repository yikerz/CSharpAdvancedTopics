namespace ThreadPoolAndBackgroundThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // normal thread with background setup
            
            new Thread(() =>
            {
                Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId} is started...");
                Thread.Sleep(1000);
                Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId} is ended...");
            })
            { IsBackground = true }.Start();
            

            // thread pool
            /*
            Enumerable.Range(0, 100).ToList().ForEach(i =>
            {
                ThreadPool.QueueUserWorkItem((o) =>
                {
                    Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId} is started...");
                    Thread.Sleep(1000);
                    Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId} is ended...");
                });
            });
            */

            Console.ReadKey();
        }
    }
}
