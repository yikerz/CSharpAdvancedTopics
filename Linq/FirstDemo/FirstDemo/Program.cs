namespace FirstDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            OddNumbers(nums);
            Console.ReadKey();
        }

        public static void OddNumbers(int[] nums)
        {
            IEnumerable<int> oddNums = from num in nums
                                     where num % 2 != 0
                                     select num;
            foreach (int num in oddNums)
            {
                Console.WriteLine(num);
            }
        }
    }
}
