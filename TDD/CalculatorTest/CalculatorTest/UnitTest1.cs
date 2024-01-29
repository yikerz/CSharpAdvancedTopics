using Domain;

namespace CalculatorTest
{
    // 1. Create xUnit Test project
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // 4. Add project referece with domain and write test for Sum method
            var calculator = new Calculator();
            if (calculator.Sum(2,2) != 4)
            {
                throw new Exception();
            }
        }
    }
}