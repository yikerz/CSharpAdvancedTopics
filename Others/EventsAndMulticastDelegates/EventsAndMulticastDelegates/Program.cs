namespace EventsAndMulticastDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameEngine engine = new GameEngine();
            AudioSystem audioSystem = new AudioSystem();
            Player player1 = new Player("Travis");
            Player player2 = new Player("Carmen");

            GameEventManager.OnGameStart();

            Console.WriteLine("Press any key to stop the game...");
            Console.ReadKey();

            GameEventManager.OnGameStop();
            Console.ReadKey();


        }
    }
}
