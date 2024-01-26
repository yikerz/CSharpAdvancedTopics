namespace InterfaceDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(3);
            double area = circle.CalculateArea();
            Console.WriteLine(area);
            Console.ReadKey();
        }
    }
}
