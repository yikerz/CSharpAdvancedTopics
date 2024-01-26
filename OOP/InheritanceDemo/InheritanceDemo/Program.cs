namespace InheritanceDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ImagePost imagePost1 = new ImagePost();
            Console.WriteLine(imagePost1.ToString());
            ImagePost imagePost2 = new ImagePost("Second Post", "Travis", true, "www.abc.com/image");
            Console.WriteLine(imagePost2.ToString());
            Console.ReadKey();
        }
    }
}
